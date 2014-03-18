CREATE TABLE [dbo].[PageStyles] (
    [PageID]  INT NOT NULL,
    [StyleID] INT NOT NULL,
    CONSTRAINT [PK_PageStyles] PRIMARY KEY CLUSTERED ([PageID] ASC, [StyleID] ASC),
    CONSTRAINT [FK_PageStyles_Pages] FOREIGN KEY ([PageID]) REFERENCES [dbo].[Pages] ([ID]),
    CONSTRAINT [FK_PageStyles_Styles] FOREIGN KEY ([StyleID]) REFERENCES [dbo].[Styles] ([ID])
);

