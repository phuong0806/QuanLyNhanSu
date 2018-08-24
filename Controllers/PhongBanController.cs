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
    [Route("api/PhongBan")]
    public class PhongBanController : Controller
    {
        private IPhongBanRepository phongBanRepository;

        public PhongBanController(IPhongBanRepository phongBanRepository)
        {
            this.phongBanRepository = phongBanRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Phongban>> getAll()
        {
            var list = await phongBanRepository.getAll();
            return list;
        }

        // GET: 
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            var model = await phongBanRepository.getById(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Phongban model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            await phongBanRepository.Create(model);

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]Phongban model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            model.Id = id;

            await phongBanRepository.Update(model);

            return Ok(model);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id < 1)
            {
                return NotFound();
            }

            await phongBanRepository.Delete(id);

            return new NoContentResult();
        }
    }
}