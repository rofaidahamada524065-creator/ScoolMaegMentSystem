using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScoolMaegMentSystem.DTOs.Student;
using ScoolMaegMentSystem.DTOs.Teatcher;
using ScoolMaegMentSystem.Model;
using ScoolMaegMentSystem.UnitOfWorkk;

namespace ScoolMaegMentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeatcherController : ControllerBase
    {
        private readonly IUnitOfWork _repo;
        private readonly IMapper _map;
        public TeatcherController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repo = unitOfWork;
            _map = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllTeatcher()
        {
            var x = await _repo.teacher.GetAllAsync();
            var list = _map.Map<List<TeatcherDTO>>(x);
            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUpdateTeatcherDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("Enter Data");
            }
            var d = _map.Map<Teacher>(dto);
            await _repo.teacher.CreateAsync(d);
            await _repo.SaveChangeAsync();
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> Update(CreateUpdateTeatcherDTO dto, int id)
        {
            var x = await _repo.teacher.GetById(id);
            if (x == null)
            {
                return NotFound();
            }
            x.FullName = dto.FullName;
            x.Email = dto.Email;
            x.Phone = dto.Phone;
            x.HireDate = dto.HireDate;

            await _repo.SaveChangeAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {

            var x = await _repo.teacher.GetById(id);
            if (x == null)
            {
                return NotFound();
            }
            _repo.teacher.Delete(id);
            await _repo.SaveChangeAsync();
            return Ok();
        }
    }
}
