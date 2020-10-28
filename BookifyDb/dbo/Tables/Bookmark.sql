CREATE TABLE [dbo].[Bookmark]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [BookmarkId] INT NOT NULL, 
    [Name] NVARCHAR(150) NOT NULL, 
    [WebAddress] NVARCHAR(250) NOT NULL, 
    [FilePath] NVARCHAR(250) NOT NULL, 
    [Icon] VARCHAR(MAX) NULL, 
    [UserId] INT NOT NULL, 
    CONSTRAINT [FK_Bookmark_User] FOREIGN KEY ([UserId]) REFERENCES [User] (Id) 
)
