namespace WorkplaceBooking.Utils
{
    public static class Utils
    {
        /// <summary>
        /// Заменяет пустую строку на null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ReplaceEmptyWithNull(string value)
        {
            return string.IsNullOrEmpty(value) ? null : value;
        }
    }
}
