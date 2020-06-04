using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Wallet.Core.Extentions
{
	public static class EnumExtensions
    {
        /// <summary>
        /// Получить описание из атрибута Description
        /// </summary>
        /// <param name="enumValue">Перечисление.</param>
        /// <returns>Строку или null.</returns>
        public static string GetDescription(this Enum enumValue)
        {
            var attribute = enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .FirstOrDefault()?
                            .GetCustomAttribute<DescriptionAttribute>();
			if (attribute is null || string.IsNullOrWhiteSpace(attribute.Description))
			{
                return null;
			}

            return attribute.Description;
        }
    }
}
