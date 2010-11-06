using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Glav.PasswordMgr
{
    public partial class frmPeekWindow : Form
    {
        #region Private fields

        private byte[] _displayData;

        #endregion

        #region Constructors

        public frmPeekWindow()
        {
            InitializeComponent();
        }

        public frmPeekWindow(int x, int y)
            : this()
        {
            this.Left = x;
            this.Top = y;
        }

        #endregion

        #region Properties

        /// <summary>
        /// A byte array of character data to use as display data on the peek form.
        /// </summary>
        public byte[] DisplayData
        {
            get { return _displayData; }
            set { 
                _displayData = value;
                DisplayCharacters();
            }
        }

        #endregion

        #region DisplayCharacters

        /// <summary>
        /// This method creates multiple Label controls within a panel to display the password data. This is a little more
        /// secure (but not much) than displaying a string as a string is held in a contiguous section of memory whereas
        /// the label controls, while might be held contigously, are separated by object data and represent only 1 char each
        /// </summary>
        private void DisplayCharacters()
        {
            if (_displayData != null && _displayData.Length > 0)
            {
                // Clear the main panel
                pnlPeekDisplay.Controls.Clear();

                // Create a container panel which is where all the labels are held and which we can move/position as one unit.
                Panel cont = new Panel();
                int leftPosCnt = 0;
                for (int i = 0; i < _displayData.Length; i++)
                {
                    Label l = new Label();
                    l.Top = (int)(pnlPeekDisplay.Height / 2) - (l.Height / 2);
                    l.Left = leftPosCnt;
                    l.AutoSize = true;
                    l.Text = System.Text.UTF8Encoding.UTF8.GetString(new byte[] { _displayData[i] });
                    leftPosCnt += l.PreferredWidth;
                    cont.Controls.Add(l);
                }

                cont.Width = leftPosCnt;

                // Make sure the main form is wide enough to cope.
                if (cont.Width > this.Width)
                    this.Width = cont.Width + 10;

                // Position the container form in the centre of the form
                cont.Left = (int)((this.Width / 2) - (cont.Width / 2));
                
                pnlPeekDisplay.Controls.Add(cont);
            }
        }
        #endregion
    }
}