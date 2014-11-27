CREATE VIEW [dbo].[PostSummary]
	AS SELECT p.[ID], [Date], [Active], p.[SID], [Partition], [Title], [Summary], [Body], [PostTypeID],
	STUFF((
		SELECT ', ' + t.Name
			FROM Tags t
			join PostTags pt on pt.PostID = p.ID 
			WHERE pt.TagID = t.ID
			FOR XML PATH('')
	),1, 2, '') AS TagList
from Posts p

