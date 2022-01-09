CREATE TABLE [dbo].[casts]
(
	[Id] INT NOT NULL IDENTITY , 
    [movie_id] INT NULL FOREIGN KEY REFERENCES movies(Id), 
    [tvshow_id] INT NULL FOREIGN KEY REFERENCES tv_shows(Id), 
    [actor_id] INT NOT NULL FOREIGN KEY REFERENCES actors(Id), 
    PRIMARY KEY ([Id])
)
