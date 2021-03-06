//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the T4\Model.tt template.
//
//     Changes to this file will be lost when the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//
using System.ComponentModel.Composition;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace Rock.REST.CMS
{
	/// <summary>
	/// REST WCF service for Blogs
	/// </summary>
    [Export(typeof(IService))]
    [ExportMetadata("RouteName", "CMS/Blog")]
	[AspNetCompatibilityRequirements( RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed )]
    public partial class BlogService : IBlogService, IService
    {
		/// <summary>
		/// Gets a Blog object
		/// </summary>
		[WebGet( UriTemplate = "{id}" )]
        public Rock.CMS.DTO.Blog Get( string id )
        {
            var currentUser = Rock.CMS.UserService.GetCurrentUser();
            if ( currentUser == null )
                throw new WebFaultException<string>("Must be logged in", System.Net.HttpStatusCode.Forbidden );

            using (Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope())
            {
				uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.CMS.BlogService BlogService = new Rock.CMS.BlogService();
				Rock.CMS.Blog Blog = BlogService.Get( int.Parse( id ) );
				if ( Blog.Authorized( "View", currentUser ) )
					return Blog.DataTransferObject;
				else
					throw new WebFaultException<string>( "Not Authorized to View this Blog", System.Net.HttpStatusCode.Forbidden );
            }
        }
		
		/// <summary>
		/// Gets a Blog object
		/// </summary>
		[WebGet( UriTemplate = "{id}/{apiKey}" )]
        public Rock.CMS.DTO.Blog ApiGet( string id, string apiKey )
        {
            using (Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope())
            {
				Rock.CMS.UserService userService = new Rock.CMS.UserService();
                Rock.CMS.User user = userService.Queryable().Where( u => u.ApiKey == apiKey ).FirstOrDefault();

				if (user != null)
				{
					uow.objectContext.Configuration.ProxyCreationEnabled = false;
					Rock.CMS.BlogService BlogService = new Rock.CMS.BlogService();
					Rock.CMS.Blog Blog = BlogService.Get( int.Parse( id ) );
					if ( Blog.Authorized( "View", user ) )
						return Blog.DataTransferObject;
					else
						throw new WebFaultException<string>( "Not Authorized to View this Blog", System.Net.HttpStatusCode.Forbidden );
				}
				else
					throw new WebFaultException<string>( "Invalid API Key", System.Net.HttpStatusCode.Forbidden );
            }
        }
		
		/// <summary>
		/// Updates a Blog object
		/// </summary>
		[WebInvoke( Method = "PUT", UriTemplate = "{id}" )]
        public void UpdateBlog( string id, Rock.CMS.DTO.Blog Blog )
        {
            var currentUser = Rock.CMS.UserService.GetCurrentUser();
            if ( currentUser == null )
                throw new WebFaultException<string>("Must be logged in", System.Net.HttpStatusCode.Forbidden );

            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.CMS.BlogService BlogService = new Rock.CMS.BlogService();
				Rock.CMS.Blog existingBlog = BlogService.Get( int.Parse( id ) );
				if ( existingBlog.Authorized( "Edit", currentUser ) )
				{
					uow.objectContext.Entry(existingBlog).CurrentValues.SetValues(Blog);
					
					if (existingBlog.IsValid)
						BlogService.Save( existingBlog, currentUser.PersonId );
					else
						throw new WebFaultException<string>( existingBlog.ValidationResults.AsDelimited(", "), System.Net.HttpStatusCode.BadRequest );
				}
				else
					throw new WebFaultException<string>( "Not Authorized to Edit this Blog", System.Net.HttpStatusCode.Forbidden );
            }
        }

		/// <summary>
		/// Updates a Blog object
		/// </summary>
		[WebInvoke( Method = "PUT", UriTemplate = "{id}/{apiKey}" )]
        public void ApiUpdateBlog( string id, string apiKey, Rock.CMS.DTO.Blog Blog )
        {
            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				Rock.CMS.UserService userService = new Rock.CMS.UserService();
                Rock.CMS.User user = userService.Queryable().Where( u => u.ApiKey == apiKey ).FirstOrDefault();

				if (user != null)
				{
					uow.objectContext.Configuration.ProxyCreationEnabled = false;
					Rock.CMS.BlogService BlogService = new Rock.CMS.BlogService();
					Rock.CMS.Blog existingBlog = BlogService.Get( int.Parse( id ) );
					if ( existingBlog.Authorized( "Edit", user ) )
					{
						uow.objectContext.Entry(existingBlog).CurrentValues.SetValues(Blog);
					
						if (existingBlog.IsValid)
							BlogService.Save( existingBlog, user.PersonId );
						else
							throw new WebFaultException<string>( existingBlog.ValidationResults.AsDelimited(", "), System.Net.HttpStatusCode.BadRequest );
					}
					else
						throw new WebFaultException<string>( "Not Authorized to Edit this Blog", System.Net.HttpStatusCode.Forbidden );
				}
				else
					throw new WebFaultException<string>( "Invalid API Key", System.Net.HttpStatusCode.Forbidden );
            }
        }

		/// <summary>
		/// Creates a new Blog object
		/// </summary>
		[WebInvoke( Method = "POST", UriTemplate = "" )]
        public void CreateBlog( Rock.CMS.DTO.Blog Blog )
        {
            var currentUser = Rock.CMS.UserService.GetCurrentUser();
            if ( currentUser == null )
                throw new WebFaultException<string>("Must be logged in", System.Net.HttpStatusCode.Forbidden );

            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.CMS.BlogService BlogService = new Rock.CMS.BlogService();
				Rock.CMS.Blog existingBlog = new Rock.CMS.Blog();
				BlogService.Add( existingBlog, currentUser.PersonId );
				uow.objectContext.Entry(existingBlog).CurrentValues.SetValues(Blog);

				if (existingBlog.IsValid)
					BlogService.Save( existingBlog, currentUser.PersonId );
				else
					throw new WebFaultException<string>( existingBlog.ValidationResults.AsDelimited(", "), System.Net.HttpStatusCode.BadRequest );
            }
        }

		/// <summary>
		/// Creates a new Blog object
		/// </summary>
		[WebInvoke( Method = "POST", UriTemplate = "{apiKey}" )]
        public void ApiCreateBlog( string apiKey, Rock.CMS.DTO.Blog Blog )
        {
            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				Rock.CMS.UserService userService = new Rock.CMS.UserService();
                Rock.CMS.User user = userService.Queryable().Where( u => u.ApiKey == apiKey ).FirstOrDefault();

				if (user != null)
				{
					uow.objectContext.Configuration.ProxyCreationEnabled = false;
					Rock.CMS.BlogService BlogService = new Rock.CMS.BlogService();
					Rock.CMS.Blog existingBlog = new Rock.CMS.Blog();
					BlogService.Add( existingBlog, user.PersonId );
					uow.objectContext.Entry(existingBlog).CurrentValues.SetValues(Blog);

					if (existingBlog.IsValid)
						BlogService.Save( existingBlog, user.PersonId );
					else
						throw new WebFaultException<string>( existingBlog.ValidationResults.AsDelimited(", "), System.Net.HttpStatusCode.BadRequest );
				}
				else
					throw new WebFaultException<string>( "Invalid API Key", System.Net.HttpStatusCode.Forbidden );
            }
        }

		/// <summary>
		/// Deletes a Blog object
		/// </summary>
		[WebInvoke( Method = "DELETE", UriTemplate = "{id}" )]
        public void DeleteBlog( string id )
        {
            var currentUser = Rock.CMS.UserService.GetCurrentUser();
            if ( currentUser == null )
                throw new WebFaultException<string>("Must be logged in", System.Net.HttpStatusCode.Forbidden );

            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.CMS.BlogService BlogService = new Rock.CMS.BlogService();
				Rock.CMS.Blog Blog = BlogService.Get( int.Parse( id ) );
				if ( Blog.Authorized( "Edit", currentUser ) )
				{
					BlogService.Delete( Blog, currentUser.PersonId );
					BlogService.Save( Blog, currentUser.PersonId );
				}
				else
					throw new WebFaultException<string>( "Not Authorized to Edit this Blog", System.Net.HttpStatusCode.Forbidden );
            }
        }

		/// <summary>
		/// Deletes a Blog object
		/// </summary>
		[WebInvoke( Method = "DELETE", UriTemplate = "{id}/{apiKey}" )]
        public void ApiDeleteBlog( string id, string apiKey )
        {
            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				Rock.CMS.UserService userService = new Rock.CMS.UserService();
                Rock.CMS.User user = userService.Queryable().Where( u => u.ApiKey == apiKey ).FirstOrDefault();

				if (user != null)
				{
					uow.objectContext.Configuration.ProxyCreationEnabled = false;
					Rock.CMS.BlogService BlogService = new Rock.CMS.BlogService();
					Rock.CMS.Blog Blog = BlogService.Get( int.Parse( id ) );
					if ( Blog.Authorized( "Edit", user ) )
					{
						BlogService.Delete( Blog, user.PersonId );
						BlogService.Save( Blog, user.PersonId );
					}
					else
						throw new WebFaultException<string>( "Not Authorized to Edit this Blog", System.Net.HttpStatusCode.Forbidden );
				}
				else
					throw new WebFaultException<string>( "Invalid API Key", System.Net.HttpStatusCode.Forbidden );
            }
        }

    }
}
