exec Check_db_Version 26

ALTER TABLE Product
ADD ProductPriority int;


ALTER TABLE Product
ADD ProductEnabled bit;

ALTER TABLE Product
ADD ProductImageThumb nvarchar(55);

exec Update_db_Version 26