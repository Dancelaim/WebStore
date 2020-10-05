exec Check_db_Version 4

ALTER TABLE ProductGame
ADD GameShortUrl varchar(50);
update ProductGame set GameShortUrl = 'classic' where ProductGameId = '9F9CD017-539E-4220-91C6-343D621E6CE8'
update ProductGame set GameShortUrl = 'destiny' where ProductGameId = '08F84BE4-9827-4D7E-A9D9-6B57F3CDD0A2'
update ProductGame set GameShortUrl = 'poe' where ProductGameId = '41C5FE3E-70EB-4912-B303-AA0A3751D7C9'
update ProductGame set GameShortUrl = 'hs' where ProductGameId = '93D3F1AA-CD77-4B7A-9AFE-C5F44277207B'
update ProductGame set GameShortUrl = 'lol' where ProductGameId = 'AF225302-F24A-46F0-B88A-D040D5FCB69B'
update ProductGame set GameShortUrl = 'valorant' where ProductGameId = '7C12E74A-260E-41C6-8626-E5B0CB82145F'
update ProductGame set GameShortUrl = 'bfa' where ProductGameId = 'D4905029-D10E-46F1-BFC0-F1318DAFB2D2'

update Product set ProductGameId = 'D4905029-D10E-46F1-BFC0-F1318DAFB2D2'
update HtmlBlocks set SitePage = 'HomePage'

exec Update_db_Version 4