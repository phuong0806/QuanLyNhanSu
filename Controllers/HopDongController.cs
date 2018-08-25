using Microsoft.AspNetCore.Mvc;
using QLNS.Data.Interface;
using QLNS.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLNS.Controllers
{
    [Produces("application/json")]
    [Route("api/HopDong")]
    public class HopDongController : Controller
    {
        private readonly IHopDongRepository _context;

        public HopDongController(IHopDongRepository context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Hopdong>> getAll()
        {
            var DanhSachHopDong = await _context.getAll();
            return DanhSachHopDong;
        }

        // GET: 
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            var model = await _context.getById(id);

            if (model == null)
            {
                return NotFound(); 
            }

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Hopdong model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            await _context.Create(model);

            return Ok(model); 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,[FromBody]Hopdong model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            model.Id = id;

            await _context.Update(model);

            return Ok(model);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id < 1)
            {
                return NotFound(); 
            }

            await _context.Delete(id);

            return new NoContentResult(); 
        }
    }
}