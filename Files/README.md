# Sion.Useful.Files

NuGet package that provides useful file methods. Specifically, CSV file reading.

## Sion.Useful.Files.Classes.CsvObject 

```
public abstract class CsvObject {
	public CsvObject(string[] row) { }
}
```

## Sion.Useful.Files.Csv

```
public static IEnumerable<string[]> Read(string path, string delimiter = ",", bool hasHeader = false)
public static IEnumerable<RowType> Read<RowType>(string path, string delimiter = ",", bool hasHeader = false) where RowType : class
public static IEnumerable<RowType> ReadWithCustomMapping(string path, string delimiter = ",", bool hasHeader = false) where RowType : CsvObject
```

## How to use:

First, download the Sion.Useful.Files NuGet package, then include this using statement at the top of the file:

```
using Sion.Useful.Files;
```

### Csv

#### Reading a CSV file and mapping it to a custom class

Things to note: 

- The delimiter defaults to a comma, but can be customized
- The hasHeader defaults to false
- The mapping currently only supports classes that use built-in property types
- The mapping works best if there's a header row on the CSV file with column names that match the property names for the custom class (casing does matter)
- Data needs to be properly formed if doing custom mapping, aka no empty column values
- Empty column values are probably best as null values, please make this change before trying to read the CSV (I'll be making a method to automatically do this later)
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

1. Create your object similarly as the previous example, except your class must now inherit from the CsvObject class located in the Sion.Useful.Files.Csv.Classes namespace
2. Create an explicit constructor that takes in a string array representing a row in the CSV file (this is where you'll do custom mapping)

Your class definition should look something like this now:

```
public class Student : CsvObject {
	public long Id { get; set; }
	public string FirstName { get; set; } = "";
	public string? MiddleName { get; set; }
	public string LastName { get; set; } = "";
	public bool IsGraduateStudent { get; set; }
	
	// Explicit constructor with custom mapping
	public Student(string[] row) : base(row) {
		Id = Convert.ToInt64(row[0]);
		FirstName = row[1];
		MiddleName = row[2] == "null" ? null : row[2];
		LastName = row[3];
		IsGraduateStudent = Convert.ToBoolean(row[4]);
	}
}
```

```
// Reading the CSV with your custom mapping
IEnumerable<Student> students = Csv.ReadWithCustomMapping<Student>("students.csv", hasHeader = true);
```

#### Reading a CSV file and receiving raw string data

```
IEnumerable<string[]> rows = Csv.Read("students.csv", hasHeader: true);
```
