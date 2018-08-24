using Microsoft.AspNetCore.Mvc;
using QLNS.Data.Interface;
using QLNS.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Authorization;

namespace QLNS.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class HopDongController : Controller
    {
        private IHopDongRepository hopDongRepository;
        public HopDongController(IHopDongRepository hopDongRepository)
        {
            this.hopDongRepository = hopDongRepository;
        }
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
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
            //if (hopdong == null)
            //{
            //    return BadRequest(); // 400 - Xử lý lỗi
            //}

            await hopDongRepository.Create(hopdong);

            return Ok(hopdong); // 200 - Xử lý thành công và trả về đối tượng đã xử lý
        }
        //[Route("Update")]
        //[HttpPost]
        //public async Task<IActionResult> Update([FromForm] Hopdong hopdong)
        //{
        //    if (hopdong == null || hopdong.Id == 0)
        //    {
        //        return BadRequest(); // 400
        //    }

        //    await hopDongRepository.Update(hopdong);

        //    return Ok(hopdong); // 200 - Xử lý thành công và trả về đối tượng đã xử lý

        //}
        /// <summary>
        /// 

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]Hopdong hopdong)
        {
            //if (id != hopdong.Id)
            //{
            //    return BadRequest();
            //}

            hopdong.Id = id;

            await hopDongRepository.Update(hopdong);

            return Ok(hopdong); // 200 - Xử lý thành công và trả về đối tượng đã xử lý

        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id < 1)
            {
                return NotFound(); // 404 - 
            }

            await this.hopDongRepository.Delete(id);

            return Json("{\"code\":1}"); // 204 - Xử lý thành công nhưng không trả về g2
        }
    }
}