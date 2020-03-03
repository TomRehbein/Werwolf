using Werwolf.Model;

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows.Input;
using System.Windows;

namespace Werwolf.ViewModel
{
   class GameSetUpViewModel : INotifyPropertyChanged
   {
      public ObservableCollection<Character> Characters{ get; set; }


      public MyICommand AddRoleCommand { get; set; }
      public MyICommand DeleteRoleCommand { get; set; }
      public RelayCommand PlayCommand { get; set; }

      private Character _selectedCharacter { get; set; }
      public Character SelectedCharacter
      {
         get
         {
            return _selectedCharacter;
         }
         set
         {
            _selectedCharacter = value;
         }
      }

      public GameSetUpViewModel()
      {


         AddRoleCommand = new MyICommand(OnAdd, CanAdd);
         DeleteRoleCommand = new MyICommand(OnDelete, CanDelete);
         PlayCommand = new RelayCommand((parameter) => StartGame());
      }

      private void OnAdd()
      {
         // show a View of all remaining Roles as png

         //Characters.Add(new Character());
      }

      private bool CanAdd()
      {
         return true;
      }

      private void OnDelete()
      {
         Characters.Remove(SelectedCharacter);
      }

      private bool CanDelete()
      {
         return SelectedCharacter != null;
      }

      private void StartGame()
      {
         // Close the View and hands over the Characters
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
