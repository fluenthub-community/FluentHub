namespace FluentHub.Octokit.Models.v4
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Autogenerated input type of ClosePullRequest
    /// </summary>
    public class ClosePullRequestInput
    {
        /// <summary>
        /// ID of the pull request to be closed.
        /// </summary>
        public ID PullRequestId { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        public string ClientMutationId { get; set; }
    }
}