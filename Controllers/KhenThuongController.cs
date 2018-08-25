﻿using System;
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
    [Route("api/KhenThuong")]
    public class KhenThuongController : Controller
    {
        private readonly IKhenThuongRepository _context;

        public KhenThuongController(IKhenThuongRepository context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Khenthuong>> getAll()
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
        public async Task<IActionResult> Create([FromBody]Khenthuong model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            await _context.Create(model);

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]Khenthuong model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            model.Id = id;

            await _context.Update(model);

            return Ok(model);

        }

        [HttpDelete("{id}")]
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