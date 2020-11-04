exec Check_db_Version 26

ALTER TABLE Product
ADD ProductPriority int;

ALTER TABLE Product
ADD ProductEnabled bit;

ALTER TABLE Product
ADD ProductImageThumb nvarchar(55);
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
CREATE TABLE [dbo].[TempOptionParams](
	[ParamsId] [uniqueidentifier] NOT NULL,
	[ParamName] [nvarchar](50) NULL,
	[ParamTooltip] [nvarchar](255) NULL,
	[ParamPrice] [float] NULL,
	[TempOptionId] [uniqueidentifier] NULL,
	[OptionSale] [nvarchar](50) NULL,
 CONSTRAINT [PK_Params] PRIMARY KEY CLUSTERED 
(
	[ParamsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TempOptionParams]  WITH CHECK ADD FOREIGN KEY([TempOptionId])
REFERENCES [dbo].[TemplateOptions] ([TempOptionId])
GO 
EXEC sp_rename 'WowCarry.dbo.OptionParams', 'ProductOptionParams'
GO 
EXEC sp_rename 'WowCarry.dbo.ProductOption', 'ProductOptions'
GO
ALTER TABLE ProductToOption
ADD FOREIGN KEY (ProductId) REFERENCES Product(ProductId);
GO
ALTER TABLE ProductToOption
ADD FOREIGN KEY (ProductOptionId) REFERENCES ProductOptions(ProductOptionId);
GO 
EXEC sp_rename 'ProductToOption.OptionId', 'ProductOptionId', 'COLUMN'
GO
ALTER TABLE ProductOptions
ALTER COLUMN OptionName nvarchar(55)
GO
exec Update_db_Version 26