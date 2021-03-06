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
using System;
using System.Collections.Generic;
using System.Linq;

using Rock.Data;

namespace Rock.CMS
{
	/// <summary>
	/// Site Domain POCO Service Layer class
	/// </summary>
    public partial class SiteDomainService : Service<Rock.CMS.SiteDomain>
    {
		/// <summary>
		/// Gets Site Domain by Domain
		/// </summary>
		/// <param name="domain">Domain.</param>
		/// <returns>SiteDomain object.</returns>
	    public Rock.CMS.SiteDomain GetByDomain( string domain )
        {
            return Repository.FirstOrDefault( t => t.Domain == domain );
        }
		
		/// <summary>
		/// Gets Site Domains by Guid
		/// </summary>
		/// <param name="guid">Guid.</param>
		/// <returns>An enumerable list of SiteDomain objects.</returns>
	    public IEnumerable<Rock.CMS.SiteDomain> GetByGuid( Guid guid )
        {
            return Repository.Find( t => t.Guid == guid );
        }
		
		/// <summary>
		/// Gets Site Domains by Site Id And Domain
		/// </summary>
		/// <param name="siteId">Site Id.</param>
		/// <param name="domain">Domain.</param>
		/// <returns>An enumerable list of SiteDomain objects.</returns>
	    public IEnumerable<Rock.CMS.SiteDomain> GetBySiteIdAndDomain( int siteId, string domain )
        {
            return Repository.Find( t => t.SiteId == siteId && t.Domain == domain );
        }
		
    }
}
