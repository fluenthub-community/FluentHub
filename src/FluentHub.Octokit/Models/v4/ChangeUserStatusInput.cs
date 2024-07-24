// Copyright (c) 2022-2024 0x5BFA
// Licensed under the MIT License. See the LICENSE.

namespace FluentHub.Octokit.Models.v4
{
	/// <summary>
	/// Autogenerated input type of ChangeUserStatus
	/// </summary>
	public class ChangeUserStatusInput
	{
		/// <summary>
		/// A unique identifier for the client performing the mutation.
		/// </summary>
		public string ClientMutationId { get; set; }

		/// <summary>
		/// The emoji to represent your status. Can either be a native Unicode emoji or an emoji name with colons, e.g., :grinning:.
		/// </summary>
		public string Emoji { get; set; }

		/// <summary>
		/// A short description of your current status.
		/// </summary>
		public string Message { get; set; }

		/// <summary>
		/// The ID of the organization whose members will be allowed to see the status. If omitted, the status will be publicly visible.
		/// </summary>
		public ID? OrganizationId { get; set; }

		/// <summary>
		/// Whether this status should indicate you are not fully available on GitHub, e.g., you are away.
		/// </summary>
		public bool? LimitedAvailability { get; set; }

		/// <summary>
		/// If set, the user status will not be shown after this date.
		/// </summary>
		public DateTimeOffset? ExpiresAt { get; set; }
	}
}
