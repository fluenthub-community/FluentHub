// Copyright (c) 2022-2024 0x5BFA
// Licensed under the MIT License. See the LICENSE.

namespace FluentHub.Octokit.Models.v4
{
	/// <summary>
	/// Autogenerated input type of RemoveEnterpriseMember
	/// </summary>
	public class RemoveEnterpriseMemberInput
	{
		/// <summary>
		/// A unique identifier for the client performing the mutation.
		/// </summary>
		public string ClientMutationId { get; set; }

		/// <summary>
		/// The ID of the enterprise from which the user should be removed.
		/// </summary>
		public ID EnterpriseId { get; set; }

		/// <summary>
		/// The ID of the user to remove from the enterprise.
		/// </summary>
		public ID UserId { get; set; }
	}
}
