using Microsoft.EntityFrameworkCore;
using ScoolMaegMentSystem.Data;
using ScoolMaegMentSystem.Model;
using ScoolMaegMentSystem.Repos.Interface;

namespace ScoolMaegMentSystem.Repos.impelementation
{
    public class EnrollmentCustom : GenaricRepo<Enrollment>, IEnrollmentCustom
    {
        private readonly AppDbcontext _context;
        public EnrollmentCustom(AppDbcontext appDbcontext) : base(appDbcontext)
        {
            _context = appDbcontext;
        }

        public async Task<double> average_grades()
        {
            return (double)await _context.enrollments.AverageAsync(a => a.Grade);
        }

        public async Task<ICollection<Enrollment>> Cource_id(int CourceId)
        {
            return await _context.enrollments.Include(A => A.Course).Include(a => a.Student).Where(a => a.CourceId == CourceId).ToListAsync();
        }

        public async Task<bool> has_students(int StudentId, int courceId)
        {
            return await _context.enrollments.AnyAsync(a => a.StudentId == StudentId && a.CourceId == courceId);
        }

        public async Task<ICollection<Enrollment>> studentid(int StudentId)
        {
            return await _context.enrollments.Include(A => A.Course).Include(a => a.Student).Where(a => a.StudentId == StudentId).ToListAsync();
        }

        public async Task<ICollection<Enrollment>> top_students()
        {
            return await _context.enrollments.Include(A => A.Course).Include(a => a.Student).OrderByDescending(a => a.Grade).Take(5).ToListAsync();
        }
    }
}
