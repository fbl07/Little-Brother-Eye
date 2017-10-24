CREATE TABLE [dbo].[ErrorLog]
(
	[LogId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [StatusCode] INT NULL,
	[Request] VARCHAR(1000) NULL,
	[Text] VARCHAR(1000) NULL, 
    [StackTrace] VARCHAR(MAX) NULL, 
    [TimeOfError] DATETIME NULL
)
