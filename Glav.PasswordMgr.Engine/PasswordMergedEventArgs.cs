using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.PasswordMgr.Engine
{
    /// <summary>
    /// The delegate definition of the Password Marged status event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void PasswordMergedDelegate(object sender, PasswordMergedEventArgs e);

    /// <summary>
    /// The Event argument object used in passing the current progress status during a password data merge process.
    /// </summary>
    public class PasswordMergedEventArgs : System.EventArgs
    {
        #region Public fields

        public string PasswordTitle = null;
        public DateTime PasswordLastModified = DateTime.MinValue;
        public int PercentComplete = 0;
        public string Message = null;
        public bool Cancel = false;

        #endregion

        #region Constructors

        public PasswordMergedEventArgs(string title, DateTime lastModified, int percentComplete)
            : base()
        {
            PasswordTitle = title;
            PasswordLastModified = lastModified;
            PercentComplete = percentComplete;
        }
        public PasswordMergedEventArgs(string title, DateTime lastModified, int percentComplete, string message)
            : this(title,lastModified,percentComplete)
        {
            Message = message;
        }

        #endregion
    }

}
