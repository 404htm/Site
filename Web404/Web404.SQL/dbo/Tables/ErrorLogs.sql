CREATE TABLE [dbo].[ErrorLog]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [URL] VARCHAR(MAX) NULL, 
    [Message] VARCHAR(MAX) NULL, 
    [StackTrace] VARCHAR(MAX) NULL, 
    [InnerException] VARCHAR(MAX) NULL, 
    [Description] VARCHAR(MAX) NULL
)
