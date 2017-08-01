using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;

namespace StoreBranchApp
{
    [Table(Name = "Transaction")]
    public class Transaction
    {
        [Column(IsPrimaryKey = true, AutoSync = AutoSync.OnInsert, DbType = "Int NULL IDENTITY", IsDbGenerated = true)]
        public int Id;
        [Column]
        public int BranchId;
        [Column]
        public int UserId;
        [Column]
        public int cancel;
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
                    Connection.TableTransaction.InsertOnSubmit(this);
                }
                Connection.DataContext.SubmitChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public User user()
        {
            return User.findOne(this.UserId);
        }

        public Branch branch()
        {
            return Branch.findOne(this.BranchId);
        }

        public void delete()
        {
            Connection.TableTransaction.DeleteOnSubmit(this);
            this.save();
        }

        public static IQueryable<Transaction> findAll()
        {
            var query =
                from product in Connection.TableTransaction
                select product;

            return query;
        }

        public static Transaction findOne(int id)
        {
            return Transaction.findAll().Where(u => u.Id == id).First();
        }

        public static IQueryable<Transaction> findByBranch(int id)
        {
            return Transaction.findAll().Where(u => u.BranchId == id && u.cancel == 0);
        }

        public IQueryable<TransactionItem> transactionItem()
        {
            return TransactionItem.findByTransaction(this.Id);
        }

        public double? getSales()
        {
            return this.transactionItem().Sum(x => x.lockPrice * (double?)x.NumOfItem);
        }

        public double? thisMonthSales()
        {
            DateTime date = DateTime.Now;
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddSeconds(-1);
            return this.transactionItem()
                .Where(x => x.CreatedAt >= firstDayOfMonth && x.CreatedAt <= lastDayOfMonth)
                .Sum(x => x.lockPrice * (double?)x.NumOfItem);
        }

        public double? thisWeekSales()
        {
            DateTime date = DateTime.Now;
            int delta = DayOfWeek.Monday - date.DayOfWeek;
            var firstDayOfWeek = date.AddDays(delta);
            var lastDayOfWeek = firstDayOfWeek.AddDays(7).AddSeconds(-1);
            return this.transactionItem()
                .Where(x => x.CreatedAt >=firstDayOfWeek && x.CreatedAt <= lastDayOfWeek)
                .Sum(x => x.lockPrice * (double?)x.NumOfItem);
        }

        public double? todaySales()
        {
            DateTime date = DateTime.Now;
            DateTime first = new DateTime(date.Year, date.Month, date.Day);
            DateTime last = first.AddDays(1).AddSeconds(-1);
            return this.transactionItem()
                .Where(x => x.CreatedAt >= first && x.CreatedAt <= last)
                .Sum(y => y.lockPrice * (double?)y.NumOfItem);
        }

        public static IQueryable<TransactionItem> transactionItems(int id, int branchId = 0)
        {
            return TransactionItem.findAll().Where(u => u.TransactionId == id);
        }
    }
}