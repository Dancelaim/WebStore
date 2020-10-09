exec Check_db_Version 11
GO
ALTER PROCEDURE [dbo].[Check_db_Version] @Script smallint
AS
	declare @ScriptNumber nvarchar(10)
	set @ScriptNumber = (select * from ScriptHistory)
	if(@Script < @ScriptNumber)
		begin
			raiserror('Script version is lower than DB version', 20, -1) with log
		end
	else if(@Script = @ScriptNumber)
		begin 
			raiserror('Script version is same as DB version', 20, -1) with log
		end
		else if(@Script!=(@ScriptNumber+1))
		begin
			raiserror('Script version is not correct', 20, -1) with log 
		end
exec Update_db_Version 11