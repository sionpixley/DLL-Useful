using Sion.Useful.Files.Attributes;
using System;

namespace Tests.Classes {
	public class Student {
		public long Id { get; set; }
		public string FirstName { get; set; }
		public string? MiddleName { get; set; }
		public string LastName { get; set; }
		public bool HasGraduated { get; set; }

		[OutputFormat("yyyy-MM-ddTHH:mm:ss.fff")]
		public DateTime? GraduationDate { get; set; }

		public Student() {
			Id = 0;
			FirstName = "";
			MiddleName = null;
			LastName = "";
			HasGraduated = false;
			GraduationDate = null;
		}

		public override bool Equals(object? that) {
			if(this == null && that == null) {
				return true;
			}
			else if(this == null || that == null) {
				return false;
			}
			else {
				Student obj = (that as Student)!;
				return Id == obj.Id
					&& FirstName == obj.FirstName
					&& MiddleName == obj.MiddleName
					&& LastName == obj.LastName
					&& HasGraduated == obj.HasGraduated
					&& GraduationDate == obj.GraduationDate;
			}
		}

		public override int GetHashCode() {
			return HashCode.Combine(Id, FirstName, MiddleName, LastName, HasGraduated, GraduationDate);
		}
	}
}
