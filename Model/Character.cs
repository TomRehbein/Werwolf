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
      public int WakeUpOrder { get; set; }
      public Image Image { get; set; }
      public int Count { get; set; }

      public Character(string name, string description, bool wakesUp, int wakeUpOrder, int count)
      {
         this.Name = name;
         this.Description = description;
         this.Alive = true;
         this.WakesUp = wakesUp;
         this.WakeUpOrder = wakeUpOrder;
         this.Image = FindImage(name);
         this.Count = count;
      }

      public Character(string name, string description, bool wakesUp, int count)
      {
         this.Name = name;
         this.Description = description;
         this.Alive = true;
         this.WakesUp = wakesUp;
         this.Image = FindImage(name);
         this.Count = count;
      }

      public Character(string name, bool wakesUp, int wakeUpOrder, int count)
      {
         this.Name = name;
         this.Alive = true;
         this.WakesUp = wakesUp;
         this.WakeUpOrder = wakeUpOrder;
         this.Image = FindImage(name);
         this.Count = count;
      }

      public Character(string name, bool wakesUp, int count)
      {
         this.Name = name;
         this.Alive = true;
         this.WakesUp = wakesUp;
         this.Image = FindImage(name);
         this.Count = count;
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
