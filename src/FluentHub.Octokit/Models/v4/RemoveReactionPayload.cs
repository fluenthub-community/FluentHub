// Copyright (c) 2022-2024 0x5BFA
// Licensed under the MIT License. See the LICENSE.

namespace FluentHub.Octokit.Models.v4
{
	/// <summary>
	/// Autogenerated return type of RemoveReaction
	/// </summary>
	public class RemoveReactionPayload
	{
		/// <summary>
		/// A unique identifier for the client performing the mutation.
		/// </summary>
		public string ClientMutationId { get; set; }

		/// <summary>
		/// The reaction object.
		/// </summary>
		public Reaction Reaction { get; set; }

		/// <summary>
		/// The reaction groups for the subject.
		/// </summary>
		public List<ReactionGroup> ReactionGroups { get; set; }

		/// <summary>
		/// The reactable subject.
		/// </summary>
		public IReactable Subject { get; set; }
	}
}
