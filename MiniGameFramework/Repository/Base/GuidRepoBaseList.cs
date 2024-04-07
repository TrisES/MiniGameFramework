using MiniGameFramework.Repository.Interfaces;
using MiniGameFramework.MarkerInterfaces;

namespace MiniGameFramework.Repository.Base
{
    public class GuidRepoBaseList<T> : IRepositoryGUID<T> where T : class, IHasGuid
    {
        protected readonly List<T> _list;

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
        
    }
}
