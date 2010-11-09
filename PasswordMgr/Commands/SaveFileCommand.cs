using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PasswordMgr.Data;

namespace PasswordMgr.Commands
{
    /// <summary>
    /// For this command, lets assu,e a parameter should be a bool which indicates whether to use the current filename (nasically a straight save)
    /// or do a Save-As type command to save with a new filename.
    /// </summary>
    class SaveFileCommand : BaseCommand
    {
        public override void Execute(object parameter)
        {
            bool useCurrentFilename = true;
            if (parameter != null)
            {
                try
                {
                    useCurrentFilename = (bool)parameter;
                }
                catch
                {
                    useCurrentFilename = true;
                }

            }

            //TODO: Need to ensure we have a valid passphrase before saving
            if (useCurrentFilename)
            {
                PasswordDataRepository.Current.PasswordContainer.SaveFile();
            }
            else
            {
                //TODO: implement save-as type functionality
            }

        }
    }
}
