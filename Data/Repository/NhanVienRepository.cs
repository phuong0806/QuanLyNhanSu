using Dapper;
using QLNS.Data.Interface;
using QLNS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNS.Data.Repository
{
    public class NhanVienRepository : Repository<Nhanvien>, INhanVienRepository
    {
        public async Task Create(Nhanvien entity)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@hoten", entity.Hoten);
            dynamicParameters.Add("@ngaysinh", entity.Ngaysinh);
            dynamicParameters.Add("@noisinh", entity.Noisinh);
            dynamicParameters.Add("@gioitinh", entity.Gioitinh);
            dynamicParameters.Add("@diachi", entity.Diachi);
            dynamicParameters.Add("@sdt", entity.Sdt);
            dynamicParameters.Add("@diachi_hientai", entity.DiachiHientai);
            dynamicParameters.Add("@email", entity.Email);
            dynamicParameters.Add("@id_chucvu", entity.IdChucvu);
            dynamicParameters.Add("@id_donvi", entity.IdDonvi);
            dynamicParameters.Add("@id_ taikhoan", entity.IdTaikhoan);
            dynamicParameters.Add("@dateadd", DateTime.Now);
            dynamicParameters.Add("@useradd", 1);

            await QueryFirstOrDefault("usp_NhanVienInsert", dynamicParameters);
        }
        public async Task Delete(int? id)
        {
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@id", id);

            await Execute("usp_NhanVienDelete", dynamicParameters);
        }

        public async Task<IEnumerable<Nhanvien>> getAll()
        {
            return await Query("usp_NhanVienGetAll");
        }

        public async Task<Nhanvien> getById(int? id)
        {
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@id", id);

            return await QueryFirstOrDefault("usp_NhanVienGet", dynamicParameters);
        }

        public async Task Update(Nhanvien entity)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@id", entity.Id);
            dynamicParameters.Add("@hoten", entity.Hoten);
            dynamicParameters.Add("@ngaysinh", entity.Ngaysinh);
            dynamicParameters.Add("@noisinh", entity.Noisinh);
            dynamicParameters.Add("@gioitinh", entity.Gioitinh);
            dynamicParameters.Add("@diachi", entity.Diachi);
            dynamicParameters.Add("@sdt", entity.Sdt);
            dynamicParameters.Add("@diachi_hientai", entity.DiachiHientai);
            dynamicParameters.Add("@email", entity.Email);
            dynamicParameters.Add("@id_chucvu", entity.IdChucvu);
            dynamicParameters.Add("@id_donvi", entity.IdDonvi);
            dynamicParameters.Add("@id_ taikhoan", entity.IdTaikhoan);
            dynamicParameters.Add("@dateedit", DateTime.Now);
            dynamicParameters.Add("@useredit", 1);

            await Execute("usp_NhanVienUpdate", dynamicParameters);
        }
    }
}
