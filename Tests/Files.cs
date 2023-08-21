using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sion.Useful.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tests.Classes;

namespace Tests {
	[TestClass]
	public class Files {
		private readonly string[][] _ExpectedNoType = {
			new string[] { "1", "Landon", "Jameson", "Smith", "false", "null" },
			new string[] { "2", "Avery", "Eliza,beth", "Davis", "true", "2000-05-14T17:00:00.000" },
			new string[] { "3", "Ethan", "", "John\"son", "false", "" },
			new string[] { "4", "Mia", "Grace", "Rodriguez", "false", "null" },
			new string[] { "5", "Oliver", "William", "Brown", "true", "2002-05-23T16:00:00.000" },
			new string[] { "6", "Aria", "Rose", "Hernandez", "false", "null" },
			new string[] { "7", "Caleb", "Alexander", "Lee", "true", "2003-05-16T13:30:00.000" },
			new string[] { "8", "Lila", "Madison", "Turner", "false", "null" }
		};

		private readonly Student[] _ExpectedType = {
			new Student() {
				Id = 1,
				FirstName = "Landon",
				MiddleName = "Jameson",
				LastName = "Smith",
				HasGraduated = false,
				GraduationDate = null
			},
			new Student() {
				Id = 2,
				FirstName = "Avery",
				MiddleName = "Eliza,beth",
				LastName = "Davis",
				HasGraduated = true,
				GraduationDate = Convert.ToDateTime("2000-05-14T17:00:00.000")
			},
			new Student() {
				Id = 3,
				FirstName = "Ethan",
				MiddleName = null,
				LastName = "John\"son",
				HasGraduated = false,
				GraduationDate = null
			},
			new Student() {
				 Id = 4,
				 FirstName = "Mia",
				 MiddleName = "Grace",
				 LastName = "Rodriguez",
				 HasGraduated = false,
				GraduationDate = null
			},
			new Student() {
				Id = 5,
				FirstName = "Oliver",
				MiddleName = "William",
				LastName = "Brown",
				HasGraduated = true,
				GraduationDate = Convert.ToDateTime("2002-05-23T16:00:00.000")
			},
			new Student() {
				Id = 6,
				FirstName = "Aria",
				MiddleName = "Rose",
				LastName = "Hernandez",
				HasGraduated = false,
				GraduationDate = null
			},
			new Student() {
				Id = 7,
				FirstName = "Caleb",
				MiddleName = "Alexander",
				LastName = "Lee",
				HasGraduated = true,
				GraduationDate = Convert.ToDateTime("2003-05-16T13:30:00.000")
			},
			new Student() {
				Id = 8,
				FirstName = "Lila",
				MiddleName = "Madison",
				LastName = "Turner",
				HasGraduated = false,
				GraduationDate = null
			}
		};

		[TestMethod]
		public void Csv_Read_HeaderNoType() {
			try {
				string[][] actual = Csv.Read(@".\assets\students.csv", hasHeader: true).ToArray();

				bool areEqual = false;
				for(int i = 0; i < _ExpectedNoType.Length; i += 1) {
					areEqual = _ExpectedNoType[i].SequenceEqual(actual[i]);
					if(!areEqual) {
						break;
					}
				}

				Assert.IsTrue(areEqual);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void Csv_Read_HeaderType() {
			try {
				IEnumerable<Student> actual = Csv.Read<Student>(@".\assets\students.csv", hasHeader: true);
				Assert.IsTrue(_ExpectedType.SequenceEqual(actual));
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void Csv_Read_HeaderTypeCustomMapping() {
			try {
				IEnumerable<Student> actual = Csv.Read(
					@".\assets\students.csv",
					(string[] row) => {
						return new Student() {
							Id = Convert.ToInt64(row[0]),
							FirstName = row[1],
							MiddleName = row[2] == "null" || String.IsNullOrWhiteSpace(row[2]) ? null : row[2],
							LastName = row[3],
							HasGraduated = Convert.ToBoolean(row[4]),
							GraduationDate = row[5] == "null" || String.IsNullOrWhiteSpace(row[5]) ? null : Convert.ToDateTime(row[5])
						};
					},
					hasHeader: true
				);

				Assert.IsTrue(_ExpectedType.SequenceEqual(actual));
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void Csv_Write_NoType() {
			try {
				Csv.Write(_ExpectedNoType, @".\assets\students2.csv");
				string[][] actual = Csv.Read(@".\assets\students2.csv", hasHeader: false).ToArray();

				bool areEqual = false;
				for(int i = 0; i < _ExpectedNoType.Length; i += 1) {
					areEqual = _ExpectedNoType[i].SequenceEqual(actual[i]);
					if(!areEqual) {
						break;
					}
				}

				Assert.IsTrue(areEqual);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public async Task Csv_WriteAsync_NoType() {
			try {
				await Csv.WriteAsync(_ExpectedNoType, @".\assets\students2.csv");
				string[][] actual = Csv.Read(@".\assets\students2.csv", hasHeader: false).ToArray();

				bool areEqual = false;
				for(int i = 0; i < _ExpectedNoType.Length; i += 1) {
					areEqual = _ExpectedNoType[i].SequenceEqual(actual[i]);
					if(!areEqual) {
						break;
					}
				}

				Assert.IsTrue(areEqual);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}
	}
}
