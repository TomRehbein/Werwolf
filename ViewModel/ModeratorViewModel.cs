using Werwolf.Model;

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
      public static string workDir = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"/Bundesliga";
      public static string workDirEtc = workDir + @"/etc";
      public static string workDirEtcPic = workDirEtc + @"/Pictures";

      public int PlayerCount { get; set; }
      public Character[] PlayerRoles;

      public ModeratorViewModel()
      {
         DirectorySetUp();
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

      public void GameSetUp()
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
