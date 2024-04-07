using MiniGameFramework.Repository.Interfaces;
using MiniGameFramework.MarkerInterfaces;

namespace MiniGameFramework.Repository.Base
{
    public class IntegerRepoBaseList<T> : IRepositoryID<T> where T : class, IHasId
    {
        protected readonly List<T> _list;
        protected int _nextId;

        public IntegerRepoBaseList()
        {
            _list = new List<T>();
            _nextId = 1;
        }

        public T Add(T entity)
        {
            entity.Id = _nextId++;
            _list.Add(entity);
            return entity;
        }

        public T? GetById(int id)
        {
            return _list.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<T> Get()
        {
            return _list;
        }

        public T? Delete(int id)
        {
            T? entityToDelete = GetById(id);
            if (entityToDelete != null)
            {
                _list.Remove(entityToDelete);
                return entityToDelete;
            }
            return null;
        }
        
    }
}
