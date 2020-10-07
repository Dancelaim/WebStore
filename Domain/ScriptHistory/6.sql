exec Check_db_Version 6

declare @id uniqueidentifier = newID()

Insert into HtmlBlocks(SiteBlockId,ParentTitle,SitePage)
Values(@id,'PROFESSIONAL GAMING BOOSTING SERVICES','HomePage')

Insert into HtmlBlocksChildren(SiteBlockChildsId,SiteBlockId,Text,Title,ChildOrder)
Values(newid(),@id,'WowCarry.com is a place where online video game players can get various services aimed at improving their in-game progress. We are sharing our gaming knowledge, experience and advances to help players from all over the world obtain the hardest in-game achievements, titles and ratings. We are a company that unites casual players and professional gamers!','WHO WE ARE','0')

Insert into HtmlBlocksChildren(SiteBlockChildsId,SiteBlockId,Text,Title,ChildOrder)
Values(newid(),@id,'Our boosting teams are the best players from all over the world struggling to provide our customers with the most flexible service, adapted for customer’s needs, schedule and lead time with best care possible. We believe that our customer’s interests must always come first.','OUR TEAM','1')

Insert into HtmlBlocksChildren(SiteBlockChildsId,SiteBlockId,Text,Title,ChildOrder)
Values(newid(),@id,'We’ve successfully completed more than 80000 carries by now including even most difficult tasks with special conditions and exclusive terms.','80,000 SUCCESSFUL ORDERS','2')

Insert into HtmlBlocksChildren(SiteBlockChildsId,SiteBlockId,Text,Title,ChildOrder)
Values(newid(),@id,'We’re an officially registered company with 11 years of experience on the market and verified Business Paypal account with thousands of successful transactions.','11 YEARS ON THE MARKET','3')

exec Update_db_Version 6