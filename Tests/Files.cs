using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sion.Useful.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using Tests.Classes;

namespace Tests {
	[TestClass]
	public class Files {
		[TestMethod]
		public void Csv_Read_HeaderNoType() {
			try {
				string[][] expected = {
					new string[] { "1", "Landon", "Jameson", "Smith", "false" },
					new string[] { "2", "Avery", "Eliza,beth", "Davis", "true" },
					new string[] { "3", "Ethan", "", "John\"son", "false" },
					new string[] { "4", "Mia", "Grace", "Rodriguez", "false" },
					new string[] { "5", "Oliver", "William", "Brown", "true" },
					new string[] { "6", "Aria", "Rose", "Hernandez", "false" },
					new string[] { "7", "Caleb", "Alexander", "Lee", "true" },
					new string[] { "8", "Lila", "Madison", "Turner", "false" }
				};
				string[][] actual = Csv.Read(@".\assets\students.csv", hasHeader: true).ToArray();

				bool areEqual = false;
				for(int i = 0; i < expected.Length; i += 1) {
					areEqual = expected[i].SequenceEqual(actual[i]);
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
				Student[] expected = {
					new Student() {
						Id = 1,
						FirstName = "Landon",
						MiddleName = "Jameson",
						LastName = "Smith",
						IsGraduateStudent = false
					},
					new Student() {
						Id = 2,
						FirstName = "Avery",
						MiddleName = "Eliza,beth",
						LastName = "Davis",
						IsGraduateStudent = true
					},
					new Student() {
						Id = 3,
						FirstName = "Ethan",
						MiddleName = null,
						LastName = "John\"son",
						IsGraduateStudent = false
					},
					new Student() {
						 Id = 4,
						 FirstName = "Mia",
						 MiddleName = "Grace",
						 LastName = "Rodriguez",
						 IsGraduateStudent = false
					},
					new Student() {
						Id = 5,
						FirstName = "Oliver",
						MiddleName = "William",
						LastName = "Brown",
						IsGraduateStudent = true
					},
					new Student() {
						Id = 6,
						FirstName = "Aria",
						MiddleName = "Rose",
						LastName = "Hernandez",
						IsGraduateStudent = false
					},
					new Student() {
						Id = 7,
						FirstName = "Caleb",
						MiddleName = "Alexander",
						LastName = "Lee",
						IsGraduateStudent = true
					},
					new Student() {
						Id = 8,
						FirstName = "Lila",
						MiddleName = "Madison",
						LastName = "Turner",
						IsGraduateStudent = false
					}
				};

				IEnumerable<Student> actual = Csv.Read<Student>(@".\assets\students.csv", hasHeader: true);
				Assert.IsTrue(expected.SequenceEqual(actual));
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void Csv_Read_HeaderTypeCustomMapping() {
			try {
				Student[] expected = {
					new Student() {
						Id = 1,
						FirstName = "Landon",
						MiddleName = "Jameson",
						LastName = "Smith",
						IsGraduateStudent = false
					},
					new Student() {
						Id = 2,
						FirstName = "Avery",
						MiddleName = "Eliza,beth",
						LastName = "Davis",
						IsGraduateStudent = true
					},
					new Student() {
						Id = 3,
						FirstName = "Ethan",
						MiddleName = null,
						LastName = "John\"son",
						IsGraduateStudent = false
					},
					new Student() {
						 Id = 4,
						 FirstName = "Mia",
						 MiddleName = "Grace",
						 LastName = "Rodriguez",
						 IsGraduateStudent = false
					},
					new Student() {
						Id = 5,
						FirstName = "Oliver",
						MiddleName = "William",
						LastName = "Brown",
						IsGraduateStudent = true
					},
					new Student() {
						Id = 6,
						FirstName = "Aria",
						MiddleName = "Rose",
						LastName = "Hernandez",
						IsGraduateStudent = false
					},
					new Student() {
						Id = 7,
						FirstName = "Caleb",
						MiddleName = "Alexander",
						LastName = "Lee",
						IsGraduateStudent = true
					},
					new Student() {
						Id = 8,
						FirstName = "Lila",
						MiddleName = "Madison",
						LastName = "Turner",
						IsGraduateStudent = false
					}
				};

				IEnumerable<Student> actual = Csv.Read(
					@".\assets\students.csv",
					(string[] row) => {
						return new Student() {
							Id = Convert.ToInt64(row[0]),
							FirstName = row[1],
							MiddleName = row[2] == "null" || String.IsNullOrWhiteSpace(row[2]) ? null : row[2],
							LastName = row[3],
							IsGraduateStudent = Convert.ToBoolean(row[4])
						};
					},
					hasHeader: true
				);

				Assert.IsTrue(expected.SequenceEqual(actual));
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		//[TestMethod]
		//public void Csv_Write() {
		//	try {
		//		IEnumerable<Diamond> diamonds = Csv.Read<Diamond>(@".\assets\diamonds.csv", hasHeader: true);
		//		Csv.Write(diamonds, @".\assets\diamonds2.csv", writeHeader: true);
		//		Assert.IsTrue(File.Exists(@".\assets\diamonds2.csv"));
		//	}
		//	catch(Exception e) {
		//		Assert.Fail(e.Message);
		//	}
		//}

		//[TestMethod]
		//public async Task Csv_WriteAsync() {
		//	try {
		//		IEnumerable<Diamond> diamonds = Csv.Read<Diamond>(@".\assets\diamonds.csv", hasHeader: true);
		//		await Csv.WriteAsync(diamonds, @".\assets\diamondsasync.csv", writeHeader: true);
		//		Assert.IsTrue(File.Exists(@".\assets\diamondsasync.csv"));
		//	}
		//	catch(Exception e) {
		//		Assert.Fail(e.Message);
		//	}
		//}
	}
}
