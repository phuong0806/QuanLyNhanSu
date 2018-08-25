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
    [Route("api/NhanVien")]
    public class NhanVienController : Controller
    {
        private INhanVienRepository nhanVienRepository;

        public NhanVienController(INhanVienRepository nhanVienRepository)
        {
            this.nhanVienRepository = nhanVienRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Nhanvien>> getAll()
        {
            var list = await nhanVienRepository.getAll();
            return list;
        }

        // GET: 
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            var model = await nhanVienRepository.getById(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Nhanvien model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            await nhanVienRepository.Create(model);

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]Nhanvien model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            model.Id = id;

            await nhanVienRepository.Update(model);

            return Ok(model);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id < 1)
            {
                return NotFound();
            }

            await nhanVienRepository.Delete(id);

            return new NoContentResult();
        }
    }
}