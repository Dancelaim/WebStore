Begin Try
    SET NOCOUNT ON
    Set XACT_ABORT ON
Begin Tran
exec Check_db_Version 36

ALTER TABLE Users add DefaultPage nvarchar(55) null

Create table Customers (CustomerId uniqueidentifier primary key,[Name] Nvarchar(55),[Password] nvarchar(55),[RankId] uniqueidentifier,Email nvarchar(55))

Alter table Customers ADD FOREIGN KEY (RankId) REFERENCES Ranks(RankId)

ALTER TABLE Users DROP COLUMN RankId

Create table Orders (OrderId uniqueidentifier primary key, CustomerId uniqueidentifier,Discord nvarchar(55),Comment nvarchar(55),OrderCustomFieldsId uniqueidentifier,Email nvarchar(55),PaymentMethod nvarchar(55),PaymentCode nvarchar(55),Total decimal (18,2),OrderStatus nvarchar(55),Currency nvarchar(55),CustomerIP nvarchar(55),UserAgent nvarchar(255),OrderCreateTime datetime,OrderUpdateTime datetime, EmailSended bit,EmailSendTime datetime )
Create table OrderCustomFields (OrderCustomFieldsId uniqueidentifier primary key,ShlCharacterName nvarchar(55),ShlRealmName nvarchar(55),ShlFaction nvarchar(55),ShlRegion nvarchar(55),ShlBattleTag nvarchar(55),PoeCharacterName nvarchar(55),PoeAccountName nvarchar(55),ClassicCharacterName nvarchar(55),ClassicRealmName nvarchar(55),ClassicFaction nvarchar(55),ClassicRegion nvarchar(55),ClassicBattleTag nvarchar(55))

Alter table Orders ADD FOREIGN KEY (OrderCustomFieldsId) REFERENCES OrderCustomFields(OrderCustomFieldsId)
Alter table Orders ADD FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId)

exec Update_db_Version 36
Commit Tran
End Try
Begin Catch
   RollBack Tran
   Select ERROR_MESSAGE() as Msg, ERROR_NUMBER() as Num
End Catch