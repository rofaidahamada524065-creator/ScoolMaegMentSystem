using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScoolMaegMentSystem.DTOs.Student;
using ScoolMaegMentSystem.Model;
using ScoolMaegMentSystem.UnitOfWorkk;

namespace ScoolMaegMentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IUnitOfWork _repo;
        private readonly IMapper _map;
        public StudentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repo = unitOfWork;
            _map = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudent()
        {
            var x = await _repo.student.GetAllAsync();
            var list = _map.Map<List<StudentDTO>>(x);
            return Ok(list);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateUpdateDtO dto)
        {
            if (dto == null)
            {
                return BadRequest("Enter Data");
            }
            var d = _map.Map<Student>(dto);
            await _repo.student.CreateAsync(d);
            await _repo.SaveChangeAsync();
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var x = await _repo.student.GetById(id);
            if (x == null)
            {
                return NotFound();
            }
            var s = _map.Map<StudentDTO>(x);
            return Ok(s);
        }
        [HttpPut]
        public async Task<IActionResult> Update(CreateUpdateDtO dto, int id)
        {
            var x = await _repo.student.GetById(id);
            if (x == null)
            {
                return NotFound();
            }
            x.FullName = dto.FullName;
            x.Email = dto.Email;
            x.Phone = dto.Phone;
            x.BirthDate = dto.BirthDate;
            x.Gender = dto.Gender;
            await _repo.SaveChangeAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {

            var x = await _repo.student.GetById(id);
            if (x == null)
            {
                return NotFound();
            }
            _repo.student.Delete(id);
            await _repo.SaveChangeAsync();
            return Ok();
        }

        [HttpGet("searchByname")]
        public async Task<IActionResult> searchByname(string name)
        {
            var x =await _repo.student.SearchByName(name);
            if (x == null)
            {
                return BadRequest("Name Not Found");
            }

            var list = _map.Map<StudentDTO>(x);
            return Ok(list);
        }

        [HttpGet("Filter_by_gender")]

        public async Task<IActionResult> Filter_by_gender(string name)
        {
            var x = await _repo.student.Filter_by_gender(name);
            if (x == null)
            {
                return BadRequest("Name Not Found");
            }

            var list = _map.Map<List<StudentDTO>>(x);
            return Ok(list);
        }


        [HttpGet("Pagination")]
        public async Task<IActionResult> Pagination(int pageNum,int PageSize)
        {
            var x=await _repo.student.Pagination(pageNum, PageSize);
            if (x == null)
            {
                return BadRequest("No students found.");
            }
            if (PageSize <= 0 || pageNum <= 0)
            {
                return BadRequest("Page number and page size must be greater than zero.");
            }

            var list = _map.Map<List<StudentDTO>>(x);
            return Ok(list);
        }
    }
}
