USE [master]
GO
/****** Object:  Database [user50_battle]    Script Date: 21.04.2023 15:33:25 ******/
CREATE DATABASE [user50_battle]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'user50_battle', FILENAME = N'/var/opt/mssql/data/user50_battle.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'user50_battle_log', FILENAME = N'/var/opt/mssql/data/user50_battle_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [user50_battle] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [user50_battle].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [user50_battle] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [user50_battle] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [user50_battle] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [user50_battle] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [user50_battle] SET ARITHABORT OFF 
GO
ALTER DATABASE [user50_battle] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [user50_battle] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [user50_battle] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [user50_battle] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [user50_battle] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [user50_battle] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [user50_battle] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [user50_battle] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [user50_battle] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [user50_battle] SET  DISABLE_BROKER 
GO
ALTER DATABASE [user50_battle] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [user50_battle] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [user50_battle] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [user50_battle] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [user50_battle] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [user50_battle] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [user50_battle] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [user50_battle] SET RECOVERY FULL 
GO
ALTER DATABASE [user50_battle] SET  MULTI_USER 
GO
ALTER DATABASE [user50_battle] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [user50_battle] SET DB_CHAINING OFF 
GO
ALTER DATABASE [user50_battle] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [user50_battle] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [user50_battle] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [user50_battle] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [user50_battle] SET QUERY_STORE = OFF
GO
USE [user50_battle]
GO
/****** Object:  Table [dbo].[EndGame]    Script Date: 21.04.2023 15:33:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EndGame](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserWin] [int] NULL,
	[UserShit] [int] NULL,
	[TurnCountUserWin] [int] NULL,
	[GameTimeEnd] [datetime] NULL,
	[Room_ID] [int] NOT NULL,
 CONSTRAINT [PK_EndGame] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rank]    Script Date: 21.04.2023 15:33:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rank](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Rank] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 21.04.2023 15:33:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[UserCreator_ID] [int] NOT NULL,
	[UserSlow_ID] [int] NULL,
	[GameTimeStart] [datetime] NULL,
	[Status_ID] [int] NOT NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 21.04.2023 15:33:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 21.04.2023 15:33:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[DateRegistration] [date] NULL,
	[Rank_ID] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Rank] ON 

INSERT [dbo].[Rank] ([ID], [Name]) VALUES (1, N'Юнга')
INSERT [dbo].[Rank] ([ID], [Name]) VALUES (2, N'Матрос')
INSERT [dbo].[Rank] ([ID], [Name]) VALUES (3, N'Старший матрос')
INSERT [dbo].[Rank] ([ID], [Name]) VALUES (4, N'Старшина 3-й статьи')
INSERT [dbo].[Rank] ([ID], [Name]) VALUES (5, N'Старшина 2-й статьи')
INSERT [dbo].[Rank] ([ID], [Name]) VALUES (6, N'Старшина 1-й статьи')
INSERT [dbo].[Rank] ([ID], [Name]) VALUES (7, N'Главный старшина')
INSERT [dbo].[Rank] ([ID], [Name]) VALUES (8, N'Главный корабельный старшина')
INSERT [dbo].[Rank] ([ID], [Name]) VALUES (9, N'Младший мичман')
INSERT [dbo].[Rank] ([ID], [Name]) VALUES (10, N'Мичман')
INSERT [dbo].[Rank] ([ID], [Name]) VALUES (11, N'Старший мичман')
INSERT [dbo].[Rank] ([ID], [Name]) VALUES (12, N'Главный мичман')
INSERT [dbo].[Rank] ([ID], [Name]) VALUES (13, N'Младший лейтенант')
INSERT [dbo].[Rank] ([ID], [Name]) VALUES (14, N'Лейтенант')
INSERT [dbo].[Rank] ([ID], [Name]) VALUES (15, N'Старший лейтенант')
INSERT [dbo].[Rank] ([ID], [Name]) VALUES (16, N'Капитан-лейтенант')
INSERT [dbo].[Rank] ([ID], [Name]) VALUES (17, N'Капитан 3-го ранга')
INSERT [dbo].[Rank] ([ID], [Name]) VALUES (18, N'Капитан 2-го ранга')
INSERT [dbo].[Rank] ([ID], [Name]) VALUES (19, N'Капитан 1-го ранга')
INSERT [dbo].[Rank] ([ID], [Name]) VALUES (20, N'Капитан-командор')
INSERT [dbo].[Rank] ([ID], [Name]) VALUES (21, N'Контр-адмирал')
INSERT [dbo].[Rank] ([ID], [Name]) VALUES (22, N'Вице-адмирал')
INSERT [dbo].[Rank] ([ID], [Name]) VALUES (23, N'Штабс-адмирал')
INSERT [dbo].[Rank] ([ID], [Name]) VALUES (24, N'УЛЬТРА-АДМИРАЛ')
SET IDENTITY_INSERT [dbo].[Rank] OFF
GO
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([ID], [Name], [UserCreator_ID], [UserSlow_ID], [GameTimeStart], [Status_ID]) VALUES (1, N'ХУй', 1, 2, CAST(N'2023-04-21T14:54:00.000' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[Room] OFF
GO
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([ID], [Name]) VALUES (1, N'Ожидание соперника')
INSERT [dbo].[Status] ([ID], [Name]) VALUES (2, N'В процессе')
INSERT [dbo].[Status] ([ID], [Name]) VALUES (3, N'Закончена')
SET IDENTITY_INSERT [dbo].[Status] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([ID], [Email], [Login], [Password], [DateRegistration], [Rank_ID]) VALUES (1, N'ewewfq@mail.ru', N'ewewfq', N'222', CAST(N'2023-04-21' AS Date), 1)
INSERT [dbo].[User] ([ID], [Email], [Login], [Password], [DateRegistration], [Rank_ID]) VALUES (2, N'string@shit.ru', N'string', N'string', CAST(N'2023-04-21' AS Date), 1)
INSERT [dbo].[User] ([ID], [Email], [Login], [Password], [DateRegistration], [Rank_ID]) VALUES (3, N'abobus@mail.ru', N'abobus', N'��3e欕�,C�9X4�', CAST(N'2023-04-21' AS Date), 1)
INSERT [dbo].[User] ([ID], [Email], [Login], [Password], [DateRegistration], [Rank_ID]) VALUES (4, N'a@a.ru', N'a', N'�u���1Ù�iw&a', CAST(N'2023-04-21' AS Date), 1)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_DateRegistration]  DEFAULT (getdate()) FOR [DateRegistration]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_Rank_ID]  DEFAULT ((1)) FOR [Rank_ID]
GO
ALTER TABLE [dbo].[EndGame]  WITH CHECK ADD  CONSTRAINT [FK_EndGame_Room] FOREIGN KEY([Room_ID])
REFERENCES [dbo].[Room] ([ID])
GO
ALTER TABLE [dbo].[EndGame] CHECK CONSTRAINT [FK_EndGame_Room]
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_Status] FOREIGN KEY([Status_ID])
REFERENCES [dbo].[Status] ([ID])
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [FK_Room_Status]
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_User] FOREIGN KEY([UserCreator_ID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [FK_Room_User]
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_User1] FOREIGN KEY([UserSlow_ID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [FK_Room_User1]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Rank] FOREIGN KEY([Rank_ID])
REFERENCES [dbo].[Rank] ([ID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Rank]
GO
USE [master]
GO
ALTER DATABASE [user50_battle] SET  READ_WRITE 
GO
