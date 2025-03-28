----Database đồ án quản lý nhân sự
--Create Database
create database PersonnelManagement
go

use PersonnelManagement
go

--Set format date = dd/mm/yyyy
set dateformat dmy
go

--Table 1
--Create Table ChucVu
create table ChucVu
(
	id int identity(1,1) not null,
	TenChucVu nvarchar(255),
	NgayNhan date,
	primary key(id)

)
go

--Table 2
--Create Table PhongBan
create table PhongBan
(
	id int identity(1,1) not null,
	TenPhongBan nvarchar(255),
	Mota nvarchar(max),
	primary key(id)
)
go

--Table 3
--Create table Luong
create table Luong
(
	id int identity(1,1) not null,
	SoTienLuong int,
	primary key(id),
	constraint chk_SoTienLuong check (SoTienLuong >= 0)
)
go

--Table 4
--Create table NhanVien 
create table NhanVien
(
	id int identity(1,1) not null,
	TenNhanVien nvarchar(255),
	NgaySinh date,
	DiaChi nvarchar(500),
	Que nvarchar(255),
	GioiTinh nvarchar(4),
	Email varchar(255),
	idChucVu int,
	idLuong int,
	idPhongBan int,
	primary key(id),
	constraint chk_NgaySinhNV check (NgaySinh <= dateadd(year, -16, getdate()))
)
go

--Table 5
--Create table TaiKhoan
create table TaiKhoan
(
	id int identity(1,1) not null,
	idNhanVien int,
	taiKhoan varchar(255) unique,
	matKhau varchar(255),
	primary key(id)

)
go

--Table 6
--Create table ChamCong
create table ChamCong
(
	id int identity(1,1) not null,
	NgayChamCong date,
	idNhanVien int,
	primary key(id)
)
go

--Table 7
--Create table KhenThuong
create table KhenThuong
(
	id int identity(1,1) not null,
	ngayKhenThuong date,
	SoTienThuong int,
	LyDo nvarchar(255),
	primary key(id)
)
go

--Table 8
--Create table KhenThuong_NhanVien
Create table KhenThuong_NhanVien
(
	idKhenThuong int not null,
	idNhanVien int not null,
	primary key(idKhenThuong, idNhanVien)
)
go

--Table 9
--Create table HopDongLaoDong
create table HopDongLaoDong
(
	id int identity(1,1) not null,
	NgayKy date,
	NgayBatDau date,
	NgayKetThuc date,
	idNhanVien int,
	MoTa nvarchar(max),
	primary key(id),
	constraint chk_NgayKetThuc check (NgayBatDau <= NgayKetThuc)
)
go

--Table 10
--Create table KyLuat
create table KyLuat
(
	id int identity(1,1) not null,
	NgayKyLuat date,
	NoiDungKyLuat nvarchar(255),
	LyDoKyLuat nvarchar(max),
	primary key(id)
)
go

--Table 11
--Create table KyLuat_NhanVien
Create table KyLuat_NhanVien
(
	idKyLuat int not null,
	idNhanVien int not null,
	primary key(idKyLuat, idNhanVien)
)
go

--Table 12
--Create table NghiPhep
create table NghiPhep
(
	id int identity(1,1) not null,
	NgayBatDau date,
	NgayKetThuc date,
	LyDoNghi nvarchar(500),
	LoaiNghiPhep nvarchar(50),
	idNhanVien int,
	primary key(id),
	constraint chk_NgayBatDau check(NgayBatDau<= ngayKetThuc)
)
go

--Table 13
--Create table DuAn
create table DuAn
(
	id int identity(1,1) not null,
	TenDuAn nvarchar(100),
	MoTa text,
	NgayBatDau date,
	NgayKetThuc date,
	TrangThai nvarchar(20),
	NgayTao date,
	primary key(id),
	constraint chk_NgayKetThucDuAn check (NgayBatDau <= NgayKetThuc)
)
go

--Table 14
--Create table DuAn_NhanVien
create table DuAn_NhanVien
(
	idNhanVien int not null,
	idDuAn int not null,
	VaiTroNhanVien nvarchar(100),
	NgayThamGia date,
	NgayTao date,
	primary key(idNhanVien, idDuAn)
)
go

--Table 15
--Create table DanhGiaNhanVien
Create table DanhGiaNhanVien
(
	id int identity(1,1) not null,
	DiemSo int,
	NhanXet text,
	ngayTao date,
	idNhanVien int,
	idNguoiDanhGia int,
	primary key(id),
	constraint chk_NguoiDanhGia check (idNhanVien != idNguoiDanhGia)
)
go


----Create Foreign Key constraint
--Table NhanVien
alter table NhanVien
add constraint fk_ChucVu_NhanVien foreign key(idChucVu) references ChucVu(id),
	constraint	fk_Luong_NhanVien foreign key(idLuong) references Luong(id),
	constraint	fk_PhongBan_NhanVien foreign key(idPhongBan) references PhongBan(id)
go

--Table ChamCong
alter table ChamCong
add constraint fk_NhanVien_ChamCong foreign key(idNhanVien) references NhanVien(id)
go

--Table TaiKhoan
alter table TaiKhoan
add constraint fk_NhanVien_TaiKhoan foreign key(idNhanVien) references NhanVien(id)
go

--Table NghiPhep
alter table NghiPhep
add constraint fk_NhanVien_NghiPhep foreign key(idNhanVien) references NhanVien(id)
go

--Table NhanVien_KyLuat
alter table KyLuat_NhanVien
add constraint fk_KyLuat_KLNV foreign key(idKyLuat) references KyLuat(id),
	constraint fk_NhanVien_KLNV foreign key(idNhanVien) references NhanVien(id)
go

--Table HopDongLaoDong
alter table HopDongLaoDong
add constraint fk_NhanVien_HopDongLaoDong foreign key(idNhanVien) references NhanVien(id)
go

--Table KhenThuong_NhanVien
alter table KhenThuong_NhanVien
add constraint fk_KhenThuong_KTNV foreign key(idKhenThuong) references KhenThuong(id),
	constraint fk_NhanVien_KTNV foreign key(idNhanVien) references NhanVien(id)
go

--Table DuAn_NhanVien
alter table DuAn_NhanVien
add constraint fk_DuAn_DANV foreign key(idDuAn) references DuAn(id),
	constraint fk_NhanVien_DANV foreign key(idNhanVien) references NhanVien(id)
go

--Table DanhGiaNhanVien
alter table DanhGiaNhanVien
add constraint fk_NV1_DGNV foreign key(idNhanVien) references NhanVien(id),
	constraint fk_NV2_DGNV foreign key(idNguoiDanhGia) references NhanVien(id)
go




----Chèn dữ liệu
-- Chèn dữ liệu vào bảng ChucVu
INSERT INTO ChucVu (TenChucVu, NgayNhan) VALUES
(N'Tổng Giám đốc', GETDATE()),
(N'Phó Giám đốc', GETDATE()),
(N'Giám đốc Công nghệ (CTO)', GETDATE()),
(N'Giám đốc Tài chính (CFO)', GETDATE()),
(N'Giám đốc Nhân sự (CHRO)', GETDATE()),
(N'Trưởng phòng Kỹ thuật', GETDATE()),
(N'Trưởng phòng Marketing', GETDATE()),
(N'Trưởng phòng Kinh doanh', GETDATE()),
(N'Quản lý Dự án', GETDATE()),
(N'Chuyên viên Phát triển Phần mềm', GETDATE()),
(N'Trưởng phòng An ninh mạng', GETDATE()),
(N'Trưởng phòng Nhân sự', GETDATE()),
(N'Trưởng phòng Tài chính', GETDATE()),
(N'Trưởng phòng Chăm sóc khách hàng', GETDATE()),
(N'Trưởng phòng Hành chính', GETDATE()),
(N'Nhân viên chính thức', GETDATE()),
(N'Nhân viên thực tập', GETDATE());

-- Chèn dữ liệu vào bảng PhongBan
INSERT INTO PhongBan (TenPhongBan, Mota) VALUES
('Phòng Kỹ thuật', 'Chuyên phát triển và duy trì hệ thống phần mềm, quản lý server và hạ tầng công nghệ.'),
('Phòng Sản phẩm', 'Nghiên cứu, thiết kế và phát triển sản phẩm công nghệ mới.'),
('Phòng Nhân sự', 'Quản lý tuyển dụng, đào tạo và phát triển nhân sự trong công ty.'),
('Phòng Marketing', 'Lên chiến lược tiếp thị và quảng bá sản phẩm công nghệ.'),
('Phòng Kinh doanh', 'Chăm sóc khách hàng và tìm kiếm cơ hội kinh doanh mới.'),
('Phòng Tài chính', 'Quản lý tài chính, kế toán và ngân sách công ty.'),
('Phòng Hành chính', 'Xử lý các công việc hành chính, hậu cần và quản lý văn phòng.'),
('Phòng Chăm sóc khách hàng', 'Hỗ trợ, tư vấn và giải đáp thắc mắc của khách hàng.'),
('Phòng An ninh mạng', 'Đảm bảo an toàn thông tin và bảo mật hệ thống.'),
('Phòng Nghiên cứu & Phát triển', 'Nghiên cứu công nghệ mới và phát triển giải pháp sáng tạo.');

-- Khai báo biến bảng để lưu ID lương
DECLARE @LuongIds TABLE (id INT);

-- Chèn dữ liệu vào bảng Luong và lưu ID vào biến bảng
INSERT INTO Luong (SoTienLuong)
OUTPUT INSERTED.id INTO @LuongIds
SELECT TOP 10 ABS(CHECKSUM(NEWID())) % 10000000 + 5000000
FROM master.dbo.spt_values;

-- Khai báo danh sách tỉnh thành và quận
DECLARE @TinhThanh TABLE (id INT IDENTITY(1,1), Que NVARCHAR(50));
INSERT INTO @TinhThanh VALUES
(N'Hà Nội'), (N'TP. Hồ Chí Minh'), (N'Đà Nẵng'), (N'Hải Phòng'), (N'Bình Dương'),
(N'Quảng Ninh'), (N'Huế'), (N'Cần Thơ'), (N'Bắc Ninh'), (N'Nha Trang');

DECLARE @QuanHCM TABLE (id INT IDENTITY(1,1), DiaChi NVARCHAR(100));
INSERT INTO @QuanHCM VALUES
(N'Quận 1'), (N'Quận 2'), (N'Quận 3'), (N'Quận 4'), (N'Quận 5'),
(N'Quận 7'), (N'Quận 9'), (N'Quận 10'), (N'Quận Bình Thạnh'), (N'Quận Gò Vấp');

-- Chèn dữ liệu vào bảng NhanVien
INSERT INTO NhanVien (TenNhanVien, NgaySinh, DiaChi, Que, GioiTinh, Email, idChucVu, idLuong, idPhongBan)
SELECT TOP 200 
       'NhanVien' + CAST(ROW_NUMBER() OVER (ORDER BY NEWID()) AS NVARCHAR),
       DATEADD(YEAR, -20 - (ABS(CHECKSUM(NEWID())) % 30), GETDATE()),
       (SELECT TOP 1 DiaChi FROM @QuanHCM ORDER BY NEWID()),
       (SELECT TOP 1 Que FROM @TinhThanh ORDER BY NEWID()),
       CASE WHEN ABS(CHECKSUM(NEWID())) % 2 = 0 THEN N'Nam' ELSE N'Nữ' END,
       'nhanvien' + CAST(ROW_NUMBER() OVER (ORDER BY NEWID()) AS NVARCHAR) + '@example.com',
       (SELECT TOP 1 id FROM ChucVu ORDER BY NEWID()),
       (SELECT TOP 1 id FROM @LuongIds ORDER BY NEWID()),
       (SELECT TOP 1 id FROM PhongBan ORDER BY NEWID())
FROM master.dbo.spt_values;


--USE master;
--ALTER DATABASE PersonnelManagement SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
--DROP DATABASE PersonnelManagement;