using Werwolf.ViewModel;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Werwolf.Model
{
   class Character
   {
      public string Name { get; set; }
      public string Description { get; set; }
      public bool Alive { get; set; }
      public bool WakesUp { get; set; }
      public uint WakeUpOrder { get; set; }
      public Image Image { get; set; }

      public Character(string name, string description, bool wakesUp, uint wakeUpOrder)
      {
         this.Name = name;
         this.Description = description;
         this.Alive = true;
         this.WakesUp = wakesUp;
         this.WakeUpOrder = wakeUpOrder;
         this.Image = FindImage(name);
      }

      public Character(string name, string description, bool wakesUp)
      {
         this.Name = name;
         this.Description = description;
         this.Alive = true;
         this.WakesUp = wakesUp;
         this.Image = FindImage(name);
      }

      public Character(string name, bool wakesUp, uint wakeUpOrder)
      {
         this.Name = name;
         this.Alive = true;
         this.WakesUp = wakesUp;
         this.WakeUpOrder = wakeUpOrder;
         this.Image = FindImage(name);
      }

      public Character(string name, bool wakesUp)
      {
         this.Name = name;
         this.Alive = true;
         this.WakesUp = wakesUp;
         this.Image = FindImage(name);
      }

      private Image FindImage(string name)
      {
         name = name.Replace(" ", "_");
         if (File.Exists(ModeratorViewModel.workDirEtcPic + name + ".jpg"))
         {
            return Image.FromFile(ModeratorViewModel.workDirEtcPic + name + ".jpg");
         }

         return null;
      }

      public void Ability()
      {
      }
   }
}
