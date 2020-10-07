exec Check_db_Version 5

declare @id uniqueidentifier = newID()

Insert into HtmlBlocks(SiteBlockId,ParentCSSClass,ParentTitle,ChildCSSClass,SitePage)
Values(@id,'choose_block','Why choose us','choose_block_in','HomePage')

Insert into HtmlBlocksChildren(SiteBlockChildsId,SiteBlockId,Title,CSSClass,ChildOrder)
Values(newid(),@id,'WE’RE ONLINE 24/7','choose_in','0')

Insert into HtmlBlocksChildren(SiteBlockChildsId,SiteBlockId,Title,CSSClass,ChildOrder)
Values(newid(),@id,'GUARANTEED SECURITY','choose_in','1')

Insert into HtmlBlocksChildren(SiteBlockChildsId,SiteBlockId,Title,CSSClass,ChildOrder)
Values(newid(),@id,'HIGH QUALITY SERVICES','choose_in','2')

Insert into HtmlBlocksChildren(SiteBlockChildsId,SiteBlockId,Title,CSSClass,ChildOrder)
Values(newid(),@id,'PROFESSIONAL TEAM','choose_in','3')

exec Update_db_Version 5