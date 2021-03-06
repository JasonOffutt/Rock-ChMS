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

namespace Rock.Util
{
	/// <summary>
	/// Job POCO Service Layer class
	/// </summary>
    public partial class JobService : Service<Rock.Util.Job>
    {
		/// <summary>
		/// Gets Jobs by Guid
		/// </summary>
		/// <param name="guid">Guid of the job..</param>
		/// <returns>An enumerable list of Job objects.</returns>
	    public IEnumerable<Rock.Util.Job> GetByGuid( Guid guid )
        {
            return Repository.Find( t => t.Guid == guid );
        }
		
    }
}
