using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBranchApp
{
    [Table(Name = "User")]
    public class User
    {
        [Column(IsPrimaryKey = true, AutoSync = AutoSync.OnInsert, DbType = "Int NULL IDENTITY", IsDbGenerated = true)]
        public int Id;
        [Column]
        public string Username;
        [Column]
        public string Password;
        [Column]
        public DateTime UpdatedAt;
        [Column]
        public Nullable<DateTime> DeletedAt;
        [Column(IsDbGenerated = true)]
        public DateTime CreatedAt;
        [Column]
        public int BranchId = 1;
        [Column]
        public int UserTypeId = 1;

        public bool save()
        {
            try
            {
                UpdatedAt = DateTime.Now;
                if (Id == 0)
                {
                    Connection.TableUser.InsertOnSubmit(this);
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
            DeletedAt = DateTime.Now;
            this.save();
        }

        public Branch branch()
        {
            return Branch.findOne(this.BranchId);
        }

        public UserType type()
        {
            return UserType.findOne(this.UserTypeId);
        }

        public static IQueryable<User> findAll()
        {
            var query =
                from user in Connection.TableUser
                where !user.DeletedAt.HasValue
                select user;

            return query;
        }

        public static User findOne(string username)
        {
            User user;
            try
            {
                user = User.findAll().Where(u => u.Username == username).First();
            } 
            catch
            {
                return null;
            }

            return user;
            
        }

        public static User findOne(int id)
        {
            User user;
            try
            {
                user = User.findAll().Where(u => u.Id == id).First();
            }
            catch
            {
                return null;
            }

            return user;
        }
    }
}
