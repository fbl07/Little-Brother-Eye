CREATE TABLE [dbo].[BotConfig]
(
	[ConfigId] INT NOT NULL PRIMARY KEY,
	[AccessToken] VARCHAR(1000) NOT NULL, 
    [Expire] DATETIME NOT NULL
)
