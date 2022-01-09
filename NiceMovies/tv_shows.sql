CREATE TABLE [dbo].[tv_shows]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NVARCHAR(50) NOT NULL, 
    [Release] SMALLDATETIME NOT NULL, 
    [Score] FLOAT NOT NULL, 
    [NumberOfVotes] INT NOT NULL, 
    [ImageLocation] NVARCHAR(50) NOT NULL
)
