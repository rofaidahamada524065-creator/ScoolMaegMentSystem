using ScoolMaegMentSystem.Model;

namespace ScoolMaegMentSystem.Repos.Interface
{
    public interface IStudentCustom:IGenaricRepo<Student>
    {
        Task<Student> SearchByName(string name);
        Task<ICollection<Student>> Filter_by_gender(string Gender);
        Task<ICollection<Student>> Pagination(int pageSize, int pageNumber);
    }
}
