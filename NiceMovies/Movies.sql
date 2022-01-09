CREATE TABLE [dbo].[movies]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] VARCHAR(50) NOT NULL, 
    [Release] SMALLDATETIME NOT NULL, 
    [Score] FLOAT NOT NULL, 
    [NumberOfVotes] INT NOT NULL, 
    [ImageLocation] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL
)
