----Database đồ án quản lý nhân sự
--Create Database
create database PersonnelManagement
go

use PersonnelManagement
go

--Set format date = dd/mm/yyyy
set dateformat dmy
go

--Create Table ChucVu
create table ChucVu
(
	id int identity(1,1) not null,
	TenChucVu nvarchar(255),
	NgayNhan date,
	primary key(id)

)
go

--Create Table PhongBan
create table PhongBan
(
	id int identity(1,1) not null,
	TenPhongBan nvarchar(255),
	Mota nvarchar(max),
	primary key(id)
)
go

--Create table Luong
create table Luong
(
	id int identity(1,1) not null,
	SoTienLuong int,
	primary key(id),
	constraint chk_SoTienLuong check (SoTienLuong >= 0)
)
go

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

--Create table ChamCong
create table ChamCong
(
	id int identity(1,1) not null,
	NgayChamCong date,
	idNhanVien int,
	primary key(id)
)
go

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

--Create table KhenThuong_NhanVien
Create table KhenThuong_NhanVien
(
	idKhenThuong int not null,
	idNhanVien int not null,
	primary key(idKhenThuong, idNhanVien)
)
go

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

--Create table KyLuat_NhanVien
Create table KyLuat_NhanVien
(
	idKyLuat int not null,
	idNhanVien int not null,
	primary key(idKyLuat, idNhanVien)
)
go

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


