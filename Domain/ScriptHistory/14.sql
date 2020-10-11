exec Check_db_Version 14
------------------------------------------Fix GameId NUMBER 1--------------------------------------------------------------------
declare @BFAID uniqueidentifier = (select ProductGameId from ProductGame where GameName = 'World of Warcraft')

update ProductCategory
set ProductCategoryName = 'essences', ProductGameId = @BFAID
where ProductCategoryId = '02BB8C26-1180-4002-8156-08A42DA0295E'
------------------------------------------Fix GameId  NUMBER 2--------------------------------------------------------------------
update ProductCategory
set ProductCategoryName = 'bundles', ProductGameId = @BFAID
where ProductCategoryId = 'FD0DD254-6E0D-49E1-AAF7-11FFEB0EC172'
------------------------------------------Fix GameId  NUMBER 3--------------------------------------------------------------------
update ProductCategory
set ProductCategoryName = 'dungeons', ProductGameId = @BFAID
where ProductCategoryId = 'CFBC3393-390B-4A7F-93DC-3EBE19AD6EE9'
------------------------------------------Fix GameId  NUMBER 4--------------------------------------------------------------------
update ProductCategory
set ProductCategoryName = 'reputation', ProductGameId = @BFAID
where ProductCategoryId = 'A56C5AA8-5D22-45BF-8AE6-51E082549335'
------------------------------------------Fix GameId  NUMBER 5--------------------------------------------------------------------
update ProductCategory
set ProductCategoryName = 'powerleveling', ProductGameId = @BFAID
where ProductCategoryId = '3C0555DA-8B74-4B85-B88C-415E867CCFC8'
-----------------------------------------Fix GameId  NUMBER 6--------------------------------------------------------------------
update ProductCategory
set ProductCategoryName = 'mounts', ProductGameId = @BFAID
where ProductCategoryId = '30AE1EB3-4F53-4656-9A1C-DA09A3885435'
------------------------------------------Fix GameId  NUMBER 7--------------------------------------------------------------------
update ProductCategory
set ProductCategoryName = 'raid', ProductGameId = @BFAID
where ProductCategoryId = 'A66BB3FE-A98D-4020-8208-E9B5F0436EEC'


------------------------------------------PRODUCT NUMBER 1--------------------------------------------------------------------
declare @DescrId uniqueidentifier = newID()
declare @ProducID uniqueidentifier = newID()

declare @GameID uniqueidentifier = (select ProductGameId from ProductGame where GameName = 'World of Warcraft')
declare @CatID uniqueidentifier = (select ProductCategoryId from ProductCategory where ProductCategoryName = 'mounts')

declare @ProductName nvarchar(255) = 'CLUTCH OF HA-LI'
declare @ProductDescription nvarchar(255) = 'This night-blue bird mount drops from Ha-Li, a rare added to the N’zoth Assault Phase of the Vale of Eternal Blossoms in Patch 8.3. She only appears during Mogu assault weeks (which occur in the west of the zone), not when the Old God assaults occur in the east'
declare @TitleDescription1 nvarchar(255) = 'WHAT YOU’LL GET'
declare @TitleDescription2 nvarchar(255) = 'ESTIMATED TIME: 1 MONTH'
declare @TitleDescription3 nvarchar(255) = 'REQUIREMENTS'
declare @EUPrice nvarchar(255) = '105.91'
declare @USPrice nvarchar(255) = '119.00'

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

set @GameID = (select ProductGameId from ProductGame where GameName = 'World of Warcraft')
set @CatID = (select ProductCategoryId from ProductCategory where ProductCategoryName = 'powerleveling')

set @ProductDescription = 'Mad World is an achievement when very good equipment is not enough, every little thing is important, careful preparation and honed skills. Your character will plunge into the Visions of N’zoth at maximum difficulty with 5 masks and single-handedly clear Stormwind and Orgrimmar from the most dangerous enemies under the influence of the Old God. For the The Mad World achievement, you will be rewarded with the title "The Faceless One", which will become unavailable with the release of Pre-Patch Shadowlands. Our professional pilots will help you get the Mad World achievement as quickly and easily as possible.'
set @TitleDescription1= 'WHAT YOU’LL GET'
set @TitleDescription2 = 'ESTIMATED TIME: 1-2 WEEKS'
set @TitleDescription3 = 'REQUIREMENTS'
set @ProductName = 'MAD WORLD ACHIEVEMENT'


Insert into ProductDescription(ProductDescriptionId,ProductDescription,TitleDescription1,TitleDescription2,TitleDescription3)
Values(@DescrId,@ProductDescription,@TitleDescription1,@TitleDescription2,@TitleDescription3)

Insert into Product(ProductId,ProductName,ProductCategoryId,InStock,PreOrder,ProductQuantity,ProductDescriptionId,ProductGameId)
Values(@ProducID,@ProductName,@CatID,'1','0','999',@DescrId,@GameID)

Insert into ProductPrice(ProductPriceId,Region,Price,MinPrice,MaxPrice,ProductId)
Values(newid(),'Europe','0','22.24','44.48',@ProducID)

Insert into ProductPrice(ProductPriceId,Region,Price,MinPrice,MaxPrice,ProductId)
Values(newid(),'US&Oceania','0','24.99','49.98',@ProducID)

------------------------------------------PRODUCT NUMBER 3--------------------------------------------------------------------
set @DescrId  = newID()
set @ProducID  = newID()

set @GameID = (select ProductGameId from ProductGame where GameName = 'World of Warcraft')
set @CatID = (select ProductCategoryId from ProductCategory where ProductCategoryName = 'reputation')

set @ProductDescription = 'The Rajani are a new Neutral faction arriving in Patch 8.3 of Battle For Azeroth which features unique rewards such as a mount, a pet, and essences to enhance your Heart of Azeroth'
set @TitleDescription1= 'WHAT YOU’LL GET'
set @TitleDescription2 = 'ESTIMATED TIME: UP TO 5 WEEKS'
set @TitleDescription3 = 'REQUIREMENTS'
set @ProductName = 'RAJANI REPUTATION'


Insert into ProductDescription(ProductDescriptionId,ProductDescription,TitleDescription1,TitleDescription2,TitleDescription3)
Values(@DescrId,@ProductDescription,@TitleDescription1,@TitleDescription2,@TitleDescription3)

Insert into Product(ProductId,ProductName,ProductCategoryId,InStock,PreOrder,ProductQuantity,ProductDescriptionId,ProductGameId)
Values(@ProducID,@ProductName,@CatID,'1','0','999',@DescrId,@GameID)

Insert into ProductPrice(ProductPriceId,Region,Price,MinPrice,MaxPrice,ProductId)
Values(newid(),'Europe','0','22.25','88.11',@ProducID)

Insert into ProductPrice(ProductPriceId,Region,Price,MinPrice,MaxPrice,ProductId)
Values(newid(),'US&Oceania','0','25.00','99.00',@ProducID)

------------------------------------------PRODUCT NUMBER 4--------------------------------------------------------------------
set @DescrId  = newID()
set @ProducID  = newID()

set @GameID = (select ProductGameId from ProductGame where GameName = 'World of Warcraft')
set @CatID = (select ProductCategoryId from ProductCategory where ProductCategoryName = 'essences')

set @ProductDescription = 'The Vision of Perfection Essence for your Heart of Azeroth is available to all specializations. This unique essence is obtained via the new mega dungeon Operation: Mechagon. The Major power of this essence is its passive ability: Vision of Perfection. The Minor power of this essence is the passive proc: Strive for Perfection. It’s currently considered the most usefull essence by most classes. Get it easy with WoWCarry!'
set @TitleDescription1= 'WHAT YOU’LL GET'
set @TitleDescription2 = 'ESTIMATED TIME: UP TO 2 DAYS'
set @TitleDescription3 = 'REQUIREMENTS'
set @ProductName = 'VISION OF PERFECTION ESSENCE'


Insert into ProductDescription(ProductDescriptionId,ProductDescription,TitleDescription1,TitleDescription2,TitleDescription3)
Values(@DescrId,@ProductDescription,@TitleDescription1,@TitleDescription2,@TitleDescription3)

Insert into Product(ProductId,ProductName,ProductCategoryId,InStock,PreOrder,ProductQuantity,ProductDescriptionId,ProductGameId)
Values(@ProducID,@ProductName,@CatID,'1','0','999',@DescrId,@GameID)

Insert into ProductPrice(ProductPriceId,Region,Price,MinPrice,MaxPrice,ProductId)
Values(newid(),'Europe','0','21.36','185.12',@ProducID)

Insert into ProductPrice(ProductPriceId,Region,Price,MinPrice,MaxPrice,ProductId)
Values(newid(),'US&Oceania','0','24.00','208.00',@ProducID)

exec Update_db_Version 14