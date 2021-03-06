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
	/// REST WCF service for PageRoutes
	/// </summary>
    [Export(typeof(IService))]
    [ExportMetadata("RouteName", "CMS/PageRoute")]
	[AspNetCompatibilityRequirements( RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed )]
    public partial class PageRouteService : IPageRouteService, IService
    {
		/// <summary>
		/// Gets a PageRoute object
		/// </summary>
		[WebGet( UriTemplate = "{id}" )]
        public Rock.CMS.DTO.PageRoute Get( string id )
        {
            var currentUser = Rock.CMS.UserService.GetCurrentUser();
            if ( currentUser == null )
                throw new WebFaultException<string>("Must be logged in", System.Net.HttpStatusCode.Forbidden );

            using (Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope())
            {
				uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.CMS.PageRouteService PageRouteService = new Rock.CMS.PageRouteService();
				Rock.CMS.PageRoute PageRoute = PageRouteService.Get( int.Parse( id ) );
				if ( PageRoute.Authorized( "View", currentUser ) )
					return PageRoute.DataTransferObject;
				else
					throw new WebFaultException<string>( "Not Authorized to View this PageRoute", System.Net.HttpStatusCode.Forbidden );
            }
        }
		
		/// <summary>
		/// Gets a PageRoute object
		/// </summary>
		[WebGet( UriTemplate = "{id}/{apiKey}" )]
        public Rock.CMS.DTO.PageRoute ApiGet( string id, string apiKey )
        {
            using (Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope())
            {
				Rock.CMS.UserService userService = new Rock.CMS.UserService();
                Rock.CMS.User user = userService.Queryable().Where( u => u.ApiKey == apiKey ).FirstOrDefault();

				if (user != null)
				{
					uow.objectContext.Configuration.ProxyCreationEnabled = false;
					Rock.CMS.PageRouteService PageRouteService = new Rock.CMS.PageRouteService();
					Rock.CMS.PageRoute PageRoute = PageRouteService.Get( int.Parse( id ) );
					if ( PageRoute.Authorized( "View", user ) )
						return PageRoute.DataTransferObject;
					else
						throw new WebFaultException<string>( "Not Authorized to View this PageRoute", System.Net.HttpStatusCode.Forbidden );
				}
				else
					throw new WebFaultException<string>( "Invalid API Key", System.Net.HttpStatusCode.Forbidden );
            }
        }
		
		/// <summary>
		/// Updates a PageRoute object
		/// </summary>
		[WebInvoke( Method = "PUT", UriTemplate = "{id}" )]
        public void UpdatePageRoute( string id, Rock.CMS.DTO.PageRoute PageRoute )
        {
            var currentUser = Rock.CMS.UserService.GetCurrentUser();
            if ( currentUser == null )
                throw new WebFaultException<string>("Must be logged in", System.Net.HttpStatusCode.Forbidden );

            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.CMS.PageRouteService PageRouteService = new Rock.CMS.PageRouteService();
				Rock.CMS.PageRoute existingPageRoute = PageRouteService.Get( int.Parse( id ) );
				if ( existingPageRoute.Authorized( "Edit", currentUser ) )
				{
					uow.objectContext.Entry(existingPageRoute).CurrentValues.SetValues(PageRoute);
					
					if (existingPageRoute.IsValid)
						PageRouteService.Save( existingPageRoute, currentUser.PersonId );
					else
						throw new WebFaultException<string>( existingPageRoute.ValidationResults.AsDelimited(", "), System.Net.HttpStatusCode.BadRequest );
				}
				else
					throw new WebFaultException<string>( "Not Authorized to Edit this PageRoute", System.Net.HttpStatusCode.Forbidden );
            }
        }

		/// <summary>
		/// Updates a PageRoute object
		/// </summary>
		[WebInvoke( Method = "PUT", UriTemplate = "{id}/{apiKey}" )]
        public void ApiUpdatePageRoute( string id, string apiKey, Rock.CMS.DTO.PageRoute PageRoute )
        {
            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				Rock.CMS.UserService userService = new Rock.CMS.UserService();
                Rock.CMS.User user = userService.Queryable().Where( u => u.ApiKey == apiKey ).FirstOrDefault();

				if (user != null)
				{
					uow.objectContext.Configuration.ProxyCreationEnabled = false;
					Rock.CMS.PageRouteService PageRouteService = new Rock.CMS.PageRouteService();
					Rock.CMS.PageRoute existingPageRoute = PageRouteService.Get( int.Parse( id ) );
					if ( existingPageRoute.Authorized( "Edit", user ) )
					{
						uow.objectContext.Entry(existingPageRoute).CurrentValues.SetValues(PageRoute);
					
						if (existingPageRoute.IsValid)
							PageRouteService.Save( existingPageRoute, user.PersonId );
						else
							throw new WebFaultException<string>( existingPageRoute.ValidationResults.AsDelimited(", "), System.Net.HttpStatusCode.BadRequest );
					}
					else
						throw new WebFaultException<string>( "Not Authorized to Edit this PageRoute", System.Net.HttpStatusCode.Forbidden );
				}
				else
					throw new WebFaultException<string>( "Invalid API Key", System.Net.HttpStatusCode.Forbidden );
            }
        }

		/// <summary>
		/// Creates a new PageRoute object
		/// </summary>
		[WebInvoke( Method = "POST", UriTemplate = "" )]
        public void CreatePageRoute( Rock.CMS.DTO.PageRoute PageRoute )
        {
            var currentUser = Rock.CMS.UserService.GetCurrentUser();
            if ( currentUser == null )
                throw new WebFaultException<string>("Must be logged in", System.Net.HttpStatusCode.Forbidden );

            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.CMS.PageRouteService PageRouteService = new Rock.CMS.PageRouteService();
				Rock.CMS.PageRoute existingPageRoute = new Rock.CMS.PageRoute();
				PageRouteService.Add( existingPageRoute, currentUser.PersonId );
				uow.objectContext.Entry(existingPageRoute).CurrentValues.SetValues(PageRoute);

				if (existingPageRoute.IsValid)
					PageRouteService.Save( existingPageRoute, currentUser.PersonId );
				else
					throw new WebFaultException<string>( existingPageRoute.ValidationResults.AsDelimited(", "), System.Net.HttpStatusCode.BadRequest );
            }
        }

		/// <summary>
		/// Creates a new PageRoute object
		/// </summary>
		[WebInvoke( Method = "POST", UriTemplate = "{apiKey}" )]
        public void ApiCreatePageRoute( string apiKey, Rock.CMS.DTO.PageRoute PageRoute )
        {
            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				Rock.CMS.UserService userService = new Rock.CMS.UserService();
                Rock.CMS.User user = userService.Queryable().Where( u => u.ApiKey == apiKey ).FirstOrDefault();

				if (user != null)
				{
					uow.objectContext.Configuration.ProxyCreationEnabled = false;
					Rock.CMS.PageRouteService PageRouteService = new Rock.CMS.PageRouteService();
					Rock.CMS.PageRoute existingPageRoute = new Rock.CMS.PageRoute();
					PageRouteService.Add( existingPageRoute, user.PersonId );
					uow.objectContext.Entry(existingPageRoute).CurrentValues.SetValues(PageRoute);

					if (existingPageRoute.IsValid)
						PageRouteService.Save( existingPageRoute, user.PersonId );
					else
						throw new WebFaultException<string>( existingPageRoute.ValidationResults.AsDelimited(", "), System.Net.HttpStatusCode.BadRequest );
				}
				else
					throw new WebFaultException<string>( "Invalid API Key", System.Net.HttpStatusCode.Forbidden );
            }
        }

		/// <summary>
		/// Deletes a PageRoute object
		/// </summary>
		[WebInvoke( Method = "DELETE", UriTemplate = "{id}" )]
        public void DeletePageRoute( string id )
        {
            var currentUser = Rock.CMS.UserService.GetCurrentUser();
            if ( currentUser == null )
                throw new WebFaultException<string>("Must be logged in", System.Net.HttpStatusCode.Forbidden );

            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.CMS.PageRouteService PageRouteService = new Rock.CMS.PageRouteService();
				Rock.CMS.PageRoute PageRoute = PageRouteService.Get( int.Parse( id ) );
				if ( PageRoute.Authorized( "Edit", currentUser ) )
				{
					PageRouteService.Delete( PageRoute, currentUser.PersonId );
					PageRouteService.Save( PageRoute, currentUser.PersonId );
				}
				else
					throw new WebFaultException<string>( "Not Authorized to Edit this PageRoute", System.Net.HttpStatusCode.Forbidden );
            }
        }

		/// <summary>
		/// Deletes a PageRoute object
		/// </summary>
		[WebInvoke( Method = "DELETE", UriTemplate = "{id}/{apiKey}" )]
        public void ApiDeletePageRoute( string id, string apiKey )
        {
            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				Rock.CMS.UserService userService = new Rock.CMS.UserService();
                Rock.CMS.User user = userService.Queryable().Where( u => u.ApiKey == apiKey ).FirstOrDefault();

				if (user != null)
				{
					uow.objectContext.Configuration.ProxyCreationEnabled = false;
					Rock.CMS.PageRouteService PageRouteService = new Rock.CMS.PageRouteService();
					Rock.CMS.PageRoute PageRoute = PageRouteService.Get( int.Parse( id ) );
					if ( PageRoute.Authorized( "Edit", user ) )
					{
						PageRouteService.Delete( PageRoute, user.PersonId );
						PageRouteService.Save( PageRoute, user.PersonId );
					}
					else
						throw new WebFaultException<string>( "Not Authorized to Edit this PageRoute", System.Net.HttpStatusCode.Forbidden );
				}
				else
					throw new WebFaultException<string>( "Invalid API Key", System.Net.HttpStatusCode.Forbidden );
            }
        }

    }
}
