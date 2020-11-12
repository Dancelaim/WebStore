exec Check_db_Version 29

ALTER TABLE TempOptionParams
ADD ParamParentId Uniqueidentifier

ALTER TABLE TempOptionParams
ADD CONSTRAINT FK_TempOptionParams_TempOptionParams FOREIGN KEY (ParamParentId) REFERENCES TempOptionParams(ParamsId)
------------ADD_COLLUM_AND_CREATE_F-KEY 2---------------------------
ALTER TABLE ProductOptionParams
ADD ParamParentId Uniqueidentifier

ALTER TABLE ProductOptionParams
ADD CONSTRAINT FK_ProductOptionParams_ProductOptionParams FOREIGN KEY (ParamParentId) REFERENCES ProductOptionParams(OptionParamsId)

exec Update_db_Version 29