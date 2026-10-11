using ScoolMaegMentSystem.Model;

namespace ScoolMaegMentSystem.Repos.Interface
{
    public interface IEnrollmentCustom:IGenaricRepo<Enrollment>
    {
        Task<ICollection<Enrollment>> studentid(int StudentId);
        Task<ICollection<Enrollment>> Cource_id(int CourceId);
        Task<double> average_grades();
        Task<ICollection<Enrollment>> top_students();
        Task<bool> has_students(int StudentId,int courceId);
    }
}

