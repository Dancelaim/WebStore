exec Check_db_Version 25

GO
ALTER TABLE ProductOption 
DROP CONSTRAINT FK__ProductOp__Produ__3B40CD36   

ALTER TABLE ProductOption
DROP COLUMN ProductId

GO
CREATE TABLE [dbo].[ProductToOption](
	[ProductId] [uniqueidentifier] NOT NULL,
	[OptionId] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE Product
DROP CONSTRAINT FK__Product__Product__08B54D69   
GO
ALTER TABLE Product
ADD FOREIGN KEY (ProductSEOId) REFERENCES SEO(SEOId)
GO
ALTER TABLE [dbo].[ProductToOption]  WITH CHECK ADD FOREIGN KEY([OptionId])
REFERENCES [dbo].[ProductOption] ([ProductOptionId])
GO

ALTER TABLE [dbo].[ProductToOption]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO

ALTER TABLE [dbo].[ProductToOption]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO


ALTER TABLE ProductGame
add GameSeoId uniqueidentifier

ALTER TABLE ProductGame
ADD FOREIGN KEY (GameSeoId) REFERENCES SEO(SeoId)

ALTER TABLE ProductCategory
add CategorySeoId uniqueidentifier

ALTER TABLE ProductCategory
ADD FOREIGN KEY (CategorySeoId) REFERENCES SEO(SeoId)

ALTER TABLE ProductSubCategory
add SubCategorySeoId uniqueidentifier

ALTER TABLE ProductSubCategory
ADD FOREIGN KEY (SubCategorySeoId) REFERENCES SEO(SeoId)

ALTER TABLE SEO
add SEOImage nvarchar(55)

ALTER TABLE ProductPrice
add ProductSale decimal(18,1)

ALTER TABLE ProductPrice
DROP COLUMN MaxPrice

ALTER TABLE ProductPrice
DROP COLUMN MinPrice


GO

EXEC sp_rename 'ProductCEO', 'SEO'

EXEC sp_rename 'SEO.ProductCEOId', 'SEOId', 'COLUMN'

EXEC sp_rename 'SEO.ProductTags', 'SEOTags', 'COLUMN'

EXEC sp_rename 'Product.ProductCEOId', 'ProductSEOId', 'COLUMN'

exec Update_db_Version 25