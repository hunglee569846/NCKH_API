USE [DBEduSoft]
GO
/****** Object:  StoredProcedure [dbo].[spThongTinSinhVien]    Script Date: 4/26/2021 12:45:09 PM ******/
DROP PROCEDURE [dbo].[spThongTinSinhVien]
GO
/****** Object:  StoredProcedure [dbo].[spThongTinGiangVien]    Script Date: 4/26/2021 12:45:09 PM ******/
DROP PROCEDURE [dbo].[spThongTinGiangVien]
GO
/****** Object:  StoredProcedure [dbo].[spSinhVien_SelectByID]    Script Date: 4/26/2021 12:45:09 PM ******/
DROP PROCEDURE [dbo].[spSinhVien_SelectByID]
GO
/****** Object:  StoredProcedure [dbo].[spSinhVien_SelectAll]    Script Date: 4/26/2021 12:45:09 PM ******/
DROP PROCEDURE [dbo].[spSinhVien_SelectAll]
GO
/****** Object:  StoredProcedure [dbo].[spSinhVien_Search]    Script Date: 4/26/2021 12:45:09 PM ******/
DROP PROCEDURE [dbo].[spSinhVien_Search]
GO
/****** Object:  StoredProcedure [dbo].[spSinhVien_KiemTraDK]    Script Date: 4/26/2021 12:45:09 PM ******/
DROP PROCEDURE [dbo].[spSinhVien_KiemTraDK]
GO
/****** Object:  StoredProcedure [dbo].[spNganh_SelectByID]    Script Date: 4/26/2021 12:45:09 PM ******/
DROP PROCEDURE [dbo].[spNganh_SelectByID]
GO
/****** Object:  StoredProcedure [dbo].[spNganh_SelectAll]    Script Date: 4/26/2021 12:45:09 PM ******/
DROP PROCEDURE [dbo].[spNganh_SelectAll]
GO
/****** Object:  StoredProcedure [dbo].[spLopHoc_SelectByID]    Script Date: 4/26/2021 12:45:09 PM ******/
DROP PROCEDURE [dbo].[spLopHoc_SelectByID]
GO
/****** Object:  StoredProcedure [dbo].[spLopHoc_SelectAll]    Script Date: 4/26/2021 12:45:09 PM ******/
DROP PROCEDURE [dbo].[spLopHoc_SelectAll]
GO
/****** Object:  StoredProcedure [dbo].[spKhoa_SelectByID]    Script Date: 4/26/2021 12:45:09 PM ******/
DROP PROCEDURE [dbo].[spKhoa_SelectByID]
GO
/****** Object:  StoredProcedure [dbo].[spKhoa_SelectAll]    Script Date: 4/26/2021 12:45:09 PM ******/
DROP PROCEDURE [dbo].[spKhoa_SelectAll]
GO
/****** Object:  StoredProcedure [dbo].[spGiangVien_SelectByID]    Script Date: 4/26/2021 12:45:09 PM ******/
DROP PROCEDURE [dbo].[spGiangVien_SelectByID]
GO
/****** Object:  StoredProcedure [dbo].[spGiangVien_SelectAll]    Script Date: 4/26/2021 12:45:09 PM ******/
DROP PROCEDURE [dbo].[spGiangVien_SelectAll]
GO
/****** Object:  StoredProcedure [dbo].[spChuyenNganh_SelectByID]    Script Date: 4/26/2021 12:45:09 PM ******/
DROP PROCEDURE [dbo].[spChuyenNganh_SelectByID]
GO
/****** Object:  StoredProcedure [dbo].[spChuyenNganh_SelectAll]    Script Date: 4/26/2021 12:45:09 PM ******/
DROP PROCEDURE [dbo].[spChuyenNganh_SelectAll]
GO
/****** Object:  StoredProcedure [dbo].[spBoMon_SelectByID]    Script Date: 4/26/2021 12:45:09 PM ******/
DROP PROCEDURE [dbo].[spBoMon_SelectByID]
GO
/****** Object:  StoredProcedure [dbo].[spBoMon_SelectAll]    Script Date: 4/26/2021 12:45:09 PM ******/
DROP PROCEDURE [dbo].[spBoMon_SelectAll]
GO
/****** Object:  StoredProcedure [dbo].[spBoMon_SearchByIdKhoa]    Script Date: 4/26/2021 12:45:09 PM ******/
DROP PROCEDURE [dbo].[spBoMon_SearchByIdKhoa]
GO
/****** Object:  StoredProcedure [dbo].[spBoMon_Search]    Script Date: 4/26/2021 12:45:09 PM ******/
DROP PROCEDURE [dbo].[spBoMon_Search]
GO
/****** Object:  StoredProcedure [dbo].[spBoMo_SelectAll]    Script Date: 4/26/2021 12:45:09 PM ******/
DROP PROCEDURE [dbo].[spBoMo_SelectAll]
GO
/****** Object:  Table [dbo].[ThongTinChungs]    Script Date: 4/26/2021 12:45:09 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ThongTinChungs]') AND type in (N'U'))
DROP TABLE [dbo].[ThongTinChungs]
GO
/****** Object:  Table [dbo].[SinhViens]    Script Date: 4/26/2021 12:45:09 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SinhViens]') AND type in (N'U'))
DROP TABLE [dbo].[SinhViens]
GO
/****** Object:  Table [dbo].[NienGiamCTDTs]    Script Date: 4/26/2021 12:45:09 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NienGiamCTDTs]') AND type in (N'U'))
DROP TABLE [dbo].[NienGiamCTDTs]
GO
/****** Object:  Table [dbo].[Nganhs]    Script Date: 4/26/2021 12:45:09 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Nganhs]') AND type in (N'U'))
DROP TABLE [dbo].[Nganhs]
GO
/****** Object:  Table [dbo].[MonHocs]    Script Date: 4/26/2021 12:45:09 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MonHocs]') AND type in (N'U'))
DROP TABLE [dbo].[MonHocs]
GO
/****** Object:  Table [dbo].[LopHocs]    Script Date: 4/26/2021 12:45:09 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LopHocs]') AND type in (N'U'))
DROP TABLE [dbo].[LopHocs]
GO
/****** Object:  Table [dbo].[LoaiMonHocs]    Script Date: 4/26/2021 12:45:09 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LoaiMonHocs]') AND type in (N'U'))
DROP TABLE [dbo].[LoaiMonHocs]
GO
/****** Object:  Table [dbo].[KhoasDaoTaos]    Script Date: 4/26/2021 12:45:09 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KhoasDaoTaos]') AND type in (N'U'))
DROP TABLE [dbo].[KhoasDaoTaos]
GO
/****** Object:  Table [dbo].[Khoas]    Script Date: 4/26/2021 12:45:09 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Khoas]') AND type in (N'U'))
DROP TABLE [dbo].[Khoas]
GO
/****** Object:  Table [dbo].[KetQuaHocTaps]    Script Date: 4/26/2021 12:45:09 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KetQuaHocTaps]') AND type in (N'U'))
DROP TABLE [dbo].[KetQuaHocTaps]
GO
/****** Object:  Table [dbo].[HocKys]    Script Date: 4/26/2021 12:45:09 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[HocKys]') AND type in (N'U'))
DROP TABLE [dbo].[HocKys]
GO
/****** Object:  Table [dbo].[GiangViens]    Script Date: 4/26/2021 12:45:09 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GiangViens]') AND type in (N'U'))
DROP TABLE [dbo].[GiangViens]
GO
/****** Object:  Table [dbo].[ChuyenNganhs]    Script Date: 4/26/2021 12:45:09 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ChuyenNganhs]') AND type in (N'U'))
DROP TABLE [dbo].[ChuyenNganhs]
GO
/****** Object:  Table [dbo].[ChuongTrinhDaoTaos]    Script Date: 4/26/2021 12:45:09 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ChuongTrinhDaoTaos]') AND type in (N'U'))
DROP TABLE [dbo].[ChuongTrinhDaoTaos]
GO
/****** Object:  Table [dbo].[BoMons]    Script Date: 4/26/2021 12:45:09 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BoMons]') AND type in (N'U'))
DROP TABLE [dbo].[BoMons]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 4/26/2021 12:45:09 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[__MigrationHistory]') AND type in (N'U'))
DROP TABLE [dbo].[__MigrationHistory]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 4/26/2021 12:45:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BoMons]    Script Date: 4/26/2021 12:45:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BoMons](
	[Id] [varchar](50) NOT NULL,
	[MaBoMon] [varchar](50) NULL,
	[TenBoMon] [nvarchar](300) NOT NULL,
	[VanPhong] [nvarchar](500) NULL,
	[DiaChi] [nvarchar](500) NULL,
	[HomThu] [nvarchar](max) NULL,
	[DienThoai] [nvarchar](11) NULL,
	[NgayTao] [datetime2](7) NULL,
	[NgayCapNhat] [date] NULL,
	[NgayXoa] [datetime2](7) NULL,
	[IsDelete] [bit] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_dbo.BoMons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChuongTrinhDaoTaos]    Script Date: 4/26/2021 12:45:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChuongTrinhDaoTaos](
	[Id] [varchar](50) NOT NULL,
	[MaChuongTrinhDaoTao] [varchar](50) NULL,
	[TenChuongTrinhDaoTao] [nvarchar](300) NULL,
	[IdNganh] [varchar](50) NULL,
	[IdChuyenNganh] [varchar](50) NULL,
	[IdKhoasDaoTao] [varchar](50) NULL,
	[SoKy] [int] NULL,
	[TrinhDoDaoTao] [nvarchar](500) NULL,
	[HeDaoTao] [nvarchar](50) NULL,
	[ThoiGianDaoTao] [float] NULL,
	[SoTinChi] [int] NOT NULL,
	[IsDelete] [bit] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_dbo.ChuongTrinhDaoTaos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChuyenNganhs]    Script Date: 4/26/2021 12:45:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChuyenNganhs](
	[Id] [varchar](50) NOT NULL,
	[MaChuyenNganh] [varchar](50) NOT NULL,
	[TenChuyenNganh] [nvarchar](500) NOT NULL,
	[VanPhong] [nvarchar](300) NULL,
	[HopThu] [nvarchar](300) NULL,
	[DienThoai] [nvarchar](11) NULL,
	[DiaChi] [nvarchar](500) NULL,
	[GhiChu] [nvarchar](500) NULL,
	[NgayCapNhat] [datetime2](7) NULL,
	[NgayTao] [datetime2](7) NULL,
	[IsDelete] [bit] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_dbo.ChuyenNganhs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GiangViens]    Script Date: 4/26/2021 12:45:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiangViens](
	[Id] [varchar](50) NOT NULL,
	[MaGiangVien] [varchar](50) NOT NULL,
	[HoDem] [nvarchar](200) NULL,
	[Ten] [nvarchar](50) NULL,
	[HoTen] [nvarchar](50) NOT NULL,
	[HomThu] [nvarchar](max) NULL,
	[GhiChu] [nvarchar](max) NULL,
	[DonViCongTac] [nvarchar](500) NULL,
	[DienThoai] [nvarchar](11) NULL,
	[SoDeTai] [int] NULL,
	[IdThongTinChung] [varchar](50) NULL,
	[TenThongTinChung] [nvarchar](500) NULL,
	[NgayTao] [datetime2](7) NULL,
	[NgayCapNhat] [datetime2](7) NULL,
	[IsDelete] [bit] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_dbo.GiangViens] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HocKys]    Script Date: 4/26/2021 12:45:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HocKys](
	[Id] [varchar](50) NOT NULL,
	[MaHocKy] [varchar](50) NULL,
	[TenHocKy] [nvarchar](300) NULL,
 CONSTRAINT [PK_HocKys] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KetQuaHocTaps]    Script Date: 4/26/2021 12:45:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KetQuaHocTaps](
	[Id] [varchar](50) NULL,
	[IdSinhVien] [varchar](50) NULL,
	[IdMonHoc] [nchar](10) NULL,
	[TenMonHoc] [nchar](10) NULL,
	[DiemHocPhan] [float] NULL,
	[DiemC] [float] NULL,
	[DiemB] [float] NULL,
	[DiemA] [float] NULL,
	[SoTinChi] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Khoas]    Script Date: 4/26/2021 12:45:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Khoas](
	[Id] [varchar](50) NOT NULL,
	[MaKhoa] [varchar](50) NULL,
	[TenKhoa] [nvarchar](300) NOT NULL,
	[IsDelete] [bit] NULL,
	[IsActive] [bit] NULL,
	[NgayTao] [datetime2](7) NULL,
	[NgayCapNhat] [datetime2](7) NULL,
 CONSTRAINT [PK_dbo.Khoas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhoasDaoTaos]    Script Date: 4/26/2021 12:45:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhoasDaoTaos](
	[Id] [varchar](50) NOT NULL,
	[MaKhoasDaoTao] [nvarchar](50) NULL,
	[TenKhoasDaoTao] [nvarchar](500) NULL,
	[ThoiGianDaoTao] [nvarchar](50) NULL,
	[IdChuongTringDaoTao] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiMonHocs]    Script Date: 4/26/2021 12:45:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiMonHocs](
	[Id] [varchar](50) NULL,
	[MaLoai] [varchar](50) NULL,
	[TenLoaiMonHoc] [nvarchar](300) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LopHocs]    Script Date: 4/26/2021 12:45:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LopHocs](
	[Id] [varchar](50) NOT NULL,
	[MaLop] [varchar](50) NOT NULL,
	[TenLop] [nvarchar](500) NOT NULL,
	[IdThongTinChung] [varchar](50) NULL,
	[IdChuongTrinhDaoTao] [varchar](50) NULL,
	[IdKhoasDaoTao] [varchar](50) NULL,
	[MaChuyenNganh] [varchar](50) NULL,
	[MaChuongTrinhDaoTao] [varchar](50) NULL,
	[NienKhoa] [nvarchar](50) NULL,
	[NgayTao] [datetime2](7) NULL,
	[NgayCapNhat] [datetime2](7) NULL,
	[IsDelete] [bit] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_dbo.LopHocs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MonHocs]    Script Date: 4/26/2021 12:45:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonHocs](
	[Id] [varchar](50) NOT NULL,
	[MaMonHoc] [varchar](50) NULL,
	[TenMonHoc] [nvarchar](1000) NULL,
	[SoTinChi] [int] NULL,
	[MaLoaiMonHoc] [varchar](50) NULL,
	[TenLoaiMonHoc] [nvarchar](300) NULL,
 CONSTRAINT [PK_MonHocs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nganhs]    Script Date: 4/26/2021 12:45:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nganhs](
	[Id] [varchar](50) NOT NULL,
	[MaNganh] [varchar](50) NULL,
	[TenNganh] [nvarchar](500) NOT NULL,
	[NgayTao] [datetime2](7) NULL,
	[IsDelete] [bit] NULL,
	[IsActive] [bit] NULL,
	[NgayCapNhat] [datetime2](7) NULL,
	[NgayXoa] [datetime2](7) NULL,
 CONSTRAINT [PK_dbo.Nganhs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NienGiamCTDTs]    Script Date: 4/26/2021 12:45:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NienGiamCTDTs](
	[Id] [varchar](50) NOT NULL,
	[MaNienGiam] [varchar](50) NULL,
	[TenNienGiam] [nvarchar](500) NULL,
	[IdChuongTrinhDaoTaos] [nvarchar](50) NULL,
	[IdKhoasDaoTao] [varchar](50) NULL,
	[IdHocKy] [varchar](50) NULL,
	[IdMonHoc] [varchar](50) NULL,
	[IdLoaiMonHoc] [varchar](50) NULL,
	[GhiChu] [nvarchar](max) NULL,
 CONSTRAINT [PK_NienGiamCTDTs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SinhViens]    Script Date: 4/26/2021 12:45:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SinhViens](
	[Id] [varchar](50) NOT NULL,
	[MaSinhVien] [varchar](50) NOT NULL,
	[HoDem] [nvarchar](50) NULL,
	[Ten] [nvarchar](50) NULL,
	[HoTen] [nvarchar](50) NULL,
	[HomThu] [nvarchar](max) NULL,
	[IdLop] [varchar](50) NOT NULL,
	[MaLop] [varchar](50) NULL,
	[DienThoai] [nvarchar](11) NULL,
	[NgayTao] [datetime2](7) NULL,
	[TinChiTichLuy] [int] NULL,
	[DiemTichLuy] [float] NULL,
	[IdThongTinChung] [varchar](50) NULL,
	[TenThongTinChung] [nvarchar](500) NULL,
	[IsDelete] [bit] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_dbo.SinhViens] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThongTinChungs]    Script Date: 4/26/2021 12:45:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongTinChungs](
	[Id] [varchar](50) NOT NULL,
	[MaNhomChuyenNganh] [varchar](50) NULL,
	[TenNhomChuyenNganh] [nvarchar](1000) NULL,
	[IdKhoa] [varchar](50) NULL,
	[TenKhoa] [nvarchar](300) NULL,
	[IdBoMon] [varchar](50) NULL,
	[TenBoMon] [nvarchar](1000) NULL,
	[IdNganh] [varchar](50) NULL,
	[TenNganh] [nvarchar](1000) NULL,
	[IdChuyenNganh] [varchar](50) NULL,
	[TenChuyenNganh] [nvarchar](1000) NULL,
	[GhiChu] [nvarchar](max) NULL,
 CONSTRAINT [PK_ThongTinChungs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'202104040755239_CreateDBedusoft', N'CreateDBEduSoft.Migrations.Configuration', 0x1F8B0800000000000400ED5DCD8EDB3610BE17E83B183EB540B2DADD20681B781364EDFC2C126FD2D859E4CA95695BA844AA12B5583F5B0F7DA4BE42A97F91A22452A62C393172484C72BEA168CEC7E17834F9EF9F7F27AF1E1D7BF4003DDFC2E86A7C71763E1E4164E295853657E380AC9FFE3E7EF5F2E79F266F56CEE3E82E1DF72C1C4725917F35DE12E2BE300CDFDC4207F8678E657AD8C76B726662C7002B6C5C9E9FFF615C5C1890428C29D66834F91220623930FA403F4E3132A14B0260CFF10ADA7ED24E7B1611EAE81638D0778109AFC6530F020267D76F56C122D4124B8C47AF6D0BD0D92CA0BD1E8F0042980042E7FAE2AB0F17C4C368B3706903B0973B17D2716B60FB30798617F970D9C739BF0C1FC7C805532833F0097614012F9E25EB63F0E2AD56799CAD1F5DC13774A5C92E7CEA6815AFC6D7788E115D305ED58BA9ED85C3AA96F82C167C32E2BA9F64DB82EE9EF00F1D11D824F0E0158201F180FD64F439B8B72DF303DC2DF15F105DA1C0B68B93A4D3A47D4C036DFAEC61177A64F705AE93A9DFACC62383953378C14CAC20133F16DD0674578F4773F0F811A20DD95E8D9FD36DFCD67A84ABB421D9165F91456D00669F6FE984C1BD9D3718B53AE7205A2B0D8AEBF52C216A52F4ECBC4913F102F527BC03E8F31687BA6A1E514E73BDA29905A65BAB7335EFB1B3DC06356AE83FB53C0D44CB2D06750F7471A141D11C7CA06A0EBFF36F3760B70438553CA344B1A4442F233605EEED169036A2DFF2479515BBF167D08604A672D718DB10A066B1D726B11EEAC526464EBAB5543CDD06D48696F4CBD9CE00A6EBD68696CB20278A96A1E8D2BA1D82AE5594CA527703B3C1FD9FAED5114179CE7A6701C4AABF41E4D9A532D6022F2D543807DAA10CC5E6771051D642DB96D69E899FEC5CD2CED3153BBCFAD8E4A5F4F7E5A769A219ECD63B507AD41CCC813A90DFF96E6B4D6B974D8F9A39E869FFEFE9D8B570250741F2E1B9B7B9A37BB50DC5E7C227829721F86CBD0EAFFC3D9E41A746EDA516EB5DEEF76872F4AD4589F2F269BA750F343ED3C8EE9AA20A18DD59D3F05E01CC0304640E74022FA86D2D01EFF20F2DFC3088E3E603247F06E03D3697C06D73E230F2A74347864016F406DFCF9933071FB1DBC34D26BA802F2D73FB31D8ED770F4FA0B6160CF603A25CE42CAFB939CD30DD8B4DCF276F5A94EA5A99542877322599EDAC2952DDE84335E8E9E897922E0F88C603B033974370626AD2256D999405E989D5C63613C993750EF7B081A8496F27C6DA73B4B09B1F255443365623556AB972FEA0BE7AEBC8FF29E62F6F46BAECB791A57A0AEBEB0B601CE6F7FDC33B412D29229E268946D6494A9B7B7A4F6C63F199ECC9E8877D256F0A036B392F4F5160ED24DA8B6F7BB000EA00B9BA9E36A718116021E8A52B751FB6C04742592FCC751550E8571F262CEA278BC24E32065E40C225BFE6D3885386CFD20EA35E5E94B155C2120D6AC62D648588100BDD0D58C51F1F4B48C5CE061C2EAA5C82E2FA9BD0E2405A19256E6F90CE2EFB25F9ACA701A1726D2557B5709097200A7DA2DD9EEDEBAC6F62C489ED49C3C4A8C8809FCC81EB52722864C4272DA345920EFF74A19E23EEC418065DB61A2BCC3411EC810DE47AA96A3AD3B796E713CA2CE01E84FC345D39A561252BAE58E7541D63A8BC7F922F7D3A3CFC7762437569EB3C52BE926FE9C3391091E83961369DAA2944A20B13D8C013783D536C070EAAF29CEAA43397BE089135CAE3E439E145A0BC551E29CF1D2A22E5ADF24869324D11276D934749FD84224ADAA63297ECF865A79335AB7C6771A084FDCAE2367994EC9C2EC2648D6A38D9B587C7CA3AD4F0BEF18F9735CAE3E40E05631D59AB0A52EA63B048696B1969627056CE138A516214EEAEC3F393147B093C000D4CD68C2AC16A32205D319C20BAC99A8E608012F33528108F5060202842CD5B15E6CA254733B3E4FAE451F334E9225EDE7AB2D951ADCDE63EB61E6BADC493B3D31AF10E2D34FFF9A3649B7997AA558A41F9BE3E7C93347199F52ADC1EBD0A3DDE529A7B564449DB547684702F287F5F5DF8263A7CA61F90E70A11000D2C578D26C17175C25D315C215B98DDD3850E15F68822BF2C79444D4A0C59A245B539941092A643DFAD74DD61F570179B16CBB029D3D30FCB67E9ADACAB96341EFFEDF10764563620AA815C6B0125F8B541BE2B8ACD7F886379206F57418B7EA46181A226058265535719AA65BB9431E31C560162DCA1442DC554568E5E8A5DC3D9EE51E45EC7361701C96C6FB15C57DB5A47AC2F4B43E5CE7B559C3ED975A827514F6690FE00A5C1102AA0244CA152B22B63D0C0CA498E2767098A285D842CBA0E54E61996CCEEB6D469A06F931B223DF54403FA0287AD4386870E16EA090D2DAB42832DEC56CFF5F37B082E1DCAD28B09938CD35A681F8C8DE6791A1ACCB4124CC2526B648FE152768A7AE97686744696BE07FAEA94204A7959FC904C7BD2927DCEF2B2929C288972A57C92543C643CA24BF460ADC204A9C5CE27D0390B079C2DFEB6A736FDD2493E600E90B5863E89D3B8C797E717975CB5D3E1541E357C7F650B72CA0A09F1A2ACAA4364A23F00CFDC02AF94E1BBDF9B17CDA892A9DD0C2A12C146EFA7EE59FE4908FCFC5C79C26C75245DA86C22788AFA8B031E7F559F2097642D9C639866AD86CBBEADAC694F7189DA2B103B4E97210740D38A4B2EFFA63A55C15B3021721B98427D4D4D93E393CCEF2DA20EC1269C3742EC5396F378E9AAF28D526DD455A94186C6DA94B0ACE01B4D152A2D449491F8FA946D30866E1215D948C7660CFCDBDDBAF692B0D0A3CCC9A8EF206F635A4CD9465DA85D9DBEDDB81D6C952E5DA8DC4BC81A5D05C1A1AEC95DD0EF840C9AD4AAD28F8E8AD24AD50F352133EFB40A8DE252DD280AAF974A1CE2CAAFACEA720C242F22FD5D18C594D5EEA624281EA8EF9AD8CD39C09506E4BCADFED8AE3B761E348FD6A4191D1595F20504B40117DE33D7E56E8AAAF1B5B975086AF1B5811156E25BDB1834412916E23BDECDA51637923C4C8BA0DA82867D704D2343EF75C6097859014FB922DDF16ED20E888AA9E4A6ED3EDCE5557EAF9859AB126B9A7CE19353A3D1A939FA5897A269489E38DD84B7942F493DFEAE329CE3B11BAB2C97406B05DCA242DAF1DA5A473787E6184C2B1BFEF14230FAFD9AAE421BDF0F67A9D5FA2A17136267A35CC82BCEB3A12B781F2E663CC9AE8B7C8974765D0CAC426707E5C2449ABA2B2726D2561CD2ACAFBEE098105F572D3211B8B642652270BD45CC441AF6AF7156CE999B18C5FF087C3283BEB5C921C2FF161C41334C46CB41D33137688D5386A2CF579C513A843F052001944EC16B8F586B6012DA6D42DF8F4A2FDE013BA043DE38F77075833E05C40DC86BDF87CEBDCDBC713731EAF54785DCD8394F3EB9E1275FC723D0695AE189F0095D0796BDCAE6FD561057AB800879F61DA4ED5192DF82D0BFE1669721DD622409942CDF0CBA10AD20224BE8B83605F33FA105088F09F5B97DF5E147B801E62E4D7DAC0669FE22D8659FCC2CB0F180E32718B93CFD48F7F0CA797CF93FB1F412FB0F7F0000, N'6.4.4')
GO
INSERT [dbo].[BoMons] ([Id], [MaBoMon], [TenBoMon], [VanPhong], [DiaChi], [HomThu], [DienThoai], [NgayTao], [NgayCapNhat], [NgayXoa], [IsDelete], [IsActive]) VALUES (N'0fb58942-fe59-448a-aebb-abb3ebc0cbbe', N'0601', N'Địa chất dầu khí', N'Phòng 807, Nhà C12 tầng, Trường Đại học Mỏ - Địa chất', N'Số 18 Phố Viên, phường Đức Thắng, quận Bắc Từ Liêm, Hà Nội', N'diachatdaukhi@humg.edu.vn', N'02437520009', CAST(N'2005-04-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0, 1)
INSERT [dbo].[BoMons] ([Id], [MaBoMon], [TenBoMon], [VanPhong], [DiaChi], [HomThu], [DienThoai], [NgayTao], [NgayCapNhat], [NgayXoa], [IsDelete], [IsActive]) VALUES (N'12334fds', N'DCCTKT23', N'Kinh te vaf tin hocj', N'c13 tang', N'123 co nhue', N'vsbfn@gmail.com', N'01214578963', CAST(N'2021-04-04T00:00:00.0000000' AS DateTime2), NULL, NULL, 0, 1)
INSERT [dbo].[BoMons] ([Id], [MaBoMon], [TenBoMon], [VanPhong], [DiaChi], [HomThu], [DienThoai], [NgayTao], [NgayCapNhat], [NgayXoa], [IsDelete], [IsActive]) VALUES (N'2c017050-323f-4e30-9626-01ef7a6986eb', N'9008', N'Thiết bị Dầu khí và Công trình', N'Phòng 803, Nhà C, Trường Đại học Mỏ - Địa chất', N'Số 18 Phố Viên, phường Đức Thắng, quận Bắc Từ Liêm, Hà Nội', N'tbdaukhicongtrinh@humg.edu.vn', N'02437520962', CAST(N'2005-04-05T00:00:00.0000000' AS DateTime2), NULL, NULL, 0, 1)
INSERT [dbo].[BoMons] ([Id], [MaBoMon], [TenBoMon], [VanPhong], [DiaChi], [HomThu], [DienThoai], [NgayTao], [NgayCapNhat], [NgayXoa], [IsDelete], [IsActive]) VALUES (N'2c2da3b2-f82b-4920-9585-c02db02c0633', N'0805', N'Khoa học máy tính', N'Phòng 704, tầng 7 nhà C12 tầng khu A Trường ĐH Mỏ - Địa chất', N'Số 18 Phố Viên, phường Đức Thắng, quận Bắc Từ Liêm, Hà Nội', N'khoahocmaytinh@humg.edu.vn', N'8437551110', CAST(N'2005-03-27T00:00:00.0000000' AS DateTime2), NULL, NULL, 0, 1)
INSERT [dbo].[BoMons] ([Id], [MaBoMon], [TenBoMon], [VanPhong], [DiaChi], [HomThu], [DienThoai], [NgayTao], [NgayCapNhat], [NgayXoa], [IsDelete], [IsActive]) VALUES (N'30e4ff10-85ea-49de-a3a5-094c08859525', N'9003', N'Địa vật lý', N'Phòng 802, Nhà C12 tầng, Trường Đại học Mỏ - Địa chất', N'Số 18 Phố Viên, phường Đức Thắng, quận Bắc Từ Liêm, Hà Nội', N'diavatly@humg.edu.vn', N'02432121646', CAST(N'2005-04-02T00:00:00.0000000' AS DateTime2), NULL, NULL, 0, 1)
INSERT [dbo].[BoMons] ([Id], [MaBoMon], [TenBoMon], [VanPhong], [DiaChi], [HomThu], [DienThoai], [NgayTao], [NgayCapNhat], [NgayXoa], [IsDelete], [IsActive]) VALUES (N'4323e0fb-dc71-421f-a9ef-f81a0125965e', N'0806', N'Tin học Kinh Tế', N'Phòng 708, tầng 7 nhà C12 tầng khu A Trường ĐH Mỏ - Địa chất', N'Số 18 Phố Viên, phường Đức Thắng, quận Bắc Từ Liêm, Hà Nội', N'tinhockinhte@humg.edu.vn', N'8437520643', CAST(N'2005-03-30T00:00:00.0000000' AS DateTime2), NULL, NULL, 0, 1)
INSERT [dbo].[BoMons] ([Id], [MaBoMon], [TenBoMon], [VanPhong], [DiaChi], [HomThu], [DienThoai], [NgayTao], [NgayCapNhat], [NgayXoa], [IsDelete], [IsActive]) VALUES (N'4db896a1-bba2-4c1f-8578-01a2f2cf0c04', N'9007', N'Lọc - Hóa dầu', N'Phòng 808, Nhà C12 tầng, Trường Đại học Mỏ - Địa chất', N'Số 18 Phố Viên, phường Đức Thắng, quận Bắc Từ Liêm, Hà Nội', N'lochoadau@humg.edu.vn', N'02437520220', CAST(N'2005-04-04T00:00:00.0000000' AS DateTime2), NULL, NULL, 0, 1)
INSERT [dbo].[BoMons] ([Id], [MaBoMon], [TenBoMon], [VanPhong], [DiaChi], [HomThu], [DienThoai], [NgayTao], [NgayCapNhat], [NgayXoa], [IsDelete], [IsActive]) VALUES (N'6c8f9a59-1155-4b1a-8517-c3125b21c562', N'0802', N'Hệ thống thông tin và tri thức', N'Phòng 706, tầng 7 nhà C12 tầng khu A Trường ĐH Mỏ - Địa chất', N'Số 18 Phố Viên, phường Đức Thắng, quận Bắc Từ Liêm, Hà Nội', N'hethongthongtintrithuc@humg.edu.vn', N'02437551109', CAST(N'2005-03-26T00:00:00.0000000' AS DateTime2), NULL, NULL, 0, 1)
INSERT [dbo].[BoMons] ([Id], [MaBoMon], [TenBoMon], [VanPhong], [DiaChi], [HomThu], [DienThoai], [NgayTao], [NgayCapNhat], [NgayXoa], [IsDelete], [IsActive]) VALUES (N'7bf67a54-ba9c-4298-8cff-fadb1dcf80c4', N'0807', N'Mạng máy tính', N'Phòng 705, tầng 7 nhà C12 tầng khu A Trường ĐH Mỏ - Địa chất', N'Số 18 Phố Viên, phường Đức Thắng, quận Bắc Từ Liêm, Hà Nội', N'mangmaytinh@humg.edu.vn', N'0422453709', CAST(N'2005-03-28T00:00:00.0000000' AS DateTime2), NULL, NULL, 0, 1)
INSERT [dbo].[BoMons] ([Id], [MaBoMon], [TenBoMon], [VanPhong], [DiaChi], [HomThu], [DienThoai], [NgayTao], [NgayCapNhat], [NgayXoa], [IsDelete], [IsActive]) VALUES (N'aed121f1-a6ad-4c91-85f8-5aa3e93aa34b', N'0801', N'Công nghệ Phần Mềm', N'Phòng 703, tầng 7 nhà C12 tầng khu A Trường ĐH Mỏ - Địa chất', N'Số 18 Phố Viên, phường Đức Thắng, quận Bắc Từ Liêm, Hà Nội', N'congnghephanmem@humg.edu.vn', N'8437521428', CAST(N'2005-03-25T00:00:00.0000000' AS DateTime2), NULL, NULL, 0, 1)
INSERT [dbo].[BoMons] ([Id], [MaBoMon], [TenBoMon], [VanPhong], [DiaChi], [HomThu], [DienThoai], [NgayTao], [NgayCapNhat], [NgayXoa], [IsDelete], [IsActive]) VALUES (N'aef1b30b-76c0-470d-a797-e94e7f7895b7', N'2205', N'Quản trị doanh nghiệp Mỏ', N'Phòng C12.05 nhà C12 tầng khu A Trường ĐH Mỏ - Địa chất', N'Số 18 Phố Viên, phường Đức Thắng, quận Bắc Từ Liêm, Hà Nội', N'quantridnmo@humg.edu.vn', N'02437550809', CAST(N'2005-04-07T00:00:00.0000000' AS DateTime2), NULL, NULL, 0, 1)
INSERT [dbo].[BoMons] ([Id], [MaBoMon], [TenBoMon], [VanPhong], [DiaChi], [HomThu], [DienThoai], [NgayTao], [NgayCapNhat], [NgayXoa], [IsDelete], [IsActive]) VALUES (N'b1018438-f837-4a1f-be50-a78213823676', N'10105', N'Kế toán doanh nghiệp', N'Phòng C12.07 nhà C12 tầng khu A Trường ĐH Mỏ - Địa chất', N'Số 18 Phố Viên, phường Đức Thắng, quận Bắc Từ Liêm, Hà Nội', N'ketoandn@humg.edu.vn', N'02437520358', CAST(N'2005-04-06T00:00:00.0000000' AS DateTime2), NULL, NULL, 0, 1)
INSERT [dbo].[BoMons] ([Id], [MaBoMon], [TenBoMon], [VanPhong], [DiaChi], [HomThu], [DienThoai], [NgayTao], [NgayCapNhat], [NgayXoa], [IsDelete], [IsActive]) VALUES (N'deef084b-4a9b-4aee-81c7-fc5bb4026be5', N'9006', N'Khoan - Khai thác', N'Phòng 806, Nhà C12 tầng, Trường Đại học Mỏ - Địa chất', N'Số 18 Phố Viên, phường Đức Thắng, quận Bắc Từ Liêm, Hà Nội', N'khoan-khaithac@humg.edu.vn', N'02422181323', CAST(N'2005-04-03T00:00:00.0000000' AS DateTime2), NULL, NULL, 0, 1)
INSERT [dbo].[BoMons] ([Id], [MaBoMon], [TenBoMon], [VanPhong], [DiaChi], [HomThu], [DienThoai], [NgayTao], [NgayCapNhat], [NgayXoa], [IsDelete], [IsActive]) VALUES (N'fb4d5d49-77fc-4885-9aa4-fa26513d52b2', N'0803', N'Tin học Trắc địa', N'Phòng 709, tầng 7 nhà C12 tầng khu A Trường ĐH Mỏ - Địa chất', N'Số 18 Phố Viên, phường Đức Thắng, quận Bắc Từ Liêm, Hà Nội', N'tinhoctracdia@humg.edu.vn', N'02437551112', CAST(N'2005-03-31T00:00:00.0000000' AS DateTime2), NULL, NULL, 0, 1)
INSERT [dbo].[BoMons] ([Id], [MaBoMon], [TenBoMon], [VanPhong], [DiaChi], [HomThu], [DienThoai], [NgayTao], [NgayCapNhat], [NgayXoa], [IsDelete], [IsActive]) VALUES (N'ff4df15d-14e3-4a40-9972-21af29dca3b6', N'0804', N'Tin học Địa Chất', N'Phòng 707, tầng 7 nhà C12 tầng khu A Trường ĐH Mỏ - Địa chất', N'Số 18 Phố Viên, phường Đức Thắng, quận Bắc Từ Liêm, Hà Nội', N'tindiachat@humg.edu.vn', N'0437551119', CAST(N'2005-03-29T00:00:00.0000000' AS DateTime2), NULL, NULL, 0, 1)
INSERT [dbo].[BoMons] ([Id], [MaBoMon], [TenBoMon], [VanPhong], [DiaChi], [HomThu], [DienThoai], [NgayTao], [NgayCapNhat], [NgayXoa], [IsDelete], [IsActive]) VALUES (N'sdasd2332', N'DCCTKT', N'tin kinh tees', N'c12 tang', N'123 co nhue', N'avbc@gmail.com', N'0123456789', CAST(N'2021-04-04T00:00:00.0000000' AS DateTime2), NULL, NULL, 0, 1)
GO
INSERT [dbo].[ChuongTrinhDaoTaos] ([Id], [MaChuongTrinhDaoTao], [TenChuongTrinhDaoTao], [IdNganh], [IdChuyenNganh], [IdKhoasDaoTao], [SoKy], [TrinhDoDaoTao], [HeDaoTao], [ThoiGianDaoTao], [SoTinChi], [IsDelete], [IsActive]) VALUES (N'0adbcfe0-2ef5-409f-8354-669e62556c18', N'7480201', N'Đào tạo chuẩn 4 năm ', N'8f06964a-fef2-4e11-8481-74eac292e36f', N'b73237ee-6b25-40a7-aa5e-ed11f218596b', N'9a73c320-2a88-4b8b-8736-0e989e0f7ce8', 8, N'Đại học', N'Chính quy tập trung', 4, 152, 0, 1)
INSERT [dbo].[ChuongTrinhDaoTaos] ([Id], [MaChuongTrinhDaoTao], [TenChuongTrinhDaoTao], [IdNganh], [IdChuyenNganh], [IdKhoasDaoTao], [SoKy], [TrinhDoDaoTao], [HeDaoTao], [ThoiGianDaoTao], [SoTinChi], [IsDelete], [IsActive]) VALUES (N'0ebd8b6e-c179-49aa-b80d-81ba3691a196', N'7480201', N'Đào tạo chuẩn 4 năm ', N'126b2cbe-3693-4cce-a6dd-a1b883f741b9', N'18ba6455-22bb-4db5-99c3-c88f5d9fe4ba', N'2e208ef3-7067-459b-b38b-408d3aaa4fc5', 8, N'Đại học', N'Chính quy tập trung', 4, 152, 0, 1)
INSERT [dbo].[ChuongTrinhDaoTaos] ([Id], [MaChuongTrinhDaoTao], [TenChuongTrinhDaoTao], [IdNganh], [IdChuyenNganh], [IdKhoasDaoTao], [SoKy], [TrinhDoDaoTao], [HeDaoTao], [ThoiGianDaoTao], [SoTinChi], [IsDelete], [IsActive]) VALUES (N'16397f2d-7b2d-4f28-a547-973d937cc87c', N'7480202', N'Đào tạo chuẩn 5 năm', N'22e78e45-cfc5-43e8-a08a-4c548f37f4d3', N'7e5ee162-d0b2-463e-9d49-f2edacf81993', N'd8c0dd18-233f-4948-ac16-52d9123cd020', 10, N'Đại học', N'Chính quy tập trung', 5, 164, 0, 1)
INSERT [dbo].[ChuongTrinhDaoTaos] ([Id], [MaChuongTrinhDaoTao], [TenChuongTrinhDaoTao], [IdNganh], [IdChuyenNganh], [IdKhoasDaoTao], [SoKy], [TrinhDoDaoTao], [HeDaoTao], [ThoiGianDaoTao], [SoTinChi], [IsDelete], [IsActive]) VALUES (N'192c1350-6a18-4e71-beeb-fb7da588e4ef', N'7480203', N'Đào tạo chuẩn 4,5 năm', N'26ec297a-4dd9-493c-8b9e-3eee539ba26a', N'5f70649e-e350-4bd6-aa0e-e41fdfe263c9', N'4efd2ac2-57d9-4e8a-ad3f-1e8c22f3b4e7', 9, N'Đại học', N'Chính quy tập trung', 4.5, 160, 0, 1)
INSERT [dbo].[ChuongTrinhDaoTaos] ([Id], [MaChuongTrinhDaoTao], [TenChuongTrinhDaoTao], [IdNganh], [IdChuyenNganh], [IdKhoasDaoTao], [SoKy], [TrinhDoDaoTao], [HeDaoTao], [ThoiGianDaoTao], [SoTinChi], [IsDelete], [IsActive]) VALUES (N'1b9b46a9-8db8-452a-b8d4-a0561255e899', N'7480202', N'Đào tạo chuẩn 5 năm', N'8f06964a-fef2-4e11-8481-74eac292e36f', N'b73237ee-6b25-40a7-aa5e-ed11f218596b', N'40278716-341a-490a-a17c-fa640a556cef', 10, N'Đại học', N'Chính quy tập trung', 5, 164, 0, 1)
INSERT [dbo].[ChuongTrinhDaoTaos] ([Id], [MaChuongTrinhDaoTao], [TenChuongTrinhDaoTao], [IdNganh], [IdChuyenNganh], [IdKhoasDaoTao], [SoKy], [TrinhDoDaoTao], [HeDaoTao], [ThoiGianDaoTao], [SoTinChi], [IsDelete], [IsActive]) VALUES (N'2cc0557a-e98f-46e0-a922-a63922155b91', N'7480203', N'Đào tạo chuẩn 4,5 năm', N'22e78e45-cfc5-43e8-a08a-4c548f37f4d3', N'7e5ee162-d0b2-463e-9d49-f2edacf81993', N'2c243df8-3a44-4dc3-aab1-eb3a90e15b75', 9, N'Đại học', N'Chính quy tập trung', 4.5, 160, 0, 1)
INSERT [dbo].[ChuongTrinhDaoTaos] ([Id], [MaChuongTrinhDaoTao], [TenChuongTrinhDaoTao], [IdNganh], [IdChuyenNganh], [IdKhoasDaoTao], [SoKy], [TrinhDoDaoTao], [HeDaoTao], [ThoiGianDaoTao], [SoTinChi], [IsDelete], [IsActive]) VALUES (N'37ee6be1-bcd6-47ef-a94a-4e97b66f0305', N'7480201', N'Đào tạo chuẩn 4 năm ', N'41cacf8e-e8e9-49e6-8b71-89cbb2396fa8', N'ea63558e-7ca0-4d85-9562-6c51b933ea10', N'10053fda-3036-4253-89a5-1d29dcf182ab', 8, N'Đại học', N'Chính quy tập trung', 4, 152, 0, 1)
INSERT [dbo].[ChuongTrinhDaoTaos] ([Id], [MaChuongTrinhDaoTao], [TenChuongTrinhDaoTao], [IdNganh], [IdChuyenNganh], [IdKhoasDaoTao], [SoKy], [TrinhDoDaoTao], [HeDaoTao], [ThoiGianDaoTao], [SoTinChi], [IsDelete], [IsActive]) VALUES (N'37f5bb21-f765-4cf1-ab27-7c1e05ccb8ed', N'7480203', N'Đào tạo chuẩn 4,5 năm', N'126b2cbe-3693-4cce-a6dd-a1b883f741b9', N'18ba6455-22bb-4db5-99c3-c88f5d9fe4ba', N'be74ffea-06c2-47f5-aa25-70e62b1873aa', 9, N'Đại học', N'Chính quy tập trung', 4.5, 160, 0, 1)
INSERT [dbo].[ChuongTrinhDaoTaos] ([Id], [MaChuongTrinhDaoTao], [TenChuongTrinhDaoTao], [IdNganh], [IdChuyenNganh], [IdKhoasDaoTao], [SoKy], [TrinhDoDaoTao], [HeDaoTao], [ThoiGianDaoTao], [SoTinChi], [IsDelete], [IsActive]) VALUES (N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'7480202', N'Đào tạo chuẩn 5 năm', N'8b4244fc-9604-483d-ab68-66cc1df154b4', N'f3947a40-caf9-4964-bfc3-65a0455a4516', N'332f7905-a3b0-44ab-a242-dc901741f9d6', 10, N'Đại học', N'Chính quy tập trung', 5, 164, 0, 1)
INSERT [dbo].[ChuongTrinhDaoTaos] ([Id], [MaChuongTrinhDaoTao], [TenChuongTrinhDaoTao], [IdNganh], [IdChuyenNganh], [IdKhoasDaoTao], [SoKy], [TrinhDoDaoTao], [HeDaoTao], [ThoiGianDaoTao], [SoTinChi], [IsDelete], [IsActive]) VALUES (N'506056f2-20b4-4617-addf-a8b92ec98528', N'7480202', N'Đào tạo chuẩn 5 năm', N'58a466eb-9e1a-4439-90b3-03d9e69b8b13', N'fa9eb6c6-436e-4609-921b-4d1acf3b94f2', N'1e992ea9-9249-49f7-8dc9-64564fc8d2d0', 10, N'Đại học', N'Chính quy tập trung', 5, 164, 0, 1)
INSERT [dbo].[ChuongTrinhDaoTaos] ([Id], [MaChuongTrinhDaoTao], [TenChuongTrinhDaoTao], [IdNganh], [IdChuyenNganh], [IdKhoasDaoTao], [SoKy], [TrinhDoDaoTao], [HeDaoTao], [ThoiGianDaoTao], [SoTinChi], [IsDelete], [IsActive]) VALUES (N'62d63aec-e67c-4342-8c2a-8adf464d626e', N'7480203', N'Đào tạo chuẩn 4,5 năm', N'8f06964a-fef2-4e11-8481-74eac292e36f', N'b73237ee-6b25-40a7-aa5e-ed11f218596b', N'a50223c0-d641-45e3-b748-830b0c45ab79', 9, N'Đại học', N'Chính quy tập trung', 4.5, 160, 0, 1)
INSERT [dbo].[ChuongTrinhDaoTaos] ([Id], [MaChuongTrinhDaoTao], [TenChuongTrinhDaoTao], [IdNganh], [IdChuyenNganh], [IdKhoasDaoTao], [SoKy], [TrinhDoDaoTao], [HeDaoTao], [ThoiGianDaoTao], [SoTinChi], [IsDelete], [IsActive]) VALUES (N'81a42cb4-c801-4769-be26-e64a82a585b1', N'7480203', N'Đào tạo chuẩn 4,5 năm', N'58a466eb-9e1a-4439-90b3-03d9e69b8b13', N'fa9eb6c6-436e-4609-921b-4d1acf3b94f2', N'1a9f3d04-84cc-49b4-ae20-80163cfd8bf7', 9, N'Đại học', N'Chính quy tập trung', 4.5, 160, 0, 1)
INSERT [dbo].[ChuongTrinhDaoTaos] ([Id], [MaChuongTrinhDaoTao], [TenChuongTrinhDaoTao], [IdNganh], [IdChuyenNganh], [IdKhoasDaoTao], [SoKy], [TrinhDoDaoTao], [HeDaoTao], [ThoiGianDaoTao], [SoTinChi], [IsDelete], [IsActive]) VALUES (N'8a1f0040-57e9-46ed-bfe6-d0f8722e5a29', N'7480203', N'Đào tạo chuẩn 4,5 năm', N'8b4244fc-9604-483d-ab68-66cc1df154b4', N'f3947a40-caf9-4964-bfc3-65a0455a4516', N'da1b81c4-4887-4e8f-810b-5d1453592942', 9, N'Đại học', N'Chính quy tập trung', 4.5, 160, 0, 1)
INSERT [dbo].[ChuongTrinhDaoTaos] ([Id], [MaChuongTrinhDaoTao], [TenChuongTrinhDaoTao], [IdNganh], [IdChuyenNganh], [IdKhoasDaoTao], [SoKy], [TrinhDoDaoTao], [HeDaoTao], [ThoiGianDaoTao], [SoTinChi], [IsDelete], [IsActive]) VALUES (N'9301b060-3a93-4325-a511-bc6637a16704', N'7480201', N'Đào tạo chuẩn 4 năm ', N'22e78e45-cfc5-43e8-a08a-4c548f37f4d3', N'7e5ee162-d0b2-463e-9d49-f2edacf81993', N'39e7cc4a-3112-4a46-b815-d03f4163899c', 8, N'Đại học', N'Chính quy tập trung', 4, 152, 0, 1)
INSERT [dbo].[ChuongTrinhDaoTaos] ([Id], [MaChuongTrinhDaoTao], [TenChuongTrinhDaoTao], [IdNganh], [IdChuyenNganh], [IdKhoasDaoTao], [SoKy], [TrinhDoDaoTao], [HeDaoTao], [ThoiGianDaoTao], [SoTinChi], [IsDelete], [IsActive]) VALUES (N'960bacdd-d4a1-40d2-97f2-a7212395f380', N'7480201', N'Đào tạo chuẩn 4 năm ', N'58a466eb-9e1a-4439-90b3-03d9e69b8b13', N'fa9eb6c6-436e-4609-921b-4d1acf3b94f2', N'7ed6e26f-712c-46b5-adfa-535e1d735aad', 8, N'Đại học', N'Chính quy tập trung', 4, 152, 0, 1)
INSERT [dbo].[ChuongTrinhDaoTaos] ([Id], [MaChuongTrinhDaoTao], [TenChuongTrinhDaoTao], [IdNganh], [IdChuyenNganh], [IdKhoasDaoTao], [SoKy], [TrinhDoDaoTao], [HeDaoTao], [ThoiGianDaoTao], [SoTinChi], [IsDelete], [IsActive]) VALUES (N'a13e4aab-ea33-4744-ae87-aca390f44be8', N'7480202', N'Đào tạo chuẩn 5 năm', N'26ec297a-4dd9-493c-8b9e-3eee539ba26a', N'5f70649e-e350-4bd6-aa0e-e41fdfe263c9', N'7be92ecd-b07e-4acc-8c4a-364d7a7b4ca2', 10, N'Đại học', N'Chính quy tập trung', 5, 164, 0, 1)
INSERT [dbo].[ChuongTrinhDaoTaos] ([Id], [MaChuongTrinhDaoTao], [TenChuongTrinhDaoTao], [IdNganh], [IdChuyenNganh], [IdKhoasDaoTao], [SoKy], [TrinhDoDaoTao], [HeDaoTao], [ThoiGianDaoTao], [SoTinChi], [IsDelete], [IsActive]) VALUES (N'a8bb0472-a07c-4015-baf0-6e469c41a2bb', N'7480201', N'Đào tạo chuẩn 4 năm ', N'8b4244fc-9604-483d-ab68-66cc1df154b4', N'f3947a40-caf9-4964-bfc3-65a0455a4516', N'46253b0a-f8df-4c03-bed6-cc235511b764', 8, N'Đại học', N'Chính quy tập trung', 4, 152, 0, 1)
INSERT [dbo].[ChuongTrinhDaoTaos] ([Id], [MaChuongTrinhDaoTao], [TenChuongTrinhDaoTao], [IdNganh], [IdChuyenNganh], [IdKhoasDaoTao], [SoKy], [TrinhDoDaoTao], [HeDaoTao], [ThoiGianDaoTao], [SoTinChi], [IsDelete], [IsActive]) VALUES (N'b5a94bb1-535e-45ae-80c8-63977abb5758', N'7480202', N'Đào tạo chuẩn 5 năm', N'126b2cbe-3693-4cce-a6dd-a1b883f741b9', N'18ba6455-22bb-4db5-99c3-c88f5d9fe4ba', N'fae5f1c1-243c-45af-969e-e312d2c38e1d', 10, N'Đại học', N'Chính quy tập trung', 5, 164, 0, 1)
INSERT [dbo].[ChuongTrinhDaoTaos] ([Id], [MaChuongTrinhDaoTao], [TenChuongTrinhDaoTao], [IdNganh], [IdChuyenNganh], [IdKhoasDaoTao], [SoKy], [TrinhDoDaoTao], [HeDaoTao], [ThoiGianDaoTao], [SoTinChi], [IsDelete], [IsActive]) VALUES (N'bc8a858c-9b83-4a53-bf69-595e00598a02', N'7480201', N'Đào tạo chuẩn 4 năm ', N'26ec297a-4dd9-493c-8b9e-3eee539ba26a', N'5f70649e-e350-4bd6-aa0e-e41fdfe263c9', N'f34c3394-8536-4394-b636-1896306bc403', 8, N'Đại học', N'Chính quy tập trung', 4, 152, 0, 1)
INSERT [dbo].[ChuongTrinhDaoTaos] ([Id], [MaChuongTrinhDaoTao], [TenChuongTrinhDaoTao], [IdNganh], [IdChuyenNganh], [IdKhoasDaoTao], [SoKy], [TrinhDoDaoTao], [HeDaoTao], [ThoiGianDaoTao], [SoTinChi], [IsDelete], [IsActive]) VALUES (N'f709454e-5993-41d3-a579-418739d2530a', N'7480203', N'Đào tạo chuẩn 4,5 năm', N'41cacf8e-e8e9-49e6-8b71-89cbb2396fa8', N'ea63558e-7ca0-4d85-9562-6c51b933ea10', N'e9043845-3c61-4b17-9c33-9a1550f2a8f3', 9, N'Đại học', N'Chính quy tập trung', 4.5, 160, 0, 1)
INSERT [dbo].[ChuongTrinhDaoTaos] ([Id], [MaChuongTrinhDaoTao], [TenChuongTrinhDaoTao], [IdNganh], [IdChuyenNganh], [IdKhoasDaoTao], [SoKy], [TrinhDoDaoTao], [HeDaoTao], [ThoiGianDaoTao], [SoTinChi], [IsDelete], [IsActive]) VALUES (N'f8dc63e3-c06f-4c09-93a9-3d3be044c7cb', N'7480202', N'Đào tạo chuẩn 5 năm', N'41cacf8e-e8e9-49e6-8b71-89cbb2396fa8', N'ea63558e-7ca0-4d85-9562-6c51b933ea10', N'314df73e-c32e-46cd-a4fa-50f095a25cd5', 10, N'Đại học', N'Chính quy tập trung', 5, 164, 0, 1)
GO
INSERT [dbo].[ChuyenNganhs] ([Id], [MaChuyenNganh], [TenChuyenNganh], [VanPhong], [HopThu], [DienThoai], [DiaChi], [GhiChu], [NgayCapNhat], [NgayTao], [IsDelete], [IsActive]) VALUES (N'06bf7ff9-a93b-43b6-8d61-da7773ad7c3b', N'0802', N'Hệ thống thông tin và tri thức', N'Phòng 706, tầng 7 nhà C12 tầng khu A Trường ĐH Mỏ - Địa chất', N'hethongthongtintrithuc@humg.edu.vn', N'02437551109', N'Số 18 Phố Viên, phường Đức Thắng, quận Bắc Từ Liêm, Hà Nội', NULL, NULL, CAST(N'2019-02-14T00:00:00.0000000' AS DateTime2), 1, 1)
INSERT [dbo].[ChuyenNganhs] ([Id], [MaChuyenNganh], [TenChuyenNganh], [VanPhong], [HopThu], [DienThoai], [DiaChi], [GhiChu], [NgayCapNhat], [NgayTao], [IsDelete], [IsActive]) VALUES (N'12142b40-7ab9-44b4-97a0-81a11df86c0f', N'0603', N'Khoan - Khai thác', N'Phòng 806, Nhà C12 tầng, Trường Đại học Mỏ - Địa chất', N'khoan-khaithac@humg.edu.vn', N'02422181323', N'Số 18 Phố Viên, phường Đức Thắng, quận Bắc Từ Liêm, Hà Nội', NULL, NULL, CAST(N'1962-01-01T00:00:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[ChuyenNganhs] ([Id], [MaChuyenNganh], [TenChuyenNganh], [VanPhong], [HopThu], [DienThoai], [DiaChi], [GhiChu], [NgayCapNhat], [NgayTao], [IsDelete], [IsActive]) VALUES (N'161c753d-3ca6-4299-97ec-f07d9691f789', N'0607', N'Quản trị doanh nghiệp Mỏ', N'Phòng C12.05 nhà C12 tầng khu A Trường ĐH Mỏ - Địa chất', N'quantridnmo@humg.edu.vn', N'02437550809', N'Số 18 Phố Viên, phường Đức Thắng, quận Bắc Từ Liêm, Hà Nội', NULL, NULL, CAST(N'1966-01-01T00:00:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[ChuyenNganhs] ([Id], [MaChuyenNganh], [TenChuyenNganh], [VanPhong], [HopThu], [DienThoai], [DiaChi], [GhiChu], [NgayCapNhat], [NgayTao], [IsDelete], [IsActive]) VALUES (N'2d9ad470-b8ff-4efd-b9b2-3112800ec38d', N'0801', N'Công nghệ Phần Mềm', N'Phòng 703, tầng 7 nhà C12 tầng khu A Trường ĐH Mỏ - Địa chất', N'congnghephanmem@humg.edu.vn', N'+8437521428', N'Số 18 Phố Viên, phường Đức Thắng, quận Bắc Từ Liêm, Hà Nội', NULL, NULL, CAST(N'2005-03-25T00:00:00.0000000' AS DateTime2), 1, 0)
INSERT [dbo].[ChuyenNganhs] ([Id], [MaChuyenNganh], [TenChuyenNganh], [VanPhong], [HopThu], [DienThoai], [DiaChi], [GhiChu], [NgayCapNhat], [NgayTao], [IsDelete], [IsActive]) VALUES (N'6259a0fe-34f0-41a4-9f1f-9cd30d61e507', N'0806', N'Tin học Kinh Tế', N'Phòng 708, tầng 7 nhà C12 tầng khu A Trường ĐH Mỏ - Địa chất', N'tinhockinhte@humg.edu.vn', N'8437520643', N'Số 18 Phố Viên, phường Đức Thắng, quận Bắc Từ Liêm, Hà Nội', NULL, NULL, CAST(N'2004-02-14T00:00:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[ChuyenNganhs] ([Id], [MaChuyenNganh], [TenChuyenNganh], [VanPhong], [HopThu], [DienThoai], [DiaChi], [GhiChu], [NgayCapNhat], [NgayTao], [IsDelete], [IsActive]) VALUES (N'7d5b7683-e5cc-4f50-99c8-08df9081379c', N'0602', N'Địa vật lý', N'Phòng 802, Nhà C12 tầng, Trường Đại học Mỏ - Địa chất', N'diavatly@humg.edu.vn', N'02432121646', N'Số 18 Phố Viên, phường Đức Thắng, quận Bắc Từ Liêm, Hà Nội', NULL, NULL, CAST(N'1966-12-28T00:00:00.0000000' AS DateTime2), 1, 0)
INSERT [dbo].[ChuyenNganhs] ([Id], [MaChuyenNganh], [TenChuyenNganh], [VanPhong], [HopThu], [DienThoai], [DiaChi], [GhiChu], [NgayCapNhat], [NgayTao], [IsDelete], [IsActive]) VALUES (N'881d50a8-9222-4b72-a21a-110ad9c8abab', N'0604', N'Lọc - Hóa dầu', N'Phòng 808, Nhà C12 tầng, Trường Đại học Mỏ - Địa chất', N'lochoadau@humg.edu.vn', N'02437520220', N'Số 18 Phố Viên, phường Đức Thắng, quận Bắc Từ Liêm, Hà Nội', NULL, NULL, CAST(N'1994-10-01T00:00:00.0000000' AS DateTime2), 1, 0)
INSERT [dbo].[ChuyenNganhs] ([Id], [MaChuyenNganh], [TenChuyenNganh], [VanPhong], [HopThu], [DienThoai], [DiaChi], [GhiChu], [NgayCapNhat], [NgayTao], [IsDelete], [IsActive]) VALUES (N'966a5447-829d-4621-8be7-39e6762af15e', N'0803', N'Tin học Trắc địa', N'Phòng 709, tầng 7 nhà C12 tầng khu A Trường ĐH Mỏ - Địa chất', N'tinhoctracdia@humg.edu.vn', N'02437551112', N'Số 18 Phố Viên, phường Đức Thắng, quận Bắc Từ Liêm, Hà Nội', NULL, NULL, CAST(N'2000-01-01T00:00:00.0000000' AS DateTime2), 1, 0)
INSERT [dbo].[ChuyenNganhs] ([Id], [MaChuyenNganh], [TenChuyenNganh], [VanPhong], [HopThu], [DienThoai], [DiaChi], [GhiChu], [NgayCapNhat], [NgayTao], [IsDelete], [IsActive]) VALUES (N'9d4ae719-afb3-4631-9827-64c7ac0eea21', N'0804', N'Tin học Địa Chất', N'Phòng 707, tầng 7 nhà C12 tầng khu A Trường ĐH Mỏ - Địa chất', N'tindiachat@humg.edu.vn', N'043.7551119', N'Số 18 Phố Viên, phường Đức Thắng, quận Bắc Từ Liêm, Hà Nội', NULL, NULL, CAST(N'2002-07-10T00:00:00.0000000' AS DateTime2), 0, 0)
INSERT [dbo].[ChuyenNganhs] ([Id], [MaChuyenNganh], [TenChuyenNganh], [VanPhong], [HopThu], [DienThoai], [DiaChi], [GhiChu], [NgayCapNhat], [NgayTao], [IsDelete], [IsActive]) VALUES (N'a1e2acb6-60c4-4efc-a612-29bad0fdeee6', N'0807', N'Mạng máy tính', N'Phòng 705, tầng 7 nhà C12 tầng khu A Trường ĐH Mỏ - Địa chất', N'mangmaytinh@humg.edu.vn', N'042 2453709', N'Số 18 Phố Viên, phường Đức Thắng, quận Bắc Từ Liêm, Hà Nội', NULL, NULL, CAST(N'2010-02-09T00:00:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[ChuyenNganhs] ([Id], [MaChuyenNganh], [TenChuyenNganh], [VanPhong], [HopThu], [DienThoai], [DiaChi], [GhiChu], [NgayCapNhat], [NgayTao], [IsDelete], [IsActive]) VALUES (N'ab3301be-8b5c-42f1-84a9-f9de2359025a', N'0805', N'Khoa học máy tính', N'Phòng 704, tầng 7 nhà C12 tầng khu A Trường ĐH Mỏ - Địa chất', N'khoahocmaytinh@humg.edu.vn', N'+8437551110', N'Số 18 Phố Viên, phường Đức Thắng, quận Bắc Từ Liêm, Hà Nội', NULL, NULL, CAST(N'2017-09-28T00:00:00.0000000' AS DateTime2), 0, 0)
INSERT [dbo].[ChuyenNganhs] ([Id], [MaChuyenNganh], [TenChuyenNganh], [VanPhong], [HopThu], [DienThoai], [DiaChi], [GhiChu], [NgayCapNhat], [NgayTao], [IsDelete], [IsActive]) VALUES (N'ac98b12d-68be-469a-8485-892168eb3568', N'0601', N'Địa chất dầu khí', N'Phòng 807, Nhà C12 tầng, Trường Đại học Mỏ - Địa chất', N'diachatdaukhi@humg.edu.vn', N'02437520009', N'Số 18 Phố Viên, phường Đức Thắng, quận Bắc Từ Liêm, Hà Nội', NULL, NULL, CAST(N'1966-12-28T00:00:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[ChuyenNganhs] ([Id], [MaChuyenNganh], [TenChuyenNganh], [VanPhong], [HopThu], [DienThoai], [DiaChi], [GhiChu], [NgayCapNhat], [NgayTao], [IsDelete], [IsActive]) VALUES (N'dd0b283d-ebb2-4210-94a9-db1bcbfbf553', N'0605', N'Thiết bị Dầu khí và Công trình', N'Phòng 803, Nhà C, Trường Đại học Mỏ - Địa chất', N'tbdaukhicongtrinh@humg.edu.vn', N'02437520962', N'Số 18 Phố Viên, phường Đức Thắng, quận Bắc Từ Liêm, Hà Nội', NULL, NULL, CAST(N'2004-02-12T00:00:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[ChuyenNganhs] ([Id], [MaChuyenNganh], [TenChuyenNganh], [VanPhong], [HopThu], [DienThoai], [DiaChi], [GhiChu], [NgayCapNhat], [NgayTao], [IsDelete], [IsActive]) VALUES (N'e2532a0a-c448-4955-bcd0-9a42ead1550c', N'0606', N'Kế toán doanh nghiệp', N'Phòng C12.07 nhà C12 tầng khu A Trường ĐH Mỏ - Địa chất', N'ketoandn@humg.edu.vn', N'02437520358', N'Số 18 Phố Viên, phường Đức Thắng, quận Bắc Từ Liêm, Hà Nội', NULL, NULL, CAST(N'2003-06-23T00:00:00.0000000' AS DateTime2), 1, 0)
GO
INSERT [dbo].[GiangViens] ([Id], [MaGiangVien], [HoDem], [Ten], [HoTen], [HomThu], [GhiChu], [DonViCongTac], [DienThoai], [SoDeTai], [IdThongTinChung], [TenThongTinChung], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'05837361-14a8-43a8-b261-773ced6e67c7', N'0828-01', N'Trương Xuân', N'Bình', N'Trương Xuân Bình', N'truõnguanbinh@humg.edu.vn', N'', N'Bộ môn Tin học Địa Chất', N'343650044', 5, N'e185cd01-9d30-478b-b0bc-37d4273df5f3', N'Tin học Địa Chất', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[GiangViens] ([Id], [MaGiangVien], [HoDem], [Ten], [HoTen], [HomThu], [GhiChu], [DonViCongTac], [DienThoai], [SoDeTai], [IdThongTinChung], [TenThongTinChung], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'08c98b3e-4545-4ca2-b16a-164943cb617d', N'0823-01', N'Phạm Đức', N'Hậu', N'Phạm Đức Hậu', N'phamduchau@humg.edu.vn', N'', N'Bộ môn Hệ thống thông tin và tri thức', N'343650039', 5, N'd9d571a1-89fb-487b-b71d-b78b7e96031a', N'Hệ thống thông tin và tri thức', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[GiangViens] ([Id], [MaGiangVien], [HoDem], [Ten], [HoTen], [HomThu], [GhiChu], [DonViCongTac], [DienThoai], [SoDeTai], [IdThongTinChung], [TenThongTinChung], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'0aae4709-1619-4eb5-b103-4e9bb2b8b1d0', N'0801-01', N'Dương Thị Hiền', N'Thanh', N'Dương Thị Hiền Thanh', N'duongthihienthanh@humg.edu.vn', N'', N'Bộ môn Tin học Kinh tế', N'982537982', 3, N'0f26bb6f-f2d8-472d-bdee-9f4d324affe9', N'Tin học Kinh Tế', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[GiangViens] ([Id], [MaGiangVien], [HoDem], [Ten], [HoTen], [HomThu], [GhiChu], [DonViCongTac], [DienThoai], [SoDeTai], [IdThongTinChung], [TenThongTinChung], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'11116878f-84b3-4e17-9b34-076209HFHSJH', N'1686868999', N'Phamj Quan', N'Hiển', N'Phạm Quang Hiển', N'6868999@edusoft.com.vn', N'test thông tin chung', NULL, N'0909090909', 8, N'11116878f-84b3-4e17-9b34-076209fkdfsdf', N'Thong tin chuyen nganh tin kinh tế', NULL, NULL, 0, 1)
INSERT [dbo].[GiangViens] ([Id], [MaGiangVien], [HoDem], [Ten], [HoTen], [HomThu], [GhiChu], [DonViCongTac], [DienThoai], [SoDeTai], [IdThongTinChung], [TenThongTinChung], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'2127516f-c374-480d-8e9c-fa86aae236df', N'0816-01', N'Phạm Văn', N'Đồng', N'Phạm Văn Đồng', N'phamvandong@humg.edu.vn', N'', N'Bộ môn Công Nghệ phầm mềm', N'357445777', 6, N'63a1864a-78ab-4218-857d-35a5789d1596', N'Công nghệ Phần Mềm', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[GiangViens] ([Id], [MaGiangVien], [HoDem], [Ten], [HoTen], [HomThu], [GhiChu], [DonViCongTac], [DienThoai], [SoDeTai], [IdThongTinChung], [TenThongTinChung], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'2befba8b-2e62-4bcb-b4de-4309eb32b7e6', N'0818-01', N'Hồ Thị Thảo', N'Trang', N'Hồ Thị Thảo Trang', N'hothithaotrang@humg.edu.vn', N'', N'Bộ môn Công Nghệ phầm mềm', N'343650033', 7, N'63a1864a-78ab-4218-857d-35a5789d1596', N'Công nghệ Phần Mềm', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[GiangViens] ([Id], [MaGiangVien], [HoDem], [Ten], [HoTen], [HomThu], [GhiChu], [DonViCongTac], [DienThoai], [SoDeTai], [IdThongTinChung], [TenThongTinChung], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'3211f46a-951a-40d5-a2be-147ecf5ad64c', N'0827-01', N'Nguyễn Thị Hải', N'Yến', N'Nguyễn Thị Hải Yến', N'nguyenthihaiyen@humg.edu.vn', N'', N'Bộ môn Tin học Địa Chất', N'343650043', 4, N'e185cd01-9d30-478b-b0bc-37d4273df5f3', N'Tin học Địa Chất', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[GiangViens] ([Id], [MaGiangVien], [HoDem], [Ten], [HoTen], [HomThu], [GhiChu], [DonViCongTac], [DienThoai], [SoDeTai], [IdThongTinChung], [TenThongTinChung], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'458e148d-aabd-4670-9617-d66bf1b44d97', N'0807-01', N'Vũ Thị Kim', N'Liên', N'Vũ Thị Kim Liên', N'vuthikimlien@humg.edu.vn', N'', N'Bộ môn Tin học Kinh tế', N'984603666', 3, N'0f26bb6f-f2d8-472d-bdee-9f4d324affe9', N'Tin học Kinh Tế', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[GiangViens] ([Id], [MaGiangVien], [HoDem], [Ten], [HoTen], [HomThu], [GhiChu], [DonViCongTac], [DienThoai], [SoDeTai], [IdThongTinChung], [TenThongTinChung], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'462070a7-81d1-4955-8366-1be180abb247', N'0826-01', N'Dương Chí', N'Thiện', N'Dương Chí Thiện', N'duongchithien@humg.edu.vn', N'', N'Bộ môn Hệ thống thông tin và tri thức', N'343650042', 2, N'd9d571a1-89fb-487b-b71d-b78b7e96031a', N'Hệ thống thông tin và tri thức', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[GiangViens] ([Id], [MaGiangVien], [HoDem], [Ten], [HoTen], [HomThu], [GhiChu], [DonViCongTac], [DienThoai], [SoDeTai], [IdThongTinChung], [TenThongTinChung], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'4652f227-9165-46a2-9e93-47fd46d5bbda', N'0806-01', N'Võ Thị Thu', N'Trang', N'Võ Thị Thu Trang', N'vothithutrang@humg.edu.vn', N'', N'Bộ môn Tin học Kinh tế', N'983888601', 8, N'0f26bb6f-f2d8-472d-bdee-9f4d324affe9', N'Tin học Kinh Tế', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[GiangViens] ([Id], [MaGiangVien], [HoDem], [Ten], [HoTen], [HomThu], [GhiChu], [DonViCongTac], [DienThoai], [SoDeTai], [IdThongTinChung], [TenThongTinChung], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'4f3361fd-749d-4ebf-9968-531d014f2c78', N'0815-01', N'Nguyễn Thế', N'Lộc', N'Nguyễn Thế Lộc', N'nguyentheloc@humg.edu.vn', N'', N'Bộ môn Công Nghệ phầm mềm', N'822685555', 5, N'63a1864a-78ab-4218-857d-35a5789d1596', N'Công nghệ Phần Mềm', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[GiangViens] ([Id], [MaGiangVien], [HoDem], [Ten], [HoTen], [HomThu], [GhiChu], [DonViCongTac], [DienThoai], [SoDeTai], [IdThongTinChung], [TenThongTinChung], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'50479ed5-0ad6-4fcb-93cf-17c4ec8b1510', N'0820-01', N'Phạm Đình', N'Tân', N'Phạm Đình Tân', N'phamdinhtan@humg.edu.vn', N'', N'Bộ môn Mạng máy tính', N'343650036', 6, N'1bf1a46b-9baa-4f11-a9e2-6c402b4b3f0b', N'Mạng máy tính', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[GiangViens] ([Id], [MaGiangVien], [HoDem], [Ten], [HoTen], [HomThu], [GhiChu], [DonViCongTac], [DienThoai], [SoDeTai], [IdThongTinChung], [TenThongTinChung], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'70d99664-4579-4223-ae0f-be6fcbb89e41', N'0808-01', N'Nguyễn Thu', N'Hằng', N'Nguyễn Thu Hằng', N'nguyenthuhang@humg.edu.vn', N'', N'Bộ môn Tin học Kinh tế', N'986375166', 5, N'0f26bb6f-f2d8-472d-bdee-9f4d324affe9', N'Tin học Kinh Tế', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[GiangViens] ([Id], [MaGiangVien], [HoDem], [Ten], [HoTen], [HomThu], [GhiChu], [DonViCongTac], [DienThoai], [SoDeTai], [IdThongTinChung], [TenThongTinChung], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'7f8f512f-8130-43da-8349-caa4bb43feed', N'0812-01', N'Nguyễn Thị Mai', N'Dung', N'Nguyễn Thị Mai Dung', N'nguyenthimaidung@humg.edu.vn', N'', N'Bộ môn Tin học Trắc địa', N'912644484', 2, N'e185cd01-9d30-478b-b0bc-37d4273df5f3', N'Tin học Địa Chất', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[GiangViens] ([Id], [MaGiangVien], [HoDem], [Ten], [HoTen], [HomThu], [GhiChu], [DonViCongTac], [DienThoai], [SoDeTai], [IdThongTinChung], [TenThongTinChung], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'8191233f-3dc4-4424-b6b2-cad32f4ef1e0', N'0817-01', N'Nguyễn Thị Hữu', N'Phương', N'Nguyễn Thị Hữu Phương', N'nguyenthihuuphuong@humg.edu.vn', N'', N'Bộ môn Công Nghệ phầm mềm', N'379612345', 6, N'63a1864a-78ab-4218-857d-35a5789d1596', N'Công nghệ Phần Mềm', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[GiangViens] ([Id], [MaGiangVien], [HoDem], [Ten], [HoTen], [HomThu], [GhiChu], [DonViCongTac], [DienThoai], [SoDeTai], [IdThongTinChung], [TenThongTinChung], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'9036e6c9-e19a-4880-ba7d-964fb4c31940', N'0802-01', N'Phạm Quang', N'Hiển', N'Phạm Quang Hiển', N'phamquanghien@humg.edu.vn', N'', N'Bộ môn Tin học Kinh tế', N'973876072', 5, N'0f26bb6f-f2d8-472d-bdee-9f4d324affe9', N'Tin học Kinh Tế', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[GiangViens] ([Id], [MaGiangVien], [HoDem], [Ten], [HoTen], [HomThu], [GhiChu], [DonViCongTac], [DienThoai], [SoDeTai], [IdThongTinChung], [TenThongTinChung], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'a5040d4b-a472-4f80-9626-c2797537f130', N'0820-01', N'Trần Thị Thu', N'Thúy', N'Trần Thị Thu Thúy', N'tranthithuthuy@humg.edu.vn', N'', N'Bộ môn Mạng máy tính', N'343650035', 5, N'1bf1a46b-9baa-4f11-a9e2-6c402b4b3f0b', N'Mạng máy tính', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[GiangViens] ([Id], [MaGiangVien], [HoDem], [Ten], [HoTen], [HomThu], [GhiChu], [DonViCongTac], [DienThoai], [SoDeTai], [IdThongTinChung], [TenThongTinChung], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'a79fd9fb-cd58-4507-add0-85a8207b614c', N'0825-01', N'Vũ Lan', N'Phương', N'Vũ Lan Phương', N'vulanphuong@humg.edu.vn', N'', N'Bộ môn Hệ thống thông tin và tri thức', N'343650041', 2, N'd9d571a1-89fb-487b-b71d-b78b7e96031a', N'Hệ thống thông tin và tri thức', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[GiangViens] ([Id], [MaGiangVien], [HoDem], [Ten], [HoTen], [HomThu], [GhiChu], [DonViCongTac], [DienThoai], [SoDeTai], [IdThongTinChung], [TenThongTinChung], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'a88f2d65-abc5-4c8f-8d20-9792e6f328e7', N'0830-01', N'Nguyễn Hoàng', N'Long', N'Nguyễn Hoàng Long', N'nguyenhoanglong@humg.edu.vn', N'', N'Bộ môn Tin học Trắc địa', N'343650046', 3, N'e185cd01-9d30-478b-b0bc-37d4273df5f3', N'Tin học Địa Chất', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[GiangViens] ([Id], [MaGiangVien], [HoDem], [Ten], [HoTen], [HomThu], [GhiChu], [DonViCongTac], [DienThoai], [SoDeTai], [IdThongTinChung], [TenThongTinChung], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'a9c9064b-cf5f-40c9-9f0f-d31373dd75e2', N'0819-01', N'Diêm Công', N'Hoàn', N'Diêm Công Hoàn', N'diemconghoan@humg.edu.vn', N'', N'Bộ môn Mạng máy tính', N'343650034', 3, N'1bf1a46b-9baa-4f11-a9e2-6c402b4b3f0b', N'Mạng máy tính', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[GiangViens] ([Id], [MaGiangVien], [HoDem], [Ten], [HoTen], [HomThu], [GhiChu], [DonViCongTac], [DienThoai], [SoDeTai], [IdThongTinChung], [TenThongTinChung], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'b173cdf8-30b4-4d9d-93ea-30caf5543c24', N'0805-01', N'Lê Thanh', N'Huệ', N'Lê Thanh Huệ', N'lethanhhue@humg.edu.vn', N'', N'Bộ môn Tin học Kinh tế', N'974887788', 5, N'0f26bb6f-f2d8-472d-bdee-9f4d324affe9', N'Tin học Kinh Tế', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[GiangViens] ([Id], [MaGiangVien], [HoDem], [Ten], [HoTen], [HomThu], [GhiChu], [DonViCongTac], [DienThoai], [SoDeTai], [IdThongTinChung], [TenThongTinChung], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'b1b80e6c-de41-4673-ab1d-f5641cf4a368', N'0811-01', N'Lê Hồng', N'Anh', N'Lê Hồng Anh', N'lehonganh@humg.edu.vn', N'', N'Bộ môn Khoa học máy tính', N'944555232', 5, N'eb03592b-8312-4bb7-9ea9-3022209b0061', N'Khoa học máy tính', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[GiangViens] ([Id], [MaGiangVien], [HoDem], [Ten], [HoTen], [HomThu], [GhiChu], [DonViCongTac], [DienThoai], [SoDeTai], [IdThongTinChung], [TenThongTinChung], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'b51eecab-1c1d-4f33-8249-a2a4d8489a5a', N'0829-01', N'Phạm An', N'Cương', N'Phạm An Cương', N'phamacuong@humg.edu.vn', N'', N'Bộ môn Tin học Địa Chất', N'343650045', 6, N'e185cd01-9d30-478b-b0bc-37d4273df5f3', N'Tin học Địa Chất', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[GiangViens] ([Id], [MaGiangVien], [HoDem], [Ten], [HoTen], [HomThu], [GhiChu], [DonViCongTac], [DienThoai], [SoDeTai], [IdThongTinChung], [TenThongTinChung], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'b891bb70-6800-46c9-a70b-eb7ec67d1845', N'0804-01', N'Phạm Thị', N'Nguyệt', N'Phạm Thị Nguyệt', N'phamthinguyet@humg.edu.vn', N'', N'Bộ môn Tin học Kinh tế', N'904170053', 3, N'0f26bb6f-f2d8-472d-bdee-9f4d324affe9', N'Tin học Kinh Tế', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[GiangViens] ([Id], [MaGiangVien], [HoDem], [Ten], [HoTen], [HomThu], [GhiChu], [DonViCongTac], [DienThoai], [SoDeTai], [IdThongTinChung], [TenThongTinChung], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'b9879622-73c3-4062-98bb-45f8a6417c2d', N'0813-01', N'Nguyễn Duy', N'Huy', N'Nguyễn Duy Huy', N'nguyenduyhuy@humg.edu.vn', N'', N'Bộ môn Khoa học máy tính', N'966219991', 3, N'eb03592b-8312-4bb7-9ea9-3022209b0061', N'Khoa học máy tính', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[GiangViens] ([Id], [MaGiangVien], [HoDem], [Ten], [HoTen], [HomThu], [GhiChu], [DonViCongTac], [DienThoai], [SoDeTai], [IdThongTinChung], [TenThongTinChung], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'bb7bc8c3-180c-440c-ba9e-d60ffc0f8820', N'0822-01', N'Đào Thị Thu', N'Vân', N'Đào Thị Thu Vân', N'daothithuvan@humg.edu.vn', N'', N'Bộ môn Hệ thống thông tin và tri thức', N'343650038', 4, N'd9d571a1-89fb-487b-b71d-b78b7e96031a', N'Hệ thống thông tin và tri thức', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[GiangViens] ([Id], [MaGiangVien], [HoDem], [Ten], [HoTen], [HomThu], [GhiChu], [DonViCongTac], [DienThoai], [SoDeTai], [IdThongTinChung], [TenThongTinChung], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'bc7368e2-61af-42fa-8819-511b66c7292c', N'0824-01', N'Bùi Thị Vân', N'Anh', N'Bùi Thị Vân Anh', N'buithivananh@humg.edu.vn', N'', N'Bộ môn Hệ thống thông tin và tri thức', N'343650040', 4, N'd9d571a1-89fb-487b-b71d-b78b7e96031a', N'Hệ thống thông tin và tri thức', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[GiangViens] ([Id], [MaGiangVien], [HoDem], [Ten], [HoTen], [HomThu], [GhiChu], [DonViCongTac], [DienThoai], [SoDeTai], [IdThongTinChung], [TenThongTinChung], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'be1c7f23-3e81-4308-a2e6-b06c90c56274', N'0810-01', N'Lê Văn', N'Ngọc', N'Lê Văn Ngọc', N'levanngoc@humg.edu.vn', N'', N'Bộ môn Khoa học máy tính', N'986243482', 6, N'eb03592b-8312-4bb7-9ea9-3022209b0061', N'Khoa học máy tính', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[GiangViens] ([Id], [MaGiangVien], [HoDem], [Ten], [HoTen], [HomThu], [GhiChu], [DonViCongTac], [DienThoai], [SoDeTai], [IdThongTinChung], [TenThongTinChung], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'bfad5ec0-a787-4540-ae19-f11d958ad3dc', N'0803-01', N'Nguyễn Thế', N'Bình', N'Nguyễn Thế Bình', N'nguyenthebinh@humg.edu.vn', N'', N'Bộ môn Tin học Kinh tế', N'917749754', 2, N'0f26bb6f-f2d8-472d-bdee-9f4d324affe9', N'Tin học Kinh Tế', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[GiangViens] ([Id], [MaGiangVien], [HoDem], [Ten], [HoTen], [HomThu], [GhiChu], [DonViCongTac], [DienThoai], [SoDeTai], [IdThongTinChung], [TenThongTinChung], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'd0dbe61a-347c-466b-9056-04bfbe46af76', N'0821-01', N'Đào Anh', N'Thư', N'Đào Anh Thư', N'daoanhthu@humg.edu.vn', N'', N'Bộ môn Mạng máy tính', N'343650037', 4, N'1bf1a46b-9baa-4f11-a9e2-6c402b4b3f0b', N'Mạng máy tính', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[GiangViens] ([Id], [MaGiangVien], [HoDem], [Ten], [HoTen], [HomThu], [GhiChu], [DonViCongTac], [DienThoai], [SoDeTai], [IdThongTinChung], [TenThongTinChung], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'd38dca63-4d2c-4b7b-ae55-79bda996779c', N'0814-01', N'Lê Văn', N'Hưng', N'Lê Văn Hưng', N'levanghung@humg.edu.vn', N'', N'Bộ môn Khoa học máy tính', N'833665555', 4, N'eb03592b-8312-4bb7-9ea9-3022209b0061', N'Khoa học máy tính', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[GiangViens] ([Id], [MaGiangVien], [HoDem], [Ten], [HoTen], [HomThu], [GhiChu], [DonViCongTac], [DienThoai], [SoDeTai], [IdThongTinChung], [TenThongTinChung], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'd5b56995-a769-4554-b8f5-6d52190d37f0', N'0809-01', N'Hoàng Anh', N'Đức', N'Hoàng Anh Đức', N'hoanganhduc@humg.edu.vn', N'', N'Bộ môn Khoa học máy tính', N'914775545', 8, N'eb03592b-8312-4bb7-9ea9-3022209b0061', N'Khoa học máy tính', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[GiangViens] ([Id], [MaGiangVien], [HoDem], [Ten], [HoTen], [HomThu], [GhiChu], [DonViCongTac], [DienThoai], [SoDeTai], [IdThongTinChung], [TenThongTinChung], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'ebbeac91-1630-430f-aae6-ebd068b9ee74', N'0831-01', N'Nguyễn Quang', N'Khánh', N'Nguyễn Quang Khánh', N'nguyenquangkhanh@humg.edu.vn', N'', N'Bộ môn Tin học Trắc địa', N'343650047', 2, N'e185cd01-9d30-478b-b0bc-37d4273df5f3', N'Tin học Địa Chất', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[GiangViens] ([Id], [MaGiangVien], [HoDem], [Ten], [HoTen], [HomThu], [GhiChu], [DonViCongTac], [DienThoai], [SoDeTai], [IdThongTinChung], [TenThongTinChung], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'f97a8fb7-6d7c-4bf2-a4fd-bf09db4eb059', N'0832-01', N'Trần Trung', N'Chuyên', N'Trần Trung Chuyên', N'trantrungchuyen@humg.edu.vn', N'', N'Bộ môn Tin học Trắc địa', N'343650048', 3, N'e185cd01-9d30-478b-b0bc-37d4273df5f3', N'Tin học Địa Chất', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), 0, 1)
GO
INSERT [dbo].[HocKys] ([Id], [MaHocKy], [TenHocKy]) VALUES (N'7c1115b7-d18c-49ac-9445-6b910d7fb1b2', N'6', N'Học kỳ 6')
INSERT [dbo].[HocKys] ([Id], [MaHocKy], [TenHocKy]) VALUES (N'80fc951a-f4e3-4659-a408-a501c08294b0', N'7', N'Học kỳ 7')
INSERT [dbo].[HocKys] ([Id], [MaHocKy], [TenHocKy]) VALUES (N'8978f3ed-c75e-4abb-bc44-cf97dd858b60', N'10', N'Học kỳ 10')
INSERT [dbo].[HocKys] ([Id], [MaHocKy], [TenHocKy]) VALUES (N'8978f3ed-c75e-4abb-bc44-cf97dd858b61', N'11', N'Tự chọn A')
INSERT [dbo].[HocKys] ([Id], [MaHocKy], [TenHocKy]) VALUES (N'8978f3ed-c75e-4abb-bc44-cf97dd858b62', N'12', N'Tự chọn B')
INSERT [dbo].[HocKys] ([Id], [MaHocKy], [TenHocKy]) VALUES (N'8978f3ed-c75e-4abb-bc44-cf97dd858b63', N'13', N'Tự chọn C')
INSERT [dbo].[HocKys] ([Id], [MaHocKy], [TenHocKy]) VALUES (N'8d0f2f7b-2c4e-44ad-8895-735a69e2283a', N'5', N'Học kỳ 5')
INSERT [dbo].[HocKys] ([Id], [MaHocKy], [TenHocKy]) VALUES (N'90ce6b98-8133-45eb-8182-8cc0649cd213', N'1', N'Học kỳ 1')
INSERT [dbo].[HocKys] ([Id], [MaHocKy], [TenHocKy]) VALUES (N'9679c6ec-ae42-47ae-ae72-73bf18f17303', N'3', N'Học kỳ 3')
INSERT [dbo].[HocKys] ([Id], [MaHocKy], [TenHocKy]) VALUES (N'c85e2f2e-dae8-4027-8bc1-270ea372e141', N'4', N'Học kỳ 4')
INSERT [dbo].[HocKys] ([Id], [MaHocKy], [TenHocKy]) VALUES (N'e1c2d3e1-bdd9-44bb-92a6-a51436f94205', N'9', N'Học kỳ 9')
INSERT [dbo].[HocKys] ([Id], [MaHocKy], [TenHocKy]) VALUES (N'edf488e0-e9ff-4b96-a276-d5a482b73d56', N'2', N'Học kỳ 2')
INSERT [dbo].[HocKys] ([Id], [MaHocKy], [TenHocKy]) VALUES (N'efab05ee-bf15-4386-88c9-d71a25304356', N'8', N'Học kỳ 8')
GO
INSERT [dbo].[Khoas] ([Id], [MaKhoa], [TenKhoa], [IsDelete], [IsActive], [NgayTao], [NgayCapNhat]) VALUES (N'00800d7c-12ba-4151-9540-b86789b1e71d', N'01CD', N'Cơ - Điện', 0, 1, NULL, NULL)
INSERT [dbo].[Khoas] ([Id], [MaKhoa], [TenKhoa], [IsDelete], [IsActive], [NgayTao], [NgayCapNhat]) VALUES (N'2c203642-547c-4005-93f5-44eac5e3b05c', N'08CNTT', N'Công Nghệ Thông Tin', 0, 1, NULL, NULL)
INSERT [dbo].[Khoas] ([Id], [MaKhoa], [TenKhoa], [IsDelete], [IsActive], [NgayTao], [NgayCapNhat]) VALUES (N'3b744517-08d3-4ab5-b386-55859e0bdfab', N'06DK', N'Dầu khí', 0, 1, NULL, NULL)
INSERT [dbo].[Khoas] ([Id], [MaKhoa], [TenKhoa], [IsDelete], [IsActive], [NgayTao], [NgayCapNhat]) VALUES (N'5c7d804a-3a08-48a3-8af8-c5a977399b87', N'09XD', N'Xây Dựng', 0, 1, NULL, NULL)
INSERT [dbo].[Khoas] ([Id], [MaKhoa], [TenKhoa], [IsDelete], [IsActive], [NgayTao], [NgayCapNhat]) VALUES (N'914cc2b4-2053-4a25-a816-eb542129de20', N'03MO', N'Mỏ ', 0, 1, NULL, NULL)
INSERT [dbo].[Khoas] ([Id], [MaKhoa], [TenKhoa], [IsDelete], [IsActive], [NgayTao], [NgayCapNhat]) VALUES (N'9d9365be-1aa1-48e4-9cfa-503c1851dbb4', N'07KTQT', N'Kinh tế - Quản trị kinh doanh', 0, 1, NULL, NULL)
INSERT [dbo].[Khoas] ([Id], [MaKhoa], [TenKhoa], [IsDelete], [IsActive], [NgayTao], [NgayCapNhat]) VALUES (N'9dda924d-6b60-4b24-813e-f94cd59860ab', N'05TDBD', N'Trắc địa - Bản đồ và Quản lý đất đai', 0, 1, NULL, NULL)
INSERT [dbo].[Khoas] ([Id], [MaKhoa], [TenKhoa], [IsDelete], [IsActive], [NgayTao], [NgayCapNhat]) VALUES (N'd7728db2-edbd-4cc6-9bf1-d9aba34ed7d4', N'04KTDCC', N'Khoa học và Kỹ thuật Địa Chất', 0, 1, NULL, NULL)
INSERT [dbo].[Khoas] ([Id], [MaKhoa], [TenKhoa], [IsDelete], [IsActive], [NgayTao], [NgayCapNhat]) VALUES (N'e1355cb4-9ada-46d5-943d-40d48d781f32', N'02MT', N'Môi Trường', 0, 1, NULL, NULL)
INSERT [dbo].[Khoas] ([Id], [MaKhoa], [TenKhoa], [IsDelete], [IsActive], [NgayTao], [NgayCapNhat]) VALUES (N'sadsads3234', N'TKT112', N'TIN KINH TE', 0, 1, CAST(N'2021-04-04T00:00:00.0000000' AS DateTime2), NULL)
GO
INSERT [dbo].[KhoasDaoTaos] ([Id], [MaKhoasDaoTao], [TenKhoasDaoTao], [ThoiGianDaoTao], [IdChuongTringDaoTao]) VALUES (N'1e992ea9-9249-49f7-8dc9-64564fc8d2d0', N'K61', N'Khóa 61', N'5 năm', N'fa9eb6c6-436e-4609-921b-4d1acf3b94f2')
INSERT [dbo].[KhoasDaoTaos] ([Id], [MaKhoasDaoTao], [TenKhoasDaoTao], [ThoiGianDaoTao], [IdChuongTringDaoTao]) VALUES (N'314df73e-c32e-46cd-a4fa-50f095a25cd5', N'K61', N'Khóa 61', N'5 năm', N'ea63558e-7ca0-4d85-9562-6c51b933ea10')
INSERT [dbo].[KhoasDaoTaos] ([Id], [MaKhoasDaoTao], [TenKhoasDaoTao], [ThoiGianDaoTao], [IdChuongTringDaoTao]) VALUES (N'd8c0dd18-233f-4948-ac16-52d9123cd020', N'K61', N'Khóa 61', N'5 năm', N'7e5ee162-d0b2-463e-9d49-f2edacf81993')
INSERT [dbo].[KhoasDaoTaos] ([Id], [MaKhoasDaoTao], [TenKhoasDaoTao], [ThoiGianDaoTao], [IdChuongTringDaoTao]) VALUES (N'7be92ecd-b07e-4acc-8c4a-364d7a7b4ca2', N'K61', N'Khóa 61', N'5 năm', N'5f70649e-e350-4bd6-aa0e-e41fdfe263c9')
INSERT [dbo].[KhoasDaoTaos] ([Id], [MaKhoasDaoTao], [TenKhoasDaoTao], [ThoiGianDaoTao], [IdChuongTringDaoTao]) VALUES (N'fae5f1c1-243c-45af-969e-e312d2c38e1d', N'K61', N'Khóa 61', N'5 năm', N'18ba6455-22bb-4db5-99c3-c88f5d9fe4ba')
INSERT [dbo].[KhoasDaoTaos] ([Id], [MaKhoasDaoTao], [TenKhoasDaoTao], [ThoiGianDaoTao], [IdChuongTringDaoTao]) VALUES (N'332f7905-a3b0-44ab-a242-dc901741f9d6', N'K61', N'Khóa 61', N'5 năm', N'f3947a40-caf9-4964-bfc3-65a0455a4516')
INSERT [dbo].[KhoasDaoTaos] ([Id], [MaKhoasDaoTao], [TenKhoasDaoTao], [ThoiGianDaoTao], [IdChuongTringDaoTao]) VALUES (N'40278716-341a-490a-a17c-fa640a556cef', N'K61', N'Khóa 61', N'5 năm', N'b73237ee-6b25-40a7-aa5e-ed11f218596b')
INSERT [dbo].[KhoasDaoTaos] ([Id], [MaKhoasDaoTao], [TenKhoasDaoTao], [ThoiGianDaoTao], [IdChuongTringDaoTao]) VALUES (N'e280f580-f24c-4409-9e17-bbdbf3805949', N'K62', N'Khóa 62', N'5 năm', N'fa9eb6c6-436e-4609-921b-4d1acf3b94f2')
INSERT [dbo].[KhoasDaoTaos] ([Id], [MaKhoasDaoTao], [TenKhoasDaoTao], [ThoiGianDaoTao], [IdChuongTringDaoTao]) VALUES (N'556a79e9-f8c4-4916-8ea3-883807c0c8f8', N'K62', N'Khóa 62', N'5 năm', N'ea63558e-7ca0-4d85-9562-6c51b933ea10')
INSERT [dbo].[KhoasDaoTaos] ([Id], [MaKhoasDaoTao], [TenKhoasDaoTao], [ThoiGianDaoTao], [IdChuongTringDaoTao]) VALUES (N'2b1dd51a-f1b0-49ef-9bd3-1ccd736c5ea1', N'K62', N'Khóa 62', N'5 năm', N'7e5ee162-d0b2-463e-9d49-f2edacf81993')
INSERT [dbo].[KhoasDaoTaos] ([Id], [MaKhoasDaoTao], [TenKhoasDaoTao], [ThoiGianDaoTao], [IdChuongTringDaoTao]) VALUES (N'18c8d800-298b-4a00-9717-1123f2d9a1fd', N'K62', N'Khóa 62', N'5 năm', N'5f70649e-e350-4bd6-aa0e-e41fdfe263c9')
INSERT [dbo].[KhoasDaoTaos] ([Id], [MaKhoasDaoTao], [TenKhoasDaoTao], [ThoiGianDaoTao], [IdChuongTringDaoTao]) VALUES (N'504f8614-32e2-418a-96b5-f8d087b65496', N'K62', N'Khóa 62', N'5 năm', N'18ba6455-22bb-4db5-99c3-c88f5d9fe4ba')
INSERT [dbo].[KhoasDaoTaos] ([Id], [MaKhoasDaoTao], [TenKhoasDaoTao], [ThoiGianDaoTao], [IdChuongTringDaoTao]) VALUES (N'd742ba69-6302-428c-8c83-6f91cc07be1a', N'K62', N'Khóa 62', N'5 năm', N'f3947a40-caf9-4964-bfc3-65a0455a4516')
INSERT [dbo].[KhoasDaoTaos] ([Id], [MaKhoasDaoTao], [TenKhoasDaoTao], [ThoiGianDaoTao], [IdChuongTringDaoTao]) VALUES (N'fead0fb8-72a9-428d-bec7-3050f3444d80', N'K62', N'Khóa 62', N'5 năm', N'b73237ee-6b25-40a7-aa5e-ed11f218596b')
INSERT [dbo].[KhoasDaoTaos] ([Id], [MaKhoasDaoTao], [TenKhoasDaoTao], [ThoiGianDaoTao], [IdChuongTringDaoTao]) VALUES (N'7ed6e26f-712c-46b5-adfa-535e1d735aad', N'K63', N'Khóa 63', N'4 năm', N'fa9eb6c6-436e-4609-921b-4d1acf3b94f2')
INSERT [dbo].[KhoasDaoTaos] ([Id], [MaKhoasDaoTao], [TenKhoasDaoTao], [ThoiGianDaoTao], [IdChuongTringDaoTao]) VALUES (N'10053fda-3036-4253-89a5-1d29dcf182ab', N'K63', N'Khóa 63', N'4 năm', N'ea63558e-7ca0-4d85-9562-6c51b933ea10')
INSERT [dbo].[KhoasDaoTaos] ([Id], [MaKhoasDaoTao], [TenKhoasDaoTao], [ThoiGianDaoTao], [IdChuongTringDaoTao]) VALUES (N'39e7cc4a-3112-4a46-b815-d03f4163899c', N'K63', N'Khóa 63', N'4 năm', N'7e5ee162-d0b2-463e-9d49-f2edacf81993')
INSERT [dbo].[KhoasDaoTaos] ([Id], [MaKhoasDaoTao], [TenKhoasDaoTao], [ThoiGianDaoTao], [IdChuongTringDaoTao]) VALUES (N'f34c3394-8536-4394-b636-1896306bc403', N'K63', N'Khóa 63', N'4 năm', N'5f70649e-e350-4bd6-aa0e-e41fdfe263c9')
INSERT [dbo].[KhoasDaoTaos] ([Id], [MaKhoasDaoTao], [TenKhoasDaoTao], [ThoiGianDaoTao], [IdChuongTringDaoTao]) VALUES (N'2e208ef3-7067-459b-b38b-408d3aaa4fc5', N'K63', N'Khóa 63', N'4 năm', N'18ba6455-22bb-4db5-99c3-c88f5d9fe4ba')
INSERT [dbo].[KhoasDaoTaos] ([Id], [MaKhoasDaoTao], [TenKhoasDaoTao], [ThoiGianDaoTao], [IdChuongTringDaoTao]) VALUES (N'46253b0a-f8df-4c03-bed6-cc235511b764', N'K63', N'Khóa 63', N'4 năm', N'f3947a40-caf9-4964-bfc3-65a0455a4516')
INSERT [dbo].[KhoasDaoTaos] ([Id], [MaKhoasDaoTao], [TenKhoasDaoTao], [ThoiGianDaoTao], [IdChuongTringDaoTao]) VALUES (N'9a73c320-2a88-4b8b-8736-0e989e0f7ce8', N'K63', N'Khóa 63', N'4 năm', N'b73237ee-6b25-40a7-aa5e-ed11f218596b')
INSERT [dbo].[KhoasDaoTaos] ([Id], [MaKhoasDaoTao], [TenKhoasDaoTao], [ThoiGianDaoTao], [IdChuongTringDaoTao]) VALUES (N'1a9f3d04-84cc-49b4-ae20-80163cfd8bf7', N'K64', N'Khóa 64', N'4,5 năm', N'fa9eb6c6-436e-4609-921b-4d1acf3b94f2')
INSERT [dbo].[KhoasDaoTaos] ([Id], [MaKhoasDaoTao], [TenKhoasDaoTao], [ThoiGianDaoTao], [IdChuongTringDaoTao]) VALUES (N'e9043845-3c61-4b17-9c33-9a1550f2a8f3', N'K64', N'Khóa 64', N'4,5 năm', N'ea63558e-7ca0-4d85-9562-6c51b933ea10')
INSERT [dbo].[KhoasDaoTaos] ([Id], [MaKhoasDaoTao], [TenKhoasDaoTao], [ThoiGianDaoTao], [IdChuongTringDaoTao]) VALUES (N'2c243df8-3a44-4dc3-aab1-eb3a90e15b75', N'K64', N'Khóa 64', N'4,5 năm', N'7e5ee162-d0b2-463e-9d49-f2edacf81993')
INSERT [dbo].[KhoasDaoTaos] ([Id], [MaKhoasDaoTao], [TenKhoasDaoTao], [ThoiGianDaoTao], [IdChuongTringDaoTao]) VALUES (N'4efd2ac2-57d9-4e8a-ad3f-1e8c22f3b4e7', N'K64', N'Khóa 64', N'4,5 năm', N'5f70649e-e350-4bd6-aa0e-e41fdfe263c9')
INSERT [dbo].[KhoasDaoTaos] ([Id], [MaKhoasDaoTao], [TenKhoasDaoTao], [ThoiGianDaoTao], [IdChuongTringDaoTao]) VALUES (N'be74ffea-06c2-47f5-aa25-70e62b1873aa', N'K64', N'Khóa 64', N'4,5 năm', N'18ba6455-22bb-4db5-99c3-c88f5d9fe4ba')
INSERT [dbo].[KhoasDaoTaos] ([Id], [MaKhoasDaoTao], [TenKhoasDaoTao], [ThoiGianDaoTao], [IdChuongTringDaoTao]) VALUES (N'da1b81c4-4887-4e8f-810b-5d1453592942', N'K64', N'Khóa 64', N'4,5 năm', N'f3947a40-caf9-4964-bfc3-65a0455a4516')
INSERT [dbo].[KhoasDaoTaos] ([Id], [MaKhoasDaoTao], [TenKhoasDaoTao], [ThoiGianDaoTao], [IdChuongTringDaoTao]) VALUES (N'a50223c0-d641-45e3-b748-830b0c45ab79', N'K64', N'Khóa 64', N'4,5 năm', N'b73237ee-6b25-40a7-aa5e-ed11f218596b')
GO
INSERT [dbo].[LoaiMonHocs] ([Id], [MaLoai], [TenLoaiMonHoc]) VALUES (N'388111bf-1321-46fc-901a-dcaea2c15000', N'10001', N'Học phần chính')
INSERT [dbo].[LoaiMonHocs] ([Id], [MaLoai], [TenLoaiMonHoc]) VALUES (N'524ede90-c112-431a-bb0d-a171a2ead791', N'10002', N'Tự Chọn A')
INSERT [dbo].[LoaiMonHocs] ([Id], [MaLoai], [TenLoaiMonHoc]) VALUES (N'2f872943-9a13-4933-ab71-3c687a83ecaa', N'10003', N'Tự Chọn B')
INSERT [dbo].[LoaiMonHocs] ([Id], [MaLoai], [TenLoaiMonHoc]) VALUES (N'aca57e50-904e-4591-86dd-b36cfe52468b', N'10004', N'Tự Chọn C')
INSERT [dbo].[LoaiMonHocs] ([Id], [MaLoai], [TenLoaiMonHoc]) VALUES (N'dc4fc47e-bb43-4c5d-9c61-299506278ba0', N'10005', N'Quốc Phòng')
INSERT [dbo].[LoaiMonHocs] ([Id], [MaLoai], [TenLoaiMonHoc]) VALUES (N'11db8e1e-c8e9-4a24-b35b-a47b436c3780', N'10006', N'Thể Chất')
GO
INSERT [dbo].[LopHocs] ([Id], [MaLop], [TenLop], [IdThongTinChung], [IdChuongTrinhDaoTao], [IdKhoasDaoTao], [MaChuyenNganh], [MaChuongTrinhDaoTao], [NienKhoa], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'041fca20-f848-4966-870c-e97c5f74a292', N'DCCTKH64A', N'Khoa học máy tính K64_A', N'eb03592b-8312-4bb7-9ea9-3022209b0061', N'2cc0557a-e98f-46e0-a922-a63922155b91', N'2c243df8-3a44-4dc3-aab1-eb3a90e15b75', N'805', N'7480203', N'', CAST(N'2019-09-01T00:00:00.0000000' AS DateTime2), NULL, 0, 1)
INSERT [dbo].[LopHocs] ([Id], [MaLop], [TenLop], [IdThongTinChung], [IdChuongTrinhDaoTao], [IdKhoasDaoTao], [MaChuyenNganh], [MaChuongTrinhDaoTao], [NienKhoa], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'0745b36a-126d-429a-893a-ba17f476e901', N'DCCTPM62A', N'Công nghệ phần mềm K62_A', N'63a1864a-78ab-4218-857d-35a5789d1596', N'506056f2-20b4-4617-addf-a8b92ec98528', N'e280f580-f24c-4409-9e17-bbdbf3805949', N'801', N'7480203', N'', CAST(N'2016-11-01T00:00:00.0000000' AS DateTime2), NULL, 0, 1)
INSERT [dbo].[LopHocs] ([Id], [MaLop], [TenLop], [IdThongTinChung], [IdChuongTrinhDaoTao], [IdKhoasDaoTao], [MaChuyenNganh], [MaChuongTrinhDaoTao], [NienKhoa], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'0c611a70-6934-4b68-b87b-4de13c6fd280', N'DCCTKH63', N'Khoa học máy tính K63', N'eb03592b-8312-4bb7-9ea9-3022209b0061', N'9301b060-3a93-4325-a511-bc6637a16704', N'39e7cc4a-3112-4a46-b815-d03f4163899c', N'805', N'7480201', N'', CAST(N'2018-09-01T00:00:00.0000000' AS DateTime2), NULL, 0, 1)
INSERT [dbo].[LopHocs] ([Id], [MaLop], [TenLop], [IdThongTinChung], [IdChuongTrinhDaoTao], [IdKhoasDaoTao], [MaChuyenNganh], [MaChuongTrinhDaoTao], [NienKhoa], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'29a2bbc7-0082-46b9-91e5-d0059f87ee92', N'DCCTKT63', N'Tin học kinh tế K63', N'0f26bb6f-f2d8-472d-bdee-9f4d324affe9', N'a8bb0472-a07c-4015-baf0-6e469c41a2bb', N'46253b0a-f8df-4c03-bed6-cc235511b764', N'806', N'7480201', N'', CAST(N'2018-09-01T00:00:00.0000000' AS DateTime2), NULL, 0, 1)
INSERT [dbo].[LopHocs] ([Id], [MaLop], [TenLop], [IdThongTinChung], [IdChuongTrinhDaoTao], [IdKhoasDaoTao], [MaChuyenNganh], [MaChuongTrinhDaoTao], [NienKhoa], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'51fb8d2a-c509-43ca-99db-d2c6f4514d3c', N'DCCTKT61', N'Tin học kinh tế K61', N'0f26bb6f-f2d8-472d-bdee-9f4d324affe9', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d6', N'806', N'7480203', N'', CAST(N'2016-09-01T00:00:00.0000000' AS DateTime2), NULL, 0, 1)
INSERT [dbo].[LopHocs] ([Id], [MaLop], [TenLop], [IdThongTinChung], [IdChuongTrinhDaoTao], [IdKhoasDaoTao], [MaChuyenNganh], [MaChuongTrinhDaoTao], [NienKhoa], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'53421994-e2e9-4392-8f16-9c99798f3138', N'DCCTHT63A', N'Hệ thống thông tin K63_A', N'd9d571a1-89fb-487b-b71d-b78b7e96031a', N'37ee6be1-bcd6-47ef-a94a-4e97b66f0305', N'10053fda-3036-4253-89a5-1d29dcf182ab', N'802', N'7480201', N'', CAST(N'2018-09-01T00:00:00.0000000' AS DateTime2), NULL, 0, 1)
INSERT [dbo].[LopHocs] ([Id], [MaLop], [TenLop], [IdThongTinChung], [IdChuongTrinhDaoTao], [IdKhoasDaoTao], [MaChuyenNganh], [MaChuongTrinhDaoTao], [NienKhoa], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'58d4d113-d9f1-40b7-a95b-4d58d7496b08', N'DCCTPM60', N'Công nghệ phần mềm K60', N'63a1864a-78ab-4218-857d-35a5789d1596', N'506056f2-20b4-4617-addf-a8b92ec98528', N'1e992ea9-9249-49f7-8dc9-64564fc8d2d0', N'801', N'7480203', N'', CAST(N'2016-10-01T00:00:00.0000000' AS DateTime2), NULL, 0, 1)
INSERT [dbo].[LopHocs] ([Id], [MaLop], [TenLop], [IdThongTinChung], [IdChuongTrinhDaoTao], [IdKhoasDaoTao], [MaChuyenNganh], [MaChuongTrinhDaoTao], [NienKhoa], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'5a526226-afc3-47bd-9e24-cc0dc3b33aab', N'DCCTMM61B', N'Mạng máy tính K61_B', N'1bf1a46b-9baa-4f11-a9e2-6c402b4b3f0b', N'a13e4aab-ea33-4744-ae87-aca390f44be8', N'7be92ecd-b07e-4acc-8c4a-364d7a7b4ca2', N'807', N'7480203', N'', CAST(N'2018-09-01T00:00:00.0000000' AS DateTime2), NULL, 0, 1)
INSERT [dbo].[LopHocs] ([Id], [MaLop], [TenLop], [IdThongTinChung], [IdChuongTrinhDaoTao], [IdKhoasDaoTao], [MaChuyenNganh], [MaChuongTrinhDaoTao], [NienKhoa], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'5d496c6d-b4af-498d-b3c5-d271c46abaca', N'DCCTPM63A', N'Công nghệ phần mềm K63_A', N'63a1864a-78ab-4218-857d-35a5789d1596', N'960bacdd-d4a1-40d2-97f2-a7212395f380', N'7ed6e26f-712c-46b5-adfa-535e1d735aad', N'801', N'7480201', N'', CAST(N'2018-09-01T00:00:00.0000000' AS DateTime2), NULL, 0, 1)
INSERT [dbo].[LopHocs] ([Id], [MaLop], [TenLop], [IdThongTinChung], [IdChuongTrinhDaoTao], [IdKhoasDaoTao], [MaChuyenNganh], [MaChuongTrinhDaoTao], [NienKhoa], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'874f88be-9eaf-41a2-bd0d-767c17b86fe9', N'DCCTMM64B', N'Mạng máy tính K64_B', N'1bf1a46b-9baa-4f11-a9e2-6c402b4b3f0b', N'192c1350-6a18-4e71-beeb-fb7da588e4ef', N'4efd2ac2-57d9-4e8a-ad3f-1e8c22f3b4e7', N'807', N'7480203', N'', CAST(N'2018-09-01T00:00:00.0000000' AS DateTime2), NULL, 0, 1)
INSERT [dbo].[LopHocs] ([Id], [MaLop], [TenLop], [IdThongTinChung], [IdChuongTrinhDaoTao], [IdKhoasDaoTao], [MaChuyenNganh], [MaChuongTrinhDaoTao], [NienKhoa], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'9f5f8eae-7334-4420-8b19-7c5046af71f8', N'DCCTMM63C', N'Mạng máy tính K63_C', N'1bf1a46b-9baa-4f11-a9e2-6c402b4b3f0b', N'bc8a858c-9b83-4a53-bf69-595e00598a02', N'f34c3394-8536-4394-b636-1896306bc403', N'807', N'7480201', N'', CAST(N'2016-09-01T00:00:00.0000000' AS DateTime2), NULL, 0, 1)
INSERT [dbo].[LopHocs] ([Id], [MaLop], [TenLop], [IdThongTinChung], [IdChuongTrinhDaoTao], [IdKhoasDaoTao], [MaChuyenNganh], [MaChuongTrinhDaoTao], [NienKhoa], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'a055906d-2c57-401c-a495-da09b88d10ca', N'DCCTPM63B', N'Công nghệ phần mềm K63_B', N'63a1864a-78ab-4218-857d-35a5789d1596', N'960bacdd-d4a1-40d2-97f2-a7212395f380', N'7ed6e26f-712c-46b5-adfa-535e1d735aad', N'801', N'7480201', N'', CAST(N'2018-09-01T00:00:00.0000000' AS DateTime2), NULL, 0, 1)
INSERT [dbo].[LopHocs] ([Id], [MaLop], [TenLop], [IdThongTinChung], [IdChuongTrinhDaoTao], [IdKhoasDaoTao], [MaChuyenNganh], [MaChuongTrinhDaoTao], [NienKhoa], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'a2fa7131-3fa3-4d8d-ba97-27a158ab4501', N'DCCTKT62A', N'Tin học kinh tế K62_A', N'0f26bb6f-f2d8-472d-bdee-9f4d324affe9', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'd742ba69-6302-428c-8c83-6f91cc07be1a', N'806', N'7480203', N'', CAST(N'2017-09-01T00:00:00.0000000' AS DateTime2), NULL, 0, 1)
INSERT [dbo].[LopHocs] ([Id], [MaLop], [TenLop], [IdThongTinChung], [IdChuongTrinhDaoTao], [IdKhoasDaoTao], [MaChuyenNganh], [MaChuongTrinhDaoTao], [NienKhoa], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'c7718a8d-ee8f-4015-b4c6-aa1534ea9471', N'DCCTKT62B', N'Tin học kinh tế K62_B', N'0f26bb6f-f2d8-472d-bdee-9f4d324affe9', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'd742ba69-6302-428c-8c83-6f91cc07be1a', N'806', N'7480203', N'', CAST(N'2017-09-01T00:00:00.0000000' AS DateTime2), NULL, 0, 1)
INSERT [dbo].[LopHocs] ([Id], [MaLop], [TenLop], [IdThongTinChung], [IdChuongTrinhDaoTao], [IdKhoasDaoTao], [MaChuyenNganh], [MaChuongTrinhDaoTao], [NienKhoa], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'd3a0fab0-5ca6-4fd6-8a62-34ae75062378', N'DCCTKH62A', N'Khoa học máy tính K62_A', N'eb03592b-8312-4bb7-9ea9-3022209b0061', N'16397f2d-7b2d-4f28-a547-973d937cc87c', N'2b1dd51a-f1b0-49ef-9bd3-1ccd736c5ea1', N'805', N'7480203', N'', CAST(N'2017-09-01T00:00:00.0000000' AS DateTime2), NULL, 0, 1)
INSERT [dbo].[LopHocs] ([Id], [MaLop], [TenLop], [IdThongTinChung], [IdChuongTrinhDaoTao], [IdKhoasDaoTao], [MaChuyenNganh], [MaChuongTrinhDaoTao], [NienKhoa], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'd6644543-010e-4c7a-a584-4921a3c930b0', N'DCCTPM61', N'Công nghệ phần mềm K61', N'63a1864a-78ab-4218-857d-35a5789d1596', N'506056f2-20b4-4617-addf-a8b92ec98528', N'1e992ea9-9249-49f7-8dc9-64564fc8d2d0', N'801', N'7480203', N'', CAST(N'2016-09-01T00:00:00.0000000' AS DateTime2), NULL, 0, 1)
INSERT [dbo].[LopHocs] ([Id], [MaLop], [TenLop], [IdThongTinChung], [IdChuongTrinhDaoTao], [IdKhoasDaoTao], [MaChuyenNganh], [MaChuongTrinhDaoTao], [NienKhoa], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'df5ad3da-7f52-4e63-a83e-baf0ddec6b16', N'DCCTMM61A', N'Mạng máy tính K61_A', N'1bf1a46b-9baa-4f11-a9e2-6c402b4b3f0b', N'a13e4aab-ea33-4744-ae87-aca390f44be8', N'7be92ecd-b07e-4acc-8c4a-364d7a7b4ca2', N'807', N'7480203', N'', CAST(N'2016-09-01T00:00:00.0000000' AS DateTime2), NULL, 0, 1)
INSERT [dbo].[LopHocs] ([Id], [MaLop], [TenLop], [IdThongTinChung], [IdChuongTrinhDaoTao], [IdKhoasDaoTao], [MaChuyenNganh], [MaChuongTrinhDaoTao], [NienKhoa], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'e8ab4faf-5f40-4c23-80b6-80a036676c10', N'DCCTKH61', N'Khoa học máy tính K61', N'eb03592b-8312-4bb7-9ea9-3022209b0061', N'16397f2d-7b2d-4f28-a547-973d937cc87c', N'd8c0dd18-233f-4948-ac16-52d9123cd020', N'805', N'7480201', N'', CAST(N'2016-10-01T00:00:00.0000000' AS DateTime2), NULL, 0, 1)
INSERT [dbo].[LopHocs] ([Id], [MaLop], [TenLop], [IdThongTinChung], [IdChuongTrinhDaoTao], [IdKhoasDaoTao], [MaChuyenNganh], [MaChuongTrinhDaoTao], [NienKhoa], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'e9df066e-92bb-480c-8858-ed01e6eedb94', N'DCCTPM63B', N'Công nghệ phần mềm K61_B', N'63a1864a-78ab-4218-857d-35a5789d1596', N'506056f2-20b4-4617-addf-a8b92ec98528', N'1e992ea9-9249-49f7-8dc9-64564fc8d2d0', N'801', N'7480203', N'', CAST(N'2016-09-01T00:00:00.0000000' AS DateTime2), NULL, 0, 1)
INSERT [dbo].[LopHocs] ([Id], [MaLop], [TenLop], [IdThongTinChung], [IdChuongTrinhDaoTao], [IdKhoasDaoTao], [MaChuyenNganh], [MaChuongTrinhDaoTao], [NienKhoa], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'f4a04e11-4912-445e-b806-451d0c362a40', N'DCCTMM63A', N'Mạng máy tính K63_A', N'1bf1a46b-9baa-4f11-a9e2-6c402b4b3f0b', N'bc8a858c-9b83-4a53-bf69-595e00598a02', N'f34c3394-8536-4394-b636-1896306bc403', N'807', N'7480201', N'', CAST(N'2016-09-01T00:00:00.0000000' AS DateTime2), NULL, 0, 1)
INSERT [dbo].[LopHocs] ([Id], [MaLop], [TenLop], [IdThongTinChung], [IdChuongTrinhDaoTao], [IdKhoasDaoTao], [MaChuyenNganh], [MaChuongTrinhDaoTao], [NienKhoa], [NgayTao], [NgayCapNhat], [IsDelete], [IsActive]) VALUES (N'f4e6f125-8ef6-4c9c-815a-8453a29b0ee7', N'DCCTHT63B', N'Hệ thống thông tin K63_B', N'd9d571a1-89fb-487b-b71d-b78b7e96031a', N'37ee6be1-bcd6-47ef-a94a-4e97b66f0305', N'10053fda-3036-4253-89a5-1d29dcf182ab', N'802', N'7480201', N'', CAST(N'2018-09-01T00:00:00.0000000' AS DateTime2), NULL, 0, 1)
GO
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'017f4d8a-aceb-402b-9d9e-9fc693a6696a', N'4110241', N'An toàn, sức khỏe và môi trường', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'0310a4b8-3231-4144-ba3d-7dfec2729992', N'4010604', N'Tiếng Anh 4', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'0865a4fb-2bac-4ad0-b88d-d7c92c6a6fe4', N'4070335', N'Một số vấn đề cơ bản về quản lý Nhà nước trong hoạt động dầu khí', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'0c05b8fb-b88f-4f73-b302-3bd7df9881be', N'4080609', N'Kế toán máy (tin kinh tế)', 2, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'0de9bd76-df2d-48ac-a230-b0b768c57fbd', N'4070103', N'Kinh tế lượng', 3, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'0e015ba0-20a1-4205-9672-179208b83325', N'4080707', N'Lập trình mạng', 3, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'0e806bbd-0684-4438-b71e-4f939e3dd276', N'4010605', N'Tiếng Nga 1', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'0ec65d3d-dee0-4ece-a506-47cbeaa554ed', N'4080117', N'Quản trị dự án công nghệ thông tin', 2, N'10003', N'Tự Chọn B')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'11e92deb-adb0-476d-8fb7-9d77256ff8f7', N'', N'Môn Tự Chọn C (toàn trường)', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'133f846d-fc45-4c0e-ac04-10e3649919ab', N'4010111', N'Toán rời rạc', 2, N'10002', N'Tự Chọn A')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'178b1715-6c9d-4d8a-920c-0c442551f936', N'4080705', N'An ninh mạng + BTL', 3, N'10003', N'Tự Chọn B')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'17d2bd8f-9a69-4ea9-80f4-9ae9d16d0a7e', N'4010102', N'Giải tích 1', 4, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'189a3a34-70d7-43c2-8aeb-4c16bd0d2def', N'4080626', N'ứng dụng công nghệ thông tin trong thị trường chứng khoán', 2, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'19568311-f89d-4e79-9ed2-fadadf4cec21', N'4070101', N'Kinh tế vi mô', 3, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'1ca1fc35-a134-4e6f-af01-38c128e0cba1', N'4050509', N'Kỹ thuật môi trường', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'1e6b9dd8-3cfe-425e-9687-e95b310f11d6', N'4080608', N'Lập trình quản lý + TH', 4, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'1e8c3828-80d6-4047-a844-f3fc9f5e0ea8', N'', N'Môn Tự Chọn C (toàn trường)', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'25e4ef88-866d-4a70-b47f-e27bafc4270c', N'4020101', N'Nguyên lý cơ bản của Chủ nghĩa Mác- Lênin 1', 2, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'2a7b6efc-407e-4312-8946-50c751cb5fad', N'4070309', N'Phân tích kinh tế hoạt động kinh doanh', 3, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'2ba9c59a-4975-44b8-bee8-5ccb97261251', N'4110114', N'Môi trường và phát triển bền vững', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'2d4f6993-bd87-47a1-92a3-45167ef65fc1', N'4080208', N'Kỹ thuật lập trình hướng đối tượng trên C++ BTL', 3, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'2e07191c-f208-4df7-a858-ec31dcae815b', N'4070410', N'Quản trị tài chính', 3, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'2ebc4e7d-e904-4698-bc41-3f5401ff0aed', N'4070205', N'Marketing căn bản', 3, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'2ec4f0c2-5118-4802-a50c-eda56bcc8834', N'4080109', N'Kiến trúc và thiết kế phần mềm', 3, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'2f4aadaf-79e7-4296-98df-77a033ea2b0d', N'4020301', N'Đường lối cách mạng của Đảng Cộng Sản Việt Nam', 3, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'2f9ab4f6-205b-41a8-826b-042bd1f45c6c', N'4070304', N'Kinh tế và quản trị doanh nghiệp', 3, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'302aeada-43e4-4647-a054-1ab6064ae980', N'', N'Môn Tự Chọn B (khoa 08)', 2, N'10003', N'Tự Chọn B')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'3307cf47-7123-483f-b2d6-ffc95c66318d', N'4020104', N'Lịch sử Triết học', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'33b8b771-3111-460a-a585-22b13cc83aee', N'4080203', N'Cơ sở lập trình', 3, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'364b619e-e21d-4bae-bcc3-7d252b474d34', N'4110130', N'Địa y học', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'39e16621-04c2-44af-9a93-d4a0cbb045f8', N'4080103', N'Phân tích và thiết kế hệ thống + ĐA', 3, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'39f07488-9ce4-4e01-8aff-c7818593168d', N'4010606', N'Tiếng Nga 2', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'3d608fbf-4396-4411-ac0f-80f28d6c332b', N'4080611', N'Chuyên đề - thực hành 1', 2, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'3d8b85bd-c472-445b-b9dd-cd1850b51db7', N'4050513', N'Quy hoạch và quản lý môi trường', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'3efa56c9-6ae9-4bc6-9e4d-5823be0ed746', N'4080207', N'Hệ quản trị cơ sở dữ liệu', 3, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'435f90af-593d-4fa1-b4d3-23e905980118', N'4070401', N'Nguyên lý kế toán', 3, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'453f4a4a-c627-4791-9e6b-054527ede801', N'4070107', N'Luật kinh tế', 2, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'470d68ac-7363-418e-ba85-47e978d7b30c', N'4010616', N'Tiếng Anh 4', 3, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'48e94fb8-9a3b-4910-ba8b-2fdc215c148b', N'', N'Môn Tự Chọn B (khoa 08)', 2, N'10003', N'Tự Chọn B')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'4a7d6520-d8e7-4819-a5fb-008f93cf35f3', N'4080201', N'Tin học đại cương +TH (dùng cho Kỹ thuật)', 3, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'4c7fa701-5d3c-4c3a-8a0a-51e2addd666c', N'', N'Môn Tự Chọn C (toàn trường)', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'5226ca24-c51c-4506-8b20-3152068a6774', N'4000005', N'Kỹ năng giao tiếp và làm việc theo nhóm', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'5453eaec-96e7-4122-b8df-18c8552cc8cb', N'4070403', N'Kế toán tài chính 1', 4, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'5645e8dd-987b-4847-9f23-74b0dc625c65', N'4010704', N'Giáo dục thể chất 4', 1, N'10006', N'Thể Chất')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'56aaff09-d260-4668-84fb-13d3435e3016', N'4000002', N'Tâm lý học đại cương', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'57a67fcd-9bda-4f93-ac99-c43c7581a57d', N'4040825', N'Cơ sở sinh vật học', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'592bb9ec-6d4b-4fe2-9933-f62e9ebc9869', N'4010101', N'Đại số', 3, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'5b7237af-dca5-4804-8a12-2ccb334b8a28', N'4010105', N'Xác suất thống kê', 2, N'10002', N'Tự Chọn A')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'5d334ea7-a3d0-4991-9818-6f3e71d96255', N'4080631', N'Tiếng Anh chuyên ngành', 2, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'5da8aead-8c11-433d-a7b6-096f65913964', N'4060142', N'Địa vật lý đại cương', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'5ed5a391-bc9e-4095-a882-5ae87e0221c8', N'4080615', N'Đồ án tốt nghiệp', 7, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'60a0bdaa-d076-4200-bbfd-010ff13cb5a4', N'4080602', N'ứng dụng tin học trong lập và phân tích dự án đầu tư', 2, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'64925c47-d152-450f-8979-b7c0a102f627', N'4040101', N'Địa chất đại cương', 3, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'64fc1c90-6d14-4e9e-b7fe-f29002d16c2b', N'4070330', N'Quản trị sản xuất', 2, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'6650b945-ef9f-4d9a-89a2-bf4fa5432a0b', N'4010701', N'Giáo dục thể chất 1', 1, N'10006', N'Thể Chất')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'6c777ea2-5ad4-4f92-8a40-1e32b72cc622', N'4080153', N'Thiết kế Website', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'6cb22572-b164-4982-aeb9-0b3540a51e27', N'4080709', N'Kiến trúc máy tính', 2, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'6d3c6ea2-67b6-4a31-aab1-96acaf23efb8', N'4050206', N'Trắc địa mặt cầu + BTL', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'7233c909-e982-4393-b5bb-63a8c1c8e0a4', N'4080617', N'Tin học đại cương ứng dụng chuyên ngành kinh tế', 2, N'10002', N'Tự Chọn A')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'72fb7893-6db6-4329-a3a6-b181a8436d8f', N'4010607', N'Tiếng Trung 1', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'74ed92e2-5ebd-4b6e-abee-4992f506d6b2', N'4080105', N'Lập trình .NET 1 + BTL', 3, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'76899fab-3d77-4c33-bb0f-1a5ca686099b', N'4010705', N'Giáo dục thể chất 5', 1, N'10006', N'Thể Chất')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'76977f6d-d664-41bd-8559-f5121cb2549d', N'4050602', N'Kỹ thuật lập trình trong trắc địa', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'76c0945a-4167-4c05-a75f-ce10fd0b6d41', N'4080612', N'Chuyên đề - thực hành 2', 2, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'796fc0b2-43f8-4265-9f7c-8655b7f3718b', N'4010603', N'Tiếng Anh 3', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'7979e58d-36f6-419e-8855-9131a8e6a33c', N'4010614', N'Tiếng Anh 2', 3, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'7dd29eca-b1ba-4f62-95b1-55fd8a1d0048', N'4010608', N'Tiếng Trung 2', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'7e14f90c-f802-4fcb-acea-a4e5ade80513', N'4080419', N'Các mô hình đánh giá môi trường địa chất', 2, N'10003', N'Tự Chọn B')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'801ab0e0-6b06-420c-9d54-ab2233051b2a', N'4080606', N'Thống kê và ứng dụng tin học', 3, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'84547cac-8734-445d-b1c2-2d29d02db83a', N'4050649', N'Quy hoạch vùng', 3, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'85331861-1711-4805-a6f1-9f7989998bb9', N'4050616', N'Quản lý bất động sản', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'85bd6dc9-0542-4b58-bd93-6045539d9cc5', N'4090301', N'Kỹ thuật điện +TN', 3, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'862b905a-c69e-4d13-bf09-bf052dd3c9a9', N'4080110', N'Mã nguồn mở', 2, N'10003', N'Tự Chọn B')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'88d69490-be60-423a-99ca-590f569b1a8a', N'4030114', N'Cơ sở khai thác lộ thiên', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'8a90d062-0559-4658-9f9d-340dd378bcef', N'4080604', N'Phát triển ứng dụng tin học trong quản lý - văn phòng', 2, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'8aa2368c-2ef2-4fa3-bcf8-6d8965a1df84', N'4070336', N'Văn hóa doanh nghiệp', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'8b28c19f-8bbe-48ad-ab48-0cd3282d8528', N'4050302', N'Cơ sở viễn thám', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'8bfc6769-f547-418f-a346-ae553a50e0ea', N'4080608', N'Lập trình quản lý + TH', 4, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'8e3649b3-e395-4e5d-8b1d-47eba9647a26', N'4080610', N'Tối ưu hóa - thuật toán', 2, N'10002', N'Tự Chọn A')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'8e374978-ce5e-416a-8929-b5cd92009989', N'4010403', N'Autocad + TH', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'8fc0d9a8-05aa-435c-8907-f0fcf937e56b', N'4010103', N'Giải tích 2', 3, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'9097e03f-172a-4cc1-b264-d843fb18e9c0', N'', N'Môn Tự Chọn A (ngành CTKT)', 2, N'10002', N'Tự Chọn A')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'92f010b4-a1f1-4e62-ac26-931d2dc8c507', N'4080605', N'Thuật toán hoá các bài toán kinh tế', 3, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'9316fa63-802b-4481-9fde-a0097bcbd31d', N'4080710', N'Kỹ thuật vi xử lý', 2, N'10003', N'Tự Chọn B')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'95baed32-31bb-4173-adbd-3de6c73b104e', N'4070109', N'Kinh doanh quốc tế', 2, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'979f1100-a335-4a09-9d25-b32669627e22', N'4080614', N'Thực tập tốt nghiệp', 4, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'99d2874d-babb-4684-99a4-01fbf39f34d9', N'4090595', N'Kỹ thuật lái ô tô', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'9acb620a-641b-4dec-b672-c21b613ade5f', N'4050650', N'Phương pháp lập dự án đầu tư', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'9acf0ce7-6f9b-48d3-b2f0-d05d347339a5', N'4010615', N'Tiếng Anh 3', 3, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'9b247d58-0dda-4128-b26e-9159f2a9d85e', N'4010703', N'Giáo dục thể chất 3', 1, N'10006', N'Thể Chất')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'9b5cba0e-3504-46b6-8889-f9fce42c4516', N'4050526', N'Trắc địa đại cương', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'9d3db434-4715-4ae4-99fb-18e597d4c47b', N'4010201', N'Vật lý đại cương A1 + TN', 3, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'9fd00d31-4fb1-424e-8770-6c193924d8c3', N'4080627', N'Ứng dụng tin học trong phân tích dữ liệu kinh tế', 3, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'a09ce778-7cfb-4cf8-af73-f06d7a16fc21', N'', N'Môn Tự Chọn B (khoa 08)', 2, N'10003', N'Tự Chọn B')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'a107e4cf-33ac-4849-a061-0701234b24ce', N'4080618', N'Mã nguồn mở chuyên ngành kinh tế', 2, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'a1a4be07-8fda-44aa-b006-16f1a344499b', N'4030222', N'Cơ sở khai thác hầm lò', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'a1d52722-41dc-4fd2-b6ba-1d0ca80d36ca', N'4040110', N'Địa mạo cảnh quan', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'a2f9e079-14b2-4fa0-9a8a-74e8140b9a03', N'4050623', N'Hệ thống thông tin đất đai 2', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'a3188c35-1954-4bf1-a9aa-0b3ba3e473b9', N'4010613', N'Tiếng Anh 1', 3, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'a60d89b6-90b1-4d26-afee-6d19fa08795a', N'4080616', N'Phát triển phần mềm ứng dụng trong kinh tế và quản lý', 2, N'10001', N'Học phần chính')
GO
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'a6338657-9bea-4f77-a3f4-6233b1bca605', N'4050301', N'Cơ sở hệ thông tin địa lý (GIS)', 3, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'a776582d-0667-4bfe-a11c-feaddad54167', N'4020201', N'Tư tưởng Hồ Chí Minh', 2, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'a89daa23-eb1b-4fd2-9c51-ec580c4e40ca', N'4080708', N'Cơ sở truyền tin và truyền số liệu', 2, N'10003', N'Tự Chọn B')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'a98d9215-c3ca-4a24-96c0-7d046e6a2cf7', N'4070401', N'Nguyên lý kế toán', 3, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'aa0c2317-c89b-4bee-b7e2-d74d2d971037', N'4050203', N'Định vị vệ tinh (GPS)- A(cho ngành Trắc địa) + BTL', 3, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'ae1b4e48-0930-419e-8659-2d666f5f563e', N'4080122', N'Tiếng Anh chuyên ngành công nghệ thông tin', 2, N'10003', N'Tự Chọn B')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'ae50a039-5d18-434c-b67d-9363a36b65b1', N'4010618', N'Tiếng Anh 6', 3, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'af252eb3-0a45-428a-82d2-cfa4bfbef8be', N'4080723', N'Kỹ thuật điện tử', 2, N'10003', N'Tự Chọn B')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'b01f0ca1-d034-4a47-9024-1bb924eb6549', N'4080101', N'Nguyên lý Hệ điều hành + BTL', 3, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'b60da8e9-1927-4feb-9fe3-ee47e49fc5ed', N'', N'Môn Tự Chọn A (ngành CTKT)', 2, N'10002', N'Tự Chọn A')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'b6da28c5-a752-4708-bd4e-be2c73484a92', N'4080614', N'Thực tập tốt nghiệp', 4, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'b8b0e94d-72f6-4de7-a11a-39962de921cb', N'4030422', N'Cơ sở tuyển khoáng', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'b9ff30ba-bc3a-43dd-b5dd-f32d4b4101fd', N'4060402', N'Kỹ thuật dầu khí đại cương', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'bae7bf5c-e41e-4c46-b912-d0b07b9f39bf', N'4010202', N'Vật lý đại cương A2 + TN', 3, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'bd8539e6-bbe3-4863-b3db-6dd6930cb2a6', N'4080613', N'Thực tập sản xuất', 3, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'c02d497b-d008-4d39-b4bc-9b490b904d00', N'4080601', N'Thực tập tin học cơ sở tin kinh tế', 3, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'c0a0ab20-3a09-46c1-b601-2d39972432e6', N'', N'Môn Tự Chọn C (toàn trường)', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'c1c880b5-6df3-40de-b05b-1b45c791141a', N'4050621', N'Hệ thống hỗ trợ ra quyết định trong quản lý đất đai', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'c2664153-fd6c-4eff-9df9-91a9f5a54414', N'', N'Môn Tự Chọn A (ngành CTKT)', 2, N'10002', N'Tự Chọn A')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'c2cf6456-68d9-49f9-9145-9a22a074949c', N'4000006', N'Kỹ năng tư duy phê phán', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'c3fa50de-bff0-441e-9b7a-f05c34ef0418', N'4080612', N'Chuyên đề - thực hành 2', 2, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'c43c7be3-e99e-4eba-9915-a160d78da0f5', N'4080706', N'Mạng máy tính + BTL', 3, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'c4488bca-21d4-4980-934f-9593e3a815e3', N'4050653', N'Quản lý đất đô thị', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'c49c1686-28d4-436a-8304-901c5e980080', N'4080206', N'Cơ sở dữ liệu', 3, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'c57f9747-66a3-442e-a475-37c5e1b96581', N'4000001', N'Kỹ năng soạn thảo văn bản quản lý hành chính', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'c7ac8743-4e59-41f8-8700-fd034d96f4f6', N'4050610', N'Địa chính đô thị', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'c8a21fcc-9386-424a-ba7e-a9c6a4a4227b', N'4080106', N'Phát triển ứng dụng Web + BTL', 3, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'cecaec46-ec6b-4599-bd9d-aeef9e6f7d0a', N'4000004', N'Cơ sở văn hoá Việt Nam', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'cf7d2d33-1f36-49ef-9e6a-76fe05af93e3', N'4080613', N'Thực tập sản xuất', 3, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'd209500e-258b-44f7-8efd-bc4ae7a61e87', N'4070216', N'Quản trị học', 2, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'd2bd5f29-1475-4563-9b8f-8d35184b060b', N'4080615', N'Đồ án tốt nghiệp', 7, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'd2cafdbf-530f-483c-835f-7795de86ccb0', N'4080309', N'Hệ quản trị nội dung mã nguồn mở', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'd592d6cf-e762-44f9-8b89-453e6d9155e1', N'4010301', N'Hóa học đại cương phần 1 + TN', 3, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'dc2454e5-c8e2-470f-9be4-1668a20839dc', N'4000003', N'Tiếng Việt thực hành', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'dd0d685c-11a1-43d4-ae1b-785c81612379', N'4020102', N'Nguyên lý cơ bản của Chủ nghĩa Mác- Lênin 2', 3, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'de77ba3e-f59b-4ff4-abbc-2e88451bbf23', N'4070102', N'Kinh tế vĩ mô', 3, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'e0029f95-73bd-4d94-9a71-f418009dd285', N'4080621', N'Thương mại điện tử', 2, N'10003', N'Tự Chọn B')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'e06d0d7c-0e19-40e4-80f0-3e5354931fa3', N'4020103', N'Pháp luật đại cương', 2, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'e44aebb4-5d2b-46cc-9130-78574c667e24', N'4080603', N'Kinh tế thông tin', 2, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'e64ef543-5276-4ac5-8ca8-5597740a35d5', N'', N'Môn Tự Chọn B (khoa 08)', 2, N'10003', N'Tự Chọn B')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'e85af8c5-97b5-4da5-afc2-2cb1f7f96f40', N'4040517', N'Cơ sở dịa chất công trình - địa chất thủy văn', 3, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'e961f1c2-60e0-4ad0-8f0b-441e71b1f863', N'', N'Môn Tự Chọn B (khoa 08)', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'e9cf9fab-4bdc-4756-8a6d-a61662d8f88d', N'4080204', N'Cấu trúc dữ liệu và giải thuật', 3, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'ec86d5cf-7241-4e61-8053-3a05cfa830a0', N'4100167', N'Cơ sở xây dựng công trình ngầm và mỏ', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'ecbcb78e-5f8a-4528-b817-df7f8b5546d1', N'', N'Môn Tự Chọn C (toàn trường)', 2, N'10003', N'Tự Chọn B')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'edce2358-4ee7-45c1-8f9a-888e30633565', N'4060339', N'Cơ sở lọc hóa dầu', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'f0c4b147-fc3a-4c70-bcde-6518e435c1c1', N'4110236', N'Môi trường và con người', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'f55593f8-a8b7-419f-8b49-0a6992d2f125', N'4070331', N'Quản trị dự án đầu tư', 2, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'f6532252-ef6f-4c61-aea4-e839e047eb67', N'4070334', N'Kinh tế công nghiệp', 2, N'10001', N'Học phần chính')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'f75db24d-4d92-4dd0-80a5-6726ecb4e1a9', N'4010617', N'Tiếng Anh 5', 3, N'10004', N'Tự Chọn C')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'fc420d84-875c-4c2d-96d5-85f4cfba1a44', N'4010702', N'Giáo dục thể chất 2', 1, N'10006', N'Thể Chất')
INSERT [dbo].[MonHocs] ([Id], [MaMonHoc], [TenMonHoc], [SoTinChi], [MaLoaiMonHoc], [TenLoaiMonHoc]) VALUES (N'ffc8c3c3-3382-4c1a-b0a6-c9a2f4314b5b', N'4080211', N'Phương pháp tính ứng dụng', 2, N'10002', N'Tự Chọn A')
GO
INSERT [dbo].[Nganhs] ([Id], [MaNganh], [TenNganh], [NgayTao], [IsDelete], [IsActive], [NgayCapNhat], [NgayXoa]) VALUES (N'126b2cbe-3693-4cce-a6dd-a1b883f741b9', N'52480201', N'Tin học Địa Chất', CAST(N'2002-07-10T00:00:00.0000000' AS DateTime2), 0, 1, CAST(N'2002-07-10T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Nganhs] ([Id], [MaNganh], [TenNganh], [NgayTao], [IsDelete], [IsActive], [NgayCapNhat], [NgayXoa]) VALUES (N'22e78e45-cfc5-43e8-a08a-4c548f37f4d3', N'52480201', N'Khoa học máy tính', CAST(N'2017-09-28T00:00:00.0000000' AS DateTime2), 0, 1, CAST(N'2017-09-28T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Nganhs] ([Id], [MaNganh], [TenNganh], [NgayTao], [IsDelete], [IsActive], [NgayCapNhat], [NgayXoa]) VALUES (N'26ec297a-4dd9-493c-8b9e-3eee539ba26a', N'52480201', N'Mạng máy tính', CAST(N'2010-02-09T00:00:00.0000000' AS DateTime2), 0, 1, CAST(N'2010-02-09T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Nganhs] ([Id], [MaNganh], [TenNganh], [NgayTao], [IsDelete], [IsActive], [NgayCapNhat], [NgayXoa]) VALUES (N'41cacf8e-e8e9-49e6-8b71-89cbb2396fa8', N'52480201', N'Hệ thống thông tin và tri thức', CAST(N'2019-02-14T00:00:00.0000000' AS DateTime2), 0, 1, CAST(N'2019-02-14T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Nganhs] ([Id], [MaNganh], [TenNganh], [NgayTao], [IsDelete], [IsActive], [NgayCapNhat], [NgayXoa]) VALUES (N'58a466eb-9e1a-4439-90b3-03d9e69b8b13', N'52480201', N'Công nghệ Phần Mềm', CAST(N'2005-03-25T00:00:00.0000000' AS DateTime2), 0, 1, CAST(N'2005-03-25T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Nganhs] ([Id], [MaNganh], [TenNganh], [NgayTao], [IsDelete], [IsActive], [NgayCapNhat], [NgayXoa]) VALUES (N'8b4244fc-9604-483d-ab68-66cc1df154b4', N'52480201', N'Tin học Kinh Tế', CAST(N'2004-02-14T00:00:00.0000000' AS DateTime2), 0, 1, CAST(N'2004-02-14T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Nganhs] ([Id], [MaNganh], [TenNganh], [NgayTao], [IsDelete], [IsActive], [NgayCapNhat], [NgayXoa]) VALUES (N'8f06964a-fef2-4e11-8481-74eac292e36f', N'52480201', N'Tin học Trắc địa', CAST(N'2000-01-01T00:00:00.0000000' AS DateTime2), 0, 1, CAST(N'2000-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Nganhs] ([Id], [MaNganh], [TenNganh], [NgayTao], [IsDelete], [IsActive], [NgayCapNhat], [NgayXoa]) VALUES (N'8u7y6gh964a-fef2-4e11-8481-74eac234fr42fd', N'524802025', N'Công nghệ thông tin', CAST(N'2021-01-01T00:00:00.0000000' AS DateTime2), 0, 1, CAST(N'2015-08-05T00:00:00.0000000' AS DateTime2), NULL)
GO
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'01222f41-e5a7-4161-be65-af9a087ed528', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d35', N'8d0f2f7b-2c4e-44ad-8895-735a69e2283a', N'19568311-f89d-4e79-9ed2-fadadf4cec21', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'0c146036-9c1f-41db-b5c8-fc276ca8fb7f', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d80', N'8978f3ed-c75e-4abb-bc44-cf97dd858b60', N'cf7d2d33-1f36-49ef-9e6a-76fe05af93e3', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'11537510-24bc-4994-aafa-62793b30e9cf', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d69', N'e1c2d3e1-bdd9-44bb-92a6-a51436f94205', N'0e015ba0-20a1-4205-9672-179208b83325', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'16687df3-0708-4a86-aedc-d851e7e55126', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d47', N'80fc951a-f4e3-4659-a408-a501c08294b0', N'c0a0ab20-3a09-46c1-b601-2d39972432e6', N'aca57e50-904e-4591-86dd-b36cfe52468b', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'17a78fed-ff33-4475-9190-6480451d2492', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d55', N'efab05ee-bf15-4386-88c9-d71a25304356', N'2ebc4e7d-e904-4698-bc41-3f5401ff0aed', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'17da615b-b124-4c57-980e-8d0627f1455e', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d41', N'7c1115b7-d18c-49ac-9445-6b910d7fb1b2', N'76899fab-3d77-4c33-bb0f-1a5ca686099b', N'11db8e1e-c8e9-4a24-b35b-a47b436c3780', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'20d22445-dcc1-4396-813a-ad2a7781d3cb', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d78', N'e1c2d3e1-bdd9-44bb-92a6-a51436f94205', N'76c0945a-4167-4c05-a75f-ce10fd0b6d41', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'239491c3-b63a-4433-8a4b-51a516a72b82', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d56', N'efab05ee-bf15-4386-88c9-d71a25304356', N'74ed92e2-5ebd-4b6e-abee-4992f506d6b2', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'2459ad92-08a8-4e84-bba8-e9ba0925e10c', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d65', N'e1c2d3e1-bdd9-44bb-92a6-a51436f94205', N'1e6b9dd8-3cfe-425e-9687-e95b310f11d6', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'2e7d02ef-307d-43c2-846e-504f08ba88ea', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d36', N'8d0f2f7b-2c4e-44ad-8895-735a69e2283a', N'de77ba3e-f59b-4ff4-abbc-2e88451bbf23', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'3325d352-23ec-412a-8aca-1985b7e67f25', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d19', N'9679c6ec-ae42-47ae-ae72-73bf18f17303', N'7979e58d-36f6-419e-8855-9131a8e6a33c', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'34d99bd1-9ea8-4b4a-9e8e-594759aaf3a4', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d71', N'e1c2d3e1-bdd9-44bb-92a6-a51436f94205', N'e961f1c2-60e0-4ad0-8f0b-441e71b1f863', N'2f872943-9a13-4933-ab71-3c687a83ecaa', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'3f3871d1-b329-4392-9ae6-b4e78c091a4f', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d11', N'edf488e0-e9ff-4b96-a276-d5a482b73d56', N'9d3db434-4715-4ae4-99fb-18e597d4c47b', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'3fa9bfb8-8846-4f65-b143-7b8645903f36', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d33', N'8d0f2f7b-2c4e-44ad-8895-735a69e2283a', N'5645e8dd-987b-4847-9f23-74b0dc625c65', N'11db8e1e-c8e9-4a24-b35b-a47b436c3780', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'4051d4e3-77aa-4c51-b9cf-3ec4b1e3b2a4', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d24', N'9679c6ec-ae42-47ae-ae72-73bf18f17303', N'6cb22572-b164-4982-aeb9-0b3540a51e27', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'435e4ce0-354f-4222-aee3-883e6e949926', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d42', N'7c1115b7-d18c-49ac-9445-6b910d7fb1b2', N'0de9bd76-df2d-48ac-a230-b0b768c57fbd', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'490a2e0b-dab2-49c1-af18-a8238ee52aa1', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d31', N'c85e2f2e-dae8-4027-8bc1-270ea372e141', N'5d334ea7-a3d0-4991-9818-6f3e71d96255', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'49983cda-b05f-422f-b39d-dabcbd6f1209', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d63', N'e1c2d3e1-bdd9-44bb-92a6-a51436f94205', N'2ec4f0c2-5118-4802-a50c-eda56bcc8834', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'4b38db8d-792f-40c5-bf81-ca2658aeafd0', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d54', N'efab05ee-bf15-4386-88c9-d71a25304356', N'1e8c3828-80d6-4047-a844-f3fc9f5e0ea8', N'aca57e50-904e-4591-86dd-b36cfe52468b', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'4b8147f0-5698-4397-8b2c-c3635f34d99b', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d57', N'efab05ee-bf15-4386-88c9-d71a25304356', N'2d4f6993-bd87-47a1-92a3-45167ef65fc1', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'4cb172f0-1c7e-40c3-8162-cf402f08f0e7', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d77', N'e1c2d3e1-bdd9-44bb-92a6-a51436f94205', N'8bfc6769-f547-418f-a346-ae553a50e0ea', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'5460d718-4c9d-4494-b776-f45233a221ac', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d30', N'c85e2f2e-dae8-4027-8bc1-270ea372e141', N'c02d497b-d008-4d39-b4bc-9b490b904d00', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'55809d2c-7417-4a0a-8160-8770f3feb2d0', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d53', N'efab05ee-bf15-4386-88c9-d71a25304356', N'302aeada-43e4-4647-a054-1ab6064ae980', N'2f872943-9a13-4933-ab71-3c687a83ecaa', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'58818804-36ab-4c1b-8dfa-2023a0bb4a23', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d50', N'80fc951a-f4e3-4659-a408-a501c08294b0', N'e44aebb4-5d2b-46cc-9130-78574c667e24', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'5bdcd31a-3533-4054-bcfb-566b27c5ca5c', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d40', N'7c1115b7-d18c-49ac-9445-6b910d7fb1b2', N'11e92deb-adb0-476d-8fb7-9d77256ff8f7', N'aca57e50-904e-4591-86dd-b36cfe52468b', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'5ec33e11-2434-4cd1-89bd-332e88ccff08', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d62', N'e1c2d3e1-bdd9-44bb-92a6-a51436f94205', N'c8a21fcc-9386-424a-ba7e-a9c6a4a4227b', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'5f4fc1a2-b07c-456c-b857-564a4144029c', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d20', N'9679c6ec-ae42-47ae-ae72-73bf18f17303', N'fc420d84-875c-4c2d-96d5-85f4cfba1a44', N'11db8e1e-c8e9-4a24-b35b-a47b436c3780', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'5fb752cb-6cd9-414e-bb38-fbbdbdd53e9b', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d79', N'e1c2d3e1-bdd9-44bb-92a6-a51436f94205', N'189a3a34-70d7-43c2-8aeb-4c16bd0d2def', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'640f8f1e-5f3f-41b2-8032-b03fe38c4f73', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d13', N'edf488e0-e9ff-4b96-a276-d5a482b73d56', N'6650b945-ef9f-4d9a-89a2-bf4fa5432a0b', N'11db8e1e-c8e9-4a24-b35b-a47b436c3780', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'65029fc1-81d8-4b1a-9aab-b73f777aaa58', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d68', N'e1c2d3e1-bdd9-44bb-92a6-a51436f94205', N'a107e4cf-33ac-4849-a061-0701234b24ce', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'6ad31cd6-b64b-46a9-882d-ebaf73badc8a', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d7', N'90ce6b98-8133-45eb-8182-8cc0649cd213', N'17d2bd8f-9a69-4ea9-80f4-9ae9d16d0a7e', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'6b7602bc-cd11-49f7-9e7e-6b244f274d6c', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d84', N'8978f3ed-c75e-4abb-bc44-cf97dd858b60', N'b6da28c5-a752-4708-bd4e-be2c73484a92', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'6c291d83-a62e-4c41-b04d-60ecb8cc45fd', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d83', N'8978f3ed-c75e-4abb-bc44-cf97dd858b60', N'bd8539e6-bbe3-4863-b3db-6dd6930cb2a6', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'71571abe-ae9f-4195-b705-c93569f0ee49', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d34', N'8d0f2f7b-2c4e-44ad-8895-735a69e2283a', N'2f4aadaf-79e7-4296-98df-77a033ea2b0d', N'dc4fc47e-bb43-4c5d-9c61-299506278ba0', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'725fb54f-d357-4a42-a572-d3c6d1ed43a9', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d81', N'8978f3ed-c75e-4abb-bc44-cf97dd858b60', N'979f1100-a335-4a09-9d25-b32669627e22', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'73cf9670-64be-4c4e-b9f8-105cfd620652', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d74', N'e1c2d3e1-bdd9-44bb-92a6-a51436f94205', N'64fc1c90-6d14-4e9e-b7fe-f29002d16c2b', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'76c82bad-626f-4d1e-86d7-b011d9591052', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d61', N'e1c2d3e1-bdd9-44bb-92a6-a51436f94205', N'4c7fa701-5d3c-4c3a-8a0a-51e2addd666c', N'aca57e50-904e-4591-86dd-b36cfe52468b', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'77edfaf8-2690-4e11-98c9-d086bb315479', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d76', N'e1c2d3e1-bdd9-44bb-92a6-a51436f94205', N'2e07191c-f208-4df7-a858-ec31dcae815b', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'792e59c1-18fa-41ab-8a21-9e4b9df728b0', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d66', N'e1c2d3e1-bdd9-44bb-92a6-a51436f94205', N'c3fa50de-bff0-441e-9b7a-f05c34ef0418', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'862b75ba-89c3-47c2-a720-3f40e1076d5d', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d8', N'90ce6b98-8133-45eb-8182-8cc0649cd213', N'd592d6cf-e762-44f9-8b89-453e6d9155e1', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'863664b5-56d5-4540-a943-f38dd9e5e5cf', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d45', N'7c1115b7-d18c-49ac-9445-6b910d7fb1b2', N'92f010b4-a1f1-4e62-ac26-931d2dc8c507', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'8953cd43-eeec-4f34-b09e-f95cacc58a85', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d58', N'efab05ee-bf15-4386-88c9-d71a25304356', N'0c05b8fb-b88f-4f73-b302-3bd7df9881be', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'8e67afc3-f709-42b8-8fe9-e36aae10837b', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d28', N'c85e2f2e-dae8-4027-8bc1-270ea372e141', N'e9cf9fab-4bdc-4756-8a6d-a61662d8f88d', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'9277c7a5-2a6a-423c-a50f-d6a5bbff30e6', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d12', N'edf488e0-e9ff-4b96-a276-d5a482b73d56', N'a3188c35-1954-4bf1-a9aa-0b3ba3e473b9', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'94bf704f-a16e-453c-8543-4acde4ff6c5d', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d49', N'80fc951a-f4e3-4659-a408-a501c08294b0', N'39e16621-04c2-44af-9a93-d4a0cbb045f8', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'9e6ba682-fb98-43e9-be56-97635fa984bf', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d44', N'7c1115b7-d18c-49ac-9445-6b910d7fb1b2', N'8a90d062-0559-4658-9f9d-340dd378bcef', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'a24d51dc-6c72-4e89-b848-780631c89f7d', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d16', N'9679c6ec-ae42-47ae-ae72-73bf18f17303', N'e64ef543-5276-4ac5-8ca8-5597740a35d5', N'524ede90-c112-431a-bb0d-a171a2ead791', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'a985902f-24d9-49ed-a91d-b3efb3f111cf', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d75', N'e1c2d3e1-bdd9-44bb-92a6-a51436f94205', N'f6532252-ef6f-4c61-aea4-e839e047eb67', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'ade7d911-ec3f-45e5-b03c-4b6729131f4d', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d37', N'8d0f2f7b-2c4e-44ad-8895-735a69e2283a', N'd209500e-258b-44f7-8efd-bc4ae7a61e87', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'af7d3b9f-d720-4f6f-91eb-08d2d2849123', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d48', N'80fc951a-f4e3-4659-a408-a501c08294b0', N'a98d9215-c3ca-4a24-96c0-7d046e6a2cf7', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'afc254b9-9277-4c9d-a8ea-dfb6e1f4a335', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d6', N'90ce6b98-8133-45eb-8182-8cc0649cd213', N'592bb9ec-6d4b-4fe2-9933-f62e9ebc9869', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'b287a2a2-ca82-4a92-96c8-2ad98fea13b7', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d46', N'7c1115b7-d18c-49ac-9445-6b910d7fb1b2', N'c43c7be3-e99e-4eba-9915-a160d78da0f5', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'b31eb5a1-cf96-4a2f-bcc1-63616b46d341', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d60', N'e1c2d3e1-bdd9-44bb-92a6-a51436f94205', N'a09ce778-7cfb-4cf8-af73-f06d7a16fc21', N'2f872943-9a13-4933-ab71-3c687a83ecaa', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'b3628449-f20d-4ed2-b2e5-daf55da7218b', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d18', N'9679c6ec-ae42-47ae-ae72-73bf18f17303', N'bae7bf5c-e41e-4c46-b912-d0b07b9f39bf', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'b3c8a746-d122-4620-8aeb-5a6aaf51211b', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d29', N'c85e2f2e-dae8-4027-8bc1-270ea372e141', N'c49c1686-28d4-436a-8304-901c5e980080', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'b5f59b1e-0a39-4b48-a191-7f151f0ae353', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d23', N'9679c6ec-ae42-47ae-ae72-73bf18f17303', N'33b8b771-3111-460a-a585-22b13cc83aee', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'bc1984df-9c00-47c6-9420-82d1c1d67628', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d85', N'8978f3ed-c75e-4abb-bc44-cf97dd858b60', N'5ed5a391-bc9e-4095-a882-5ae87e0221c8', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'c14955fd-5011-476b-93d0-f4f7fce7b201', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d27', N'c85e2f2e-dae8-4027-8bc1-270ea372e141', N'b01f0ca1-d034-4a47-9024-1bb924eb6549', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'c3fba9a6-b664-4cf0-a11c-2ce6423a5838', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d10', N'edf488e0-e9ff-4b96-a276-d5a482b73d56', N'8fc0d9a8-05aa-435c-8907-f0fcf937e56b', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'd152158d-58b8-4ee8-86b4-515106c90fc5', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d52', N'80fc951a-f4e3-4659-a408-a501c08294b0', N'9fd00d31-4fb1-424e-8770-6c193924d8c3', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'd3be5a0c-ed80-4a42-bbf9-ce4ba17196e8', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d70', N'e1c2d3e1-bdd9-44bb-92a6-a51436f94205', N'ecbcb78e-5f8a-4528-b817-df7f8b5546d1', N'aca57e50-904e-4591-86dd-b36cfe52468b', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'd3dc73cb-36ab-4682-b7c1-ac5e8e40170d', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d9', N'90ce6b98-8133-45eb-8182-8cc0649cd213', N'25e4ef88-866d-4a70-b47f-e27bafc4270c', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'dc7a2f56-6439-4df4-8c6c-7557e7c0088d', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d21', N'9679c6ec-ae42-47ae-ae72-73bf18f17303', N'e06d0d7c-0e19-40e4-80f0-3e5354931fa3', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'dce99ffe-1283-4aad-9b66-83e03ee70f82', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d59', N'efab05ee-bf15-4386-88c9-d71a25304356', N'3d608fbf-4396-4411-ac0f-80f28d6c332b', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'df275dac-e27a-4e98-8c26-ccb288c7f737', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d38', N'8d0f2f7b-2c4e-44ad-8895-735a69e2283a', N'3efa56c9-6ae9-4bc6-9e4d-5823be0ed746', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'e182ef6d-1551-4d1e-a789-dd40e8cd6926', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d82', N'8978f3ed-c75e-4abb-bc44-cf97dd858b60', N'd2bd5f29-1475-4563-9b8f-8d35184b060b', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'e2e5d955-2e41-436a-ac46-0e262faacf82', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d39', N'7c1115b7-d18c-49ac-9445-6b910d7fb1b2', N'48e94fb8-9a3b-4910-ba8b-2fdc215c148b', N'2f872943-9a13-4933-ab71-3c687a83ecaa', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'e521adcb-a8d8-412f-a1ee-a4ac4b06711a', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d32', N'8d0f2f7b-2c4e-44ad-8895-735a69e2283a', N'9097e03f-172a-4cc1-b264-d843fb18e9c0', N'524ede90-c112-431a-bb0d-a171a2ead791', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'e55213ca-6caa-4301-acea-f7d29064c582', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d72', N'e1c2d3e1-bdd9-44bb-92a6-a51436f94205', N'95baed32-31bb-4173-adbd-3de6c73b104e', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'e875bc5c-27ff-4229-8bac-6173010c307e', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d64', N'e1c2d3e1-bdd9-44bb-92a6-a51436f94205', N'60a0bdaa-d076-4200-bbfd-010ff13cb5a4', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'efccc85d-f9dc-4a3b-8db3-a42e91a8644c', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d25', N'c85e2f2e-dae8-4027-8bc1-270ea372e141', N'c2664153-fd6c-4eff-9df9-91a9f5a54414', N'524ede90-c112-431a-bb0d-a171a2ead791', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'f191120a-2192-46cf-ae70-09eb1fbf11fc', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d26', N'c85e2f2e-dae8-4027-8bc1-270ea372e141', N'9b247d58-0dda-4128-b26e-9159f2a9d85e', N'11db8e1e-c8e9-4a24-b35b-a47b436c3780', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'f50fca82-66a5-43b5-ab94-662f3e7084e4', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d43', N'7c1115b7-d18c-49ac-9445-6b910d7fb1b2', N'453f4a4a-c627-4791-9e6b-054527ede801', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'f54398f2-2343-41ee-a9e2-92178a592a2f', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d73', N'e1c2d3e1-bdd9-44bb-92a6-a51436f94205', N'2a7b6efc-407e-4312-8946-50c751cb5fad', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'f92a58d4-22fc-4471-9183-224bef447d4d', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d22', N'9679c6ec-ae42-47ae-ae72-73bf18f17303', N'a776582d-0667-4bfe-a11c-feaddad54167', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'f9737888-91ff-4fd2-9a25-b2377dcc0d34', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d67', N'e1c2d3e1-bdd9-44bb-92a6-a51436f94205', N'a60d89b6-90b1-4d26-afee-6d19fa08795a', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'fc6556b1-4c03-4a0b-a7ed-53a5f4202550', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d14', N'edf488e0-e9ff-4b96-a276-d5a482b73d56', N'dd0d685c-11a1-43d4-ae1b-785c81612379', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'fc82d6bf-bbf0-4581-9947-e8476c705396', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d15', N'edf488e0-e9ff-4b96-a276-d5a482b73d56', N'4a7d6520-d8e7-4819-a5fb-008f93cf35f3', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'fd5e7751-6a23-4b52-9763-d84c13e2ee7e', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d17', N'9679c6ec-ae42-47ae-ae72-73bf18f17303', N'b60da8e9-1927-4feb-9fe3-ee47e49fc5ed', N'2f872943-9a13-4933-ab71-3c687a83ecaa', NULL)
INSERT [dbo].[NienGiamCTDTs] ([Id], [MaNienGiam], [TenNienGiam], [IdChuongTrinhDaoTaos], [IdKhoasDaoTao], [IdHocKy], [IdMonHoc], [IdLoaiMonHoc], [GhiChu]) VALUES (N'fe1fd0f2-29e5-4d2e-a914-5706c528edcf', N'NGTKTK61', N'Niên Giám Tin Học Kinh Tế K61', N'3ee4bb6f-6849-4708-bfdf-fd2905788b5c', N'332f7905-a3b0-44ab-a242-dc901741f9d51', N'80fc951a-f4e3-4659-a408-a501c08294b0', N'801ab0e0-6b06-420c-9d54-ab2233051b2a', N'388111bf-1321-46fc-901a-dcaea2c15000', NULL)
GO
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'075403a9-dbce-43d5-8641-28bb63e4861f', N'1921050306', N'Vũ Thị', N'Huyền', N'Vũ Thị Huyền', N'1921050306@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333920', N'DCCTCT64F', N'0349843271', CAST(N'2021-05-22T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'0bdf1e51-5798-4c25-920b-e71440f4e582', N'1921050179', N'Nguyễn Văn', N'Đăng', N'Nguyễn Văn Đăng', N'1921050179@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333918', N'DCCTCT64E', N'0833685555', CAST(N'2021-05-10T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'0cb63966-663c-4d35-84aa-997c0b76cbc5', N'1924010596', N'Nguyễn Thị Quỳnh', N'Hoa', N'Nguyễn Thị Quỳnh Hoa', N'1924010596@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333928', N'DCKTKT_64B', N'0569785698', CAST(N'2021-05-17T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'0ef799b3-193c-45d6-b255-21f7db070297', N'1821050078', N'Vũ Anh', N'Chung', N'Vũ Anh Chung', N'1821050078@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333922', N'DCCTKH63A', N'0974880788', CAST(N'2021-04-30T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'0f53a3c3-68d7-4619-a154-ff9f2019977569846', N'1621050181', N'Lê Huy', N'Hùng', N'Lê Huy Hùng', N'1621050181@student.humg.edu.vn', N'51fb8d2a-c509-43ca-99db-d2c6f4514d3c', N'DCCTKT61', N'0974336856', CAST(N'2021-05-19T00:00:00.0000000' AS DateTime2), NULL, NULL, N'11116878f-84b3-4e17-9b34-076209fkdfsdf', N'Thong tin chuyen nganh tin kinh tế', 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'142199ca-bfb6-41d0-a9f7-50775235b0f5', N'1821050143', N'Nguyễn Đình', N'Việt', N'Nguyễn Đình Việt', N'1821050143@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333936', N'DCCTHT63A', N'0969387841', CAST(N'2021-06-27T00:00:00.0000000' AS DateTime2), NULL, NULL, N'0f53a3c3-68d7-4619-a154-ff9f2019977569846', N'Thong tin chuyen nganh tin kinh tế', 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'17ac6947-8b62-47d0-a701-b2c84d5ccb71', N'1921050057', N'Nguyễn Thị', N'Anh', N'Nguyễn Thị Anh', N'1921050057@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333918', N'DCCTCT64E', N'0982527982', CAST(N'2021-04-26T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'30c428f1-acc0-415b-9ff4-93b435b862e0', N'1821050953', N'Nguyễn Ngọc', N'Phú', N'Nguyễn Ngọc Phú', N'1821050953@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333919', N'DCCTMM63C', N'0387717148', CAST(N'2021-06-09T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'36a3e433-fc7a-4c05-ac59-50103bc11903', N'1921050172', N'Nguyễn Tiến', N'Đạt', N'Nguyễn Tiến Đạt', N'1921050172@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333920', N'DCCTCT64F', N'0912644784', CAST(N'2021-05-07T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'395f4fec-c5ed-4e0f-8d83-eb64075d4e50', N'1921050406', N'Lê Thế', N'Nam', N'Lê Thế Nam', N'1921050406@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333918', N'DCCTCT64E', N'0354328666', CAST(N'2021-06-03T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'3a70b485-9c87-4148-be01-b3528dff882a', N'1821050843', N'Lê Thành', N'Thảo', N'Lê Thành Thảo', N'1821050843@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333922', N'DCCTKH63A', N'0974336856', CAST(N'2021-06-14T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'3d19494b-ce19-4788-935d-7a258545a534', N'1921050608', N'Lê Thu', N'Trang', N'Lê Thu Trang', N'1921050608@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333931', N'DCCTCT64A', N'0969387841', CAST(N'2021-06-21T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'3d366535-e9ed-45d1-bc06-d0d615102aad', N'1821050069', N'Đào Đình', N'Toàn', N'Đào Đình Toàn', N'1821050069@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333922', N'DCCTKH63A', N'0334088718', CAST(N'2021-06-19T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'3ea38cfe-8de1-4778-a4dc-64752f5a29d4', N'1921050233', N'Hồ Xuân', N'Hiệp', N'Hồ Xuân Hiệp', N'1921050233@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333920', N'DCCTCT64F', N'0977273980', CAST(N'2021-05-16T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'3f08cf92-f9c7-45b7-9e1a-9813c5945820', N'1921050184', N'Nguyễn Quyết', N'Định', N'Nguyễn Quyết Định', N'1921050184@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333918', N'DCCTCT64E', N'0357460777', CAST(N'2021-05-11T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'404abde7-9e2f-474e-b55b-560455673a99', N'1921050151', N'Nguyễn Thế', N'Dương', N'Nguyễn Thế Dương', N'1921050151@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333920', N'DCCTCT64F', N'0914770545', CAST(N'2021-05-04T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'44495b51-9f2c-4fe3-a965-0ed6bd47c7f7', N'1921011080', N'Đỗ Công', N'Tấn', N'Đỗ Công Tấn', N'1921011080@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333920', N'DCCTCT64F', N'0929479243', CAST(N'2021-06-13T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'45962256-704c-4da6-ab0b-c7526c79991e', N'1921050117', N'Nguyễn Văn', N'Cường', N'Nguyễn Văn Cường', N'1921050117@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333920', N'DCCTCT64F', N'0984603663', CAST(N'2021-05-02T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'46634186-3bcc-404c-a8d0-1899721a9351', N'1721030108', N'Bùi Minh', N'Ngọc', N'Bùi Minh Ngọc', N'1721030108@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333932', N'DCKTKT_62_2', N'0326699445', CAST(N'2021-06-07T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'4d06730b-eb9b-40a3-8549-0b484456cf0f', N'1821050975', N'Nguyễn Thanh', N'Long', N'Nguyễn Thanh Long', N'1821050975@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333921', N'DCCTPM63B', N'0325131919', CAST(N'2021-05-31T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'4e242471-654a-44b5-a6e5-bdd1575ad344', N'1821050816', N'Nguyễn Thành', N'Lâm', N'Nguyễn Thành Lâm', N'1821050816@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333929', N'DCCTPM63A', N'0369784525', CAST(N'2021-05-29T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'4e33642f-17c7-46cd-86e2-98b05ea5e46b', N'1921050430', N'Bùi Thị Kim', N'Ngân', N'Bùi Thị Kim Ngân', N'1921050430@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333920', N'DCCTCT64F', N'0962728598', CAST(N'2021-06-06T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'4ee420e1-eb53-42cb-ab4f-97c4e0d67d16', N'1821050621', N'Lê Mạnh', N'Hùng', N'Lê Mạnh Hùng', N'1821050621@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333921', N'DCCTPM63B', N'0337980888', CAST(N'2021-05-19T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'4f9e1ff4-cd60-465e-b68b-3ba2e837e27d', N'1921050553', N'Trần Thị', N'Thảo', N'Trần Thị Thảo', N'1921050553@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333931', N'DCCTCT64A', N'0336378689', CAST(N'2021-06-15T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'526ad28f-6aaa-47c7-960d-f59957190bea', N'1921050230', N'Đặng Duy', N'Hiển', N'Đặng Duy Hiển', N'1921050230@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333918', N'DCCTCT64E', N'0359989090', CAST(N'2021-05-15T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'5499132b-026f-4d3f-b048-ead97d32a07b', N'1921050364', N'Nguyễn Thanh', N'Long', N'Nguyễn Thanh Long', N'1921050364@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333920', N'DCCTCT64F', N'0348677940', CAST(N'2021-06-01T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'5a4f983d-1ed4-4f7d-be87-b3cf111e96cc', N'1921050532', N'Đoàn Văn', N'Tần', N'Đoàn Văn Tần', N'1921050532@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333934', N'DCCTCT64B', N'0397011010', CAST(N'2021-06-12T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'5adcb727-2318-4aaa-8720-87799d369526', N'1821050979', N'Lê Thanh', N'Tùng', N'Lê Thanh Tùng', N'1821050979@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333922', N'DCCTKH63A', N'0335587809', CAST(N'2021-06-24T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'5d8b4d99-d5ce-4297-9c7f-e615b38932aa', N'1924010123', N'Hà Thị Thùy', N'Nhung', N'Hà Thị Thùy Nhung', N'1924010123@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333933', N'DCKTTN_64', N'0968975922', CAST(N'2021-06-08T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'6429bdb0-74f1-40e1-8e7a-aea523fc634b', N'1924010541', N'Hoàng Thị', N'Hạnh', N'Hoàng Thị Hạnh', N'1924010541@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333927', N'DCKTKT_64A', N'0326685965', CAST(N'2021-05-14T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'666b96a9-bed9-4968-96c5-06d0dabcb2b6', N'1921050124', N'Nguyễn Thùy', N'Dung', N'Nguyễn Thùy Dung', N'1921050124@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333920', N'DCCTCT64F', N'0986375176', CAST(N'2021-05-03T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'6772867b-7008-4062-a751-76a58e8bda1a', N'1821050292', N'Nguyễn Xuân', N'Đạt', N'Nguyễn Xuân Đạt', N'1821050292@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333923', N'DCCTKH63C', N'0966219941', CAST(N'2021-05-08T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'6fc5a0ee-3612-4df9-89eb-6453787214e9', N'1921050414', N'Nguyễn Khắc', N'Nam', N'Nguyễn Khắc Nam', N'1921050414@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333931', N'DCCTCT64A', N'0329354111', CAST(N'2021-06-04T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'71b740b1-286e-4b08-8b0a-dcdb5d30cebd', N'1821051019', N'Nguyễn Đức', N'Thắng', N'Nguyễn Đức Thắng', N'1821051019@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333921', N'DCCTPM63B', N'0328161382', CAST(N'2021-06-17T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'7335ad1e-9781-46a3-949f-fa6e8856303f', N'1821050138', N'Nguyễn Chiến', N'Thắng', N'Nguyễn Chiến Thắng', N'1821050138@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333922', N'DCCTKH63A', N'0986273909', CAST(N'2021-06-16T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'7488788f-eb1a-4c00-90d4-7d802f76ad56', N'1924011046', N'Chu Thị', N'Thu', N'Chu Thị Thu', N'1924011046@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333935', N'DCKTKT_64D', N'0988746985', CAST(N'2021-06-18T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'7b78bdd3-ce4e-48c5-9c5c-a35cf8e7a9fd', N'1821050560', N'Đàm Đức Trí', N'Khang', N'Đàm Đức Trí Khang', N'1821050560@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333930', N'DCCTDH63B', N'0948686378', CAST(N'2021-05-23T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'7b84773a-200e-4ab9-98b6-3c9e44c3345a', N'1921050207', N'Nguyễn Trường', N'Giang', N'Nguyễn Trường Giang', N'1921050207@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333920', N'DCCTCT64F', N'0343656633', CAST(N'2021-05-13T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'7c7ed47a-71ff-442b-90f7-df217cc46c5c', N'1821050955', N'Đặng Thành', N'Công', N'Đặng Thành Công', N'1821050955@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333924', N'DCCTKH63B', N'0983888611', CAST(N'2021-05-01T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'80d38ade-a590-499e-9fbc-c4b9e5ae8cc5', N'1921050652', N'Phạm Minh', N'Tuấn', N'Phạm Minh Tuấn', N'1921050652@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333931', N'DCCTCT64A', N'0328161382', CAST(N'2021-06-23T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'81a49a06-ff98-4ea7-be43-c5eff577140d', N'1821050034', N'Nguyễn Tiến', N'Anh', N'Nguyễn Tiến Anh', N'1821050034@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333924', N'DCCTKH63B', N'0973776072', CAST(N'2021-04-27T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'84604bb0-e235-4d44-ae48-d898ac97f5a4', N'1921010113', N'Phạm Đình', N'Nam', N'Phạm Đình Nam', N'1921010113@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333918', N'DCCTCT64E', N'0382686363', CAST(N'2021-06-05T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'9d99d62b-ae71-48c7-8799-130f6e6a6a4f', N'1921050330', N'Nguyễn Thị', N'Khâm', N'Nguyễn Thị Khâm', N'1921050330@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333920', N'DCCTCT64F', N'03657945223', CAST(N'2021-05-27T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'a071ddc9-ffa4-4308-a200-47c2db88964a', N'1821050084', N'Dương Chí', N'Kiên', N'Dương Chí Kiên', N'1821050084@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333930', N'DCCTDH63B', N'0963063998', CAST(N'2021-05-28T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'a95148d8-79b0-485d-b312-928dcab98ab8', N'1821051004', N'Ngô Việt', N'Long', N'Ngô Việt Long', N'1821051004@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333929', N'DCCTPM63A', N'0387476604', CAST(N'2021-05-30T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'af4a4b4d-19e6-43fd-b5ec-200d227f1d2f', N'1821050899', N'Trịnh Quốc', N'Toàn', N'Trịnh Quốc Toàn', N'1821050899@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333921', N'DCCTPM63B', N'0356527666', CAST(N'2021-06-20T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'b23537dc-0bd5-451e-8fcc-a9f55c3371bd', N'1821050872', N'Đinh Quang', N'Đại', N'Đinh Quang Đại', N'1821050872@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333919', N'DCCTMM63C', N'0986253482', CAST(N'2021-05-05T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'b50d0705-4012-4c01-b5ae-e9530a0b2411', N'1924010431', N'Nguyễn Văn', N'Chiến', N'Nguyễn Văn Chiến', N'1924010431@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333926', N'DCKTKDTM64B', N'0904770053', CAST(N'2021-04-29T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'b7e7d1de-7db8-45a4-a9ab-0a7115bb6957', N'1921050400', N'Lê Văn', N'Mong', N'Lê Văn Mong', N'1921050400@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333918', N'DCCTCT64E', N'0979229968', CAST(N'2021-06-02T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'c0f0145b-a6b6-4e34-8910-51ad0a7125e4', N'1821051068', N'Đặng Danh', N'Việt', N'Đặng Danh Việt', N'1821051068@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333922', N'DCCTKH63A', N'0356527666', CAST(N'2021-06-26T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'c30e47e2-76bd-466e-a87c-c0c6c6ed0760', N'1821050745', N'Nguyễn Văn', N'Sơn', N'Nguyễn Văn Sơn', N'1821050745@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333919', N'DCCTMM63C', N'0968960602', CAST(N'2021-06-10T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'c8e336a5-c4d8-4de3-9df7-179879165de3', N'1921050666', N'Nguyễn Văn', N'Tùng', N'Nguyễn Văn Tùng', N'1921050666@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333931', N'DCCTCT64A', N'0919528645', CAST(N'2021-06-25T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'd13a135c-b743-49fb-8866-ee3a6c4a8b93', N'1921050171', N'Nguyễn Tiến', N'Đạt', N'Nguyễn Tiến Đạt', N'1921050171@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333918', N'DCCTCT64E', N'0944545232', CAST(N'2021-05-06T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'd57a7a81-69d6-4347-b891-f5a753344377', N'1821050025', N'Nguyễn Minh', N'Hoàng', N'Nguyễn Minh Hoàng', N'1821050025@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333929', N'DCCTPM63A', N'0383813244', CAST(N'2021-05-18T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'dee72546-0f58-4968-a365-d2add47279e9', N'1821050815', N'Nguyễn Mạnh', N'Tú', N'Nguyễn Mạnh Tú', N'1821050815@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333936', N'DCCTHT63A', N'0941330398', CAST(N'2021-06-22T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'e1d42dc9-7cf4-4b9c-b96f-c90f26e75d60', N'1821050652', N'Vũ Ngọc', N'Huyên', N'Vũ Ngọc Huyên', N'1821050652@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333922', N'DCCTKH63A', N'0349843271', CAST(N'2021-05-21T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'e773b76d-f5cb-4819-bc6c-790c208210b4', N'1821050962', N'Hồ Trọng', N'Khánh', N'Hồ Trọng Khánh', N'1821050962@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333929', N'DCCTPM63A', N'0354630303', CAST(N'2021-05-25T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'f2816224-dbf8-40a5-bd6d-156f40c33bbb', N'1921050177', N'Vũ Tiến', N'Đạt', N'Vũ Tiến Đạt', N'1921050177@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333918', N'DCCTCT64E', N'0833685555', CAST(N'2021-05-09T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'f590cb40-82ae-4540-8795-ad4f705453c9', N'1421050274', N'Đặng Xuân', N'Bách', N'Đặng Xuân Bách', N'1421050274@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333925', N'DCCTPM59_1', N'0917749254', CAST(N'2021-04-28T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'fdcdc0d4-197a-42a0-8dfd-43c3ccd65d7e', N'1821050707', N'Nguyễn Văn', N'Khang', N'Nguyễn Văn Khang', N'1821050707@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333924', N'DCCTKH63B', N'0386167548', CAST(N'2021-05-24T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[SinhViens] ([Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [TinChiTichLuy], [DiemTichLuy], [IdThongTinChung], [TenThongTinChung], [IsDelete], [IsActive]) VALUES (N'fea576c5-6d25-4f4e-8e7b-3999ecf71a89', N'1821050702', N'Trần Minh', N'Đức', N'Trần Minh Đức', N'1821050702@studen.humg.edu.vn', N'0f53a3c3-68d7-4619-a154-ff9f20333923', N'DCCTKH63C', N'0379610510', CAST(N'2021-05-12T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, 0, 1)
GO
INSERT [dbo].[ThongTinChungs] ([Id], [MaNhomChuyenNganh], [TenNhomChuyenNganh], [IdKhoa], [TenKhoa], [IdBoMon], [TenBoMon], [IdNganh], [TenNganh], [IdChuyenNganh], [TenChuyenNganh], [GhiChu]) VALUES (N'0f26bb6f-f2d8-472d-bdee-9f4d324affe9', N'DCCTKT', N'Tin học Kinh Tế', N'2c203642-547c-4005-93f5-44eac5e3b05c', N'Công Nghệ Thông Tin', N'4323e0fb-dc71-421f-a9ef-f81a0125965e', N'Bộ Môn Tin học Kinh Tế', N'8u7y6gh964a-fef2-4e11-8481-74eac234fr42fd', N'Công nghệ thông tin', N'6259a0fe-34f0-41a4-9f1f-9cd30d61e507', N'Tin học Kinh Tế', N'')
INSERT [dbo].[ThongTinChungs] ([Id], [MaNhomChuyenNganh], [TenNhomChuyenNganh], [IdKhoa], [TenKhoa], [IdBoMon], [TenBoMon], [IdNganh], [TenNganh], [IdChuyenNganh], [TenChuyenNganh], [GhiChu]) VALUES (N'1bf1a46b-9baa-4f11-a9e2-6c402b4b3f0b', N'DCCTMM', N'Mạng máy tính', N'2c203642-547c-4005-93f5-44eac5e3b05c', N'Công Nghệ Thông Tin', N'7bf67a54-ba9c-4298-8cff-fadb1dcf80c4', N'Bộ Môn Mạng máy tính', N'8u7y6gh964a-fef2-4e11-8481-74eac234fr42fd', N'Công nghệ thông tin', N'a1e2acb6-60c4-4efc-a612-29bad0fdeee6', N'Mạng máy tính', N'')
INSERT [dbo].[ThongTinChungs] ([Id], [MaNhomChuyenNganh], [TenNhomChuyenNganh], [IdKhoa], [TenKhoa], [IdBoMon], [TenBoMon], [IdNganh], [TenNganh], [IdChuyenNganh], [TenChuyenNganh], [GhiChu]) VALUES (N'63a1864a-78ab-4218-857d-35a5789d1596', N'DCCTPM', N'Công nghệ Phần Mềm', N'2c203642-547c-4005-93f5-44eac5e3b05c', N'Công Nghệ Thông Tin', N'aed121f1-a6ad-4c91-85f8-5aa3e93aa34b', N'Bộ Môn Công nghệ Phần Mềm', N'8u7y6gh964a-fef2-4e11-8481-74eac234fr42fd', N'Công nghệ thông tin', N'2d9ad470-b8ff-4efd-b9b2-3112800ec38d', N'Công nghệ Phần Mềm', N'')
INSERT [dbo].[ThongTinChungs] ([Id], [MaNhomChuyenNganh], [TenNhomChuyenNganh], [IdKhoa], [TenKhoa], [IdBoMon], [TenBoMon], [IdNganh], [TenNganh], [IdChuyenNganh], [TenChuyenNganh], [GhiChu]) VALUES (N'd9d571a1-89fb-487b-b71d-b78b7e96031a', N'DCCTHT', N'Hệ thống thông tin và tri thức', N'2c203642-547c-4005-93f5-44eac5e3b05c', N'Công Nghệ Thông Tin', N'6c8f9a59-1155-4b1a-8517-c3125b21c562', N'Bộ Môn Hệ thống thông tin và tri thức', N'8u7y6gh964a-fef2-4e11-8481-74eac234fr42fd', N'Công nghệ thông tin', N'06bf7ff9-a93b-43b6-8d61-da7773ad7c3b', N'Hệ thống thông tin và tri thức', N'')
INSERT [dbo].[ThongTinChungs] ([Id], [MaNhomChuyenNganh], [TenNhomChuyenNganh], [IdKhoa], [TenKhoa], [IdBoMon], [TenBoMon], [IdNganh], [TenNganh], [IdChuyenNganh], [TenChuyenNganh], [GhiChu]) VALUES (N'e185cd01-9d30-478b-b0bc-37d4273df5f3', N'DCCTDC', N'Tin học Địa Chất', N'2c203642-547c-4005-93f5-44eac5e3b05c', N'Công Nghệ Thông Tin', N'ff4df15d-14e3-4a40-9972-21af29dca3b6', N'Bộ Môn Tin học Địa Chất', N'8u7y6gh964a-fef2-4e11-8481-74eac234fr42fd', N'Công nghệ thông tin', N'9d4ae719-afb3-4631-9827-64c7ac0eea21', N'Tin học Địa Chất', N'')
INSERT [dbo].[ThongTinChungs] ([Id], [MaNhomChuyenNganh], [TenNhomChuyenNganh], [IdKhoa], [TenKhoa], [IdBoMon], [TenBoMon], [IdNganh], [TenNganh], [IdChuyenNganh], [TenChuyenNganh], [GhiChu]) VALUES (N'eb03592b-8312-4bb7-9ea9-3022209b0061', N'DCCTKH', N'Khoa học máy tính', N'2c203642-547c-4005-93f5-44eac5e3b05c', N'Công Nghệ Thông Tin', N'2c2da3b2-f82b-4920-9585-c02db02c0633', N'Bộ Môn Khoa học máy tính', N'8u7y6gh964a-fef2-4e11-8481-74eac234fr42fd', N'Công nghệ thông tin', N'ab3301be-8b5c-42f1-84a9-f9de2359025a', N'Khoa học máy tính', N'')
INSERT [dbo].[ThongTinChungs] ([Id], [MaNhomChuyenNganh], [TenNhomChuyenNganh], [IdKhoa], [TenKhoa], [IdBoMon], [TenBoMon], [IdNganh], [TenNganh], [IdChuyenNganh], [TenChuyenNganh], [GhiChu]) VALUES (N'f64a1fea-aee7-49fd-bfe5-c60674aeb094', N'DCCTDT', N'Tin học Trắc địa', N'2c203642-547c-4005-93f5-44eac5e3b05c', N'Công Nghệ Thông Tin', N'fb4d5d49-77fc-4885-9aa4-fa26513d52b2', N'Bộ Môn Tin học Trắc địa', N'8u7y6gh964a-fef2-4e11-8481-74eac234fr42fd', N'Công nghệ thông tin', N'966a5447-829d-4621-8be7-39e6762af15e', N'Tin học Trắc địa', N'')
GO
/****** Object:  StoredProcedure [dbo].[spBoMo_SelectAll]    Script Date: 4/26/2021 12:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spBoMo_SelectAll]
AS
BEGIN
	SELECT [Id],[MaBoMon],[TenBoMon],[VanPhong],[DiaChi],[HomThu],[DienThoai] 
	FROM [dbo].[BoMons] WHERE [IsDelete]= 0 AND [IsActive]= 1
END
GO
/****** Object:  StoredProcedure [dbo].[spBoMon_Search]    Script Date: 4/26/2021 12:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Create by :lê hùng
--Create date : 12/04/2021 16:12:38
--Description :
--Output :
--Modify :
--Project :QLDA
-----------------------o0o-----------------------

CREATE PROCEDURE [dbo].[spBoMon_Search]
(
	@Keyword AS NVARCHAR(50),
	@IsActive AS BIT,
	@page AS INT = 1,
	@pageSize AS INT =20
)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @SQL NVARCHAR(MAX);
	DECLARE @ParamList NVARCHAR(2000);

	SELECT @keyword = UPPER([dbo].[StripVietnameseChars](@keyword));

	SELECT @SQL= N'
SELECT [Id], [MaBoMon], [TenBoMon], [VanPhong], [DiaChi], [HomThu], [DienThoai], [IdKhoa], [NgayTao], [NgayCapNhat], [NgayXoa], [IsActive]
INTO #BoMons
FROM [dbo].[BoMons] WITH (NOLOCK)
WHERE [IsDelete] = 0';

	IF ISNULL(@Keyword, '') <> ''
	SELECT @SQL = @SQL + N'
AND ([UnsignName] LIKE N''%' + @Keyword + '%'')';

	IF @IsActive IS NOT NULL
	SELECT @SQL = @SQL + N'
AND ([IsActive] = @IsActive)';

	SELECT @SQL= @SQL+ N'
SELECT ISNULL(COUNT(1),0) AS TotalRows FROM #BoMons';

	SELECT @SQL= @SQL+ N'
SELECT [Id], [MaBoMon], [TenBoMon], [VanPhong], [DiaChi], [HomThu], [DienThoai], [IdKhoa], [NgayTao], [NgayCapNhat], [NgayXoa], [IsActive]
FROM #BoMons
ORDER BY [Order],[LastUpdate] DESC
OFFSET ' + CAST(@pageSize AS VARCHAR(10)) + N' * (' + CAST(@page AS VARCHAR(10)) + N' - 1) ROWS
FETCH NEXT ' + CAST(@pageSize AS VARCHAR(10)) + N' ROWS ONLY;';

	SELECT @ParamList= N'
@Keyword AS NVARCHAR(50),
@IsActive AS BIT,
@page AS INT,
@pageSize AS INT';

	EXECUTE sp_executesql @SQL,@ParamList,@Keyword,@IsActive,@page,@pageSize;

END; 

 
GO
/****** Object:  StoredProcedure [dbo].[spBoMon_SearchByIdKhoa]    Script Date: 4/26/2021 12:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spBoMon_SearchByIdKhoa]
(
	@IdKhoa VARCHAR(50) = '2c203642-547c-4005-93f5-44eac5e3b05c'
)
AS
BEGIN
    SELECT ThongTinChungs.IdBoMon AS Id,BoMons.MaBoMon,BoMons.TenBoMon,BoMons.VanPhong,BoMons.DiaChi,BoMons.HomThu,BoMons.DienThoai,BoMons.NgayTao
	INTO #BoMon
	FROM dbo.ThongTinChungs INNER JOIN dbo.BoMons ON BoMons.Id = ThongTinChungs.IdBoMon
	WHERE ThongTinChungs.IdKhoa = @IdKhoa AND BoMons.IsDelete = 0 AND BoMons.IsActive = 1
	SELECT ISNULL(COUNT(1),0) AS TotalRows FROM #BoMon
	SELECT * FROM #BoMon
END
GO
/****** Object:  StoredProcedure [dbo].[spBoMon_SelectAll]    Script Date: 4/26/2021 12:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spBoMon_SelectAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		[Id],
		[MaBoMon],
		[TenBoMon],
		[VanPhong],
		[DiaChi],
		[HomThu],
		[DienThoai],
		[IdKhoa],
		[NgayTao],
		[NgayCapNhat],
		[NgayXoa],
		[IsActive]
	FROM [dbo].[BoMons] WITH (NOLOCK)
	WHERE
		[IsDelete] = 0 AND [IsActive] = 1
	ORDER BY [MaBoMon] DESC
END 
GO
/****** Object:  StoredProcedure [dbo].[spBoMon_SelectByID]    Script Date: 4/26/2021 12:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spBoMon_SelectByID]
(
	@Id AS VARCHAR(50)
)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		[Id],
		[MaBoMon],
		[TenBoMon],
		[VanPhong],
		[DiaChi],
		[HomThu],
		[DienThoai],
		[NgayTao],
		[NgayCapNhat],
		[NgayXoa],
		[IsDelete],
		[IsActive]
	FROM [dbo].[BoMons] WITH (NOLOCK)
	WHERE 
		[Id]=@Id AND 
		[IsDelete] = 0
END 
GO
/****** Object:  StoredProcedure [dbo].[spChuyenNganh_SelectAll]    Script Date: 4/26/2021 12:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spChuyenNganh_SelectAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		[Id],
		[MaChuyenNganh],
		[TenChuyenNganh],
		[VanPhong],
		[HopThu],
		[DienThoai],
		[DiaChi],
		[GhiChu],
		[NgayCapNhat],
		[NgayTao],
		[IsActive]
	FROM [dbo].[ChuyenNganhs] WITH (NOLOCK)
	WHERE
		[IsDelete] = 0 AND [IsActive] = 1
	ORDER BY [MaChuyenNganh],[NgayCapNhat] DESC
END 
GO
/****** Object:  StoredProcedure [dbo].[spChuyenNganh_SelectByID]    Script Date: 4/26/2021 12:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spChuyenNganh_SelectByID]
(
	@Id AS VARCHAR(50) ='ac98b12d-68be-469a-8485-892168eb3568'
)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		[Id],
		[MaChuyenNganh],
		[TenChuyenNganh],
		[VanPhong],
		[HopThu],
		[DienThoai],
		[DiaChi],
		[GhiChu],
		[NgayCapNhat],
		[NgayTao],
		[IsDelete],
		[IsActive]
	FROM [dbo].[ChuyenNganhs] WITH (NOLOCK)
	WHERE 
		[Id]=@Id AND 
		[IsDelete] = 0
END 
GO
/****** Object:  StoredProcedure [dbo].[spGiangVien_SelectAll]    Script Date: 4/26/2021 12:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGiangVien_SelectAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		[Id],
		[MaGiangVien],
		[HoDem],
		[Ten],
		[HoTen],
		[HomThu],
		[GhiChu],
		[DonViCongTac],
		[DienThoai],
		[SoDeTai],
		[IdThongTinChung],
		[TenThongTinChung],
		[NgayTao],
		[NgayCapNhat],
		[IsActive]
	FROM [dbo].[GiangViens] WITH (NOLOCK)
	WHERE
		[IsDelete] = 0 AND [IsActive] = 1
	ORDER BY [MaGiangVien],[NgayTao] DESC
END 
GO
/****** Object:  StoredProcedure [dbo].[spGiangVien_SelectByID]    Script Date: 4/26/2021 12:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Create by :lê hùng
--Create date : 14/04/2021 18:52:06
--Description :
--Output :
--Modify :
--Project :QLDA
-----------------------o0o-----------------------

CREATE PROCEDURE [dbo].[spGiangVien_SelectByID]
(
	@Id AS VARCHAR(50)
)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		[Id],
		[MaGiangVien],
		[HoDem],
		[Ten],
		[HoTen],
		[HomThu],
		[MaBoMon],
		[GhiChu],
		[DonViCongTac],
		[DienThoai],
		[SoDeTai],
		[NgayTao],
		[NgayCapNhat],
		[IsDelete],
		[IsActive]
	FROM [dbo].[GiangViens] WITH (NOLOCK)
	WHERE 
		[Id]=@Id AND 
		[IsDelete] = 0
END 

GO
/****** Object:  StoredProcedure [dbo].[spKhoa_SelectAll]    Script Date: 4/26/2021 12:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spKhoa_SelectAll]
AS
BEGIN
--thong tin Khoa
	SELECT [Id],[MaKhoa],[TenKhoa],[NgayTao],[NgayCapNhat]
FROM dbo.Khoas WHERE IsActive = 1 AND IsDelete = 0
END
GO
/****** Object:  StoredProcedure [dbo].[spKhoa_SelectByID]    Script Date: 4/26/2021 12:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Create by :lê hùng
--Create date : 23/04/2021 17:46:56
--Description :
--Output :
--Modify :
--Project :QLDA
-----------------------o0o-----------------------

CREATE PROCEDURE [dbo].[spKhoa_SelectByID]
(
	@Id AS VARCHAR(50)
)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		[Id],
		[MaKhoa],
		[TenKhoa],
		[IsDelete],
		[IsActive],
		[NgayTao],
		[NgayCapNhat]
	FROM [dbo].[Khoas] WITH (NOLOCK)
	WHERE 
		[Id]=@Id AND 
		[IsDelete] = 0
END 

GO
/****** Object:  StoredProcedure [dbo].[spLopHoc_SelectAll]    Script Date: 4/26/2021 12:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Create by :lê hùng
--Create date : 12/04/2021 16:29:24
--Description :
--Output :
--Modify :
--Project :QLDA
-----------------------o0o-----------------------

CREATE PROCEDURE [dbo].[spLopHoc_SelectAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		[Id],
		[MaLop],
		[TenLop],
		[IdChuyenNganh],
		[IdChuongTrinhDaoTao],
		[MaChuyenNganh],
		[MaChuongTrinhDaoTao],
		[NienKhoa],
		[NgayTao],
		[NgayCapNhat],
		[IsActive]
	FROM [dbo].[LopHocs] WITH (NOLOCK)
	WHERE
		[IsDelete] = 0 AND [IsActive] = 1
	ORDER BY [MaLop],[NgayCapNhat] DESC
END 

GO
/****** Object:  StoredProcedure [dbo].[spLopHoc_SelectByID]    Script Date: 4/26/2021 12:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Create by :lê hùng
--Create date : 12/04/2021 16:30:00
--Description :
--Output :
--Modify :
--Project :QLDA
-----------------------o0o-----------------------

CREATE PROCEDURE [dbo].[spLopHoc_SelectByID]
(
	@Id AS VARCHAR(50)
)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		[Id],
		[MaLop],
		[TenLop],
		[IdChuyenNganh],
		[IdChuongTrinhDaoTao],
		[MaChuyenNganh],
		[MaChuongTrinhDaoTao],
		[NienKhoa],
		[NgayTao],
		[NgayCapNhat],
		[IsDelete],
		[IsActive]
	FROM [dbo].[LopHocs] WITH (NOLOCK)
	WHERE 
		[Id]=@Id AND 
		[IsDelete] = 0
END 

GO
/****** Object:  StoredProcedure [dbo].[spNganh_SelectAll]    Script Date: 4/26/2021 12:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spNganh_SelectAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		[Id],
		[MaNganh],
		[TenNganh],
		[NgayTao],
		[IsActive],
		[NgayCapNhat]
	FROM [dbo].[Nganhs] WITH (NOLOCK)
	WHERE
		[IsDelete] = 0 AND [IsActive] = 1
	ORDER BY [MaNganh] DESC
END 
GO
/****** Object:  StoredProcedure [dbo].[spNganh_SelectByID]    Script Date: 4/26/2021 12:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Create by :lê hùng
--Create date : 12/04/2021 16:25:37
--Description :
--Output :
--Modify :
--Project :QLDA
-----------------------o0o-----------------------

CREATE PROCEDURE [dbo].[spNganh_SelectByID]
(
	@Id AS VARCHAR(50)
)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		[Id],
		[MaNganh],
		[TenNganh],
		[IdBoMon],
		[NgayTao],
		[IsDelete],
		[IsActive],
		[NgayCapNhat],
		[NgayXoa]
	FROM [dbo].[Nganhs] WITH (NOLOCK)
	WHERE 
		[Id]=@Id AND 
		[IsDelete] = 0
END 

GO
/****** Object:  StoredProcedure [dbo].[spSinhVien_KiemTraDK]    Script Date: 4/26/2021 12:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spSinhVien_KiemTraDK]
(
	@IdSinhVien AS VARCHAR(50) = null
)
AS
BEGIN
	DECLARE @MaLop AS VARCHAR(50)
		SET @MaLop = ''
		SELECT @MaLop = IdLop FROM dbo.SinhViens WHERE Id = '@IdSinhVien';
	PRINT @MaLop
	SELECT IdChuongTrinhDaoTao FROM dbo.LopHocs WHERE Id = @MaLop
END
GO
/****** Object:  StoredProcedure [dbo].[spSinhVien_Search]    Script Date: 4/26/2021 12:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSinhVien_Search]
(
	@Id AS NVARCHAR(50),
	@page AS INT = 1,
	@pageSize AS INT =20
)
AS
BEGIN
	SET NOCOUNT ON;


	SELECT [Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [IsActive]
	INTO #SinhViens
	FROM [dbo].[SinhViens] WITH (NOLOCK)
	WHERE [IsDelete] = 0 AND
		 [IdLop] = @Id
	SELECT  ISNULL(COUNT(1),0) AS TotalRows FROM #SinhViens

	SELECT  [Id], [MaSinhVien], [HoDem], [Ten], [HoTen], [HomThu], [IdLop], [MaLop], [DienThoai], [NgayTao], [IsActive]
	FROM #SinhViens
	ORDER BY [MaSinhVien],[NgayTao] DESC
	OFFSET @pageSize * (@page - 1) ROWS
	FETCH NEXT @pageSize ROWS ONLY;
END 
GO
/****** Object:  StoredProcedure [dbo].[spSinhVien_SelectAll]    Script Date: 4/26/2021 12:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSinhVien_SelectAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		[Id],
		[MaSinhVien],
		[HoDem],
		[Ten],
		[HoTen],
		[HomThu],
		[IdLop],
		[MaLop],
		[DienThoai],
		[TinChiTichLuy],
		[DiemTichLuy],
		[IdThongTinChung],
		[TenThongTinChung],
		[NgayTao],
		[IsActive]
	FROM [dbo].[SinhViens] WITH (NOLOCK)
	WHERE
		[IsDelete] = 0 AND [IsActive] = 1
	ORDER BY [MaSinhVien],[NgayTao] DESC
END 
GO
/****** Object:  StoredProcedure [dbo].[spSinhVien_SelectByID]    Script Date: 4/26/2021 12:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Create by :lê hùng
--Create date : 14/04/2021 18:04:40
--Description :
--Output :
--Modify :
--Project :QLDA
-----------------------o0o-----------------------

CREATE PROCEDURE [dbo].[spSinhVien_SelectByID]
(
	@Id AS VARCHAR(50)
)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		[Id],
		[MaSinhVien],
		[HoDem],
		[Ten],
		[HoTen],
		[HomThu],
		[IdLop],
		[MaLop],
		[DienThoai],
		[NgayTao],
		[IsDelete],
		[IsActive]
	FROM [dbo].[SinhViens] WITH (NOLOCK)
	WHERE 
		[Id]=@Id AND 
		[IsDelete] = 0
END 

GO
/****** Object:  StoredProcedure [dbo].[spThongTinGiangVien]    Script Date: 4/26/2021 12:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spThongTinGiangVien]
(@IdGiangVien AS VARCHAR(50) = '11116878f-84b3-4e17-9b34-076209HFHSJH')
AS
BEGIN
	SELECT ThongTinChungs.Id AS IdThongTinChung, ThongTinChungs.MaNhomChuyenNganh, ThongTinChungs.TenNhomChuyenNganh, ThongTinChungs.IdKhoa, ThongTinChungs.TenKhoa, ThongTinChungs.IdBoMon, ThongTinChungs.TenBoMon,
		ThongTinChungs.IdNganh,ThongTinChungs.TenNganh,ThongTinChungs.IdChuyenNganh,ThongTinChungs.TenChuyenNganh,
		GiangViens.MaGiangVien,GiangViens.HoDem,GiangViens.Ten,GiangViens.HoTen,GiangViens.DienThoai,GiangViens.HomThu,GiangViens.DonViCongTac
	FROM dbo.ThongTinChungs INNER JOIN dbo.GiangViens ON GiangViens.IdThongTinChung = ThongTinChungs.Id
	WHERE GiangViens.Id =@IdGiangVien AND GiangViens.IsDelete = 0 AND GiangViens.IsActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[spThongTinSinhVien]    Script Date: 4/26/2021 12:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spThongTinSinhVien]
(@IdSingVien AS VARCHAR(50) = '0f53a3c3-68d7-4619-a154-ff9f2019977569846')
AS
BEGIN
	SELECT ThongTinChungs.Id, ThongTinChungs.MaNhomChuyenNganh, ThongTinChungs.TenNhomChuyenNganh, ThongTinChungs.IdKhoa, ThongTinChungs.TenKhoa, ThongTinChungs.IdBoMon, ThongTinChungs.TenBoMon,
		ThongTinChungs.IdNganh,ThongTinChungs.TenNganh,ThongTinChungs.IdChuyenNganh,ThongTinChungs.TenChuyenNganh,
		SinhViens.MaSinhVien,SinhViens.HoDem,SinhViens.Ten,SinhViens.HomThu,SinhViens.HoTen,SinhViens.DienThoai,SinhViens.IdLop,SinhViens.MaLop,SinhViens.NgayTao,SinhViens.IsActive
	FROM dbo.ThongTinChungs INNER JOIN dbo.LopHocs ON LopHocs.IdThongTinChung = ThongTinChungs.Id
	INNER JOIN SinhViens ON LopHocs.Id = SinhViens.IdLop
	WHERE SinhViens.Id =@IdSingVien AND SinhViens.IsDelete = 0 AND SinhViens.IsActive = 1
END
GO
