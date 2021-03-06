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
	/// Person POCO Service Layer class
	/// </summary>
    public partial class PersonService : Service<Rock.CRM.Person>
    {
		/// <summary>
		/// Gets Person by Guid
		/// </summary>
		/// <param name="guid">Guid.</param>
		/// <returns>Person object.</returns>
	    public Rock.CRM.Person GetByGuid( Guid guid )
        {
            return Repository.FirstOrDefault( t => t.Guid == guid );
        }
		
		/// <summary>
		/// Gets People by Email
		/// </summary>
		/// <param name="email">Email.</param>
		/// <returns>An enumerable list of Person objects.</returns>
	    public IEnumerable<Rock.CRM.Person> GetByEmail( string email )
        {
            return Repository.Find( t => ( t.Email == email || ( email == null && t.Email == null ) ) );
        }
		
    }
}
