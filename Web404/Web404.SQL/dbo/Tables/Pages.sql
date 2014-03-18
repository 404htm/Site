CREATE TABLE [dbo].[Pages] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [Date]        DATETIME       NOT NULL,
    [Title]       VARCHAR (100)  NULL,
    [URLName]     VARCHAR (100)  NULL,
    [Description] NVARCHAR (MAX) NULL,
    [Summary]     NVARCHAR (MAX) NULL,
    [Content]     NVARCHAR (MAX) NULL,
    [Active]      BIT            NOT NULL,
    CONSTRAINT [PK_Pages_1] PRIMARY KEY CLUSTERED ([ID] ASC)
);

