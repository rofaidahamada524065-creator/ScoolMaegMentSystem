using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using ScoolMaegMentSystem.DTOs.Cource;
using ScoolMaegMentSystem.DTOs.Enrollment;
using ScoolMaegMentSystem.Model;
using ScoolMaegMentSystem.UnitOfWorkk;

namespace ScoolMaegMentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IUnitOfWork _repo;
        private readonly IMapper _map;
        public EnrollmentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repo = unitOfWork;
            _map = mapper;

        }

       

        [HttpPost]
        public async Task<IActionResult> Create(CreateUpdateEnrollmentDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("Enter Data");
            }
            var d = _map.Map<Enrollment>(dto);
            await _repo.Enrollment.CreateAsync(d);
            await _repo.SaveChangeAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {

            var x = await _repo.Enrollment.GetById(id);
            if (x == null)
            {
                return NotFound();
            }
            _repo.Enrollment.Delete(id);
            await _repo.SaveChangeAsync();
            return Ok();
        }

        [HttpGet("studentId")]
        public async Task<IActionResult> studentById(int StudentId)
        {
            var x =await _repo.Enrollment.studentid(StudentId);
            if (x == null)
            {
                return NotFound();
            }
            var list = _map.Map<List<EnrollmentDTO>>(x);
            return Ok(list);
        }

        [HttpGet("CourceId")]
        public async Task<IActionResult> CourceById(int courceId)
        {
            var x = await _repo.Enrollment.Cource_id(courceId);
            if (x == null)
            {
                return NotFound();
            }
            var list = _map.Map<List<EnrollmentDTO>>(x);
            return Ok(list);
        }
        [HttpGet("TopStudent")]
        public async Task<IActionResult> TopStudent()
        {
            var x = await _repo.Enrollment.top_students();

            var list = _map.Map<List<EnrollmentDTO>>(x);
            return Ok(list);
        }

        [HttpGet("Avarege")]
        public async Task<IActionResult> Avarege()
        {
            var x = await _repo.Enrollment.average_grades();
            
           
            return Ok(x);
        }

        [HttpGet("has_students")]
        public async Task<IActionResult> has_students(int sId,int cid)
        {
            var x = await _repo.Enrollment.has_students(sId,cid);

           
            return Ok(x);
        }


    }
}
