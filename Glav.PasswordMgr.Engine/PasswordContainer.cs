using System;
using System.Collections;
using Glav.PasswordMgr.Engine.Globals;
using Glav.PasswordMgr.Engine.Exceptions;
using Glav.PasswordMgr.Engine.Crypto;

/************************************************************************************
 * Modification History:-
 * Date        Who  CodeIDTag  Comments
 * ~~~~~~~~~~  ~~~  ~~~~~~~~~  ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 * 04/02/2006   PG             Initial .Net V2.0 Migration
 * ***********************************************************************************/

namespace Glav.PasswordMgr.Engine
{
	/// <summary>
	/// A container for a list of passwords, user ids and descriptions.
	/// </summary>
    [Obsolete("This is obsolete for .Net V2.0+. Use the PasswordManagerContainer instead")]
	public class PasswordContainer
	{
		#region My Privates!
		private const char FIELD_SEPARATOR = '\t';

		private ArrayList mPasswordDescriptions = null;
		private ArrayList mUserIDs = null;
		private ArrayList mPasswords = null;
		private ArrayList mChangeDateTimes = null; 
		private string mContainerDesc = "";

		private System.Collections.Hashtable m_descTable;


		private string m_Passphrase = "";
		private bool mModified = false;

		private FileVersions m_fileVersion;
		#endregion

		#region Default Constructor
		/// <summary>
		/// Default Constructor
		/// </summary>
		public PasswordContainer()
		{
			mPasswordDescriptions = new ArrayList();
			mUserIDs = new ArrayList();
			mPasswords = new ArrayList();
			mChangeDateTimes = new ArrayList();
			m_descTable = new Hashtable();
            
			m_fileVersion = FileVersions.Version2;
		}
		#endregion

		#region Public properties
		/// <summary>
		/// Gets/Sets the file passphrase/password.
		/// </summary>
		public string Passphrase
		{
			get
			{
				return m_Passphrase;
			}
			set
			{
				mModified = (m_Passphrase != value);
				m_Passphrase = value;
			}
		}

		/// <summary>
		/// Gets/Sets the data modified flag
		/// </summary>
		public bool DataModified
		{
			get
			{
				return mModified;
			}
			set
			{
				mModified = value;
			}
		}

		/// <summary>
		/// Gets/Sets the Container description.
		/// </summary>
		public string ContainerDescription
		{
			get
			{
				return mContainerDesc;
			}
			set
			{
				mModified = (mContainerDesc != value);
				mContainerDesc = value;
			}
		}

		/// <summary>
		/// Gets the Password Descriptions
		/// </summary>
		public ArrayList PasswordDescriptions
		{
			get 
			{
				return mPasswordDescriptions;
			}
		}

		/// <summary>
		/// Gets the User IDs associated with the passwords
		/// </summary>
		public ArrayList UserIDs
		{
			get
			{
				return mUserIDs;
			}
		}

		/// <summary>
		/// Gets the passwords
		/// </summary>
		public ArrayList Passwords
		{
			get
			{
				return mPasswords;
			}
		}


		// <V2.0>
		/// <summary>
		/// Gets the dates and times that the password entry was modified/added.
		/// </summary>
		public ArrayList EntryModified
		{
			get
			{
				return mChangeDateTimes;
			}
		}

		/// <summary>
		/// Current version of the data file.
		/// </summary>
		public FileVersions FileVersion
		{
			get 
			{
				return m_fileVersion;
			}
		}
		#endregion

		#region ClearAll method
		/// <summary>
		/// Clears all the items. Passwords, UserIDs and Descriptions.
		/// </summary>
		public void ClearAll()
		{
			mPasswordDescriptions.Clear();
			mPasswords.Clear();
			mUserIDs.Clear();
			mChangeDateTimes.Clear();
			mContainerDesc = "";
			m_Passphrase = "";
			m_descTable.Clear();
			mModified = false;
		}
		#endregion

		#region "Add" routines
		/// <summary>
		/// Add an entire entry of data
		/// </summary>
		/// <param name="Description">Password Description</param>
		/// <param name="UserID">User ID associated with password</param>
		/// <param name="Password">Password</param>
		public void AddEntry(string Description, string UserID, string Password)
		{
			AddDescription(Description);
			AddUserID(UserID);
			AddPassword(Password);
			AddModifiedDateTime(DateTime.Now);
			RefreshHashtable();
			mModified = true;
		}

		// <V2.0>
		/// <summary>
		/// Add an entire entry of data (overloaded)
		/// </summary>
		/// <param name="Description">Password Description</param>
		/// <param name="UserID">User ID associated with password</param>
		/// <param name="Password">Password</param>
		/// <param name="modDateTime">Date-Time the password entry was last modified/added</param>
		public void AddEntry(string Description, string UserID, string Password, DateTime modDateTime)
		{
			AddDescription(Description);
			AddUserID(UserID);
			AddPassword(Password);
			AddModifiedDateTime(modDateTime); // <V2.0>
			RefreshHashtable();  // <V2.0>
			mModified = true;
		}
		

		/// <summary>
		/// Add a password description
		/// </summary>
		/// <param name="Description">The description to add</param>
		private void AddDescription(string Description)
		{
			mModified = true;
			mPasswordDescriptions.Add(Description);
		}
		/// <summary>
		/// Add a user id associated with a password
		/// </summary>
		/// <param name="UserID">The user id to add</param>
		private void AddUserID(string UserID)
		{
			mModified = true;
			mUserIDs.Add(UserID);
		}
		/// <summary>
		/// Add a password
		/// </summary>
		/// <param name="Password">The password to add</param>
		private void AddPassword(string Password)
		{
			mModified = true;
			mPasswords.Add(Password);
		}

		// <V2.0>
		/// <summary>
		/// Adds a new entry for the modified date/time of this entry.
		/// </summary>
		/// <param name="Password">The date/time to add</param>
		private void AddModifiedDateTime(DateTime newDateTime)
		{
			mModified = true;
			mChangeDateTimes.Add(newDateTime);
		}
		#endregion

		#region DeleteEntry method
		/// <summary>
		/// Deletes an entire password entry (Password Desc, UserID and Password)
		/// for the specified array index
		/// </summary>
		/// <param name="entryIndex">The zero based array index</param>
		public void DeleteEntry(int entryIndex)
		{
			if (entryIndex > mPasswords.Count)
				throw new Exception("Password Index out of range.");
			else
			{
				mPasswordDescriptions.RemoveAt(entryIndex);
				mUserIDs.RemoveAt(entryIndex);
				mPasswords.RemoveAt(entryIndex);
				mChangeDateTimes.RemoveAt(entryIndex);  // <V2.0>
				RefreshHashtable();  // <V2.0>
				mModified = true;
			}
		}
		#endregion

		#region Serialisation Routines
		/// <summary>
		/// Serialise the current data set into a delimited string
		/// </summary>
		/// <returns>The serialised data</returns>
		public string SerialiseToStr()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			if (m_fileVersion == FileVersions.Version1) // <V2.0>
			{
				// String format :-
				//   Password Count<TAB>Pwd Description<TAB>UserID<TAB>Password<TAB>
				// with the last 3 fields being repeated for however many passwords
				// there are.
				sb.Append(mPasswords.Count.ToString());
				sb.Append(FIELD_SEPARATOR);
				sb.Append(mContainerDesc);
				sb.Append(FIELD_SEPARATOR);
				for (int i=0; i < mPasswords.Count; i++)
				{
					sb.Append(mPasswordDescriptions[i]);
					sb.Append(FIELD_SEPARATOR);
					sb.Append(mUserIDs[i]);
					sb.Append(FIELD_SEPARATOR);
					sb.Append(mPasswords[i]);
					sb.Append(FIELD_SEPARATOR);
				}
			} 
			else // This will be for the latest version. Currently V2.0
			{	// <V2.0>
				// String format :-
				//   FileVersionIdentifier<TAB>Password Count<TAB>Pwd Description<TAB>
				//   UserID<TAB>Password<TAB>ModifiedDateTime<TAB>
				// with the last 4 fields being repeated for however many passwords
				// there are.
				sb.Append(Globals.DataFileVersion.VERSION2);
				sb.Append(FIELD_SEPARATOR);
				sb.Append(mPasswords.Count.ToString());
				sb.Append(FIELD_SEPARATOR);
				sb.Append(mContainerDesc);
				sb.Append(FIELD_SEPARATOR);
				for (int i=0; i < mPasswords.Count; i++)
				{
					sb.Append(mPasswordDescriptions[i]);
					sb.Append(FIELD_SEPARATOR);
					sb.Append(mUserIDs[i]);
					sb.Append(FIELD_SEPARATOR);
					sb.Append(mPasswords[i]);
					sb.Append(FIELD_SEPARATOR);
					sb.Append(ToDateTimeString((DateTime)mChangeDateTimes[i]));
					sb.Append(FIELD_SEPARATOR);
				}
			}
			return sb.ToString();
		}

		public void DeserialiseFromStr(string pwdData)
		{
			string tmpDesc = "";
			string tmpUser = "";
			string tmpPwd = "";
			string tmpDateTime = "";

			// Store our pass phrase before the clear as it will get cleared.
			string oldPassPhrase = m_Passphrase;
			ClearAll();
			m_Passphrase = oldPassPhrase;

			string[] data = pwdData.Split(new char[] {FIELD_SEPARATOR});
			// <V2.0>
			m_fileVersion = FileVersions.Version1;  // Our default data file version
			if (data[0] == DataFileVersion.VERSION2)  // Check for version 2
				m_fileVersion = FileVersions.Version2;

			if (m_fileVersion == FileVersions.Version1)  // <V2.0>
			{
				// routine to load a version 1 password file
				int numPwds = Convert.ToInt32(data[0]);
				mContainerDesc = data[1];
				for (int i=0; i < numPwds; i++)
				{
					tmpDesc	= data[2+(i*3)];
					tmpUser = data[3+(i*3)];
					tmpPwd = data[4+(i*3)];
					AddEntry(tmpDesc,tmpUser,tmpPwd);
				}
			} 
			else
			{
				// <V2.0>
				// routine to load a version 2 password file
				string VersionID = data[0];
				int numPwds = Convert.ToInt32(data[1]);
				mContainerDesc = data[2];
				for (int i=0; i < numPwds; i++)
				{
					tmpDesc	= data[3+(i*4)];
					tmpUser = data[4+(i*4)];
					tmpPwd = data[5+(i*4)];
					tmpDateTime = data[6+(i*4)];
					AddEntry(tmpDesc,tmpUser,tmpPwd,FromDateTimeString(tmpDateTime));
				}
			}
			mModified = false;
		}
		#endregion

		#region RefreshHashtable method
		/// <summary>
		/// Refreshes the internal hashtable of password descriptions
		/// </summary>
		private void RefreshHashtable()
		{
			// Refresh our hastable
			if (m_descTable != null)
				m_descTable.Clear();
			
			for (int i=0; i < mPasswords.Count; i++)
				m_descTable.Add(mPasswordDescriptions[i],i);
		}
		#endregion

		#region FindEntry method
		/// <summary>
		/// Finds an entry in the internal arrays using the password description
		/// </summary>
		/// <param name="pwdDesc">Password description used to search</param>
		/// <returns>The array index of the entry, -1 if unsuccessfull.</returns>
		public int FindEntry(string pwdDesc)
		{
			int retIndex = -1;

			System.Collections.DictionaryEntry dict;
			System.Collections.IEnumerator en = m_descTable.GetEnumerator();

			while (en.MoveNext())
			{

				dict = (System.Collections.DictionaryEntry)en.Current;
				if ((string)dict.Key == pwdDesc)
				{
					// Found it.
					retIndex = (int)dict.Value;
					break;
				}
			}

			return retIndex;
		}
		#endregion

		#region UpdateEntry <V2.0>
		// <V2.0>
		/// <summary>
		/// Updates a password entry
		/// </summary>
		/// <param name="OldPasswordDescription">The 'old' password description which is used to search for an entry</param>
		/// <param name="NewPasswordDescription">The 'new' password description which is stored in the description list</param>
		/// <param name="UserID">The 'new' User id to store in the UserID list</param>
		/// <param name="Password">The 'new' Password to store in the password list</param>
		/// <returns>True if successfull, False if unsuccessfull.</returns>
		public bool UpdateEntry(string OldPasswordDescription, string NewPasswordDescription, string UserID, string Password)
		{
			bool retVal = false;

			int arrIndex = FindEntry(OldPasswordDescription);
			if (arrIndex > -1)
			{
				mPasswordDescriptions[arrIndex] = NewPasswordDescription;
				mUserIDs[arrIndex] = UserID;
				mPasswords[arrIndex] = Password;
				mChangeDateTimes[arrIndex] = DateTime.Now;
				mModified = true;
				RefreshHashtable();
				retVal = true;
			}

			return retVal;
		}
		#endregion

		#region Load/Save File Routines

        public void LoadFromFile(string FileName)
		{
			CryptoTool tool = new CryptoTool(m_Passphrase);
			try 
			{
				string tmpStr = tool.DecryptFromFile(FileName);
				DeserialiseFromStr(tmpStr);
				mModified = false;
			} 
			catch (System.Security.Cryptography.CryptographicException crypt_ex)
			{
				ClearAll();
				throw crypt_ex;
			}
			catch (System.Exception ex)
			{
				ClearAll();
				throw ex;
			}
		}

		public void SaveToFile(string FileName)
		{
			try 
			{
				CryptoTool ctool = new CryptoTool(m_Passphrase);
				string tmpStr = SerialiseToStr();
				ctool.EncryptToFile(FileName,tmpStr);
				mModified = false;
			} 
			catch (System.Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region ConvertDataFile
		/// <summary>
		/// Converts the internal data structures to a V2 or later compatible file.
		/// </summary>
		/// <param name="newFileVersion"></param>
		public void ConvertDataFile(Globals.FileVersions newFileVersion)
		{
			switch (newFileVersion)
			{
				case Globals.FileVersions.Version2:
					// Currently, this is all thats necessary, as this class will
					// maintain modified date/times even for old version files, but
					// the info is discarded when the file is saved a a version 1 file.
					m_fileVersion = FileVersions.Version2;
					break;
			}
		}
		#endregion

		#region ToDateTimeString and FromDateTimeString routines
		// <V2.0>
		private string ToDateTimeString(DateTime dateTimeVal)
		{
			string tmpStr = "";
			tmpStr = dateTimeVal.ToString("dd/MM/yyyy HH:mm:ss");
			return tmpStr;
		}

		// <V2.0>
		private DateTime FromDateTimeString(string dateTimeVal)
		{
			int day, month, year, hour, minute, second;

			DateTime tmpDateTime;
			char[] tmpChars;
			tmpChars = dateTimeVal.ToCharArray();
			// Do the day
			string tmpStr = tmpChars[0].ToString() + tmpChars[1].ToString();
			day = Convert.ToInt32(tmpStr);
			// Do the month
			tmpStr = tmpChars[3].ToString() + tmpChars[4].ToString();
			month = Convert.ToInt32(tmpStr);
			// Do the year
			tmpStr = tmpChars[6].ToString() + tmpChars[7].ToString() + tmpChars[8].ToString() + tmpChars[9].ToString();
			year = Convert.ToInt32(tmpStr);
			// Do the hour
			tmpStr = tmpChars[11].ToString() + tmpChars[12].ToString();
			hour = Convert.ToInt32(tmpStr);
			// Do the minute
			tmpStr = tmpChars[14].ToString() + tmpChars[15].ToString();
			minute = Convert.ToInt32(tmpStr);
			// Do the second
			tmpStr = tmpChars[17].ToString() + tmpChars[18].ToString();
			second = Convert.ToInt32(tmpStr);
			tmpDateTime = new DateTime(year,month,day,hour,minute,second,0);
			return tmpDateTime;
		}
		#endregion

		#region FindTextInEntry
		/// <summary>
		/// Attempts to find a segment of text in any field in a password entry.
		/// </summary>
		/// <param name="pwdDescription">The password description of the entry we are searching. This is the key we use to locatethe
		/// entry in our internal lists.</param>
		/// <param name="textToSearch">The segment to text to seach for.</param>
		/// <param name="caseSensitive">Whether the search is case sensitive or not.</param>
		/// <returns></returns>
		public bool FindTextInEntry(string pwdDescription, string textToSearch, bool caseSensitive)
		{

			bool found = false;
			
			int realIndex = FindEntry(pwdDescription);

			string compareVal1 = null;
			string compareVal2 = null;
			string compareVal3 = null;

			string srchText = null;
			if (!caseSensitive)
			{
				srchText = textToSearch.ToUpper();
				compareVal1 = pwdDescription.ToUpper();
				compareVal2 = ((string)mUserIDs[realIndex]).ToUpper();
				compareVal3 = ((string)mPasswords[realIndex]).ToUpper();
			}
			else
			{
				srchText = textToSearch;
				compareVal1 = pwdDescription;
				compareVal2 = (string)mUserIDs[realIndex];
				compareVal3 = (string)mPasswords[realIndex];
			}
			
			if (realIndex >= 0)
			{
				if (compareVal1.IndexOf(srchText) >= 0 || compareVal2.IndexOf(srchText) >= 0 || compareVal3.IndexOf(srchText) >= 0)
					found = true;
			}
			return found;

		}
		#endregion
	}
}
