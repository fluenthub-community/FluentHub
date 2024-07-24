// Copyright (c) 2022-2024 0x5BFA
// Licensed under the MIT License. See the LICENSE.

namespace FluentHub.Octokit.Models.v4
{
	/// <summary>
	/// The value of a number field in a Project item.
	/// </summary>
	public class ProjectV2ItemFieldNumberValue
	{
		/// <summary>
		/// Identifies the date and time when the object was created.
		/// </summary>
		public DateTimeOffset CreatedAt { get; set; }

		/// <summary>
		/// Humanized string of "Identifies the date and time when the object was created."
		/// <summary>
		public string CreatedAtHumanized { get; set; }

		/// <summary>
		/// The actor who created the item.
		/// </summary>
		public IActor Creator { get; set; }

		/// <summary>
		/// Identifies the primary key from the database.
		/// </summary>
		public int? DatabaseId { get; set; }

		/// <summary>
		/// The project field that contains this value.
		/// </summary>
		public ProjectV2FieldConfiguration Field { get; set; }

		/// <summary>
		/// The Node ID of the ProjectV2ItemFieldNumberValue object
		/// </summary>
		public ID Id { get; set; }

		/// <summary>
		/// The project item that contains this value.
		/// </summary>
		public ProjectV2Item Item { get; set; }

		/// <summary>
		/// Number as a float(8)
		/// </summary>
		public double? Number { get; set; }

		/// <summary>
		/// Identifies the date and time when the object was last updated.
		/// </summary>
		public DateTimeOffset UpdatedAt { get; set; }

		/// <summary>
		/// Humanized string of "Identifies the date and time when the object was last updated."
		/// <summary>
		public string UpdatedAtHumanized { get; set; }
	}
}
