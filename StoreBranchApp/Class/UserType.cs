using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;

namespace StoreBranchApp
{
    [Table(Name = "UserType")]
    public class UserType
    {
        [Column(IsPrimaryKey = true, AutoSync = AutoSync.OnInsert, DbType = "Int NULL IDENTITY", IsDbGenerated = true)]
        public int Id;
        [Column]
        public string Name;
        [Column]
        public string Description;
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
                    Connection.TableUserType.InsertOnSubmit(this);
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
            Connection.TableUserType.DeleteOnSubmit(this);
            this.save();
        }

        public static IQueryable<UserType> findAll()
        {
            var query =
                from userType in Connection.TableUserType
                select userType;

            return query;
        }

        public static UserType findOne(int id)
        {
            return UserType.findAll().Where(u => u.Id == id).First();
        }
    }
}