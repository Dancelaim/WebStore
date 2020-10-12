exec Check_db_Version 17

GO
------------------------------------------COLUMS NUMBER 1--------------------------------------------------------------------
Alter Table ProductDescription
Add Description1 nvarchar(MAX)null 
------------------------------------------COLUMS NUMBER 2--------------------------------------------------------------------
Alter Table ProductDescription
Add Description2 nvarchar(MAX)null 
------------------------------------------COLUMS NUMBER 3--------------------------------------------------------------------
Alter Table ProductDescription
Add Description3 nvarchar(MAX)null 
------------------------------------------COLUMS NUMBER 4--------------------------------------------------------------------
Alter Table ProductDescription
Add Description4 nvarchar(MAX)null 
------------------------------------------COLUMS NUMBER 5--------------------------------------------------------------------
Alter Table ProductDescription
Add Description5 nvarchar(MAX)null 
GO
------------------------------------------PRODUCT FIX NUMBER 1--------------------------------------------------------------------
declare @Desc1 nvarchar(255) = 'DESIRED LEVEL 60
you will get desired level 60 right after we complete your order
PROFESSIONAL PILOT
you will get professional pilot that will level up your character. You can specify the time-frame when the pilot can play on your account
ALL PERSONAL LOOT ITEMS
you will receive all the personal loot items, gear and resources obtained during leveling'

declare @Desc2 nvarchar(255) = 'Please note that the start of leveling up your character depends on the current lineup. Time to reach 60 level depends on your current progress. You can always get more specific time estimate by asking the online support'

declare @Desc3 nvarchar(255) = 'ACCOUNT SHARING REQUIRED
this service can only be provided by account sharing. We will only need your login and password and we do NOT need an answer to a secret question or access to your email'

update ProductDescription	
set Description1 = @Desc1,Description2 = @Desc2, Description3 = @Desc3
where ProductDescriptionId in (select ProductDescriptionId from product where productname = 'CHARACTER LEVELING TO 60')
------------------------------------------PRODUCT FIX NUMBER 2--------------------------------------------------------------------
set @Desc1  = 'DESIRED REPUTATION
you will get guaranteed desired reputation achieved in minimum possible time
PROFESSIONAL PILOT
professional pilot that will farm the reputation for you (you can specify the time-frame when we can play on your account)
POWERFUL TRINKET
you will get one of two available powerful trinkets against Undead: Seal of the Dawn or Rune of the Dawn. If you loose your trinket or want to change spec, talk to Betina Bigglezink and turn the quest The Active Agent'

set @Desc2  = 'Please note that time to farm depends on current lineup. We will gain the reputation from all the available sources to speed up the process. You can always get more specific time estimate by asking the online support'

set @Desc3  = ' 60 LEVEL CHARACTER
you should have a 60 level character on your account
ACCOUNT SHARING REQUIRED
this service can only be provided by account sharing. We will only need your login and password and we do NOT need an answer to a secret question or access to your email'

update ProductDescription	
set Description1 = @Desc1,Description2 = @Desc2, Description3 = @Desc3
where ProductDescriptionId in (select ProductDescriptionId from product where productname = 'ARGENT DAWN REPUTATION BOOST')
------------------------------------------PRODUCT FIX NUMBER 3--------------------------------------------------------------------
set @Desc1  = 'PROFESSION SKILL
you will get desired skill level of the profession after we complete the service for you
PROFESSIONAL PILOT
you will get professional pilot that will farm the profession skill for you. You can specify the time-frame when the pilot can play on your account
GOLD
you will get valuable amount of gold earned from selling crafted/geathered items while our pilot will level up your profession'

set @Desc2  = 'The average time for getting your pilot and share the account is about 15 minutes. Time to reach desired skill level of your profession depends on your current progress'

set @Desc3  = 'LEVEL 60 CHARACTER
you should have at least one level 60 character on your account
ACCOUNT SHARING REQUIRED
sthis service can only be provided by account sharing. We will only need your login and password and we do NOT need an answer to a secret question or access to your email'

update ProductDescription	
set Description1 = @Desc1,Description2 = @Desc2, Description3 = @Desc3
where ProductDescriptionId in (select ProductDescriptionId from product where productname = 'CLASSIC ALCHEMY 300 SKILL BOOST')
------------------------------------------PRODUCT FIX NUMBER 4--------------------------------------------------------------------
set @Desc1  = 'GUARANTEED MOUNT
you will get Reins of the Winterspring Frostsaber mount in your inventory after we complete the service for you
100% MOVEMENT SPEED
you will be able to ride your Winterspring Frostsaber mount at 100% movement speed
REPUTATION
you will get Exalted reputation with The Wintersaber Trainers in Winterspring
900 GOLD
we will farm 900 gold for you while doing daily quests. This gold is required to buy the mount from the vendor'

set @Desc2  = 'Please note that time to farm depends on current lineup. You can always get more specific time estimate by asking the online support'

set @Desc3  = '60 LEVEL CHARACTER
you should have at least 60 level character on your account
ALLIANCE PLAYERS ONLY
you can only get this mount if you are night elf, gnome, human, or dwarf
TIGER RIDING SKILL
you either need to be Night Elf or have Exalted status with Darnassus'

update ProductDescription	
set Description1 = @Desc1,Description2 = @Desc2, Description3 = @Desc3
where ProductDescriptionId in (select ProductDescriptionId from product where productname = 'WINTERSPRING FROSTSABER MOUNT ALLIANCE ONLY BOOST')
------------------------------------------PRODUCT FIX NUMBER 5--------------------------------------------------------------------
set @Desc1  = 'ALL THE LOOT
you will receive all the gear dropped during the run as well as all the other loot for your Profession
EXPERIENCE POINTS
you will get a lot of experience points by completing this dungeon. You will get even more points if you take the quests related to this dungeon prior to entering the dungeon. Our team can also help you obtain the necessary quests before we start the run
PROFESSIONAL PILOT
you will get professional pilot that will farm the profession skill for you. You can specify the time-frame when the pilot can play on your account'

set @Desc2  = 'The average time for invite after the purchase is 7 minutes. The dungeon itself will take on average 1 hour. You can check the exact timing for invite by asking our online customer support agent at the button right corner of the website'

set @Desc3  = 'LEVEL 15 CHARACTER
you should have at least level 15 character on your account to be able to enter this dungeon
FOLLOW THE TEAM
this service doesn’t require any specific knowledge of dungeon mechanics. However, we kindly ask you to follow the team as we can use specific trash skips'

update ProductDescription	
set Description1 = @Desc1,Description2 = @Desc2, Description3 = @Desc3
where ProductDescriptionId in (select ProductDescriptionId from product where productname = 'BLACKFATHOM DEEPS (24-32)')

exec Update_db_Version 17