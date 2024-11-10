/****** Object:  Database [CafeGocNho]    Script Date: 25/05/2024 18:03:02 ******/
DROP DATABASE [CafeGocNho]
GO
/****** Object:  Database [CafeGocNho]    Script Date: 25/05/2024 18:03:02 ******/
CREATE DATABASE [CafeGocNho]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CafeGocNho', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\CafeGocNho.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CafeGocNho_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\CafeGocNho_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [CafeGocNho] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CafeGocNho].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CafeGocNho] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CafeGocNho] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CafeGocNho] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CafeGocNho] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CafeGocNho] SET ARITHABORT OFF 
GO
ALTER DATABASE [CafeGocNho] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [CafeGocNho] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CafeGocNho] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CafeGocNho] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CafeGocNho] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CafeGocNho] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CafeGocNho] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CafeGocNho] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CafeGocNho] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CafeGocNho] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CafeGocNho] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CafeGocNho] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CafeGocNho] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CafeGocNho] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CafeGocNho] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CafeGocNho] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CafeGocNho] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CafeGocNho] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CafeGocNho] SET  MULTI_USER 
GO
ALTER DATABASE [CafeGocNho] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CafeGocNho] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CafeGocNho] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CafeGocNho] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CafeGocNho] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CafeGocNho] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CafeGocNho] SET QUERY_STORE = ON
GO
ALTER DATABASE [CafeGocNho] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [CafeGocNho]
GO
/****** Object:  Table [dbo].[BAN]    Script Date: 25/05/2024 18:03:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BAN](
	[MABAN] [int] NOT NULL,
	[TINHTRANG] [smallint] NULL,
 CONSTRAINT [PK_BAN] PRIMARY KEY CLUSTERED 
(
	[MABAN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CHITIETHOADON]    Script Date: 25/05/2024 18:03:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHITIETHOADON](
	[MAHD] [varchar](10) NOT NULL,
	[MAMH] [varchar](10) NOT NULL,
	[SOLUONG] [int] NULL,
	[GIACA] [int] NULL,
 CONSTRAINT [PK_CHITIETHOADON] PRIMARY KEY CLUSTERED 
(
	[MAHD] ASC,
	[MAMH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HOADON]    Script Date: 25/05/2024 18:03:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOADON](
	[MAHD] [varchar](10) NOT NULL,
	[MABAN] [int] NULL,
	[MANV] [varchar](10) NULL,
	[THOIGIAN] [datetime] NULL,
 CONSTRAINT [PK_HOADON] PRIMARY KEY CLUSTERED 
(
	[MAHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAIMATHANG]    Script Date: 25/05/2024 18:03:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAIMATHANG](
	[MALOAI] [varchar](10) NOT NULL,
	[TENLOAI] [nvarchar](30) NULL,
 CONSTRAINT [PK_LOAIMATHANG] PRIMARY KEY CLUSTERED 
(
	[MALOAI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MENU]    Script Date: 25/05/2024 18:03:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MENU](
	[MAMH] [varchar](10) NOT NULL,
	[TENMH] [nvarchar](200) NULL,
	[GIACA] [int] NULL,
	[DVT] [nvarchar](10) NULL,
	[MALOAI] [varchar](10) NULL,
 CONSTRAINT [PK_MENU] PRIMARY KEY CLUSTERED 
(
	[MAMH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 25/05/2024 18:03:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[MANV] [varchar](10) NOT NULL,
	[HONV] [nvarchar](50) NULL,
	[TENNV] [nvarchar](10) NULL,
	[EMAIL] [varchar](50) NULL,
	[DIACHI] [nvarchar](200) NULL,
	[MATKHAU] [varchar](50) NULL,
	[CHUCVU] [nvarchar](30) NULL,
	[GIOITINH] [smallint] NULL,
	[SDT] [varchar](15) NULL,
	[CCCD] [varchar](12) NULL,
 CONSTRAINT [PK_NHANVIEN] PRIMARY KEY CLUSTERED 
(
	[MANV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[BAN] ([MABAN], [TINHTRANG]) VALUES (1, 0)
INSERT [dbo].[BAN] ([MABAN], [TINHTRANG]) VALUES (2, 0)
INSERT [dbo].[BAN] ([MABAN], [TINHTRANG]) VALUES (3, 0)
INSERT [dbo].[BAN] ([MABAN], [TINHTRANG]) VALUES (4, 0)
INSERT [dbo].[BAN] ([MABAN], [TINHTRANG]) VALUES (5, 0)
INSERT [dbo].[BAN] ([MABAN], [TINHTRANG]) VALUES (6, 0)
INSERT [dbo].[BAN] ([MABAN], [TINHTRANG]) VALUES (7, 0)
INSERT [dbo].[BAN] ([MABAN], [TINHTRANG]) VALUES (8, 0)
INSERT [dbo].[BAN] ([MABAN], [TINHTRANG]) VALUES (9, 0)
INSERT [dbo].[BAN] ([MABAN], [TINHTRANG]) VALUES (10, 0)
GO
INSERT [dbo].[CHITIETHOADON] ([MAHD], [MAMH], [SOLUONG], [GIACA]) VALUES (N'HD0002', N'AVS001', 1, 20000)
INSERT [dbo].[CHITIETHOADON] ([MAHD], [MAMH], [SOLUONG], [GIACA]) VALUES (N'HD0002', N'AVS003', 1, 20000)
INSERT [dbo].[CHITIETHOADON] ([MAHD], [MAMH], [SOLUONG], [GIACA]) VALUES (N'HD0003', N'AVS001', 2, 10000)
INSERT [dbo].[CHITIETHOADON] ([MAHD], [MAMH], [SOLUONG], [GIACA]) VALUES (N'HD0004', N'AVS001', 2, 20000)
INSERT [dbo].[CHITIETHOADON] ([MAHD], [MAMH], [SOLUONG], [GIACA]) VALUES (N'HD0004', N'AVS007', 2, 20000)
INSERT [dbo].[CHITIETHOADON] ([MAHD], [MAMH], [SOLUONG], [GIACA]) VALUES (N'HD0005', N'AVS005', 2, 20000)
INSERT [dbo].[CHITIETHOADON] ([MAHD], [MAMH], [SOLUONG], [GIACA]) VALUES (N'HD0006', N'AVS006', 2, 20000)
INSERT [dbo].[CHITIETHOADON] ([MAHD], [MAMH], [SOLUONG], [GIACA]) VALUES (N'HD0007', N'AVS006', 3, 20000)
INSERT [dbo].[CHITIETHOADON] ([MAHD], [MAMH], [SOLUONG], [GIACA]) VALUES (N'HD0007', N'AVS007', 3, 20000)
INSERT [dbo].[CHITIETHOADON] ([MAHD], [MAMH], [SOLUONG], [GIACA]) VALUES (N'HD0008', N'AVS003', 2, 20000)
INSERT [dbo].[CHITIETHOADON] ([MAHD], [MAMH], [SOLUONG], [GIACA]) VALUES (N'HD0009', N'AVS004', 2, 20000)
INSERT [dbo].[CHITIETHOADON] ([MAHD], [MAMH], [SOLUONG], [GIACA]) VALUES (N'HD0010', N'AVS005', 2, 20000)
INSERT [dbo].[CHITIETHOADON] ([MAHD], [MAMH], [SOLUONG], [GIACA]) VALUES (N'HD0011', N'AVS003', 4, 20000)
INSERT [dbo].[CHITIETHOADON] ([MAHD], [MAMH], [SOLUONG], [GIACA]) VALUES (N'HD0011', N'AVS007', 4, 20000)
INSERT [dbo].[CHITIETHOADON] ([MAHD], [MAMH], [SOLUONG], [GIACA]) VALUES (N'HD0012', N'AVS002', 2, 10000)
GO
INSERT [dbo].[HOADON] ([MAHD], [MABAN], [MANV], [THOIGIAN]) VALUES (N'HD0002', 1, N'NV003', CAST(N'2024-05-19T14:30:03.000' AS DateTime))
INSERT [dbo].[HOADON] ([MAHD], [MABAN], [MANV], [THOIGIAN]) VALUES (N'HD0003', 1, N'NV001', CAST(N'2024-05-20T09:48:25.000' AS DateTime))
INSERT [dbo].[HOADON] ([MAHD], [MABAN], [MANV], [THOIGIAN]) VALUES (N'HD0004', 2, N'NV002', CAST(N'2024-05-20T09:49:04.000' AS DateTime))
INSERT [dbo].[HOADON] ([MAHD], [MABAN], [MANV], [THOIGIAN]) VALUES (N'HD0005', 1, N'NV002', CAST(N'2024-05-20T09:52:23.000' AS DateTime))
INSERT [dbo].[HOADON] ([MAHD], [MABAN], [MANV], [THOIGIAN]) VALUES (N'HD0006', 2, N'NV001', CAST(N'2024-05-20T09:52:45.000' AS DateTime))
INSERT [dbo].[HOADON] ([MAHD], [MABAN], [MANV], [THOIGIAN]) VALUES (N'HD0007', 2, N'NV001', CAST(N'2024-05-20T09:52:59.000' AS DateTime))
INSERT [dbo].[HOADON] ([MAHD], [MABAN], [MANV], [THOIGIAN]) VALUES (N'HD0008', 3, N'NV001', CAST(N'2024-05-20T10:03:29.000' AS DateTime))
INSERT [dbo].[HOADON] ([MAHD], [MABAN], [MANV], [THOIGIAN]) VALUES (N'HD0009', 2, N'NV001', CAST(N'2024-05-23T16:05:43.000' AS DateTime))
INSERT [dbo].[HOADON] ([MAHD], [MABAN], [MANV], [THOIGIAN]) VALUES (N'HD0010', 8, N'NV003', CAST(N'2024-05-23T16:06:37.000' AS DateTime))
INSERT [dbo].[HOADON] ([MAHD], [MABAN], [MANV], [THOIGIAN]) VALUES (N'HD0011', 2, N'NV003', CAST(N'2024-05-23T16:10:54.000' AS DateTime))
INSERT [dbo].[HOADON] ([MAHD], [MABAN], [MANV], [THOIGIAN]) VALUES (N'HD0012', 2, N'NV002', CAST(N'2024-05-25T18:00:13.000' AS DateTime))
GO
INSERT [dbo].[LOAIMATHANG] ([MALOAI], [TENLOAI]) VALUES (N'AVS', N'Ăn vặt & snack')
INSERT [dbo].[LOAIMATHANG] ([MALOAI], [TENLOAI]) VALUES (N'BEO', N'Béo')
INSERT [dbo].[LOAIMATHANG] ([MALOAI], [TENLOAI]) VALUES (N'DANG', N'Đắng')
INSERT [dbo].[LOAIMATHANG] ([MALOAI], [TENLOAI]) VALUES (N'DTS', N'Điểm Tâm Sáng')
INSERT [dbo].[LOAIMATHANG] ([MALOAI], [TENLOAI]) VALUES (N'ICB', N'Ice Blended')
INSERT [dbo].[LOAIMATHANG] ([MALOAI], [TENLOAI]) VALUES (N'SODA', N'Soda')
INSERT [dbo].[LOAIMATHANG] ([MALOAI], [TENLOAI]) VALUES (N'TUOI', N'Tươi')
INSERT [dbo].[LOAIMATHANG] ([MALOAI], [TENLOAI]) VALUES (N'THANH', N'Thanh')
INSERT [dbo].[LOAIMATHANG] ([MALOAI], [TENLOAI]) VALUES (N'YOGURT', N'Yogurt')
GO
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'AVS001', N'Xúc xích Đức', 10000, N'Cái', N'AVS')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'AVS002', N'Phô mai que', 10000, N'Đĩa', N'AVS')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'AVS003', N'Bánh tráng cuộn bơ', 20000, N'Cái', N'AVS')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'AVS004', N'Bánh tráng chấm me', 20000, N'Cái', N'AVS')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'AVS005', N'Bánh tráng trộn', 20000, N'Cái', N'AVS')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'AVS006', N'Bắp xào', 20000, N'Đĩa', N'AVS')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'AVS007', N'Khoai tây chiên', 20000, N'Đĩa', N'AVS')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'AVS008', N'Xoài lắc', 20000, N'Đĩa', N'AVS')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'AVS009', N'Trứng cút sốt me', 25000, N'Đĩa', N'AVS')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'AVS010', N'Mẹt chiên thập cẩm (vừa)', 40000, N'Mẹt', N'AVS')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'AVS011', N'Mẹt chiên thập cẩm (lớn)', 50000, N'Mẹt', N'AVS')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'AVS012', N'Bánh tráng bơ/dẻo tôm muối tắc', 12000, N'Cái', N'AVS')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'AVS013', N'Bánh tráng muối tắc/xì ke', 10000, N'Cái', N'AVS')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'AVS014', N'Hạt dưa/hướng dương', 10000, N'Đĩa', N'AVS')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'AVS015', N'Khô gà', 15000, N'Đĩa', N'AVS')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'AVS016', N'Xúc xích Mỹ', 10000, N'Cái', N'AVS')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'BEO001', N'Sữa tươi trân châu đường đen', 28000, N'Ly', N'BEO')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'BEO002', N'Trà sữa truyền thống trân châu đen', 25000, N'Ly', N'BEO')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'BEO003', N'Trà sữa thái xanh trân châu đen', 25000, N'Ly', N'BEO')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'BEO004', N'Trà sữa phủ kem Oreo', 35000, N'Ly', N'BEO')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'BEO005', N'Trà sữa kem Marshmalow', 35000, N'Ly', N'BEO')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'DANG001', N'Cà phê đen truyền thống', 15000, N'Ly', N'DANG')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'DANG002', N'Cà phê đen Bốn mùa', 18000, N'Ly', N'DANG')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'DANG003', N'Cà phê sữa truyền thống', 17000, N'Ly', N'DANG')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'DANG004', N'Cà phê sữa Bốn mùa', 20000, N'Ly', N'DANG')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'DANG005', N'Bạc xỉu/Cacao', 25000, N'Ly', N'DANG')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'DANG006', N'Cà phê cốt dừa đá xay', 28000, N'Ly', N'DANG')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'DANG007', N'Cacao cốt dừa đá xay', 28000, N'Ly', N'DANG')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'DANG008', N'Cà phê kem muối', 30000, N'Ly', N'DANG')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'DANG009', N'Cà phê kem trứng', 30000, N'Ly', N'DANG')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'DTS001', N'Bánh mì nướng muối ớt', 20000, N'Cái', N'DTS')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'DTS002', N'Cơm chiên cháy tỏi/muối é/ trứng', 18000, N'Cái', N'DTS')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'DTS003', N'Mì tôm nhà Góc', 23000, N'Cái', N'DTS')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'DTS004', N'Ốp la bánh mì', 23000, N'Cái', N'DTS')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'DTS005', N'Bánh mì xíu mại', 25000, N'Cái', N'DTS')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'DTS006', N'Bò né (phần nhỏ)', 27000, N'Cái', N'DTS')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'DTS007', N'Bò né (phần lớn)', 35000, N'Cái', N'DTS')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'DTS008', N'Bánh mì thêm', 5000, N'Cái', N'DTS')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'DTS009', N'Trừng rán thêm', 5000, N'Cái', N'DTS')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'ICB001', N'Chocolate đá xay', 30000, N'Ly', N'ICB')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'ICB002', N'Chocolate cookie đá xay', 35000, N'Ly', N'ICB')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'ICB003', N'Cà phê cookie đá xay', 35000, N'Ly', N'ICB')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'ICB004', N'Matcha đá xay', 35000, N'Ly', N'ICB')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'SODA001', N'Soda Blue Lychee', 25000, N'Ly', N'SODA')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'SODA002', N'Soda Vải', 25000, N'Ly', N'SODA')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'SODA003', N'Soda Chanh dây', 25000, N'Ly', N'SODA')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'SODA004', N'Soda Purple', 25000, N'Ly', N'SODA')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'TUOI001', N'Cà rốt', 27000, N'Ly', N'TUOI')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'TUOI002', N'Ôỉ', 27000, N'Ly', N'TUOI')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'TUOI003', N'Cam', 30000, N'Ly', N'TUOI')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'TUOI004', N'Chanh sữa', 25000, N'Ly', N'TUOI')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'TUOI005', N'Chanh dây sữa', 30000, N'Ly', N'TUOI')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'TUOI006', N'Đá chanh', 20000, N'Ly', N'TUOI')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'THANH001', N'Trà đào', 27000, N'Ly', N'THANH')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'THANH002', N'Trà vải hoa hồng', 27000, N'Ly', N'THANH')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'THANH003', N'Trà xoài chanh dây', 32000, N'Ly', N'THANH')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'THANH004', N'Trà ổi hồng thạch dừa', 32000, N'Ly', N'THANH')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'THANH005', N'Trà hoa rừng (nóng)', 30000, N'Ly', N'THANH')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'THANH006', N'Trà hoa quả nhiệt đới', 32000, N'Ly', N'THANH')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'THANH007', N'Trà nhà Góc', 32000, N'Ly', N'THANH')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'YOGURT001', N'Yogurt Phúc Bồn Tử/Kiwi', 32000, N'Ly', N'YOGURT')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'YOGURT002', N'Yogurt Việt quất/Xoài', 32000, N'Ly', N'YOGURT')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'YOGURT003', N'Yogurt đác rim', 32000, N'Ly', N'YOGURT')
INSERT [dbo].[MENU] ([MAMH], [TENMH], [GIACA], [DVT], [MALOAI]) VALUES (N'YOGURT004', N'Yogurt đá chanh', 28000, N'Ly', N'YOGURT')
GO
INSERT [dbo].[NHANVIEN] ([MANV], [HONV], [TENNV], [EMAIL], [DIACHI], [MATKHAU], [CHUCVU], [GIOITINH], [SDT], [CCCD]) VALUES (N'NV001', N'Nguyễn Đình', N'Hiệu', N'hieu@gmail.com', N'Đắk lắk', N'123', N'Quản Lý', 1, N'0901983555', N'056444111222')
INSERT [dbo].[NHANVIEN] ([MANV], [HONV], [TENNV], [EMAIL], [DIACHI], [MATKHAU], [CHUCVU], [GIOITINH], [SDT], [CCCD]) VALUES (N'NV002', N'Phan Châu Hải', N'Lâm', N'haicay@gmail.com', N'Khánh Hoà', N'123', N'Nhân Viên', 1, N'0904564654', N'056444111724')
INSERT [dbo].[NHANVIEN] ([MANV], [HONV], [TENNV], [EMAIL], [DIACHI], [MATKHAU], [CHUCVU], [GIOITINH], [SDT], [CCCD]) VALUES (N'NV003', N'Nguyễn Trần Việt', N'Hoàng', N'hoang@gmail.com', N'Khánh Hoà', N'123', N'Nhân Viên', 1, N'0415456465', N'056203444111')
GO
ALTER TABLE [dbo].[CHITIETHOADON]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETH_CHI_TIET__MENU] FOREIGN KEY([MAMH])
REFERENCES [dbo].[MENU] ([MAMH])
GO
ALTER TABLE [dbo].[CHITIETHOADON] CHECK CONSTRAINT [FK_CHITIETH_CHI_TIET__MENU]
GO
ALTER TABLE [dbo].[CHITIETHOADON]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETH_PHIEU_XUA_HOADON] FOREIGN KEY([MAHD])
REFERENCES [dbo].[HOADON] ([MAHD])
GO
ALTER TABLE [dbo].[CHITIETHOADON] CHECK CONSTRAINT [FK_CHITIETH_PHIEU_XUA_HOADON]
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [FK_HOADON_BAN_PHIEU_BAN] FOREIGN KEY([MABAN])
REFERENCES [dbo].[BAN] ([MABAN])
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [FK_HOADON_BAN_PHIEU_BAN]
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [FK_HOADON_NHAN_VIEN_NHANVIEN] FOREIGN KEY([MANV])
REFERENCES [dbo].[NHANVIEN] ([MANV])
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [FK_HOADON_NHAN_VIEN_NHANVIEN]
GO
ALTER TABLE [dbo].[MENU]  WITH CHECK ADD  CONSTRAINT [FK_MENU_REFERENCE_LOAIMATH] FOREIGN KEY([MALOAI])
REFERENCES [dbo].[LOAIMATHANG] ([MALOAI])
GO
ALTER TABLE [dbo].[MENU] CHECK CONSTRAINT [FK_MENU_REFERENCE_LOAIMATH]
GO
USE [master]
GO
ALTER DATABASE [CafeGocNho] SET  READ_WRITE 
GO
