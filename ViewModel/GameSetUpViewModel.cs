using Werwolf.Model;
using Werwolf.Views;

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Linq;
using System.Collections.Generic;

namespace Werwolf.ViewModel
{
   class GameSetUpViewModel : INotifyPropertyChanged
   {
      #region Variables

      public static string WorkDir = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"/Werewolf";
      public static string WorkDirEtc = WorkDir + @"/etc";
      public static string WorkDirEtcPic = WorkDirEtc + @"/png";

      public ObservableCollection<Character> AllCharacters { get; set; }
      public ObservableCollection<Character> PlayerCharacters { get; set; }

      //public MyICommand AddCharacterToPlayer { get; set; }
      //public MyICommand RemoveCharacterFromPlayer { get; set; }

      public MyICommand DeleteCommand { get; set; }
      public RelayCommand PlayCommand { get; set; }

      private Character _addSelectedCharacter { get; set; }
      public Character AddSelectedCharacter
      {
         get
         {
            return _addSelectedCharacter;
         }
         set
         {
            _addSelectedCharacter = value;
            AddCharacterToPlayer();
            _addSelectedCharacter = null;
            RaisePropertyChanged("PlayerCharacters");
            RaisePropertyChanged("AddSelectedCharacter");
         }
      }

      private Character _deleteSelectedCharacter { get; set; }
      public Character DeleteSelectedCharacter
      {
         get
         {
            return _deleteSelectedCharacter;
         }
         set
         {
            _deleteSelectedCharacter = value;
            DeleteCommand.RaiseCanExecuteChanged();
         }
      }

      #endregion Variables

      public GameSetUpViewModel()
      {
         DirectorySetUp();
         DirectoryAndFileSetUp();

         LoadCharacters();

         DeleteCommand = new MyICommand(OnDelete, CanDelete);

         //AddCharacterToPlayer = new MyICommand(OnAdd, CanAdd);
         //RemoveCharacterFromPlayer = new MyICommand();

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
            CreateCharacterJson();
         }
      }

      private void CreateCharacterJson()
      {
         string[] pics = Directory.GetFiles(WorkDirEtcPic);
         int count = pics.Length;
         ObservableCollection<Character> c = new ObservableCollection<Character>();

         foreach (string pic in pics)
         {
            string nameWithScore = Path.GetFileName(pic);

            nameWithScore = nameWithScore.Replace(".png", "");

            Character character = new Character(nameWithScore);

            try
            {
               AllCharacters.Add(character);
            }
            catch // catch fires when the program starts
            {
               c.Add(character);
               AllCharacters = c;
            }

            count--;
         }

         new CharacterJson(WorkDirEtc, AllCharacters);
      }

      private void LoadCharacters()
      {
         foreach (Character c in CharacterJson.GetCharactersFromJson()) 
         {
            try
            {
               AllCharacters.Add(c);
            }
            catch // catch fires when the program starts
            {
               ObservableCollection<Character> characters = new ObservableCollection<Character>();
               
               characters.Add(c);
               AllCharacters = characters;
            }
         }
      }

      private void AddCharacterToPlayer()
      {
         try
         {
            PlayerCharacters.Add(_addSelectedCharacter);
         }
         catch
         {
            ObservableCollection<Character> playerCharacters = new ObservableCollection<Character>();

            playerCharacters.Add(AddSelectedCharacter);

            PlayerCharacters = playerCharacters;
         }

         SortPlayerCharacters();
      }

      private void SortPlayerCharacters()
      {
         ObservableCollection<Character> sorted;
         sorted = new ObservableCollection<Character>(PlayerCharacters.OrderBy(c => c.Name));

         PlayerCharacters = sorted;
      }

      private void OnDelete()
      {
         PlayerCharacters.Remove(DeleteSelectedCharacter);
      }

      private bool CanDelete()
      {
         return DeleteSelectedCharacter != null;
      }

      private void StartGame()
      {
         string output = "";

         foreach(Character c in PlayerCharacters)
         {
            output += c.Name + "/n";
         }

         MessageBox.Show(output);
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
