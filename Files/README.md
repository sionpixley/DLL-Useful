# Sion.Useful.Files

NuGet package that provides useful file methods. Specifically, CSV file reading.

## Sion.Useful.Files.Csv

```
public static IEnumerable<string[]> Read(string path, string delimiter = ",", bool hasHeader = false)
public static IEnumerable<RowType> Read<RowType>(string path, string delimiter = ",", bool hasHeader = false) where RowType : class
public static IEnumerable<RowType> ReadWithCustomMapping<RowType>(string path, Func<string[], RowType> customMapping, string delimiter = ",", bool hasHeader = false)
```

## How to use:

First, download the Sion.Useful.Files NuGet package, then include this using statement at the top of the file:

```
using Sion.Useful.Files;
```

### Csv

#### Reading a CSV file and mapping it to a custom class (automatically)

Things to note: 

- The delimiter defaults to a comma, but can be customized
- The hasHeader defaults to false
- The automatic mapping currently only supports classes that use built-in property types
- The automatic mapping works best if there's a header row on the CSV file with column names that match the property names for the custom class (casing does matter)
- Empty column values are treated as null
- Column values null and "null" are also treated as null
- If using null, please mark which properties are nullable in the class definition

```
// Every row in our CSV file is a Student object
public class Student {
	public long Id { get; set; }
	public string FirstName { get; set; } = "";
	public string? MiddleName { get; set; }
	public string LastName { get; set; } = "";
	public bool IsGraduateStudent { get; set; }
}
```

```
students.csv:
Id,FirstName,MiddleName,LastName,IsGraduateStudent
1,Landon,Jameson,Smith,false
2,Avery,Elizabeth,Davis,true
3,Ethan,null,Johnson,false
4,Mia,Grace,Rodriguez,false
5,Oliver,William,Brown,true
6,Aria,Rose,Hernandez,false
7,Caleb,Alexander,Lee,true
8,Lila,Madison,Turner,false
```

```
// Reading the CSV
IEnumerable<Student> students = Csv.Read<Student>("students.csv", hasHeader: true);
```

#### Reading a CSV file and mapping it to a custom class with custom mapping

If you find that the default automatic mapping is just not cutting it, there is a way to define a custom mapping for your object:

```
// Reading the CSV with your custom mapping
IEnumerable<Student> students = Csv.ReadWithCustomMapping<Student>(
	"students.csv",
	(string[] row) => {
		return new Student() {
			Id = Convert.ToInt64(row[0]),
			FirstName = row[1],
			MiddleName = row[2] == "null" || String.IsNullOrWhiteSpace(row[2]) ? null : row[2],
			LastName = row[3],
			IsGraduateStudent = Convert.ToBoolean(row[4])
		};
	},
	hasHeader = true
);
```

#### Reading a CSV file and receiving raw string data

```
IEnumerable<string[]> rows = Csv.Read("students.csv", hasHeader: true);
```
