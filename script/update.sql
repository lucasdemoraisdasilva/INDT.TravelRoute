UPDATE [INDT.TravelRoute].[dbo].[Routes]
SET [From] = 'GRU',
	[To] = 'BRC',
	[Value] = 10,
	[LastUpdateDate] = GETDATE()
WHERE [Id] = '49B3AFDF-1547-F011-A00D-28F52B23FC66'
