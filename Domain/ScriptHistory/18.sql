exec Check_db_Version 18

------------------------------------------Update Product--------------------------------------------------------------------
update Product	
set ProductName = 'Ny’alotha 11/12 Heroic'
where ProductId = '13CF25D1-E2A3-49D4-B8F1-2105A89A4942'

update Product	
set ProductName = 'Ny’alotha 12/12 Heroic'
where ProductId = '84E36A7F-C08B-401D-9C80-C345F8564604'

update Product	
set ProductName = 'N’ZOTH HEROIC KILL'
where ProductId = '9EB71F0D-418B-49A0-8AE6-70BC1BC0266B'


------------------------------------------PRODUCT FIX NUMBER 1--------------------------------------------------------------------
declare @DescrId uniqueidentifier = newID()
declare @Name nvarchar(255) = 'Ny’alotha 11/12 Heroic'
declare @ProductDescription nvarchar(255) = 'Ny’alotha, the Waking City is the very last raid of Battle for Azeroth expansion, composed of a 12 bosses. Warforging or Titanforging does not exist in Ny’alotha, with items instead having a chance of becoming Corrupted - a new affix that grants both positive and negative stats. We care about your account safety, so we don’t offer last boss kill along with other bosses. However, you can purchase safe separate N’zoth boss kill from us. Get unique experience with ordering Ny’alotha, The Waking City from WoWCarry!'
declare @TitleDescription1 nvarchar(255) = 'WHAT YOU’LL GET'
declare @TitleDescription2 nvarchar(255) = 'ESTIMATED TIME: 3 HOURS'
declare @TitleDescription3 nvarchar(255) = 'REQUIREMENTS'

Insert into ProductDescription(ProductDescriptionId,ProductDescription,TitleDescription1,TitleDescription2,TitleDescription3)
Values(@DescrId,@ProductDescription,@TitleDescription1,@TitleDescription2,@TitleDescription3)

update Product
set ProductDescriptionId = @DescrId
where ProductName = @Name

declare @Desc1 nvarchar(255)  = '11/12 HEROIC BOSSES
you will get pro raid team that will complete the 11/12 Ny’alotha, the Waking City raid on Heroic difficulty for you. We care about your account safety, so we offer only 11 bosses
ACHIEVEMENTS
you will get Vision of Destiny and Halls of Devotion achievements
NEW RAID ESSENCE
you will collect Encrypted Ny’alothan Text to have a new 8.3 patch essence: The Formless Void
ALL PERSONAL LOOT ITEMS
you will receive all the personal loot items and gear with 465 ilvl'

declare @Desc2 nvarchar(255)  = 'We have up to 3 raids every day. Please note that it’s always better to check the current schedule with the online support agent to reserve your spot before purchasing. Please, always check with the online support if there are any of your armor type traders left for your run'

declare @Desc3 nvarchar(255)  = ' SELFPLAY
you will need to personally participate in the run. We will not be able to provide our pilot who will log into your account to complete this service. We want to ensure the good standing of your account and "self-play" is the best way to do it
	120 LEVEL CHARACTER
you should have a 120 level character on your account and Ashjra’kamas, Shroud of Resolve'

update ProductDescription	
set Description1 = @Desc1,Description2 = @Desc2, Description3 = @Desc3
where ProductDescriptionId in (select ProductDescriptionId from product where productname = 'Ny’alotha 11/12 Heroic')
------------------------------------------PRODUCT FIX NUMBER 2--------------------------------------------------------------------
set @DescrId  = newID()
set @Name  = 'Ny’alotha 12/12 Heroic'
set @ProductDescription  = 'Ny’alotha, the Waking City is the very last raid of Battle for Azeroth expansion, composed of a 12 bosses. Warforging or Titanforging does not exist in Ny’alotha, with items instead having a chance of becoming Corrupted - a new affix that grants both positive and negative stats. Get an unique experience with ordering Ny’alotha, The Waking City from WoWCarry!'
set @TitleDescription1  = 'WHAT YOU’LL GET'
set @TitleDescription2  = 'ESTIMATED TIME: 3 HOURS'
set @TitleDescription3  = 'REQUIREMENTS'

Insert into ProductDescription(ProductDescriptionId,ProductDescription,TitleDescription1,TitleDescription2,TitleDescription3)
Values(@DescrId,@ProductDescription,@TitleDescription1,@TitleDescription2,@TitleDescription3)

update Product
set ProductDescriptionId = @DescrId
where ProductName = @Name

set @Desc1  = 'PROFESSIONAL TEAM
you will get pro team that will complete the 12/12 Ny’alotha, the Waking City raid on Heroic difficulty for you
ACHIEVEMENT
you will get Ahead of the Curve: N’Zoth the Corruptor achievement
NEW RAID ESSENCE
you will collect Encrypted Ny’alothan Text to have a new 8.3 patch essence: The Formless Void
ALL PERSONAL LOOT ITEMS
you will receive all the personal loot items and gear with 465 ilvl
MOUNT
You will be rewarded with Uncorrupted Voidwing mount for Ahead of the Curve: N’Zoth the Corruptor'

set @Desc2  = 'we have up to 3 raids every day. Please note that it’s always better to check the current schedule with the online support agent to reserve your spot before purchasing. Please, always check with the online support if there are any of your armor type traders left for your run'

set @Desc3  = ' SELFPLAY
you will need to personally participate in the run. We will not be able to provide our pilot who will log into your account to complete this service. We want to ensure the good standing of your account and "self-play" is the best way to do it
120 LEVEL CHARACTER
you must have a 120 level character on your account and Ashjra’kamas, Shroud of Resolve
NO RAID EXPERIENCE REQUIRED
you don’t need to have any specific gear level or knowledge of raid mechanics'

update ProductDescription	
set Description1 = @Desc1,Description2 = @Desc2, Description3 = @Desc3
where ProductDescriptionId in (select ProductDescriptionId from product where productname = 'Ny’alotha 12/12 Heroic')
------------------------------------------PRODUCT FIX NUMBER 3--------------------------------------------------------------------
set @DescrId  = newID()
set @Name  = 'Glacial tide strorm'
set @ProductDescription  = 'Glacial Tidestorm is the most beatifull mount ever created in BFA expansion. Thousands of players are hunting it everyday up to this day. It’s still not that easy to get, because you need to defeat 8 bosses of Battle of Dazar’alor raid, to take a step closer to desired mount, which drops from Mythic: Lady Jaina Proudmoore. We will save your time as we will kill all the bosses up to Jaina in Mythic difficulty. Then we will summon you to the last boss: Mythic: Lady Jaina Proudmoore and you will get the mount upon the kill. Get this unique experience ordering Glacial Tidestorm mount from WoWCarry!'
set @TitleDescription1  = 'WHAT YOU’LL GET'
set @TitleDescription2  = 'ESTIMATED TIME: 1 HOUR'
set @TitleDescription3  = 'REQUIREMENTS'

Insert into ProductDescription(ProductDescriptionId,ProductDescription,TitleDescription1,TitleDescription2,TitleDescription3)
Values(@DescrId,@ProductDescription,@TitleDescription1,@TitleDescription2,@TitleDescription3)

update Product
set ProductDescriptionId = @DescrId
where ProductName = @Name

set @Desc1  = 'UNIQUE MOUNT
you will get Glacial Tidestorm mount as guarantee. After we kill the boss the mount will be traded to you directly
UNIQUE TITLE AND ACHIEVEMENT
you will unlock tittle Hero of Dazar’alor with 10 points achievement Mythic: Lady Jaina Proudmoore
TRANSMOGRIFICATION
you have a chance for personal loot of cool looking transmogrification from Jaina Mythic
PROFESSIONAL RAID TEAM
you will become a part of our pro-raid team that will gladly help you with Mythic: Lady Jaina Proudmoore kill'

set @Desc2  = 'We have up to 3 raids every week. Please note that it’s always better to check the current schedule with the online support agent to reserve your spot before purchasing'

set @Desc3  = 'SELFPLAY
you will need to personally participate in the run. We will not be able to provide our pilot who will log into your account to complete this service. We want to ensure the good standing of your account and "self-play" is the best way to do it
RELATIVE RISK
we strive to provide only safe carry at our website. This service, is new and thus, we cannot predict it’s risk level. However, we want to warn you about the theoretical possibility of monthly penalty for this service'

update ProductDescription	
set Description1 = @Desc1,Description2 = @Desc2, Description3 = @Desc3
where ProductDescriptionId in (select ProductDescriptionId from product where productname = 'Glacial tide strorm')
------------------------------------------PRODUCT FIX NUMBER 4--------------------------------------------------------------------
set @DescrId  = newID()
set @Name  = 'N’ZOTH HEROIC KILL'
set @ProductDescription  = 'N’Zoth the Corruptor is the very last boss of the very last raid of Battle for Azeroth expansion-Ny’alotha, the Waking City, composed of a 12 bosses. During Battle for Azeroth, N’Zoth became a more direct threat to Azeroth’s mortal races, its naga servants becoming more aggressive and spreading its influence to Kul Tiras through the order of the Tidesages. Eventually, thanks in large part to the machinations of Queen Azshara, N’Zoth’s bindings were shattered and the Old God was unleashed upon Azeroth once again. Warforging or Titanforging does not exist in Ny’alotha, with items instead having a chance of becoming Corrupted - a new affix that grants both positive and negative stats. Get an unique experience with ordering N’Zoth, the Corruptor Heroic kill from WoWCarry!'
set @TitleDescription1  = 'WHAT YOU’LL GET'
set @TitleDescription2  = 'ESTIMATED TIME: 1 HOUR'
set @TitleDescription3  = 'REQUIREMENTS'

Insert into ProductDescription(ProductDescriptionId,ProductDescription,TitleDescription1,TitleDescription2,TitleDescription3)
Values(@DescrId,@ProductDescription,@TitleDescription1,@TitleDescription2,@TitleDescription3)

update Product
set ProductDescriptionId = @DescrId
where ProductName = @Name

set @Desc1  = 'PROFESSIONAL TEAM
you will get pro team that will kill N’Zoth, the Corruptor on Heroic difficulty for you
ACHIEVEMENT
you will get Ahead of the Curve: N’Zoth the Corruptor achievement
NEW RAID ESSENCE
you will collect Encrypted Ny’alothan Text to have a new 8.3 patch essence: The Formless Void
ALL PERSONAL LOOT ITEMS
you will receive all the personal loot items and gear with 470 ilvl, wich is 10ilvl higher than first ten bosses loot
MOUNT
You will be rewarded with Uncorrupted Voidwing mount for Ahead of the Curve: N’Zoth the Corruptor'

set @Desc2  = 'We have up to 3 raids every day. Please note that it’s always better to check the current schedule with the online support agent to reserve your spot before purchasing. Please, always check with the online support if there are any of your armor type traders left for your run'

set @Desc3  = ' SELFPLAY
you will need to personally participate in the run. We will not be able to provide our pilot who will log into your account to complete this service. We want to ensure the good standing of your account and "self-play" is the best way to do it
120 LEVEL CHARACTER
you should have a 120 level character on your account and Ashjra’kamas, Shroud of Resolve
NO RAID EXPERIENCE REQUIRED
you don’t need to have any specific gear level or knowledge of raid mechanics'

update ProductDescription	
set Description1 = @Desc1,Description2 = @Desc2, Description3 = @Desc3
where ProductDescriptionId in (select ProductDescriptionId from product where productname = 'N’ZOTH HEROIC KILL')
------------------------------------------PRODUCT FIX NUMBER 5--------------------------------------------------------------------
set @DescrId  = newID()
set @Name  = 'Mythic +15 x3 package'
set @ProductDescription  = 'This package will get you through 3 mythic +15 dungeons of season 4 Battle for Azeroth expansion. You will receive all the tradable gear obtained in the dungeons. So far, it’s considered the fastest way to gear up your character. It also gives you some part of Battle for Azeroth Keystone Master: Season Four achievement in case of choosing unique dungeons and in time options'
set @TitleDescription1  = 'WHAT YOU’LL GET'
set @TitleDescription2  = 'ESTIMATED TIME'
set @TitleDescription3  = 'REQUIREMENTS'

Insert into ProductDescription(ProductDescriptionId,ProductDescription,TitleDescription1,TitleDescription2,TitleDescription3)
Values(@DescrId,@ProductDescription,@TitleDescription1,@TitleDescription2,@TitleDescription3)

update Product
set ProductDescriptionId = @DescrId
where ProductName = @Name

set @Desc1  = 'PROFESSIONAL TEAM
you will get 3 mythic +15 keystone level dungeons with our professional team
ACHIEVEMENT
some part of Battle for Azeroth Keystone Master: Season Four achievement in case of choosing unique dungeons and in time option
UP TO NINE 465ILVL ITEMS
you will receive all the tradable personal loot gear with 465 ilvl and weekly chest with 475 ilvl gear. Learn more about mythic+ drop rate here
INGAME CURRENCY
2150 Titan Residuum in weekly chest (currency to buy azerite pieces from vendor)'

set @Desc2  = 'The average time for invite after the purchase is 15 minutes. Each dungeon itself will take on average 30 minutes and 5 more minutes to get to the next dungeon. Thus, please plan at least 1.5-2 hours for all 3 dungeons. You can do all 3 dungeons at once or you can also split the runs in-between different characters of yours and/or split the runs into several days/weeks'

set @Desc3  = '120 LEVEL CHARACTER
you should have a 120 level character on your account
NO DUNGEON EXPERIENCE REQUIRED
you don’t need to have any specific gear level or knowledge of dungeon mechanics. Our team will also provide the keystones so you are not required to have them. We can also use the one(s) that you have at your own discretion'

update ProductDescription	
set Description1 = @Desc1,Description2 = @Desc2, Description3 = @Desc3
where ProductDescriptionId in (select ProductDescriptionId from product where productname = 'Mythic +15 x3 package')
------------------------------------------PRODUCT FIX NUMBER 6--------------------------------------------------------------------
set @DescrId  = newID()
set @Name  = 'CUSTOM MYTHIC KEY'
set @ProductDescription  = 'This service will get you through desired level of Mythic dungeon keystone of season 4 Battle for Azeroth expansion. Since, mythic+ became the most popular part of the World of Warcraft content, we did our best to improve the service quality for you. You will receive all the tradable gear obtained during the run. Mythic+ is considered to be the fastest way to gear up your character. You can also increase your loot chance by adding traders with your armor type to your run. Don’t forget to select "beating the timer" option to maximize your chance to get three items. Mythic+ becomes much easier with WoWCarry!'
set @TitleDescription1  = 'WHAT YOU’LL GET'
set @TitleDescription2  = 'ESTIMATED TIME: 30 MINUTES'
set @TitleDescription3  = 'REQUIREMENTS'

Insert into ProductDescription(ProductDescriptionId,ProductDescription,TitleDescription1,TitleDescription2,TitleDescription3)
Values(@DescrId,@ProductDescription,@TitleDescription1,@TitleDescription2,@TitleDescription3)

update Product
set ProductDescriptionId = @DescrId
where ProductName = @Name

set @Desc1  = 'DESIRED KEY LVL
mythic+ 10-15 key completed by our professional team
WEEKLY CHEST
460-475ilvl corrupted piece of gear or trinket at the end of the week
UP TO THREE 455-465 GEAR ITEMS
the team will have at least 2 items dropped by the end of the dungeon and 40% chance for an additional item. You will receive all personal loot items as well as all tradable items from our team. Please, note "Beating the timer" option grants you and your team another addtitional item. Learn more about mythic+ drop rate here
1700-2150 TITAN RESIDUUM
you will get currency to buy azerite pieces from vendor, depending on the chosen key lvl'

set @Desc2  = 'The average time for invite after the purchase is 15 minutes. The dungeon itself will take on average 35 minutes. Please note that if you are ordering specific dungeon and/or specify the team armor type composition it can take just a bit longer to get the right team for you. You can check the exact timing by providing your chosen options to our online customer support agent'

set @Desc3  = '120 LEVEL CHARACTER
you should have a 120 level character on your account
NO DUNGEON EXPERIENCE REQUIRED
you don’t need to have any specific gear level or knowledge of dungeon mechanics. Our team will also provide the keystones so you are not required to have one. We can also use the one that you have at your own discretion'

update ProductDescription	
set Description1 = @Desc1,Description2 = @Desc2, Description3 = @Desc3
where ProductDescriptionId in (select ProductDescriptionId from product where productname = 'Custom Mythic key')
------------------------------------------PRODUCT FIX NUMBER 7--------------------------------------------------------------------
set @DescrId  = newID()
set @Name  = 'Weekly Best +15 key 8.3'
set @ProductDescription  = 'Completing +15 key is definitely considered to be the next game skill level. For this service we will provide you one of our best teams. Also, by choosing "Beating the timer" option you will get the great achievement: Keystone Master. Meet the new 8.3 season four affix "Awekened" with WoWCarry!'
set @TitleDescription1  = 'WHAT YOU’LL GET'
set @TitleDescription2  = 'ESTIMATED TIME'
set @TitleDescription3  = 'REQUIREMENTS'

Insert into ProductDescription(ProductDescriptionId,ProductDescription,TitleDescription1,TitleDescription2,TitleDescription3)
Values(@DescrId,@ProductDescription,@TitleDescription1,@TitleDescription2,@TitleDescription3)

update Product
set ProductDescriptionId = @DescrId
where ProductName = @Name

set @Desc1  = 'PROFESSIONAL TEAM
you will get pro team that will complete +15 mythic level dungeon for you, which is weekly best for 4th season
ACHIEVEMENT
you will get Keystone Master achievement, if you haven’t received it yet
ALL PERSONAL LOOT ITEMS
you will receive all tradable personal loot or corrupted gear with 465 ilvl and weekly chest with 475 ilvl gear. Learn more about mythic+ drop rate here
INGAME CURRENCY
2150 Titan Residuum (currency to buy azerite pieces from vendor)'

set @Desc2  = 'The average time for invite after the purchase is 15 minutes. The dungeon itself will take on average 35 minutes. Please note that if you are ordering specific dungeon and/or specify the team armor type composition it can take just a bit longer to get the right team for you. You can check the exact timing by providing your chosen options to our online customer support agent'

set @Desc3  = '120 LEVEL CHARACTER
you should have a 120 level character on your account
NO DUNGEON EXPERIENCE REQUIRED
you don’t need to have any specific gear level or knowledge of dungeon mechanics. Our team will also provide the keystones so you are not required to have one. We can also use the one that you have at your own discretion'

update ProductDescription	
set Description1 = @Desc1,Description2 = @Desc2, Description3 = @Desc3
where ProductDescriptionId in (select ProductDescriptionId from product where productname = 'Weekly Best +15 key 8.3')
------------------------------------------PRODUCT FIX NUMBER 8--------------------------------------------------------------------
set @DescrId  = newID()
set @Name  = 'High mythic+ keys'
set @ProductDescription  = 'We offer this unique service for people who are already highly experienced mythic dungeon players and just need a great team to push high keys together. We will provide you with our top team that regularly qualifies and takes part in the MDI tournament. There is no limit in terms of key level. This service is only for "self-play" so you will personally participate in the runs. Also, there is no "beating the timer" guarantee. We only guarantee great team, company and competitive atmosphere'
set @TitleDescription1  = 'WHAT YOU’LL GET'
set @TitleDescription2  = '30 MINUTES PER DUNGEON'
set @TitleDescription3  = 'REQUIREMENTS'

Insert into ProductDescription(ProductDescriptionId,ProductDescription,TitleDescription1,TitleDescription2,TitleDescription3)
Values(@DescrId,@ProductDescription,@TitleDescription1,@TitleDescription2,@TitleDescription3)

update Product
set ProductDescriptionId = @DescrId
where ProductName = @Name

set @Desc1  = 'PROFESSIONAL TEAM
highest pro-level team that will run dungeons with you for specified amount of time
ALL PERSONAL LOOT ITEMS
you will receive all tradable personal loot, and even corrupted gear with 465 ilvl, and weekly chest with 475 ilvl corrupted gear (hope for not a trinket, which cannot be corrupted)
MYTHIC+ DUNGEONS COACHING
our team will give you a discord channel and explain you all the strats, tricks before dungeon starts
MYTHIC+ RIO SCORE
we always try to get the needed dungeons for you, to raise your rio score'

set @Desc2  = 'You can expect to complete up to 4 dungeons of +19-23 in 2 hours on average. Our top team is available daily for up to 8 hours. We are based in US but very flexible to your schedule. Please, contact the customer support to set up the time for your runs'

set @Desc3  = '120 LEVEL CHARACTER
you should have a 120 level character on your account
NO DUNGEON EXPERIENCE REQUIRED
you don’t need to have any specific gear level or knowledge of dungeon mechanics. Our team will also provide the keystones so you are not required to have one. We can also use the one that you have at your own discretion'

update ProductDescription	
set Description1 = @Desc1,Description2 = @Desc2, Description3 = @Desc3
where ProductDescriptionId in (select ProductDescriptionId from product where productname = 'High mythic+ keys')
------------------------------------------PRODUCT FIX NUMBER 9--------------------------------------------------------------------
set @Desc1  = 'PROFESSIONAL PILOT
you will get professional pilot, who will gladly complete this service for you. You can specify the time-frame when he can play on your account
FEAT OF STRENGHT ACHIEVEMENT
you will get Feat of Strenght achievement - Mad World (won’t be obtainable once the pre-patch goes live)
UNIQUE TITLE
you will get unique and prestige Title ".. the Faceless One" (won’t be obtainable once the pre-patch goes live)
CORRUPTED PIECE OF GEAR GUARANTEE
you will receive one or two gear pieces (depends on selected options) with 470ilvl with a 100% chance to be corrupted
ECHOES OF NY’ALOTHA
you will get 750 of Echoes of Ny’alotha for your character
OTHER ACHIEVEMENTS
you will get The Even More Horrific Vision of Stormwind and/or The Even More Horrific Vision of Orgrimmar'

set @Desc2  = 'Please note that the estimated time depends on the options selected. You can always get more information by contacting our support agent'

set @Desc3  = 'GEAR REQUIREMENTS
you need to have 460+ gear item level and you need to have Ashjra’kamas, Shroud of Resolve level 15 on your character. You can upgrade it to 15 level by Full Horrific Visions Runs
VESSEL OF HORRIFIC VISIONS
to enter the Horrific Vision you will need to have Vessel of Horrific Visions in your intenvoty. If you want both visions of Stormwind and Orgrimmar you need to have two Vessels in your inventory.
5 FACELESS MASKS
you need to have 5 Faceless Masks unlocked for this achievement
ACCOUNT SHARING REQUIRED
this service can only be provided by account sharing. We will only need your login and password and we do NOT need an answer to a secret question or access to your email'

update ProductDescription	
set Description1 = @Desc1,Description2 = @Desc2, Description3 = @Desc3
where ProductDescriptionId in (select ProductDescriptionId from product where productname = 'MAD WORLD ACHIEVEMENT')
------------------------------------------PRODUCT FIX NUMBER 10--------------------------------------------------------------------
set @Desc1  = 'PROFESSIONAL PILOT
professional pilot that will farm the reputation for you (you can specify the time-frame when we can play on your account)
ACHIEVEMENT
you will get The Rajani achievement if you will hit it to exalted 
NEW AZERITE ESSENCES
you will get the opportunity to buy two new azerite essences: Touch of the Everlasting and Spirit of Preservation
DESIRED REPUTATION
guaranteed desired reputation achieved in minimum possible time
TABARD
unique Rajani Tabard with hitting exalted reputation'

set @Desc2  = 'Please note that time to farm depends on selected options. We will farm all the local quests available every 12 hours and will also gain the reputation from all the other available sources to speed up the process. You can always get more specific time estimate by asking the online support. Estimated Delivery Time (no longer than): Neutral to Friendly: 2 days; Friendly to Honored: 4 days; Honored to Revered: 7 days; Revered to Exalted: 14 days'

set @Desc3  = ' 120 LEVEL CHARACTER
you should have a 120 level character on your account
ACCOUNT SHARING REQUIRED
this service can only be provided by account sharing. We will only need your login and password and we do NOT need an answer to a secret question or access to your email'

update ProductDescription	
set Description1 = @Desc1,Description2 = @Desc2, Description3 = @Desc3
where ProductDescriptionId in (select ProductDescriptionId from product where productname = 'RAJANI REPUTATION')
------------------------------------------PRODUCT FIX NUMBER 11--------------------------------------------------------------------
set @Desc1  = 'GUARANTEED MOUNT
Clutch of Ha-li mount in your inventory after we complete the service for you
PROFESSIONAL PILOT
professional pilot will maximize the chance to obtain the mount for you'

set @Desc2  = 'Please note that time to farm depends on current lineup. On average you can expect this mount earlier. You can always get more specific time estimate by asking the online support'

set @Desc3  = '120 LEVEL CHARACTER
you should have a 120 level character on your account
ACCOUNT SHARING REQUIRED
this service can only be provided by account sharing. We will only need your login and password and we do NOT need an answer to a secret question or access to your email'

update ProductDescription	
set Description1 = @Desc1,Description2 = @Desc2, Description3 = @Desc3
where ProductDescriptionId in (select ProductDescriptionId from product where productname = 'CLUTCH OF HA-LI')
------------------------------------------PRODUCT FIX NUMBER 12--------------------------------------------------------------------
set @Desc1  = 'PROFESSIONAL TEAM
you will get professional team that will gladly provide this service for you
ALL PERSONAL LOOT ITEMS
you will get all the personal loot items with 430ilvl obtained during the Mechagon Megadungeon
DESIRED ESSENCE LEVEL
you will get desired level of Vision of Perfection essence'

set @Desc2  = 'please note, time to farm your desired essence rank depends on your current progress'

set @Desc3  = '110 LEVEL CHARACTER
you should have a 110 level character on your account
ACCOUNT SHARING REQUIRED
this service can only be provided by account sharing. We will only need your login and password and we do NOT need an answer to a secret question or access to your email'

update ProductDescription	
set Description1 = @Desc1,Description2 = @Desc2, Description3 = @Desc3
where ProductDescriptionId in (select ProductDescriptionId from product where productname = 'VISION OF PERFECTION ESSENCE')

exec Update_db_Version 18