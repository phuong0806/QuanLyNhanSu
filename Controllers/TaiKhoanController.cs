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
        private ITaiKhoanRepository taiKhoanRepository;

        public TaiKhoanController(ITaiKhoanRepository taiKhoanRepository)
        {
            this.taiKhoanRepository = taiKhoanRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPut]
        public async Task<int> Login([FromBody]LoginModel loginModel)
        {
            var user = await taiKhoanRepository.getUser(loginModel.username, loginModel.password);

            return (checkUserLogin(user));
        }

        public int checkUserLogin(Taikhoan user)
        {
            // Sai tài khoản hoặc mật khẩu
            if (user == null)
            {
                return 0;
            }

            // Tài khoản khóa
            if (user.Khoa == "0")
            {
                return 1;
            }

            return 2;
        }
    }
}