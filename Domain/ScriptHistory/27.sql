exec Check_db_Version 27

EXEC sp_rename 'FK__HtmlBlock__SiteB__3E1D39E1', 'FK__HtmlBlocksChildren_HtmlBlocks', 'OBJECT'
EXEC sp_rename 'FK__OptionPar__Produ__4D5F7D71', 'FK__OptionParams__ProductOption', 'OBJECT'
EXEC sp_rename 'FK__Product__Product__29221CFB', 'FK__Product__ProductGame', 'OBJECT'
EXEC sp_rename 'FK__Product__Product__2A164134', 'FK__Product__ProductSubCategory', 'OBJECT'
EXEC sp_rename 'FK__Product__Product__65370702', 'FK__Product__SEO', 'OBJECT'
EXEC sp_rename 'FK__Product__Product__6FE99F9F', 'FK__Product__ProductDescription', 'OBJECT'
EXEC sp_rename 'FK__ProductCa__Categ__69FBBC1F','FK__ProductCategory__SEO','OBJECT'
EXEC sp_rename 'FK__ProductCa__Produ__2B0A656D','FK__ProductCategory__ProductSubCategory','OBJECT'
EXEC sp_rename 'FK__ProductGa__GameS__690797E6','FK__ProductGame__SEO','OBJECT'
EXEC sp_rename 'FK__ProductOp__Optio__540C7B00','FK__ProductOption__OptionParams','OBJECT'
EXEC sp_rename 'FK__ProductSu__SubCa__6AEFE058','FK__ProductSubCategory','OBJECT'
EXEC sp_rename 'FK__ProductTo__Optio__6166761E','FK__ProductToOption__ProductOption','OBJECT'
EXEC sp_rename 'FK__ProductTo__Produ__681373AD','FK__ProductToOption__Product','OBJECT'
EXEC sp_rename 'FK__Realms__ProductG__51300E55','FK__Realms__ProductGame','OBJECT'
EXEC sp_rename 'FK__TempOptio__TempO__7755B73D','FK__TempOptionParams__TemplateOptions','OBJECT'

exec Update_db_Version 27