exec Check_db_Version 1

CREATE TABLE [dbo].[ProductSubCategory](
	[ProductSubCategoryId] [uniqueidentifier] NOT NULL,
	[ProductCategoryName] [nvarchar](50) NULL,
	[ProductCategoryId] [nvarchar](50) NULL,
	[CategoryDescription] [nvarchar](255) NULL,
 CONSTRAINT [PK_ProductSubCategory] PRIMARY KEY CLUSTERED 
(
	[ProductSubCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

exec Update_db_Version 1