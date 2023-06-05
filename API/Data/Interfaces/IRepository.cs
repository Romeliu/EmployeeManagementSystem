namespace API.Data.Interfaces
{
    public interface IRepository<E>
    {
        public Task<E> AddAsync(E entity);
        public Task<E> GetByIdAsync(int id);
        public Task<IEnumerable<E>> GetAllAsync();
        public Task<E> UpdateAsync(E entity);
        public Task<E> DeleteAsync(E entity);
    }
}