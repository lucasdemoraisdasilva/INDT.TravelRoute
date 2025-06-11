namespace INDT.TravelRoute.Infrastructure.SqlServer.Constants;

internal static class RoutesConstants
{
    public static string InsertQuery =>
        @"INSERT INTO [dbo].[Routes]
                    ([From]
		            ,[To]
		            ,[Value])
              OUTPUT inserted.[Id], 
                     inserted.[From],
                     inserted.[To],
                     inserted.[Value],
                     inserted.[InclusionDate],
                     inserted.[LastUpdateDate]
              VALUES
                    (@From
		            ,@To
		            ,@Value)";

    public static string DeleteQuery =>
        @"DELETE FROM [dbo].[Routes]
                WHERE [Id] = @Id";

    public static string GetByIdQuery =>
        @"SELECT [Id]
            FROM [dbo].[Routes]
           WHERE [Id] = @Id";

    public static string GetAllQuery =>
        @"SELECT [Id]
                ,[From]
                ,[To]
                ,[Value]
                ,[InclusionDate]
                ,[LastUpdateDate]
            FROM [dbo].[Routes]";

    public static string UpdateQuery =>
        @"UPDATE [dbo].[Routes]
             SET [From] = @From,
                 [To] = @To,
                 [Value] = @Value,
                 [LastUpdateDate] = GETDATE()
           WHERE [Id] = @Id";
}
