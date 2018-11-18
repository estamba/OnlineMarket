
CREATE PROCEDURE [dbo].[SearchPostedAd]
	@Title NVARCHAR(100) = NULL,
	@CategoryId INT = NULL,
	@LocationId INT = NULL,
	@StartPrice DECIMAL(18,2) = NULL,
	@EndPrice DECIMAL(18, 2) = NULL,
	@StartDate DATE = NULL,
	@SortBy VARCHAR(20) = 'date',
	@SortDir VARCHAR(4) = 'desc',
	@EndDate DATE = NULL,
	@PageIndex INT = 0,
	@PageSize INT = 10
AS
BEGIN

	SET NOCOUNT ON;

	/* Get subcategory list */
	DECLARE @SubCategories TABLE ( [Id] INT, [Name] NVARCHAR(50))
	IF @CategoryId IS NULL 
	BEGIN
		INSERT INTO @SubCategories ([Id], [Name]) SELECT [Id], [Name] FROM dbo.Category
	END
	ELSE
	BEGIN
		
		WITH CTE_SubCategories AS 
		(
			SELECT A.[Id], A.[ParentId], A.[Name] FROM [dbo].[Category] A WHERE [Id] = @CategoryId
			UNION ALL
			SELECT A.[Id], A.[ParentId], A.[Name] FROM [dbo].[Category] A JOIN CTE_SubCategories B ON A.[ParentId] = B.[Id]
		)
		INSERT INTO @SubCategories ([Id], [Name]) SELECT [Id], [Name] FROM CTE_SubCategories
	END

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
		JOIN @SubCategories B on A.[CategoryID] = B.[Id]
		JOIN [dbo].[Location] C on A.[LocationID] = [C].[Id] 
		JOIN [dbo].[Seller] D  ON A.[SellerID] = D.[Id]
	WHERE
		(@Title IS NULL OR [A].[Name] LIKE '%' + @Title + '%') AND
		--(@CategoryId IS NULL OR [A].[CategoryID] = @CategoryId) AND
		(@LocationId IS NULL OR [A].[LocationID] = @LocationId) AND
		(@StartPrice IS NULL OR [A].[Price] >= @StartPrice) AND
		(@EndPrice IS NULL OR [A].[Price] <= @EndPrice) AND
		(@StartDate IS NULL OR [A].[CreatedDate] >= @StartDate) AND
		(@EndDate IS NULL OR [A].[CreatedDate] < DATEADD(DAy, 1, @EndDate)) AND
		[A].[IsDeleted] = 'FALSE'
	ORDER BY
		CASE WHEN @SortDir = 'asc' AND @SortBy = 'title' THEN [A].[Name] END,
		CASE WHEN @SortDir = 'desc' AND @SortBy = 'title' THEN [A].[Name] END DESC,
		CASE WHEN @SortDir = 'asc' AND @SortBy = 'price' THEN [A].[Price] END,
		CASE WHEN @SortDir = 'desc' AND @SortBy = 'price' THEN [A].[Price] END DESC,
		CASE WHEN @SortDir = 'asc' AND @SortBy = 'date' THEN [A].[CreatedDate] END,
		CASE WHEN @SortDir = 'desc' AND @SortBy = 'date' THEN [A].[CreatedDate] END DESC
	OFFSET @PageIndex * @PageSize ROWS FETCH NEXT @PageSize ROWS ONLY;

END
