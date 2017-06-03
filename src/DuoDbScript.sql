USE [master]
GO
/****** Object:  Database [Duo]    Script Date: 03/06/2017 16:20:30 ******/
CREATE DATABASE [Duo]
GO
USE [Duo]
GO
/****** Object:  Table [dbo].[ExtrusionLines]    Script Date: 03/06/2017 16:20:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExtrusionLines](
	[Id] [uniqueidentifier] NOT NULL,
	[Version] [int] NOT NULL,
	[Code] [nvarchar](10) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[StandardWidth] [int] NOT NULL,
 CONSTRAINT [PK_ExtrusionLines] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ExtrusionPrograms]    Script Date: 03/06/2017 16:20:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExtrusionPrograms](
	[Id] [uniqueidentifier] NOT NULL,
	[Version] [int] NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[ExtrusionLineId] [uniqueidentifier] NOT NULL,
	[ProductId] [uniqueidentifier] NOT NULL,
	[Thickness] [int] NOT NULL,
	[Lenght] [int] NOT NULL,
	[Widht] [int] NOT NULL,
	[TreatmentId] [uniqueidentifier] NOT NULL,
	[QuantityToBeProduced] [int] NOT NULL,
	[JumboRollToBeProduced] [int] NOT NULL,
	[ExpectedProductionDate] [int] NOT NULL,
 CONSTRAINT [PK_ExtrusionPrograms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 03/06/2017 16:20:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [uniqueidentifier] NOT NULL,
	[Version] [int] NOT NULL,
	[Code] [nvarchar](10) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[Thickness] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Treatments]    Script Date: 03/06/2017 16:20:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Treatments](
	[Id] [uniqueidentifier] NOT NULL,
	[Version] [int] NOT NULL,
	[Code] [nvarchar](10) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Treatments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[ExtrusionLines] ([Id], [Version], [Code], [Description], [StandardWidth]) VALUES (N'2d35dc74-988e-4978-bcbc-c54277f0947c', 1, N'EX1', N'Extrusion Line 1', 8600)
GO
INSERT [dbo].[Products] ([Id], [Version], [Code], [Description], [Thickness]) VALUES (N'9dccd482-13fe-4a34-8a51-09cba966d226', 1, N'COEX-25', N'Coex 25', 25)
GO
INSERT [dbo].[Products] ([Id], [Version], [Code], [Description], [Thickness]) VALUES (N'41fc05da-5036-4bff-8956-a03092c6ab90', 1, N'COEX-20', N'Coex 20', 20)
GO
INSERT [dbo].[Treatments] ([Id], [Version], [Code], [Description]) VALUES (N'86210105-7fe6-4499-b047-5b783652280d', 1, N'CO', N'Corona Outside')
GO
INSERT [dbo].[Treatments] ([Id], [Version], [Code], [Description]) VALUES (N'07c08544-18bb-4d3e-bac4-c1c6c4d65831', 1, N'NT', N'Not Treated')
GO
INSERT [dbo].[Treatments] ([Id], [Version], [Code], [Description]) VALUES (N'56bd42b7-876f-4ad6-bcc4-fb1fe84e476b', 1, N'CI', N'Corona Inside')
GO
USE [master]
GO
ALTER DATABASE [Duo] SET  READ_WRITE 
GO
