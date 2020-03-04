using Werwolf.Model;

using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Werwolf.ViewModel
{
   class CreateJson
   {
      public ObservableCollection<Character> Characters { get; set; }

      public CreateJson(string workDirEtc, ObservableCollection<Character> characters)
      {
         this.Characters = characters;

         CreateFile();
         CreateEntry();
      }

      private string GetJsonPath()
      {
         return GameSetUpViewModel.WorkDirEtc + @"/Characters.json";
      }

      private void CreateFile()
      {
         if (!File.Exists(GetJsonPath()))
         {
            File.Create(GetJsonPath()).Close();
         }
      }

      private void CreateEntry()
      {
         JObject json;

         json =
            new JObject(
               new JProperty("PNG Directory", GameSetUpViewModel.WorkDirEtcPic),
               new JProperty("Characters",
                  new JArray(
                     from c in Characters
                     orderby c.Name
                     select new JObject(
                        new JProperty("Name", c.Name),
                        new JProperty("Werewolf", c.Werewolf),
                        new JProperty("WakesUp", c.WakesUp),
                        new JProperty("Score", c.Score)))));

         File.WriteAllText(GetJsonPath(), json.ToString());
      }
   }
}
