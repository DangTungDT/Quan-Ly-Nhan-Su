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
	id varchar(10) not null,
	TenChucVu nvarchar(255) not null,
	primary key(id)
)
go

--Table 2
--Create Table PhongBan
create table PhongBan
(
	id varchar(10) not null,
	TenPhongBan nvarchar(255) not null,
	Mota nvarchar(255),
	primary key(id)
)
go

--Table 3
--Create table Luong
create table Luong
(
	id int identity(1,1) not null,
	SoTienLuong int not null,
	primary key(id),
	constraint chk_SoTienLuong check (SoTienLuong >= 0)
)
go

--Table 4
--Create table NhanVien 
create table NhanVien
(
	id varchar(10) not null,
	TenNhanVien nvarchar(255) not null,
	NgaySinh date,
	DiaChi nvarchar(255),
	Que nvarchar(100),
	GioiTinh nvarchar(4),
	Email varchar(100),
	idChucVu varchar(10),
	idLuong int,
	idPhongBan varchar(10),
	primary key(id),
	constraint chk_NgaySinhNV check (NgaySinh <= dateadd(year, -16, getdate()))
)
go

--Table 5
--Create table TaiKhoan
create table TaiKhoan
(
	id int identity(1,1) not null,
	idNhanVien varchar(10),
	taiKhoan varchar(10) unique,
	matKhau varchar(255),
	primary key(id),
	constraint chk_taiKhoan check (taiKhoan = idNhanVien)

)
go

--Table 6
--Create table ChamCong
create table ChamCong
(
	id int identity(1,1) not null,
	NgayChamCong date,
	idNhanVien varchar(10),
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
	idNhanVien varchar(10) not null,
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
	idNhanVien varchar(10),
	MoTa nvarchar(255),
	primary key(id),
	constraint chk_NgayKetThuc check (NgayBatDau <= NgayKetThuc)
)
go

--Table 10
--Create table KyLuat
create table KyLuat
(
	id int identity(1,1) not null,
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
	idNhanVien varchar(10) not null,
	NgayKyLuat date,
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
	idNhanVien varchar(10),
	primary key(id),
	constraint chk_NgayBatDau check(NgayBatDau<= ngayKetThuc)
)
go

--Table 13
--Create table DuAn
create table DuAn
(
	id varchar(10) not null,
	TenDuAn nvarchar(100) not null,
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
	idNhanVien varchar(10) not null,
	idDuAn varchar(10) not null,
	VaiTroNhanVien nvarchar(100) not null,
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
	idNhanVien varchar(10),
	idNguoiDanhGia varchar(10),
	primary key(id),
	constraint chk_NguoiDanhGia check (idNhanVien != idNguoiDanhGia)
)
go


----Create Foreign Key constraint

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




------Chèn dữ liệu
---- Chèn dữ liệu vào bảng ChucVu
--INSERT INTO ChucVu (TenChucVu, NgayNhan) VALUES
--(N'Tổng Giám đốc', GETDATE()),


insert into Luong(SoTienLuong) values
(2000000),
(5000000),
(7000000),
(15000000),
(30000000),
(50000000)
go

insert into ChucVu(id, TenChucVu) values
('TTS',N'Thực tập sinh'),
('NVCT01',N'Nhân viên chính thức'),
('NVCT02',N'Nhân viên chính thức lâu năm'),
('TPKD',N'Trưởng phòng kinh doanh'),
('TPKT',N'Trưởng phòng kế toán'),
('TPCNTT',N'Trưởng phòng công nghệ thông tin'),
('TPMKT',N'Trưởng phòng Marketing'),
('TPNS',N'Trưởng phòng nhân sự'),
('GD',N'Giám đốc công ty'),
('PGD', N'Phó giám đốc công ty')
go

insert into KyLuat(NoiDungKyLuat, LyDoKyLuat) values
(N'Trừ 200k vào tiền lương', N'Đi trễ' ),
(N'Trừ 500k vào tiền lương', N'Đi trễ quá 3 lần trong tháng' ),
(N'Trừ 500k vào tiền lương', N'Nghỉ không xin phép' ),
(N'Sa thải', N'Đi trễ quá 5 lần trong tháng' ),
(N'Sa thải', N'Không đạt KPI 5 tháng liên tục' ),
(N'Sa thải', N'Phá hoại vật chất công ty' )
go

insert into PhongBan(id, TenPhongBan, Mota) values
('PBCNTT', N'Phòng ban công nghệ thông tin', N'Phòng thực hiện các công việc sản xuất ra các phần mềm'),
('PBKD', N'Phong ban kinh doanh', N'Phòng ban thực hiện các công tác liên quan đến kinh doanh'),
('PBMKT', N'Phòng ban Marketing', N'Phòng thực hiện công tác marketing, quảng cáo cho công ty'),
('PBNS', N'Phòng ban nhân sự', N'Phòng quản lý các thông tin và tự hiện nghiệp vụ nhân sự'),
('PBKT', N'Phòng ban kế toán', N'Phòng thực hiện các nghiệp vụ kế toán'),
('HDQT', N'Hội đồng quản trị', N'Các cổ đông của công ty')
go

--select * from PhongBan
--select * from ChucVu
--select * from NhanVien
insert into NhanVien(id,TenNhanVien, NgaySinh, DiaChi, Que, GioiTinh, Email, idChucVu, idLuong, idPhongBan) values
('TPCNTT01', N'Đặng Thanh Tùng', '20/08/2005',N'Phường Linh Tây thành phố Thủ Đức thành phố Hồ Chí Minh', N'Bà Rịa Vũng Tàu', 'Nam', 'dangthanhtung@gmail.com', 'TPCNTT', '4', 'PBCNTT'),
('NVCNTT02', N'Lý Thị Kim Ngân', '1/1/1998',N'thành phố Thủ Đức thành phố Hồ Chí Minh', N'Hồ Chí Minh', 'Nu', 'lythikimngan@gmail.com', 'NVCT02', '3', 'PBCNTT'),
('NVCNTT03', N'Nguyễn Thành Tuấn', '1/1/2005',N'thành phố Thủ Đức thành phố Hồ Chí Minh', N'Gia Lai', 'Nam', 'nguyenthanhtuan@gmail.com', 'NVCT01', '2', 'PBCNTT'),
('NVCNTT04', N'Ngô Tấn Lộc', '11/11/2004',N'quận Bình Thạnh thành phố Hồ Chí Minh', N'Đồng Tháp', 'Nam', 'ngotanloc@gmail.com', 'TTS', '1', 'PBCNTT'),
('TPKD01', N'Đỗ Kim Quyên', '23/12/2005',N'Phường Linh Tây thành phố Thủ Đức thành phố Hồ Chí Minh', N'Bà Rịa Vũng Tàu', 'Nu', 'dokimquyen@gmail.com', 'TPKD', '4', 'PBKD'),
('NVKD01', N'Nguyễn Kỳ Duyên', '12/4/2005',N'quận Bình Thạnh thành phố Hồ Chí Minh', N'Đồng Nai', 'Nu', 'nguyenkyduyen@gmail.com', 'NVCT01', '2', 'PBKD'),
('NVKD02', N'Võ Kim Ngân', '5/5/2005',N'quận 2 thành phố Hồ Chí Minh', N'Bến tre', 'Nu', 'vokimngan@gmail.com', 'NVCT02', '3', 'PBKD'),
('NVKD03', N'Nguyễn Nguyên Pháp', '9/11/2002',N'thành phố Thủ Đức thành phố Hồ Chí Minh', N'Hà Nội', 'Nam', 'nguyennguyenphap@gmail.com', 'TTS', '1', 'PBKD'),
('TPMKT01', N'Nguyễn Hữu Điền', '21/12/2005',N'quận 3 thành phố Hồ Chí Minh', N'Bà Rịa Vũng Tàu', 'Nam', 'nguyenhuudien@gmail.com', 'TPMKT', '4', 'PBMKT'),
('NVMKT01', N'Trần Thị Hòa', '14/3/2005',N'quận 5 thành phố Hồ Chí Minh', N'An Giang', 'Nu', 'tranthihoa@gmail.com', 'NVCT02', '3', 'PBMKT'),
('NVMKT02', N'Lê Đăng Tiền', '6/3/2005',N'thành phố Thủ Đức thành phố Hồ Chí Minh', N'Bình Định', 'Nam', 'ledangtien@gmail.com', 'NVCT01', '2', 'PBMKT'),
('NVMKT03', N'Phan Lê Phi Thanh', '7/7/2002',N'quận 1 thành phố Hồ Chí Minh', N'An Giang', 'Nam', 'phanlephithanh@gmail.com', 'TTS', '1', 'PBMKT'),
('TPNS01', N'Nguyễn Văn Thanh', '12/8/2004',N'quận Bình Thạnh thành phố Hồ Chí Minh', N'Cà Mau', 'Nam', 'nguyenvanthanh@gmail.com', 'TPNS', '4', 'PBNS'),
('NVNS01', N'Trương Lê Nhật Huy', '5/2/2004',N'quận Bình Thạnh thành phố Hồ Chí Minh', N'Hồ Chí Minh', 'Nam', 'truonglenhathuy@gmail.com', 'NVCT02', '3', 'PBNS'),
('NVNS02', N'Nguyễn Đông Huy', '4/3/2004',N'quận Bình Thạnh thành phố Hồ Chí Minh', N'Bà Rịa Vũng Tàu', 'Nam', 'nguyendonghuy@gmail.com', 'NVCT01', '2', 'PBNS'),
('NVNS03', N'Nguyễn Thị Như Quỳnh', '21/9/2004',N'quận Bình Thạnh thành phố Hồ Chí Minh', N'Bình Phước', 'Nu', 'nguyenthinhuquynh@gmail.com', 'TTS', '1', 'PBNS'),
('TPKT01', 'Phan Gia Phước', '21/3/2004',N'quận Bình Thạnh thành phố Hồ Chí Minh', N'Long An', 'Nam', 'phangiaphuoc@gmail.com', 'TPKT', '4', 'PBKT'),
('NVKT01', N'Nguyễn Huy Hoàng', '21/7/2001',N'quận Bình Thạnh thành phố Hồ Chí Minh', N'Vĩnh Long', 'Nam', 'nguyenhuyhoang@gmail.com', 'NVCT02', '3', 'PBKT'),
('NVKT02', N'Nguyễn Đức Hoàng', '1/12/2003',N'quận Bình Thạnh thành phố Hồ Chí Minh', N'Đà Nẵng', 'Nam', 'hoangnd@gmail.com', 'NVCT01', '2', 'PBKT'),
('NVKT03', N'Nông Lương Ngọc Nhi', '12/8/2002',N'quận Bình Thạnh thành phố Hồ Chí Minh', N'Tây Ninh', 'Nu', 'nongluongngocnhi@gmail.com', 'TTS', '1', 'PBKT'),
('GDHDQT01', N'Đặng Lê Nguyên Vũ', '11/12/1970',N'quận Bình Thạnh thành phố Hồ Chí Minh', N'Bình Thuận', 'Nam', 'danglenguyenvu@gmail.com', 'GD', '6', 'HDQT'),
('PGDHDQT01', N'Hoàng Nam Tiến', '11/12/1976',N'quận Bình Thạnh thành phố Hồ Chí Minh', N'Hà Nội', 'Nam', 'hoangnamtien@gmail.com', 'PGD', '5', 'HDQT')
go

------Create Foreign Key constraint
----Table PhongBan
--alter table PhongBan
--add constraint fk_NhanVien_PhongBan foreign key(idTruongPhong) references NhanVien(id)
--go

--Chèn dữ liệu bảng DuAN
insert into DuAn (id, TenDuAn, MoTa, NgayBatDau, NgayKetThuc, TrangThai, NgayTao) values
('PMBD01',N'Dự án phần mềm Bình Dương 1',N'Dự án làm về phần mêm cho 1 công ty ở Bình Dương', '1/1/2025','1/5/2025',N'Đang thực hiện', '10/4/2025'),
('PMBD02',N'Dự án phần mềm Bình Dương 2',N'Dự án làm về phần mêm cho 1 công ty ở Bình Dương' , '1/1/2025','1/2/2025',N'Hoàn thành', '10/3/2025'),
('PMBRVT01',N'Phần mềm quản lý khách sạn Bà Rịa Vũng Tàu',N'Dự án làm về phần mêm cho 1 công ty ở Vũng Tàu' , '1/5/2025','1/10/2025',N'Chưa thực hiện', '10/4/2025'),
('PMBRVT02',N'Phần mềm đèn tín hiệu khách sạn Bà Rịa Vũng Tàu',N'Dự án làm về phần mêm cho 1 công ty ở Vũng Tàu' , '1/1/2025','1/5/2025',N'Đang thực hiện', '10/3/2025'),
('PMBRVT03',N'Phần mềm quản lý nhân sự khách sạn Bà Rịa Vũng Tàu',N'Dự án làm về phần mêm cho 1 công ty ở Vũng Tàu' , '1/1/2025','1/2/2025',N'Hoàn thành', '10/2/2025'),
('PMHN01',N'Phần mềm quản lý nhà thông minh Hà Nội',N'Dự án làm về phần mêm cho 1 công ty ở Vũng Tàu' , '1/1/2025','1/10/2025',N'Đang thực hiện', '10/4/2025')
GO

insert into DuAn_NhanVien(idNhanVien, idDuAn, VaiTroNhanVien, NgayThamGia, NgayTao) values
('TPMKT01', 'PMBD01', N'nhân viên dự án', '1/1/2025', '11/4/2025'),
('TPCNTT01', 'PMBD01', N'quản lý dự án', '1/1/2025', '11/4/2025'),
('TPCNTT01', 'PMBRVT02', N'quản lý dự án', '1/1/2025', '11/3/2025'),
('NVKT02', 'PMBRVT02', N'nhân viên dự án', '1/1/2025', '11/3/2025'),
('NVNS03', 'PMBRVT02', N'nhân viên dự án', '1/1/2025', '11/3/2025'),
('NVCNTT03', 'PMBRVT02', N'nhân viên dự án', '1/1/2025', '11/3/2025'),
('TPKT01', 'PMHN01', N'quản lý dự án', '1/1/2025', '11/4/2025'),
('NVMKT03', 'PMHN01', N'nhân viên dự án', '1/1/2025', '11/4/2025'),
('TPKD01', 'PMHN01', N'nhân viên dự án', '1/1/2025', '11/4/2025'),
('NVCNTT02', 'PMHN01', N'nhân viên dự án', '1/1/2025', '11/4/2025')
go

insert into DanhGiaNhanVien(DiemSo, NhanXet, ngayTao, idNhanVien, idNguoiDanhGia) values
(10, N'Nhân viên tốt', '2/2/2025', 'NVMKT03', 'TPMKT01'),
(10, N'Cần tự tin hơn', '2/2/2025', 'NVMKT03', 'TPMKT01'),
(10, N'Ít giao tiếp', '2/2/2025', 'NVMKT03', 'TPMKT01'),
(10, N'Nhân viên tốt', '2/2/2025', 'NVMKT03', 'TPMKT01'),
(10, N'Nhân viên tốt', '2/2/2025', 'NVMKT03', 'TPMKT01')
go

insert into NghiPhep(NgayBatDau, NgayKetThuc, LyDoNghi, LoaiNghiPhep, idNhanVien) values
('13/04/2025','13/04/2025',N'Bị bệnh', N'Không nhận lương', 'NVKT03'),
('18/04/2025','19/04/2025',N'Có việc gia đình', N'Vẫn nhận lương', 'NVMKT01'),
('3/04/2025','5/04/2025',N'Có việc gia đình', N'Không nhận lương', 'TPCNTT01')
go

insert into KhenThuong(ngayKhenThuong, SoTienThuong, LyDo) values
('25/12/2024',10000000, 'Thưởng tết'),
('25/12/2024',20000000, 'Thưởng đạt KPI năm'),
('25/12/2024',50000000, 'Thưởng vượt KPI năm'),
('25/12/2024',100000000, 'Thưởng nhân viên xuất sắc nhất năm'),
('25/12/2024',200000000, 'Thưởng nhân viên kiếm lợi nhuật nhiều nhất ')
go

insert into KhenThuong_NhanVien(idKhenThuong, idNhanVien) values
('1','TPCNTT01'),
('3','NVKT03'),
('1','TPMKT01'),
('3','TPCNTT01')
go

insert into ChamCong(NgayChamCong, idNhanVien) values
('1/4/2025','TPCNTT01'),
('2/4/2025','TPCNTT01'),
('3/4/2025','TPCNTT01'),
('4/4/2025','TPCNTT01'),
('5/4/2025','TPCNTT01'),
('6/4/2025','TPCNTT01'),
('6/4/2025','NVKT01'),
('1/4/2025','NVKT01'),
('2/4/2025','NVKT01'),
('3/4/2025','NVKT01'),
('4/4/2025','NVKT01'),
('5/4/2025','NVKT01')
go

insert into TaiKhoan(idNhanVien, taiKhoan, matKhau) values
('TPCNTT01','TPCNTT01','1'),
('NVCNTT02','NVCNTT02','1'),
('NVCNTT03','NVCNTT03','1'),
('GDHDQT01','GDHDQT01','1')
go

insert into KyLuat_NhanVien(idKyLuat, idNhanVien, NgayKyLuat) values 
('1','TPCNTT01', '13/04/2025'),
('2','NVCNTT03', '13/04/2025'),
('1','NVCNTT03', '13/04/2025'),
('2','TPCNTT01', '13/04/2025')
go

insert into HopDongLaoDong(NgayKy, NgayBatDau, NgayKetThuc, idNhanVien, MoTa) values
('1/1/2025', '15/1/2025', '15/1/2028', 'TPCNTT01', N'Hợp đồng có thời hạn'),
('1/1/2025', '15/1/2025', '15/1/2028', 'NVCNTT02', N'Hợp đồng có thời hạn'),
('1/1/2025', '15/1/2025', '15/1/2028', 'NVCNTT03', N'Hợp đồng có thời hạn'),
('1/1/2025', '15/1/2025', '15/1/2028', 'TPCNTT01', N'Hợp đồng có thời hạn')
go

--USE master;
--ALTER DATABASE PersonnelManagement SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
--DROP DATABASE PersonnelManagement;
