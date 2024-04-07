using MiniGameFramework.Repository.Interfaces;
using MiniGameFramework.MarkerInterfaces;

namespace MiniGameFramework.Repository.Base
{
    public class GuidRepoBaseDictionary<T> : IRepositoryGUID<T> where T : class, IHasGuid
    {
        protected readonly Dictionary<Guid, T> _dictionary;

        public GuidRepoBaseDictionary() 
        {
            _dictionary = new Dictionary<Guid, T>();
        }

        public T Add(T entity)
        {
            entity.Id = Guid.NewGuid();
            _dictionary.Add(entity.Id, entity);
            return entity;
        }

        public T? GetById(Guid id)
        {
            return _dictionary.TryGetValue(id, out T? entity) ? entity : null;
        }

        public IEnumerable<T> Get()
        {
            return _dictionary.Values;
        }

        public T? Delete(Guid id)
        {
            if (_dictionary.TryGetValue(id, out T? entity))
            {
                _dictionary.Remove(id);
                return entity;
            }
            return null;
        }

    }
}
