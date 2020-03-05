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
      public static string WorkDir = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"/Werewolf";
      public static string WorkDirEtc = WorkDir + @"/etc";
      public static string WorkDirEtcPic = WorkDirEtc + @"/png";

      public ObservableCollection<Character> Characters { get; set; }

      public MyICommand AddRoleCommand { get; set; }
      public MyICommand DeleteRoleCommand { get; set; }
      public RelayCommand PlayCommand { get; set; }

      public Character SelectedCharacter { get; set; }

      /*

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
      }*/

      public GameSetUpViewModel()
      {
         DirectorySetUp();
         DirectoryAndFileSetUp();

         CharacterJson.GetCharactersFromJson();

         AddRoleCommand = new MyICommand(OnAdd, CanAdd);
         DeleteRoleCommand = new MyICommand(OnDelete, CanDelete);
         PlayCommand = new RelayCommand((parameter) => StartGame());
      }

      private void DirectorySetUp()
      {
         if (!Directory.Exists(WorkDir))
         {
            Directory.CreateDirectory(WorkDir);
            Directory.CreateDirectory(WorkDirEtc);
            //string currentDir = Directory.GetCurrentDirectory();
            Directory.CreateDirectory(WorkDirEtcPic);
         }
      }

      private void DirectoryAndFileSetUp()
      {
         // move all pic to the Dir
         
         
         if (!File.Exists(WorkDirEtc + @"/Characters.json"))
         {
            string[] pics = Directory.GetFiles(WorkDirEtcPic);
            int count = Directory.GetFiles(WorkDirEtcPic).Length;
            ObservableCollection<Character> c = new ObservableCollection<Character>();

            foreach (string pic in pics)
            {
               string nameWithScore = Path.GetFileName(pic);

               nameWithScore = nameWithScore.Replace("_", " ");
               nameWithScore = nameWithScore.Replace(".png", "");

               Character character = new Character(nameWithScore);
               try
               {
                  Characters.Add(character);
               }
               catch
               {
                  c.Add(character);
                  Characters = c;
               }
               count--;
            }

            new CharacterJson(WorkDirEtc, Characters);
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
