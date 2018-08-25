using Microsoft.AspNetCore.Mvc;
using QLNS.Data.Interface;
using QLNS.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Authorization;


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
            var model = await hopDongRepository.getById(id);

            if (model == null)
            {
                return NotFound(); 
            }

            return Ok(model);
        }
       

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Hopdong model)
        {

            if (model == null)
            {
                return BadRequest();
            }


            await hopDongRepository.Create(model);

            return Ok(model); 
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

        
        public async Task<IActionResult> Update(int id,[FromBody]Hopdong model)
        {
            //if (id != model.Id)
            //{
            //    return BadRequest();
            //}


            model.Id = id;

            await hopDongRepository.Update(model);

            return Ok(model);

        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id < 1)
            {
                return NotFound(); 
            }

            await hopDongRepository.Delete(id);


           return Json("{\"code\":1}"); // 204 - Xử lý thành công nhưng không trả về g2

           // return new NoContentResult(); 

        }
    }
}