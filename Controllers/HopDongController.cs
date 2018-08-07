using Microsoft.AspNetCore.Mvc;
using QLNS.Data.Interface;
using QLNS.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;

namespace QLNS.Controllers
{
    [Route("api/[controller]")]
    public class HopDongController : Controller
    {
        private IHopDongRepository hopDongRepository;

        public HopDongController(IHopDongRepository hopDongRepository)
        {
            this.hopDongRepository = hopDongRepository;
        }

        // GET: HopDong
        [HttpGet]
        public async Task<IEnumerable<Hopdong>> getAll()
        {
            var DanhSachHopDong = await hopDongRepository.getAll();
            return DanhSachHopDong;
        }

        // GET: 
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            var HopDong = await hopDongRepository.getById(id);

            if (HopDong == null)
            {
                return NotFound(); // 404 - Các tài nguyên hiện tại không được tìm thấy
            }

            return Ok(HopDong); // 200 - Xử lý thành công và trả về đối tượng đã xử lý
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Hopdong hopdong)
        {
            if (hopdong == null)
            {
                return BadRequest(); // 400 - Xử lý lỗi
            }

            await hopDongRepository.Create(hopdong);

            return Ok(hopdong); // 200 - Xử lý thành công và trả về đối tượng đã xử lý
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody]Hopdong hopdong)
        {
            if (hopdong == null || hopdong.Id == 0)
            {
                return BadRequest(); // 400
            }

            await hopDongRepository.Update(hopdong);

            return Ok(hopdong); // 200 - Xử lý thành công và trả về đối tượng đã xử lý

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id < 1)
            {
                return NotFound(); // 404 - 
            }

            await this.hopDongRepository.Delete(id);

            return new NoContentResult(); // 204 - Xử lý thành công nhưng không trả về g2
        }
    }
}