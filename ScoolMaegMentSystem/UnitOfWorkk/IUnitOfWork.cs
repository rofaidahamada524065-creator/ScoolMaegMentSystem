using ScoolMaegMentSystem.Model;
using ScoolMaegMentSystem.Repos.Interface;

namespace ScoolMaegMentSystem.UnitOfWorkk
{
    public interface IUnitOfWork
    {
        IStudentCustom student { get; }
        IGenaricRepo<Teacher> teacher { get; }
        ICourceCustom cource { get; }
        IEnrollmentCustom Enrollment { get; }
        Task<int> SaveChangeAsync();
    }
}
