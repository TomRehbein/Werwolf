using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows.Input;
using System.Windows;

namespace Werwolf.ViewModel
{
   class ModeratorViewModel
   {
      public static string workDir = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"/Bundesliga";
      public static string workDirEtc = workDir + @"/etc";
      public static string workDirEtcPic = workDirEtc + @"/Pictures";

      public ModeratorViewModel()
      {
         SetUp();
      }

      private void SetUp()
      {
         if (!Directory.Exists(workDir))
         {
            Directory.CreateDirectory(workDir);
            Directory.CreateDirectory(workDirEtc);
            //string currentDir = Directory.GetCurrentDirectory();
            Directory.CreateDirectory(workDirEtcPic);
         }
      }


   }
}
