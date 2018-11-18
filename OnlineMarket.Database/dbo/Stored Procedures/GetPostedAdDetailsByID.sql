CREATE PROCEDURE [dbo].[GetPostedAdDetailsByID]
	@Id INT
AS
BEGIN
	
	SET NOCOUNT ON;


	SELECT 
		[A].[Id], [A].[Name], [A].[Description],
		[B].[Name] AS 'Category', [A].[CategoryID],
		[C].[Name] AS 'Location', [C].[Id] AS 'LocationId',
		[D].[Name] AS 'SellerName', [A].[SellerID],
		[A].[Price], [A].[CreatedDate], [A].[CreatedDateUtc],
		[D].[PhoneNumber], [A].[CoverPhotoId], [A].[PictureCount],
		COUNT(1) OVER() AS 'ActualSize'

	FROM
		[dbo].[Item] A
		JOIN [dbo].[Category] B on A.[CategoryID] = B.[Id]
		JOIN [dbo].[Location] C on A.[LocationID] = [C].[Id] 
		JOIN [dbo].[Seller] D  ON A.[SellerID] = D.[Id]
	WHERE A.[Id] = @Id

	SELECT [ImageId] 
	FROM [dbo].[ItemImages]
	WHERE [ItemId] = @Id

END
