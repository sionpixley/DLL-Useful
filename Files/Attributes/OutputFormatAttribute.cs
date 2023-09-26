using System;

namespace Sion.Useful.Files.Attributes {
	[AttributeUsage(AttributeTargets.Property)]
	/// <summary>
	/// Use this attribute to change the output format of your DateTime properties when using Sion.Useful.Files.Csv.Write.
	/// </summary>
	public class OutputFormatAttribute : Attribute {

		/// <summary>
		/// The property that changes output format when using Sion.Useful.Files.Csv.Write.
		/// </summary>
		public string? Format { get; set; }

		/// <summary>
		/// Sets the Format property to its default null state.
		/// </summary>
		public OutputFormatAttribute() {
			Format = null;
		}

		/// <summary>
		/// Sets the Format property to the provided format.
		/// </summary>
		/// <param name="format">The format you want to use for your DateTime properties.</param>
		public OutputFormatAttribute(string format) {
			Format = format;
		}
	}
}
