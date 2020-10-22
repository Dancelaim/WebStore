exec Check_db_Version 23

GO

CREATE TABLE [dbo].[Realms](
	[RealmId] [uniqueidentifier] NOT NULL,
	[ProductGameId] [uniqueidentifier] NOT NULL,
	[RealmName] [nvarchar](55) NOT NULL,
 CONSTRAINT [PK_Realms] PRIMARY KEY CLUSTERED 
(
	[RealmId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE Realms
ADD FOREIGN KEY (ProductGameId) REFERENCES ProductGame(ProductGameId)


exec Update_db_Version 23