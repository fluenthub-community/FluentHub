namespace FluentHub.Octokit.Models.v4
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Autogenerated input type of UpdateProjectV2ItemFieldValue
    /// </summary>
    public class UpdateProjectV2ItemFieldValueInput
    {        /// <summary>
        /// The ID of the Project.
        /// </summary>
        public ID ProjectId { get; set; }

        /// <summary>
        /// The ID of the item to be updated.
        /// </summary>
        public ID ItemId { get; set; }

        /// <summary>
        /// The ID of the field to be updated.
        /// </summary>
        public ID FieldId { get; set; }

        /// <summary>
        /// The value which will be set on the field.
        /// </summary>
        public ProjectV2FieldValue Value { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        public string ClientMutationId { get; set; }
    }
}