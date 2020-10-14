exec Check_db_Version 22

EXEC sp_rename 'ProductDescription.ProductDescription', 'Description', 'COLUMN'

EXEC sp_rename 'ProductDescription.Description1', 'SubDescription1', 'COLUMN'
EXEC sp_rename 'ProductDescription.Description2', 'SubDescription2', 'COLUMN'
EXEC sp_rename 'ProductDescription.Description3', 'SubDescription3', 'COLUMN'
EXEC sp_rename 'ProductDescription.Description4', 'SubDescription4', 'COLUMN'
EXEC sp_rename 'ProductDescription.Description5', 'SubDescription5', 'COLUMN'

EXEC sp_rename 'ProductDescription.TitleDescription1', 'SubDescriptionTitle1', 'COLUMN'
EXEC sp_rename 'ProductDescription.TitleDescription2', 'SubDescriptionTitle2', 'COLUMN'
EXEC sp_rename 'ProductDescription.TitleDescription3', 'SubDescriptionTitle3', 'COLUMN'
EXEC sp_rename 'ProductDescription.TitleDescription4', 'SubDescriptionTitle4', 'COLUMN'
EXEC sp_rename 'ProductDescription.TitleDescription5', 'SubDescriptionTitle5', 'COLUMN'

exec Update_db_Version 22