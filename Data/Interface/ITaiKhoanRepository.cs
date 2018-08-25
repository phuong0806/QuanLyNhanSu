using QLNS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNS.Data.Interface
{
    public interface ITaiKhoanRepository : IRepository<Taikhoan>
    {
        Task<Taikhoan> Authenticate(string username, string password);
        Task ChangeStatus(string username, string status, string reason);
    }
}
