exec Check_db_Version 19

------------------------------------------PRODUCT FIX NUMBER 1--------------------------------------------------------------------
declare @Desc1 nvarchar(255) = 'EASY LEVELING
all enemies will be one shoted with your spells
LEVELING GEAR
Silverbranch, Quill Rain, Storm Cloud, Doomfletch, The Tempest, Goldrim, Araku Tiki, Karui Ward, Sacrificial Heart, x2 Blackheart, x2 Berek’s Grip, x2 Le Heup of All, Lochtonial Caress, Meginord’s Girdle, Belt of the Deceiver, Prismweave. Wanderlust, Wake of Destruction, Craghead, Hyrri’s Byte, Hyrri’s Demise, Tabula Rasa, Quicksilver Flask, Silver Flask'

declare @Desc2 nvarchar(255) = 'The average time before we trade you all gear is about 15 minutes'

declare @Desc3 nvarchar(255) = 'HEIST SOFTCORE LEAGUE
you should have a character created on Heist Softcore League'


update ProductDescription	
set Description1 = @Desc1,Description2 = @Desc2, Description3 = @Desc3 
where ProductDescriptionId in (select ProductDescriptionId from product where productname = 'BOW STARTER PACKAGE')

update Product
set ProductImage = '\Images\PathOfExile\gear\bow_package.png'
where ProductName  = 'BOW STARTER PACKAGE'
------------------------------------------PRODUCT FIX NUMBER 2--------------------------------------------------------------------
set @Desc1 = '82 CHARACTER LEVEL
you will get 82 character level on your account as soon as possible
ALL SKILL POINTS QUESTS COMPLETED
you will get all skill points from certain quests, you can always check it with the /passives command in the game chat
GUARANTEED CURRENCY
with all contained currency and items during leveling, we will additionaly add 10 Exalted Orbs, 100 Chaos Orbs, 200 Chromatic Orbs, 100 Orbs of Fusing, 50 Orbs of Alchemy and 50 Orbs of Scouring on your character
LABYRINTHS COMPLETION
The Labyrinth, The Cruel Labyrinth and The Merciless Labyrinth completed on your character'

set @Desc2= 'The average time for getting a pilot is about 15 minutes. Leveling by itself will take up to 24 hours. You can always ask pilots availability by contacting our customer support agent'

set @Desc3  = 'LEVEL 1 CHARACTER
you should have at least one level 1 character on your account. We can also create a character for you by ourselves, just give us instructions for that
ACCOUNT SHARING REQUIRED
this service can only be provided by account sharing. We will only need your login and password and we do NOT need an answer to a secret question or access to your email
SOFTCORE LEAGUE
this service can only be provided on Heist softcore league'



update ProductDescription	
set Description1 = @Desc1,Description2 = @Desc2, Description3 = @Desc3 
where ProductDescriptionId in (select ProductDescriptionId from product where productname = 'BRONZE EXILE PACKAGE')

update Product
set ProductImage = '\Images\PathOfExile\services\bronze-exile-package.png'
where ProductName  = 'BRONZE EXILE PACKAGE'
------------------------------------------PRODUCT FIX NUMBER 3--------------------------------------------------------------------
set @Desc1 = 'DESIRED AMOUNT OF EXALTED ORB
you will get as many exalted orbs as you selected in product options
CURRENCY FOR MAJOR TRADES
you can buy rare or unique expensive items with this currency'

set @Desc2= 'The average time before we trade you currency is about 15 minutes'

set @Desc3  = 'HEIST SOFTCORE LEAGUE
you should have a character created on Heist Softcore League to get your currency'



update ProductDescription	
set Description1 = @Desc1,Description2 = @Desc2, Description3 = @Desc3 
where ProductDescriptionId in (select ProductDescriptionId from product where productname = 'EXALTED ORB')

update Product
set ProductImage = '\Images\PathOfExile\currency\exlated_orb.png'
where ProductName  = 'EXALTED ORB'

exec Update_db_Version 19