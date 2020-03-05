using Werwolf.Model;

using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Windows;

namespace Werwolf.ViewModel
{
   class Json
   {
      public ObservableCollection<Character> Characters { get; set; }

      public Json(string workDirEtc, ObservableCollection<Character> characters)
      {
         this.Characters = characters;

         CreateFile();
         CreateEntry();
      }

      private static string GetJsonPath()
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
                        new JProperty("WakesUpFirstNight", c.WakesUpFirstNight),
                        new JProperty("WakesUpAllNights", c.WakesUpAllNights),
                        new JProperty("WakesUpOneNight", c.WakesUpOneNight),
                        new JProperty("Score", c.Score)))),

               new JProperty("WakesUpFirstNight",
                  new JArray(
                     new JObject(
                        new JProperty("Cupid", 1),
                        new JProperty("Doppelgaenger", 2),
                        new JProperty("Hoodlum", 3),
                        new JProperty("Mason", 4),
                        new JProperty("Werewolfs and Minios", 5)))),

               new JProperty("WakesUpOneNightEnum",
                  new JArray(
                     new JObject(
                        new JProperty("Bodyguard", 1),
                        new JProperty("Werewolfs", 2),
                        new JProperty("Sorceress", 3),
                        new JProperty("Vampire", 4),
                        new JProperty("Seer", 5),
                        new JProperty("Aura_Seer", 6),
                        new JProperty("Spellcaster", 7),
                        new JProperty("Cult_Leader", 8),
                        new JProperty("Old_Hag", 9)))),

               new JProperty("WakesUpAllNights",
                  new JArray(
                     new JObject(
                        new JProperty("Witch", 1),
                        new JProperty("Pi", 2),
                        new JProperty("Priest", 3),
                        new JProperty("Troublemaker", 4)))));

         File.WriteAllText(GetJsonPath(), json.ToString());
      }

      public static void GetCharactersFromJson()
      {
         GetDeliveryJArray();
      }

      private static JArray GetDeliveryJArray()
      {
         string jsonText = File.ReadAllText(GetJsonPath());
         JObject jObject = JObject.Parse(jsonText);
         return (JArray)jObject["Characters"];
      }
   }
}
