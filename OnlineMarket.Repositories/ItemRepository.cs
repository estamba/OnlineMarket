using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineMarket.DAL;
using System.Data.Entity;
using OnlineMarket.Common.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace OnlineMarket.Repositories
{
    public class ItemRepository: GenericRepository<Item>
    {
        OnlineMarketEntities dbContext;

        public ItemRepository(OnlineMarketEntities dbContext) : base(dbContext)
        {
           this.dbContext = dbContext;

        }
        public List<ItemStatu> GetStatusList()
        {
            return dbContext.ItemStatus.ToList();
        }
        public async Task<PaginatedList<PostedAdListItem>> SearchPostedAdAsync(PostedAdSearchFilter filter, int pageIndex, int pageSize)
        {
            SqlConnection connection = null;
            if (filter == null)
            {
                filter = new PostedAdSearchFilter();
            }

            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                SqlCommand cmd = new SqlCommand("dbo.SearchPostedAd", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                if (!string.IsNullOrEmpty(filter.Title))
                    cmd.Parameters.AddWithValue("@Title", filter.Title);
                else
                    cmd.Parameters.AddWithValue("@Title", DBNull.Value);

                if (filter.CategoryId.HasValue)
                    cmd.Parameters.AddWithValue("@CategoryId", filter.CategoryId.Value);
                else
                    cmd.Parameters.AddWithValue("@CategoryId", DBNull.Value);

                if (filter.LocationId.HasValue)
                    cmd.Parameters.AddWithValue("@LocationId", filter.LocationId);
                else
                    cmd.Parameters.AddWithValue("@LocationId", DBNull.Value);

                if (filter.StartPrice.HasValue)
                    cmd.Parameters.AddWithValue("@StartPrice", filter.StartPrice.Value);
                else
                    cmd.Parameters.AddWithValue("@StartPrice", DBNull.Value);

                if (filter.EndPrice.HasValue)
                    cmd.Parameters.AddWithValue("@EndPrice", filter.EndPrice.Value);
                else
                    cmd.Parameters.AddWithValue("@EndPrice", DBNull.Value);

                if (filter.StartDate.HasValue)
                    cmd.Parameters.AddWithValue("@StartDate", filter.StartDate.Value);
                else
                    cmd.Parameters.AddWithValue("@StartDate", DBNull.Value);

                if (filter.EndDate.HasValue)
                    cmd.Parameters.AddWithValue("@EndDate", filter.EndDate.Value);
                else
                    cmd.Parameters.AddWithValue("@EndDate", DBNull.Value);

                if (filter.SellerId.HasValue)
                    cmd.Parameters.AddWithValue("@SellerId", filter.SellerId);
                else
                    cmd.Parameters.AddWithValue("@SellerId", DBNull.Value);

                if (filter.SortBy.HasValue ==  false)
                {
                    filter.SortBy = SortOrderType.date;
                }
                if (filter.SortDirection.HasValue ==  false)
                {
                    filter.SortDirection = SortDirection.asc;
                }
                
                cmd.Parameters.AddWithValue("@SortBy", filter.SortBy.ToString());
                cmd.Parameters.AddWithValue("@SortDir", filter.SortDirection.ToString());
                cmd.Parameters.AddWithValue("@PageSize", pageSize);
                cmd.Parameters.AddWithValue("@PageIndex", pageIndex);

                await connection.OpenAsync();
                SqlDataReader reader = await cmd.ExecuteReaderAsync();

                int actualSize = 0;
                int iId = reader.GetOrdinal("Id");
                int iName = reader.GetOrdinal("Name");
                int iDescription = reader.GetOrdinal("Description");
                int iCategory = reader.GetOrdinal("Category");
                int iCategoryId = reader.GetOrdinal("CategoryID");
                int iLocation = reader.GetOrdinal("Location");
                int iLocationId = reader.GetOrdinal("LocationId");
                int iSellerName = reader.GetOrdinal("SellerName");
                int iSellerId = reader.GetOrdinal("SellerID");
                int iActualSize = reader.GetOrdinal("ActualSize");
                int iPrice = reader.GetOrdinal("Price");
                int iPhoneNumber = reader.GetOrdinal("PhoneNumber");
                int iCreatedDate = reader.GetOrdinal("CreatedDate");
                int iCreatedDateUtc = reader.GetOrdinal("CreatedDateUtc");
                int iCoverPhotoId = reader.GetOrdinal("CoverPhotoId");
                int iPictureCount = reader.GetOrdinal("PictureCount");
                int iItemStatus = reader.GetOrdinal("ItemStatus");

                List<PostedAdListItem> adList = new List<PostedAdListItem>();

                while (await reader.ReadAsync())
                {
                    PostedAdListItem ad = new PostedAdListItem()
                    {
                        Id = reader.GetInt32(iId),
                        Category = reader.GetString(iCategory),
                        CategoryId = reader.GetInt32(iCategoryId),
                        Description = reader.GetString(iDescription),
                        Location = reader.GetString(iLocation),
                        LocationId = reader.GetInt32(iLocationId),
                        Price = reader.GetDecimal(iPrice),
                        SellerId = reader.GetInt32(iSellerId),
                        SellerName = reader.GetString(iSellerName),
                        SellerPhone = reader.GetString(iPhoneNumber),
                        Title = reader.GetString(iName),
                        CoverPhotoId = reader.GetGuid(iCoverPhotoId),
                        CreatedDate = DateTime.SpecifyKind(reader.GetDateTime(iCreatedDate), DateTimeKind.Local),
                        CreatedDateUtc = DateTime.SpecifyKind(reader.GetDateTime(iCreatedDateUtc), DateTimeKind.Utc),
                        PictureCount = reader.GetInt32(iPictureCount),
                        ItemStatus = reader.GetString(iItemStatus)
                        
                    };
                    actualSize = reader.GetInt32(iActualSize);
                    adList.Add(ad);
                }

                reader.Close();
                return new PaginatedList<PostedAdListItem>()
                {
                    ActualSize = actualSize,
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    Results = adList
                };
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public async Task<PostedAdDetails> GetPostedAdDetailsByIDAsync(int id)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                SqlCommand cmd = new SqlCommand("dbo.GetPostedAdDetailsByID", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);

                await connection.OpenAsync();
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                PostedAdDetails ad = null;

                if (await reader.ReadAsync())
                {
                    int iId = reader.GetOrdinal("Id");
                    int iName = reader.GetOrdinal("Name");
                    int iDescription = reader.GetOrdinal("Description");
                    int iCategory = reader.GetOrdinal("Category");
                    int iCategoryId = reader.GetOrdinal("CategoryID");
                    int iLocation = reader.GetOrdinal("Location");
                    int iLocationId = reader.GetOrdinal("LocationId");
                    int iSellerName = reader.GetOrdinal("SellerName");
                    int iSellerId = reader.GetOrdinal("SellerID");
                    int iActualSize = reader.GetOrdinal("ActualSize");
                    int iPrice = reader.GetOrdinal("Price");
                    int iPhoneNumber = reader.GetOrdinal("PhoneNumber");
                    int iCreatedDate = reader.GetOrdinal("CreatedDate");
                    int iCreatedDateUtc = reader.GetOrdinal("CreatedDateUtc");
                    int iCoverPhotoId = reader.GetOrdinal("CoverPhotoId");
                    int iPictureCount = reader.GetOrdinal("PictureCount");

                    ad = new PostedAdDetails()
                    {
                        Id = reader.GetInt32(iId),
                        Category = reader.GetString(iCategory),
                        CategoryId = reader.GetInt32(iCategoryId),
                        Description = reader.GetString(iDescription),
                        Location = reader.GetString(iLocation),
                        LocationId = reader.GetInt32(iLocationId),
                        Price = reader.GetDecimal(iPrice),
                        SellerId = reader.GetInt32(iSellerId),
                        SellerName = reader.GetString(iSellerName),
                        SellerPhone = reader.GetString(iPhoneNumber),
                        Title = reader.GetString(iName),
                        CoverPhotoId = reader.GetGuid(iCoverPhotoId),
                        CreatedDate = DateTime.SpecifyKind(reader.GetDateTime(iCreatedDate), DateTimeKind.Local),
                        CreatedDateUtc = DateTime.SpecifyKind(reader.GetDateTime(iCreatedDateUtc), DateTimeKind.Utc),
                        PictureCount = reader.GetInt32(iPictureCount),
                        Pictures = new List<Guid>()
                    };

                    if (await reader.NextResultAsync())
                    {
                        int iImageId = reader.GetOrdinal("ImageId");
                        while(reader.Read())
                        {
                            Guid imageId = reader.GetGuid(iImageId);
                            ad.Pictures.Add(imageId);
                        }
                    }
                }

                reader.Close();
                return ad;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
            
        }
    }
}
