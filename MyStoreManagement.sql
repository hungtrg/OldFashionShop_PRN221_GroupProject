USE [master]
GO
/****** Object:  Database [MyStoreManagement]    Script Date: 11/8/2022 8:12:21 PM ******/
CREATE DATABASE [MyStoreManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MyStoreManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MyStoreManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MyStoreManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MyStoreManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MyStoreManagement] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MyStoreManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MyStoreManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MyStoreManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MyStoreManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MyStoreManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MyStoreManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [MyStoreManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MyStoreManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MyStoreManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MyStoreManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MyStoreManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MyStoreManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MyStoreManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MyStoreManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MyStoreManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MyStoreManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MyStoreManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MyStoreManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MyStoreManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MyStoreManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MyStoreManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MyStoreManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MyStoreManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MyStoreManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [MyStoreManagement] SET  MULTI_USER 
GO
ALTER DATABASE [MyStoreManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MyStoreManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MyStoreManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MyStoreManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MyStoreManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MyStoreManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'MyStoreManagement', N'ON'
GO
ALTER DATABASE [MyStoreManagement] SET QUERY_STORE = OFF
GO
USE [MyStoreManagement]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 11/8/2022 8:12:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[AccountID] [int] IDENTITY(1,1) NOT NULL,
	[Phone] [varchar](12) NULL,
	[Email] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Active] [bit] NOT NULL,
	[FullName] [nvarchar](150) NULL,
	[RoleID] [int] NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Attributes]    Script Date: 11/8/2022 8:12:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attributes](
	[AttributeID] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Attributes] PRIMARY KEY CLUSTERED 
(
	[AttributeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AttributesPrices]    Script Date: 11/8/2022 8:12:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttributesPrices](
	[AttributesPriceID] [int] NOT NULL,
	[AttributeID] [int] NULL,
	[ProductID] [int] NULL,
	[Price] [int] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_AttributesPrices] PRIMARY KEY CLUSTERED 
(
	[AttributesPriceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 11/8/2022 8:12:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CatID] [int] IDENTITY(1,1) NOT NULL,
	[CatName] [nvarchar](250) NULL,
	[Description] [nvarchar](max) NULL,
	[Levels] [int] NULL,
	[Ordering] [int] NULL,
	[Published] [bit] NOT NULL,
	[Title] [nvarchar](250) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CatID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 11/8/2022 8:12:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](255) NULL,
	[Birthday] [datetime] NULL,
	[Avatar] [nvarchar](255) NULL,
	[Address] [nvarchar](255) NULL,
	[Email] [nchar](150) NULL,
	[Phone] [varchar](12) NULL,
	[Password] [nvarchar](50) NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 11/8/2022 8:12:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderDetailID] [int] NOT NULL,
	[OrderID] [int] NULL,
	[ProductID] [int] NULL,
	[OrderNumber] [int] NULL,
	[Quantity] [int] NULL,
	[Discount] [int] NULL,
	[Total] [int] NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[OrderDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 11/8/2022 8:12:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NULL,
	[OrderDate] [datetime] NULL,
	[TransacStatusID] [int] NULL,
	[Deleted] [bit] NULL,
	[Note] [nvarchar](max) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 11/8/2022 8:12:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CatID] [int] NULL,
	[Price] [int] NULL,
	[Discount] [int] NULL,
	[Thumb] [nvarchar](255) NULL,
	[Active] [bit] NOT NULL,
	[Title] [nvarchar](255) NULL,
	[UnitsInStock] [int] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 11/8/2022 8:12:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [int] NOT NULL,
	[RoleName] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransactStatus]    Script Date: 11/8/2022 8:12:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactStatus](
	[TransactStatusID] [int] NOT NULL,
	[Status] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_TransactStatus] PRIMARY KEY CLUSTERED 
(
	[TransactStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([AccountID], [Phone], [Email], [Password], [Active], [FullName], [RoleID]) VALUES (3, N'12345678', N'darson@gmail.com', N'12345', 1, N'Darson Luff', 1)
INSERT [dbo].[Account] ([AccountID], [Phone], [Email], [Password], [Active], [FullName], [RoleID]) VALUES (5, N'098765421', N'alice@gmail.com', N'12345', 1, N'Alice Hausman', 2)
INSERT [dbo].[Account] ([AccountID], [Phone], [Email], [Password], [Active], [FullName], [RoleID]) VALUES (6, N'098712345', N'blake@gmail.com', N'12345', 1, N'Blake Davidson', 2)
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
INSERT [dbo].[Attributes] ([AttributeID], [Name]) VALUES (1, N'BlackFriday')
INSERT [dbo].[Attributes] ([AttributeID], [Name]) VALUES (2, N'NewYear')
INSERT [dbo].[Attributes] ([AttributeID], [Name]) VALUES (3, N'Christmas')
GO
INSERT [dbo].[AttributesPrices] ([AttributesPriceID], [AttributeID], [ProductID], [Price], [Active]) VALUES (1, 1, 2, 20, 0)
INSERT [dbo].[AttributesPrices] ([AttributesPriceID], [AttributeID], [ProductID], [Price], [Active]) VALUES (2, 2, 3, 20, 0)
INSERT [dbo].[AttributesPrices] ([AttributesPriceID], [AttributeID], [ProductID], [Price], [Active]) VALUES (3, 1, 4, 30, 0)
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CatID], [CatName], [Description], [Levels], [Ordering], [Published], [Title]) VALUES (2, N'Shirt', N'T-Shirt', 1, 3, 1, N'Tee shirt')
INSERT [dbo].[Categories] ([CatID], [CatName], [Description], [Levels], [Ordering], [Published], [Title]) VALUES (3, N'Pant', N'Pant', 1, 3, 1, N'Trouser')
INSERT [dbo].[Categories] ([CatID], [CatName], [Description], [Levels], [Ordering], [Published], [Title]) VALUES (4, N'Suit', N'A set of suit', 4, 3, 0, N'Nice Suit')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([CustomerID], [FullName], [Birthday], [Avatar], [Address], [Email], [Phone], [Password], [Active]) VALUES (2, N'Carson Richard', CAST(N'2002-12-04T00:00:00.000' AS DateTime), NULL, N'OH, US', N'carson@gmail.com                                                                                                                                      ', N'123245678', N'12345', 1)
INSERT [dbo].[Customers] ([CustomerID], [FullName], [Birthday], [Avatar], [Address], [Email], [Phone], [Password], [Active]) VALUES (5, N'Lilly Swift', CAST(N'1996-01-09T00:00:00.000' AS DateTime), NULL, N'ON, CA', N'lily@gmail.com                                                                                                                                        ', N'098765432', N'12345', 1)
INSERT [dbo].[Customers] ([CustomerID], [FullName], [Birthday], [Avatar], [Address], [Email], [Phone], [Password], [Active]) VALUES (6, N'Oscar Nixson', CAST(N'2000-06-15T00:00:00.000' AS DateTime), NULL, N' Berlin, GE', N'oscar@gmail.com                                                                                                                                       ', N'091234577', N'12345', 1)
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
INSERT [dbo].[OrderDetails] ([OrderDetailID], [OrderID], [ProductID], [OrderNumber], [Quantity], [Discount], [Total]) VALUES (1, 2, 2, 1, 2, 0, 64)
INSERT [dbo].[OrderDetails] ([OrderDetailID], [OrderID], [ProductID], [OrderNumber], [Quantity], [Discount], [Total]) VALUES (2, 3, 2, 1, 1, 0, 32)
INSERT [dbo].[OrderDetails] ([OrderDetailID], [OrderID], [ProductID], [OrderNumber], [Quantity], [Discount], [Total]) VALUES (3, 4, 3, 1, 1, 0, 32)
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TransacStatusID], [Deleted], [Note]) VALUES (2, 2, CAST(N'2022-11-08T00:00:00.000' AS DateTime), 3, 0, N'No note')
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TransacStatusID], [Deleted], [Note]) VALUES (3, 2, CAST(N'2022-05-15T00:00:00.000' AS DateTime), 4, 0, N'No note')
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TransacStatusID], [Deleted], [Note]) VALUES (4, 5, CAST(N'2021-03-19T00:00:00.000' AS DateTime), 4, 0, N'No note')
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductID], [ProductName], [Description], [CatID], [Price], [Discount], [Thumb], [Active], [Title], [UnitsInStock]) VALUES (2, N'Black T-Shirt', N'Tshirt with black', 2, 32, 0, NULL, 1, N'Black Tee Shirt', 30)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Description], [CatID], [Price], [Discount], [Thumb], [Active], [Title], [UnitsInStock]) VALUES (3, N'White T-Shirt', N'Tshirt with white', 2, 32, 0, NULL, 1, N'White Tee Shirt', 30)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Description], [CatID], [Price], [Discount], [Thumb], [Active], [Title], [UnitsInStock]) VALUES (4, N'Blue Jeans Pant', N'Blue Jeans Pant', 3, 45, 0, NULL, 1, N'Blue Jeans Pant', 20)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
INSERT [dbo].[Roles] ([RoleID], [RoleName], [Description]) VALUES (1, N'AD', N'Admin')
INSERT [dbo].[Roles] ([RoleID], [RoleName], [Description]) VALUES (2, N'ST', N'Staff')
GO
INSERT [dbo].[TransactStatus] ([TransactStatusID], [Status], [Description]) VALUES (1, N'In Store', N'still in store')
INSERT [dbo].[TransactStatus] ([TransactStatusID], [Status], [Description]) VALUES (2, N'On the way', N'On thier way')
INSERT [dbo].[TransactStatus] ([TransactStatusID], [Status], [Description]) VALUES (3, N'Decline', N'Decline the delivery')
INSERT [dbo].[TransactStatus] ([TransactStatusID], [Status], [Description]) VALUES (4, N'Done', N'Finish delivery')
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Roles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Roles]
GO
ALTER TABLE [dbo].[AttributesPrices]  WITH CHECK ADD  CONSTRAINT [FK_AttributesPrices_Attributes] FOREIGN KEY([AttributeID])
REFERENCES [dbo].[Attributes] ([AttributeID])
GO
ALTER TABLE [dbo].[AttributesPrices] CHECK CONSTRAINT [FK_AttributesPrices_Attributes]
GO
ALTER TABLE [dbo].[AttributesPrices]  WITH CHECK ADD  CONSTRAINT [FK_AttributesPrices_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[AttributesPrices] CHECK CONSTRAINT [FK_AttributesPrices_Products]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders1] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Orders1]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Products]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers1] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customers] ([CustomerID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customers1]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_TransactStatus] FOREIGN KEY([TransacStatusID])
REFERENCES [dbo].[TransactStatus] ([TransactStatusID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_TransactStatus]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories1] FOREIGN KEY([CatID])
REFERENCES [dbo].[Categories] ([CatID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories1]
GO
USE [master]
GO
ALTER DATABASE [MyStoreManagement] SET  READ_WRITE 
GO
