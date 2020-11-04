exec Check_db_Version 26

ALTER TABLE Product
ADD ProductPriority int;

ALTER TABLE Product
ADD ProductEnabled bit;

ALTER TABLE Product
ADD ProductImageThumb nvarchar(55);


ALTER TABLE ProductToOption
ADD FOREIGN KEY (ProductId) REFERENCES Product(ProductId);

ALTER TABLE ProductToOption
ADD FOREIGN KEY (ProductOptionId) REFERENCES ProductOptions(ProductOptionId);
GO 

EXEC sp_rename 'ProductToOption.OptionId', 'ProductOptionId', 'COLUMN'
GO
ALTER TABLE ProductOptions
ALTER COLUMN OptionName nvarchar(55)
GO
exec Update_db_Version 26