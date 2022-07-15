namespace FluentHub.Octokit.Models.v4
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    /// <summary>
    /// Autogenerated return type of InviteEnterpriseAdmin
    /// </summary>
    public class InviteEnterpriseAdminPayload
    {
        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        public string ClientMutationId { get; set; }

        /// <summary>
        /// The created enterprise administrator invitation.
        /// </summary>
        public EnterpriseAdministratorInvitation Invitation { get; set; }
    }
}