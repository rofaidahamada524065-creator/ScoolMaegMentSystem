namespace ScoolMaegMentSystem.Repos.Interface
{
    public interface IGenaricRepo<T> where T : class
    {
        Task CreateAsync(T entety);
        void Update(T enteity);
        void Delete(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetById(int id);
    }
}
