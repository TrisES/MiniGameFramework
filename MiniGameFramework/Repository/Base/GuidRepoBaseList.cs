using MiniGameFramework.Repository.Interfaces;
using MiniGameFramework.MarkerInterfaces;

namespace MiniGameFramework.Repository.Base
{
    public class GuidRepoBaseList<T> : IRepositoryGUID<T> where T : class, IHasGuid
    {
        protected readonly List<T> _list;

        public int Count => _list.Count;

        public GuidRepoBaseList()
        {
            _list = new List<T>();
        }

        public T Add(T entity)
        {
            entity.Id = Guid.NewGuid();
            _list.Add(entity);
            return entity;
        }

        public T? GetById(Guid id)
        {
            return _list.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<T> Get()
        {
            return _list;
        }

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
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Exists(Guid id)
        {
            return _list.Any(e => e.Id == id);
        }

        /// <summary>
        /// Gets a list of entities that match the specified predicate.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<T> Get(Func<T, bool> predicate)
        {
            return _list.Where(predicate);
        }

        /// <summary>
        /// Gets the first entity that matches the specified predicate.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public T? GetFirst(Func<T, bool> predicate)
        {
            return _list.FirstOrDefault(predicate);
        }
    }
}
