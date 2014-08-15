/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

MERGE INTO Tags AS Target
USING (VALUES
  (0, N'C#',N''),
  (1, N'd3.js',N''),
  (2, N'MVC',N''),
  (3, N'Javascript',N''),
  (4, N'jQuery',N''),
  (5, N'LINQ',N''),
  (6, N'off-topic',N''),
  (7, N'Metacode',N''),
  (8, N'SQL',N''),
  (9, N'Rant',N''),
  (10, N'Tutorial',N''),
  (11, N'T4',N''),
  (12, N'Azure',N'')
)
AS Source (ID, Name, Description)
ON Target.ID = Source.ID
-- update matched rows
WHEN MATCHED THEN
UPDATE SET Name = Source.Name, Description = Source.Description
-- insert new rows
WHEN NOT MATCHED BY TARGET THEN
INSERT (ID, Name, Description)
VALUES (ID, Name, Description)
-- delete rows that are in the target but not the source
WHEN NOT MATCHED BY SOURCE THEN
DELETE;