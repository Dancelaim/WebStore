exec Check_db_Version 13
Go
ALTER PROCEDURE [dbo].[Update_db_Version] @Script smallint
AS
	declare @ScriptNumber nvarchar(10)
	set @ScriptNumber = (select * from ScriptHistory)

	if(@Script < @ScriptNumber)
		begin
			Raiserror('Script version is lower than DB version',1,1)
		end
	else if(@Script = @ScriptNumber)
		begin 
			Raiserror('Script version is same as DB version',1,1)
		end
	else
		begin
		update ScriptHistory set Script = @Script
		end

exec Update_db_Version 13