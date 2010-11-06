using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PwdMgr_WPF_UI.Data;
using Glav.PasswordMgr.Engine;

namespace PwdMgr_WPF_UI.ViewModels
{
    class FindEntryViewModel : BaseViewModel
    {
        public bool IsFindEnabled
        {
            get { return !string.IsNullOrWhiteSpace(_searchText); }
        }

        private bool _searchFromBeginning = true;
        public bool SearchFromBeginning
        {
            get { return _searchFromBeginning; }
            set
            {
                if (value != _searchFromBeginning)
                {
                    _searchFromBeginning = value;
                    RaisePropertyChanged("SearchFromBeginning");
                }
            }
        }

        private string _searchText = string.Empty;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                if (value != _searchText)
                {
                    _searchText = value;
                    RaisePropertyChanged("SearchText", "IsFindEnabled");
                }
            }
        }

        public void DoSearch()
        {
            PasswordEntry foundEntry = null;

            if (SearchFromBeginning)
            {
                foundEntry = PasswordDataRepository.Current.PasswordContainer.FindEntry(SearchText);
                // After searching once, we typically want to continue searching, so turn off the
                // search from start option
                SearchFromBeginning = false;
            }
            else
                foundEntry = PasswordDataRepository.Current.PasswordContainer.FindEntry(SearchText, PasswordDataRepository.Current.PasswordContainer.Current);

            // Set whether we have found a result or not.
            IsEntryFound = (foundEntry != null);
            SearchStatusMessage = IsEntryFound ? string.Format("Found Entry: {0}", PasswordContainer.Current.Title) : "No Entry Found!";
        }

        public string _searchStatusMessage = string.Empty;
        public string SearchStatusMessage
        {
            get { return _searchStatusMessage; }
            set
            {
                if (value != _searchStatusMessage)
                {
                    _searchStatusMessage = value;
                    RaisePropertyChanged("SearchStatusMessage");
                }
            }
        }

        private bool _isEntryFound = false;
        public bool IsEntryFound
        {
            get { return _isEntryFound; }
            set
            {
                if (value != _isEntryFound)
                {
                    _isEntryFound = value;
                    RaisePropertyChanged("IsEntryFound");
                }
            }
        }

        public void ResetSearch()
        {
            SearchFromBeginning = true;
            SearchText = string.Empty;
            IsEntryFound = false;
            SearchStatusMessage = string.Empty;
        }
    }
}
