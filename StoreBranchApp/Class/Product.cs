using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;

namespace StoreBranchApp
{
    [Table(Name = "Product")]
    public class Product
    {
        [Column(IsPrimaryKey = true, AutoSync = AutoSync.OnInsert, DbType = "Int NULL IDENTITY", IsDbGenerated = true)]
        public int Id;
        [Column]
        public string Name;
        [Column]
        public int TypeId;
        [Column]
        public string Barcode;
        [Column]
        public double Price;
        [Column]
        public DateTime UpdatedAt;
        [Column(IsDbGenerated = true)]
        public DateTime CreatedAt;
        [Column]
        public int Show = 1;

        public bool save()
        {
            try
            {
                UpdatedAt = DateTime.Now;
                if (Id == 0)
                {
                    Connection.TableProduct.InsertOnSubmit(this);
                }
                Connection.DataContext.SubmitChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public ProductType type()
        {
            return ProductType.findOne(this.TypeId);
        }

        public void delete()
        {
            Connection.TableProduct.DeleteOnSubmit(this);
            this.save();
        }

        public static IQueryable<Product> findAll()
        {
            var query =
                from product in Connection.TableProduct
                select product;

            return query;
        }

        public static Product findOne(string barcode)
        {
            Product p;
            try
            {
                p = Product.findAll().Where(u => u.Barcode == barcode).First();
            } catch
            {
                return null;
            }
            return p;
        }

        public static Product findOne(int id)
        {
            Product p;
            try
            {
                p = Product.findAll().Where(u => u.Id == id).First();
            }
            catch
            {
                return null;
            }
            return p;
        }
    }
}