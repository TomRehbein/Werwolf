using Werwolf.Model;
using Werwolf.Views;

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows.Input;
using System.Windows;

namespace Werwolf.ViewModel
{
   class ModeratorViewModel : INotifyPropertyChanged
   {
      public ObservableCollection<Character> Characters { get; set; }

      public int PlayerCount { get; set; }
      //public Character[] PlayerRoles;

      public ModeratorViewModel()
      {
      }

      #region PropertyChanged

      public event PropertyChangedEventHandler PropertyChanged;

      private void RaisePropertyChanged(string property)
      {
         if (PropertyChanged != null)
         {
            PropertyChanged(this, new PropertyChangedEventArgs(property));
         }
      }

      #endregion PropertyChanged
   }
}
