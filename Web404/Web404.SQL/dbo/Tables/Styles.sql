CREATE TABLE [dbo].[Styles] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NULL,
    [Description] NVARCHAR (MAX) NULL,
    [Content]     NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Styles] PRIMARY KEY CLUSTERED ([ID] ASC)
);

