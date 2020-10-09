exec Check_db_Version 2

GO

CREATE TABLE [dbo].[HtmlBlocks](
	[SiteBlockId] [uniqueidentifier] NOT NULL,
	[ParentCSSClass] [nvarchar](50) NULL,
	[ParentTitle] [nvarchar](55) NULL,
	[ChildCSSClass] [nchar](10) NULL,
 CONSTRAINT [PK_HtmlBlocks] PRIMARY KEY CLUSTERED 
(
	[SiteBlockId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[HtmlBlocksChildren](
	[SiteBlockChildsId] [uniqueidentifier] NOT NULL,
	[SiteBlockId] [uniqueidentifier] NOT NULL,
	[Text] [nvarchar](max) NULL,
	[Title] [nvarchar](255) NULL,
	[Image] [nvarchar](255) NULL,
	[CSSClass] [nvarchar](50) NULL,
 CONSTRAINT [PK_HtmlBlocksChildren] PRIMARY KEY CLUSTERED 
(
	[SiteBlockChildsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[HtmlBlocksChildren]  WITH CHECK ADD FOREIGN KEY([SiteBlockId])
REFERENCES [dbo].[HtmlBlocks] ([SiteBlockId])
GO

exec Update_db_Version 2