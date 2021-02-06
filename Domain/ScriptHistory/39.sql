Begin Try
    SET NOCOUNT ON
    Set XACT_ABORT ON
Begin Tran
exec Check_db_Version 39

Create table Article
(
	ArticleId uniqueidentifier Primary key
	,Title nvarchar(100)
	,ShortDescription nvarchar(255)
	,[Description] nvarchar(max)
	,ReadTime nvarchar(55)
	,Tags nvarchar(255)
	,ProductGameId uniqueidentifier 
	,SEOId uniqueidentifier 
	,ImagePath nvarchar(255)
	,[Enabled] bit
	,Rating int
	,ArticleCreateTime datetime  DEFAULT GETDATE()
	,ArticleUpdateTime datetime  DEFAULT GETDATE()
	,ArticlePostTime datetime  DEFAULT GETDATE()

	CONSTRAINT FK_ProductGame FOREIGN KEY (ProductGameId) REFERENCES ProductGame(ProductGameId),
	CONSTRAINT FK_SEO FOREIGN KEY (SEOId) REFERENCES SEO(SEOId)
)


exec Update_db_Version 39
Commit Tran
End Try
Begin Catch
   RollBack Tran
   Select ERROR_MESSAGE() as Msg, ERROR_NUMBER() as Num
End Catch