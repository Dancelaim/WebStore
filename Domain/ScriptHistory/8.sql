exec Check_db_Version 8

declare @blockId uniqueidentifier = (select SiteBlockId from HtmlBlocks where ParentTitle = 'Professional Gaming Boosting Services')
update HtmlBlocks
set ParentCSSClass = 'who-we-are' , ChildCSSClass = 'purchase_block_in'
where SiteBlockId = @blockId

update HtmlBlocksChildren
set CSSClass = 'purchase_in'
where SiteBlockId = @blockId

exec Update_db_Version 8