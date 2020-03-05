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
   class Character
   {
      public string Name { get; set; }
      public bool Werewolf { get; set; }
      public bool WakesUp { get; set; }
      public int Score { get; set; }
      public Image Image { get; set; }

      public Character(string nameWithScore, bool werewolf, bool wakesUp)
      {
         this.Name = nameWithScore.Substring(0, nameWithScore.Length - 2);
         this.Werewolf = werewolf;
         this.WakesUp = wakesUp;
         string _score = nameWithScore.Substring(nameWithScore.Length - 2, 2);
         this.Score = Convert.ToInt32(_score);
         this.Image = FindImage(Name, _score);
      }

      private Image FindImage(string name, string score)
      {
         name = name.Replace(" ", "_");
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
