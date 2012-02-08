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
	/// REST WCF service for Blocks
	/// </summary>
    [Export(typeof(IService))]
    [ExportMetadata("RouteName", "CMS/Block")]
	[AspNetCompatibilityRequirements( RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed )]
    public partial class BlockService : IBlockService, IService
    {
		/// <summary>
		/// Gets a Block object
		/// </summary>
		[WebGet( UriTemplate = "{id}" )]
        public Rock.CMS.DTO.Block Get( string id )
        {
            var currentUser = Rock.CMS.UserService.GetCurrentUser();
            if ( currentUser == null )
                throw new WebFaultException<string>("Must be logged in", System.Net.HttpStatusCode.Forbidden );

            using (Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope())
            {
				uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.CMS.BlockService BlockService = new Rock.CMS.BlockService();
				Rock.CMS.Block Block = BlockService.Get( int.Parse( id ) );
				if ( Block.Authorized( "View", currentUser ) )
					return Block.DataTransferObject;
				else
					throw new WebFaultException<string>( "Not Authorized to View this Block", System.Net.HttpStatusCode.Forbidden );
            }
        }
		
		/// <summary>
		/// Gets a Block object
		/// </summary>
		[WebGet( UriTemplate = "{id}/{apiKey}" )]
        public Rock.CMS.DTO.Block ApiGet( string id, string apiKey )
        {
            using (Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope())
            {
				Rock.CMS.UserService userService = new Rock.CMS.UserService();
                Rock.CMS.User user = userService.Queryable().Where( u => u.ApiKey == apiKey ).FirstOrDefault();

				if (user != null)
				{
					uow.objectContext.Configuration.ProxyCreationEnabled = false;
					Rock.CMS.BlockService BlockService = new Rock.CMS.BlockService();
					Rock.CMS.Block Block = BlockService.Get( int.Parse( id ) );
					if ( Block.Authorized( "View", user.UserName ) )
						return Block.DataTransferObject;
					else
						throw new WebFaultException<string>( "Not Authorized to View this Block", System.Net.HttpStatusCode.Forbidden );
				}
				else
					throw new WebFaultException<string>( "Invalid API Key", System.Net.HttpStatusCode.Forbidden );
            }
        }
		
		/// <summary>
		/// Updates a Block object
		/// </summary>
		[WebInvoke( Method = "PUT", UriTemplate = "{id}" )]
        public void UpdateBlock( string id, Rock.CMS.DTO.Block Block )
        {
            var currentUser = Rock.CMS.UserService.GetCurrentUser();
            if ( currentUser == null )
                throw new WebFaultException<string>("Must be logged in", System.Net.HttpStatusCode.Forbidden );

            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.CMS.BlockService BlockService = new Rock.CMS.BlockService();
				Rock.CMS.Block existingBlock = BlockService.Get( int.Parse( id ) );
				if ( existingBlock.Authorized( "Edit", currentUser ) )
				{
					uow.objectContext.Entry(existingBlock).CurrentValues.SetValues(Block);
					
					if (existingBlock.IsValid)
						BlockService.Save( existingBlock, currentUser.PersonId );
					else
						throw new WebFaultException<string>( existingBlock.ValidationResults.AsDelimited(", "), System.Net.HttpStatusCode.BadRequest );
				}
				else
					throw new WebFaultException<string>( "Not Authorized to Edit this Block", System.Net.HttpStatusCode.Forbidden );
            }
        }

		/// <summary>
		/// Updates a Block object
		/// </summary>
		[WebInvoke( Method = "PUT", UriTemplate = "{id}/{apiKey}" )]
        public void ApiUpdateBlock( string id, string apiKey, Rock.CMS.DTO.Block Block )
        {
            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				Rock.CMS.UserService userService = new Rock.CMS.UserService();
                Rock.CMS.User user = userService.Queryable().Where( u => u.ApiKey == apiKey ).FirstOrDefault();

				if (user != null)
				{
					uow.objectContext.Configuration.ProxyCreationEnabled = false;
					Rock.CMS.BlockService BlockService = new Rock.CMS.BlockService();
					Rock.CMS.Block existingBlock = BlockService.Get( int.Parse( id ) );
					if ( existingBlock.Authorized( "Edit", user.UserName ) )
					{
						uow.objectContext.Entry(existingBlock).CurrentValues.SetValues(Block);
					
						if (existingBlock.IsValid)
							BlockService.Save( existingBlock, user.PersonId );
						else
							throw new WebFaultException<string>( existingBlock.ValidationResults.AsDelimited(", "), System.Net.HttpStatusCode.BadRequest );
					}
					else
						throw new WebFaultException<string>( "Not Authorized to Edit this Block", System.Net.HttpStatusCode.Forbidden );
				}
				else
					throw new WebFaultException<string>( "Invalid API Key", System.Net.HttpStatusCode.Forbidden );
            }
        }

		/// <summary>
		/// Creates a new Block object
		/// </summary>
		[WebInvoke( Method = "POST", UriTemplate = "" )]
        public void CreateBlock( Rock.CMS.DTO.Block Block )
        {
            var currentUser = Rock.CMS.UserService.GetCurrentUser();
            if ( currentUser == null )
                throw new WebFaultException<string>("Must be logged in", System.Net.HttpStatusCode.Forbidden );

            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.CMS.BlockService BlockService = new Rock.CMS.BlockService();
				Rock.CMS.Block existingBlock = new Rock.CMS.Block();
				BlockService.Add( existingBlock, currentUser.PersonId );
				uow.objectContext.Entry(existingBlock).CurrentValues.SetValues(Block);

				if (existingBlock.IsValid)
					BlockService.Save( existingBlock, currentUser.PersonId );
				else
					throw new WebFaultException<string>( existingBlock.ValidationResults.AsDelimited(", "), System.Net.HttpStatusCode.BadRequest );
            }
        }

		/// <summary>
		/// Creates a new Block object
		/// </summary>
		[WebInvoke( Method = "POST", UriTemplate = "{apiKey}" )]
        public void ApiCreateBlock( string apiKey, Rock.CMS.DTO.Block Block )
        {
            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				Rock.CMS.UserService userService = new Rock.CMS.UserService();
                Rock.CMS.User user = userService.Queryable().Where( u => u.ApiKey == apiKey ).FirstOrDefault();

				if (user != null)
				{
					uow.objectContext.Configuration.ProxyCreationEnabled = false;
					Rock.CMS.BlockService BlockService = new Rock.CMS.BlockService();
					Rock.CMS.Block existingBlock = new Rock.CMS.Block();
					BlockService.Add( existingBlock, user.PersonId );
					uow.objectContext.Entry(existingBlock).CurrentValues.SetValues(Block);

					if (existingBlock.IsValid)
						BlockService.Save( existingBlock, user.PersonId );
					else
						throw new WebFaultException<string>( existingBlock.ValidationResults.AsDelimited(", "), System.Net.HttpStatusCode.BadRequest );
				}
				else
					throw new WebFaultException<string>( "Invalid API Key", System.Net.HttpStatusCode.Forbidden );
            }
        }

		/// <summary>
		/// Deletes a Block object
		/// </summary>
		[WebInvoke( Method = "DELETE", UriTemplate = "{id}" )]
        public void DeleteBlock( string id )
        {
            var currentUser = Rock.CMS.UserService.GetCurrentUser();
            if ( currentUser == null )
                throw new WebFaultException<string>("Must be logged in", System.Net.HttpStatusCode.Forbidden );

            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.CMS.BlockService BlockService = new Rock.CMS.BlockService();
				Rock.CMS.Block Block = BlockService.Get( int.Parse( id ) );
				if ( Block.Authorized( "Edit", currentUser ) )
				{
					BlockService.Delete( Block, currentUser.PersonId );
					BlockService.Save( Block, currentUser.PersonId );
				}
				else
					throw new WebFaultException<string>( "Not Authorized to Edit this Block", System.Net.HttpStatusCode.Forbidden );
            }
        }

		/// <summary>
		/// Deletes a Block object
		/// </summary>
		[WebInvoke( Method = "DELETE", UriTemplate = "{id}/{apiKey}" )]
        public void ApiDeleteBlock( string id, string apiKey )
        {
            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				Rock.CMS.UserService userService = new Rock.CMS.UserService();
                Rock.CMS.User user = userService.Queryable().Where( u => u.ApiKey == apiKey ).FirstOrDefault();

				if (user != null)
				{
					uow.objectContext.Configuration.ProxyCreationEnabled = false;
					Rock.CMS.BlockService BlockService = new Rock.CMS.BlockService();
					Rock.CMS.Block Block = BlockService.Get( int.Parse( id ) );
					if ( Block.Authorized( "Edit", user.UserName ) )
					{
						BlockService.Delete( Block, user.PersonId );
						BlockService.Save( Block, user.PersonId );
					}
					else
						throw new WebFaultException<string>( "Not Authorized to Edit this Block", System.Net.HttpStatusCode.Forbidden );
				}
				else
					throw new WebFaultException<string>( "Invalid API Key", System.Net.HttpStatusCode.Forbidden );
            }
        }

    }
}