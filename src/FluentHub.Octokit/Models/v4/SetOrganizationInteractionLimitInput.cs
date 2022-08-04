namespace FluentHub.Octokit.Models.v4
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Autogenerated input type of SetOrganizationInteractionLimit
    /// </summary>
    public class SetOrganizationInteractionLimitInput
    {
        /// <summary>
        /// The ID of the organization to set a limit for.
        /// </summary>
        public ID OrganizationId { get; set; }

        /// <summary>
        /// The limit to set.
        /// </summary>
        public RepositoryInteractionLimit Limit { get; set; }

        /// <summary>
        /// When this limit should expire.
        /// </summary>
        public RepositoryInteractionLimitExpiry? Expiry { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        public string ClientMutationId { get; set; }
    }
}