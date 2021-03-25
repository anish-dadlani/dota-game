USE [master]
GO
/****** Object:  Database [dota]    Script Date: 3/26/2021 1:22:55 AM ******/
CREATE DATABASE [dota]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dota', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\dota.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'dota_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\dota_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [dota] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dota].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dota] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dota] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dota] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dota] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dota] SET ARITHABORT OFF 
GO
ALTER DATABASE [dota] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dota] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dota] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dota] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dota] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dota] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dota] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dota] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dota] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dota] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dota] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dota] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dota] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dota] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dota] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dota] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dota] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dota] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [dota] SET  MULTI_USER 
GO
ALTER DATABASE [dota] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dota] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dota] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dota] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [dota] SET DELAYED_DURABILITY = DISABLED 
GO
USE [dota]
GO
/****** Object:  Table [dbo].[tournaments]    Script Date: 3/26/2021 1:22:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tournaments](
	[t_id] [int] IDENTITY(1,1) NOT NULL,
	[t_name] [varchar](50) NOT NULL,
	[t_pp] [varchar](50) NOT NULL,
	[t_date] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[t_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[insertTournaments]    Script Date: 3/26/2021 1:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[insertTournaments]
@t_name varchar(50),
@t_pp varchar(50),
@t_date datetime
as
insert into tournaments values (@t_name,@t_pp,@t_date)

GO
/****** Object:  StoredProcedure [dbo].[st_deleteTournaments]    Script Date: 3/26/2021 1:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[st_deleteTournaments]
@id int
as
delete from tournaments where t_id = @id

GO
/****** Object:  StoredProcedure [dbo].[st_getTournamentsData]    Script Date: 3/26/2021 1:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[st_getTournamentsData]
as
select 
u.t_id as 'ID',
u.t_name as 'Tournament',
u.t_pp as 'Pool Prize',
u.t_date as 'Date'
from tournaments u order by u.t_name asc

GO
/****** Object:  StoredProcedure [dbo].[st_getTournamentsDataLike]    Script Date: 3/26/2021 1:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[st_getTournamentsDataLike]
@data varchar(50)
as
select 
u.t_id as 'ID',
u.t_name as 'Tournament',
u.t_pp as 'Pool Prize',
u.t_date as 'Date'
from tournaments u 
where 
u.t_name like '%'+@data+'%'
order by u.t_name asc

GO
/****** Object:  StoredProcedure [dbo].[st_updateTournaments]    Script Date: 3/26/2021 1:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[st_updateTournaments]
@t_name varchar(50),
@t_pp varchar(50),
@t_date datetime,
@id int
as
update tournaments 
set
t_name = @t_name,
t_pp = @t_pp
where t_id = @id

GO
USE [master]
GO
ALTER DATABASE [dota] SET  READ_WRITE 
GO
