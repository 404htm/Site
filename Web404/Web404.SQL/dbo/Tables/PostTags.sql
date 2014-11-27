CREATE TABLE [dbo].[PostTags] (
    [PostID] INT NOT NULL,
    [TagID]  INT NOT NULL,
    CONSTRAINT [PK_PageTags] PRIMARY KEY CLUSTERED ([PostID] ASC, [TagID] ASC),
    CONSTRAINT [FK_PageTags_Posts] FOREIGN KEY ([PostID]) REFERENCES [dbo].[Posts] ([ID]),
    CONSTRAINT [FK_PageTags_Tags] FOREIGN KEY ([TagID]) REFERENCES [dbo].[Tags] ([ID])
);

