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
    [Route("api/DaoTaoChuyenNganh")]
    public class DaoTaoChuyenNganhController : Controller
    {
        private IDaoTaoChuyenNganhRepository daoTaoChuyenNganhRepository;

        public DaoTaoChuyenNganhController(IDaoTaoChuyenNganhRepository daoTaoChuyenNganhRepository)
        {
            this.daoTaoChuyenNganhRepository = daoTaoChuyenNganhRepository;
        }

        // GET: HopDong
        [HttpGet]
        public async Task<IEnumerable<Daotaochuyennganh>> getAll()
        {
            var list = await daoTaoChuyenNganhRepository.getAll();
            return list;
        }

        // GET: 
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            var model = await daoTaoChuyenNganhRepository.getById(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Daotaochuyennganh model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            await daoTaoChuyenNganhRepository.Create(model);

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]Daotaochuyennganh model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            model.Id = id;

            await daoTaoChuyenNganhRepository.Update(model);

            return Ok(model);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id < 1)
            {
                return NotFound();
            }

            await daoTaoChuyenNganhRepository.Delete(id);

            return new NoContentResult();
        }
    }
}