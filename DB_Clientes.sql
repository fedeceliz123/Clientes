USE [master]
GO
/****** Object:  Database [Clientes-Challenge]    Script Date: 4/2/2023 17:45:12 ******/
CREATE DATABASE [Clientes-Challenge]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Clientes-Challenge', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Clientes-Challenge.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Clientes-Challenge_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Clientes-Challenge_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Clientes-Challenge] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Clientes-Challenge].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Clientes-Challenge] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Clientes-Challenge] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Clientes-Challenge] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Clientes-Challenge] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Clientes-Challenge] SET ARITHABORT OFF 
GO
ALTER DATABASE [Clientes-Challenge] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Clientes-Challenge] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Clientes-Challenge] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Clientes-Challenge] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Clientes-Challenge] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Clientes-Challenge] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Clientes-Challenge] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Clientes-Challenge] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Clientes-Challenge] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Clientes-Challenge] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Clientes-Challenge] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Clientes-Challenge] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Clientes-Challenge] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Clientes-Challenge] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Clientes-Challenge] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Clientes-Challenge] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Clientes-Challenge] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Clientes-Challenge] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Clientes-Challenge] SET  MULTI_USER 
GO
ALTER DATABASE [Clientes-Challenge] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Clientes-Challenge] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Clientes-Challenge] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Clientes-Challenge] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Clientes-Challenge] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Clientes-Challenge] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Clientes-Challenge] SET QUERY_STORE = OFF
GO
USE [Clientes-Challenge]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 4/2/2023 17:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[idCliente] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [nvarchar](100) NOT NULL,
	[Apellidos] [nvarchar](100) NOT NULL,
	[FechaNacimiento] [date] NULL,
	[CUIT] [nvarchar](11) NOT NULL,
	[Domicilio] [nvarchar](200) NULL,
	[telefonoCelular] [nvarchar](20) NOT NULL,
	[email] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[idCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([idCliente], [Nombres], [Apellidos], [FechaNacimiento], [CUIT], [Domicilio], [telefonoCelular], [email]) VALUES (1, N'Juan Cruz', N'Alvarez', CAST(N'1990-01-15' AS Date), N'20341234512', N'Colon 5001', N'3513985911', N'jalvarez@gmail.com')
INSERT [dbo].[Clientes] ([idCliente], [Nombres], [Apellidos], [FechaNacimiento], [CUIT], [Domicilio], [telefonoCelular], [email]) VALUES (2, N'Carlos', N'Martinez', CAST(N'1995-06-12' AS Date), N'20384568712', N'Almagro 2012', N'3513568745', N'cmartinez@email.com')
INSERT [dbo].[Clientes] ([idCliente], [Nombres], [Apellidos], [FechaNacimiento], [CUIT], [Domicilio], [telefonoCelular], [email]) VALUES (3, N'Federico', N'Perez', CAST(N'1991-01-15' AS Date), N'20341234622', N'Colon 5123', N'3513985912', N'fperez@gmail.com')
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO
/****** Object:  StoredProcedure [dbo].[createCostumer]    Script Date: 4/2/2023 17:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[createCostumer]
@nombre nvarchar(150),
@apellido nvarchar(150),
@fechaN date,
@cuit nvarchar(11),
@domicilio nvarchar(200),
@telefono nvarchar(20),
@email nvarchar(100)
as
begin

insert into Clientes 
(Nombres,Apellidos,FechaNacimiento,CUIT,Domicilio,telefonoCelular,email)
values
(@nombre,@apellido,@fechaN,@cuit,@domicilio,@telefono,@email)

end
GO
/****** Object:  StoredProcedure [dbo].[deleteCostumer]    Script Date: 4/2/2023 17:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[deleteCostumer]
@id int
as
begin
delete Clientes where idCliente=@id
end
GO
/****** Object:  StoredProcedure [dbo].[getAllCostumer]    Script Date: 4/2/2023 17:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[getAllCostumer]
as
begin
select * from Clientes
end
GO
/****** Object:  StoredProcedure [dbo].[getCostumerById]    Script Date: 4/2/2023 17:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[getCostumerById]
@idCliente int
as
begin
select * from Clientes where idcliente=@idCliente
end
GO
/****** Object:  StoredProcedure [dbo].[getCostumerByName]    Script Date: 4/2/2023 17:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[getCostumerByName]
@data nvarchar(200)
as
begin
select * from Clientes where Nombres+' '+Apellidos like '%'+@data+'%'
end
GO
/****** Object:  StoredProcedure [dbo].[updateCostumer]    Script Date: 4/2/2023 17:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[updateCostumer]
@id int,
@nombre nvarchar(150),
@apellido nvarchar(150),
@fechaN date,
@cuit nvarchar(11),
@domicilio nvarchar(200),
@telefono nvarchar(20),
@email nvarchar(100)
as
begin

update Clientes 
set
Nombres=@nombre,
Apellidos=@apellido,
FechaNacimiento=@fechaN,CUIT=@cuit,
Domicilio=@domicilio,
telefonoCelular=@telefono,
email=@email
where idCliente=@id

end
GO
USE [master]
GO
ALTER DATABASE [Clientes-Challenge] SET  READ_WRITE 
GO
