CREATE TABLE [dbo].[EditHistory]
(
	[HistoryId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [EventId] INT NOT NULL, 
    [EditDate] DATETIME NOT NULL, 
    [NewName] VARCHAR(500) NULL, 
    [IpAdress] VARCHAR(50) NULL, 
    CONSTRAINT [FK_EditHistory_Event] FOREIGN KEY ([EventId]) REFERENCES [Event]([EventId])
)
