CREATE TABLE [dbo].[PageTags] (
    [PageID] INT NOT NULL,
    [TagID]  INT NOT NULL,
    CONSTRAINT [PK_PageTags] PRIMARY KEY CLUSTERED ([PageID] ASC, [TagID] ASC),
    CONSTRAINT [FK_PageTags_Pages] FOREIGN KEY ([PageID]) REFERENCES [dbo].[Pages] ([ID]),
    CONSTRAINT [FK_PageTags_Tags] FOREIGN KEY ([TagID]) REFERENCES [dbo].[Tags] ([ID])
);

