Begin Try
    SET NOCOUNT ON
    Set XACT_ABORT ON
Begin Tran
exec Check_db_Version 34

DECLARE @sqlCommand varchar(1000)
set @sqlCommand  =( SELECT top 1 'ALTER TABLE [' +  OBJECT_SCHEMA_NAME(parent_object_id) + '].[' + OBJECT_NAME(parent_object_id) +'] DROP CONSTRAINT [' + name + ']' FROM sys.foreign_keys WHERE referenced_object_id = object_id('TemplateOptions'))
EXEC (@sqlCommand)

set @sqlCommand  =( SELECT top 1 'ALTER TABLE [' +  OBJECT_SCHEMA_NAME(parent_object_id) + '].[' + OBJECT_NAME(parent_object_id) +'] DROP CONSTRAINT [' + name + ']' FROM sys.foreign_keys WHERE referenced_object_id = object_id('ProductOptions'))
EXEC (@sqlCommand)

set @sqlCommand  =( SELECT top 1 'ALTER TABLE [' +  OBJECT_SCHEMA_NAME(parent_object_id) + '].[' + OBJECT_NAME(parent_object_id) +'] DROP CONSTRAINT [' + name + ']' FROM sys.foreign_keys WHERE referenced_object_id = object_id('TempOptionParams'))
EXEC (@sqlCommand)

set @sqlCommand  =( SELECT top 1 'ALTER TABLE [' +  OBJECT_SCHEMA_NAME(parent_object_id) + '].[' + OBJECT_NAME(parent_object_id) +'] DROP CONSTRAINT [' + name + ']' FROM sys.foreign_keys WHERE referenced_object_id = object_id('ProductOptionParams'))
EXEC (@sqlCommand)

EXEC sp_rename 'TemplateOptions.TempOptionId', 'OptionId', 'COLUMN'
EXEC sp_rename 'TemplateOptions.TempOptionName', 'OptionName', 'COLUMN'
EXEC sp_rename 'TemplateOptions.TempOptionType', 'OptionType', 'COLUMN'
EXEC sp_rename 'TemplateOptions.TempOptionParamParentId', 'OptionParentId', 'COLUMN'
EXEC sp_rename 'ProductOptions.OptionParamsParentId', 'OptionParentId', 'COLUMN'
EXEC sp_rename 'ProductOptions.ProductOptionId', 'OptionId', 'COLUMN'
EXEC sp_rename 'TempOptionParams.ParamsId', 'ParameterId', 'COLUMN'
EXEC sp_rename 'ProductOptionParams.OptionParamsId', 'ParameterId', 'COLUMN'
EXEC sp_rename 'TempOptionParams.ParamName', 'ParameterName', 'COLUMN'
EXEC sp_rename 'ProductOptionParams.ParamName', 'ParameterName', 'COLUMN'
EXEC sp_rename 'TempOptionParams.ParamTooltip', 'ParameterTooltip', 'COLUMN'
EXEC sp_rename 'ProductOptionParams.ParamTooltip', 'ParameterTooltip', 'COLUMN'
EXEC sp_rename 'TempOptionParams.ParamPrice', 'ParameterPrice', 'COLUMN'
EXEC sp_rename 'ProductOptionParams.ParamPrice', 'ParameterPrice', 'COLUMN'
EXEC sp_rename 'TempOptionParams.TempOptionId', 'ParentOptionId', 'COLUMN'
EXEC sp_rename 'ProductOptionParams.ProductOptionId', 'ParentOptionId', 'COLUMN'
EXEC sp_rename 'TempOptionParams.OptionSale', 'ParameterSale', 'COLUMN'
EXEC sp_rename 'ProductOptionParams.Sale', 'ParameterSale', 'COLUMN'
EXEC sp_rename 'TempOptionParams.ParamParentId', 'Delete', 'COLUMN'
EXEC sp_rename 'ProductOptionParams.ParamParentId', 'ParameterParentId', 'COLUMN'

ALTER TABLE TempOptionParams
DROP COLUMN [Delete]

ALTER TABLE ProductOptions
ADD CONSTRAINT FK_Product_ProductOption FOREIGN KEY (OptionProductId) REFERENCES Product(ProductId)
ALTER TABLE ProductOptionParams
ADD CONSTRAINT FK_ProductOptionParams_ProductOptionParams FOREIGN KEY (ParameterParentId) REFERENCES ProductOptionParams(ParameterId)

ALTER TABLE ProductOptions
ADD CONSTRAINT FK_ProductOptions_ProductOptions FOREIGN KEY (OptionParentId) REFERENCES ProductOptions(OptionId)

ALTER TABLE ProductOptionParams
ADD CONSTRAINT FK_ProductOptions_ProductOptionParams FOREIGN KEY (ParentOptionId) REFERENCES ProductOptions(OptionId)
ALTER TABLE TempOptionParams
ADD CONSTRAINT FK_TemplateOptions_TempOptionParams FOREIGN KEY (ParentOptionId) REFERENCES TemplateOptions(OptionId)



exec Update_db_Version 34
Commit Tran
End Try
Begin Catch
   RollBack Tran
   Select ERROR_MESSAGE() as Msg, ERROR_NUMBER() as Num
End Catch