using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLNS.Data.Interface;
using QLNS.Data.User;
using QLNS.Model;

namespace QLNS.Controllers
{
    [Produces("application/json")]
    [Route("api/TaiKhoan")]
    public class TaiKhoanController : Controller
    {
        private readonly ITaiKhoanRepository _context;

        public TaiKhoanController(ITaiKhoanRepository context)
        {
            _context = context;
        }

        [HttpPut]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return BadRequest();

            var user = await _context.Authenticate(username, password);

            if (user == null)
                return BadRequest();

            return Ok(user);
        }

        [HttpGet]
        public async Task<IEnumerable<Taikhoan>> getAll()
        {
            var list = await _context.getAll();
            return list;
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
        public async Task<IActionResult> Create([FromBody]Taikhoan model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            await _context.Create(model);

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]Taikhoan model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            model.Id = id;

            await _context.Update(model);

            return Ok(model);

        }

        [Route("status")]
        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeStatus(int id, string status, string reason = "")
        {
            var user = await _context.getById(id);

            if (user == null)
                return BadRequest();

            await _context.ChangeStatus(user.Taikhoan1, changeStatus(status), reason);

            return new NoContentResult();
        }


        private string changeStatus(string status)
        {
            // 0 = active
            // 1 = lock
            if (status == "0")
                return "1";
            return "0";
        }

        [HttpDelete("status")]
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