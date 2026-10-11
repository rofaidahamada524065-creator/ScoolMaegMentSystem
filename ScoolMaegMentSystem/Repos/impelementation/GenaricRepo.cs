using Microsoft.EntityFrameworkCore;
using ScoolMaegMentSystem.Data;
using ScoolMaegMentSystem.Repos.Interface;

namespace ScoolMaegMentSystem.Repos.impelementation
{
    public class GenaricRepo<T> : IGenaricRepo<T> where T : class
    {
        private readonly AppDbcontext _context;
        public DbSet<T> db;
        public GenaricRepo(AppDbcontext appDbcontext)
        {

            _context = appDbcontext;
            db = _context.Set<T>();
            
        }
        public async Task CreateAsync(T entety)
        {
            await db.AddAsync(entety);
        }

        public void Delete(int id)
        {
            var x = db.Find(id);
            if (x != null)
            {
                db.Remove(x);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await db.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await db.FindAsync(id);
        }

        public void Update(T enteity)
        {
            db.Update(enteity);
        }
    }
}
