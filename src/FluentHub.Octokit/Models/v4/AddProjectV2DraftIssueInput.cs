namespace FluentHub.Octokit.Models.v4
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Autogenerated input type of AddProjectV2DraftIssue
    /// </summary>
    public class AddProjectV2DraftIssueInput
    {        /// <summary>
        /// The ID of the Project to add the draft issue to.
        /// </summary>
        public ID ProjectId { get; set; }

        /// <summary>
        /// The title of the draft issue.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The body of the draft issue.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// The IDs of the assignees of the draft issue.
        /// </summary>
        public List<ID> AssigneeIds { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        public string ClientMutationId { get; set; }
    }
}