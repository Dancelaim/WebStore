Begin Try
    SET NOCOUNT ON
    Set XACT_ABORT ON
Begin Tran
exec Check_db_Version 40

ALTER TABLE Article 
ALTER COLUMN ArticlePostTime DATETIME NOT NULL 


ALTER TABLE Product 
ALTER COLUMN ProductEnabled bit NOT NULL 

exec Update_db_Version 40
Commit Tran
End Try
Begin Catch
   RollBack Tran
   Select ERROR_MESSAGE() as Msg, ERROR_NUMBER() as Num
End Catch