CREATE TABLE [dbo].[Posts] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [Date]        DATETIME       NOT NULL,
	[Active]      BIT            NOT NULL,
	[SID]     VARCHAR (100)  NULL,
	[Partition]        CHAR(4) NULL,
    [Title]       VARCHAR (100)  NULL,
    
    [Summary]     NVARCHAR (MAX) NULL,
    
    [Body] NVARCHAR(MAX) NULL, 
    [PostTypeID] INT NOT NULL DEFAULT 0, 
    CONSTRAINT [PK_Posts_1] PRIMARY KEY CLUSTERED ([ID] ASC), 
    CONSTRAINT [FK_Posts_PostTypeID] FOREIGN KEY ([PostTypeID]) REFERENCES [PostType]([ID]),

);


GO

CREATE UNIQUE INDEX [UX_Posts_Url] ON [dbo].[Posts] ([Partition], [SID])
