USE [master]
GO
/****** Object:  Database [BD_PRUEBA]    Script Date: 24/06/2022 01:36:23 ******/
CREATE DATABASE [BD_PRUEBA]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BD_PRUEBA', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\BD_PRUEBA.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BD_PRUEBA_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\BD_PRUEBA_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BD_PRUEBA] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BD_PRUEBA].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BD_PRUEBA] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BD_PRUEBA] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BD_PRUEBA] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BD_PRUEBA] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BD_PRUEBA] SET ARITHABORT OFF 
GO
ALTER DATABASE [BD_PRUEBA] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BD_PRUEBA] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BD_PRUEBA] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BD_PRUEBA] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BD_PRUEBA] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BD_PRUEBA] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BD_PRUEBA] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BD_PRUEBA] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BD_PRUEBA] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BD_PRUEBA] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BD_PRUEBA] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BD_PRUEBA] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BD_PRUEBA] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BD_PRUEBA] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BD_PRUEBA] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BD_PRUEBA] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [BD_PRUEBA] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BD_PRUEBA] SET RECOVERY FULL 
GO
ALTER DATABASE [BD_PRUEBA] SET  MULTI_USER 
GO
ALTER DATABASE [BD_PRUEBA] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BD_PRUEBA] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BD_PRUEBA] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BD_PRUEBA] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BD_PRUEBA] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BD_PRUEBA', N'ON'
GO
ALTER DATABASE [BD_PRUEBA] SET QUERY_STORE = OFF
GO
USE [BD_PRUEBA]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [BD_PRUEBA]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 24/06/2022 01:36:25 ******/
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
/****** Object:  Table [dbo].[Clientes]    Script Date: 24/06/2022 01:36:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Contraseña] [nvarchar](50) NOT NULL,
	[Estado] [bit] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Genero] [nvarchar](50) NOT NULL,
	[Edad] [int] NOT NULL,
	[Identificacion] [nvarchar](50) NOT NULL,
	[Direccion] [nvarchar](max) NULL,
	[Telefono] [nvarchar](max) NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cuentas]    Script Date: 24/06/2022 01:36:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuentas](
	[CuentaId] [int] IDENTITY(1,1) NOT NULL,
	[ClienteId] [int] NOT NULL,
	[NumeroCuenta] [nvarchar](50) NOT NULL,
	[TipoCuenta] [nvarchar](50) NOT NULL,
	[SaldoIncial] [decimal](18, 2) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Cuentas] PRIMARY KEY CLUSTERED 
(
	[CuentaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movimientos]    Script Date: 24/06/2022 01:36:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movimientos](
	[MovimientoId] [int] IDENTITY(1,1) NOT NULL,
	[CuentaId] [int] NOT NULL,
	[Fecha] [datetime2](7) NOT NULL,
	[TipoMovimiento] [bit] NOT NULL,
	[Valor] [decimal](18, 2) NOT NULL,
	[Saldo] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Movimientos] PRIMARY KEY CLUSTERED 
(
	[MovimientoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220623220058_MigracionInicial', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220623222134_MigracionInicial1', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220623222733_MigracionInicial2', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220623222857_MigracionInicial3', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220623223120_MigracionInicial4', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220623223207_MigracionInicial5', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220624002754_AddMovimiento', N'5.0.17')
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([Id], [Contraseña], [Estado], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (1, N'123', 1, N'Willy', N'Masculino', 28, N'71595945', N'Casa', N'990568875')
INSERT [dbo].[Clientes] ([Id], [Contraseña], [Estado], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (2, N'123', 1, N'Xiomara', N'Femenino', 29, N'72329856', N'Casa', N'992934451')
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[Cuentas] ON 

INSERT [dbo].[Cuentas] ([CuentaId], [ClienteId], [NumeroCuenta], [TipoCuenta], [SaldoIncial], [Estado]) VALUES (1, 1, N'665544112233', N'Ahorros', CAST(1000.00 AS Decimal(18, 2)), 1)
SET IDENTITY_INSERT [dbo].[Cuentas] OFF
GO
SET IDENTITY_INSERT [dbo].[Movimientos] ON 

INSERT [dbo].[Movimientos] ([MovimientoId], [CuentaId], [Fecha], [TipoMovimiento], [Valor], [Saldo]) VALUES (1, 1, CAST(N'2022-06-24T05:03:47.4920000' AS DateTime2), 1, CAST(300.00 AS Decimal(18, 2)), CAST(1300.00 AS Decimal(18, 2)))
INSERT [dbo].[Movimientos] ([MovimientoId], [CuentaId], [Fecha], [TipoMovimiento], [Valor], [Saldo]) VALUES (3, 1, CAST(N'2022-06-24T05:51:46.1010000' AS DateTime2), 1, CAST(1000.00 AS Decimal(18, 2)), CAST(2300.00 AS Decimal(18, 2)))
INSERT [dbo].[Movimientos] ([MovimientoId], [CuentaId], [Fecha], [TipoMovimiento], [Valor], [Saldo]) VALUES (4, 1, CAST(N'2022-06-24T05:53:35.2540000' AS DateTime2), 0, CAST(-800.00 AS Decimal(18, 2)), CAST(1500.00 AS Decimal(18, 2)))
INSERT [dbo].[Movimientos] ([MovimientoId], [CuentaId], [Fecha], [TipoMovimiento], [Valor], [Saldo]) VALUES (5, 1, CAST(N'2022-06-24T05:53:35.2540000' AS DateTime2), 0, CAST(-300.00 AS Decimal(18, 2)), CAST(1200.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Movimientos] OFF
GO
/****** Object:  Index [IX_Cuentas_ClienteId]    Script Date: 24/06/2022 01:36:28 ******/
CREATE NONCLUSTERED INDEX [IX_Cuentas_ClienteId] ON [dbo].[Cuentas]
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Movimientos_CuentaId]    Script Date: 24/06/2022 01:36:28 ******/
CREATE NONCLUSTERED INDEX [IX_Movimientos_CuentaId] ON [dbo].[Movimientos]
(
	[CuentaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cuentas]  WITH CHECK ADD  CONSTRAINT [FK_Cuentas_Clientes_ClienteId] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Clientes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cuentas] CHECK CONSTRAINT [FK_Cuentas_Clientes_ClienteId]
GO
ALTER TABLE [dbo].[Movimientos]  WITH CHECK ADD  CONSTRAINT [FK_Movimientos_Cuentas_CuentaId] FOREIGN KEY([CuentaId])
REFERENCES [dbo].[Cuentas] ([CuentaId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Movimientos] CHECK CONSTRAINT [FK_Movimientos_Cuentas_CuentaId]
GO
USE [master]
GO
ALTER DATABASE [BD_PRUEBA] SET  READ_WRITE 
GO
