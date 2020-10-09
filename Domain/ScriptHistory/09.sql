exec Check_db_Version 9

ALTER TABLE HtmlBlocks
ADD [Order] numeric(18, 0)

update HtmlBlocks
set [Order] = 0 
where  ParentTitle = 'Why choose us'
update HtmlBlocks
set [Order] = 1
where  ParentTitle = 'How our service works'
update HtmlBlocks
set [Order] = 2 
where  ParentTitle = 'PROFESSIONAL GAMING BOOSTING SERVICES'

exec Update_db_Version 9