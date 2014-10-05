CREATE TABLE [dbo].[Posts] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [Date]        DATETIME       NOT NULL,
    [Title]       VARCHAR (100)  NULL,
    [URLName]     VARCHAR (100)  NULL,
	[Year]        CHAR(4) NULL,
    [Summary]     NVARCHAR (MAX) NULL,
	[IsMainPage]  Bit NOT NULL,
    [Active]      BIT            NOT NULL,
    [SectionID] INT NULL , 
    CONSTRAINT [PK_Posts_1] PRIMARY KEY CLUSTERED ([ID] ASC), 
    CONSTRAINT [FK_Posts_Section] FOREIGN KEY ([SectionID]) REFERENCES [Sections]([ID]),

);


GO

CREATE UNIQUE INDEX [UX_Posts_Url] ON [dbo].[Posts] ([Year], [URLName])
