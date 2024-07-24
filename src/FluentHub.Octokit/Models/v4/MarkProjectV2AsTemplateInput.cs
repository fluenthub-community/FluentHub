// Copyright (c) 2022-2024 0x5BFA
// Licensed under the MIT License. See the LICENSE.

namespace FluentHub.Octokit.Models.v4
{
	/// <summary>
	/// Autogenerated input type of MarkProjectV2AsTemplate
	/// </summary>
	public class MarkProjectV2AsTemplateInput
	{
		/// <summary>
		/// A unique identifier for the client performing the mutation.
		/// </summary>
		public string ClientMutationId { get; set; }

		/// <summary>
		/// The ID of the Project to mark as a template.
		/// </summary>
		public ID ProjectId { get; set; }
	}
}
