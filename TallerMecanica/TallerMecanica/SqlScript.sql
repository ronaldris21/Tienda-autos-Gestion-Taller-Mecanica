﻿USE [master]
GO
/****** Object:  Database [TallerMecanica]    Script Date: 02/05/2022 14:13:47 ******/
CREATE DATABASE [TallerMecanica]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TallerMecanica', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TallerMecanica.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TallerMecanica_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TallerMecanica_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TallerMecanica] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TallerMecanica].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TallerMecanica] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TallerMecanica] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TallerMecanica] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TallerMecanica] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TallerMecanica] SET ARITHABORT OFF 
GO
ALTER DATABASE [TallerMecanica] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TallerMecanica] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TallerMecanica] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TallerMecanica] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TallerMecanica] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TallerMecanica] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TallerMecanica] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TallerMecanica] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TallerMecanica] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TallerMecanica] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TallerMecanica] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TallerMecanica] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TallerMecanica] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TallerMecanica] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TallerMecanica] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TallerMecanica] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TallerMecanica] SET HONOR_BROKER_PRIORITY OFF 
GO
GO
ALTER DATABASE [TallerMecanica] SET  MULTI_USER 
GO
ALTER DATABASE [TallerMecanica] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TallerMecanica] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TallerMecanica] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TallerMecanica] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TallerMecanica] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TallerMecanica] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TallerMecanica] SET QUERY_STORE = OFF
GO
USE [TallerMecanica]
GO
/****** Object:  Table [dbo].[AdminUser]    Script Date: 02/05/2022 14:13:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminUser](
	[idAdmin] [int] IDENTITY(1,1) NOT NULL,
	[email] [nchar](50) NOT NULL,
	[contrasena] [nchar](20) NOT NULL,
 CONSTRAINT [PK_AdminUser] PRIMARY KEY CLUSTERED 
(
	[idAdmin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 02/05/2022 14:13:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[idCategoria] [int] IDENTITY(1,1) NOT NULL,
	[nombreCategoria] [nchar](30) NOT NULL,
	[cantidadCocheCompleto] [int] NOT NULL,
 CONSTRAINT [PK_Categorias] PRIMARY KEY CLUSTERED 
(
	[idCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 02/05/2022 14:13:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[idCliente] [int] IDENTITY(1,1) NOT NULL,
	[nombreCompleto] [nchar](70) NOT NULL,
	[email] [nchar](50) NOT NULL,
	[telefono1] [nchar](17) NOT NULL,
	[telefono2] [nchar](17) NOT NULL,
	[contrasena] [nchar](20) NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[idCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MateriaPrima]    Script Date: 02/05/2022 14:13:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MateriaPrima](
	[idMateriaPrima] [int] NOT NULL,
	[nombre] [nchar](10) NOT NULL,
	[precioCompra] [float] NOT NULL,
	[precioVenta] [float] NOT NULL,
	[cantidadStock] [int] NOT NULL,
	[idCategoria] [int] NOT NULL,
 CONSTRAINT [PK_MateriaPrima] PRIMARY KEY CLUSTERED 
(
	[idMateriaPrima] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MateriaPrima_Producto]    Script Date: 02/05/2022 14:13:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MateriaPrima_Producto](
	[idMateriaPrima_Producto] [int] IDENTITY(1,1) NOT NULL,
	[cantidad] [int] NOT NULL,
	[idMateriaPrima] [int] NOT NULL,
	[idProductoFinal] [int] NOT NULL,
 CONSTRAINT [PK_MateriaPrima_Producto] PRIMARY KEY CLUSTERED 
(
	[idMateriaPrima_Producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MateriaPrima_ProductoEnsamblado]    Script Date: 02/05/2022 14:13:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MateriaPrima_ProductoEnsamblado](
	[idMateriaPrima_ProductoEnsamblado] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[idMAteriaPrima] [int] NOT NULL,
	[idProductoEnsamblado] [int] NOT NULL,
 CONSTRAINT [PK_MateriaPrima_ProductoEnsamblado] PRIMARY KEY CLUSTERED 
(
	[idMateriaPrima_ProductoEnsamblado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductoEnsamblado]    Script Date: 02/05/2022 14:13:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductoEnsamblado](
	[idProductoEnsamblado] [int] IDENTITY(1,1) NOT NULL,
	[fechaCompra] [date] NOT NULL,
	[fechaEntregaPrevista] [date] NOT NULL,
	[costoEnsamblado] [float] NOT NULL,
 CONSTRAINT [PK_ProductoEnsamblado] PRIMARY KEY CLUSTERED 
(
	[idProductoEnsamblado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductoFinal]    Script Date: 02/05/2022 14:13:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductoFinal](
	[idProductoFinal] [int] IDENTITY(1,1) NOT NULL,
	[idCliente] [int] NOT NULL,
	[fechaCompra] [date] NOT NULL,
	[fechEntregaPrevista] [date] NOT NULL,
	[costoEnsamblado] [float] NOT NULL,
	[requiereEnsamblado] [bit] NOT NULL,
 CONSTRAINT [PK_ProductoFinal] PRIMARY KEY CLUSTERED 
(
	[idProductoFinal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [TallerMecanica] SET  READ_WRITE 
GO

