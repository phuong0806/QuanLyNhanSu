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
    [Route("api/LoaiDaoTao")]
    public class LoaiDaoTaoController : Controller
    {
        private ILoaiDaoTaoRepository loaiDaoTaoRepository;

        public LoaiDaoTaoController(ILoaiDaoTaoRepository loaiDaoTaoRepository)
        {
            this.loaiDaoTaoRepository = loaiDaoTaoRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<LoaiDaotao>> getAll()
        {
            var list = await loaiDaoTaoRepository.getAll();
            return list;
        }

        // GET: 
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            var model = await loaiDaoTaoRepository.getById(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Loaidaotao model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            await loaiDaoTaoRepository.Create(model);

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]Loaidaotao model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            model.Id = id;

            await loaiDaoTaoRepository.Update(model);

            return Ok(model);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id < 1)
            {
                return NotFound();
            }

            await loaiDaoTaoRepository.Delete(id);

            return new NoContentResult();
        }
    }
}