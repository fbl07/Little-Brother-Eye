CREATE TABLE [dbo].[CodeValue]
(
    [CodeTableId] INT NOT NULL, 
	[CodeValue] INT NOT NULL , 
    [Description] VARCHAR(250) NULL, 
    [Deleted] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_CodeValue_CodeTable] FOREIGN KEY (CodeTableId) REFERENCES [CodeTable]([CodeTableId]), 
    CONSTRAINT [PK_CodeValue] PRIMARY KEY ([CodeValue])
)
