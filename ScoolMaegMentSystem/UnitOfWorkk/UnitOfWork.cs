using ScoolMaegMentSystem.Data;
using ScoolMaegMentSystem.Model;
using ScoolMaegMentSystem.Repos.Interface;

namespace ScoolMaegMentSystem.UnitOfWorkk
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbcontext _context;
        public UnitOfWork(AppDbcontext appDbcontext,IStudentCustom student,IGenaricRepo<Teacher> genaricRepo,ICourceCustom courceCustom,IEnrollmentCustom enrollmentCustom)
        {
            _context = appDbcontext;
            this.student = student;
            teacher = genaricRepo;
            cource = courceCustom;
            Enrollment = enrollmentCustom;
        }
        public IStudentCustom student { get; }

        public IGenaricRepo<Teacher> teacher { get; }

        public ICourceCustom cource { get; }

        public IEnrollmentCustom Enrollment { get; }

        public async Task<int> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
