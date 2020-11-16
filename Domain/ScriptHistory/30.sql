Begin Try
    SET NOCOUNT ON
    Set XACT_ABORT ON
Begin Tran
exec Check_db_Version 30
-------------------------Product fix 1---------------------------------------------
declare @OptionId uniqueidentifier = newID()
declare @OptionName nvarchar(50) =	'Faction progress'
declare @OptionType nvarchar(10) = 'Checkbox'
insert into TemplateOptions (TempOptionId,TempOptionName,TempOptionType)
values (@OptionId,@OptionName,@OptionType)
---------------------------------Params 1-----------------------------------------------
declare @ParamsId uniqueidentifier = newID()
declare @ParamName nvarchar(max) = 'Neutral to Exalted'
declare @ParamTooltip nvarchar(max) = 'You will get your reputation boosted from Neutral to Exalted'
declare @ParamPrice decimal(18,2) = '299.99' 
declare @Sale nvarchar = '0'	

insert into TempOptionParams (ParamsId,ParamName,ParamTooltip,ParamPrice,TempOptionId,OptionSale)
values (@ParamsId,@ParamName,@ParamTooltip,@ParamPrice,@OptionId,@Sale)
---------------------------------Params 2-----------------------------------------------
set @ParamsId  = newID()
set @ParamName  = 'Friendly to Exalted'
set @ParamTooltip  = 'You will get your reputation boosted from Friendly to Exalted'
set @ParamPrice  = '279.99'
set @Sale  = '0'	

insert into TempOptionParams (ParamsId,ParamName,ParamTooltip,ParamPrice,TempOptionId,OptionSale)
values (@ParamsId,@ParamName,@ParamTooltip,@ParamPrice,@OptionId,@Sale)
---------------------------------Params 3-----------------------------------------------
set @ParamsId  = newID()
set @ParamName  = 'Honored to Exalted'
set @ParamTooltip  = 'You will get your reputation boosted from Honored to Exalted'
set @ParamPrice  = '239.99'
set @Sale  = '0'	

insert into TempOptionParams (ParamsId,ParamName,ParamTooltip,ParamPrice,TempOptionId,OptionSale)
values (@ParamsId,@ParamName,@ParamTooltip,@ParamPrice,@OptionId,@Sale)

---------------------------------Params 4-----------------------------------------------
set @ParamsId  = newID()
set @ParamName  = 'Revered to Exalted'
set @ParamTooltip  = 'You will get your reputation boosted from Revered to Exalted'
set @ParamPrice  = '149.99'
set @Sale  = '0'	

insert into TempOptionParams (ParamsId,ParamName,ParamTooltip,ParamPrice,TempOptionId,OptionSale)
values (@ParamsId,@ParamName,@ParamTooltip,@ParamPrice,@OptionId,@Sale)
-------------------------Product fix 1---------------------------------------------
set @OptionId  = newID()
set @OptionName  = 'Leveling options'
set @OptionType  = 'Dropdown'

insert into TemplateOptions (TempOptionId,TempOptionName,TempOptionType)
values (@OptionId,@OptionName,@OptionType)
---------------------------------Params 1-----------------------------------------------
set @ParamsId  = newID()
set @ParamName  = '1-60 - 14 days(express)'
set @ParamPrice  = '459' 
set @Sale  = '0'	

insert into TempOptionParams (ParamsId,ParamName,ParamPrice,TempOptionId,OptionSale)
values (@ParamsId,@ParamName,@ParamPrice,@OptionId,@Sale)
---------------------------------Params 2-----------------------------------------------
set @ParamsId  = newID()
set @ParamName  = '1-60 - 21 days'
set @ParamPrice  = '369'
set @Sale  = '0'	

insert into TempOptionParams (ParamsId,ParamName,ParamPrice,TempOptionId,OptionSale)
values (@ParamsId,@ParamName,@ParamPrice,@OptionId,@Sale)
---------------------------------Params 3-----------------------------------------------
set @ParamsId  = newID()
set @ParamName  = '2-60 - 21 days'
set @ParamPrice  = '367' 
set @Sale  = '0'	

insert into TempOptionParams (ParamsId,ParamName,ParamPrice,TempOptionId,OptionSale)
values (@ParamsId,@ParamName,@ParamPrice,@OptionId,@Sale)
---------------------------------Params 4-----------------------------------------------
set @ParamsId  = newID()
set @ParamName  = '3-60 - 21 days'
set @ParamPrice  = '365.40' 
set @Sale  = '0'	

insert into TempOptionParams (ParamsId,ParamName,ParamPrice,TempOptionId,OptionSale)
values (@ParamsId,@ParamName,@ParamPrice,@OptionId,@Sale)
---------------------------------Params 5-----------------------------------------------
set @ParamsId  = newID()
set @ParamName  = '4-60 - 21 days'
set @ParamPrice  = '363' 
set @Sale  = '0'	

insert into TempOptionParams (ParamsId,ParamName,ParamPrice,TempOptionId,OptionSale)
values (@ParamsId,@ParamName,@ParamPrice,@OptionId,@Sale)
-------------------------Product Option 2---------------------------------------------
set @OptionId  = newID()
set @OptionName = 'Additional leveling options'
set @OptionType  = 'Checkbox'

insert into TemplateOptions (TempOptionId,TempOptionName,TempOptionType)
values (@OptionId,@OptionName,@OptionType)

---------------------------------Params 1-----------------------------------------------
set @ParamsId  = newID()
set @ParamName  = '60% speed mount for your race'
set @ParamTooltip  = 'You will get 60% speed mount for your race'
set @ParamPrice  = '99.00' 
set @Sale  = '0'	

insert into TempOptionParams (ParamsId,ParamName,ParamTooltip,ParamPrice,TempOptionId,OptionSale)
values (@ParamsId,@ParamName,@ParamTooltip,@ParamPrice,@OptionId,@Sale)
---------------------------------Params 2-----------------------------------------------
set @ParamsId  = newID()
set @ParamName  = '100% speed Epic mount for your race'
set @ParamTooltip  = 'You will get 100% speed Epic mount for your race'
set @ParamPrice  = '399.00' 
set @Sale  = '0'	

insert into TempOptionParams (ParamsId,ParamName,ParamTooltip,ParamPrice,TempOptionId,OptionSale)
values (@ParamsId,@ParamName,@ParamTooltip,@ParamPrice,@OptionId,@Sale)
---------------------------------Params 3-----------------------------------------------
set @ParamsId  = newID()
set @ParamName  = '1 gathering profession lvl 300'
set @ParamTooltip  = 'You will have either Skinning, Mining or Herbalism leveled to 300 at your choice'
set @ParamPrice  = '84.99' 
set @Sale  = '0'	

insert into TempOptionParams (ParamsId,ParamName,ParamTooltip,ParamPrice,TempOptionId,OptionSale)
values (@ParamsId,@ParamName,@ParamTooltip,@ParamPrice,@OptionId,@Sale)
---------------------------------Params 4-----------------------------------------------
set @ParamsId  = newID()
set @ParamName  = '1 gathering + 1 crafting professions'
set @ParamTooltip  = 'You will have 2 professions lvl 300: one gathering and one crafting at your choice'
set @ParamPrice  = '264.98' 
set @Sale  = '0'	

insert into TempOptionParams (ParamsId,ParamName,ParamTooltip,ParamPrice,TempOptionId,OptionSale)
values (@ParamsId,@ParamName,@ParamTooltip,@ParamPrice,@OptionId,@Sale)
---------------------------------Params 5-----------------------------------------------
set @ParamsId  = newID()
set @ParamName  = 'Full dungeon gear (non-set)'
set @ParamTooltip  = 'You will get full non-set gear from dungeons'
set @ParamPrice  = '169.99' 
set @Sale  = '0'	

insert into TempOptionParams (ParamsId,ParamName,ParamTooltip,ParamPrice,TempOptionId,OptionSale)
values (@ParamsId,@ParamName,@ParamTooltip,@ParamPrice,@OptionId,@Sale)
---------------------------------Params 6-----------------------------------------------
set @ParamsId  = newID()
set @ParamName  = 'Full dungeon gear (fullset 8 pieces)'
set @ParamTooltip  = 'You will get fullset gear from dungeons: all 8 pieces'
set @ParamPrice  = '299.99' 
set @Sale  = '0'	

insert into TempOptionParams (ParamsId,ParamName,ParamTooltip,ParamPrice,TempOptionId,OptionSale)
values (@ParamsId,@ParamName,@ParamTooltip,@ParamPrice,@OptionId,@Sale)
---------------------------------Params 7-----------------------------------------------
set @ParamsId  = newID()
set @ParamName  = 'All weapon skills leveled to 300'
set @ParamTooltip  = 'All possible for your class weapon skills will be leveled to 300'
set @ParamPrice  = '299.99' 
set @Sale  = '0'	

insert into TempOptionParams (ParamsId,ParamName,ParamTooltip,ParamPrice,TempOptionId,OptionSale)
values (@ParamsId,@ParamName,@ParamTooltip,@ParamPrice,@OptionId,@Sale)
---------------------------------Params 8-----------------------------------------------
set @ParamsId  = newID()
set @ParamName  = 'Class quests completed'
set @ParamTooltip  = 'Druid forms, warrior stances, warlock pets, paladin auras or shaman totems unlocked'
set @ParamPrice  = '49.99' 
set @Sale  = '0'	

insert into TempOptionParams (ParamsId,ParamName,ParamTooltip,ParamPrice,TempOptionId,OptionSale)
values (@ParamsId,@ParamName,@ParamTooltip,@ParamPrice,@OptionId,@Sale)
-------------------------Product fix 1---------------------------------------------
set @OptionId  = newID()
set @OptionName  = 'Personal dungeon options'
set @OptionType  = 'Checkbox'

insert into TemplateOptions (TempOptionId,TempOptionName,TempOptionType)
values (@OptionId,@OptionName,@OptionType)
---------------------------------Params 1-----------------------------------------------
set @ParamsId  = newID()
set @ParamName  = 'Piloted'
set @ParamTooltip  = 'We will provide our player who will be playing on your account. We will also provide video-stream so that you can always keep track on all the activities'
set @ParamPrice  = '0' 
set @Sale  = '0'	

insert into TempOptionParams (ParamsId,ParamName,ParamTooltip,ParamPrice,TempOptionId,OptionSale)
values (@ParamsId,@ParamName,@ParamTooltip,@ParamPrice,@OptionId,@Sale)

exec Update_db_Version 30
Commit Tran
End Try
Begin Catch
   RollBack Tran
   Select ERROR_MESSAGE() as Msg, ERROR_NUMBER() as Num
End Catch
