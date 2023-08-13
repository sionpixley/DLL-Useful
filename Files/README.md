# Sion.Useful.Files

NuGet package that provides useful file methods. Specifically, CSV file reading.

## Sion.Useful.Files.Csv

```
public static IEnumerable<string[]> Read(string path, string delimiter = ",", bool hasHeader = false)
public static IEnumerable<RowType> Read<RowType>(string path, string delimiter = ",", bool hasHeader = false) where RowType : class
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

#### Reading a CSV file and receiving raw string data

```
IEnumerable<string[]> rows = Csv.Read("students.csv", hasHeader: true);
```
