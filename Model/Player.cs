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
   class Player
   {
      public string Name { get; set; }
      public Character Character { get; set; }
      public bool Alive { get; set; }

      public Player(string name, Character character)
      {
         this.Name = name;
         this.Character = character;
         this.Alive = true;
      }

      public Player()
      {

      }
   }
}