namespace LegacyModernization.Application.Abstractions.Repositories
{
    public interface IBaseRepository
    {
        /// <summary>
        /// Add given entity into DbSet
        /// </summary>
        /// <param name="entity"></param>
        public void Add<T>(T entity) where T : class;

        /// <summary>
        /// Saves Context
        /// </summary>
        /// <returns>Task</returns>
        Task SaveChangesAsync();
    }
}
