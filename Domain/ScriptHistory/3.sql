exec Check_db_Version 3

ALTER TABLE HtmlBlocks
ALTER COLUMN ChildCSSClass nvarchar(55)

ALTER TABLE HtmlBlocks
ADD SitePage nvarchar(55)

ALTER TABLE HtmlBlocksChildren
ADD ChildOrder decimal

declare @id uniqueidentifier = newID()

Insert into HtmlBlocks
Values(@id,'purchase_block','How our service works','purchase_block_in','HomePage')

Insert into HtmlBlocksChildren
Values(newid(),@id,'Need more details? Visit this page for more info','','','purchase_in','0')

Insert into HtmlBlocksChildren
Values(newid(),@id,'','1. Find the service you need','','purchase_in','1')

Insert into HtmlBlocksChildren
Values(newid(),@id,'','2. Place the order','','purchase_in','2')

Insert into HtmlBlocksChildren
Values(newid(),@id,'','3. We contact you in 5-10 mins','','purchase_in','3')

Insert into HtmlBlocksChildren
Values(newid(),@id,'','4. Boosting starts','','purchase_in','4')

Insert into HtmlBlocksChildren
Values(newid(),@id,'','5. Feedback','','purchase_in','5')


exec Update_db_Version 3