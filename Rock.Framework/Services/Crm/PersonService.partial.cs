using System.Security.Principal;
using Rock.Helpers;
using Rock.Models.Crm;

namespace Rock.Services.Crm
{
    public partial class PersonService
    {
        public bool IsAllowedTo(OperationType operationType, Person person, IPrincipal user)
        {
            // TODO: Hook into Authorization functionality
            return true;
        }
    }
}