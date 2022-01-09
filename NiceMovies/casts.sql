CREATE TABLE [dbo].[casts]
(
	[Id] INT NOT NULL , 
    [movie_id] INT NOT NULL, 
    [tvshow_id] INT NOT NULL, 
    [actor_id] INT NOT NULL, 
    PRIMARY KEY ([Id])
)
