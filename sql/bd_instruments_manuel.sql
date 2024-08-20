USE [master]
GO
/****** Object:  Database [db_instruments]    Script Date: 19/08/2024 20:24:25 ******/
CREATE DATABASE [db_instruments]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_instruments', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\db_instruments.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'db_instruments_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\db_instruments_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [db_instruments] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_instruments].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_instruments] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_instruments] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_instruments] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_instruments] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_instruments] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_instruments] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [db_instruments] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_instruments] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_instruments] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_instruments] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_instruments] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_instruments] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_instruments] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_instruments] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_instruments] SET  DISABLE_BROKER 
GO
ALTER DATABASE [db_instruments] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_instruments] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_instruments] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_instruments] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_instruments] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_instruments] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_instruments] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_instruments] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [db_instruments] SET  MULTI_USER 
GO
ALTER DATABASE [db_instruments] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_instruments] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_instruments] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_instruments] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [db_instruments] SET DELAYED_DURABILITY = DISABLED 
GO
USE [db_instruments]
GO
/****** Object:  Table [dbo].[Instruments]    Script Date: 19/08/2024 20:24:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Instruments](
	[Id] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Type] [nvarchar](100) NULL,
	[Price] [nvarchar](50) NULL,
	[IsDeleted] [bit] NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  StoredProcedure [dbo].[AddInstrument]    Script Date: 19/08/2024 20:24:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddInstrument]
    @Id NVARCHAR(50),
    @Name NVARCHAR(100),
    @Type NVARCHAR(100),
    @Price NVARCHAR(50)  
AS
BEGIN
    INSERT INTO Instruments (Id, Name, Type, Price)
    VALUES (@Id, @Name, @Type, @Price);
END

GO
/****** Object:  StoredProcedure [dbo].[EditInstrument]    Script Date: 19/08/2024 20:24:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditInstrument]
    @Id NVARCHAR(50),
    @Name NVARCHAR(100),
    @Type NVARCHAR(100),
    @Price DECIMAL(18, 2)
AS
BEGIN
    UPDATE Instruments
    SET Name = @Name,
        Type = @Type,
        Price = @Price
    WHERE Id = @Id;
END

GO
/****** Object:  StoredProcedure [dbo].[GetAllInstruments]    Script Date: 19/08/2024 20:24:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllInstruments]
AS
BEGIN
    SELECT Id, Name, Type, Price
    FROM Instruments
    WHERE IsDeleted = 0;

END

GO
/****** Object:  StoredProcedure [dbo].[GetInstrumentById]    Script Date: 19/08/2024 20:24:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetInstrumentById]
    @Id NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Id, Name, Type, Price
    FROM Instruments
    WHERE Id = @Id;
END

GO
/****** Object:  StoredProcedure [dbo].[SoftDeleteInstrument]    Script Date: 19/08/2024 20:24:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SoftDeleteInstrument]
    @Id NVARCHAR(50)
AS
BEGIN
    UPDATE Instruments
    SET IsDeleted = 1
    WHERE Id = @Id;
END
GO
USE [master]
GO
ALTER DATABASE [db_instruments] SET  READ_WRITE 
GO
