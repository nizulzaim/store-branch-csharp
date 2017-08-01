using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBranchApp
{
    [Table(Name = "Branch")]
    public class Branch
    {
        [Column(IsPrimaryKey = true, AutoSync = AutoSync.OnInsert, DbType = "Int NULL IDENTITY", IsDbGenerated = true)]
        public int Id;
        [Column]
        public string Name;
        [Column]
        public string Address;
        [Column]
        public DateTime UpdatedAt;
        [Column(IsDbGenerated = true)]
        public DateTime CreatedAt;
        [Column]
        public Nullable<DateTime> DeletedAt = null;

        public bool save()
        {
            try
            {
                UpdatedAt = DateTime.Now;
                if (Id == 0)
                {
                    Connection.TableBranch.InsertOnSubmit(this);
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
            //Connection.TableBranch.DeleteOnSubmit(this);
            DeletedAt = DateTime.Now;
            this.save();
        }

        public static IQueryable<Branch> findAll()
        {
            var query =
                from branch in Connection.TableBranch
                where !branch.DeletedAt.HasValue
                select branch;

            return query;
        }

        public static Branch findOne(int id)
        {
            return Branch.findAll().Where(u => u.Id == id).First();
        }

        public IQueryable<Transaction> transaction()
        {
            return Transaction.findByBranch(this.Id);
        }

        public double totalSales()
        {
            double sales = 0;
            
            foreach(Transaction t in this.transaction())
            {
                sales += t.getSales() ?? 0.0;
            }

            return sales;
        }

        public double todaySales()
        {
            double sales = 0;

            foreach (Transaction t in this.transaction())
            {
                sales += t.todaySales() ?? 0.0;
            }

            return sales;
        }

        public double thisWeekSales()
        {
            double sales = 0;

            foreach (Transaction t in this.transaction())
            {
                sales += t.thisWeekSales() ?? 0.0;
            }

            return sales;
        }

        public double thisMonthSales()
        {
            double sales = 0;

            foreach (Transaction t in this.transaction())
            {
                sales += t.thisMonthSales() ?? 0.0;
            }

            return sales;
        }

        public static double Sales(string type = "total")
        {
            if (type == "today")
            {
                double r = 0 ;
                foreach (Branch b in Branch.findAll())
                {
                    r += b.todaySales();
                }
                return r;
            }

            if (type == "week")
            {
                double r = 0;
                foreach (Branch b in Branch.findAll())
                {
                    r += b.thisWeekSales();
                }
                return r;
            }

            if (type == "month")
            {
                double r = 0;
                foreach (Branch b in Branch.findAll())
                {
                    r += b.thisMonthSales();
                }
                return r;
            }

            double y = 0;
            foreach (Branch b in Branch.findAll())
            {
                y += b.totalSales();
            }
            return y;
        }

    }
}
