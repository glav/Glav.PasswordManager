using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Security;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace Glav.PasswordMgr.Engine
{
    /// <summary>
    /// The class used to represent a Password Entry
    /// </summary>
    [Serializable]
    public class PasswordEntry: ISerializable, IDisposable, INotifyPropertyChanged
    {
        #region Private fields and constants

        private const string FLDNAME_TITLE       = "Title";
        private const string FLDNAME_USERID      = "UserID";
        private const string FLDNAME_URL         = "Url";
        private const string FLDNAME_PWDDATA     = "PasswordData";
        private const string FLDNAME_COMMENT     = "Comment";
        private const string FLDNAME_MODDATETIME = "ModifiedDateTime";

        #endregion

        #region Private fields

        private string _title = null;
        private string _userID = null;

        private string _url = null;
        private string _comment = null;
        private DateTime _modifiedDateTime = DateTime.MinValue;

        //private char[] _passwordData = null;
        private SecureString _passwordData = new SecureString();

        #endregion

        #region Default constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public PasswordEntry()
        {
        }

        /// <summary>
        /// Serialisation/Deserialisation constructor
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public PasswordEntry(SerializationInfo info, StreamingContext context)
        {
            for (int memCnt = 0; memCnt < info.MemberCount; memCnt++)
            {
                _title = info.GetString(FLDNAME_TITLE);
                _userID = info.GetString(FLDNAME_USERID);
                _url = info.GetString(FLDNAME_URL);
                _comment = info.GetString(FLDNAME_COMMENT);
                _modifiedDateTime = info.GetDateTime(FLDNAME_MODDATETIME);

                char[] pwdData = (char[])info.GetValue(FLDNAME_PWDDATA,typeof(char[]));
                _passwordData.Clear();

                foreach (char c in pwdData)
                    _passwordData.AppendChar(c);

                //TODO: Cannot clear array here as it seems to affect the secure string data
                //      Not sure why we cannot clear the char array here. If we uncomment the line below, the SecureString seems to only
                //      contain the NULL characters??
                //ZeroClearArray(pwdData);
            }
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// The title or description of this entry
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { 
                _title = value;
                OnPropertyChanged("Title");
                IsDataModified = true;
            }
        }

        /// <summary>
        /// The UserID for this entry
        /// </summary>
        public string UserID
        {
            get { return _userID; }
            set { 
                _userID = value;
                OnPropertyChanged("UserID");
                IsDataModified = true;
            }
        }

        /// <summary>
        /// any URL associated with the password entry
        /// </summary>
        public string Url
        {
            get { return _url; }
            set { 
                _url = value;
                OnPropertyChanged("Url");
                IsDataModified = true;
            }
        }

        /// <summary>
        /// Comments
        /// </summary>
        public string Comment
        {
            get { return _comment; }
            set { 
                _comment = value;
                OnPropertyChanged("Comment");
                IsDataModified = true;
            }
        }
        /// <summary>
        /// last date/time the password entry was modified
        /// </summary>
        public DateTime ModifiedDateTime
        {
            get { return _modifiedDateTime; }
            set { 
                _modifiedDateTime = value;
                OnPropertyChanged("ModifiedDateTime");
                IsDataModified = true;
            }
        }

        //public char[] PasswordData
        public SecureString PasswordData
        {
            get { return _passwordData; }
            set { 
                _passwordData = value;
                OnPropertyChanged("PasswordData");
                IsDataModified = true;
            }
        }

        private bool _isDataModified = false;
        public bool IsDataModified
        {
            get { return _isDataModified; }
            set
            {
                if (value != _isDataModified)
                {
                    _isDataModified = value;
                    OnPropertyChanged("IsDataModified");
                }
            }
        }
        #endregion

        #region ISerializable Members

        /// <summary>
        /// Retrieves the object data for use in serialisation
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.SetType(typeof(PasswordEntry));
            info.AddValue(FLDNAME_TITLE, _title);
            info.AddValue(FLDNAME_USERID, _userID);
            info.AddValue(FLDNAME_URL, _url);
            info.AddValue(FLDNAME_COMMENT, _comment);
            info.AddValue(FLDNAME_MODDATETIME, _modifiedDateTime);

            char[] data = PasswordEntry.GetCharacterData(_passwordData);
            info.AddValue(FLDNAME_PWDDATA, data.Clone());

            ZeroClearArray(data);
        }

        #endregion

        #region GetCharacterData
        /// <summary>
        /// Utility function to return the contents of a secure string as a character array
        /// </summary>
        /// <param name="secureData"></param>
        /// <returns></returns>
        public static char[] GetCharacterData(SecureString secureData)
        {
            char[] bytes = new char[secureData.Length];
            IntPtr ptr = IntPtr.Zero;

            try
            {
                ptr = Marshal.SecureStringToBSTR(secureData);
                Marshal.Copy(ptr, bytes, 0, secureData.Length);
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                    Marshal.ZeroFreeBSTR(ptr);
            }

            return bytes;
        }
        #endregion

        #region ZeroClearArray
        /// <summary>
        /// Simple fills each element of the array with a null character
        /// </summary>
        /// <param name="characterArray"></param>
        private void ZeroClearArray(char[] characterArray)
        {
            for (int i = 0; i < characterArray.Length; i++)
                characterArray[i] = '\0';
        }
        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            this._comment = null;
            if (this._passwordData != null)
                this._passwordData.Dispose();
            this._title = null;
            this._url = null;
            this._userID = null;
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
