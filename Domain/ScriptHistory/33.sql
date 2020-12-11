Begin Try
    SET NOCOUNT ON
    Set XACT_ABORT ON
Begin Tran
exec Check_db_Version 33

update TempOptionParams
set ParamTooltip = ''
where ParamTooltip is null

update TempOptionParams
set ParamPrice = '0'
where ParamPrice is null

ALTER TABLE ProductOptions
ALTER COLUMN OptionType  Nvarchar(10) NULL

ALTER TABLE ProductPrice
ALTER COLUMN Region Nvarchar(10)

ALTER TABLE TempOptionParams
ALTER COLUMN ParamTooltip nvarchar(255) NOT NULL

ALTER TABLE TempOptionParams
ALTER COLUMN ParamPrice decimal(18,2) NOT NULL

ALTER TABLE TempOptionParams
ALTER COLUMN OptionSale nvarchar(50) NOT NULL


ALTER TABLE ProductOptionParams
ALTER COLUMN ParamTooltip nvarchar(255) NOT NULL

ALTER TABLE ProductOptionParams
ALTER COLUMN ParamPrice decimal(18,2) NOT NULL

ALTER TABLE ProductOptionParams
ALTER COLUMN Sale nvarchar(50) NOT NULL

ALTER TABLE Product
ALTER COLUMN ProductName  Nvarchar(50) NOT NULL


ALTER TABLE ProductCategory
ALTER COLUMN ProductCategoryName  Nvarchar(50) NOT NULL

ALTER TABLE ProductCategory
ALTER COLUMN CategoryDescription  Nvarchar(255)  NULL


ALTER TABLE ProductGame
ALTER COLUMN GameName  Nvarchar(50)  NULL

ALTER TABLE ProductGame
ALTER COLUMN GameDescription  Nvarchar(255)  NULL

ALTER TABLE ProductGame
ALTER COLUMN GameShortUrl  Nvarchar(50)  NULL

ALTER TABLE Product
ALTER COLUMN ProductEnabled bit NOT NULL

exec Update_db_Version 33
Commit Tran
End Try
Begin Catch
   RollBack Tran
   Select ERROR_MESSAGE() as Msg, ERROR_NUMBER() as Num
End Catch