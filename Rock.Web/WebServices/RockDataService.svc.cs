using System;
using System.Data.Entity.Infrastructure;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq.Expressions;
using System.ServiceModel;
using System.Web;
using Rock.Cms.Security;
using Rock.EntityFramework;
using Rock.Helpers;
using Rock.Models.Crm;
using Rock.Services.Cms;

namespace Rock.Web.WebServices
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class RockDataService : DataService<RockContext>
    {
        /// <summary>
        /// Create some compatibility with EF POCO classes and WCF Data Services.
        /// </summary>
        /// <returns>RockContext w/ Proxy Creation disabled</returns>
        protected override RockContext CreateDataSource()
        {
            var context = new RockContext();
            var objectContext = ((IObjectContextAdapter) context).ObjectContext;
            objectContext.ContextOptions.ProxyCreationEnabled = false;
            return context;
        }

        /// <summary>
        /// This method is called only once to initialize service-wide policies.
        /// </summary>
        /// <param name="config">Configuration object to add Entity config opitons to.</param>
        public static void InitializeService(DataServiceConfiguration config)
        {
            InitEntityAccessRules(config);
            config.UseVerboseErrors = true;
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;
        }

        /// <summary>
        /// Maps all POCO entity objects to service config.
        /// </summary>
        /// <param name="config">Configuration object to add Entity config opitons to.</param>
        private static void InitEntityAccessRules(DataServiceConfiguration config)
        {
            config.SetEntitySetAccessRule("Persons", EntitySetRights.All);
            config.SetEntitySetAccessRule("PhoneNumbers", EntitySetRights.All);
            config.SetEntitySetAccessRule("Groups", EntitySetRights.All);
            config.SetEntitySetAccessRule("GroupRoles", EntitySetRights.All);
            config.SetEntitySetAccessRule("GroupTypes", EntitySetRights.All);
            config.SetEntitySetAccessRule("Members", EntitySetRights.All);
            config.SetEntitySetAccessRule("Attributes", EntitySetRights.All);
            config.SetEntitySetAccessRule("AttributeQualifiers", EntitySetRights.All);
            config.SetEntitySetAccessRule("AttributeValues", EntitySetRights.All);
            config.SetEntitySetAccessRule("DefinedTypes", EntitySetRights.All);
            config.SetEntitySetAccessRule("EntityChanges", EntitySetRights.All);
            config.SetEntitySetAccessRule("FieldTypes", EntitySetRights.All);
            config.SetEntitySetAccessRule("Users", EntitySetRights.All);
            config.SetEntitySetAccessRule("Roles", EntitySetRights.All);
            config.SetEntitySetAccessRule("Blocks", EntitySetRights.All);
            config.SetEntitySetAccessRule("Auths", EntitySetRights.All);
            config.SetEntitySetAccessRule("BlockInstances", EntitySetRights.All);
            config.SetEntitySetAccessRule("HtmlContents", EntitySetRights.All);
            config.SetEntitySetAccessRule("Pages", EntitySetRights.All);
            config.SetEntitySetAccessRule("PageRoutes", EntitySetRights.All);
            config.SetEntitySetAccessRule("Sites", EntitySetRights.All);
            config.SetEntitySetAccessRule("SiteDomains", EntitySetRights.All);
            config.SetEntitySetAccessRule("Blogs", EntitySetRights.All);
            config.SetEntitySetAccessRule("BlogCategorys", EntitySetRights.All);
            config.SetEntitySetAccessRule("BlogPosts", EntitySetRights.All);
            config.SetEntitySetAccessRule("BlogPostComments", EntitySetRights.All);
        }

        [QueryInterceptor("Persons")]
        public Expression<Func<Person, bool>> OnPersonQuery()
        {
            var user = HttpContext.Current.User;

            if (user == null)
            {
                throw new DataServiceException(403, "You must be logged in.");
            }

            var service = new UserService();
            var rockUser = service.GetUserByApplicationNameAndUsername("RockChMS", user.Identity.Name);
            return p => Authorization.Authorized(p, "View", MembershipHelper.GetMembershipUserFromModel("RockMembershipProvider", rockUser));
        }

        //[ChangeInterceptor("Persons")]
        //public void OnPersonChange(Person person, UpdateOperations operations)
        //{
        //    // Can use this point to apply per-record access security
        //    // This, of course would end up getting 
        //}
    }
}
