exec Check_db_Version 28
------------ADD_COLLUM_AND_CREATE_F-KEY 1---------------------------
ALTER TABLE TemplateOptions
ADD TempOptionParamParentId Uniqueidentifier

ALTER TABLE TemplateOptions
ADD CONSTRAINT FK_TemplateOptions_TempOptionParams FOREIGN KEY (TempOptionParamParentId) REFERENCES TempOptionParams(ParamsId)
------------ADD_COLLUM_AND_CREATE_F-KEY 2---------------------------
ALter Table ProductOptions
Add OptionParamsParentId Uniqueidentifier

alter table ProductOptions
add constraint FK_ProductOption_ProductOptionParams FOREIGN KEY (OptionParamsParentId) REFERENCES  ProductOptionParams(OptionParamsId)

exec Update_db_Version 28