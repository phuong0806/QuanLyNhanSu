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
    [Route("api/ChucVu")]
    public class ChucVuController : Controller
    {
        private IChucVuRepository chucVuRepository;

        public ChucVuController(IChucVuRepository chucVuRepository)
        {
            this.chucVuRepository = chucVuRepository;
        }

        // GET: HopDong
        [HttpGet]
        public async Task<IEnumerable<Chucvu>> getAll()
        {
            var list = await chucVuRepository.getAll();
            return list;
        }

        // GET: 
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            var model = await chucVuRepository.getById(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Chucvu model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            await chucVuRepository.Create(model);

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]Chucvu model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            model.Id = id;

            await chucVuRepository.Update(model);

            return Ok(model);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id < 1)
            {
                return NotFound();
            }

            await chucVuRepository.Delete(id);

            return new NoContentResult();
        }
    }
}