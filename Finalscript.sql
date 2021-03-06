USE [master]
GO
/****** Object:  Database [Practice-2]    Script Date: 8/27/2018 11:45:52 PM ******/
CREATE DATABASE [Practice-2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Practice-2', FILENAME = N'H:\sql\Sql Database\Practice-2.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Practice-2_log', FILENAME = N'H:\sql\Sql Database\Practice-2_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Practice-2] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Practice-2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Practice-2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Practice-2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Practice-2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Practice-2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Practice-2] SET ARITHABORT OFF 
GO
ALTER DATABASE [Practice-2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Practice-2] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Practice-2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Practice-2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Practice-2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Practice-2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Practice-2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Practice-2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Practice-2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Practice-2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Practice-2] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Practice-2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Practice-2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Practice-2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Practice-2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Practice-2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Practice-2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Practice-2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Practice-2] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Practice-2] SET  MULTI_USER 
GO
ALTER DATABASE [Practice-2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Practice-2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Practice-2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Practice-2] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Practice-2]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 8/27/2018 11:45:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Companies]    Script Date: 8/27/2018 11:45:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Companies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [varchar](50) NULL,
 CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ItemSetup]    Script Date: 8/27/2018 11:45:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ItemSetup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NULL,
	[CompanyId] [int] NULL,
	[ItemName] [varchar](50) NULL,
	[ReorderLevel] [int] NULL,
	[AvailableQuantity] [int] NULL,
 CONSTRAINT [PK_ItemSetup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StockOut]    Script Date: 8/27/2018 11:45:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StockOut](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NULL,
	[ItemId] [int] NULL,
	[Quantity] [varchar](50) NULL,
	[ItemType] [varchar](50) NULL,
	[Date] [date] NULL,
 CONSTRAINT [PK_StockOut] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserLogin]    Script Date: 8/27/2018 11:45:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserLogin](
	[UserName] [varchar](50) NULL,
	[Password] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[ShowAllItemsView]    Script Date: 8/27/2018 11:45:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE View [dbo].[ShowAllItemsView]
AS
Select ItemSetup.Id As ItemId,ItemName,ReorderLevel,AvailableQuantity,
Categories.Id AS CategoryId,CategoryName,Companies.Id AS CompanyId,CompanyName FROM ItemSetup
Inner Join Categories ON ItemSetup.CategoryId = Categories.Id
Inner Join Companies ON ItemSetup.CompanyId = Companies.Id

GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [CategoryName]) VALUES (1, N'Stationary')
INSERT [dbo].[Categories] ([Id], [CategoryName]) VALUES (2, N'Cosmetics')
INSERT [dbo].[Categories] ([Id], [CategoryName]) VALUES (3, N'Electronics')
INSERT [dbo].[Categories] ([Id], [CategoryName]) VALUES (4, N'Kitchen Items')
INSERT [dbo].[Categories] ([Id], [CategoryName]) VALUES (5, N'Education Items')
INSERT [dbo].[Categories] ([Id], [CategoryName]) VALUES (1005, N'Food Items')
INSERT [dbo].[Categories] ([Id], [CategoryName]) VALUES (1006, N'Dress')
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[Companies] ON 

INSERT [dbo].[Companies] ([Id], [CompanyName]) VALUES (6, N'Dell')
INSERT [dbo].[Companies] ([Id], [CompanyName]) VALUES (4, N'Nova')
INSERT [dbo].[Companies] ([Id], [CompanyName]) VALUES (2, N'RFL')
INSERT [dbo].[Companies] ([Id], [CompanyName]) VALUES (5, N'Square')
INSERT [dbo].[Companies] ([Id], [CompanyName]) VALUES (1, N'Uniliver')
INSERT [dbo].[Companies] ([Id], [CompanyName]) VALUES (3, N'Walton')
SET IDENTITY_INSERT [dbo].[Companies] OFF
SET IDENTITY_INSERT [dbo].[ItemSetup] ON 

INSERT [dbo].[ItemSetup] ([Id], [CategoryId], [CompanyId], [ItemName], [ReorderLevel], [AvailableQuantity]) VALUES (3, 1, 2, N'Chair', 0, 735)
INSERT [dbo].[ItemSetup] ([Id], [CategoryId], [CompanyId], [ItemName], [ReorderLevel], [AvailableQuantity]) VALUES (4, 1, 2, N'Table', 0, 1985)
INSERT [dbo].[ItemSetup] ([Id], [CategoryId], [CompanyId], [ItemName], [ReorderLevel], [AvailableQuantity]) VALUES (5, 1, 2, N'Knife', 0, 495)
INSERT [dbo].[ItemSetup] ([Id], [CategoryId], [CompanyId], [ItemName], [ReorderLevel], [AvailableQuantity]) VALUES (6, 3, 3, N'Mobile', 0, 500)
INSERT [dbo].[ItemSetup] ([Id], [CategoryId], [CompanyId], [ItemName], [ReorderLevel], [AvailableQuantity]) VALUES (7, 3, 3, N'TV', 0, 1950)
INSERT [dbo].[ItemSetup] ([Id], [CategoryId], [CompanyId], [ItemName], [ReorderLevel], [AvailableQuantity]) VALUES (8, 3, 3, N'Freez', 0, 1010)
INSERT [dbo].[ItemSetup] ([Id], [CategoryId], [CompanyId], [ItemName], [ReorderLevel], [AvailableQuantity]) VALUES (9, 2, 4, N'BodyLotion', 0, 460)
INSERT [dbo].[ItemSetup] ([Id], [CategoryId], [CompanyId], [ItemName], [ReorderLevel], [AvailableQuantity]) VALUES (10, 5, 5, N'Writing Paper', 0, 0)
INSERT [dbo].[ItemSetup] ([Id], [CategoryId], [CompanyId], [ItemName], [ReorderLevel], [AvailableQuantity]) VALUES (11, 3, 6, N'Laptop', 0, 40)
SET IDENTITY_INSERT [dbo].[ItemSetup] OFF
SET IDENTITY_INSERT [dbo].[StockOut] ON 

INSERT [dbo].[StockOut] ([Id], [CompanyId], [ItemId], [Quantity], [ItemType], [Date]) VALUES (3, 2, 3, N'100', N'Sell', CAST(0x9A3E0B00 AS Date))
INSERT [dbo].[StockOut] ([Id], [CompanyId], [ItemId], [Quantity], [ItemType], [Date]) VALUES (4, 2, 3, N'100', N'Damage', CAST(0x9A3E0B00 AS Date))
INSERT [dbo].[StockOut] ([Id], [CompanyId], [ItemId], [Quantity], [ItemType], [Date]) VALUES (5, 4, 9, N'35', N'Sell', CAST(0x9F3E0B00 AS Date))
INSERT [dbo].[StockOut] ([Id], [CompanyId], [ItemId], [Quantity], [ItemType], [Date]) VALUES (6, 2, 3, N'30', N'Sell', CAST(0x9F3E0B00 AS Date))
INSERT [dbo].[StockOut] ([Id], [CompanyId], [ItemId], [Quantity], [ItemType], [Date]) VALUES (7, 3, 7, N'50', N'Sell', CAST(0x9F3E0B00 AS Date))
INSERT [dbo].[StockOut] ([Id], [CompanyId], [ItemId], [Quantity], [ItemType], [Date]) VALUES (8, 4, 9, N'3', N'Lost', CAST(0x9F3E0B00 AS Date))
INSERT [dbo].[StockOut] ([Id], [CompanyId], [ItemId], [Quantity], [ItemType], [Date]) VALUES (9, 4, 9, N'3', N'Damage', CAST(0x9F3E0B00 AS Date))
INSERT [dbo].[StockOut] ([Id], [CompanyId], [ItemId], [Quantity], [ItemType], [Date]) VALUES (10, 2, 5, N'5', N'Damage', CAST(0x9F3E0B00 AS Date))
INSERT [dbo].[StockOut] ([Id], [CompanyId], [ItemId], [Quantity], [ItemType], [Date]) VALUES (1005, 5, 10, N'3', N'Sell', CAST(0xA03E0B00 AS Date))
INSERT [dbo].[StockOut] ([Id], [CompanyId], [ItemId], [Quantity], [ItemType], [Date]) VALUES (1006, 5, 10, N'2', N'Lost', CAST(0xA03E0B00 AS Date))
INSERT [dbo].[StockOut] ([Id], [CompanyId], [ItemId], [Quantity], [ItemType], [Date]) VALUES (1007, 5, 10, N'3', N'Sell', CAST(0xA03E0B00 AS Date))
INSERT [dbo].[StockOut] ([Id], [CompanyId], [ItemId], [Quantity], [ItemType], [Date]) VALUES (1008, 2, 3, N'10', N'Sell', CAST(0xA03E0B00 AS Date))
INSERT [dbo].[StockOut] ([Id], [CompanyId], [ItemId], [Quantity], [ItemType], [Date]) VALUES (1009, 2, 4, N'15', N'Sell', CAST(0xA03E0B00 AS Date))
INSERT [dbo].[StockOut] ([Id], [CompanyId], [ItemId], [Quantity], [ItemType], [Date]) VALUES (1010, 6, 11, N'10', N'Sell', CAST(0xA23E0B00 AS Date))
INSERT [dbo].[StockOut] ([Id], [CompanyId], [ItemId], [Quantity], [ItemType], [Date]) VALUES (1011, 5, 10, N'17', N'Sell', CAST(0xA23E0B00 AS Date))
INSERT [dbo].[StockOut] ([Id], [CompanyId], [ItemId], [Quantity], [ItemType], [Date]) VALUES (1012, 2, 3, N'25', N'Sell', CAST(0xA23E0B00 AS Date))
SET IDENTITY_INSERT [dbo].[StockOut] OFF
INSERT [dbo].[UserLogin] ([UserName], [Password]) VALUES (N'admin', N'12345')
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Companies]    Script Date: 8/27/2018 11:45:52 PM ******/
ALTER TABLE [dbo].[Companies] ADD  CONSTRAINT [IX_Companies] UNIQUE NONCLUSTERED 
(
	[CompanyName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_StockOut]    Script Date: 8/27/2018 11:45:52 PM ******/
CREATE NONCLUSTERED INDEX [IX_StockOut] ON [dbo].[StockOut]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[StockOut] ADD  CONSTRAINT [DF_StockOut_Date]  DEFAULT (getdate()) FOR [Date]
GO
ALTER TABLE [dbo].[ItemSetup]  WITH CHECK ADD  CONSTRAINT [FK_ItemSetup_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[ItemSetup] CHECK CONSTRAINT [FK_ItemSetup_Categories]
GO
ALTER TABLE [dbo].[ItemSetup]  WITH CHECK ADD  CONSTRAINT [FK_ItemSetup_Companies] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([Id])
GO
ALTER TABLE [dbo].[ItemSetup] CHECK CONSTRAINT [FK_ItemSetup_Companies]
GO
ALTER TABLE [dbo].[StockOut]  WITH CHECK ADD  CONSTRAINT [FK_StockOut_ItemSetup] FOREIGN KEY([ItemId])
REFERENCES [dbo].[ItemSetup] ([Id])
GO
ALTER TABLE [dbo].[StockOut] CHECK CONSTRAINT [FK_StockOut_ItemSetup]
GO
USE [master]
GO
ALTER DATABASE [Practice-2] SET  READ_WRITE 
GO
