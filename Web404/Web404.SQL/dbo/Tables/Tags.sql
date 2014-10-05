CREATE TABLE [dbo].[Tags] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (100) NULL,
    [Description] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED ([ID] ASC), 
);

