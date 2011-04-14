using System;
using System.Web.Security;

namespace Rock.Helpers
{
    public static class MembershipHelper
    {
        public static MembershipUser GetMembershipUserFromModel(string providerName, Rock.Models.Cms.User user)
        {
            DateTime now = DateTime.Now;

            return new MembershipUser(
                providerName,
                user.Username,
                user.PersonId,
                user.Email,
                user.PasswordQuestion,
                user.Comment,
                user.IsApproved ?? true,
                user.IsLockedOut ?? false,
                user.CreationDate ?? now,
                user.LastLoginDate ?? now,
                user.LastActivityDate ?? now,
                user.LastPasswordChangedDate ?? now,
                user.LastLockedOutDate ?? now);
        }
    }
}