namespace FluentHub.Octokit.Models.v4
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Autogenerated input type of UpdateProjectCard
    /// </summary>
    public class UpdateProjectCardInput
    {
        /// <summary>
        /// The ProjectCard ID to update.
        /// </summary>
        public ID ProjectCardId { get; set; }

        /// <summary>
        /// Whether or not the ProjectCard should be archived
        /// </summary>
        public bool? IsArchived { get; set; }

        /// <summary>
        /// The note of ProjectCard.
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        public string ClientMutationId { get; set; }
    }
}