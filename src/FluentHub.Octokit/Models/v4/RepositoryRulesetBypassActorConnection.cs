// Copyright (c) 2022-2024 0x5BFA
// Licensed under the MIT License. See the LICENSE.

namespace FluentHub.Octokit.Models.v4
{
	/// <summary>
	/// The connection type for RepositoryRulesetBypassActor.
	/// </summary>
	public class RepositoryRulesetBypassActorConnection
	{
		/// <summary>
		/// A list of edges.
		/// </summary>
		public List<RepositoryRulesetBypassActorEdge> Edges { get; set; }

		/// <summary>
		/// A list of nodes.
		/// </summary>
		public List<RepositoryRulesetBypassActor> Nodes { get; set; }

		/// <summary>
		/// Information to aid in pagination.
		/// </summary>
		public PageInfo PageInfo { get; set; }

		/// <summary>
		/// Identifies the total count of items in the connection.
		/// </summary>
		public int TotalCount { get; set; }
	}
}
