using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLNS.Data.Interface;
using QLNS.Model;
using Dapper;
using Microsoft.AspNetCore.Authorization;

namespace QLNS.Controllers
{
    [Produces("application/json")]
    [Route("api/ThanNhan")]
    public class ThanNhanController : Controller
    {
        private IThanNhanRepository thanNhanRepository;

        public ThanNhanController(IThanNhanRepository thanNhanRepository)
        {
            this.thanNhanRepository = thanNhanRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Thannhan>> getAll()
        {
            var list = await thanNhanRepository.getAll();
            return list;
        }

        // GET: 
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            var model = await thanNhanRepository.getById(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Thannhan model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            await thanNhanRepository.Create(model);

            return Ok(model);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, [FromBody]Thannhan model)
        {
            //if (id != model.Id)
            //{
            //    return BadRequest();
            //}

            model.Id = id;

            await thanNhanRepository.Update(model);

            return Ok(model);

        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id < 1)
            {
                return NotFound();
            }

            await thanNhanRepository.Delete(id);

            return new NoContentResult();
        }
    }
}