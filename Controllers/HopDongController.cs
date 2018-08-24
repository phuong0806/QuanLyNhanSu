using Microsoft.AspNetCore.Mvc;
using QLNS.Data.Interface;
using QLNS.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLNS.Controllers
{
    [Produces("application/json")]
    [Route("api/HopDong")]
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
                return NotFound(); 
            }

            return Ok(HopDong);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Hopdong hopdong)
        {
            if (hopdong == null)
            {
                return BadRequest();
            }

            await hopDongRepository.Create(hopdong);

            return Ok(hopdong); 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,[FromBody]Hopdong hopdong)
        {
            if (id != hopdong.Id)
            {
                return BadRequest();
            }

            hopdong.Id = id;

            await hopDongRepository.Update(hopdong);

            return Ok(hopdong);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id < 1)
            {
                return NotFound(); 
            }

            await this.hopDongRepository.Delete(id);

            return new NoContentResult(); 
        }
    }
}