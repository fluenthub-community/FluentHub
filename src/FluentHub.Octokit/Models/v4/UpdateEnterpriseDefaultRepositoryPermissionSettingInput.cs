namespace FluentHub.Octokit.Models.v4
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Autogenerated input type of UpdateEnterpriseDefaultRepositoryPermissionSetting
    /// </summary>
    public class UpdateEnterpriseDefaultRepositoryPermissionSettingInput
    {        /// <summary>
        /// The ID of the enterprise on which to set the base repository permission setting.
        /// </summary>
        public ID EnterpriseId { get; set; }

        /// <summary>
        /// The value for the base repository permission setting on the enterprise.
        /// </summary>
        public EnterpriseDefaultRepositoryPermissionSettingValue SettingValue { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        public string ClientMutationId { get; set; }
    }
}