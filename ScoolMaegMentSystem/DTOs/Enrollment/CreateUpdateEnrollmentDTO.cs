namespace ScoolMaegMentSystem.DTOs.Enrollment
{
    public class CreateUpdateEnrollmentDTO
    {
        public int StudentId { get; set; }

        public int CourceId { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public double? Grade { get; set; }
    }
}
