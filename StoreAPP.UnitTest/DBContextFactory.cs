using Microsoft.EntityFrameworkCore;
using StoreApp.Domain.ClientDB;
using StoreApp.Domain.ExtraEdgeStoreDB;

namespace APS.UnitTest
{
    public  class DbOptionsExtraEdgeDgeFactory
    {
        string connectionString = string.Empty;
        public DbOptionsExtraEdgeDgeFactory(string type)
        {
            if (!string.IsNullOrWhiteSpace(type) && type=="ExtraEdge")
            {
                connectionString = "Server=SILICUS543\\SQLEXPRESS2017;Database=ExtraEdgeStoreDB;Trusted_Connection=True;";
                ExtraEdgeStoreDBContextOption = new DbContextOptionsBuilder<ExtraEdgeStoreDBContext>()
                .UseSqlServer(connectionString)
                .Options;
            }
            else if(!string.IsNullOrWhiteSpace(type) && type == "ClientDB")
            {
                connectionString = "Server=SILICUS543\\SQLEXPRESS2017;Database=ClientDB;Trusted_Connection=True;";
                ClientDBContextOption = new DbContextOptionsBuilder<ClientDBContext>()
                .UseSqlServer(connectionString)
                .Options;
            }

        }

        public  DbContextOptions<ExtraEdgeStoreDBContext> ExtraEdgeStoreDBContextOption { get; }
        public  DbContextOptions<ClientDBContext> ClientDBContextOption { get; }

    }
}
