using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QLNS.Data.Interface;
using QLNS.Model;

namespace QLNS.Controllers
{
    [Produces("application/json")]
    [Route("api/KyLuat")]
    public class KyLuatController : Controller
    {
        private IKyLuatRepository kyLuatRepository;

        public KyLuatController(IKyLuatRepository kyLuatRepository)
        {
            this.kyLuatRepository = kyLuatRepository;
        }

        // GET: HopDong
        [HttpGet]
        public async Task<IEnumerable<Kyluat>> getAll()
        {
            var list = await kyLuatRepository.getAll();
            return list;
        }

        // GET: 
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            var model = await kyLuatRepository.getById(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Kyluat model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            await kyLuatRepository.Create(model);

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]Kyluat model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            model.Id = id;

            await kyLuatRepository.Update(model);

            return Ok(model);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id < 1)
            {
                return NotFound();
            }

            await kyLuatRepository.Delete(id);

            return new NoContentResult();
        }
    }
}