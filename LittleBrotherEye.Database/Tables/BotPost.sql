CREATE TABLE [dbo].[BotPost]
(
	[PostId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CreateTime] DATETIME NOT NULL, 
    [LastUpdateTime] DATETIME NOT NULL, 
    [RedditPostIdentifier] VARCHAR(20) NOT NULL
)
