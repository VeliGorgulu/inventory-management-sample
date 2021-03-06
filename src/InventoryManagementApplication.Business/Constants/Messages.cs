using InventoryManagementApplication.Core.Entities.Concrete;
using InventoryManagementApplication.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApplication.Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Product added.";
        public static string ProductUpdated = "Product updated.";
        public static string ProductNameInvalid = "Product name invalid.";
        public static string MaintenanceTime = "Maintenance time.";
        public static string ProductsListed = "Products listed.";
        public static string ProductCountOfCategoryError = "The maximum number of products in a category has been reached.";
        public static string ProductNameAlreadyExist = "Product name already exist.";
        public static string CategoryLimitExceded = "Category limit exceded.";
        public static string AuthorizationDenied = "Authorization denied.";
        public static string UserRegistered = "User registered.";
        public static string UserNotFound = "User not found.";
        public static string PasswordError = "Password error.";
        public static string SuccessfulLogin = "Successful login.";
        public static string UserAlreadyExists = "User already exists.";
        public static string AccessTokenCreated = "Access token created.";
    }
}
