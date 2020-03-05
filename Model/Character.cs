using Werwolf.ViewModel;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace Werwolf.Model
{
   #region Enums

   enum WerewolfsEnum
   {
      Werewolf,
      Lone_Wolf,
      Minion,
      Sorceress,
      Wolf_Cub
   }

   enum WakesUpFirstNightEnum
   {
      Cupid,
      Doppelgaenger,
      Hoodlum,
      Mason,
   }

   enum WakesUpAllNightsEnum
   {
      Bodyguard,
      Sorceress,
      Vampire,
      Seer,
      Aura_Seer,
      Spellcaster,
      Cult_Leader,
      Old_Hag 
   }

   enum WakesUpOneNightEnum
   {
      Witch,
      Pi,
      Priest,
      Troublemaker
   }

      #endregion Enums

   class Character
   {
      public string Name { get; set; }
      public bool Werewolf { get; set; }
      public bool WakesUpFirstNight { get; set; }
      public bool WakesUpAllNights { get; set; }
      public bool WakesUpOneNight { get; set; }
      public int Score { get; set; }
      public Image Image { get; set; }

      public Character(string nameWithScore)
      {
         // Name is with "_" instead of " " -> will be change at the end
         this.Name = nameWithScore.Substring(0, nameWithScore.Length - 2);
         this.Werewolf = Enum.IsDefined(typeof(WerewolfsEnum), Name);

         if (Werewolf)
         {
            this.WakesUpFirstNight = true;

            if(Name == "Minion")
            {
               this.WakesUpAllNights = false;
            }
            else
            {
               this.WakesUpAllNights = true;
            }
         }
         else
         {
            this.WakesUpFirstNight = Enum.IsDefined(typeof(WakesUpFirstNightEnum), Name);
            this.WakesUpAllNights = Enum.IsDefined(typeof(WakesUpAllNightsEnum), Name);
         }

         this.WakesUpOneNight = Enum.IsDefined(typeof(WakesUpOneNightEnum), Name);
         string _score = nameWithScore.Substring(nameWithScore.Length - 2, 2);
         this.Score = Convert.ToInt32(_score);
         this.Image = FindImage(Name, _score);

         this.Name = Name.Replace("_", " ");
      }

      public Character(string name, 
                       bool wakesUpFirstNight, 
                       bool wakesUpAllNights, 
                       bool wakesUpOneNight, 
                       int score)
      {
         this.Name = name;
         this.WakesUpFirstNight = wakesUpFirstNight;
         this.WakesUpAllNights = wakesUpAllNights;
         this.WakesUpOneNight = wakesUpOneNight;
         this.Score = score;

         if(Score >= 0)
         {
            this.Image = FindImage(Name.Replace(" ", "_"), "+" + Score.ToString());
         }
         else
         {
            this.Image = FindImage(Name.Replace(" ", "_"), Score.ToString());
         }
      }

      private Image FindImage(string name, string score)
      {
         if (File.Exists(GameSetUpViewModel.WorkDirEtcPic + @"/" + name + score + ".png"))
         {
            return Image.FromFile(GameSetUpViewModel.WorkDirEtcPic + @"/" + name + score + ".png");
         }

         return null;
      }

      public void Ability()
      {
      }
   }
}