using System;

namespace Sion.Useful.Files.Attributes {
	[AttributeUsage(AttributeTargets.Property)]
	public class OutputFormatAttribute : Attribute {
		public string? Format { get; set; }

		public OutputFormatAttribute() {
			Format = null;
		}

		public OutputFormatAttribute(string format) {
			Format = format;
		}
	}
}
