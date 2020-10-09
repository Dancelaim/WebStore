exec Check_db_Version 8

update HtmlBlocks
set ParentCSSClass = 'who-we-are' , ChildCSSClass = 'purchase_block_in'
where SiteBlockId = '4DBAD896-75A2-46CB-A9BA-9E1B40915884'

update HtmlBlocksChildren
set CSSClass = 'purchase_in'
where SiteBlockId = '4DBAD896-75A2-46CB-A9BA-9E1B40915884'

exec Update_db_Version 8