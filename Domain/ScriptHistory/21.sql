exec Check_db_Version 21


------------------------------------------CEO FIX NUMBER 1--------------------------------------------------------------------
declare @CEOId uniqueidentifier = newID()

insert into ProductCEO (ProductCEOId,MetaTagTitle,MetaTagDescription,MetaTagKeyWords,ProductTags,MetaRobots,UrlKeyWord)
values (@CEOId,'Buy US Glacial Tidestorm in World of Warcraft | WowCarry.com',
'Here you can buy US Glacial Tidestorm mount. Wowcarry professional pilot will maximize the chance to obtain the mount for you.',
'US glacial tidestorm, buy glacial tidestorm, buy wow glacial tidestorm, wow glacial tidestorm service, cheap glacial tidestorm carry',
'US Glacial Tidestorm, Raid, WoW, World of Warcraft, Best WoW Service',
'index,follow',
'buy-wow-glacial-tidestorm-mount')

update Product 
set ProductCEOId = @CEOId
where ProductName = 'Glacial tide strorm'
------------------------------------------CEO FIX NUMBER 2--------------------------------------------------------------------
set @CEOId  = newID()

insert into ProductCEO (ProductCEOId,MetaTagTitle,MetaTagDescription,UrlKeyWord,CustomTitle1)
values (@CEOId,
'Argent Dawn - Classic WoW Reputation Farming | WowCarry',
'Buying Argent Dawn at WowCarry you will get the desired result in a short time. Most popular and custom Classic WoW Farming. WoW Reputation Farm will be done by hands without using any soft.',
'argent-dawn-classic',
'ARGENT DAWN REPUTATION BOOST')

update Product 
set ProductCEOId = @CEOId
where ProductName = 'ARGENT DAWN REPUTATION BOOST'
------------------------------------------CEO FIX NUMBER 3	--------------------------------------------------------------------
set @CEOId  = newID()

insert into ProductCEO (ProductCEOId,MetaTagTitle,MetaTagDescription,UrlKeyWord,CustomTitle1,ProductTags)
values (@CEOId,
'Buy Character Leveling to 60 in World of Warcraft | WowCarry.com',
'We will help you with Character Leveling 1 to 60 for your WoW character. We offer the service for those who do not want to waste even a second to get to level 60.',
'buy-wow-character-leveling-to-60',
'CHARACTER LEVELING TO 60',
'Character Leveling 1 to 60, Farm&Leveling, WoW, World of Warcraft, Best WoW Service')

update Product 
set ProductCEOId = @CEOId
where ProductName = 'CHARACTER LEVELING TO 60'
------------------------------------------CEO FIX NUMBER 4	--------------------------------------------------------------------
set @CEOId  = newID()

insert into ProductCEO (ProductCEOId,MetaTagTitle,MetaTagDescription,UrlKeyWord,CustomTitle1,ProductTags)
values (@CEOId,
'Blackfathom Deeps - Vanilla Dungeon Boost | WowCarry',
'Here you can buy Blackfathom Deeps boost. Most popular and custom WoW Classic PvE services. Dungeon Boosting Wow Classic boost will be done by hands without using any soft. Any questions and help from support in discord chat 24/7.',
'buy-wow-blackfathom-deeps-24-32',
'BLACKFATHOM DEEPS (24-32)',
'Blackfathom Deeps (24-32), Dungeons, WoW, World of Warcraft, Best WoW Service')

update Product 
set ProductCEOId = @CEOId
where ProductName = 'BLACKFATHOM DEEPS (24-32)'
------------------------------------------CEO FIX NUMBER 5	--------------------------------------------------------------------
set @CEOId  = newID()

insert into ProductCEO (ProductCEOId,MetaTagTitle,MetaTagDescription,UrlKeyWord,CustomTitle1)
values (@CEOId,
'Winterspring Frostsaber - Vanilla WoW Mounts | WowCarry',
'Buying Winterspring Frostsaber at WowCarry you will get the desired result in a short time. Most popular and custom WoW Classic Mounts. WoW Classic Mounts boost will be done by hands without using any soft.',
'buy-winterspring-frostsaber-mount-wow-classic',
'WINTERSPRING FROSTSABER MOUNT (ALLIANCE ONLY) BOOST')

update Product 
set ProductCEOId = @CEOId
where ProductName = 'WINTERSPRING FROSTSABER MOUNT ALLIANCE ONLY BOOST'
------------------------------------------CEO FIX NUMBER 6	--------------------------------------------------------------------
set @CEOId  = newID()

insert into ProductCEO (ProductCEOId,MetaTagTitle,MetaTagDescription,UrlKeyWord,CustomTitle1)
values (@CEOId,
'Alchemy - WoW Classic Professions Leveling | WowCarry',
'Buying Alchemy at WowCarry you will get the desired result in a short time. Most popular and custom World of Warcraft Classic Powerleveling. WoW Classic Professions Leveling boost will be done by hands without using any soft.',
'alchemy-classic-wow',
'CLASSIC ALCHEMY 300 SKILL BOOST')

update Product 
set ProductCEOId = @CEOId
where ProductName = 'CLASSIC ALCHEMY 300 SKILL BOOST'
------------------------------------------CEO FIX NUMBER 7	--------------------------------------------------------------------
set @CEOId  = newID()

insert into ProductCEO (ProductCEOId,MetaTagTitle,MetaTagDescription,UrlKeyWord,CustomTitle1)
values (@CEOId,
'Exalted Orb — Buy PoE Currency | WowCarry',
'Here you can buy Exalted Orb boost. Most popular and custom PoE Currency. The average time before we trade you currency is about 15 minutes. Any questions and help from support in discord chat 24/7.',
'exalted-orb',
'EXALTED ORB')

update Product 
set ProductCEOId = @CEOId
where ProductName = 'EXALTED ORB'
------------------------------------------CEO FIX NUMBER 8	--------------------------------------------------------------------
set @CEOId  = newID()

insert into ProductCEO (ProductCEOId,MetaTagTitle,MetaTagDescription,UrlKeyWord,CustomTitle1)
values (@CEOId,
'Bronze Exile Package — PoE Boost Services | WowCarry',
'Here you can buy Bronze Exile Package. Most popular and cheapest PoE Services. The average time before we trade you currency is about 15 minutes. Any questions and help from support in discord chat 24/7.',
'buy-poe-bronze-exile-package',
'BRONZE EXILE PACKAGE')

update Product 
set ProductCEOId = @CEOId
where ProductName = 'BRONZE EXILE PACKAGE'
------------------------------------------CEO FIX NUMBER 9	--------------------------------------------------------------------
set @CEOId  = newID()

insert into ProductCEO (ProductCEOId,MetaTagTitle,MetaTagDescription,UrlKeyWord,CustomTitle1)
values (@CEOId,
'Bow Starter Package — PoE Boost Services | WowCarry',
'Here you can buy Bow Starter Package. Most popular and cheapest PoE Services. The average time before we trade you currency is about 15 minutes. Any questions and help from support in discord chat 24/7.',
'bow-starter-package',
'BOW STARTER PACKAGE')

update Product 
set ProductCEOId = @CEOId
where ProductName = 'BOW STARTER PACKAGE'
------------------------------------------CEO FIX NUMBER 10	--------------------------------------------------------------------
set @CEOId  = newID()

insert into ProductCEO (ProductCEOId,MetaTagTitle,MetaTagDescription,UrlKeyWord,CustomTitle1,ProductTags)
values (@CEOId,
'Buy Vision of Perfection Essence in World of Warcraft | WowCarry.com',
'We will help you with Vision of Perfection Essence for your WoW character. The Vision of Perfection Essence for your Heart of Azeroth is available to all specializations.',
'buy-wow-vision-of-perfection-essence',
'VISION OF PERFECTION ESSENCE',
'Vision of Perfection Essence, Essences, WoW, World of Warcraft, Best WoW Service')

update Product 
set ProductCEOId = @CEOId
where ProductName = 'VISION OF PERFECTION ESSENCE'
------------------------------------------CEO FIX NUMBER 11	--------------------------------------------------------------------
set @CEOId  = newID()

insert into ProductCEO (ProductCEOId,MetaTagTitle,MetaTagDescription,UrlKeyWord,CustomTitle1,ProductTags)
values (@CEOId,
'Buy Rajani Reputation in World of Warcraft | WowCarry.com',
'We will help you with Rajani Reputation for your WoW character. The&amp;nbsp;Rajani&amp;nbsp;are a new&amp;nbsp;Neutral&amp;nbsp;faction arriving in Patch 8.',
'buy-wow-rajani-reputation',
'RAJANI REPUTATION',
'Rajani Reputation, Reputation, WoW, World of Warcraft, Best WoW Service')

update Product 
set ProductCEOId = @CEOId
where ProductName = 'RAJANI REPUTATION'
------------------------------------------CEO FIX NUMBER 12	--------------------------------------------------------------------
set @CEOId  = newID()

insert into ProductCEO (ProductCEOId,MetaTagTitle,MetaTagDescription,UrlKeyWord,CustomTitle1,ProductTags)
values (@CEOId,
'Buy Clutch of Ha-Li in World of Warcraft | WowCarry.com',
'We will help you with Clutch of Ha-Li for your WoW character. This night-blue bird mount drops from Ha-Li, a rare added to the N’zoth Assault Phase of the Vale of Eternal Blossoms in Patch 8.',
'buy-wow-clutch-of-ha-li',
'CLUTCH OF HA-LI',
'Clutch of Ha-Li, Mounts, WoW, World of Warcraft, Best WoW Service')

update Product 
set ProductCEOId = @CEOId
where ProductName = 'CLUTCH OF HA-LI'
------------------------------------------CEO FIX NUMBER 13	--------------------------------------------------------------------
set @CEOId  = newID()

insert into ProductCEO (ProductCEOId,MetaTagTitle,MetaTagDescription,UrlKeyWord,CustomTitle1,ProductTags)
values (@CEOId,
'EU Ny’alotha 11/12 Heroic in World of Warcraft | WowCarry.com',
'We will help you with EU Ny’alotha Full Heroic for your WoW character. Ny’alotha, The Waking City is the very last raid of Battle for Azeroth expansion, composed of a 12 bosses.',
'buy-wow-nyalotha-heroic-11-bosses',
'NY’ALOTHA 11/12 HEROIC',
'Ny’alotha Full Heroic, Raid, WoW, World of Warcraft, Best WoW Service')

update Product 
set ProductCEOId = @CEOId
where ProductName = 'Ny’alotha 11/12 Heroic'
------------------------------------------CEO FIX NUMBER 14	--------------------------------------------------------------------
set @CEOId  = newID()

insert into ProductCEO (ProductCEOId,MetaTagTitle,MetaTagDescription,UrlKeyWord,CustomTitle1,ProductTags)
values (@CEOId,
'EU Ny’alotha Full Heroic in World of Warcraft | WowCarry.com',
'We will help you with EU Ny’alotha Full Heroic for your WoW character. Ny’alotha, The Waking City is the very last raid of Battle for Azeroth expansion, composed of a 12 bosses.',
'buy-wow-nyalotha-full-heroic',
'NY’ALOTHA 12/12 HEROIC',
'Ny’alotha Full Heroic, Raid, WoW, World of Warcraft, Best WoW Service')

update Product 
set ProductCEOId = @CEOId
where ProductName = 'Ny’alotha 12/12 Heroic'
------------------------------------------CEO FIX NUMBER 15	--------------------------------------------------------------------
set @CEOId  = newID()

insert into ProductCEO (ProductCEOId,MetaTagTitle,MetaTagDescription,UrlKeyWord,CustomTitle1,ProductTags)
values (@CEOId,
'Buy EU N’Zoth Heroic Kill in World of Warcraft | WowCarry.com',
'We will help you with EU N’Zoth Heroic Kill for your WoW character. N’Zoth, the Corruptor&amp;nbsp;is the very last boss of the very last raid of Battle for Azeroth expansion-Ny’alotha, the Waking City, composed of a 12 bosses.',
'buy-wow-nzoth-heroic-kill-eu',
'N’ZOTH HEROIC KILL',
'EU N’Zoth Heroic Kill, Raid, WoW, World of Warcraft, Best WoW Service')

update Product 
set ProductCEOId = @CEOId
where ProductName = 'N’ZOTH HEROIC KILL'
------------------------------------------CEO FIX NUMBER 16	--------------------------------------------------------------------
set @CEOId  = newID()

insert into ProductCEO (ProductCEOId,MetaTagTitle,MetaTagDescription,UrlKeyWord,CustomTitle1)
values (@CEOId,
'Buy Mad World Achievement in World of Warcraft | WowCarry.com',
'Here you can buy Mad World Achievement mount. Wowcarry professional pilot will maximize the chance to obtain the mount for you.',
'mad-world-achievement',
'MAD WORLD ACHIEVEMENT')

update Product 
set ProductCEOId = @CEOId
where ProductName = 'MAD WORLD ACHIEVEMENT'
------------------------------------------CEO FIX NUMBER 17	--------------------------------------------------------------------
set @CEOId  = newID()

insert into ProductCEO (ProductCEOId,MetaTagTitle,MetaTagDescription,UrlKeyWord,CustomTitle1,ProductTags)
values (@CEOId,
'Buy EU Weekly Best +15 Key 8.3 in World of Warcraft | WowCarry.com',
'We will help you with Weekly Best +15 Key 8.3 for your WoW character. Completing +15 key is definitely considered to be the next game skill level.',
'buy-wow-weekly-best-15-key',
'EU WEEKLY BEST +15 KEY 8.3',
'Weekly Best +15 Key 8.3, Dungeons, WoW, World of Warcraft, Best WoW Service')

update Product 
set ProductCEOId = @CEOId
where ProductName = 'Weekly Best +15 key 8.3'
------------------------------------------CEO FIX NUMBER 18	--------------------------------------------------------------------
set @CEOId  = newID()

insert into ProductCEO (ProductCEOId,MetaTagTitle,MetaTagDescription,UrlKeyWord,CustomTitle1,ProductTags)
values (@CEOId,
'Buy EU Mythic +15 X3 Package 8.3 in World of Warcraft | WowCarry.com',
'We will help you with Mythic +15 x3 package 8.3 for your WoW character. This package will get you through 3 mythic +15 dungeons of season 4 Battle for Azeroth expansion.',
'buy-wow-mythic-15-x3-package',
'EU MYTHIC +15 X3 PACKAGE',
'Mythic +15 x3 package 8.3, Dungeons, WoW, World of Warcraft, Best WoW Service')

update Product 
set ProductCEOId = @CEOId
where ProductName = 'Mythic +15 x3 package'
------------------------------------------CEO FIX NUMBER 19	--------------------------------------------------------------------
set @CEOId  = newID()

insert into ProductCEO (ProductCEOId,MetaTagTitle,MetaTagDescription,UrlKeyWord,CustomTitle1,ProductTags)
values (@CEOId,
'Buy EU Mythic Key Custom in World of Warcraft | WowCarry.com',
'We will help you with Mythic Key Custom for your WoW character. You can fully customize your mythic+ experience using this service.',
'buy-wow-mythic-key-custom',
'EU CUSTOM MYTHIC KEY',
'Mythic Key Custom, Dungeons, WoW, World of Warcraft, Best WoW Service')

update Product 
set ProductCEOId = @CEOId
where ProductName = 'Custom Mythic key'
------------------------------------------CEO FIX NUMBER 20 --------------------------------------------------------------------
set @CEOId  = newID()

insert into ProductCEO (ProductCEOId,MetaTagTitle,MetaTagDescription,UrlKeyWord,CustomTitle1,ProductTags)
values (@CEOId,
'Buy EU High Mythic+ Keys in World of Warcraft | WowCarry.com',
'We will help you with High Mythic+ Keys for your WoW character. We offer this unique service for people who are already highly experienced mythic dungeon players and just need a great team to push high keys together.',
'buy-wow-high-mythic-keys',
'HIGH MYTHIC+ KEYS',
'High Mythic+ Keys, Dungeons, WoW, World of Warcraft, Best WoW Service')

update Product 
set ProductCEOId = @CEOId
where ProductName = 'High mythic+ keys'

exec Update_db_Version 21