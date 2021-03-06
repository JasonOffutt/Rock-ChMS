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

namespace Rock.CRM
{
	/// <summary>
	/// Person Trail POCO Service Layer class
	/// </summary>
    public partial class PersonTrailService : Service<Rock.CRM.PersonTrail>
    {
		/// <summary>
		/// Gets Person Trails by Current Guid
		/// </summary>
		/// <param name="currentGuid">Current Guid.</param>
		/// <returns>An enumerable list of PersonTrail objects.</returns>
	    public IEnumerable<Rock.CRM.PersonTrail> GetByCurrentGuid( Guid currentGuid )
        {
            return Repository.Find( t => t.CurrentGuid == currentGuid );
        }
		
		/// <summary>
		/// Gets Person Trails by Current Id
		/// </summary>
		/// <param name="currentId">Current Id.</param>
		/// <returns>An enumerable list of PersonTrail objects.</returns>
	    public IEnumerable<Rock.CRM.PersonTrail> GetByCurrentId( int currentId )
        {
            return Repository.Find( t => t.CurrentId == currentId );
        }
		
		/// <summary>
		/// Gets Person Trail by Guid
		/// </summary>
		/// <param name="guid">Guid.</param>
		/// <returns>PersonTrail object.</returns>
	    public Rock.CRM.PersonTrail GetByGuid( Guid guid )
        {
            return Repository.FirstOrDefault( t => t.Guid == guid );
        }
		
    }
}
