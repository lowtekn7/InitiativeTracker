using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

using InitiativeTracker.Domain.Entities;
using InitiativeTracker.WebUI.Models;
using InitiativeTracker.Domain.Abstract;

using System.Web.Mvc;



namespace InitiativeTracker.WebUI.Infrastructure
{
    public static class SharedMethods
    {
        public static IEnumerable<CharacterViewModel> ConvertIEToCharacterVM(
            IEnumerable<Character> characterList, IEnumerable<CharacterGroup> groups)
        {
            List<CharacterViewModel> list = new List<CharacterViewModel>();
            foreach (Character character in characterList)
            {
                list.Add(ConvertToCharacterVM(character, groups));
            }
            IEnumerable<CharacterViewModel> output = list;
            return output;
        }

        public static CharacterViewModel ConvertToCharacterVM(Character item, IEnumerable<CharacterGroup> groups)
        {

            CharacterViewModel output = new CharacterViewModel()
            {
                Character_ID = item.Character_ID,
                Name = item.Name,
                Group = groups.FirstOrDefault(x => x.Group_ID == item.Group_ID).Name,
                Initiative = item.Initiative,
                Initiative_Bonus = item.Initiative_Bonus,

            };
            return output;
        }

        public static IEnumerable<T> GetItemsFrom<T>(IDefaultRepository<T> context)
        {
            return context.items;
        }

        public static SelectList SelectListOf<T>(IDefaultRepository<T> repo)
        {
            SelectList output = new SelectList(
                GetItemsFrom(repo)
                .Select(x => new SelectListItem
                {
                    Value = x.GetType().GetProperty(GetID(x)).GetValue(x).ToString(),
                    Text = x.GetType().GetProperty("Name").GetValue(x).ToString()
                }), "Value", "Text");
            return output;
        }

        private static string GetID<T>(T item)
        {
            string output = "";
            PropertyInfo[] properties = item.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                KeyAttribute attribute = Attribute.GetCustomAttribute(property, typeof(KeyAttribute)) as KeyAttribute;
                if (attribute != null)
                {
                    output = property.Name.ToString();
                }
            }
            return output;
        }


    }
}