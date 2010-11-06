using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Glav.PasswordMgr;
using System.ComponentModel;

namespace Glav.PasswordMgr
{
    public class Startup
    {
		[STAThread]
		static void Main() 
		{
            //****** Test run of new screen
            Application.Run(new frmMain());
            //****** END - Test run of new screen
		}
    }
}
