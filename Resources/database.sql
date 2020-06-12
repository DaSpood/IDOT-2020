USE [master]
GO
/****** Object:		Database [IdotProject]
******/
CREATE DATABASE [IdotProject]
GO
USE [IdotProject]
GO
/****** Object:		Table [models].[T_User]
******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [models].[T_User] (
	[Id]		[bigint]		IDENTITY(1,1)	NOT NULL,
	[Name]		[nvarchar](40)	UNIQUE			NOT NULL,
	[Password]	[nvarchar](32)	UNIQUE			NOT NULL,
	[Admin]		[bit]			DEFAULT 0		NOT NULL,
	CONSTRAINT [PK_T_User] PRIMARY KEY CLUSTERED
	(
		[Id] ASC
	) WITH (
		PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON
	) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:		Table [models].[T_Article]
******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [models].[T_Article] (
	[Id]		[bigint]		IDENTITY(1,1)	NOT NULL,
	[Title]		[nvarchar](40),
	[IdAuthor]	[bigint]						NOT NULL,
	[Date]		[date]							NOT NULL,
	[Image]		[image]							NOT NULL,
	[Text]		[text]							NOT NULL,
	[Viewcount] [bigint]		DEFAULT 0		NOT NULL,
	CONSTRAINT [PK_T_User] PRIMARY KEY CLUSTERED
	(
		[Id] ASC
	) WITH (
		PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON
	) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [model].[T_Article] WITH CHECK ADD CONSTRAINT [FK_T_Article_T_User]
FOREIGN KEY ([IdAuthor])
REFERENCES [model].[T_User] ([Id])
GO
ALTER TABLE [model].[T_Article] CHECK CONSTRAINT [FK_T_Article_T_User]
GO