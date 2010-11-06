using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.PasswordMgr.Engine
{
    /// <summary>
    /// THis class is only used for file saving and loading purposes. It represents the heirarcy of data within the file and is used to
    /// store data for serialisation/deserialisation purposes.
    /// </summary>
    [Serializable]
    public class PasswordManagerContainerFileData
    {
        string _listTitle = null;
        PasswordEntry[] _passwordList = null;
        private DataFileFileVersions _fileVersion = DataFileFileVersions.V3;

        public DataFileFileVersions DataFileVersion
        {
            get { return _fileVersion; }
            set { _fileVersion = value; }
        }

        public string ListTitle
        {
            get { return _listTitle; }
            set { _listTitle = value; }
        }
        public PasswordEntry[] PasswordList
        {
            get { return _passwordList; }
            set { _passwordList = value; }
        }

    }
}
