USE [master]
GO

/****** Object:  Database [FoodCrave]    Script Date: 08/20/2014 10:12:12 ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'FoodCrave')
DROP DATABASE [FoodCrave]
GO

USE [master]
GO

/****** Object:  Database [FoodCrave]    Script Date: 08/20/2014 10:12:12 ******/
CREATE DATABASE [FoodCrave] ON  PRIMARY 
( NAME = N'FoodCrave', FILENAME = N'C:\Users\henrique.graca\FoodCrave.mdf' , SIZE = 48192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'FoodCrave_log', FILENAME = N'C:\Users\henrique.graca\FoodCrave_log.ldf' , SIZE = 94528KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FoodCrave].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [FoodCrave] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [FoodCrave] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [FoodCrave] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [FoodCrave] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [FoodCrave] SET ARITHABORT OFF 
GO

ALTER DATABASE [FoodCrave] SET AUTO_CLOSE ON 
GO

ALTER DATABASE [FoodCrave] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [FoodCrave] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [FoodCrave] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [FoodCrave] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [FoodCrave] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [FoodCrave] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [FoodCrave] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [FoodCrave] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [FoodCrave] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [FoodCrave] SET  ENABLE_BROKER 
GO

ALTER DATABASE [FoodCrave] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [FoodCrave] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [FoodCrave] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [FoodCrave] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [FoodCrave] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [FoodCrave] SET READ_COMMITTED_SNAPSHOT ON 
GO

ALTER DATABASE [FoodCrave] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [FoodCrave] SET  READ_WRITE 
GO

ALTER DATABASE [FoodCrave] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [FoodCrave] SET  MULTI_USER 
GO

ALTER DATABASE [FoodCrave] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [FoodCrave] SET DB_CHAINING OFF 
GO




USE [FoodCrave]
GO
/****** Object:  Table [dbo].[Banks]    Script Date: 08/20/2014 10:11:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Banks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Account] [nvarchar](max) NULL,
	[SortCode] [nvarchar](max) NULL,
	[AccountName] [nvarchar](max) NULL,
	[ConnectionFee] [decimal](18, 2) NULL,
	[InvoiceEmail] [nvarchar](max) NULL,
	[Iban] [nvarchar](max) NULL,
	[LegalName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Banks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FoodTypes]    Script Date: 08/20/2014 10:11:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.FoodTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Regions]    Script Date: 08/20/2014 10:11:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Regions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.Regions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PostCodes]    Script Date: 08/20/2014 10:11:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostCodes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[CityName] [nvarchar](500) NULL,
	[Synonyms] [nvarchar](500) NULL,
	[Region_Id] [int] NULL,
 CONSTRAINT [PK_dbo.PostCodes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Restaurants]    Script Date: 08/20/2014 10:11:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Restaurants](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[IsOffline] [bit] NOT NULL,
	[Joined] [datetime] NOT NULL,
	[IsBusy] [bit] NOT NULL,
	[ShortDescription] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[LogoUrl] [nvarchar](max) NULL,
	[DaysOpen] [int] NOT NULL,
	[OpenHours] [nvarchar](max) NULL,
	[OfflineMessage] [nvarchar](max) NULL,
	[Number] [nvarchar](max) NULL,
	[Rating] [float] NOT NULL,
	[Votes] [int] NOT NULL,
	[GeoLocation] [nvarchar](max) NULL,
	[FakeId] [nvarchar](max) NULL,
	[DeliversTo] [nvarchar](max) NULL,
	[ContactPhone] [nvarchar](max) NULL,
	[Latitude] [nvarchar](max) NULL,
	[Longitude] [nvarchar](max) NULL,
	[SaleFee] [int] NOT NULL,
	[FakeNumVotes] [int] NOT NULL,
	[FakeRating] [float] NOT NULL,
	[PostCode2] [nvarchar](max) NULL,
	[Bank_Id] [int] NULL,
 CONSTRAINT [PK_dbo.Restaurants] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RestaurantFoodTypes]    Script Date: 08/20/2014 10:11:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RestaurantFoodTypes](
	[Restaurant_Id] [int] NOT NULL,
	[FoodType_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.RestaurantFoodTypes] PRIMARY KEY CLUSTERED 
(
	[Restaurant_Id] ASC,
	[FoodType_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 08/20/2014 10:11:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Phone] [nvarchar](max) NULL,
	[MobilePhone] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Owner] [nvarchar](max) NULL,
	[ContactName] [nvarchar](max) NULL,
	[Restaurant_Id] [int] NULL,
 CONSTRAINT [PK_dbo.Contacts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 08/20/2014 10:11:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[City] [nvarchar](max) NULL,
	[Line1] [nvarchar](max) NULL,
	[Line2] [nvarchar](max) NULL,
	[Line3] [nvarchar](max) NULL,
	[PostCode] [nvarchar](max) NULL,
	[Restaurant_Id] [int] NULL,
 CONSTRAINT [PK_dbo.Addresses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_dbo.Addresses_dbo.Restaurants_Restaurant_Id]    Script Date: 08/20/2014 10:11:59 ******/
ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Addresses_dbo.Restaurants_Restaurant_Id] FOREIGN KEY([Restaurant_Id])
REFERENCES [dbo].[Restaurants] ([Id])
GO
ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK_dbo.Addresses_dbo.Restaurants_Restaurant_Id]
GO
/****** Object:  ForeignKey [FK_dbo.Contacts_dbo.Restaurants_Restaurant_Id]    Script Date: 08/20/2014 10:11:59 ******/
ALTER TABLE [dbo].[Contacts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Contacts_dbo.Restaurants_Restaurant_Id] FOREIGN KEY([Restaurant_Id])
REFERENCES [dbo].[Restaurants] ([Id])
GO
ALTER TABLE [dbo].[Contacts] CHECK CONSTRAINT [FK_dbo.Contacts_dbo.Restaurants_Restaurant_Id]
GO
/****** Object:  ForeignKey [FK_dbo.PostCodes_dbo.Regions_Region_Id]    Script Date: 08/20/2014 10:11:59 ******/
ALTER TABLE [dbo].[PostCodes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PostCodes_dbo.Regions_Region_Id] FOREIGN KEY([Region_Id])
REFERENCES [dbo].[Regions] ([Id])
GO
ALTER TABLE [dbo].[PostCodes] CHECK CONSTRAINT [FK_dbo.PostCodes_dbo.Regions_Region_Id]
GO
/****** Object:  ForeignKey [FK_dbo.RestaurantFoodTypes_dbo.FoodTypes_FoodType_Id]    Script Date: 08/20/2014 10:11:59 ******/
ALTER TABLE [dbo].[RestaurantFoodTypes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RestaurantFoodTypes_dbo.FoodTypes_FoodType_Id] FOREIGN KEY([FoodType_Id])
REFERENCES [dbo].[FoodTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RestaurantFoodTypes] CHECK CONSTRAINT [FK_dbo.RestaurantFoodTypes_dbo.FoodTypes_FoodType_Id]
GO
/****** Object:  ForeignKey [FK_dbo.RestaurantFoodTypes_dbo.Restaurants_Restaurant_Id]    Script Date: 08/20/2014 10:11:59 ******/
ALTER TABLE [dbo].[RestaurantFoodTypes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RestaurantFoodTypes_dbo.Restaurants_Restaurant_Id] FOREIGN KEY([Restaurant_Id])
REFERENCES [dbo].[Restaurants] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RestaurantFoodTypes] CHECK CONSTRAINT [FK_dbo.RestaurantFoodTypes_dbo.Restaurants_Restaurant_Id]
GO
/****** Object:  ForeignKey [FK_dbo.Restaurants_dbo.Banks_Bank_Id]    Script Date: 08/20/2014 10:11:59 ******/
ALTER TABLE [dbo].[Restaurants]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Restaurants_dbo.Banks_Bank_Id] FOREIGN KEY([Bank_Id])
REFERENCES [dbo].[Banks] ([Id])
GO
ALTER TABLE [dbo].[Restaurants] CHECK CONSTRAINT [FK_dbo.Restaurants_dbo.Banks_Bank_Id]
GO
