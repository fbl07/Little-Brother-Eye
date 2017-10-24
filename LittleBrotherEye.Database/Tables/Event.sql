CREATE TABLE [dbo].[Event]
(
	[EventId] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Name] VARCHAR(500) NULL, 
    [Character_Cd] INT NULL, 
    [EndTime] DATETIME NULL, 
    [RewardType_Cd] INT NOT NULL, 
    CONSTRAINT [FK_Event_Character_Cd] FOREIGN KEY ([Character_Cd]) REFERENCES [CodeValue]([CodeValue]), 
    CONSTRAINT [FK_Event_RewardType_Cd] FOREIGN KEY ([RewardType_Cd]) REFERENCES [CodeValue]([CodeValue])
)
