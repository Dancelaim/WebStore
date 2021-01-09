Begin Try
    SET NOCOUNT ON
    Set XACT_ABORT ON
Begin Tran
exec Check_db_Version 35

Create table Roles (RoleId uniqueidentifier primary key,RoleName Nvarchar(55))

Create table Users (UserId uniqueidentifier primary key,UserName Nvarchar(55),UserPassword nvarchar(55),RoleId uniqueidentifier,[RankId] uniqueidentifier,Email nvarchar(55))

Create table Ranks (RankId uniqueidentifier primary key, [Name] nvarchar(55),Sale nvarchar(55))

Alter table Users ADD FOREIGN KEY (RoleId) REFERENCES Roles(RoleId);

Alter table Users ADD FOREIGN KEY (RankId) REFERENCES Ranks(RankId);

insert into Roles values  (newid(),'Root Admin'),(newid(),'Agent'),(newid(),'Admin'),(newid(),'User'),(newid(),' Price Admin')

declare @RoleId uniqueidentifier  = (select RoleId from Roles where RoleName = 'Root Admin' )
insert into Users values  (newid(),'Admin','123',@RoleId,null,null)

insert into Ranks values (newid(),'Member',null),(newid(),'Bronze','1'),(newid(),'Silver','3'),(newid(),'Gold','5'),(newid(),'Diamond','7'),(newid(),'Shadow','10')


exec Update_db_Version 35
Commit Tran
End Try
Begin Catch
   RollBack Tran
   Select ERROR_MESSAGE() as Msg, ERROR_NUMBER() as Num
End Catch