// Copyright (c) 2022-2024 0x5BFA
// Licensed under the MIT License. See the LICENSE.

namespace FluentHub.Octokit.Models.v4
{
	/// <summary>
	/// Autogenerated return type of CreateSponsorsTier
	/// </summary>
	public class CreateSponsorsTierPayload
	{
		/// <summary>
		/// A unique identifier for the client performing the mutation.
		/// </summary>
		public string ClientMutationId { get; set; }

		/// <summary>
		/// The new tier.
		/// </summary>
		public SponsorsTier SponsorsTier { get; set; }
	}
}
