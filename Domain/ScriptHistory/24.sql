exec Check_db_Version 24

GO
ALTER TABLE OptionParams
ADD ProductOptionId Uniqueidentifier

ALTER TABLE OptionParams
ADD FOREIGN KEY (ProductOptionId) REFERENCES ProductOption(ProductOptionId)

ALTER TABLE OptionParams
ADD Sale nvarChar(50)

ALTER TABLE ProductOption 
DROP CONSTRAINT FK__ProductOp__Optio__05D8E0BE   

ALTER TABLE ProductOption
DROP COLUMN OptionParamsId

ALTER TABLE Product 
DROP CONSTRAINT FK__Product__Product__02FC7413   

ALTER TABLE Product
DROP COLUMN ProductOptionId

ALTER TABLE ProductOption
add ProductId uniqueidentifier

ALTER TABLE ProductOption
ADD FOREIGN KEY (ProductId) REFERENCES Product(ProductId)
GO


exec Update_db_Version 24