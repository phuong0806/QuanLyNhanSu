using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLNS.Data.Interface;
using QLNS.Model;

namespace QLNS.Controllers
{
    [Produces("application/json")]
    [Route("api/KhenThuong")]
    public class KhenThuongController : Controller
    {
        private IKhenThuongRepository khenThuongRepository;

        public KhenThuongController(IKhenThuongRepository khenThuongRepository)
        {
            this.khenThuongRepository = khenThuongRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Khenthuong>> getAll()
        {
            var list = await khenThuongRepository.getAll();
            return list;
        }

        // GET: 
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            var model = await khenThuongRepository.getById(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Khenthuong model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            await khenThuongRepository.Create(model);

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]Khenthuong model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            model.Id = id;

            await khenThuongRepository.Update(model);

            return Ok(model);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id < 1)
            {
                return NotFound();
            }

            await khenThuongRepository.Delete(id);

            return new NoContentResult();
        }
    }
}