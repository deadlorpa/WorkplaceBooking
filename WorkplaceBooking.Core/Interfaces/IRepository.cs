namespace WorkplaceBooking.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Получить все
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAll();

        /// <summary>
        /// Получить по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetById(int id);

        /// <summary>
        /// Создать
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> Create(T entity);

        /// <summary>
        /// Обновить
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> Update(T entity);

        /// <summary>
        /// Удалить
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<int> Delete(int id);
    }
}
