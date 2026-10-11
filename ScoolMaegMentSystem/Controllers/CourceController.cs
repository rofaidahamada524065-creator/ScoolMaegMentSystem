using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScoolMaegMentSystem.DTOs.Cource;
using ScoolMaegMentSystem.DTOs.Student;
using ScoolMaegMentSystem.Model;
using ScoolMaegMentSystem.UnitOfWorkk;

namespace ScoolMaegMentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourceController : ControllerBase
    {
        private readonly IUnitOfWork _repo;
        private readonly IMapper _map;
        public CourceController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repo = unitOfWork;
            _map = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllCource()
        {
            var x = await _repo.cource.GetAllAsync();
            var list = _map.Map<List<CourceDTO>>(x);
            return Ok(list);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateUpdateCourceDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("Enter Data");
            }
            var d = _map.Map<Course>(dto);
            await _repo.cource.CreateAsync(d);
            await _repo.SaveChangeAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(CreateUpdateCourceDTO dto, int id)
        {
            var x = await _repo.cource.GetById(id);
            if (x == null)
            {
                return NotFound();
            }
            x.Title = dto.Title;
            x.CreditHours = dto.CreditHours;
            x.TeatcherId = dto.TeatcherId;
           
            await _repo.SaveChangeAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {

            var x = await _repo.cource.GetById(id);
            if (x == null)
            {
                return NotFound();
            }
            _repo.cource.Delete(id);
            await _repo.SaveChangeAsync();
            return Ok();
        }

        [HttpGet("SearchByTitle")]
        public async Task<IActionResult> searchByTitle(string name)
        {
            var x = await _repo.cource.SearchByTitle(name);
            if (x == null)
            {
                return BadRequest("Title Not Found");
            }

            var list = _map.Map<CourceDTO>(x);
            return Ok(list);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> searchByname(int ?TeatcherId,int ?RcreditHours)
        {
            var x = await _repo.cource.FilterByTeacherIdORcreditHours(TeatcherId, RcreditHours);
            

            var list = _map.Map<List<CourceDTO>>(x);
            return Ok(list);
        }
    }
}
