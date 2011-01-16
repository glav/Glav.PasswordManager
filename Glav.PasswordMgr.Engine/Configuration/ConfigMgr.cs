using System;
using System.Configuration;
using System.IO;
using Glav.PasswordMgr.Engine.Exceptions;
using System.Text;
using System.Windows.Forms;

namespace Glav.PasswordMgr.Engine.Configuration
{
    /// <summary>
    /// Simple class to manage the saving, loading and accessing of config data.
    /// </summary>
    public static class ConfigMgr
    {
        #region My Privates!
        static private readonly string REQUIREPWD = "RequirePwdOnMaximise";
        
        private static readonly string POSLEFT = "PositionLeft";
        private static readonly string POSTOP = "PositionTop";
        private static readonly string SIZEWIDTH = "SizeWidth";
        private static readonly string SIZEHEIGHT = "SizeHeight";

        private static bool _requirePwdOnMaximise = false;
        private static bool _obscurePwdsOnDisplay = false;
        
        private const int DEFAULT_POSTOP = 10;
        private const int DEFAULT_POSLEFT = 10;
        private const int DEFAULT_SIZEHEIGHT = 345;
        private const int DEFAULT_SIZEWIDTH = 488;

        private static int _posTop = DEFAULT_POSTOP;
        private static int _posLeft = DEFAULT_POSLEFT;
        private static int _sizeWidth = DEFAULT_SIZEWIDTH;
        private static int _sizeHeight = DEFAULT_SIZEHEIGHT;

        #endregion

        #region Properties

        static public bool RequirePwdOnMaximise
        {
            get 
            { 
                return _requirePwdOnMaximise; 
            }
            set 
            {
                _requirePwdOnMaximise = value;
            }
        }

        public static int PositionLeft
        {
            get { return _posLeft; }
            set { _posLeft = value; }
        }

        public static int PositionTop
        {
            get { return _posTop; }
            set { _posTop = value; }
        }

        public static int SizeHeight
        {
            get { return _sizeHeight; }
            set { _sizeHeight = value; }
        }

        public static int SizeWidth
        {
            get { return _sizeWidth; }
            set { _sizeWidth = value; }
        }

        #endregion

        #region Save method
        static public void Save(string filename)
        {
            try 
            {
                StringBuilder configFile = new StringBuilder();
                configFile.Append("<configuration>\r\n\t<appSettings>\r\n");
                configFile.AppendFormat("\t\t<add key=\"{0}\" value=\"{1}\"/>\r\n", REQUIREPWD, _requirePwdOnMaximise);
                configFile.AppendFormat("\t\t<add key=\"{0}\" value=\"{1}\"/>\r\n", POSLEFT, _posLeft);
                configFile.AppendFormat("\t\t<add key=\"{0}\" value=\"{1}\"/>\r\n", POSTOP, _posTop);
                configFile.AppendFormat("\t\t<add key=\"{0}\" value=\"{1}\"/>\r\n", SIZEHEIGHT, _sizeHeight);
                configFile.AppendFormat("\t\t<add key=\"{0}\" value=\"{1}\"/>\r\n", SIZEWIDTH, _sizeWidth);
                configFile.Append("\t</appSettings>\r\n</configuration>");

                //string configFile = "<configuration>\r\n\t<appSettings>\r\n";
                //configFile += "\t\t<add key=\"" + S_SORTALPHA + "\" value=\"" + m_sortAlpha.ToString() + "\"/>\r\n";
                //configFile += "\t\t<add key=\"" + S_REQUIREPWD + "\" value=\"" + m_requirePwdOnMaximise.ToString() + "\"/>\r\n";
                //configFile += "\t\t<add key=\"" + S_LISTDISPLAY + "\" value=\"" + m_ListAsInitialDisplay.ToString() + "\"/>\r\n";
                //configFile += "\t\t<add key=\"" + S_OBSCUREPWDS + "\" value=\"" + m_ObscurePwdsOnDisplay.ToString() + "\"/>\r\n";

                //configFile += "\t\t<add key=\"" + S_POSLEFT + "\" value=\"" + m_posLeft.ToString() + "\"/>\r\n";  // <V2.3>
                //configFile += "\t\t<add key=\"" + S_POSTOP + "\" value=\"" + m_posTop.ToString() + "\"/>\r\n";  // <V2.3>
                //configFile += "\t\t<add key=\"" + S_SIZEHEIGHT + "\" value=\"" + m_sizeHeight.ToString() + "\"/>\r\n";  // <V2.3>
                //configFile += "\t\t<add key=\"" + S_SIZEWIDTH + "\" value=\"" + m_sizeWidth.ToString() + "\"/>\r\n";  // <V2.3>

                //configFile += "\t</appSettings>\r\n</configuration>";
                using (StreamWriter writer = new StreamWriter(filename,false,System.Text.Encoding.UTF8,1024))
                {
                    writer.Write(configFile.ToString());
                    writer.Close();
                }
            } 
            catch (Exception ex)
            {
                PasswordConfigurationException pex = new PasswordConfigurationException("Unable to save password configuration.", ex);
                throw pex;
            }
        }

        public static void Save()
        {
            Save(Application.ExecutablePath + ".config");
        }
        #endregion

        #region Load method
        static public void Load()
        {
            string tmp;
            tmp = ConfigurationManager.AppSettings[REQUIREPWD];
            if (tmp != null)
                _requirePwdOnMaximise = StringToBool(tmp);

            try 
            {
                tmp = ConfigurationManager.AppSettings[POSLEFT];
                if (tmp != null)
                    _posLeft = StringToInt(tmp,DEFAULT_POSLEFT);
            } 
            catch
            {
                _posLeft = 0;
            }
            if (_posLeft < 0)
                _posLeft = 0;

            try
            {
                tmp = ConfigurationManager.AppSettings[POSTOP];
                if (tmp != null)
                    _posTop = StringToInt(tmp,DEFAULT_POSTOP);
            } 
            catch
            {
                _posTop = 0;
            }

            if (_posTop < 0)
                _posTop = 0;

            tmp = ConfigurationManager.AppSettings[SIZEHEIGHT];
            if (tmp != null)
                _sizeHeight = StringToInt(tmp,DEFAULT_SIZEHEIGHT);

            tmp = ConfigurationManager.AppSettings[SIZEWIDTH];
            if (tmp != null)
                _sizeWidth = StringToInt(tmp,DEFAULT_SIZEWIDTH);
        }
        #endregion

        #region StringToBool utility method
        /// <summary>
        /// Yes I know there is a bool.parse but this one is a little more resilient.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        static private bool StringToBool(string value)
        {
            string tmp;
            bool retValue = false;

            if (!string.IsNullOrEmpty(value))
            {
                tmp = value.ToUpper().Trim();
                if (tmp.Equals("TRUE"))
                    retValue = true;
            }
            return retValue;
        }
        #endregion

        #region StringToInt utility method
        private static int StringToInt(string value, int defaultVal)
        {
            int tmp;
            try 
            {
                tmp = Convert.ToInt32(value);
            } 
            catch
            {
                tmp = defaultVal;
            }
            return tmp;
        }
        #endregion
    }
}
