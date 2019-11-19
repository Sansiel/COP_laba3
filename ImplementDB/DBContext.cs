using ProdModel;
using System.Data.Entity;

namespace ImplementDB
{
    public class DBContext : System.Data.Entity.DbContext
    {
        public DBContext() : base("DBContext")
        {
            //настройки конфигурации для entity
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            var ensureDLLIsCopied =
            System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        public virtual DbSet<Product> Products { get; set; }
    }
}