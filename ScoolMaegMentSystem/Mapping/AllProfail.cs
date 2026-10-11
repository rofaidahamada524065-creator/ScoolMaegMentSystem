using AutoMapper;
using ScoolMaegMentSystem.DTOs.Cource;
using ScoolMaegMentSystem.DTOs.Enrollment;
using ScoolMaegMentSystem.DTOs.Student;
using ScoolMaegMentSystem.DTOs.StudentProfaile;
using ScoolMaegMentSystem.DTOs.Teatcher;
using ScoolMaegMentSystem.Model;

namespace ScoolMaegMentSystem.Mapping
{
    public class AllProfail:Profile
    {
        public AllProfail()
        {
            CreateMap<Student, StudentDTO>().ReverseMap();
            CreateMap<Student, CreateUpdateDtO>().ReverseMap();

            CreateMap<Teacher, CreateUpdateTeatcherDTO>().ReverseMap();
            CreateMap<Teacher, TeatcherDTO>().ReverseMap();

            CreateMap<StudentProfile, StudentProfailDTO>().ReverseMap();
            CreateMap<StudentProfile, CreateUpdateStuProfaiDTO>().ReverseMap();

            CreateMap<Course, CourceDTO>().ReverseMap();
            CreateMap<Course, CreateUpdateCourceDTO>().ReverseMap();

            CreateMap<Enrollment, EnrollmentDTO>().ReverseMap();
            CreateMap<Enrollment, CreateUpdateEnrollmentDTO>().ReverseMap();
        }
    }
}
