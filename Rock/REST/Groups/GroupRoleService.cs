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

namespace Rock.REST.Groups
{
	/// <summary>
	/// REST WCF service for GroupRoles
	/// </summary>
    [Export(typeof(IService))]
    [ExportMetadata("RouteName", "Groups/GroupRole")]
	[AspNetCompatibilityRequirements( RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed )]
    public partial class GroupRoleService : IGroupRoleService, IService
    {
		/// <summary>
		/// Gets a GroupRole object
		/// </summary>
		[WebGet( UriTemplate = "{id}" )]
        public Rock.Groups.DTO.GroupRole Get( string id )
        {
            var currentUser = Rock.CMS.UserService.GetCurrentUser();
            if ( currentUser == null )
                throw new WebFaultException<string>("Must be logged in", System.Net.HttpStatusCode.Forbidden );

            using (Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope())
            {
				uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.Groups.GroupRoleService GroupRoleService = new Rock.Groups.GroupRoleService();
				Rock.Groups.GroupRole GroupRole = GroupRoleService.Get( int.Parse( id ) );
				if ( GroupRole.Authorized( "View", currentUser ) )
					return GroupRole.DataTransferObject;
				else
					throw new WebFaultException<string>( "Not Authorized to View this GroupRole", System.Net.HttpStatusCode.Forbidden );
            }
        }
		
		/// <summary>
		/// Gets a GroupRole object
		/// </summary>
		[WebGet( UriTemplate = "{id}/{apiKey}" )]
        public Rock.Groups.DTO.GroupRole ApiGet( string id, string apiKey )
        {
            using (Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope())
            {
				Rock.CMS.UserService userService = new Rock.CMS.UserService();
                Rock.CMS.User user = userService.Queryable().Where( u => u.ApiKey == apiKey ).FirstOrDefault();

				if (user != null)
				{
					uow.objectContext.Configuration.ProxyCreationEnabled = false;
					Rock.Groups.GroupRoleService GroupRoleService = new Rock.Groups.GroupRoleService();
					Rock.Groups.GroupRole GroupRole = GroupRoleService.Get( int.Parse( id ) );
					if ( GroupRole.Authorized( "View", user ) )
						return GroupRole.DataTransferObject;
					else
						throw new WebFaultException<string>( "Not Authorized to View this GroupRole", System.Net.HttpStatusCode.Forbidden );
				}
				else
					throw new WebFaultException<string>( "Invalid API Key", System.Net.HttpStatusCode.Forbidden );
            }
        }
		
		/// <summary>
		/// Updates a GroupRole object
		/// </summary>
		[WebInvoke( Method = "PUT", UriTemplate = "{id}" )]
        public void UpdateGroupRole( string id, Rock.Groups.DTO.GroupRole GroupRole )
        {
            var currentUser = Rock.CMS.UserService.GetCurrentUser();
            if ( currentUser == null )
                throw new WebFaultException<string>("Must be logged in", System.Net.HttpStatusCode.Forbidden );

            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.Groups.GroupRoleService GroupRoleService = new Rock.Groups.GroupRoleService();
				Rock.Groups.GroupRole existingGroupRole = GroupRoleService.Get( int.Parse( id ) );
				if ( existingGroupRole.Authorized( "Edit", currentUser ) )
				{
					uow.objectContext.Entry(existingGroupRole).CurrentValues.SetValues(GroupRole);
					
					if (existingGroupRole.IsValid)
						GroupRoleService.Save( existingGroupRole, currentUser.PersonId );
					else
						throw new WebFaultException<string>( existingGroupRole.ValidationResults.AsDelimited(", "), System.Net.HttpStatusCode.BadRequest );
				}
				else
					throw new WebFaultException<string>( "Not Authorized to Edit this GroupRole", System.Net.HttpStatusCode.Forbidden );
            }
        }

		/// <summary>
		/// Updates a GroupRole object
		/// </summary>
		[WebInvoke( Method = "PUT", UriTemplate = "{id}/{apiKey}" )]
        public void ApiUpdateGroupRole( string id, string apiKey, Rock.Groups.DTO.GroupRole GroupRole )
        {
            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				Rock.CMS.UserService userService = new Rock.CMS.UserService();
                Rock.CMS.User user = userService.Queryable().Where( u => u.ApiKey == apiKey ).FirstOrDefault();

				if (user != null)
				{
					uow.objectContext.Configuration.ProxyCreationEnabled = false;
					Rock.Groups.GroupRoleService GroupRoleService = new Rock.Groups.GroupRoleService();
					Rock.Groups.GroupRole existingGroupRole = GroupRoleService.Get( int.Parse( id ) );
					if ( existingGroupRole.Authorized( "Edit", user ) )
					{
						uow.objectContext.Entry(existingGroupRole).CurrentValues.SetValues(GroupRole);
					
						if (existingGroupRole.IsValid)
							GroupRoleService.Save( existingGroupRole, user.PersonId );
						else
							throw new WebFaultException<string>( existingGroupRole.ValidationResults.AsDelimited(", "), System.Net.HttpStatusCode.BadRequest );
					}
					else
						throw new WebFaultException<string>( "Not Authorized to Edit this GroupRole", System.Net.HttpStatusCode.Forbidden );
				}
				else
					throw new WebFaultException<string>( "Invalid API Key", System.Net.HttpStatusCode.Forbidden );
            }
        }

		/// <summary>
		/// Creates a new GroupRole object
		/// </summary>
		[WebInvoke( Method = "POST", UriTemplate = "" )]
        public void CreateGroupRole( Rock.Groups.DTO.GroupRole GroupRole )
        {
            var currentUser = Rock.CMS.UserService.GetCurrentUser();
            if ( currentUser == null )
                throw new WebFaultException<string>("Must be logged in", System.Net.HttpStatusCode.Forbidden );

            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.Groups.GroupRoleService GroupRoleService = new Rock.Groups.GroupRoleService();
				Rock.Groups.GroupRole existingGroupRole = new Rock.Groups.GroupRole();
				GroupRoleService.Add( existingGroupRole, currentUser.PersonId );
				uow.objectContext.Entry(existingGroupRole).CurrentValues.SetValues(GroupRole);

				if (existingGroupRole.IsValid)
					GroupRoleService.Save( existingGroupRole, currentUser.PersonId );
				else
					throw new WebFaultException<string>( existingGroupRole.ValidationResults.AsDelimited(", "), System.Net.HttpStatusCode.BadRequest );
            }
        }

		/// <summary>
		/// Creates a new GroupRole object
		/// </summary>
		[WebInvoke( Method = "POST", UriTemplate = "{apiKey}" )]
        public void ApiCreateGroupRole( string apiKey, Rock.Groups.DTO.GroupRole GroupRole )
        {
            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				Rock.CMS.UserService userService = new Rock.CMS.UserService();
                Rock.CMS.User user = userService.Queryable().Where( u => u.ApiKey == apiKey ).FirstOrDefault();

				if (user != null)
				{
					uow.objectContext.Configuration.ProxyCreationEnabled = false;
					Rock.Groups.GroupRoleService GroupRoleService = new Rock.Groups.GroupRoleService();
					Rock.Groups.GroupRole existingGroupRole = new Rock.Groups.GroupRole();
					GroupRoleService.Add( existingGroupRole, user.PersonId );
					uow.objectContext.Entry(existingGroupRole).CurrentValues.SetValues(GroupRole);

					if (existingGroupRole.IsValid)
						GroupRoleService.Save( existingGroupRole, user.PersonId );
					else
						throw new WebFaultException<string>( existingGroupRole.ValidationResults.AsDelimited(", "), System.Net.HttpStatusCode.BadRequest );
				}
				else
					throw new WebFaultException<string>( "Invalid API Key", System.Net.HttpStatusCode.Forbidden );
            }
        }

		/// <summary>
		/// Deletes a GroupRole object
		/// </summary>
		[WebInvoke( Method = "DELETE", UriTemplate = "{id}" )]
        public void DeleteGroupRole( string id )
        {
            var currentUser = Rock.CMS.UserService.GetCurrentUser();
            if ( currentUser == null )
                throw new WebFaultException<string>("Must be logged in", System.Net.HttpStatusCode.Forbidden );

            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.Groups.GroupRoleService GroupRoleService = new Rock.Groups.GroupRoleService();
				Rock.Groups.GroupRole GroupRole = GroupRoleService.Get( int.Parse( id ) );
				if ( GroupRole.Authorized( "Edit", currentUser ) )
				{
					GroupRoleService.Delete( GroupRole, currentUser.PersonId );
					GroupRoleService.Save( GroupRole, currentUser.PersonId );
				}
				else
					throw new WebFaultException<string>( "Not Authorized to Edit this GroupRole", System.Net.HttpStatusCode.Forbidden );
            }
        }

		/// <summary>
		/// Deletes a GroupRole object
		/// </summary>
		[WebInvoke( Method = "DELETE", UriTemplate = "{id}/{apiKey}" )]
        public void ApiDeleteGroupRole( string id, string apiKey )
        {
            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				Rock.CMS.UserService userService = new Rock.CMS.UserService();
                Rock.CMS.User user = userService.Queryable().Where( u => u.ApiKey == apiKey ).FirstOrDefault();

				if (user != null)
				{
					uow.objectContext.Configuration.ProxyCreationEnabled = false;
					Rock.Groups.GroupRoleService GroupRoleService = new Rock.Groups.GroupRoleService();
					Rock.Groups.GroupRole GroupRole = GroupRoleService.Get( int.Parse( id ) );
					if ( GroupRole.Authorized( "Edit", user ) )
					{
						GroupRoleService.Delete( GroupRole, user.PersonId );
						GroupRoleService.Save( GroupRole, user.PersonId );
					}
					else
						throw new WebFaultException<string>( "Not Authorized to Edit this GroupRole", System.Net.HttpStatusCode.Forbidden );
				}
				else
					throw new WebFaultException<string>( "Invalid API Key", System.Net.HttpStatusCode.Forbidden );
            }
        }

    }
}
