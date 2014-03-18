CREATE TABLE [dbo].[Scripts] (
    [ID]      INT           IDENTITY (1, 1) NOT NULL,
    [Name]    VARCHAR (MAX) NULL,
    [Version] INT           CONSTRAINT [DF_Scripts_Version] DEFAULT ((0)) NOT NULL,
    [Date]    DATETIME      NOT NULL,
    [Content] VARCHAR (MAX) NULL,
    [Notes]   VARCHAR (MAX) NULL,
    CONSTRAINT [PK_Scripts] PRIMARY KEY CLUSTERED ([ID] ASC)
);

