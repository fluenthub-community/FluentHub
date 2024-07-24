// Copyright (c) 2022-2024 0x5BFA
// Licensed under the MIT License. See the LICENSE.

namespace FluentHub.Octokit.Models.v4
{

	/// <summary>
	/// Represents an author of discussion comments in repositories.
	/// </summary>
	public interface IRepositoryDiscussionCommentAuthor
	{
		/// <summary>
		/// Discussion comments this user has authored.
		/// </summary>
		/// <param name="first">Returns the first _n_ elements from the list.</param>
		/// <param name="after">Returns the elements in the list that come after the specified cursor.</param>
		/// <param name="last">Returns the last _n_ elements from the list.</param>
		/// <param name="before">Returns the elements in the list that come before the specified cursor.</param>
		/// <param name="onlyAnswers">Filter discussion comments to only those that were marked as the answer</param>
		/// <param name="repositoryId">Filter discussion comments to only those in a specific repository.</param>
		DiscussionCommentConnection RepositoryDiscussionComments { get; set; }
	}
}

namespace FluentHub.Octokit.Models.v4
{
	public class RepositoryDiscussionCommentAuthor : IRepositoryDiscussionCommentAuthor
	{
		public DiscussionCommentConnection RepositoryDiscussionComments { get; set; }
	}
}

