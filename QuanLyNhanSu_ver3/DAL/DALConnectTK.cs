﻿using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALConnectTK
    {
        public readonly PersonnelManagementDataContext qlns;

        public DALConnectTK() => qlns = new PersonnelManagementDataContext();

        // Lay d/s tai khoan
        public IQueryable<DTOTaiKhoan> getAllTKhoan() => qlns.TaiKhoans.Select(tk => new DTOTaiKhoan
        {
            ID = tk.id,
            IDNhanVien = tk.idNhanVien,
            TaiKhoan = tk.taiKhoan1,
            MatKhau = tk.matKhau
        });
    }
}
