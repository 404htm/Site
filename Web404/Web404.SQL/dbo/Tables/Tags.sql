CREATE TABLE [dbo].[Tags] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (100) NULL,
    [Description] NVARCHAR (MAX) NULL,
    [SID] VARCHAR(50) NULL, 
    CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED ([ID] ASC), 
);


GO

CREATE UNIQUE INDEX [IX_Tags_SID] ON [dbo].[Tags] ([SID])
