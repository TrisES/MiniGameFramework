using MiniGameFramework.Repository.Interfaces;
using MiniGameFramework.MarkerInterfaces;

namespace MiniGameFramework.Repository.Base
{
    public class IntegerRepoBaseDictionary<T> : IRepositoryID<T> where T : class, IHasId
    {
        protected readonly Dictionary<int, T> _dictionary;
        protected int _nextId;

        public IntegerRepoBaseDictionary() 
        {
            _dictionary = new Dictionary<int, T>();
            _nextId = 1;
        }

        public T Add(T entity)
        {
            entity.Id = _nextId++;
            _dictionary.Add(entity.Id, entity);
            return entity;
        }

        public T? GetById(int id)
        {
            return _dictionary.TryGetValue(id, out T? entity) ? entity : null;
        }

        public IEnumerable<T> Get()
        {
            return _dictionary.Values;
        }

        public T? Delete(int id)
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
