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
    [Route("api/DonVi")]
    public class DonViController : Controller
    {
        private IDonViRepository donViRepository;

        public DonViController(IDonViRepository donViRepository)
        {
            this.donViRepository = donViRepository;
        }

        // GET: HopDong
        [HttpGet]
        public async Task<IEnumerable<Donvi>> getAll()
        {
            var list = await donViRepository.getAll();
            return list;
        }

        // GET: 
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            var model = await donViRepository.getById(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Donvi model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            await donViRepository.Create(model);

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]Donvi model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            model.Id = id;

            await donViRepository.Update(model);

            return Ok(model);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id < 1)
            {
                return NotFound();
            }

            await donViRepository.Delete(id);

            return new NoContentResult();
        }
    }
}