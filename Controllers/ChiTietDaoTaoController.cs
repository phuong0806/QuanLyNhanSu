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
    [Route("api/ChiTietDaoTao")]
    public class ChiTietDaoTaoController : Controller
    {
        private IChiTietDaoTapRepository chiTietDaoTaoRepository;

        public ChiTietDaoTaoController(IChiTietDaoTapRepository chiTietDaoTaoRepository)
        {
            this.chiTietDaoTaoRepository = chiTietDaoTaoRepository;
        }

        // GET: HopDong
        [HttpGet]
        public async Task<IEnumerable<ChitietDaotao>> getAll()
        {
            var list = await chiTietDaoTaoRepository.getAll();
            return list;
        }

        // GET: 
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            var model = await chiTietDaoTaoRepository.getById(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]ChitietDaotao model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            await chiTietDaoTaoRepository.Create(model);

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]ChitietDaotao model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            model.Id = id;

            await chiTietDaoTaoRepository.Update(model);

            return Ok(model);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id < 1)
            {
                return NotFound();
            }

            await chiTietDaoTaoRepository.Delete(id);

            return new NoContentResult();
        }
    }
}