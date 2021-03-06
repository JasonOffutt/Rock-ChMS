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
	/// REST WCF service for BlogPosts
	/// </summary>
    [Export(typeof(IService))]
    [ExportMetadata("RouteName", "CMS/BlogPost")]
	[AspNetCompatibilityRequirements( RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed )]
    public partial class BlogPostService : IBlogPostService, IService
    {
		/// <summary>
		/// Gets a BlogPost object
		/// </summary>
		[WebGet( UriTemplate = "{id}" )]
        public Rock.CMS.DTO.BlogPost Get( string id )
        {
            var currentUser = Rock.CMS.UserService.GetCurrentUser();
            if ( currentUser == null )
                throw new WebFaultException<string>("Must be logged in", System.Net.HttpStatusCode.Forbidden );

            using (Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope())
            {
				uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.CMS.BlogPostService BlogPostService = new Rock.CMS.BlogPostService();
				Rock.CMS.BlogPost BlogPost = BlogPostService.Get( int.Parse( id ) );
				if ( BlogPost.Authorized( "View", currentUser ) )
					return BlogPost.DataTransferObject;
				else
					throw new WebFaultException<string>( "Not Authorized to View this BlogPost", System.Net.HttpStatusCode.Forbidden );
            }
        }
		
		/// <summary>
		/// Gets a BlogPost object
		/// </summary>
		[WebGet( UriTemplate = "{id}/{apiKey}" )]
        public Rock.CMS.DTO.BlogPost ApiGet( string id, string apiKey )
        {
            using (Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope())
            {
				Rock.CMS.UserService userService = new Rock.CMS.UserService();
                Rock.CMS.User user = userService.Queryable().Where( u => u.ApiKey == apiKey ).FirstOrDefault();

				if (user != null)
				{
					uow.objectContext.Configuration.ProxyCreationEnabled = false;
					Rock.CMS.BlogPostService BlogPostService = new Rock.CMS.BlogPostService();
					Rock.CMS.BlogPost BlogPost = BlogPostService.Get( int.Parse( id ) );
					if ( BlogPost.Authorized( "View", user ) )
						return BlogPost.DataTransferObject;
					else
						throw new WebFaultException<string>( "Not Authorized to View this BlogPost", System.Net.HttpStatusCode.Forbidden );
				}
				else
					throw new WebFaultException<string>( "Invalid API Key", System.Net.HttpStatusCode.Forbidden );
            }
        }
		
		/// <summary>
		/// Updates a BlogPost object
		/// </summary>
		[WebInvoke( Method = "PUT", UriTemplate = "{id}" )]
        public void UpdateBlogPost( string id, Rock.CMS.DTO.BlogPost BlogPost )
        {
            var currentUser = Rock.CMS.UserService.GetCurrentUser();
            if ( currentUser == null )
                throw new WebFaultException<string>("Must be logged in", System.Net.HttpStatusCode.Forbidden );

            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.CMS.BlogPostService BlogPostService = new Rock.CMS.BlogPostService();
				Rock.CMS.BlogPost existingBlogPost = BlogPostService.Get( int.Parse( id ) );
				if ( existingBlogPost.Authorized( "Edit", currentUser ) )
				{
					uow.objectContext.Entry(existingBlogPost).CurrentValues.SetValues(BlogPost);
					
					if (existingBlogPost.IsValid)
						BlogPostService.Save( existingBlogPost, currentUser.PersonId );
					else
						throw new WebFaultException<string>( existingBlogPost.ValidationResults.AsDelimited(", "), System.Net.HttpStatusCode.BadRequest );
				}
				else
					throw new WebFaultException<string>( "Not Authorized to Edit this BlogPost", System.Net.HttpStatusCode.Forbidden );
            }
        }

		/// <summary>
		/// Updates a BlogPost object
		/// </summary>
		[WebInvoke( Method = "PUT", UriTemplate = "{id}/{apiKey}" )]
        public void ApiUpdateBlogPost( string id, string apiKey, Rock.CMS.DTO.BlogPost BlogPost )
        {
            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				Rock.CMS.UserService userService = new Rock.CMS.UserService();
                Rock.CMS.User user = userService.Queryable().Where( u => u.ApiKey == apiKey ).FirstOrDefault();

				if (user != null)
				{
					uow.objectContext.Configuration.ProxyCreationEnabled = false;
					Rock.CMS.BlogPostService BlogPostService = new Rock.CMS.BlogPostService();
					Rock.CMS.BlogPost existingBlogPost = BlogPostService.Get( int.Parse( id ) );
					if ( existingBlogPost.Authorized( "Edit", user ) )
					{
						uow.objectContext.Entry(existingBlogPost).CurrentValues.SetValues(BlogPost);
					
						if (existingBlogPost.IsValid)
							BlogPostService.Save( existingBlogPost, user.PersonId );
						else
							throw new WebFaultException<string>( existingBlogPost.ValidationResults.AsDelimited(", "), System.Net.HttpStatusCode.BadRequest );
					}
					else
						throw new WebFaultException<string>( "Not Authorized to Edit this BlogPost", System.Net.HttpStatusCode.Forbidden );
				}
				else
					throw new WebFaultException<string>( "Invalid API Key", System.Net.HttpStatusCode.Forbidden );
            }
        }

		/// <summary>
		/// Creates a new BlogPost object
		/// </summary>
		[WebInvoke( Method = "POST", UriTemplate = "" )]
        public void CreateBlogPost( Rock.CMS.DTO.BlogPost BlogPost )
        {
            var currentUser = Rock.CMS.UserService.GetCurrentUser();
            if ( currentUser == null )
                throw new WebFaultException<string>("Must be logged in", System.Net.HttpStatusCode.Forbidden );

            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.CMS.BlogPostService BlogPostService = new Rock.CMS.BlogPostService();
				Rock.CMS.BlogPost existingBlogPost = new Rock.CMS.BlogPost();
				BlogPostService.Add( existingBlogPost, currentUser.PersonId );
				uow.objectContext.Entry(existingBlogPost).CurrentValues.SetValues(BlogPost);

				if (existingBlogPost.IsValid)
					BlogPostService.Save( existingBlogPost, currentUser.PersonId );
				else
					throw new WebFaultException<string>( existingBlogPost.ValidationResults.AsDelimited(", "), System.Net.HttpStatusCode.BadRequest );
            }
        }

		/// <summary>
		/// Creates a new BlogPost object
		/// </summary>
		[WebInvoke( Method = "POST", UriTemplate = "{apiKey}" )]
        public void ApiCreateBlogPost( string apiKey, Rock.CMS.DTO.BlogPost BlogPost )
        {
            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				Rock.CMS.UserService userService = new Rock.CMS.UserService();
                Rock.CMS.User user = userService.Queryable().Where( u => u.ApiKey == apiKey ).FirstOrDefault();

				if (user != null)
				{
					uow.objectContext.Configuration.ProxyCreationEnabled = false;
					Rock.CMS.BlogPostService BlogPostService = new Rock.CMS.BlogPostService();
					Rock.CMS.BlogPost existingBlogPost = new Rock.CMS.BlogPost();
					BlogPostService.Add( existingBlogPost, user.PersonId );
					uow.objectContext.Entry(existingBlogPost).CurrentValues.SetValues(BlogPost);

					if (existingBlogPost.IsValid)
						BlogPostService.Save( existingBlogPost, user.PersonId );
					else
						throw new WebFaultException<string>( existingBlogPost.ValidationResults.AsDelimited(", "), System.Net.HttpStatusCode.BadRequest );
				}
				else
					throw new WebFaultException<string>( "Invalid API Key", System.Net.HttpStatusCode.Forbidden );
            }
        }

		/// <summary>
		/// Deletes a BlogPost object
		/// </summary>
		[WebInvoke( Method = "DELETE", UriTemplate = "{id}" )]
        public void DeleteBlogPost( string id )
        {
            var currentUser = Rock.CMS.UserService.GetCurrentUser();
            if ( currentUser == null )
                throw new WebFaultException<string>("Must be logged in", System.Net.HttpStatusCode.Forbidden );

            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.CMS.BlogPostService BlogPostService = new Rock.CMS.BlogPostService();
				Rock.CMS.BlogPost BlogPost = BlogPostService.Get( int.Parse( id ) );
				if ( BlogPost.Authorized( "Edit", currentUser ) )
				{
					BlogPostService.Delete( BlogPost, currentUser.PersonId );
					BlogPostService.Save( BlogPost, currentUser.PersonId );
				}
				else
					throw new WebFaultException<string>( "Not Authorized to Edit this BlogPost", System.Net.HttpStatusCode.Forbidden );
            }
        }

		/// <summary>
		/// Deletes a BlogPost object
		/// </summary>
		[WebInvoke( Method = "DELETE", UriTemplate = "{id}/{apiKey}" )]
        public void ApiDeleteBlogPost( string id, string apiKey )
        {
            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				Rock.CMS.UserService userService = new Rock.CMS.UserService();
                Rock.CMS.User user = userService.Queryable().Where( u => u.ApiKey == apiKey ).FirstOrDefault();

				if (user != null)
				{
					uow.objectContext.Configuration.ProxyCreationEnabled = false;
					Rock.CMS.BlogPostService BlogPostService = new Rock.CMS.BlogPostService();
					Rock.CMS.BlogPost BlogPost = BlogPostService.Get( int.Parse( id ) );
					if ( BlogPost.Authorized( "Edit", user ) )
					{
						BlogPostService.Delete( BlogPost, user.PersonId );
						BlogPostService.Save( BlogPost, user.PersonId );
					}
					else
						throw new WebFaultException<string>( "Not Authorized to Edit this BlogPost", System.Net.HttpStatusCode.Forbidden );
				}
				else
					throw new WebFaultException<string>( "Invalid API Key", System.Net.HttpStatusCode.Forbidden );
            }
        }

    }
}
