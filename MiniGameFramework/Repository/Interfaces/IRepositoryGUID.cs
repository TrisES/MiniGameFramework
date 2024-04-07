using MiniGameFramework.MarkerInterfaces;

namespace MiniGameFramework.Repository.Interfaces
{
    /// <summary>
    /// Generic interface for a repository using entities with a GUID ID.
    /// </summary>
    /// <typeparam name="T">The entity type that the repository works with.</typeparam>
    public interface IRepositoryGUID<T> where T : class, IHasGuid
    {
        /// <summary>
        /// Gets a list of all entities in the repository.
        /// </summary>
        /// <returns>List of all entities in the repository.</returns>
        IEnumerable<T> Get();

        /// <summary>
        /// Gets the entity with the specified GUID from the repository.
        /// </summary>
        /// <param name="id">The ID of the entity to get.</param>P
        /// <returns>The entity with the specified GUID, or null if it is not found.</returns>
        T? GetById(Guid id);

        /// <summary>
        /// Adds a new entity to the repository.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>The added entity, or null if it couldn't be added</returns>
        T Add(T entity);

        /// <summary>
        /// Deletes the entity with the specified GUID from the repository.
        /// </summary>
        /// <param name="id">The GUID of the entity to delete.</param>
        /// <returns>The deleted entity, or null if it is not found.</returns>
        T? Delete(Guid id);

        /// <summary>
        /// Updates the entity with the specified GUID in the repository.
        /// </summary>
        /// <param name="id">The GUID of the entity to update.</param>
        /// <param name="entity">The updated entity data.</param>
        /// <returns>The updated entity, or null if it is not found.</returns>
        //T? Update(Guid id, T entity);
    }
}
