exec Check_db_Version 31




-------------------------Ниалота ---------------------------------------------

declare @OptionId uniqueidentifier = newID()
declare @OptionName nvarchar(50) =	'Raid loot options'
declare @OptionType nvarchar(10) = 'Checkbox'

insert into TemplateOptions (TempOptionId,TempOptionName,TempOptionType)
values (@OptionId,@OptionName,@OptionType)
---------------------------------Params 1-----------------------------------------------
declare @ParamsId uniqueidentifier = newID()
declare @ParamName nvarchar(max) = 'Personal loot'
declare @ParamTooltip nvarchar(max) = 'You will receive all the personal loot obtained during the service'
declare @ParamPrice decimal(18,2) = '0' 
declare @Sale nvarchar = '0'	

insert into TempOptionParams (ParamsId,ParamName,ParamTooltip,ParamPrice,TempOptionId,OptionSale)
values (@ParamsId,@ParamName,@ParamTooltip,@ParamPrice,@OptionId,@Sale)
---------------------------------Params 2-----------------------------------------------
set @ParamsId  = newID()
set @ParamName  = '+1 player with my armor type'
set @ParamTooltip  = 'One player with your armor type will be assigned to you and will trade you all the items that he loots'
set @ParamPrice  = '29.99' 
set @Sale  = '0'	

insert into TempOptionParams (ParamsId,ParamName,ParamTooltip,ParamPrice,TempOptionId,OptionSale)
values (@ParamsId,@ParamName,@ParamTooltip,@ParamPrice,@OptionId,@Sale)
---------------------------------Params 3-----------------------------------------------
set @ParamsId  = newID()
set @ParamName  = '+2 player with my armor type'
set @ParamTooltip  = 'Two players with your armor type will be assigned to you and will trade you all the items that they loot'
set @ParamPrice  = '49.99' 
set @Sale  = '0'	

insert into TempOptionParams (ParamsId,ParamName,ParamTooltip,ParamPrice,TempOptionId,OptionSale)
values (@ParamsId,@ParamName,@ParamTooltip,@ParamPrice,@OptionId,@Sale)
---------------------------------Params 4-----------------------------------------------
set @ParamsId  = newID()
set @ParamName  = '+3 player with my armor type'
set @ParamTooltip  = 'Three players with your armor type will be assigned to you and will trade you all the items that they loot'
set @ParamPrice  = '69.99' 
set @Sale  = '0'	

insert into TempOptionParams (ParamsId,ParamName,ParamTooltip,ParamPrice,TempOptionId,OptionSale)
values (@ParamsId,@ParamName,@ParamTooltip,@ParamPrice,@OptionId,@Sale)



---------------------------кастом мифик кей-------------------------------------------------

set @OptionId  = newID()
set @OptionName  =	'Select Key level'
set @OptionType  = 'Dropdown'
insert into TemplateOptions (TempOptionId,TempOptionName,TempOptionType)
values (@OptionId,@OptionName,@OptionType)
---------------------------------Params 1-----------------------------------------------
set @ParamsId  = newID()
set @ParamName  = '10'
set @ParamPrice  = '10.99' 
set @Sale  = '0'	

insert into TempOptionParams (ParamsId,ParamName,ParamPrice,TempOptionId,OptionSale)
values (@ParamsId,@ParamName,@ParamPrice,@OptionId,@Sale)	

-------------------------Product Option fix 2---------------------------------------------
set @OptionId  = newID()
set @OptionName  =	'Increase your loot chance'
set @OptionType = 'Checkbox'
insert into TemplateOptions (TempOptionId,TempOptionName,TempOptionType,TempOptionParamParentId)
values (@OptionId,@OptionName,@OptionType,@ParamsId)

---------------------------------Params 1-----------------------------------------------
set @ParamsId  = newID()
set @ParamName  = 'No guaranteed armor type match'
set @ParamTooltip  = 'You still get all the loot dropped by the end of the dungeon but we don’t guarantee any number of team members matching your armor type. Nevertheless, we will always try to match your armor type on availability basis'


insert into TempOptionParams (ParamsId,ParamName,ParamTooltip,TempOptionId)
values (@ParamsId,@ParamName,@ParamTooltip,@OptionId)	
----fix------------------------Params 2-----------------------------------------------
set @ParamsId = newID()
set @ParamName = '+1 player with my armor type'
set @ParamTooltip = 'At least one member of our team will match your armor type, thus increasing your chance to get additional items for your specialization'

insert into TempOptionParams (ParamsId,ParamName,ParamTooltip,TempOptionId)
values (@ParamsId,@ParamName,@ParamTooltip,@OptionId)	
---------------------------------Params 2-----------------------------------------------
set @ParamsId = newID()
set @ParamName = '+2 player with my armor type'
set @ParamTooltip = 'At least two members of our team will match your armor type, thus significantly increasing your chance to get additional items for your specialization'

insert into TempOptionParams (ParamsId,ParamName,ParamTooltip,TempOptionId)
values (@ParamsId,@ParamName,@ParamTooltip,@OptionId)	

-------------------------Product Option fix 3---------------------------------------------
set @OptionId  = newID()
set @OptionName  =	'Dungeon options'
set @OptionType = 'Checkbox'
insert into TemplateOptions (TempOptionId,TempOptionName,TempOptionType,TempOptionParamParentId)
values (@OptionId,@OptionName,@OptionType,@ParamsId)
---------------------------------Params 1-----------------------------------------------
set @ParamsId  = newID()
set @ParamName  = 'Beating the timer'
set @ParamTooltip  = 'Choosing this option you will have a guarantee that the dungeon is completed within the time limit. By completing the key "in-time" the team will have one additional item at the end of the dungeon'
set @ParamPrice  = '0' 
set @Sale  = '0'	

insert into TempOptionParams (ParamsId,ParamName,ParamTooltip,ParamPrice,TempOptionId,OptionSale)
values (@ParamsId,@ParamName,@ParamTooltip,@ParamPrice,@OptionId,@Sale)	
---------------------------------Params 2-----------------------------------------------
set @ParamsId  = newID()
set @ParamName  = 'I want specific dungeon(s)'
set @ParamTooltip  = 'In case you are trying to get some specific loot from a specific dungeon we can provide this dungeon for you'
set @ParamPrice  = '3.99' 
set @Sale  = '0'	

insert into TempOptionParams (ParamsId,ParamName,ParamTooltip,ParamPrice,TempOptionId,OptionSale)
values (@ParamsId,@ParamName,@ParamTooltip,@ParamPrice,@OptionId,@Sale)	

-------------------------Product Option fix 3---------------------------------------------
set @OptionId  = newID()
set @OptionName  =	'List Desired Dungeon(s)'
set @OptionType = 'TextBox'
insert into TemplateOptions (TempOptionId,TempOptionName,TempOptionType,TempOptionParamParentId)
values (@OptionId,@OptionName,@OptionType,@ParamsId)
---------------------------------Params 1	-----------------------------------------------
set @ParamsId  = newID()

insert into TempOptionParams (ParamsId)
values (@ParamsId)	



-----------------------------------------хай мифик------------------------


set @OptionId  = newID()
set @OptionName  =	'Number of Hours'
set @OptionType  = 'Checkbox'
insert into TemplateOptions (TempOptionId,TempOptionName,TempOptionType)
values (@OptionId,@OptionName,@OptionType)
---------------------------------Params 1-----------------------------------------------
set @ParamsId  = newID()
set @ParamName  = '2 hours'
set @ParamTooltip = 'You will be able to complete up to 4 high level dungeons'


insert into TempOptionParams (ParamsId,ParamName,ParamTooltip,TempOptionId)
values (@ParamsId,@ParamName,@ParamTooltip,@OptionId)	
-------------------------Product fix 2---------------------------------------------
set @OptionId = newID()
set @OptionName  =	'Select range of high keys to play'
set @OptionType  = 'Dropdown'

insert into TemplateOptions (TempOptionId,TempOptionName,TempOptionType,TempOptionParamParentId)
values (@OptionId,@OptionName,@OptionType,@ParamsId)
---------------------------------Params 1-----------------------------------------------
set @ParamsId  = newID()
set @ParamName  = 'Mythic +19-21 keys'
set @ParamPrice  = '259.99' 
set @Sale  = '0'	

insert into TempOptionParams (ParamsId,ParamName,ParamPrice,TempOptionId,OptionSale)
values (@ParamsId,@ParamName,@ParamPrice,@OptionId,@Sale)	
---------------------------------Params 2-----------------------------------------------
set @ParamsId  = newID()
set @ParamName  = 'Mythic +21-23 keys'
set @ParamPrice  = '354.99' 
set @Sale  = '0'	

insert into TempOptionParams (ParamsId,ParamName,ParamPrice,TempOptionId,OptionSale)
values (@ParamsId,@ParamName,@ParamPrice,@OptionId,@Sale)	



-------------------------------------essence---------------------------------------------

set @OptionId  = newID()
set @OptionName  =	'Select Your Current Essence Rank'
set @OptionType  = 'chechbox'
insert into TemplateOptions (TempOptionId,TempOptionName,TempOptionType)
values (@OptionId,@OptionName,@OptionType)
---------------------------------Params 1-----------------------------------------------
set @ParamsId  = newID()
set @ParamName  = 'I don’t have this essence'
set @ParamTooltip  = 'Select this option if you currently don’t have this essence at all'

insert into TempOptionParams (ParamsId,ParamName,ParamTooltip,TempOptionId)
values (@ParamsId,@ParamName,@ParamTooltip,@OptionId)	

-------------------------Product fix 2---------------------------------------------
set @OptionId  = newID()
set @OptionName =	'Select Desired Essence Rank'
set @OptionType  = 'chechbox'

insert into TemplateOptions (TempOptionId,TempOptionName,TempOptionType,TempOptionParamParentId)
values (@OptionId,@OptionName,@OptionType,@ParamsId)
---------------------------------Params 1-----------------------------------------------
set @ParamsId  = newID()
set @ParamName  = 'Rank 1 essence'
set @ParamTooltip  = 'You will get Rank 1 of the selected essence by choosing this option'
set @ParamPrice  = '24.00' 
set @Sale  = '0'	

insert into TempOptionParams (ParamsId,ParamName,ParamTooltip,ParamPrice,TempOptionId,OptionSale)
values (@ParamsId,@ParamName,@ParamTooltip,@ParamPrice,@OptionId,@Sale)	
---------------------------------Params 2-----------------------------------------------
set @ParamsId  = newID()
set @ParamName  = 'Rank 2 essence'
set @ParamTooltip  = 'You will get Rank 2 of the selected essence by choosing this option'
set @ParamPrice  = '46.00' 
set @Sale  = '0'	

insert into TempOptionParams (ParamsId,ParamName,ParamTooltip,ParamPrice,TempOptionId,OptionSale)
values (@ParamsId,@ParamName,@ParamTooltip,@ParamPrice,@OptionId,@Sale)	
---------------------------------Params 3-----------------------------------------------
set @ParamsId  = newID()
set @ParamName  = 'Rank 3 essence'
set @ParamTooltip  = 'You will get Rank 3 of the selected essence by choosing this option'
set @ParamPrice  = '119.00' 
set @Sale  = '0'	

insert into TempOptionParams (ParamsId,ParamName,ParamTooltip,ParamPrice,TempOptionId,OptionSale)
values (@ParamsId,@ParamName,@ParamTooltip,@ParamPrice,@OptionId,@Sale)	
---------------------------------Params 4-----------------------------------------------
set @ParamsId  = newID()
set @ParamName  = 'Rank 4 essence'
set @ParamTooltip  = 'You will get Rank 4 of the selected essence by choosing this option'
set @ParamPrice  = '208.00' 
set @Sale  = '0'	

insert into TempOptionParams (ParamsId,ParamName,ParamTooltip,ParamPrice,TempOptionId,OptionSale)
values (@ParamsId,@ParamName,@ParamTooltip,@ParamPrice,@OptionId,@Sale)	

-------------------------------------------rajani----------------------------

 
set @OptionId  = newID()
set @OptionName  =	'Select your current reputation'
set @OptionType  = 'checkbox'
insert into TemplateOptions (TempOptionId,TempOptionName,TempOptionType)
values (@OptionId,@OptionName,@OptionType)
---------------------------------Params 1-----------------------------------------------
set @ParamsId  = newID()
set @ParamName  = 'Neutral'
set @ParamTooltip  = 'Select this if you are currently neutral with this faction'
set @ParamPrice  = '0' 
set @Sale  = '0'	

insert into TempOptionParams (ParamsId,ParamName,ParamTooltip,ParamPrice,TempOptionId,OptionSale)
values (@ParamsId,@ParamName,@ParamTooltip,@ParamPrice,@OptionId,@Sale)	
-------------------------Product fix 2---------------------------------------------
set @OptionId  = newID()
set @OptionName  =	'Select your desired reputation'
set @OptionType  = 'checkbox'

insert into TemplateOptions (TempOptionId,TempOptionName,TempOptionType,TempOptionParamParentId)
values (@OptionId,@OptionName,@OptionType,@ParamsId)
---------------------------------Params 1-----------------------------------------------
set @ParamsId  = newID()
set @ParamName  = 'Revered'
set @ParamPrice  = '49.00' 
set @Sale  = '0'	

insert into TempOptionParams (ParamsId,ParamName,ParamPrice,TempOptionId,OptionSale)
values (@ParamsId,@ParamName,@ParamPrice,@OptionId,@Sale)	
---------------------------------Params 2-----------------------------------------------
set @ParamsId  = newID()
set @ParamName  = 'Exalted'
set @ParamPrice  = '99.00' 
set @Sale  = '0'	

insert into TempOptionParams (ParamsId,ParamName,ParamPrice,TempOptionId,OptionSale)
values (@ParamsId,@ParamName,@ParamPrice,@OptionId,@Sale)








exec Update_db_Version 31