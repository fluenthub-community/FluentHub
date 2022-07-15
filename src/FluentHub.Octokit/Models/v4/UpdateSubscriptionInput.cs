namespace FluentHub.Octokit.Models.v4
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Autogenerated input type of UpdateSubscription
    /// </summary>
    public class UpdateSubscriptionInput
    {        /// <summary>
        /// The Node ID of the subscribable object to modify.
        /// </summary>
        public ID SubscribableId { get; set; }

        /// <summary>
        /// The new state of the subscription.
        /// </summary>
        public SubscriptionState State { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        public string ClientMutationId { get; set; }
    }
}