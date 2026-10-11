using ScoolMaegMentSystem.Model;
using System.Diagnostics.Metrics;

namespace ScoolMaegMentSystem.Repos.Interface
{
    public interface ICourceCustom:IGenaricRepo<Course>
    {
        Task<Course> SearchByTitle(string title);
        Task<ICollection<Course>> FilterByTeacherIdORcreditHours(int? Tid, int? creditHours);
        
    }
}
