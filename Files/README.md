# Sion.Useful.Files

NuGet package that provides useful file methods. Specifically, CSV file reading and writing.

## Sion.Useful.Files.Attributes

```
public class OutputFormatAttribute : Attribute
```

## Sion.Useful.Files.Csv

```
public static IEnumerable<string[]> Read(string path, string delimiter = ",", bool hasHeader = false, Encoding? encoding = null)
public static IEnumerable<RowType> Read<RowType>(string path, string delimiter = ",", bool hasHeader = false, Encoding? encoding = null) where RowType : class
public static IEnumerable<RowType> Read<RowType>(string path, Func<string[], RowType> customMappingFunc, string delimiter = ",", bool hasHeader = false, Encoding? encoding = null)
public static async Task<IEnumerable<string[]>> ReadAsync(string path, string delimiter = ",", bool hasHeader = false, Encoding? encoding = null)
public static async Task<IEnumerable<RowType>> ReadAsync<RowType>(string path, string delimiter = ",", bool hasHeader = false, Encoding? encoding = null) where RowType : class
public static async Task<IEnumerable<RowType>> ReadAsync<RowType>(string path, Func<string[], RowType> customMappingFunc, string delimiter = ",", bool hasHeader = false, Encoding? encoding = null)

public static void Write(IEnumerable<IEnumerable<string>> rows, string path, string delimiter = ",", Encoding? encoding = null)
public static void Write<RowType>(IEnumerable<RowType> rows, string path, bool writeHeader, string delimiter = ",", Encoding? encoding = null) where RowType : class
public static async Task WriteAsync(IEnumerable<IEnumerable<string>> rows, string path, string delimiter = ",", Encoding? encoding = null)
public static async Task WriteAsync<RowType>(IEnumerable<RowType> rows, string path, bool writeHeader, string delimiter = ",", Encoding? encoding = null) where RowType : class
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
- The encoding defaults to UTF-8
- The automatic mapping currently only supports classes that use these property types: bool, char, string, DateTime, short, ushort, int, uint, long, ulong, float, double, decimal, sbyte, and byte
- The automatic mapping works best if there's a header row on the CSV file with column names that match the property names for the custom class (casing does matter)
- Empty column values are treated as null
- Column values null and "null" are also treated as null
- If using null, please mark which properties are nullable in the class definition
- There are asynchronous versions of the Read method (ReadAsync)

```
// Every row in our CSV file is a Student object
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
}
```

```
students.csv:
Id,FirstName,MiddleName,LastName,HasGraduated,GraduationDate
1,Landon,Jameson,Smith,false,null
2,Avery,"Eliza,beth",Davis,true,2000-05-14T17:00:00.000
3,Ethan,,John""son,false,
4,Mia,Grace,Rodriguez,false,null
5,Oliver,William,Brown,true,2002-05-23T16:00:00.000
6,Aria,Rose,Hernandez,false,null
7,Caleb,Alexander,Lee,true,2003-05-16T13:30:00.000
8,Lila,Madison,Turner,false,null
```

```
// Reading the CSV
IEnumerable<Student> students = Csv.Read<Student>("students.csv", hasHeader: true);
```

#### Reading a CSV file and mapping it to a custom class with custom mapping

If you find that the default automatic mapping is just not cutting it, there is a way to define a custom mapping for your object. The Read method is overloaded to take in a Func parameter. This Func is where you'll do your custom mapping.

This Func has one parameter, a string array representing a row in the CSV file. It must return your custom class.

```
// Reading the CSV with your custom mapping
IEnumerable<Student> students = Csv.Read(
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

Note: Empty column values will return as an empty string ""

```
IEnumerable<string[]> rows = Csv.Read("students.csv", hasHeader: true);
```

#### Writing a collection of objects to a CSV file

Things to note: 

- The Write method using objects uses the built-in automatic mapping
- DateTime properties can output in custom formats using the OutputFormatAttribute in the Sion.Useful.Files.Attributes namespace
- The automatic mapping currently only supports classes that use these property types: bool, char, string, DateTime, short, ushort, int, uint, long, ulong, float, double, decimal, sbyte, and byte
- There are asynchronous versions of the Write method (WriteAsync)

```
Student[] data = SomeDataSource();
Csv.Write(data, "students2.csv", true);
```

#### Writing raw string data to a CSV file

```
// Doesn't have to be of type string[][], it can be any collection of string collections (i.e. any type that conforms to IEnumerable<IEnumerable<string>>)
string[][] data = SomeDataSource();
Csv.Write(data, "students2.csv");
```
