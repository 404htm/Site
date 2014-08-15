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

MERGE INTO Sections AS Target
USING (VALUES
  (0, N'Home'),
  (1, N'About'),
  (2, N'Tools'),
  (3, N'Projects'),
  (4, N'Other')
)
AS Source (ID, Name)
ON Target.ID = Source.ID
-- update matched rows
WHEN MATCHED THEN
UPDATE SET Name = Source.Name
-- insert new rows
WHEN NOT MATCHED BY TARGET THEN
INSERT (ID, Name)
VALUES (ID, Name)
-- delete rows that are in the target but not the source
WHEN NOT MATCHED BY SOURCE THEN
DELETE;