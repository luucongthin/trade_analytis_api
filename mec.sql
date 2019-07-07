USE [master]
GO
/****** Object:  Database [bobbylct_mec]    Script Date: 7/7/2019 2:47:35 PM ******/
CREATE DATABASE [bobbylct_mec]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'bobbylct_mec', FILENAME = N'D:\mssql\MSSQL11.MSSQLSERVER\MSSQL\DATA\bobbylct_mec.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'bobbylct_mec_log', FILENAME = N'D:\mssql\MSSQL11.MSSQLSERVER\MSSQL\DATA\bobbylct_mec_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [bobbylct_mec] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [bobbylct_mec].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [bobbylct_mec] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [bobbylct_mec] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [bobbylct_mec] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [bobbylct_mec] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [bobbylct_mec] SET ARITHABORT OFF 
GO
ALTER DATABASE [bobbylct_mec] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [bobbylct_mec] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [bobbylct_mec] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [bobbylct_mec] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [bobbylct_mec] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [bobbylct_mec] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [bobbylct_mec] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [bobbylct_mec] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [bobbylct_mec] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [bobbylct_mec] SET  ENABLE_BROKER 
GO
ALTER DATABASE [bobbylct_mec] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [bobbylct_mec] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [bobbylct_mec] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [bobbylct_mec] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [bobbylct_mec] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [bobbylct_mec] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [bobbylct_mec] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [bobbylct_mec] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [bobbylct_mec] SET  MULTI_USER 
GO
ALTER DATABASE [bobbylct_mec] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [bobbylct_mec] SET DB_CHAINING OFF 
GO
ALTER DATABASE [bobbylct_mec] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [bobbylct_mec] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [bobbylct_mec]
GO
/****** Object:  User [bobbylct_report]    Script Date: 7/7/2019 2:47:35 PM ******/
CREATE USER [bobbylct_report] FOR LOGIN [bobbylct_report] WITH DEFAULT_SCHEMA=[bobbylct_report]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [bobbylct_report]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [bobbylct_report]
GO
ALTER ROLE [db_datareader] ADD MEMBER [bobbylct_report]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [bobbylct_report]
GO
/****** Object:  Schema [bobbylct_hotel_app]    Script Date: 7/7/2019 2:47:36 PM ******/
CREATE SCHEMA [bobbylct_hotel_app]
GO
/****** Object:  Schema [bobbylct_mec]    Script Date: 7/7/2019 2:47:36 PM ******/
CREATE SCHEMA [bobbylct_mec]
GO
/****** Object:  Schema [bobbylct_report]    Script Date: 7/7/2019 2:47:36 PM ******/
CREATE SCHEMA [bobbylct_report]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](200) NOT NULL,
	[title] [nvarchar](max) NULL,
	[code] [int] NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cities]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[city_code] [int] NOT NULL,
	[city_name] [nvarchar](50) NOT NULL,
	[country_id] [int] NOT NULL,
	[create_at] [datetime] NULL,
	[update_at] [datetime] NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Counties]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Counties](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[country_code] [int] NOT NULL,
	[country_name] [nvarchar](50) NOT NULL,
	[create_at] [datetime] NULL,
	[update_at] [datetime] NULL,
 CONSTRAINT [PK_Counties] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Districts]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Districts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[district_code] [int] NOT NULL,
	[district_name] [nvarchar](50) NOT NULL,
	[city_id] [int] NOT NULL,
	[create_at] [datetime] NULL,
	[update_at] [datetime] NULL,
 CONSTRAINT [PK_Districts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Legislations]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Legislations](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](200) NOT NULL,
	[description] [nvarchar](max) NULL,
	[summary] [nvarchar](max) NOT NULL,
	[start_date] [datetime] NOT NULL,
	[end_date] [datetime] NOT NULL,
	[category_code] [int] NOT NULL,
	[reporter_code] [int] NOT NULL,
	[partner_code] [int] NOT NULL,
	[implementing_authority] [nchar](10) NULL,
	[is_importing_country] [int] NOT NULL,
 CONSTRAINT [PK_Legislations] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NTM]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NTM](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[reporter] [nvarchar](200) NULL,
	[reporter_code] [nchar](10) NOT NULL,
	[partner] [nvarchar](200) NULL,
	[partner_code] [nchar](100) NOT NULL,
	[partner_comment] [nvarchar](max) NULL,
	[product_code] [nchar](10) NOT NULL,
	[product_coverage] [nchar](10) NULL,
	[hs_revision] [nvarchar](200) NOT NULL,
	[product_comment] [nvarchar](max) NULL,
	[ntm_code] [nchar](10) NOT NULL,
	[ntm_revision] [nchar](100) NULL,
	[ntm_comment] [nvarchar](max) NULL,
	[category_code] [nchar](10) NULL,
 CONSTRAINT [PK_NTM] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Permissions]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permissions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[code] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Permissions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoleHasPermission]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleHasPermission](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[role_id] [int] NOT NULL,
	[permission_id] [int] NOT NULL,
 CONSTRAINT [PK_RoleHasPermission] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Roles]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[des] [nvarchar](50) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Store]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Store](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[code] [int] NOT NULL,
	[name] [nvarchar](200) NOT NULL,
	[adress] [nvarchar](max) NULL,
	[information] [nvarchar](max) NOT NULL,
	[ward_code] [int] NOT NULL,
	[latitude] [nvarchar](20) NOT NULL,
	[longitude] [nvarchar](20) NOT NULL,
	[category_code] [int] NOT NULL,
	[type] [nvarchar](50) NULL,
	[note] [nvarchar](max) NULL,
 CONSTRAINT [PK_Store] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Table_Config]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_Config](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](50) NOT NULL,
	[value_int] [int] NULL,
	[value_char] [nchar](250) NULL,
 CONSTRAINT [PK_Table_Config] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Table_Port]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_Port](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Vps_Id] [int] NOT NULL,
	[Port] [nchar](5) NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Table_Port] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Table_User]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[FullName] [nvarchar](250) NULL,
	[Password] [nvarchar](15) NOT NULL,
	[Email] [nvarchar](100) NULL,
 CONSTRAINT [PK_Table_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Table_Vps]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_Vps](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ip] [nchar](15) NOT NULL,
	[Status] [int] NOT NULL,
	[Title] [nchar](100) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[Ram_Total] [nchar](10) NOT NULL,
	[Ram_Used] [nchar](10) NOT NULL,
	[Disk_Total] [nchar](10) NOT NULL,
	[Disk_Used] [nchar](10) NOT NULL,
	[UserName] [nchar](100) NOT NULL,
	[PassWord] [nchar](100) NOT NULL,
 CONSTRAINT [PK_Table_Vps] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserHasRole]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserHasRole](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[role_id] [int] NOT NULL,
 CONSTRAINT [PK_UserHasRole] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [nvarchar](50) NOT NULL,
	[last_name] [nvarchar](50) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[create_at] [datetime] NULL,
	[update_at] [datetime] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Wards]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Wards](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ward_code] [varchar](5) NOT NULL,
	[ward_name] [nvarchar](50) NOT NULL,
	[type] [nvarchar](50) NOT NULL,
	[district_code] [varchar](5) NOT NULL,
	[district_name] [nvarchar](50) NULL,
	[city_code] [varchar](5) NOT NULL,
	[city_name] [nvarchar](50) NULL,
	[population] [int] NULL,
	[area] [int] NULL,
	[create_at] [datetime] NULL,
	[update_at] [datetime] NULL,
 CONSTRAINT [PK_Wards] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([ID], [name], [title], [code]) VALUES (1, N'Apple', N'Apple', 1)
INSERT [dbo].[Categories] ([ID], [name], [title], [code]) VALUES (2, N'Milk', N'Milk descreption', 123)
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[Table_Config] ON 

INSERT [dbo].[Table_Config] ([id], [name], [value_int], [value_char]) VALUES (1, N'time_scan                                         ', 32, NULL)
INSERT [dbo].[Table_Config] ([id], [name], [value_int], [value_char]) VALUES (2, N'scan_status                                       ', 0, NULL)
SET IDENTITY_INSERT [dbo].[Table_Config] OFF
SET IDENTITY_INSERT [dbo].[Table_Port] ON 

INSERT [dbo].[Table_Port] ([Id], [Vps_Id], [Port], [Status]) VALUES (1, 1, N'22   ', 1)
INSERT [dbo].[Table_Port] ([Id], [Vps_Id], [Port], [Status]) VALUES (2, 2, N'22   ', 1)
INSERT [dbo].[Table_Port] ([Id], [Vps_Id], [Port], [Status]) VALUES (3, 3, N'22   ', 1)
INSERT [dbo].[Table_Port] ([Id], [Vps_Id], [Port], [Status]) VALUES (4, 1, N'80   ', 1)
INSERT [dbo].[Table_Port] ([Id], [Vps_Id], [Port], [Status]) VALUES (5, 1, N'3030 ', 1)
INSERT [dbo].[Table_Port] ([Id], [Vps_Id], [Port], [Status]) VALUES (6, 2, N'3444 ', 1)
INSERT [dbo].[Table_Port] ([Id], [Vps_Id], [Port], [Status]) VALUES (7, 3, N'1200 ', 1)
SET IDENTITY_INSERT [dbo].[Table_Port] OFF
SET IDENTITY_INSERT [dbo].[Table_User] ON 

INSERT [dbo].[Table_User] ([Id], [UserName], [FullName], [Password], [Email]) VALUES (1, N'admin', N'Administrator', N'123456', N'Aministrator')
INSERT [dbo].[Table_User] ([Id], [UserName], [FullName], [Password], [Email]) VALUES (2, N'ahihi', N'luuthin', N'123456', N'luuthin@gmail.c')
SET IDENTITY_INSERT [dbo].[Table_User] OFF
SET IDENTITY_INSERT [dbo].[Table_Vps] ON 

INSERT [dbo].[Table_Vps] ([Id], [Ip], [Status], [Title], [Description], [Ram_Total], [Ram_Used], [Disk_Total], [Disk_Used], [UserName], [PassWord]) VALUES (1, N'192.168.0.1    ', 1, N'bobbylct                                                                                            ', N'bobbylct', N'2000      ', N'500       ', N'20000     ', N'10000     ', N'root                                                                                                ', N'Luuthin_51996                                                                                       ')
INSERT [dbo].[Table_Vps] ([Id], [Ip], [Status], [Title], [Description], [Ram_Total], [Ram_Used], [Disk_Total], [Disk_Used], [UserName], [PassWord]) VALUES (2, N'192.168.222.111', 0, N'ahihi                                                                                               ', N'ahihi', N'2000      ', N'500       ', N'20000     ', N'10000     ', N'root                                                                                                ', N'Luuthin_51996                                                                                       ')
INSERT [dbo].[Table_Vps] ([Id], [Ip], [Status], [Title], [Description], [Ram_Total], [Ram_Used], [Disk_Total], [Disk_Used], [UserName], [PassWord]) VALUES (3, N'192.168.222.123', 1, N'ahihi                                                                                               ', N'ahihi', N'2000      ', N'500       ', N'20000     ', N'10000     ', N'root                                                                                                ', N'Luuthin_51996                                                                                       ')
SET IDENTITY_INSERT [dbo].[Table_Vps] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [first_name], [last_name], [username], [password], [email], [create_at], [update_at]) VALUES (1, N'Luu Cong', N'Thin', N'luuthin', N'234234', N'luuthin@gmail.c', CAST(N'2019-02-27 00:37:58.260' AS DateTime), CAST(N'2019-03-03 14:27:57.223' AS DateTime))
INSERT [dbo].[Users] ([ID], [first_name], [last_name], [username], [password], [email], [create_at], [update_at]) VALUES (3, N'string1', N'strin2g1', N'string', N'', N'string1', CAST(N'2019-03-01 22:36:33.847' AS DateTime), CAST(N'2019-03-03 14:27:15.557' AS DateTime))
INSERT [dbo].[Users] ([ID], [first_name], [last_name], [username], [password], [email], [create_at], [update_at]) VALUES (4, N'123123', N'123123', N'123123', N'123123', N'123123', CAST(N'2019-03-03 14:29:51.413' AS DateTime), NULL)
INSERT [dbo].[Users] ([ID], [first_name], [last_name], [username], [password], [email], [create_at], [update_at]) VALUES (5, N'qweqwe', N'Luu Cong', N'qweqwe', N'123123', N'qweqwe@qweqwe', CAST(N'2019-03-03 14:55:59.907' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
SET IDENTITY_INSERT [dbo].[Wards] ON 

INSERT [dbo].[Wards] ([ID], [ward_code], [ward_name], [type], [district_code], [district_name], [city_code], [city_name], [population], [area], [create_at], [update_at]) VALUES (1, N'0002', N'Phường Liễu Giai', N'Phường', N'002', N'Quận Ba Đình', N'01', N'Thành phố Hà Nội', 234234, 123123, CAST(N'2019-02-28 12:56:22.547' AS DateTime), CAST(N'2019-03-04 01:56:43.437' AS DateTime))
INSERT [dbo].[Wards] ([ID], [ward_code], [ward_name], [type], [district_code], [district_name], [city_code], [city_name], [population], [area], [create_at], [update_at]) VALUES (3, N'00004', N'Phường Trúc Bạch', N'Phường', N'001', N'Quận Ba Đình', N'01', N'Thành phố Hà Nội', 9080000, 100000, CAST(N'2019-02-28 12:56:22.547' AS DateTime), CAST(N'2019-02-28 13:03:59.727' AS DateTime))
INSERT [dbo].[Wards] ([ID], [ward_code], [ward_name], [type], [district_code], [district_name], [city_code], [city_name], [population], [area], [create_at], [update_at]) VALUES (4, N'17581', N'Xã Minh Thành', N'Xã', N'426', N'Huyện Yên Thành', N'40', N'Tỉnh Nghệ An', 9080000, 100000, CAST(N'2019-02-28 12:56:22.547' AS DateTime), CAST(N'2019-02-28 13:03:59.727' AS DateTime))
INSERT [dbo].[Wards] ([ID], [ward_code], [ward_name], [type], [district_code], [district_name], [city_code], [city_name], [population], [area], [create_at], [update_at]) VALUES (5, N'00007', N'Phường Cống Vị', N'Phường', N'001', N'Quận Ba Đình', N'01', N'Thành phố Hà Nội', 9080000, 100000, CAST(N'2019-02-28 12:56:22.547' AS DateTime), CAST(N'2019-02-28 13:03:59.727' AS DateTime))
INSERT [dbo].[Wards] ([ID], [ward_code], [ward_name], [type], [district_code], [district_name], [city_code], [city_name], [population], [area], [create_at], [update_at]) VALUES (6, N'12312', N'1123', N'123', N'123', N'123', N'123', N'123', 123, 123, CAST(N'2019-02-28 12:56:22.547' AS DateTime), CAST(N'2019-03-04 01:33:35.353' AS DateTime))
INSERT [dbo].[Wards] ([ID], [ward_code], [ward_name], [type], [district_code], [district_name], [city_code], [city_name], [population], [area], [create_at], [update_at]) VALUES (1002, N'345', N'345', N'123', N'345', N'345', N'354', N'345', 345, 453, CAST(N'2019-03-04 01:34:25.843' AS DateTime), CAST(N'2019-03-04 01:56:28.030' AS DateTime))
INSERT [dbo].[Wards] ([ID], [ward_code], [ward_name], [type], [district_code], [district_name], [city_code], [city_name], [population], [area], [create_at], [update_at]) VALUES (1003, N'12312', N'123123', N'123', N'strin', N'string', N'strin', N'string', 123123, 123123, CAST(N'2019-03-04 02:00:20.173' AS DateTime), NULL)
INSERT [dbo].[Wards] ([ID], [ward_code], [ward_name], [type], [district_code], [district_name], [city_code], [city_name], [population], [area], [create_at], [update_at]) VALUES (1004, N'12312', N'123123', N'123', N'strin', N'string', N'strin', N'string', 123123, 123123, CAST(N'2019-03-04 02:00:52.223' AS DateTime), NULL)
INSERT [dbo].[Wards] ([ID], [ward_code], [ward_name], [type], [district_code], [district_name], [city_code], [city_name], [population], [area], [create_at], [update_at]) VALUES (1005, N'1231', N'123123', N'123123', N'12312', N'123123', N'12312', N'123123', 123123, 123123, CAST(N'2019-03-04 02:04:17.740' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Wards] OFF
/****** Object:  StoredProcedure [dbo].[AddCategoryData]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddCategoryData] (
	@Name nvarchar(200),
	@Title nvarchar(MAX),
	@Code int
	)
AS
BEGIN
	set nocount on;
	Insert into Categories(
		name,
		title,
		code
	)
	Values(
		@Name,
		@Title,
		@Code
	)
	set nocount off;
END
GO
/****** Object:  StoredProcedure [dbo].[AddStoreData]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddStoreData] (
	@Code varchar(5),
	@Name nvarchar(200),
	@Adress nvarchar(MAX),
	@Information nvarchar(MAX),
	@WardCode varchar(5),
	@Latitude varchar(50),
	@Longitude varchar(50),
	@CategoryCode varchar(5),
	@Type nvarchar(50),
	@Note nvarchar(MAX)
	)
AS
BEGIN
	set nocount on;
	Insert into Store(
		code,
		name,
		adress,
		information,
		ward_code,
		latitude,
		longitude,
		category_code,
		type,
		note
	)
	Values(
		@Code ,
		@Name ,
		@Adress ,
		@Information ,
		@WardCode ,
		@Latitude ,
		@Longitude ,
		@CategoryCode ,
		@Type ,
		@Note 
	)
	set nocount off;
END
GO
/****** Object:  StoredProcedure [dbo].[AddUserData]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddUserData] (
	@UserName nvarchar(50),
	@FullName nvarchar(250),
	@Password  nvarchar(15),
	@Email nvarchar(15)
	)
AS
BEGIN
	set nocount on;
	Insert into Table_User(
		UserName,
		FullName,
		Password,
		Email
	)
	Values(
		@UserName,
		@FullName,
		@Password,
		@Email
	)
	set nocount off;
END
GO
/****** Object:  StoredProcedure [dbo].[AddWardData]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddWardData] (
	@WardCode varchar(5),
	@WardName nvarchar(50),
	@Type nvarchar(50),
	@DistrictCode varchar(5),
	@DistrictName nvarchar(50),
	@CityCode varchar(5),
	@CityName nvarchar(50),
	@Population nchar(20),
	@Area nchar(20)
	)
AS
BEGIN
	set nocount on;
	Insert into Wards(
		ward_code,
		ward_name,
		type,
		district_code,
		district_name,
		city_code,
		city_name,
		population,
		area,
		create_at
	)
	Values(
		@WardCode,
		@WardName,
		@Type,
		@DistrictCode,
		@DistrictName,
		@CityCode,
		@CityName,
		@Population,
		@Area,
		getdate()
	)
	set nocount off;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteCategoryData]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteCategoryData] (
	@ID int
	)
AS
BEGIN
	set nocount on;
		
		DELETE Categories where ID = @ID

	set nocount off;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteLegislationData]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteLegislationData] (
	@ID int
	)
AS
BEGIN
	set nocount on;
		
		DELETE Legislations where ID = @ID

	set nocount off;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteStoreData]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteStoreData] (
	@ID int
	)
AS
BEGIN
	set nocount on;
		
		DELETE Store where ID = @ID

	set nocount off;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteWardData]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteWardData] (
	@ID int
	)
AS
BEGIN
	set nocount on;
		
		DELETE Wards where ID = @ID

	set nocount off;
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllVps]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllVps]
AS
BEGIN
	set nocount on;
	select * from Table_Vps
	set nocount off;
END
GO
/****** Object:  StoredProcedure [dbo].[GetMeansuer]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetMeansuer] (
	@CategoryCode nvarchar(50),
	@Reporter nvarchar(20),
	@Product nvarchar(20),
	@Page int,
	@Size int
	)
AS
BEGIN
	set nocount on;

	SET @CategoryCode = (SELECT CASE WHEN @CategoryCode <> '' THEN @CategoryCode ELSE NULL END)
	SET @Product = (SELECT CASE WHEN @Product <> '' THEN @Product ELSE NULL END)
	SET @Reporter = (SELECT CASE WHEN @Reporter <> '' THEN @Reporter ELSE NULL END)


	--Select * 
	--FROM NTM
	--Where ((@CategoryCode IS NOT NULL AND category_code  like '%' + @CategoryCode + '%') OR (@CategoryCode IS NULL))
	--AND ((@Reporter IS NOT NULL AND reporter  like '%' + @Reporter + '%') OR (@Reporter IS NULL))
	--AND ((@Product IS NOT NULL AND product_code  like '%' + @Product + '%') OR (@Product IS NULL))

	Select COUNT(ID) AS TOTAL
	INTO #TOTAL
	from NTM
	Where ((@CategoryCode IS NOT NULL AND category_code  like '%' + @CategoryCode + '%') OR (@CategoryCode IS NULL))
	AND ((@Reporter IS NOT NULL AND reporter  like '%' + @Reporter + '%') OR (@Reporter IS NULL))
	AND ((@Product IS NOT NULL AND product_code  like '%' + @Product + '%') OR (@Product IS NULL))

	SELECT * 
	INTO #DATA
	FROM
		(
			SELECT *, ROW_NUMBER() OVER (ORDER BY ID) AS Total
			FROM NTM
			Where ((@CategoryCode IS NOT NULL AND category_code  like '%' + @CategoryCode + '%') OR (@CategoryCode IS NULL))
			AND ((@Reporter IS NOT NULL AND reporter  like '%' + @Reporter + '%') OR (@Reporter IS NULL))
			AND ((@Product IS NOT NULL AND product_code  like '%' + @Product + '%') OR (@Product IS NULL))
		) AS TMP
	Where TMP.Total BETWEEN (((@Page - 1)* @Size) + 1) AND @Page * @Size
	
	UPDATE #DATA set Total = (select TOP 1 TOTAL from #TOTAL)
	SELECT * FROM #DATA

		
	set nocount off;
END
GO
/****** Object:  StoredProcedure [dbo].[GetPortByVpsID]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetPortByVpsID](
	@VPS_Id int	
)
AS
BEGIN
	set nocount on;
	select * from Table_Port where Vps_Id = @VPS_Id
	set nocount off;
END
GO
/****** Object:  StoredProcedure [dbo].[GetStatusScan]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetStatusScan]
AS
BEGIN
	set nocount on;
	select value_int from Table_Config WHERE name = 'scan_status'
	set nocount off;
END
GO
/****** Object:  StoredProcedure [dbo].[GetTimeScan]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTimeScan]
AS
BEGIN
	set nocount on;
	select value_int from Table_Config WHERE name = 'time_scan'
	set nocount off;
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserData]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserData] (
	@ID int
	)
AS
BEGIN
	set nocount on;
	/*****
		TypeSearch = 0 : Không cần search theo Password chỉ cần search theo tên
		TypeSearch = 1 : Bắt buộc Search Có Password
	**/
	Select * from Users
	Where ID = @ID
		
	set nocount off;
END
GO
/****** Object:  StoredProcedure [dbo].[GetVpsAll]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetVpsAll]
AS
BEGIN
	set nocount on;
	select * from Table_Vps
	set nocount off;
END
GO
/****** Object:  StoredProcedure [dbo].[GetVpsByID]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetVpsByID](
	@Id int	
)
AS
BEGIN
	set nocount on;
	select * from Table_Vps where Id = @Id
	set nocount off;
END
GO
/****** Object:  StoredProcedure [dbo].[GetVpsInfo]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetVpsInfo] (
	@Id nvarchar(50),
	@TypeSearch int
	)
AS
BEGIN
	set nocount on;
	/*****
		TypeSearch = 0 : Get all
		TypeSearch = 1 : Get one
	**/

	IF @Id IS NOT NULL AND @TypeSearch = 1
     Select * from Table_Vps where Id = @Id
	ELSE   
	 Select * from Table_Vps
		
	set nocount off;
END
GO
/****** Object:  StoredProcedure [dbo].[ImportNTM]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: SQLQuery6.sql|7|0|C:\Users\DELL\AppData\Local\Temp\~vs2523.sql
CREATE PROCEDURE [dbo].[ImportNTM] (
	@Data XML
	)
AS
BEGIN
	set nocount on;
	Insert into NTM(
		reporter,
		reporter_code,
		partner,
		partner_code,
		partner_comment,
		product_code,
		product_coverage,
		hs_revision,
		product_comment,
		ntm_code,
		ntm_revision,
		ntm_comment
		)
	SELECT 
		x.i.value('./Reporter[1]', 'nvarchar(MAX)'),
		x.i.value('./ReporterCode[1]', 'nvarchar(MAX)'),
		x.i.value('./Partner[1]', 'nvarchar(MAX)'),
		x.i.value('./PartnerCode[1]', 'nvarchar(MAX)'),
		x.i.value('./PartnerComment[1]', 'nvarchar(MAX)'),
		x.i.value('./ProductCode[1]', 'nvarchar(MAX)'),
		x.i.value('./ProductCoverage[1]', 'nvarchar(MAX)'),
		x.i.value('./HSRevision[1]', 'nvarchar(MAX)'),
		x.i.value('./ProductComment[1]', 'nvarchar(MAX)'),
		x.i.value('./NTMCode[1]', 'nvarchar(MAX)'),
		x.i.value('./NTMRevision[1]', 'nvarchar(MAX)'),
		x.i.value('./NTMComment[1]', 'nvarchar(MAX)')
	FROM 
	@Data.nodes('/Data/Item') as x(i);
	set nocount off;
END
GO
/****** Object:  StoredProcedure [dbo].[ImportStore]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: SQLQuery6.sql|7|0|C:\Users\DELL\AppData\Local\Temp\~vs2523.sql
CREATE PROCEDURE [dbo].[ImportStore] (
	@Data XML
	)
AS
BEGIN
	set nocount on;
	Insert into Store(
		code,
		name,
		adress,
		information,
		ward_code,
		latitude,
		longitude,
		category_code,
		type,
		note
		)
	SELECT 
		x.i.value('./Code[1]', 'varchar(5)'),
		x.i.value('./Name[1]', 'nvarchar(200)'),
		x.i.value('./Adress[1]', 'nvarchar(MAX)'),
		x.i.value('./Information[1]', 'nvarchar(MAX)'),
		x.i.value('./WardCode[1]', 'varchar(5)'),
		x.i.value('./Latitude[1]', 'varchar(50)'),
		x.i.value('./Longitude[1]', 'varchar(50)'),
		x.i.value('./CategoryCode[1]', 'varchar(5)'),
		x.i.value('./Type[1]', 'nvarchar(50)'),
		x.i.value('./Note[1]', 'nvarchar(Max)')
	FROM 
	@Data.nodes('/Data/Item') as x(i);
	set nocount off;
END
GO
/****** Object:  StoredProcedure [dbo].[ImportWard]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: SQLQuery6.sql|7|0|C:\Users\DELL\AppData\Local\Temp\~vs2523.sql
CREATE PROCEDURE [dbo].[ImportWard] (
	@Data XML
	)
AS
BEGIN
	set nocount on;
	Insert into Wards(
		ward_code,
		ward_name,
		type,
		district_code,
		district_name,
		city_code,
		city_name,
		population,
		area,
		create_at
		)
	SELECT 
		x.i.value('./WardCode[1]','varchar(5)'),
		x.i.value('./WardName[1]','nvarchar(50)'),
		x.i.value('./Type[1]','nvarchar(50)'),
		x.i.value('./DistrictCode[1]','varchar(5)'),
		x.i.value('./DistrictName[1]','nvarchar(250)'),
		x.i.value('./CityCode[1]','varchar(5)'),
		x.i.value('./CityName[1]','nvarchar(50)'),
		x.i.value('./Population[1]','nchar(20)'),
		x.i.value('./Area[1]','nchar(20)'),
		getdate()
	FROM 
	@Data.nodes('/Data/Item') as x(i);
	set nocount off;
END
GO
/****** Object:  StoredProcedure [dbo].[SearchCategoryData]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SearchCategoryData] (
	@Name nvarchar(50),
	@Title  nvarchar(50),
	@Code nvarchar(50)
	)
AS
BEGIN
	set nocount on;
	/*****
		TypeSearch = 0 : Không cần search theo Password chỉ cần search theo tên
		TypeSearch = 1 : Bắt buộc Search Có Password
	**/
	Select * from Categories
	Where ((@Name IS NOT NULL AND name like '%' + @Name +'%') OR (@Name IS NULL))
	AND ((@Title IS NOT NULL AND title like '%' + @Title + '%') OR (@Title IS NULL))
	AND ((@Code IS NOT NULL AND code like '%' + @Code + '%') OR (@Code IS NULL))
		
	set nocount off;
END
GO
/****** Object:  StoredProcedure [dbo].[SearchCityData]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SearchCityData] (
	@CityName nvarchar(50)
	)
AS
BEGIN
	set nocount on;

	Select DISTINCT(city_code), city_name from Wards
	Where ((@CityName IS NOT NULL AND city_name  like N'%' + @CityName + '%') OR (@CityName IS NULL))
		
	set nocount off;
END
GO
/****** Object:  StoredProcedure [dbo].[SearchDistrictData]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SearchDistrictData] (
	@CityCode varchar(10),
	@DistrictName nvarchar(50)
	)
AS
BEGIN
	set nocount on;

	Select DISTINCT(district_code), district_name from Wards
	Where ((@DistrictName IS NOT NULL AND district_name  like N'%' + @DistrictName + '%') OR (@DistrictName IS NULL))
	AND ((@CityCode IS NOT NULL AND city_code = @CityCode) OR (@CityCode IS NULL))
		
	set nocount off;
END
GO
/****** Object:  StoredProcedure [dbo].[SearchLegislationData]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SearchLegislationData] (
	@CategoryCode nvarchar(50),
	@StartDate  nvarchar(50),
	@EndDate nvarchar(50),
	@Page int,
	@Size int
	)
AS
BEGIN
	set nocount on;

	SET @CategoryCode = (SELECT CASE WHEN @CategoryCode <> '' THEN @CategoryCode ELSE NULL END)
	SET @StartDate = (SELECT CASE WHEN @StartDate <> '' THEN @StartDate ELSE NULL END)
	SET @EndDate = (SELECT CASE WHEN @EndDate <> '' THEN @EndDate ELSE NULL END)


	Select COUNT(ID) AS TOTAL
	INTO #TOTAL
	from Legislations
	Where ((@CategoryCode IS NOT NULL AND category_code  like '%' + @CategoryCode + '%') OR (@CategoryCode IS NULL))
	AND ((@StartDate IS NOT NULL AND @EndDate IS NULL AND start_date <= convert(datetime, @StartDate ,103))
		 OR (@StartDate IS NULL AND @EndDate IS NOT NULL AND end_date >= convert(datetime, @EndDate ,103))
		 OR (@StartDate IS NOT NULL AND @EndDate IS NOT NULL AND end_date >= convert(datetime, @EndDate ,103) AND start_date <= convert(datetime, @StartDate ,103))
		 OR (@StartDate IS NULL AND @EndDate IS NULL))


	SELECT * 
	INTO #DATA
	FROM
		(
			SELECT *, ROW_NUMBER() OVER (ORDER BY ID) AS Total
			FROM Legislations
			Where ((@CategoryCode IS NOT NULL AND category_code  like '%' + @CategoryCode + '%') OR (@CategoryCode IS NULL))
			AND ((@StartDate IS NOT NULL AND @EndDate IS NULL AND start_date <= convert(datetime, @StartDate ,103))
				 OR (@StartDate IS NULL AND @EndDate IS NOT NULL AND end_date >= convert(datetime, @EndDate ,103))
				 OR (@StartDate IS NOT NULL AND @EndDate IS NOT NULL AND end_date >= convert(datetime, @EndDate ,103) AND start_date <= convert(datetime, @StartDate ,103))
				 OR (@StartDate IS NULL AND @EndDate IS NULL))
		) AS TMP
	Where TMP.Total BETWEEN (((@Page - 1)* @Size) + 1) AND @Page * @Size
	
	UPDATE #DATA set Total = (select TOP 1 TOTAL from #TOTAL)
	SELECT * FROM #DATA
		
	set nocount off;
END
GO
/****** Object:  StoredProcedure [dbo].[SearchLegislationDataByID]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SearchLegislationDataByID] (
	@ID int
	)
AS
BEGIN
	set nocount on;

	SELECT * FROM Legislations WHERE ID = @ID
		
	set nocount off;
END
GO
/****** Object:  StoredProcedure [dbo].[SearchLikeUserData]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SearchLikeUserData] (
	@UserName nvarchar(50),
	@Email  nvarchar(100),
	@TypeSearch int
	)
AS
BEGIN
	set nocount on;

	/*****
		TypeSearch = 0 : Không cần search theo Password chỉ cần search theo tên
		TypeSearch = 1 : Bắt buộc Search Có Password
	**/
	Select * from Table_User
	Where 
	  ((@UserName IS NOT NULL AND UserName Like N'%'+ @UserName + '%') OR 
	  (
		@TypeSearch = 0 AND @UserName IS NULL
	  )
	  )
	and (
		(@Email IS NOT NULL AND Email Like N'%' + @Email + '%') OR 
		(@TypeSearch = 0 AND @Email IS NULL)
		)
		
	set nocount off;
END
GO
/****** Object:  StoredProcedure [dbo].[SearchProductData]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SearchProductData] (
	@Name nvarchar(50)
	)
AS
BEGIN
	set nocount on;
	/*****
		TypeSearch = 0 : Không cần search theo Password chỉ cần search theo tên
		TypeSearch = 1 : Bắt buộc Search Có Password
	**/
	select
		distinct(product_code) as code,
		product_code as name
	from NTM
	Where ((@Name IS NOT NULL AND product_code like '%' + @Name +'%') OR (@Name IS NULL))
		
	set nocount off;
END
GO
/****** Object:  StoredProcedure [dbo].[SearchReporterData]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SearchReporterData] (
	@Name nvarchar(50)
	)
AS
BEGIN
	set nocount on;
	/*****
		TypeSearch = 0 : Không cần search theo Password chỉ cần search theo tên
		TypeSearch = 1 : Bắt buộc Search Có Password
	**/
	select
		distinct(reporter_code),
		reporter 
	from NTM
	Where ((@Name IS NOT NULL AND reporter like '%' + @Name +'%') OR (@Name IS NULL))
		
	set nocount off;
END
GO
/****** Object:  StoredProcedure [dbo].[SearchStoreData]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SearchStoreData] (
	@Name nvarchar(50),
	@CategoryCode  nvarchar(50),
	@Adress nvarchar(50),
	@WardCode nvarchar(50),
	@Page int,
	@Size int
	)
AS
BEGIN
	set nocount on;
	/*****
		TypeSearch = 0 : Không cần search theo Password chỉ cần search theo tên
		TypeSearch = 1 : Bắt buộc Search Có Password
	**/


	Select COUNT(ID) AS TOTAL
	INTO #TOTAL 
	from Store
	Where ((@Name IS NOT NULL AND name like '%' + @Name +'%') OR (@Name IS NULL))
	AND ((@CategoryCode IS NOT NULL AND category_code like '%' + @CategoryCode + '%') OR (@CategoryCode IS NULL))
	AND ((@Adress IS NOT NULL AND adress like '%' + @Adress + '%') OR (@Adress IS NULL))
	AND ((@WardCode IS NOT NULL AND ward_code like '%' + @WardCode + '%') OR (@WardCode IS NULL))




	SELECT * 
	INTO #DATA
	FROM
		(
			SELECT *, ROW_NUMBER() OVER (ORDER BY ID) AS Total
			FROM Store
			Where ((@Name IS NOT NULL AND name like '%' + @Name +'%') OR (@Name IS NULL))
			AND ((@CategoryCode IS NOT NULL AND category_code like '%' + @CategoryCode + '%') OR (@CategoryCode IS NULL))
			AND ((@Adress IS NOT NULL AND adress like '%' + @Adress + '%') OR (@Adress IS NULL))
			AND ((@WardCode IS NOT NULL AND ward_code like '%' + @WardCode + '%') OR (@WardCode IS NULL))
		) AS TMP
	Where  TMP.Total BETWEEN (((@Page - 1)* @Size) + 1) AND @Page * @Size
	
	UPDATE #DATA set Total = (select TOP 1 TOTAL from #TOTAL)
	SELECT * FROM #DATA
		
	set nocount off;
END
GO
/****** Object:  StoredProcedure [dbo].[SearchStoreDataByID]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SearchStoreDataByID] (
	@ID int
	)
AS
BEGIN
	set nocount on;
	/*****
		TypeSearch = 0 : Không cần search theo Password chỉ cần search theo tên
		TypeSearch = 1 : Bắt buộc Search Có Password
	**/
	Select * from Store WHERE ID = @ID
		
	set nocount off;
END
GO
/****** Object:  StoredProcedure [dbo].[SearchUserData]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SearchUserData] (
	@UserName nvarchar(50),
	@Password  nvarchar(15),
	@TypeSearch int
	)
AS
BEGIN
	set nocount on;
	/*****
		TypeSearch = 0 : Không cần search theo Password chỉ cần search theo tên
		TypeSearch = 1 : Bắt buộc Search Có Password
	**/
	Select * from Table_User
	Where 
	  ((@UserName IS NOT NULL AND UserName = @UserName) OR 
	  (
		@TypeSearch = 0 AND @UserName IS NULL
	  )
	  )
	and (
		(@Password IS NOT NULL AND Password = @Password) OR 
		(@TypeSearch = 0 AND @Password IS NULL)
		)
		
	set nocount off;
END
GO
/****** Object:  StoredProcedure [dbo].[SearchWardData]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SearchWardData] (
	@CityCode nvarchar(50),
	@DistrictCode  nvarchar(50),
	@WardName nvarchar(50)
	)
AS
BEGIN
	set nocount on;

	Select * from Wards
	Where ((@CityCode IS NOT NULL AND city_code  like '%' + @CityCode + '%') OR (@CityCode IS NULL))
	AND ((@DistrictCode IS NOT NULL AND district_code like '%' + @DistrictCode + '%') OR (@DistrictCode IS NULL))
	AND ((@WardName IS NOT NULL AND ward_name like N'%' + @WardName + '%') OR (@WardName IS NULL))
		
	set nocount off;
END
GO
/****** Object:  StoredProcedure [dbo].[SearchWardDataByID]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SearchWardDataByID] (
	@ID int
	)
AS
BEGIN
	set nocount on;

	Select * from Wards Where ID = @ID
		
	set nocount off;
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateCategoryData]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateCategoryData] (
	@ID int,
	@Name nvarchar(200),
	@Title nvarchar(MAX),
	@Code int
	)
AS
BEGIN
	set nocount on;
	UPDATE Categories
	SET name = @Name,
		title = @Title,
		code = @Code
	WHERE ID = @ID
	set nocount off;
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateStatusScan]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateStatusScan](
	@Scan_status int
)
AS
BEGIN
	set nocount on;
	Update Table_Config set value_int = @Scan_status WHERE name = 'scan_status'
	set nocount off;
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateStoreData]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateStoreData] (
	@ID int,
	@Code varchar(5),
	@Name nvarchar(200),
	@Adress nvarchar(MAX),
	@Information nvarchar(MAX),
	@WardCode varchar(5),
	@Latitude varchar(50),
	@Longitude varchar(50),
	@CategoryCode varchar(5),
	@Type nvarchar(50),
	@Note nvarchar(MAX)
	)
AS
BEGIN
	set nocount on;

	UPDATE Store
	SET
		code = @Code,
		name = @Name,
		adress = @Adress,
		information = @Information,
		ward_code = @WardCode,
		latitude = @Latitude,
		longitude = @Longitude,
		category_code = @CategoryCode,
		type = @Type,
		note = @Note
	WHERE ID = @ID
		
	set nocount off;
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateTimeScan]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateTimeScan] (
	@TimeScan int
	)
AS
BEGIN
	set nocount on;
	Update Table_Config set value_int = @TimeScan where name = 'time_scan';
	set nocount off;
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateUserData]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateUserData] (
	@UserName nvarchar(50),
	@FullName nvarchar(250),
	@Password  nvarchar(15),
	@Email nvarchar(15)
	)
AS
BEGIN
	set nocount on;
	Update Table_User
	SET
		FullName = @FullName,
		Password = @Password,
		Email = @Email
	Where UserName = UserName
	
	set nocount off;
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateWardData]    Script Date: 7/7/2019 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateWardData] (
	@ID int,
	@WardCode varchar(5),
	@WardName nvarchar(50),
	@Type nvarchar(50),
	@DistrictCode varchar(5),
	@DistrictName nvarchar(50),
	@CityCode varchar(5),
	@CityName nvarchar(50),
	@Population nchar(20),
	@Area nchar(20)
	)
AS
BEGIN
	set nocount on;

	UPDATE Wards
	SET
		ward_code = @WardCode,
		ward_name = @WardName,
		type = @Type,
		district_code = @DistrictCode,
		district_name = @DistrictName,
		city_code = @CityCode,
		city_name = @CityName,
		population = @Population,
		area = @Area,
		update_at = getdate()
	WHERE ID = @ID
		
	set nocount off;
END
GO
USE [master]
GO
ALTER DATABASE [bobbylct_mec] SET  READ_WRITE 
GO
