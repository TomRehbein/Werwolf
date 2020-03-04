using Werwolf.Model;
using Werwolf.ViewModel;
using Werwolf.Views;

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
      public static string workDir = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"/Werewolf";
      public static string workDirEtc = workDir + @"/etc";
      public static string workDirEtcPic = workDirEtc + @"/Pictures";

      public ObservableCollection<Character> Characters { get; set; }

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
         DirectorySetUp();


         AddRoleCommand = new MyICommand(OnAdd, CanAdd);
         DeleteRoleCommand = new MyICommand(OnDelete, CanDelete);
         PlayCommand = new RelayCommand((parameter) => StartGame());
      }

      private void DirectorySetUp()
      {
         if (!Directory.Exists(workDir))
         {
            Directory.CreateDirectory(workDir);
            Directory.CreateDirectory(workDirEtc);
            //string currentDir = Directory.GetCurrentDirectory();
            Directory.CreateDirectory(workDirEtcPic);
         }
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
