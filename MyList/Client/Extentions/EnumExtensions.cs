using System.ComponentModel.DataAnnotations;
using System;
using System.Linq;
using System.Reflection;

namespace MyList.Client.Extentions
{
    public enum SearchingStates
    {
        [Display(Name = "По Замерам")]
        Measurement,

        [Display(Name = "По Монтажам")]
        Montage,

        [Display(Name = "По Бригадам")]
        Workers
    } 

    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            string displayName;
            displayName = enumValue.GetType()
                .GetMember(enumValue.ToString())
                .FirstOrDefault()!
                .GetCustomAttribute<DisplayAttribute>()?
                .GetName();
            if (String.IsNullOrEmpty(displayName))
            {
                displayName = enumValue.ToString();
            }
            return displayName;
        }
    }
}
