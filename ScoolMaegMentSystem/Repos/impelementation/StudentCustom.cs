using Microsoft.EntityFrameworkCore;
using ScoolMaegMentSystem.Data;
using ScoolMaegMentSystem.Model;
using ScoolMaegMentSystem.Repos.Interface;

namespace ScoolMaegMentSystem.Repos.impelementation
{
    public class StudentCustom : GenaricRepo<Student>, IStudentCustom
    {
        private readonly AppDbcontext _context;
        public StudentCustom(AppDbcontext appDbcontext) : base(appDbcontext)
        {
            _context = appDbcontext;
        }

        public async Task<ICollection<Student>> Filter_by_gender(string Gender)
        {
            return await _context.students.Where(a => a.Gender.ToLower().Contains(Gender.ToLower())).ToListAsync();
        }

        public async Task<ICollection<Student>> Pagination(int pageSize, int pageNumber)
        {
            return await _context.students.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<Student> SearchByName(string name)
        {
            return await _context.students.Where(a => a.FullName.Contains(name)).FirstOrDefaultAsync();
        }
    }
}
