USE [Accounting_DB]
GO
/****** Object:  Table [dbo].[Acconting]    Script Date: 3/2/2025 7:47:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Acconting](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[TypeID] [int] NOT NULL,
	[Amount] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[DateTitle] [datetime] NOT NULL,
 CONSTRAINT [PK_Acconting] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccontingType]    Script Date: 3/2/2025 7:47:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccontingType](
	[TypeID] [int] NOT NULL,
	[TypeTitele] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_AccontingType] PRIMARY KEY CLUSTERED 
(
	[TypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 3/2/2025 7:47:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](200) NOT NULL,
	[Mobile] [nvarchar](150) NOT NULL,
	[Email] [nvarchar](200) NULL,
	[Adress] [nvarchar](max) NULL,
	[Image] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Acconting]  WITH CHECK ADD  CONSTRAINT [FK_Acconting_AccontingType1] FOREIGN KEY([TypeID])
REFERENCES [dbo].[AccontingType] ([TypeID])
GO
ALTER TABLE [dbo].[Acconting] CHECK CONSTRAINT [FK_Acconting_AccontingType1]
GO
ALTER TABLE [dbo].[Acconting]  WITH CHECK ADD  CONSTRAINT [FK_Acconting_Customers1] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customers] ([ID])
GO
ALTER TABLE [dbo].[Acconting] CHECK CONSTRAINT [FK_Acconting_Customers1]
GO
