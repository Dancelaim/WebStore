exec Check_db_Version 12

ALTER TABLE ScriptHistory
ALTER COLUMN Script smallint;

exec Update_db_Version 12