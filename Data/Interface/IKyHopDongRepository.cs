using Microsoft.AspNetCore.Mvc;
using QLNS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNS.Data.Interface
{
    public interface IKyHopDongRepository : IRepository<Kyhopdong>
    {
        //Task Update( Hopdong hopdong);
        //Task Create(Hopdong hopdong);
        Task Create(Hopdong model);
        Task Update(Hopdong model);
        Task UpdateGiaHan(Kyhopdong model);
        Task getHopDong();
        Task<IActionResult> getHopDong(int? id);
    }
}
