USE [master]
GO
/****** Object:  Database [myPoS]    Script Date: 30-Jun-19 8:07:59 AM ******/
CREATE DATABASE [myPoS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'myPoS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\myPoS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'myPoS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\myPoS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [myPoS] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [myPoS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [myPoS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [myPoS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [myPoS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [myPoS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [myPoS] SET ARITHABORT OFF 
GO
ALTER DATABASE [myPoS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [myPoS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [myPoS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [myPoS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [myPoS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [myPoS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [myPoS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [myPoS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [myPoS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [myPoS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [myPoS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [myPoS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [myPoS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [myPoS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [myPoS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [myPoS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [myPoS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [myPoS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [myPoS] SET  MULTI_USER 
GO
ALTER DATABASE [myPoS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [myPoS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [myPoS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [myPoS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [myPoS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [myPoS] SET QUERY_STORE = OFF
GO
USE [myPoS]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 30-Jun-19 8:07:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 30-Jun-19 8:07:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[custId] [nvarchar](50) NOT NULL,
	[person_id] [nvarchar](50) NULL,
	[createdAt] [datetime] NULL,
	[updatedAt] [datetime] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[custId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Item]    Script Date: 30-Jun-19 8:07:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item](
	[item_id] [nvarchar](50) NOT NULL,
	[product_id] [nvarchar](50) NOT NULL,
	[costPrice] [decimal](18, 0) NULL,
	[salsePrice] [decimal](18, 0) NULL,
	[reorderlavel] [int] NULL,
	[Description] [text] NULL,
 CONSTRAINT [PK_Item_1] PRIMARY KEY CLUSTERED 
(
	[item_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 30-Jun-19 8:07:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[orderId] [nvarchar](50) NOT NULL,
	[customerId] [nvarchar](50) NULL,
	[employeeId] [nvarchar](50) NULL,
	[shippedTo] [text] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[orderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_Sub]    Script Date: 30-Jun-19 8:07:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Sub](
	[orderSubId] [uniqueidentifier] NOT NULL,
	[order_id] [nvarchar](50) NULL,
	[item_id] [nvarchar](50) NULL,
	[unit_price] [decimal](18, 0) NULL,
	[quantity] [decimal](18, 0) NULL,
	[discount] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Order_Sub] PRIMARY KEY CLUSTERED 
(
	[orderSubId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permision]    Script Date: 30-Jun-19 8:07:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permision](
	[id] [int] NOT NULL,
	[permisionName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Permision] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 30-Jun-19 8:08:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[Id] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[mobile] [nvarchar](50) NULL,
	[Address] [text] NULL,
	[Email] [nvarchar](100) NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[posRole]    Script Date: 30-Jun-19 8:08:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[posRole](
	[roleId] [nvarchar](50) NOT NULL,
	[roleName] [nvarchar](50) NULL,
 CONSTRAINT [PK_posRole] PRIMARY KEY CLUSTERED 
(
	[roleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[posUser]    Script Date: 30-Jun-19 8:08:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[posUser](
	[UserId] [nvarchar](50) NOT NULL,
	[person_id] [nvarchar](50) NULL,
	[userName] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
 CONSTRAINT [PK_posUser] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 30-Jun-19 8:08:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[prodId] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](150) NULL,
	[Description] [text] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[prodId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleUserMap]    Script Date: 30-Jun-19 8:08:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleUserMap](
	[id] [int] NOT NULL,
	[user_id] [nvarchar](50) NULL,
	[role_id] [nvarchar](50) NULL,
	[createdAt] [datetime] NULL,
	[updatedAt] [datetime] NULL,
 CONSTRAINT [PK_RoleUserMap] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserPermision]    Script Date: 30-Jun-19 8:08:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPermision](
	[id] [int] NOT NULL,
	[user_id] [nvarchar](50) NULL,
	[permision_id] [int] NULL,
 CONSTRAINT [PK_UserPermision] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Person] FOREIGN KEY([person_id])
REFERENCES [dbo].[Person] ([Id])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Person]
GO
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_Item_Product] FOREIGN KEY([product_id])
REFERENCES [dbo].[Product] ([prodId])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_Item_Product]
GO
ALTER TABLE [dbo].[Order_Sub]  WITH CHECK ADD  CONSTRAINT [FK_Order_Sub_Item] FOREIGN KEY([item_id])
REFERENCES [dbo].[Item] ([item_id])
GO
ALTER TABLE [dbo].[Order_Sub] CHECK CONSTRAINT [FK_Order_Sub_Item]
GO
ALTER TABLE [dbo].[Order_Sub]  WITH CHECK ADD  CONSTRAINT [FK_Order_Sub_Order_Sub] FOREIGN KEY([order_id])
REFERENCES [dbo].[Order] ([orderId])
GO
ALTER TABLE [dbo].[Order_Sub] CHECK CONSTRAINT [FK_Order_Sub_Order_Sub]
GO
ALTER TABLE [dbo].[posUser]  WITH CHECK ADD  CONSTRAINT [FK_posUser_posUser] FOREIGN KEY([person_id])
REFERENCES [dbo].[Person] ([Id])
GO
ALTER TABLE [dbo].[posUser] CHECK CONSTRAINT [FK_posUser_posUser]
GO
ALTER TABLE [dbo].[RoleUserMap]  WITH CHECK ADD  CONSTRAINT [FK_RoleUserMap_posRole] FOREIGN KEY([role_id])
REFERENCES [dbo].[posRole] ([roleId])
GO
ALTER TABLE [dbo].[RoleUserMap] CHECK CONSTRAINT [FK_RoleUserMap_posRole]
GO
ALTER TABLE [dbo].[RoleUserMap]  WITH CHECK ADD  CONSTRAINT [FK_RoleUserMap_posUser] FOREIGN KEY([user_id])
REFERENCES [dbo].[posUser] ([UserId])
GO
ALTER TABLE [dbo].[RoleUserMap] CHECK CONSTRAINT [FK_RoleUserMap_posUser]
GO
ALTER TABLE [dbo].[UserPermision]  WITH CHECK ADD  CONSTRAINT [FK_UserPermision_Permision] FOREIGN KEY([permision_id])
REFERENCES [dbo].[Permision] ([id])
GO
ALTER TABLE [dbo].[UserPermision] CHECK CONSTRAINT [FK_UserPermision_Permision]
GO
ALTER TABLE [dbo].[UserPermision]  WITH CHECK ADD  CONSTRAINT [FK_UserPermision_posUser] FOREIGN KEY([user_id])
REFERENCES [dbo].[posUser] ([UserId])
GO
ALTER TABLE [dbo].[UserPermision] CHECK CONSTRAINT [FK_UserPermision_posUser]
GO
USE [master]
GO
ALTER DATABASE [myPoS] SET  READ_WRITE 
GO
