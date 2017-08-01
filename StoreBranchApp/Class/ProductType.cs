using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;

namespace StoreBranchApp
{
    [Table(Name = "ProductType")]
    public class ProductType
    {
        [Column(IsPrimaryKey = true, AutoSync = AutoSync.OnInsert, DbType = "Int NULL IDENTITY", IsDbGenerated = true)]
        public int Id;
        [Column]
        public string Name;
        [Column]
        public DateTime UpdatedAt;
        [Column(IsDbGenerated = true)]
        public DateTime CreatedAt;

        public bool save()
        {
            try
            {
                UpdatedAt = DateTime.Now;
                if (Id == 0)
                {
                    Connection.TableProductType.InsertOnSubmit(this);
                }
                Connection.DataContext.SubmitChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public void delete()
        {
            Connection.TableProductType.DeleteOnSubmit(this);
            this.save();
        }

        public static IQueryable<ProductType> findAll()
        {
            var query =
                from productType in Connection.TableProductType
                select productType;

            return query;
        }

        public static ProductType findOne(int id)
        {
            return ProductType.findAll().Where(u => u.Id == id).First();
        }
    }
}