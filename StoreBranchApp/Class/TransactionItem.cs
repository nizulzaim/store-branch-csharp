using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;

namespace StoreBranchApp
{
    [Table(Name = "TransactionItem")]
    public class TransactionItem
    {
        [Column(IsPrimaryKey = true, AutoSync = AutoSync.OnInsert, DbType = "Int NULL IDENTITY", IsDbGenerated = true)]
        public int Id;
        [Column]
        public int TransactionId;
        [Column]
        public int ProductId;
        [Column]
        public DateTime UpdatedAt;
        [Column(IsDbGenerated = true)]
        public DateTime CreatedAt;
        [Column]
        public int NumOfItem = 1;
        [Column]
        public double lockPrice = 0.0;

        public bool save()
        {
            try
            {
                UpdatedAt = DateTime.Now;
                if (Id == 0)
                {
                    Connection.TableTransactionItem.InsertOnSubmit(this);
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
            Connection.TableTransactionItem.DeleteOnSubmit(this);
            this.save();
        }

        public Transaction transaction()
        {
            return Transaction.findOne(this.TransactionId);
        }

        public Product product()
        {
            return Product.findOne(this.ProductId);
        }

        public static IQueryable<TransactionItem> findAll()
        {
            var query =
                from items in Connection.TableTransactionItem
                select items;

            return query;
        }

        public static TransactionItem findOne(int id)
        {
            return TransactionItem.findAll().Where(u => u.Id == id).First();
        }

        public static IQueryable<TransactionItem> findByTransaction(int transactionId)
        {
            return TransactionItem.findAll().Where(x => x.TransactionId == transactionId);
        }
    }
}