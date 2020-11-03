exec Check_db_Version 27

EXEC sp_rename 'WowCarry.dbo.Options', 'ProductOptions'
EXEC sp_rename 'WowCarry.dbo.OptionParams', 'ProductOptionParams'


USE [WowCarry]
GO

/****** Object:  Table [dbo].[ProductOptions]    Script Date: 03.11.2020 17:34:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TemplateOptions](
	[TempOptionId] [uniqueidentifier] NOT NULL,
	[TempOptionName] [nchar](50) NULL,
	[TempOptionType] [nchar](10) NULL,
 CONSTRAINT [PK_TempOption] PRIMARY KEY CLUSTERED 
(
	[TempOptionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[ProductOptionParams]    Script Date: 03.11.2020 17:34:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TempOptionParams](
	[ParamsId] [uniqueidentifier] NOT NULL,
	[ParamName] [nvarchar](50) NULL,
	[ParamTooltip] [nvarchar](255) NULL,
	[ParamPrice] [float] NULL,
	[TempOptionId] [uniqueidentifier] NULL FOREIGN KEY REFERENCES [TemplateOptions](TempOptionId),
	[OptionSale] [nvarchar](50) NULL,
 CONSTRAINT [PK_Params] PRIMARY KEY CLUSTERED 
(
	[ParamsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
GO




exec Update_db_Version 27