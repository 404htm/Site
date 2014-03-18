CREATE TABLE [dbo].[PageScripts] (
    [PageID]   INT NOT NULL,
    [ScriptID] INT NOT NULL,
    CONSTRAINT [PK_PageScripts] PRIMARY KEY CLUSTERED ([PageID] ASC, [ScriptID] ASC),
    CONSTRAINT [FK_PageScripts_Pages] FOREIGN KEY ([PageID]) REFERENCES [dbo].[Pages] ([ID]),
    CONSTRAINT [FK_PageScripts_Scripts] FOREIGN KEY ([ScriptID]) REFERENCES [dbo].[Scripts] ([ID])
);

