CREATE TABLE [dbo].[Tags] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (100) NULL,
    [Description] NVARCHAR (MAX) NULL,
    [HomePageID] INT NULL, 
    CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED ([ID] ASC), 
    CONSTRAINT [FK_Tags_ToTable] FOREIGN KEY ([HomePageID]) REFERENCES [Pages]([ID]) 
);

