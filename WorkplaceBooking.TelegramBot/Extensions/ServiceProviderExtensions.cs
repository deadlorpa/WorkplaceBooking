using Microsoft.Extensions.Options;
namespace WorkplaceBooking.TelegramBot.Extensions
{
    /// <summary>
    /// Расширения для <see cref="ServiceProvider"/>
    /// </summary>
    public static class ServiceProviderExtensions
    {
        /// <summary>
        /// Получение конфигурации
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static T GetConfiguration<T>(this IServiceProvider serviceProvider)
        where T : class
        {
            var o = serviceProvider.GetService<IOptions<T>>();
            if (o is null)
                throw new ArgumentNullException(nameof(T));

            return o.Value;
        }
    }
}
