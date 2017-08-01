using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;

namespace StoreBranchApp
{
    [Table(Name = "Stock")]
    public class Stock
    {
        [Column(IsPrimaryKey = true, AutoSync = AutoSync.OnInsert, DbType = "Int NULL IDENTITY", IsDbGenerated = true)]
        public int Id;
        [Column]
        public int BranchId;
        [Column]
        public int ProductId;
        [Column]
        public int Balance;
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
                    Connection.TableStock.InsertOnSubmit(this);
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
            Connection.TableStock.DeleteOnSubmit(this);
            this.save();
        }

        public Branch branch()
        {
            return Branch.findOne(this.BranchId);
        }

        public Product product()
        {
            return Product.findOne(this.ProductId);
        }

        public int availableStock()
        {
            var ti = TransactionItem.findAll()
                                .Where(x => x.ProductId == this.ProductId);
            int checkout = 0;

            foreach(var x in ti)
            {
                if (x.transaction().BranchId == this.BranchId && x.transaction().cancel == 0)
                {
                    checkout += x.NumOfItem;
                }
            }

            return Stock.findAll().Where(item => item.BranchId == this.BranchId)
                        .Where(item => item.ProductId == this.ProductId)
                        .Sum(item => item.Balance) - checkout;
        }

        public static IQueryable<Stock> findAll()
        {
            var query =
                from item in Connection.TableStock
                select item;

            return query;
        }

        public static IQueryable<Stock> findByBranch(int id)
        {
            return Stock.findAll().Where(item => item.BranchId == id);
        }

        public static Stock findOne(int id)
        {
            return Stock.findAll().Where(u => u.Id == id).First();
        }

        public static IQueryable<Stock> distinctBranch(int id)
        {
            return Stock.findByBranch(id).GroupBy(item => item.ProductId).Select(item => item.First());
        }
    }
}