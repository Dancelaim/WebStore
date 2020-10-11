exec Check_db_Version 15

------------------------------------------CATEGORY NUMBER 1--------------------------------------------------------------------
declare @Id uniqueidentifier = (select ProductGameId from ProductGame where GameName = 'World of Warcraft Classic')

Insert into ProductCategory(ProductCategoryId,ProductCategoryName,ProductGameId)
Values(newid(),'powerleveling',@Id)
------------------------------------------CATEGORY NUMBER 2--------------------------------------------------------------------
Insert into ProductCategory(ProductCategoryId,ProductCategoryName,ProductGameId)
Values(newid(),'reputation',@Id)
------------------------------------------CATEGORY NUMBER 3--------------------------------------------------------------------
Insert into ProductCategory(ProductCategoryId,ProductCategoryName,ProductGameId)
Values(newid(),'profession',@Id)
------------------------------------------CATEGORY NUMBER 4--------------------------------------------------------------------
Insert into ProductCategory(ProductCategoryId,ProductCategoryName,ProductGameId)
Values(newid(),'mounts',@Id)
------------------------------------------CATEGORY NUMBER 5--------------------------------------------------------------------
Insert into ProductCategory(ProductCategoryId,ProductCategoryName,ProductGameId)
Values(newid(),'dungeons',@Id)
------------------------------------------PRODUCT NUMBER 1--------------------------------------------------------------------
declare @DescrId uniqueidentifier = newID()
declare @ProducID uniqueidentifier = newID()

declare @GameID uniqueidentifier = (select ProductGameId from ProductGame where GameName = 'World of Warcraft Classic')
declare @CatID uniqueidentifier = (select ProductCategoryId from ProductCategory where ProductCategoryName =  'powerleveling' and ProductGameId = @GameID)

declare @ProductName nvarchar(255) = 'CHARACTER LEVELING TO 60'
declare @ProductDescription nvarchar(255) = 'We offer the service for those who do not want to waste even a second to get to level 60. Our employees will start boosting your character right after the service is purchased. The boost takes up to 3 weeks. We can boost you using quests and dungeons, depending on your preferences. We also can work at specified time, thus, we can level up your character while you are asleep or at work so that your gaming experience is not anyhow affected'
declare @TitleDescription1 nvarchar(255) = 'WHAT YOU’LL GET'
declare @TitleDescription2 nvarchar(255) = 'ESTIMATED TIME: 1-21 DAYS'
declare @TitleDescription3 nvarchar(255) = 'REQUIREMENTS'
declare @EUPrice nvarchar(255) = '0'
declare @USPrice nvarchar(255) = '0'

Insert into ProductDescription(ProductDescriptionId,ProductDescription,TitleDescription1,TitleDescription2,TitleDescription3)
Values(@DescrId,@ProductDescription,@TitleDescription1,@TitleDescription2,@TitleDescription3)

Insert into Product(ProductId,ProductName,ProductCategoryId,InStock,PreOrder,ProductQuantity,ProductDescriptionId,ProductGameId)
Values(@ProducID,@ProductName,@CatID,'1','0','999',@DescrId,@GameID)

Insert into ProductPrice(ProductPriceId,Region,Price,MinPrice,MaxPrice,ProductId)
Values(newid(),'Europe',@EUPrice,'19.94','1892.97',@ProducID)

Insert into ProductPrice(ProductPriceId,Region,Price,MinPrice,MaxPrice,ProductId)
Values(newid(),'US&Oceania',@USPrice,'22.40','2126.93',@ProducID)
------------------------------------------PRODUCT NUMBER 2--------------------------------------------------------------------
set @DescrId  = newID()
set @ProducID  = newID()

set @GameID = (select ProductGameId from ProductGame where GameName = 'World of Warcraft Classic')
set @CatID = (select ProductCategoryId from ProductCategory where ProductCategoryName = 'reputation' and ProductGameId = @GameID)

set @ProductDescription = 'The Argent Dawn is a neutral organization focused on protecting Azeroth from any agencies that seek to destroy the world, such as the Burning Legion or the Scourge. Argent Dawn reputation will be required for Naxxramas attunement - The Dread Citadel - Naxxramas'
set @TitleDescription1= 'WHAT YOU’LL GET'
set @TitleDescription2 = 'ESTIMATED TIME: 2-10 DAYS'
set @TitleDescription3 = 'REQUIREMENTS'
set @ProductName = 'ARGENT DAWN REPUTATION BOOST'


Insert into ProductDescription(ProductDescriptionId,ProductDescription,TitleDescription1,TitleDescription2,TitleDescription3)
Values(@DescrId,@ProductDescription,@TitleDescription1,@TitleDescription2,@TitleDescription3)

Insert into Product(ProductId,ProductName,ProductCategoryId,InStock,PreOrder,ProductQuantity,ProductDescriptionId,ProductGameId)
Values(@ProducID,@ProductName,@CatID,'1','0','999',@DescrId,@GameID)

Insert into ProductPrice(ProductPriceId,Region,Price,MinPrice,MaxPrice,ProductId)
Values(newid(),'Europe','0','133.49','266.99',@ProducID)

Insert into ProductPrice(ProductPriceId,Region,Price,MinPrice,MaxPrice,ProductId)
Values(newid(),'US&Oceania','0','149.99','299.99',@ProducID)
------------------------------------------PRODUCT NUMBER 3--------------------------------------------------------------------
set @DescrId  = newID()
set @ProducID  = newID()

set @GameID = (select ProductGameId from ProductGame where GameName = 'World of Warcraft Classic')
set @CatID = (select ProductCategoryId from ProductCategory where ProductCategoryName = 'profession' and ProductGameId = @GameID)

set @ProductDescription = 'Alchemists specialize in using herbs and other materials to create consumable elixirs, potions and flasks. These items are heavily used for both PvE and PvP, making Alchemy a great source of utility and income. Alchemists can also perform transmutations, a process of turning materials into other items, such as Transmute: Arcanite, a highly desired end game material. Alchemy is often paired with Herbalism to lessen or eliminate the need to purchase materials off of the Auction House.'
set @TitleDescription1= 'WHAT YOU’LL GET'
set @TitleDescription2 = 'ESTIMATED TIME: 1-7 DAYS'
set @TitleDescription3 = 'REQUIREMENTS'
set @ProductName = 'CLASSIC ALCHEMY 300 SKILL BOOST'
set @EUPrice  = '160.19'
set @USPrice  = '179.99'


Insert into ProductDescription(ProductDescriptionId,ProductDescription,TitleDescription1,TitleDescription2,TitleDescription3)
Values(@DescrId,@ProductDescription,@TitleDescription1,@TitleDescription2,@TitleDescription3)

Insert into Product(ProductId,ProductName,ProductCategoryId,InStock,PreOrder,ProductQuantity,ProductDescriptionId,ProductGameId)
Values(@ProducID,@ProductName,@CatID,'1','0','999',@DescrId,@GameID)

Insert into ProductPrice(ProductPriceId,Region,Price,ProductId)
Values(newid(),'Europe',@EUPrice,@ProducID)

Insert into ProductPrice(ProductPriceId,Region,Price,ProductId)
Values(newid(),'US&Oceania',@USPrice,@ProducID)
------------------------------------------PRODUCT NUMBER 4--------------------------------------------------------------------
set @DescrId  = newID()
set @ProducID  = newID()

set @GameID = (select ProductGameId from ProductGame where GameName = 'World of Warcraft Classic')
set @CatID = (select ProductCategoryId from ProductCategory where ProductCategoryName = 'mounts' and ProductGameId = @GameID)

set @ProductDescription = 'Obtaining Reins of the Winterspring Frostsaber mount is one of the longest, but most rewarding grinds in the game. Only Alliance players can get it. In order to ride it you need to have the Tiger Riding (1) skill. This is the same skill used by elves to ride their normal tigers, so an elf with this skill doesn’t have to train in anything else. But if you are not an elf, you must also gain Exalted status with Darnassus.'
set @TitleDescription1= 'WHAT YOU’LL GET'
set @TitleDescription2 = 'ESTIMATED TIME: 1 MONTH'
set @TitleDescription3 = 'REQUIREMENTS'
set @ProductName = 'WINTERSPRING FROSTSABER MOUNT ALLIANCE ONLY BOOST'
set @EUPrice  = '1334.99'
set @USPrice  = '1499.99'


Insert into ProductDescription(ProductDescriptionId,ProductDescription,TitleDescription1,TitleDescription2,TitleDescription3)
Values(@DescrId,@ProductDescription,@TitleDescription1,@TitleDescription2,@TitleDescription3)

Insert into Product(ProductId,ProductName,ProductCategoryId,InStock,PreOrder,ProductQuantity,ProductDescriptionId,ProductGameId)
Values(@ProducID,@ProductName,@CatID,'1','0','999',@DescrId,@GameID)

Insert into ProductPrice(ProductPriceId,Region,Price,ProductId)
Values(newid(),'Europe',@EUPrice,@ProducID)

Insert into ProductPrice(ProductPriceId,Region,Price,ProductId)
Values(newid(),'US&Oceania',@USPrice,@ProducID)
------------------------------------------PRODUCT NUMBER 5--------------------------------------------------------------------
set @DescrId  = newID()
set @ProducID  = newID()

set @GameID = (select ProductGameId from ProductGame where GameName = 'World of Warcraft Classic')
set @CatID = (select ProductCategoryId from ProductCategory where ProductCategoryName = 'dungeons' and ProductGameId = @GameID)

set @ProductDescription = 'Blackfathom Deeps (BFD) is a partially underwater dungeon in northwestern Ashenvale. There are 8 bosses in this dungeon. You need to be at least level 24 to enter this dungeon'
set @TitleDescription1= 'WHAT YOU’LL GET'
set @TitleDescription2 = 'ESTIMATED TIME'
set @TitleDescription3 = 'REQUIREMENTS'
set @ProductName = 'BLACKFATHOM DEEPS (24-32)'
set @EUPrice  = '61.41'
set @USPrice  = '69.00'


Insert into ProductDescription(ProductDescriptionId,ProductDescription,TitleDescription1,TitleDescription2,TitleDescription3)
Values(@DescrId,@ProductDescription,@TitleDescription1,@TitleDescription2,@TitleDescription3)

Insert into Product(ProductId,ProductName,ProductCategoryId,InStock,PreOrder,ProductQuantity,ProductDescriptionId,ProductGameId)
Values(@ProducID,@ProductName,@CatID,'1','0','999',@DescrId,@GameID)

Insert into ProductPrice(ProductPriceId,Region,Price,ProductId)
Values(newid(),'Europe',@EUPrice,@ProducID)

Insert into ProductPrice(ProductPriceId,Region,Price,ProductId)
Values(newid(),'US&Oceania',@USPrice,@ProducID)

exec Update_db_Version 15