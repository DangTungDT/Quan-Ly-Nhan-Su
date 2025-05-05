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
	SoTienLuong decimal(18,2) default 0,
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
	MoTa ntext,
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
	NhanXet ntext,
	ngayTao date,
	idNhanVien varchar(10),
	idNguoiDanhGia varchar(10),
	primary key(id),
	constraint chk_NguoiDanhGia check (idNhanVien != idNguoiDanhGia)
)
go

--Table 16
--Create table ChiTietLuong
Create table ChiTietLuong
(
	id int identity(1,1) not null,
	kyNhanLuong date,
	soGioCongChuan decimal(8,2) default 208,
	luongCoBan decimal(18,2) default 0,
	donGiaTangCa decimal(18,2) not null default 50000,
	gioTangCa decimal(5,2) not null default 0,
	phuCap decimal(18,2) default 0,
	tienBiTru decimal(18,2) default 0,
	tongThuNhap as (luongCoBan + (donGiaTangCa * gioTangCa) +phuCap) PERSISTED,
	thucLanh as ((luongCoBan + (donGiaTangCa * gioTangCa) +phuCap) - tienBiTru) PERSISTED,
	ngayNhanLuong date not null default getdate(),
	ghiChu nvarchar(255),
	idLuong int,
	idNhanVien varchar(10),
)
----Create Foreign Key constraint
--Table ChiTietLuong
alter table ChiTietLuong
add constraint fk_Luong_ChiTietLuong foreign key(idLuong) references Luong(id),
	constraint fk_NhanVien_ChiTietLuong foreign key(idNhanVien) references NhanVien(id)
go

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

----Code Chat gpt
('NVCNTT05', N'Nguyễn Văn An', '21/03/1990',N'12 Lý Thường Kiệt, Hà Nội', N'Bắc Ninh', 'Nam', '	nguyenvanan1@gmail.com', 'NVCT02', '3', 'PBCNTT'),
('NVCNTT06', N'Trần Thị Bích Ngọc', '15/07/1988',N'45 Nguyễn Huệ, TP. HCM', N'Tiền Giang', 'Nu', 'tranthibichngoc2@gmail.com', 'NVCT01', '2', 'PBCNTT'),
('NVCNTT07', N'Lê Hoàng Phúc', '03/11/1995',N'89 Pasteur, Đà Nẵng', N'Quảng Nam', 'Nam', 'lehoangphuc3@gmail.com', 'TTS', '1', 'PBCNTT'),
('NVCNTT08', N'Phạm Thị Thu Hà', '12/01/1992',N'77 Hai Bà Trưng, Cần Thơ', N'Hậu Giang', 'Nu', 'phamthithuha4@gmail.com', 'NVCT02', '3', 'PBCNTT'),
('NVCNTT09', N'Đỗ Minh Quang', '29/9/1987',N'100 Trần Phú, Hải Phòng', N'Hải Dương', 'Nam', 'dominhquang5@gmail.com', 'NVCT01', '2', 'PBCNTT'),
('NVCNTT010', N'Nguyễn Văn A', '15/05/1990',N'10 Hàng Bông, Hà Nội', N'Hà Nam', 'Nam', 'nguyenvana1@gmail.com', 'TTS', '1', 'PBCNTT'),
('NVCNTT011', N'Trần Thị B', '22/08/1985',N'50 Lê Lợi, TP. HCM', N'Long An', 'Nu', 'tranthib2@gmail.com', 'NVCT02', '3', 'PBCNTT'),
('NVCNTT012', N'Lê Văn C', '03/11/1992', N'75 Nguyễn Trãi, Đà Nẵng', N'Quảng Ngãi', 'Nam', 'levanc3@gmail.com', 'NVCT02', '3', 'PBCNTT'),
('NVCNTT013', N'Phạm Thị D', '12/03/1988', N'30 Trần Hưng Đạo, Cần Thơ', N'An Giang', 'Nu', 'phamthid4@gmail.com', 'TTS', '1', 'PBCNTT'),
('NVCNTT014', N'Đỗ Văn E', '19/07/1995', N'88 Lý Thường Kiệt, Hải Phòng', N'Thái Bình', 'Nam', 'dovane5@gmail.com', 'NVCT01', '2', 'PBCNTT'),
('NVCNTT015', N'Hoàng Thị F', '25/09/1987', N'12 Pasteur, Huế', N'Quảng Trị', 'Nu', 'hoangthif6@gmail.com', 'NVCT02', '3', 'PBCNTT'),
('NVCNTT016', N'Nguyễn Văn G', '14/04/1993', N'45 Hai Bà Trưng, Hà Nội', N'Nam Định', 'Nam', 'nguyenvang7@gmail.com', 'TTS', '1', 'PBCNTT'),
('NVCNTT017', N'Trần Văn H', '30/10/1991', N'67 Nguyễn Huệ, TP. HCM', N'Tiền Giang', 'Nam', 'tranvanh8@gmail.com', 'NVCT01', '2', 'PBCNTT'),
('NVCNTT018', N'Lê Thị I', '08/06/1989', N'90 Trần Phú, Đà Nẵng', N'Quảng Bình', 'Nu', 'lethii9@gmail.com', 'NVCT02', '3', 'PBCNTT'),
('NVCNTT019', N'Phạm Văn K', '17/12/1994', N'33 Hàng Đào, Hà Nội', N'Ninh Bình', 'Nam', 'phamvank10@gmail.com', 'TTS', '1', 'PBCNTT'),
('NVCNTT020', N'Đỗ Thị L', '21/02/1986', N'55 Lê Đại Hành, TP. HCM', N'Bạc Liêu', 'Nu', 'dothil11@gmail.com', 'NVCT01', '2', 'PBCNTT'),
('NVCNTT021', N'Hoàng Văn M', '06/08/1996', N'22 Nguyễn Văn Cừ, Cần Thơ', N'Cà Mau', 'Nam', 'hoangvanm12@gmail.com', 'NVCT02', '3', 'PBCNTT'),
('NVCNTT022', N'Nguyễn Thị N', '11/01/1987', N'77 Lý Tự Trọng, Hà Nội', N'Hưng Yên', 'Nu', 'nguyenthin13@gmail.com', 'TTS', '1', 'PBCNTT'),
('NVCNTT023', N'Phan Văn O', '29/05/1990', N'10 Nguyễn Du, TP. HCM', N'Vĩnh Long', 'Nam', 'phanvano14@gmail.com', 'NVCT01', '2', 'PBCNTT'),
('NVCNTT024', N'Vũ Thị P', '18/03/1993', N'88 Hùng Vương, Đà Nẵng', N'Bình Định', 'Nu', 'vuthip15@gmail.com', 'NVCT02', '3', 'PBCNTT'),
('NVCNTT025', N'Trịnh Văn Q', '07/07/1988', N'42 Phan Chu Trinh, Huế', N'Thanh Hóa', 'Nam', 'trinhvanq16@gmail.com', 'TTS', '1', 'PBCNTT'),
('NVCNTT026', N'Huỳnh Thị R', '26/09/1991', N'15 Nguyễn Thị Minh Khai, Cần Thơ', N'Sóc Trăng', 'Nu', 'huynhthir17@gmail.com', 'NVCT01', '2', 'PBCNTT'),
('NVCNTT027', N'Bùi Văn S', '13/06/1994', N'34 Nguyễn Trãi, Hà Nội', N'Lào Cai', 'Nam', 'buivans18@gmail.com', 'NVCT02', '3', 'PBCNTT'),
('NVCNTT028', N'Lý Thị T', '04/12/1985', N'56 Trần Hưng Đạo, TP. HCM', N'Kon Tum', 'Nu', 'lythit19@gmail.com', 'TTS', '1', 'PBCNTT'),
('NVCNTT029', N'Tống Văn U', '20/10/1992', N'90 Nguyễn Huệ, Đà Nẵng', N'Gia Lai', 'Nam', 'tongvanu20@gmail.com', 'NVCT01', '2', 'PBCNTT'),
('NVCNTT030', N'Ngô Thị V', '02/02/1996', N'61 Hùng Vương, Huế', N'Quảng Nam', 'Nu', 'ngothiv21@gmail.com', 'NVCT02', '3', 'PBCNTT'),
('NVCNTT031', N'Tạ Văn X', '10/08/1989', N'48 Pasteur, Cần Thơ', N'Bến Tre', 'Nam', 'tavanx22@gmail.com', 'TTS', '1', 'PBCNTT'),
('NVCNTT032', N'Sơn Văn H3', '19/12/1991', N'41 Nguyễn Huệ, TP. HCM', N'Bến Tre', 'Nam', 'sonvanh80@gmail.com', 'NVCT01', '2', 'PBCNTT'),
('NVCNTT033', N'Thảo Thị I3', '25/09/1987', N'52 Trần Phú, Đà Nẵng', N'Phú Yên', 'Nu', 'thaothii81@gmail.com', 'NVCT02', '3', 'PBCNTT'),
('NVCNTT034', N'Uẩn Văn K3', '07/06/1990', N'36 Nguyễn Văn Cừ, Huế', N'Cà Mau', 'Nam', 'uanvank82@gmail.com', 'TTS', '1', 'PBCNTT'),
('NVCNTT035', N'Vinh Thị L3', '03/01/1994', N'84 Nguyễn Trãi, TP. HCM', N'Tiền Giang', 'Nu', 'vinhthil83@gmail.com', 'NVCT01', '2', 'PBCNTT'),
('NVCNTT036', N'Xuân Văn M3', '27/08/1988', N'46 Lý Tự Trọng, Đà Nẵng', N'Vĩnh Long', 'Nam', 'xuanvanm84@gmail.com', 'NVCT02', '3', 'PBCNTT'),
('NVCNTT037', N'Yến Thị N3', '06/11/1991', N'55 Trần Hưng Đạo, Hà Nội', N'Thái Bình', 'Nu', 'yenthin85@gmail.com', 'TTS', '1', 'PBCNTT'),
('NVCNTT038', N'Ánh Văn O3', '12/05/1993', N'31 Nguyễn Huệ, TP. HCM', N'Thái Nguyên', 'Nam', 'anhvano86@gmail.com', 'NVCT01', '2', 'PBCNTT'),
('NVCNTT039', N'Bình Thị P3', '09/03/1989', N'64 Hàng Đào, Huế', N'Hưng Yên', 'Nu', 'binhthip87@gmail.com', 'NVCT02', '3', 'PBCNTT'),
('NVCNTT040', N'Cường Văn Q3', '21/06/1990', N'43 Trần Phú, Đà Nẵng', N'Bắc Ninh', 'Nam', 'cuongvanq88@gmail.com', 'TTS', '1', 'PBCNTT'),
('NVCNTT041', N'Diệu Thị R3', '28/10/1992', N'19 Nguyễn Văn Linh, TP. HCM', N'Bình Phước', 'Nu', 'dieuthir89@gmail.com', 'NVCT01', '2', 'PBCNTT'),
('NVCNTT042', N'Đông Văn S3', '04/07/1986', N'76 Lê Lợi, Hà Nội', N'Hà Giang', 'Nam', 'dongvans90@gmail.com', 'NVCT02', '3', 'PBCNTT'),
('NVCNTT043', N'Em Thị T3', '15/02/1991', N'60 Nguyễn Huệ, Huế', N'Lai Châu', 'Nu', 'emthit91@gmail.com', 'TTS', '1', 'PBCNTT'),
('NVCNTT044', N'Giao Văn U3', '10/10/1994', N'38 Lý Tự Trọng, TP. HCM', N'Quảng Ngãi', 'Nam', 'giaovanu92@gmail.com', 'NVCT01', '2', 'PBCNTT'),
('NVCNTT045', N'Hạnh Thị V3', '19/01/1987', N'88 Trần Hưng Đạo, Hà Nội', N'Bắc Kạn', 'Nu', 'hanhthiv93@gmail.com', 'NVCT02', '3', 'PBCNTT'),
('NVCNTT046', N'Ích Văn X3', '06/08/1990', N'50 Nguyễn Văn Cừ, Huế', N'Kon Tum', 'Nam', 'ichvanx94@gmail.com', 'TTS', '1', 'PBCNTT'),
('NVCNTT047', N'Kỳ Thị Y3', '24/04/1993', N'26 Nguyễn Huệ, TP. HCM', N'Gia Lai', 'Nu', 'kythiy95@gmail.com', 'NVCT01', '2', 'PBCNTT'),
('NVCNTT048', N'Linh Văn Z3', '30/11/1988', N'68 Nguyễn Văn Linh, Đà Nẵng', N'Lào Cai', 'Nam', 'linhvanz96@gmail.com', 'NVCT02', '3', 'PBCNTT'),
('NVCNTT049', N'Mai Thị A4', '16/06/1991', N'20 Lê Duẩn, Hà Nội', N'Quảng Bình', 'Nu', 'maithia97@gmail.com', 'TTS', '1', 'PBCNTT'),
('NVCNTT050', N'Nam Văn B4', '05/09/1989', N'91 Nguyễn Trãi, TP. HCM', N'Hà Nội', 'Nam', 'namvanb98@gmail.com', 'NVCT01', '2', 'PBCNTT'),
('NVCNTT051', N'Nga Thị C4', '13/03/1992', N'34 Trần Phú, Huế', N'Thừa Thiên Huế', 'Nu', 'ngathic99@gmail.com', 'NVCT02', '3', 'PBCNTT'),
('NVCNTT052', N'Oanh Văn D4', '09/12/1987', N'89 Nguyễn Huệ, Đà Nẵng', N'Hồ Chí Minh', 'Nam', 'oanhvand100@gmail.com', 'TTS', '1', 'PBCNTT'),

('TPKD01', N'Đỗ Kim Quyên', '23/12/2005',N'Phường Linh Tây thành phố Thủ Đức thành phố Hồ Chí Minh', N'Bà Rịa Vũng Tàu', 'Nu', 'dokimquyen@gmail.com', 'TPKD', '4', 'PBKD'),
('NVKD01', N'Nguyễn Kỳ Duyên', '12/4/2005',N'quận Bình Thạnh thành phố Hồ Chí Minh', N'Đồng Nai', 'Nu', 'nguyenkyduyen@gmail.com', 'NVCT01', '2', 'PBKD'),
('NVKD02', N'Võ Kim Ngân', '5/5/2005',N'quận 2 thành phố Hồ Chí Minh', N'Bến tre', 'Nu', 'vokimngan@gmail.com', 'NVCT02', '3', 'PBKD'),
('NVKD03', N'Nguyễn Nguyên Pháp', '9/11/2002',N'thành phố Thủ Đức thành phố Hồ Chí Minh', N'Hà Nội', 'Nam', 'nguyennguyenphap@gmail.com', 'TTS', '1', 'PBKD'),

----Code chat gpt
('NVKD004', N'Trương Thị Y', '23/04/1990', N'72 Lê Lợi, TP. HCM', N'Cần Thơ', 'Nu', 'truongthiy23@gmail.com', 'NVCT01', '2', 'PBCNTT'),
('NVKD005', N'Chu Văn Z', '15/11/1993', N'39 Nguyễn Văn Cừ, Hà Nội', N'Phú Thọ', 'Nam', 'chuvanz24@gmail.com', 'NVCT02', '3', 'PBCNTT'),
('NVKD006', N'Dương Thị A1', '01/07/1986', N'58 Hai Bà Trưng, Đà Nẵng', N'Tuyên Quang', 'Nu', 'duongthia25@gmail.com', 'TTS', '1', 'PBCNTT'),
('NVKD007', N'Kiều Văn B1', '19/03/1995', N'17 Lê Duẩn, Huế', N'Thái Nguyên', 'Nam', 'kievanb26@gmail.com', 'NVCT01', '2', 'PBCNTT'),
('NVKD008', N'La Thị C1', '27/08/1992', N'84 Trần Phú, TP. HCM', N'Nghệ An', 'Nu', 'lathic27@gmail.com', 'NVCT02', '3', 'PBCNTT'),
('NVKD009', N'Mạc Văn D1', '06/01/1990', N'32 Nguyễn Huệ, Hà Nội', N'Yên Bái', 'Nam', 'macvand28@gmail.com', 'TTS', '1', 'PBCNTT'),
('NVKD010', N'Nguyễn Thị E1', '14/05/1994', N'66 Lý Tự Trọng, Đà Nẵng', N'Bình Thuận', 'Nu', 'nguyenthie29@gmail.com', 'NVCT01', '2', 'PBCNTT'),
('NVKD011', N'Phùng Văn F1', '09/09/1991', N'21 Nguyễn Trãi, TP. HCM', N'Lâm Đồng', 'Nam', 'phungvanf30@gmail.com', 'NVCT02', '3', 'PBCNTT'),
('NVKD012', N'Quách Thị G1', '02/12/1988', N'13 Lê Đại Hành, Huế', N'Cao Bằng', 'Nu', 'quachthig31@gmail.com', 'TTS', '1', 'PBCNTT'),
('NVKD013', N'Sơn Văn H1', '17/06/1993', N'41 Hàng Bài, Hà Nội', N'Bắc Giang', 'Nam', 'sonvanh32@gmail.com', 'NVCT01', '2', 'PBCNTT'),
('NVKD014', N'Tống Thị I1', '11/10/1987', N'95 Trần Hưng Đạo, Đà Nẵng', N'Điện Biên', 'Nu', 'tongthii33@gmail.com', 'NVCT02', '3', 'PBCNTT'),
('NVKD015', N'Uông Văn K1', '08/02/1995', N'36 Nguyễn Huệ, TP. HCM', N'Hòa Bình', 'Nam', 'uongvank34@gmail.com', 'TTS', '1', 'PBCNTT'),
('NVKD016', N'Vương Thị L1', '25/04/1990', N'62 Trần Phú, Huế', N'Lạng Sơn', 'Nu', 'vuongthil35@gmail.com', 'NVCT01', '2', 'PBCNTT'),
('NVKD017', N'Xà Văn M1', '30/07/1992', N'26 Hai Bà Trưng, Hà Nội', N'Sơn La', 'Nam', 'xavanm36@gmail.com', 'NVCT02', '3', 'PBCNTT'),
('NVKD018', N'Yến Thị N1', '19/11/1989', N'59 Nguyễn Văn Cừ, Đà Nẵng', N'Hà Tĩnh', 'Nu', 'yenthin37@gmail.com', 'TTS', '1', 'PBCNTT'),
('NVKD019', N'Ánh Văn O1', '22/03/1994', N'79 Lý Thường Kiệt, TP. HCM', N'Quảng Trị', 'Nam', 'anhvano38@gmail.com', 'NVCT01', '2', 'PBCNTT'),
('NVKD020', N'Bình Thị P1', '10/09/1990', N'47 Hùng Vương, Huế', N'Tây Ninh', 'Nu', 'binhthip39@gmail.com', 'NVCT02', '3', 'PBCNTT'),
('NVKD021', N'Cường Văn Q1', '28/06/1988', N'35 Nguyễn Văn Linh, Hà Nội', N'Tuyên Quang', 'Nam', 'cuongvanq40@gmail.com', 'TTS', '1', 'PBCNTT'),
('NVKD022', N'Diệu Thị R1', '16/01/1993', N'43 Nguyễn Huệ, Đà Nẵng', N'Hà Giang', 'Nu', 'dieuthir41@gmail.com', 'NVCT01', '2', 'PBCNTT'),
('NVKD023', N'Đông Văn S1', '05/08/1987', N'70 Lý Thường Kiệt, TP. HCM', N'Bình Dương', 'Nam', 'dongvans42@gmail.com', 'NVCT02', '3', 'PBCNTT'),


('TPMKT01', N'Nguyễn Hữu Điền', '21/12/2005',N'quận 3 thành phố Hồ Chí Minh', N'Bà Rịa Vũng Tàu', 'Nam', 'nguyenhuudien@gmail.com', 'TPMKT', '4', 'PBMKT'),
('NVMKT01', N'Trần Thị Hòa', '14/3/2005',N'quận 5 thành phố Hồ Chí Minh', N'An Giang', 'Nu', 'tranthihoa@gmail.com', 'NVCT02', '3', 'PBMKT'),
('NVMKT02', N'Lê Đăng Tiền', '6/3/2005',N'thành phố Thủ Đức thành phố Hồ Chí Minh', N'Bình Định', 'Nam', 'ledangtien@gmail.com', 'NVCT01', '2', 'PBMKT'),
('NVMKT03', N'Phan Lê Phi Thanh', '7/7/2002',N'quận 1 thành phố Hồ Chí Minh', N'An Giang', 'Nam', 'phanlephithanh@gmail.com', 'TTS', '1', 'PBMKT'),

----Code chat gpt
('NVMKT004', N'Em Thị T1', '12/04/1991', N'18 Nguyễn Thị Minh Khai, Huế', N'Vĩnh Phúc', 'Nu', 'emthit43@gmail.com', 'TTS', '1', 'PBCNTT'),
('NVMKT005', N'Giao Văn U1', '26/07/1992', N'57 Trần Phú, Hà Nội', N'Phú Yên', 'Nam', 'giaovanu44@gmail.com', 'NVCT01', '2', 'PBCNTT'),
('NVMKT006', N'Hạnh Thị V1', '03/02/1989', N'31 Lý Tự Trọng, TP. HCM', N'Kiên Giang', 'Nu', 'hanhthiv45@gmail.com', 'NVCT02', '3', 'PBCNTT'),
('NVMKT007', N'Ích Văn X1', '14/09/1993', N'24 Trần Hưng Đạo, Đà Nẵng', N'Trà Vinh', 'Nam', 'ichvanx46@gmail.com', 'TTS', '1', 'PBCNTT'),
('NVMKT008', N'Kỳ Thị Y1', '06/06/1988', N'92 Hai Bà Trưng, Huế', N'Đắk Lắk', 'Nu', 'kythiy47@gmail.com', 'NVCT01', '2', 'PBCNTT'),
('NVMKT009', N'Linh Văn Z1', '09/11/1994', N'11 Nguyễn Văn Cừ, TP. HCM', N'Bình Phước', 'Nam', 'linhvanz48@gmail.com', 'NVCT02', '3', 'PBCNTT'),
('NVMKT010', N'Mai Thị A2', '18/01/1990', N'67 Trần Phú, Hà Nội', N'Ninh Thuận', 'Nu', 'maithia49@gmail.com', 'TTS', '1', 'PBCNTT'),
('NVMKT011', N'Nam Văn B2', '22/05/1995', N'73 Nguyễn Trãi, Đà Nẵng', N'Cà Mau', 'Nam', 'namvanb50@gmail.com', 'NVCT01', '2', 'PBCNTT'),
('NVMKT012', N'Nga Thị C2', '07/08/1987', N'55 Nguyễn Huệ, TP. HCM', N'Đồng Nai', 'Nu', 'ngathic51@gmail.com', 'NVCT02', '3', 'PBCNTT'),
('NVMKT013', N'Oanh Văn D2', '29/03/1992', N'48 Lê Lợi, Huế', N'An Giang', 'Nam', 'oanhvand52@gmail.com', 'TTS', '1', 'PBCNTT'),
('NVMKT014', N'Phúc Thị E2', '13/10/1989', N'37 Hàng Bông, Hà Nội', N'Hậu Giang', 'Nu', 'phucthie53@gmail.com', 'NVCT01', '2', 'PBCNTT'),
('NVMKT015', N'Quân Văn F2', '21/12/1993', N'85 Nguyễn Văn Linh, Đà Nẵng', N'Sóc Trăng', 'Nam', 'quanvanf54@gmail.com', 'NVCT02', '3', 'PBCNTT'),

('TPNS01', N'Nguyễn Văn Thanh', '12/8/2004',N'quận Bình Thạnh thành phố Hồ Chí Minh', N'Cà Mau', 'Nam', 'nguyenvanthanh@gmail.com', 'TPNS', '4', 'PBNS'),
('NVNS01', N'Trương Lê Nhật Huy', '5/2/2004',N'quận Bình Thạnh thành phố Hồ Chí Minh', N'Hồ Chí Minh', 'Nam', 'truonglenhathuy@gmail.com', 'NVCT02', '3', 'PBNS'),
('NVNS02', N'Nguyễn Đông Huy', '4/3/2004',N'quận Bình Thạnh thành phố Hồ Chí Minh', N'Bà Rịa Vũng Tàu', 'Nam', 'nguyendonghuy@gmail.com', 'NVCT01', '2', 'PBNS'),
('NVNS03', N'Nguyễn Thị Như Quỳnh', '21/9/2004',N'quận Bình Thạnh thành phố Hồ Chí Minh', N'Bình Phước', 'Nu', 'nguyenthinhuquynh@gmail.com', 'TTS', '1', 'PBNS'),

----Code chat gpt
('NVNS004', N'Rạng Thị G2', '04/06/1991', N'19 Trần Phú, TP. HCM', N'Bạc Liêu', 'Nu', 'rangthig55@gmail.com', 'TTS', '1', 'PBCNTT'),
('NVNS005', N'Sơn Văn H2', '15/08/1986', N'71 Nguyễn Huệ, Huế', N'Long An', 'Nam', 'sonvanh56@gmail.com', 'NVCT01', '2', 'PBCNTT'),
('NVNS006', N'Thảo Thị I2', '10/02/1994', N'93 Nguyễn Văn Cừ, Hà Nội', N'Đắk Nông', 'Nu', 'thaothii57@gmail.com', 'NVCT02', '3', 'PBCNTT'),
('NVNS007', N'Uẩn Văn K2', '27/07/1988', N'45 Lê Duẩn, Đà Nẵng', N'Tiền Giang', 'Nam', 'uanvank58@gmail.com', 'TTS', '1', 'PBCNTT'),
('NVNS008', N'Vinh Thị L2', '02/11/1992', N'60 Trần Hưng Đạo, TP. HCM', N'Vĩnh Long', 'Nu', 'vinhthil59@gmail.com', 'NVCT01', '2', 'PBCNTT'),
('NVNS009', N'Xuân Văn M2', '08/05/1990', N'74 Nguyễn Huệ, Huế', N'Bắc Ninh', 'Nam', 'xuanvanm60@gmail.com', 'NVCT02', '3', 'PBCNTT'),
('NVNS010', N'Yến Thị N2', '31/03/1987', N'28 Nguyễn Văn Linh, Hà Nội', N'Hưng Yên', 'Nu', 'yenthin61@gmail.com', 'TTS', '1', 'PBCNTT'),
('NVNS011', N'Ánh Văn O2', '16/09/1991', N'46 Lê Thánh Tông, Đà Nẵng', N'Thái Nguyên', 'Nam', 'anhvano62@gmail.com', 'NVCT01', '2', 'PBCNTT'),


('TPKT01', N'Phan Gia Phước', '21/3/2004',N'quận Bình Thạnh thành phố Hồ Chí Minh', N'Long An', 'Nam', 'phangiaphuoc@gmail.com', 'TPKT', '4', 'PBKT'),
('NVKT01', N'Nguyễn Huy Hoàng', '21/7/2001',N'quận Bình Thạnh thành phố Hồ Chí Minh', N'Vĩnh Long', 'Nam', 'nguyenhuyhoang@gmail.com', 'NVCT02', '3', 'PBKT'),
('NVKT02', N'Nguyễn Đức Hoàng', '1/12/2003',N'quận Bình Thạnh thành phố Hồ Chí Minh', N'Đà Nẵng', 'Nam', 'hoangnd@gmail.com', 'NVCT01', '2', 'PBKT'),
('NVKT03', N'Nông Lương Ngọc Nhi', '12/8/2002',N'quận Bình Thạnh thành phố Hồ Chí Minh', N'Tây Ninh', 'Nu', 'nongluongngocnhi@gmail.com', 'TTS', '1', 'PBKT'),

----Code chat gpt
('TPKT004', N'Bình Thị P2', '03/12/1992', N'33 Hàng Đào, Hà Nội', N'Hà Nam', 'Nu', 'binhthip63@gmail.com', 'NVCT02', '3', 'PBCNTT'),
('TPKT005', N'Cường Văn Q2', '09/06/1989', N'58 Lê Lợi, TP. HCM', N'Thanh Hóa', 'Nam', 'cuongvanq64@gmail.com', 'TTS', '1', 'PBCNTT'),
('TPKT006', N'Diệu Thị R2', '21/01/1991', N'87 Nguyễn Huệ, Huế', N'Nghệ An', 'Nu', 'dieuthir65@gmail.com', 'NVCT01', '2', 'PBCNTT'),
('TPKT007', N'Đức Văn S2', '26/04/1993', N'10 Trần Hưng Đạo, Hà Nội', N'Nam Định', 'Nam', 'ducvans66@gmail.com', 'NVCT02', '3', 'PBCNTT'),
('TPKT008', N'Em Thị T2', '12/07/1988', N'92 Nguyễn Văn Cừ, TP. HCM', N'Hà Tĩnh', 'Nu', 'emthit67@gmail.com', 'TTS', '1', 'PBCNTT'),
('TPKT009', N'Giao Văn U2', '18/03/1994', N'55 Trần Phú, Huế', N'Cần Thơ', 'Nam', 'giaovanu68@gmail.com', 'NVCT01', '2', 'PBCNTT'),
('TPKT010', N'Hạnh Thị V2', '07/09/1990', N'79 Nguyễn Văn Linh, Hà Nội', N'Đồng Nai', 'Nu', 'hanhthiv69@gmail.com', 'NVCT02', '3', 'PBCNTT'),
('TPKT011', N'Ích Văn X2', '04/05/1987', N'44 Nguyễn Trãi, Đà Nẵng', N'Quảng Nam', 'Nam', 'ichvanx70@gmail.com', 'TTS', '1', 'PBCNTT'),
('TPKT012', N'Kỳ Thị Y2', '30/10/1991', N'18 Lê Duẩn, TP. HCM', N'Lâm Đồng', 'Nu', 'kythiy71@gmail.com', 'NVCT01', '2', 'PBCNTT'),
('TPKT013', N'Linh Văn Z2', '14/02/1995', N'62 Nguyễn Huệ, Hà Nội', N'Đắk Lắk', 'Nam', 'linhvanz72@gmail.com', 'NVCT02', '3', 'PBCNTT'),
('TPKT014', N'Mai Thị A3', '23/06/1989', N'70 Trần Phú, Đà Nẵng', N'Yên Bái', 'Nu', 'maithia73@gmail.com', 'TTS', '1', 'PBCNTT'),
('TPKT015', N'Nam Văn B3', '05/11/1992', N'95 Hàng Bông, TP. HCM', N'Sơn La', 'Nam', 'namvanb74@gmail.com', 'NVCT01', '2', 'PBCNTT'),
('TPKT016', N'Nga Thị C3', '29/03/1990', N'38 Nguyễn Văn Cừ, Huế', N'Tuyên Quang', 'Nu', 'ngathic75@gmail.com', 'NVCT02', '3', 'PBCNTT'),
('TPKT017', N'Oanh Văn D3', '17/08/1986', N'12 Hai Bà Trưng, Hà Nội', N'Lạng Sơn', 'Nam', 'oanhvand76@gmail.com', 'TTS', '1', 'PBCNTT'),
('TPKT018', N'Phúc Thị E3', '11/01/1993', N'22 Nguyễn Huệ, TP. HCM', N'Hòa Bình', 'Nu', 'phucthie77@gmail.com', 'NVCT01', '2', 'PBCNTT'),
('TPKT019', N'Quân Văn F3', '08/07/1988', N'66 Trần Hưng Đạo, Đà Nẵng', N'Bình Định', 'Nam', 'quanvanf78@gmail.com', 'NVCT02', '3', 'PBCNTT'),
('TPKT020', N'Rạng Thị G3', '16/04/1994', N'77 Nguyễn Văn Linh, Hà Nội', N'Hậu Giang', 'Nu', 'rangthig79@gmail.com', 'TTS', '1', 'PBCNTT'),


('GDHDQT01', N'Đặng Lê Nguyên Vũ', '11/12/1970',N'quận Bình Thạnh thành phố Hồ Chí Minh', N'Bình Thuận', 'Nam', 'danglenguyenvu@gmail.com', 'GD', '6', 'HDQT'),
('PGDHDQT01', N'Hoàng Nam Tiến', '11/12/1976',N'quận Bình Thạnh thành phố Hồ Chí Minh', N'Hà Nội', 'Nam', 'hoangnamtien@gmail.com', 'PGD', '5', 'HDQT')
go

--chèn dữ liệu bảng ChiTietLuong
insert into ChiTietLuong(kyNhanLuong, soGioCongChuan, luongCoBan, donGiaTangCa, gioTangCa, phuCap, tienBiTru, ngayNhanLuong, ghiChu, idLuong, idNhanVien) values
('1/1/2025', 208, 15000000, 100000, 50, 0, 200000, '5/1/2025', N'Cần cải thiện việc đi làm trễ', '4', 'TPCNTT01'),
('1/2/2025', 208, 15000000, 100000, 0, 100000, 0, '5/2/2025', N'tốt', '4', 'TPCNTT01'),
('1/3/2025', 208, 15000000, 100000, 20, 0, 0, '5/3/2025', N'tốt', '4', 'TPCNTT01'),
('1/4/2025', 208, 15000000, 100000, 10, 0, 100000, '5/4/2025', N'trung bình', '4', 'TPCNTT01'),

('1/1/2025', 208, 5000000, 500000, 20, 0, 0, '5/1/2025', N'tốt', '2', 'TPKD01'),
('1/2/2025', 208, 5000000, 500000, 0, 0, 0, '5/2/2025', N'tốt', '2', 'TPKD01'),
('1/3/2025', 208, 5000000, 500000, 20, 0, 0, '5/3/2025', N'tốt', '2', 'TPKD01'),
('1/4/2025', 208, 5000000, 500000, 10, 0, 0, '5/4/2025', N'tốt', '2', 'TPKD01')
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
('25/12/2024',10000000, N'Thưởng tết'),
('25/12/2024',20000000, N'Thưởng đạt KPI năm'),
('25/12/2024',50000000, N'Thưởng vượt KPI năm'),
('25/12/2024',100000000, N'Thưởng nhân viên xuất sắc nhất năm'),
('25/12/2024',200000000, N'Thưởng nhân viên kiếm lợi nhuật nhiều nhất ')
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



CREATE VIEW vw_DanhSachPhongBanSoLuong AS
SELECT 
  PhongBan.TenPhongBan, 
  COUNT(NhanVien.id) AS SoLuongNhanVien
FROM 
  PhongBan
LEFT JOIN 
  NhanVien ON PhongBan.id = NhanVien.idPhongBan
GROUP BY 
  PhongBan.TenPhongBan;
  go
