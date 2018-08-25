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
    [Route("api/ChuyenNganh")]
    public class ChuyenNganhController : Controller
    {
        private IChuyenNganhRepository chuyenNganhRepository;

        public ChuyenNganhController(IChuyenNganhRepository chuyenNganhRepository)
        {
            this.chuyenNganhRepository = chuyenNganhRepository;
        }

        // GET: HopDong
        [HttpGet]
        public async Task<IEnumerable<Chuyennganh>> getAll()
        {
            var list = await chuyenNganhRepository.getAll();
            return list;
        }

        // GET: 
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            var model = await chuyenNganhRepository.getById(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Chuyennganh model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            await chuyenNganhRepository.Create(model);

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]Chuyennganh model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            model.Id = id;

            await chuyenNganhRepository.Update(model);

            return Ok(model);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id < 1)
            {
                return NotFound();
            }

            await chuyenNganhRepository.Delete(id);

            return new NoContentResult();
        }
    }
}