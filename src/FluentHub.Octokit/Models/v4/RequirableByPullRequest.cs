// Copyright (c) 2022-2024 0x5BFA
// Licensed under the MIT License. See the LICENSE.

namespace FluentHub.Octokit.Models.v4
{

	/// <summary>
	/// Represents a type that can be required by a pull request for merging.
	/// </summary>
	public interface IRequirableByPullRequest
	{
		/// <summary>
		/// Whether this is required to pass before merging for a specific pull request.
		/// </summary>
		/// <param name="pullRequestId">The id of the pull request this is required for</param>
		/// <param name="pullRequestNumber">The number of the pull request this is required for</param>
		bool IsRequired { get; set; }
	}
}

namespace FluentHub.Octokit.Models.v4
{
	public class RequirableByPullRequest : IRequirableByPullRequest
	{
		public bool IsRequired { get; set; }
	}
}

