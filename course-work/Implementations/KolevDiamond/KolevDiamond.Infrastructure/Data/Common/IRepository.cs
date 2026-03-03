namespace KolevDiamond.Infrastructure.Data.Common
{
    /// <summary>
    /// All operations are asynchronous
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// All records in a table
        /// </summary>
        IQueryable<T> All<T>() where T : class;

        /// <summary>
        /// The result collection won't be tracked by the context
        /// </summary>
        IQueryable<T> AllReadOnly<T>() where T : class;

        /// <summary>
        /// Saves all made changes in transaction
        /// </summary>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// Adds entity to the database
        /// </summary>
        Task AddAsync<T>(T entity) where T : class;

        /// <summary>
        /// Update a record in database
        /// </summary>
        void Update<T>(T entity) where T : class;
    }
}
