exec Check_db_Version 16

------------------------------------------CATEGORY NUMBER 1--------------------------------------------------------------------
declare @GameId uniqueidentifier = (select ProductGameId from ProductGame where GameName = 'Path Of Exile')

Insert into ProductCategory(ProductCategoryId,ProductCategoryName,ProductGameId)
Values(newid(),'currency',@GameId)
------------------------------------------CATEGORY NUMBER 2--------------------------------------------------------------------
Insert into ProductCategory(ProductCategoryId,ProductCategoryName,ProductGameId)
Values(newid(),'services',@GameId)
------------------------------------------CATEGORY NUMBER 3--------------------------------------------------------------------
Insert into ProductCategory(ProductCategoryId,ProductCategoryName,ProductGameId)
Values(newid(),'gear',@GameId)
------------------------------------------PRODUCT NUMBER 1--------------------------------------------------------------------
declare @DescrId uniqueidentifier = newID()
declare @ProducID uniqueidentifier = newID()

set @GameID = (select ProductGameId from ProductGame where GameName = 'Path Of Exile')
declare @CatID uniqueidentifier = (select ProductCategoryId from ProductCategory where ProductCategoryName =  'currency' and ProductGameId = @GameID)

declare @ProductName nvarchar(255) = 'EXALTED ORB'
declare @ProductDescription nvarchar(255) = 'Exalted orb is the most popular currency for all ingame trades, with its help you can buy any existing item. It’s all about exalted orbs amount. It is also used to enhance a piece of rare equipment with a new random affix modifier. Exalted orb can be dropped in any location starting on 35 lvl or higher. You can also get it with The Hoarder or from Abandoned Wealth divinition cards stacks. But farm is always boring. Get it easy with WoWCarry!'
declare @TitleDescription1 nvarchar(255) = 'WHAT YOU’LL GET'
declare @TitleDescription2 nvarchar(255) = 'DELIVERY TIME: 15 MINUTES'
declare @TitleDescription3 nvarchar(255) = 'REQUIREMENTS'
declare @EUPrice nvarchar(255) = '0'
declare @USPrice nvarchar(255) = '0'

Insert into ProductDescription(ProductDescriptionId,ProductDescription,TitleDescription1,TitleDescription2,TitleDescription3)
Values(@DescrId,@ProductDescription,@TitleDescription1,@TitleDescription2,@TitleDescription3)

Insert into Product(ProductId,ProductName,ProductCategoryId,InStock,PreOrder,ProductQuantity,ProductDescriptionId,ProductGameId)
Values(@ProducID,@ProductName,@CatID,'1','0','999',@DescrId,@GameID)

Insert into ProductPrice(ProductPriceId,Region,Price,MinPrice,MaxPrice,ProductId)
Values(newid(),'Europe',@EUPrice,'1.51','136.17',@ProducID)

Insert into ProductPrice(ProductPriceId,Region,Price,MinPrice,MaxPrice,ProductId)
Values(newid(),'US&Oceania',@USPrice,'1.70','153.00',@ProducID)
------------------------------------------PRODUCT NUMBER 2--------------------------------------------------------------------
set @DescrId  = newID()
set @ProducID  = newID()

set @GameID = (select ProductGameId from ProductGame where GameName = 'Path Of Exile')
set @CatID = (select ProductCategoryId from ProductCategory where ProductCategoryName = 'services' and ProductGameId = @GameID)

set @ProductDescription = 'With this package you can start maping right after leveling without bothering about farming currency for Tabula Rasa or any other starter gear for your character. It is created for the player, who wants to build his character by his own. You will have all skill points quests completed. All game content will just wait for you to enjoy it. Get it easy with WoWCarry!'
set @TitleDescription1= 'WHAT YOU’LL GET'
set @TitleDescription2 = 'ESTIMATED TIME'
set @TitleDescription3 = 'REQUIREMENTS'
set @ProductName = 'BRONZE EXILE PACKAGE'
set @EUPrice  = '137.94'
set @USPrice  = '154.99'

Insert into ProductDescription(ProductDescriptionId,ProductDescription,TitleDescription1,TitleDescription2,TitleDescription3)
Values(@DescrId,@ProductDescription,@TitleDescription1,@TitleDescription2,@TitleDescription3)

Insert into Product(ProductId,ProductName,ProductCategoryId,InStock,PreOrder,ProductQuantity,ProductDescriptionId,ProductGameId)
Values(@ProducID,@ProductName,@CatID,'1','0','999',@DescrId,@GameID)

Insert into ProductPrice(ProductPriceId,Region,Price,ProductId)
Values(newid(),'Europe',@EUPrice,@ProducID)

Insert into ProductPrice(ProductPriceId,Region,Price,ProductId)
Values(newid(),'US&Oceania',@USPrice,@ProducID)
------------------------------------------PRODUCT NUMBER 2--------------------------------------------------------------------
set @DescrId  = newID()
set @ProducID  = newID()

set @GameID = (select ProductGameId from ProductGame where GameName = 'Path Of Exile')
set @CatID = (select ProductCategoryId from ProductCategory where ProductCategoryName = 'gear' and ProductGameId = @GameID)

set @ProductDescription = 'Wanted to start with archer? You’re in the right place. Buying this pack you will forget about any kind of leveling problems, using any bow ability with tag Bow. Obtained items is pretty enough to smash enemies through all 10 acts with hitting 70 lvl at the end. Get it easy with WoWCarry!'
set @TitleDescription1= 'WHAT YOU’LL GET'
set @TitleDescription2 = 'DELIVERY TIME: 15 MINUTES'
set @TitleDescription3 = 'REQUIREMENTS'
set @ProductName = 'BOW STARTER PACKAGE'
set @EUPrice  = '26.69'
set @USPrice  = '29.99'

Insert into ProductDescription(ProductDescriptionId,ProductDescription,TitleDescription1,TitleDescription2,TitleDescription3)
Values(@DescrId,@ProductDescription,@TitleDescription1,@TitleDescription2,@TitleDescription3)

Insert into Product(ProductId,ProductName,ProductCategoryId,InStock,PreOrder,ProductQuantity,ProductDescriptionId,ProductGameId)
Values(@ProducID,@ProductName,@CatID,'1','0','999',@DescrId,@GameID)

Insert into ProductPrice(ProductPriceId,Region,Price,ProductId)
Values(newid(),'Europe',@EUPrice,@ProducID)

Insert into ProductPrice(ProductPriceId,Region,Price,ProductId)
Values(newid(),'US&Oceania',@USPrice,@ProducID)


exec Update_db_Version 16