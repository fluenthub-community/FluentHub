namespace FluentHub.Octokit.Models.v4
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    /// <summary>
    /// Autogenerated return type of UpdateEnterpriseMembersCanChangeRepositoryVisibilitySetting
    /// </summary>
    public class UpdateEnterpriseMembersCanChangeRepositoryVisibilitySettingPayload
    {
        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        public string ClientMutationId { get; set; }

        /// <summary>
        /// The enterprise with the updated members can change repository visibility setting.
        /// </summary>
        public Enterprise Enterprise { get; set; }

        /// <summary>
        /// A message confirming the result of updating the members can change repository visibility setting.
        /// </summary>
        public string Message { get; set; }
    }
}