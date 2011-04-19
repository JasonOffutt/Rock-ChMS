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
using System.Text;

using Rock.Models.Groups;
using Rock.Repository.Groups;

namespace Rock.Services.Groups
{
    public partial class MemberService : Rock.Services.Service
    {
        private IMemberRepository _repository;

        public MemberService()
			: this( new EntityMemberRepository() )
        { }

        public MemberService( IMemberRepository MemberRepository )
        {
            _repository = MemberRepository;
        }

        public IQueryable<Rock.Models.Groups.Member> Queryable()
        {
            return _repository.AsQueryable();
        }

        public Rock.Models.Groups.Member GetMember( int id )
        {
            return _repository.FirstOrDefault( t => t.Id == id );
        }
		
        public IEnumerable<Rock.Models.Groups.Member> GetMembersByGroupId( int groupId )
        {
            return _repository.Find( t => t.GroupId == groupId );
        }
		
        public IEnumerable<Rock.Models.Groups.Member> GetMembersByGuid( Guid guid )
        {
            return _repository.Find( t => t.Guid == guid );
        }
		
        public IEnumerable<Rock.Models.Groups.Member> GetMembersByPersonId( int personId )
        {
            return _repository.Find( t => t.PersonId == personId );
        }
		
        public void AddMember( Rock.Models.Groups.Member Member )
        {
            if ( Member.Guid == Guid.Empty )
                Member.Guid = Guid.NewGuid();

            _repository.Add( Member );
        }

        public void DeleteMember( Rock.Models.Groups.Member Member )
        {
            _repository.Delete( Member );
        }

        public void Save( Rock.Models.Groups.Member Member, int? personId )
        {
            List<Rock.Models.Core.EntityChange> entityChanges = _repository.Save( Member, personId );

			if ( entityChanges != null )
            {
                Rock.Services.Core.EntityChangeService entityChangeService = new Rock.Services.Core.EntityChangeService();

                foreach ( Rock.Models.Core.EntityChange entityChange in entityChanges )
                {
                    entityChange.EntityId = Member.Id;
                    entityChangeService.AddEntityChange ( entityChange );
                    entityChangeService.Save( entityChange, personId );
                }
            }
        }
    }
}