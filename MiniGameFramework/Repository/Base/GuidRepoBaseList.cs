using MiniGameFramework.Repository.Interfaces;
using MiniGameFramework.MarkerInterfaces;

namespace MiniGameFramework.Repository.Base
{
    /// <summary>
    /// A base repository class for managing entities with GUIDs using a list for storage.
    /// </summary>
    /// <typeparam name="T">The type of the entity. Must implement IHasGuid.</typeparam>
    public class GuidRepoBaseList<T> : IRepositoryGUID<T> where T : class, IHasGuid
    {
        /// <summary>
        /// The list of entities.
        /// </summary>
        protected readonly List<T> _list;

        /// <summary>
        /// Gets the count of entities in the repository.
        /// </summary>
        public int Count => _list.Count;

        /// <summary>
        /// Initializes a new instance of the GuidRepoBaseList class.
        /// </summary>
        public GuidRepoBaseList()
        {
            _list = new List<T>();
        }

        /// <summary>
        /// Adds a new entity to the repository.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>The added entity.</returns>
        public T Add(T entity)
        {
            entity.Id = Guid.NewGuid();
            _list.Add(entity);
            return entity;
        }

        /// <summary>
        /// Gets an entity by its GUID.
        /// </summary>
        /// <param name="id">The GUID of the entity.</param>
        /// <returns>The entity if found; otherwise, null.</returns>
        public T? GetById(Guid id)
        {
            return _list.FirstOrDefault(e => e.Id == id);
        }

        /// <summary>
        /// Gets all entities in the repository.
        /// </summary>
        /// <returns>A list of all entities.</returns>
        public IEnumerable<T> Get()
        {
            return _list;
        }

        /// <summary>
        /// Deletes an entity by its GUID.
        /// </summary>
        /// <param name="id">The GUID of the entity.</param>
        /// <returns>The deleted entity if found; otherwise, null.</returns>
        public T? Delete(Guid id)
        {
            T? entityToDelete = GetById(id);
            if (entityToDelete != null)
            {
                _list.Remove(entityToDelete);
                return entityToDelete;
            }
            return null;
        }

        /// <summary>
        /// Checks if an entity with the specified GUID exists in the repository.
        /// </summary>
        /// <param name="id">The GUID of the entity.</param>
        /// <returns>True if the entity exists; otherwise, false.</returns>
        public bool Exists(Guid id)
        {
            return _list.Any(e => e.Id == id);
        }

        /// <summary>
        /// Gets a list of entities that match the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate to match.</param>
        /// <returns>A list of matching entities.</returns>
        public IEnumerable<T> Get(Func<T, bool> predicate)
        {
            return _list.Where(predicate);
        }

        /// <summary>
        /// Gets the first entity that matches the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate to match.</param>
        /// <returns>The first matching entity if found; otherwise, null.</returns>
        public T? GetFirst(Func<T, bool> predicate)
        {
            return _list.FirstOrDefault(predicate);
        }
    }
}
