using Microsoft.EntityFrameworkCore;
using ScoolMaegMentSystem.Data;
using ScoolMaegMentSystem.Model;
using ScoolMaegMentSystem.Repos.Interface;

namespace ScoolMaegMentSystem.Repos.impelementation
{
    public class CourceCustom : GenaricRepo<Course>,ICourceCustom
    {
        private readonly AppDbcontext _context;
        public CourceCustom(AppDbcontext appDbcontext) : base(appDbcontext)
        {
            _context = appDbcontext;
        }

        public async Task<ICollection<Course>> FilterByTeacherIdORcreditHours(int? Tid, int? creditHours)
        {
            IQueryable<Course> x = _context.courses.Include(a => a.Teacher);
            if (Tid.HasValue)
            {
                x = x.Where(a => a.TeatcherId == Tid);
            }
            if (creditHours.HasValue)
            {
                x = x.Where(a => a.CreditHours == creditHours);
            }
            return await x.ToListAsync();
        }

       

        public async Task<Course> SearchByTitle(string title)
        {
            return await _context.courses.Where(a => a.Title.Contains(title)).FirstOrDefaultAsync();
        }
    }
}
