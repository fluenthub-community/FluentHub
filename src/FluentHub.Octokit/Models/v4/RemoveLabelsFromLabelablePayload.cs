namespace FluentHub.Octokit.Models.v4
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    /// <summary>
    /// Autogenerated return type of RemoveLabelsFromLabelable
    /// </summary>
    public class RemoveLabelsFromLabelablePayload
    {
        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        public string ClientMutationId { get; set; }

        /// <summary>
        /// The Labelable the labels were removed from.
        /// </summary>
        public ILabelable Labelable { get; set; }
    }
}