using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Glav.PasswordMgr.Engine.Exceptions;
using System.IO;
using System.Security;
using System.ComponentModel;
using System.Data.Linq;
using System.Linq;

namespace Glav.PasswordMgr.Engine
{
    /// <summary>
    /// The manager class that contains the password list.
    /// </summary>
    /// <remarks>This class could be improved substantially by implement a Current property to help facilitate
    /// the likes of DataBinding which could be better used within the associated UI.</remarks>
    public class PasswordManagerContainer : IDisposable, INotifyPropertyChanged
    {
        #region Private fields

        private SortedList<string, PasswordEntry> _entryList = new SortedList<string, PasswordEntry>();
        private string _listTitle = null;
        private bool _dataChanged = false;
        private string _filename = null;
        private SecureString _passPhrase = null;
        private PasswordEntry _currentEntry = null;

        #endregion

        #region Public events

        public event PasswordMergedDelegate PasswordMerged;
        public event PasswordMergedDelegate PasswordMergeError;

        #endregion

        #region Pubic properties

        /// <summary>
        /// Returns the current password entry that this container is positioned on.
        /// </summary>
        public PasswordEntry Current
        {
            get { return _currentEntry; }
            set
            {
                _currentEntry = value;
                OnPropertyChanged("Current");
            }
        }

        #region "Current" property members - good for databinding
        public string CurrentComment
        {
            get
            {
                if (_currentEntry != null)
                    return _currentEntry.Comment;
                else
                    return string.Empty;
            }
            set
            {
                if (_currentEntry != null)
                {
                    _currentEntry.Comment = value;
                    OnPropertyChanged("CurrentComment");
                }
            }
        }
        public string CurrentTitle
        {
            get
            {
                if (_currentEntry != null)
                    return _currentEntry.Title;
                else
                    return string.Empty;
            }
            set
            {
                if (_currentEntry != null)
                {
                    _currentEntry.Title = value;
                    OnPropertyChanged("CurrentTitle");
                }
            }
        }
        public string CurrentUserID
        {
            get
            {
                if (_currentEntry != null)
                    return _currentEntry.UserID;
                else
                    return string.Empty;
            }
            set
            {
                if (_currentEntry != null)
                {
                    _currentEntry.UserID = value;
                    OnPropertyChanged("CurrentUserID");
                }
            }
        }
        public string CurrentUrl
        {
            get
            {
                if (_currentEntry != null)
                    return _currentEntry.Url;
                else
                    return string.Empty;
            }
            set
            {
                if (_currentEntry != null)
                {
                    _currentEntry.Url = value;
                    OnPropertyChanged("CurrentUrl");
                }
            }
        }
        public SecureString CurrentPasswordData
        {
            get
            {
                if (_currentEntry != null)
                    return _currentEntry.PasswordData;
                else
                    return new SecureString();
            }
            set
            {
                if (_currentEntry != null)
                {
                    _currentEntry.PasswordData = value;
                    OnPropertyChanged("CurrentPasswordData");
                }
            }
        }
        public DateTime CurrentModifiedDateTime
        {
            get
            {
                if (_currentEntry != null)
                    return _currentEntry.ModifiedDateTime;
                else
                    return DateTime.MinValue;
            }
            set
            {
                if (_currentEntry != null)
                {
                    _currentEntry.ModifiedDateTime = value;
                    OnPropertyChanged("CurrentModifiedDateTime");
                }
            }
        }

        public int NumberOfPasswords
        {
            get
            {
                int cnt = 0;
                if (_entryList != null)
                    cnt = _entryList.Count;
                return cnt;
            }
        }

        #endregion


        /// <summary>
        /// The passphrase (stored in a secure string) to access and save the password file.
        /// </summary>
        public SecureString Passphrase
        {
            get { return _passPhrase; }
            set
            {
                _passPhrase = value;
                OnPropertyChanged("Passphrase");
            }
        }

        /// <summary>
        /// The name of this set of passwords, or this list of passwords.
        /// </summary>
        public string ListTitle
        {
            get { return _listTitle; }
            set
            {
                if (value != _listTitle)
                {
                    _listTitle = value;
                    _dataChanged = true;
                    OnPropertyChanged("ListTitle");
                }
            }
        }

        /// <summary>
        /// Flag to indicate whether the data has changed but has not been committed or saved yet
        /// </summary>
        /// <remarks>It may seem odd that we allow consumers to change/set this value however when a UI does
        /// a large load and refresh and UI events are triggered, this can result in events being fired that cause
        /// data to be SET in this container even though its the same data. While its possible to prevent this with
        /// UI management and/or checks for setting the same data, this method is easier and performs better at the
        /// risk of seeming like an odd interface mechanism.</remarks>
        public bool HasChanged
        {
            get
            {
                if (!_dataChanged)
                {
                    foreach (var pwd in _entryList.Values)
                    {
                        if (pwd.IsDataModified)
                        {
                            return true;
                        }
                    }
                }
                return _dataChanged;
            }
        }

        /// <summary>
        /// A simple array of the list of password entries currently held in memory
        /// </summary>
        public PasswordEntry[] PasswordList
        {
            get
            {
                PasswordEntry[] list = new PasswordEntry[_entryList.Count];
                _entryList.Values.CopyTo(list, 0);
                return list;
            }
        }

        /// <summary>
        /// The filename (if any) used to store/load the passwords.
        /// </summary>
        public string Filename
        {
            get { return _filename; }
        }

        #endregion

        #region ClearAll

        public void ClearAll(bool clearPassphrase)
        {
            //FOR TESTING ONLY
            //COMMENT OUT THIS FOREACH LOOP TO INTRODUCE A MEMORY LEAK.
            foreach (KeyValuePair<string, PasswordEntry> kv in _entryList)
            {
                if (kv.Value != null)
                    kv.Value.Dispose();
            }

            _entryList = new SortedList<string, PasswordEntry>();
            _filename = null;
            _listTitle = null;

            if (clearPassphrase && _passPhrase != null)
                _passPhrase.Dispose();
            Current = null;
            _dataChanged = false;

            OnPropertyChanged("NumberOfPasswords");
            OnPropertyChanged("PasswordList");
            OnPropertyChanged("ListTitle");
        }

        public void ClearAll()
        {
            ClearAll(true);
        }
        #endregion

        #region AddEntry

        public void AddEntry(string title, string UserID, string url, string comment, SecureString passwordData)
        {
            PasswordEntry newEntry = new PasswordEntry();
            newEntry.Title = title;
            newEntry.UserID = UserID;
            newEntry.Url = url;
            newEntry.ModifiedDateTime = DateTime.Now;
            newEntry.Comment = comment;
            newEntry.PasswordData = passwordData;

            _entryList.Add(title, newEntry);

            Current = newEntry;

            _dataChanged = true;

            OnPropertyChanged("NumberOfPasswords");
            OnPropertyChanged("PasswordList");


        }

        #endregion

        #region DeleteEntry

        public void DeleteEntry(string title)
        {
            if (_entryList.ContainsKey(title))
            {
                PasswordEntry pe = _entryList[title];
                _entryList.Remove(title);
                pe.Dispose();
            }

            if (_entryList.Count > 0)
            {
                IEnumerator<KeyValuePair<string, PasswordEntry>> ie = _entryList.GetEnumerator();
                ie.Reset();
                if (ie.MoveNext())
                    Current = ie.Current.Value;
                else
                    Current = null;
            }
            else
                Current = null;

            _dataChanged = true;

            OnPropertyChanged("NumberOfPasswords");
            OnPropertyChanged("PasswordList");
        }

        #endregion

        #region FindEntry
        /// <summary>
        /// Searches every textual field in each password entry object for the specified search data.
        /// NOT case sensitive
        /// </summary>
        /// <param name="searchData"></param>
        /// <param name="startEntry">The entry from which searching starts</param>
        /// <returns></returns>
        public PasswordEntry FindEntry(string searchData, PasswordEntry startEntry)
        {
            PasswordEntry foundEntry = null;

            string srchUpper = string.Empty;
            if (searchData != null)
                srchUpper = searchData.ToUpper();

            bool doSearch = false;
            foreach (PasswordEntry entry in _entryList.Values)
            {
                // if the index is greater or equal to the specified starting position, then include the item in the search
                if (!doSearch && entry == startEntry || startEntry == null)
                {
                    doSearch = true;
                    if (startEntry != null)
                        continue;  // if we dont continue, we will always return the 
                }

                if (doSearch)
                {
                    if (entry.Title.ToUpper().Contains(srchUpper) || entry.Url.ToUpper().Contains(srchUpper) ||
                        entry.UserID.ToUpper().Contains(srchUpper) || entry.Comment.ToUpper().Contains(srchUpper))
                    {
                        foundEntry = entry;
                        break;
                    }
                }
            }

            if (foundEntry != null)
                Current = foundEntry;

            return foundEntry;
        }

        /// <summary>
        /// Starts a brand new search from index position zero.
        /// </summary>
        /// <param name="searchData"></param>
        /// <returns></returns>
        public PasswordEntry FindEntry(string searchData)
        {
            return FindEntry(searchData, null);
        }
        #endregion

        #region UpdateEntry

        public void UpdateEntry(string oldTitle, string newTitle, string userID, string url, SecureString passwordData, string comment)
        {
            if (_entryList.ContainsKey(oldTitle))
            {
                PasswordEntry modEntry = _entryList[oldTitle];

                modEntry.Title = newTitle;
                modEntry.UserID = userID;
                modEntry.Url = url;
                modEntry.Comment = comment;
                modEntry.PasswordData = passwordData;

                modEntry.ModifiedDateTime = DateTime.Now;

                _entryList.Remove(oldTitle);
                _entryList.Add(newTitle, modEntry);

                OnPropertyChanged("Current");
                _dataChanged = true;
            }
            else
            {
                PasswordException pex = new PasswordException("Unable to update entry. Original entry not found to update.");
                throw pex;
            }
        }
        #endregion

        #region Save / Load routines

        public void LoadFile(string filename)
        {
            ClearAll(false);
            Crypto.CryptoContainer crypt = new Glav.PasswordMgr.Engine.Crypto.CryptoContainer(this._passPhrase);
            PasswordManagerContainerFileData fileData = (PasswordManagerContainerFileData)crypt.DecryptFromFile(filename);

            this._listTitle = fileData.ListTitle;
            foreach (PasswordEntry entry in fileData.PasswordList)
                this._entryList.Add(entry.Title, entry);
            _dataChanged = false;
            _filename = filename;
            OnPropertyChanged("PasswordList");
            OnPropertyChanged("NumberOfPasswords");
            OnPropertyChanged("ListTitle");
        }

        public void SaveFile(string filename)
        {
            BackupOriginalFile(filename);

            PasswordManagerContainerFileData fileData = new PasswordManagerContainerFileData();
            fileData.ListTitle = this._listTitle;
            fileData.PasswordList = new PasswordEntry[this._entryList.Count];
            this._entryList.Values.CopyTo(fileData.PasswordList, 0);

            Crypto.CryptoContainer crypt = new Glav.PasswordMgr.Engine.Crypto.CryptoContainer(this._passPhrase);

            crypt.EncryptToFile(filename, fileData);
            _filename = filename;
            _dataChanged = false;

            _entryList.Values.Where(p => p.IsDataModified == true).ToList().ForEach(p => p.IsDataModified = false);
        }

        public void SaveFile()
        {
            if (!string.IsNullOrEmpty(this._filename))
                SaveFile(this._filename);
        }

        /// <summary>
        /// Backs up the old file to a new file.
        /// </summary>
        /// <param name="filename"></param>
        private void BackupOriginalFile(string filename)
        {
            if (File.Exists(filename))
            {
                string backupFilename = string.Format("{0}.original.bak", filename);
                if (File.Exists(backupFilename))
                    File.Delete(backupFilename);

                byte[] oldData = File.ReadAllBytes(filename);

                File.WriteAllBytes(backupFilename, oldData);
            }
        }

        #endregion

        #region DoesEntryExist

        public bool DoesEntryExist(string title)
        {
            return _entryList.ContainsKey(title);
        }

        #endregion

        #region GetEntry

        public PasswordEntry GetEntry(string title)
        {
            PasswordEntry entry = null;
            if (_entryList.ContainsKey(title))
                entry = _entryList[title];
            return entry;
        }

        #endregion

        #region Password Data Merging
        /// <summary>
        /// This method will merge a file's existing password contents into the current in memory password data. If there are 2 entries
        /// of the same key, then the one with the later date is retained.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns>Number of password records/entries merged</returns>
        public int DataMerge(string filename, SecureString passphrase)
        {
            int records = int.MinValue;

            if (this.PasswordList.Length > 0)
            {
                int percentComplete = 0;
                int pCnt = 0;
                PasswordManagerContainer tmpContainer = new PasswordManagerContainer();


                try
                {
                    tmpContainer.Passphrase = passphrase;
                    tmpContainer.LoadFile(filename);

                    records = 0;
                    foreach (PasswordEntry entry in tmpContainer.PasswordList)
                    {
                        pCnt++;
                        bool modified = false;
                        PasswordEntry currEntry = this.GetEntry(entry.Title);
                        if (currEntry != null)
                        {
                            // check modified date
                            if (entry.ModifiedDateTime > currEntry.ModifiedDateTime)
                            {
                                this.UpdateEntry(currEntry.Title, currEntry.Title, entry.UserID, entry.Url, entry.PasswordData, entry.Comment);
                                modified = true;
                            }
                        }
                        else
                        {
                            // add it
                            this.AddEntry(entry.Title, entry.UserID, entry.Url, entry.Comment, entry.PasswordData);
                            modified = true;
                        }

                        PasswordMergedEventArgs pea;
                        percentComplete = (int)((pCnt / tmpContainer.PasswordList.Length) * 100);
                        // If modified then change the current entries modified date/time
                        // fire an password merged event
                        if (modified)
                        {
                            records++;
                            // Modify our newly merged items modified date time.
                            currEntry = this.GetEntry(entry.Title);
                            currEntry.ModifiedDateTime = entry.ModifiedDateTime;
                            pea = new PasswordMergedEventArgs(entry.Title, entry.ModifiedDateTime, percentComplete);
                            OnPasswordMerged(pea);
                        }
                        else
                        {
                            // nothing was modified, but we need to notify what percent complete we are up to.
                            pea = new PasswordMergedEventArgs(null, DateTime.MinValue, percentComplete);
                            OnPasswordMerged(pea);
                        }

                        // If the consumer of the event has signified that we should cancel this process, then do just that
                        if (pea.Cancel)
                            break;
                    }
                    if (records > 0)
                    {
                        OnPropertyChanged("PasswordList");
                        OnPropertyChanged("NumberOfPasswords");
                    }
                }
                catch (Exception ex)
                {
                    // fire password merge error event
                    PasswordMergedEventArgs pea = new PasswordMergedEventArgs(null, DateTime.MinValue, percentComplete, ex.Message);
                    OnPasswordMergedError(pea);
                }

            }

            return records;
        }

        /// <summary>
        /// Our Event firing mechanism during a password merge process when a single item is merged
        /// </summary>
        /// <param name="title"></param>
        /// <param name="lastModified"></param>
        /// <param name="percentComplete"></param>
        protected void OnPasswordMerged(PasswordMergedEventArgs pea)
        {
            if (PasswordMerged != null)
                PasswordMerged(this, pea);
        }

        /// <summary>
        /// Our Event firing mechanism during a password merge process int the case of an error
        /// </summary>
        /// <param name="title"></param>
        /// <param name="lastModified"></param>
        /// <param name="percentComplete"></param>
        protected void OnPasswordMergedError(PasswordMergedEventArgs pea)
        {
            if (PasswordMerged != null)
                PasswordMergeError(this, pea);
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            ClearAll();
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
                PropertyChanged(this, e);
            }
        }

        #endregion
    }
}
