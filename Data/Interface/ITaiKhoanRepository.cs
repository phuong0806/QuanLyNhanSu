using QLNS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNS.Data.Interface
{
    public interface ITaiKhoanRepository : IRepository<Taikhoan>
    {
        Task<Taikhoan> getUser(string username, string password);
    }
}
