using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace StoreBranchApp
{
    public class Connection
    {
        private static DataContext db;
        private static Table<User> users;
        private static Table<UserType> userTypes;
        private static Table<Branch> branchs;
        private static Table<ProductType> productTypes;
        private static Table<Product> products;
        private static Table<Transaction> transactions;
        private static Table<TransactionItem> transactionItems;
        private static Table<Stock> stocks;

        static Connection()
        {
            db = new DataContext(ConfigurationManager.ConnectionStrings["storeBranchDBConnectionString"].ConnectionString.ToString());
            users = db.GetTable<User>();
            userTypes = db.GetTable<UserType>();
            branchs = db.GetTable<Branch>();
            productTypes = db.GetTable<ProductType>();
            products = db.GetTable<Product>();
            transactions = db.GetTable<Transaction>();
            transactionItems = db.GetTable<TransactionItem>();
            stocks = db.GetTable<Stock>();
        }

        internal static DataContext DataContext {
            get
            {
                return db;
            }
        }

        internal static Table<User> TableUser
        {
            get
            {
                return users;
            }
        }

        internal static Table<UserType> TableUserType
        {
            get
            {
                return userTypes;
            }
        }
        
        internal static Table<Branch> TableBranch
        {
            get
            {
                return branchs;
            }
        }

        internal static Table<ProductType> TableProductType
        {
            get
            {
                return productTypes;
            }
        }

        internal static Table<Product> TableProduct
        {
            get
            {
                return products;
            }
        }

        internal static Table<Transaction> TableTransaction
        {
            get
            {
                return transactions;
            }
        }

        internal static Table<TransactionItem> TableTransactionItem
        {
            get
            {
                return transactionItems;
            }
        }

        internal static Table<Stock> TableStock
        {
            get
            {
                return stocks;
            }
        }
    }
}