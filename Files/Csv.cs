using Sion.Useful.Files.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sion.Useful.Files {
	/// <summary>
	/// A static class that makes reading and writing CSV files easier.
	/// </summary>
	public static class Csv {
		/// <summary>
		/// Reads a CSV file and returns raw string data for the file.
		/// </summary>
		/// <param name="path">Path to the CSV file. Can be absolute or relative.</param>
		/// <param name="delimiter">Delimiter used for the CSV file.</param>
		/// <param name="hasHeader">If the CSV file has a header row, hasHeader should be set to true.</param>
		/// <param name="encoding">File encoding for the CSV file.</param>
		/// <returns>A collection of string arrays. Each array represents a row in the CSV file. Each item in the array is a single column in the CSV file.</returns>
		public static IEnumerable<string[]> Read(string path, string delimiter = ",", bool hasHeader = false, Encoding? encoding = null) {
			encoding ??= Encoding.UTF8;
			List<string[]> rows = new();

			using FileStream fin = File.OpenRead(path);
			using StreamReader reader = new(fin, encoding!);

			while(reader.ReadLine() is string line) {
				rows._ProcessLine(line, delimiter, ref hasHeader);
			}

			return rows;
		}

		/// <summary>
		/// Reads a CSV file and automatically maps it to a collection of objects.
		/// </summary>
		/// <typeparam name="RowType">An object representing a single row in the CSV file. The object must be a class.</typeparam>
		/// <param name="path">Path to the CSV file. Can be absolute or relative.</param>
		/// <param name="delimiter">Delimiter used for the CSV file.</param>
		/// <param name="hasHeader">If the CSV file has a header row, hasHeader should be set to true.</param>
		/// <param name="encoding">File encoding for the CSV file.</param>
		/// <returns>A collection of custom objects.</returns>
		public static IEnumerable<RowType> Read<RowType>(string path, string delimiter = ",", bool hasHeader = false, Encoding? encoding = null) where RowType : class {
			encoding ??= Encoding.UTF8;
			List<RowType> rows = new();
			string[]? fields = null;

			using FileStream fin = File.OpenRead(path);
			using StreamReader reader = new(fin, encoding!);

			while(reader.ReadLine() is string line) {
				rows._ProcessLine(line, ref fields, delimiter, ref hasHeader);
			}

			return rows;
		}

		/// <summary>
		/// Reads a CSV file and maps it to a collection of objects using a provided mapping function.
		/// </summary>
		/// <typeparam name="RowType">An object representing a single row in the CSV file.</typeparam>
		/// <param name="path">Path to the CSV file. Can be absolute or relative.</param>
		/// <param name="customMappingFunc">Custom mapping function.</param>
		/// <param name="delimiter">Delimiter used for the CSV file.</param>
		/// <param name="hasHeader">If the CSV file has a header row, hasHeader should be set to true.</param>
		/// <param name="encoding">File encoding for the CSV file.</param>
		/// <returns>A collection of custom objects.</returns>
		public static IEnumerable<RowType> Read<RowType>(string path, Func<string[], RowType> customMappingFunc, string delimiter = ",", bool hasHeader = false, Encoding? encoding = null) {
			encoding ??= Encoding.UTF8;
			List<RowType> rows = new();

			using FileStream fin = File.OpenRead(path);
			using StreamReader reader = new(fin, encoding!);

			while(reader.ReadLine() is string line) {
				rows._ProcessLine(line, customMappingFunc, delimiter, ref hasHeader);
			}

			return rows;
		}

		/// <summary>
		/// Reads a CSV file asynchronously and returns a Task with raw string data for the file.
		/// </summary>
		/// <param name="path">Path to the CSV file. Can be absolute or relative.</param>
		/// <param name="delimiter">Delimiter used for the CSV file.</param>
		/// <param name="hasHeader">If the CSV file has a header row, hasHeader should be set to true.</param>
		/// <param name="encoding">File encoding for the CSV file.</param>
		/// <returns>A Task of a collection of string arrays. Each array represents a row in the CSV file. Each item in the array is a single column in the CSV file.</returns>
		public static async Task<IEnumerable<string[]>> ReadAsync(string path, string delimiter = ",", bool hasHeader = false, Encoding? encoding = null) {
			encoding ??= Encoding.UTF8;
			List<string[]> rows = new();

			using FileStream fin = File.OpenRead(path);
			using StreamReader reader = new(fin, encoding!);

			while(await reader.ReadLineAsync() is string line) {
				rows._ProcessLine(line, delimiter, ref hasHeader);
			}

			return rows;
		}

		/// <summary>
		/// Reads a CSV file asynchronously and automatically maps it to a collection of objects.
		/// </summary>
		/// <typeparam name="RowType">An object representing a single row in the CSV file. The object must be a class.</typeparam>
		/// <param name="path">Path to the CSV file. Can be absolute or relative.</param>
		/// <param name="delimiter">Delimiter used for the CSV file.</param>
		/// <param name="hasHeader">If the CSV file has a header row, hasHeader should be set to true.</param>
		/// <param name="encoding">File encoding for the CSV file.</param>
		/// <returns>A Task of a collection of custom objects.</returns>
		public static async Task<IEnumerable<RowType>> ReadAsync<RowType>(string path, string delimiter = ",", bool hasHeader = false, Encoding? encoding = null) where RowType : class {
			encoding ??= Encoding.UTF8;
			List<RowType> rows = new();
			string[]? fields = null;

			using FileStream fin = File.OpenRead(path);
			using StreamReader reader = new(fin, encoding!);

			while(await reader.ReadLineAsync() is string line) {
				rows._ProcessLine(line, ref fields, delimiter, ref hasHeader);
			}

			return rows;
		}

		/// <summary>
		/// Reads a CSV file asynchronously and maps it to a collection of objects using a provided mapping function.
		/// </summary>
		/// <typeparam name="RowType">An object representing a single row in the CSV file.</typeparam>
		/// <param name="path">Path to the CSV file. Can be absolute or relative.</param>
		/// <param name="customMappingFunc">Custom mapping function.</param>
		/// <param name="delimiter">Delimiter used for the CSV file.</param>
		/// <param name="hasHeader">If the CSV file has a header row, hasHeader should be set to true.</param>
		/// <param name="encoding">File encoding for the CSV file.</param>
		/// <returns>A Task of a collection of custom objects.</returns>
		public static async Task<IEnumerable<RowType>> ReadAsync<RowType>(string path, Func<string[], RowType> customMappingFunc, string delimiter = ",", bool hasHeader = false, Encoding? encoding = null) {
			encoding ??= Encoding.UTF8;
			List<RowType> rows = new();

			using FileStream fin = File.OpenRead(path);
			using StreamReader reader = new(fin, encoding!);

			while(await reader.ReadLineAsync() is string line) {
				rows._ProcessLine(line, customMappingFunc, delimiter, ref hasHeader);
			}

			return rows;
		}

		/// <summary>
		/// Writes raw string data to a CSV file. If the file exists, it will be overwritten.
		/// </summary>
		/// <param name="rows">The raw data to write.</param>
		/// <param name="path">Path for the new CSV file to be created. Can be absolute or relative.</param>
		/// <param name="delimiter">Delimiter used for the CSV file.</param>
		/// <param name="encoding">File encoding for the CSV file.</param>
		public static void Write(IEnumerable<IEnumerable<string>> rows, string path, string delimiter = ",", Encoding? encoding = null) {
			encoding ??= Encoding.UTF8;

			if(File.Exists(path)) {
				File.Delete(path);
			}

			using FileStream fout = File.Create(path);
			foreach(var row in rows) {
				string line = row._ToCsvLine(delimiter);
				byte[] data = encoding!.GetBytes(line);
				fout.Write(data, 0, data.Length);
			}
		}

		/// <summary>
		/// Writes a collection of objects to a CSV file. If the file exists, it will be overwritten.
		/// </summary>
		/// <typeparam name="RowType">An object representing a single row in the CSV file. The object must be a class.</typeparam>
		/// <param name="rows">The data to write.</param>
		/// <param name="path">Path for the new CSV file to be created. Can be absolute or relative.</param>
		/// <param name="writeHeader">If you want the created CSV file to have a header row based on the class property names, set writeHeader to true.</param>
		/// <param name="delimiter">Delimiter used for the CSV file.</param>
		/// <param name="encoding">File encoding for the CSV file.</param>
		public static void Write<RowType>(IEnumerable<RowType> rows, string path, bool writeHeader, string delimiter = ",", Encoding? encoding = null) where RowType : class {
			encoding ??= Encoding.UTF8;

			if(Activator.CreateInstance<RowType>() is RowType obj) {
				Type objType = obj.GetType();
				PropertyInfo[] fields = objType.GetProperties();

				if(File.Exists(path)) {
					File.Delete(path);
				}

				using FileStream fout = File.Create(path);
				foreach(var row in rows) {
					string line = row._ToCsvLine(fields, delimiter, ref writeHeader);
					byte[] data = encoding!.GetBytes(line);
					fout.Write(data, 0, data.Length);
				}
			}
		}

		/// <summary>
		/// Writes raw string data to a CSV file asynchronously. If the file exists, it will be overwritten.
		/// </summary>
		/// <param name="rows">The raw data to write.</param>
		/// <param name="path">Path for the new CSV file to be created. Can be absolute or relative.</param>
		/// <param name="delimiter">Delimiter used for the CSV file.</param>
		/// <param name="encoding">File encoding for the CSV file.</param>
		/// <returns>An empty Task.</returns>
		public static async Task WriteAsync(IEnumerable<IEnumerable<string>> rows, string path, string delimiter = ",", Encoding? encoding = null) {
			encoding ??= Encoding.UTF8;

			if(File.Exists(path)) {
				File.Delete(path);
			}

			using FileStream fout = File.Create(path);
			foreach(var row in rows) {
				string line = row._ToCsvLine(delimiter);
				byte[] data = encoding!.GetBytes(line);
				await fout.WriteAsync(data.AsMemory(0, data.Length));
			}
		}

		/// <summary>
		/// Writes a collection of objects to a CSV file asynchronously. If the file exists, it will be overwritten.
		/// </summary>
		/// <typeparam name="RowType">An object representing a single row in the CSV file. The object must be a class.</typeparam>
		/// <param name="rows">The data to write.</param>
		/// <param name="path">Path for the new CSV file to be created. Can be absolute or relative.</param>
		/// <param name="writeHeader">If you want the created CSV file to have a header row based on the class property names, set writeHeader to true.</param>
		/// <param name="delimiter">Delimiter used for the CSV file.</param>
		/// <param name="encoding">File encoding for the CSV file.</param>
		/// <returns>An empty Task.</returns>
		public static async Task WriteAsync<RowType>(IEnumerable<RowType> rows, string path, bool writeHeader, string delimiter = ",", Encoding? encoding = null) where RowType : class {
			encoding ??= Encoding.UTF8;

			if(Activator.CreateInstance<RowType>() is RowType obj) {
				Type objType = obj.GetType();
				PropertyInfo[] fields = objType.GetProperties();

				if(File.Exists(path)) {
					File.Delete(path);
				}

				using FileStream fout = File.Create(path);
				foreach(var row in rows) {
					string line = row._ToCsvLine(fields, delimiter, ref writeHeader);
					byte[] data = encoding!.GetBytes(line);
					await fout.WriteAsync(data.AsMemory(0, data.Length));
				}
			}
		}

		/// <summary>
		/// Splits a string based on a given delimiter. The regex expression ensures that delimiters surrounded with quotes are not matched.
		/// </summary>
		/// <param name="line">Raw string data for a whole line in a CSV file.</param>
		/// <param name="delimiter">The delimiter to match on split.</param>
		/// <returns>A string array representing the inputed line split based on the delimiter.</returns>
		private static string[] _CsvSplit(this string line, string delimiter) {
			string pattern = $@"{delimiter}(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
			string[] row = Regex.Split(line, pattern);
			for(int i = 0; i < row.Length; i += 1) {
				if(row[i].StartsWith("\"") && row[i].EndsWith("\"")) {
					row[i] = row[i][1..^1];
				}
				row[i] = row[i].Replace("\"\"", "\"");
			}
			return row;
		}

		/// <summary>
		/// Maps a value to a specific property on an object.
		/// </summary>
		/// <typeparam name="RowType">An object representing a single row in the CSV file.</typeparam>
		/// <param name="obj">The object whose property is being set to a value.</param>
		/// <param name="column">The value we're setting the property to.</param>
		/// <param name="property">The property on the object being set.</param>
		private static void _Map<RowType>(this RowType obj, string column, PropertyInfo property) {
			if(column == "null" || String.IsNullOrWhiteSpace(column)) {
				property.SetValue(obj, null, null);
			}
			else {
				TypeCode typeCode = Type.GetTypeCode(property.PropertyType);
				switch(typeCode) {
					case TypeCode.SByte:
						property.SetValue(obj, Convert.ToSByte(column), null);
						break;
					case TypeCode.Byte:
						property.SetValue(obj, Convert.ToByte(column), null);
						break;
					case TypeCode.Int16:
						property.SetValue(obj, Convert.ToInt16(column), null);
						break;
					case TypeCode.UInt16:
						property.SetValue(obj, Convert.ToUInt16(column), null);
						break;
					case TypeCode.Int32:
						property.SetValue(obj, Convert.ToInt32(column), null);
						break;
					case TypeCode.UInt32:
						property.SetValue(obj, Convert.ToUInt32(column), null);
						break;
					case TypeCode.Int64:
						property.SetValue(obj, Convert.ToInt64(column), null);
						break;
					case TypeCode.UInt64:
						property.SetValue(obj, Convert.ToUInt64(column), null);
						break;
					case TypeCode.Single:
						property.SetValue(obj, Convert.ToSingle(column), null);
						break;
					case TypeCode.Double:
						property.SetValue(obj, Convert.ToDouble(column), null);
						break;
					case TypeCode.Decimal:
						property.SetValue(obj, Convert.ToDecimal(column), null);
						break;
					case TypeCode.Boolean:
						property.SetValue(obj, Convert.ToBoolean(column), null);
						break;
					case TypeCode.Char:
						property.SetValue(obj, Convert.ToChar(column), null);
						break;
					case TypeCode.String:
						property.SetValue(obj, column, null);
						break;
					case TypeCode.DateTime:
						property.SetValue(obj, Convert.ToDateTime(column), null);
						break;
					case TypeCode.Empty:
						property.SetValue(obj, null, null);
						break;
					default:
						if(property.PropertyType == typeof(DateTime?)) {
							property.SetValue(obj, Convert.ToDateTime(column), null);
						}
						else if(property.PropertyType == typeof(int?)) {
							property.SetValue(obj, Convert.ToInt32(column), null);
						}
						else if(property.PropertyType == typeof(long?)) {
							property.SetValue(obj, Convert.ToInt64(column), null);
						}
						else if(property.PropertyType == typeof(double?)) {
							property.SetValue(obj, Convert.ToDouble(column), null);
						}
						else if(property.PropertyType == typeof(float?)) {
							property.SetValue(obj, Convert.ToSingle(column), null);
						}
						else if(property.PropertyType == typeof(decimal?)) {
							property.SetValue(obj, Convert.ToDecimal(column), null);
						}
						else if(property.PropertyType == typeof(short?)) {
							property.SetValue(obj, Convert.ToInt16(column), null);
						}
						else if(property.PropertyType == typeof(uint?)) {
							property.SetValue(obj, Convert.ToUInt32(column), null);
						}
						else if(property.PropertyType == typeof(ulong?)) {
							property.SetValue(obj, Convert.ToUInt64(column), null);
						}
						else if(property.PropertyType == typeof(ushort?)) {
							property.SetValue(obj, Convert.ToUInt16(column), null);
						}
						else if(property.PropertyType == typeof(char?)) {
							property.SetValue(obj, Convert.ToChar(column), null);
						}
						else if(property.PropertyType == typeof(bool?)) {
							property.SetValue(obj, Convert.ToBoolean(column), null);
						}
						else if(property.PropertyType == typeof(byte?)) {
							property.SetValue(obj, Convert.ToByte(column), null);
						}
						else if(property.PropertyType == typeof(sbyte?)) {
							property.SetValue(obj, Convert.ToSByte(column), null);
						}
						else {
							property.SetValue(obj, null, null);
						}
						break;
				}
			}
		}

		/// <summary>
		/// Decision tree for raw processing of a single line from a CSV file.
		/// </summary>
		/// <param name="rows">The collection that the data from the file is added to.</param>
		/// <param name="line">The line from the CSV file.</param>
		/// <param name="delimiter">Delimiter used for the CSV file.</param>
		/// <param name="hasHeader">Skips the first line if true.</param>
		private static void _ProcessLine(this List<string[]> rows, string line, string delimiter, ref bool hasHeader) {
			if(hasHeader) {
				hasHeader = false;
			}
			else {
				string[] row = line._CsvSplit(delimiter);
				rows.Add(row);
			}
		}

		/// <summary>
		/// Decision tree for automatic mapping processing of a single line from a CSV file.
		/// </summary>
		/// <typeparam name="RowType">An object representing a single row in the CSV file. The object must be a class.</typeparam>
		/// <param name="rows">The collection that the data from the file is added to.</param>
		/// <param name="line">The line from the CSV file.</param>
		/// <param name="fields">The collection of property names.</param>
		/// <param name="delimiter">Delimiter used for the CSV file.</param>
		/// <param name="hasHeader">Skips the first line if true.</param>
		private static void _ProcessLine<RowType>(this List<RowType> rows, string line, ref string[]? fields, string delimiter, ref bool hasHeader) where RowType : class {
			string[] row = line._CsvSplit(delimiter);

			if(fields == null && hasHeader) {
				fields = row;
			}
			else {
				if(Activator.CreateInstance<RowType>() is RowType obj) {
					Type objType = obj.GetType();
					fields ??= objType.GetProperties().Select(p => p.Name).ToArray();
					for(int i = 0; i < row.Length; i += 1) {
						if(objType.GetProperty(fields![i]) is PropertyInfo property) {
							obj._Map(row[i], property);
						}
					}
					rows.Add(obj);
				}
			}
		}

		/// <summary>
		/// Decision tree for custom mapping processing of a single line from a CSV file.
		/// </summary>
		/// <typeparam name="RowType">An object representing a single row in the CSV file.</typeparam>
		/// <param name="rows">The collection that the data from the file is added to.</param>
		/// <param name="line">The line from the CSV file.</param>
		/// <param name="customMappingFunc">The mapping function provided by the user.</param>
		/// <param name="delimiter">Delimiter used for the CSV file.</param>
		/// <param name="hasHeader">Skips the first line if true.</param>
		private static void _ProcessLine<RowType>(this List<RowType> rows, string line, Func<string[], RowType> customMappingFunc, string delimiter, ref bool hasHeader) {
			if(hasHeader) {
				hasHeader = false;
			}
			else {
				string[] row = line._CsvSplit(delimiter);
				rows.Add(customMappingFunc(row));
			}
		}

		/// <summary>
		/// Converts raw string data to a delimited line. Takes care of quotes and nested delimiters.
		/// </summary>
		/// <param name="row">The data being converted.</param>
		/// <param name="delimiter">Delimiter used for the CSV file.</param>
		/// <returns>The delimited CSV line.</returns>
		private static string _ToCsvLine(this IEnumerable<string> row, string delimiter) {
			string line = "";
			foreach(var column in row) {
				if(column.Contains(delimiter)) {
					line += $"\"{column.Replace("\"", "\"\"")}\"{delimiter}";
				}
				else {
					line += $"{column.Replace("\"", "\"\"")}{delimiter}";
				}
			}
			return $"{line[..^delimiter.Length]}{Environment.NewLine}";
		}

		/// <summary>
		/// Converts a collection of objects to a delimited line. Takes care of quotes and nested delimiters.
		/// </summary>
		/// <typeparam name="RowType">An object representing a single row in the CSV file.</typeparam>
		/// <param name="row">The data being converted.</param>
		/// <param name="fields">The collection of property names.</param>
		/// <param name="delimiter">Delimiter used for the CSV file.</param>
		/// <param name="writeHeader">Creates a line of property names to start the line if true.</param>
		/// <returns>The delimited CSV line.</returns>
		private static string _ToCsvLine<RowType>(this RowType row, PropertyInfo[] fields, string delimiter, ref bool writeHeader) {
			string line = "";

			if(writeHeader) {
				line += $"{String.Join(delimiter, fields.Select(f => f.Name) ?? Array.Empty<string>())}{Environment.NewLine}";
				writeHeader = false;
			}

			foreach(var field in fields) {
				TypeCode typeCode = Type.GetTypeCode(field.PropertyType);
				switch(typeCode) {
					case TypeCode.SByte:
					case TypeCode.Byte:
					case TypeCode.Int16:
					case TypeCode.UInt16:
					case TypeCode.Int32:
					case TypeCode.UInt32:
					case TypeCode.Int64:
					case TypeCode.UInt64:
					case TypeCode.Boolean:
						line += $"{field.GetValue(row) ?? "null"}{delimiter}";
						break;
					case TypeCode.DateTime:
						object? d = field.GetValue(row);
						if(d == null) {
							line += $"null{delimiter}";
						}
						else {
							DateTime date = Convert.ToDateTime(d!);
							string? format = field.GetCustomAttribute<OutputFormatAttribute>()?.Format;
							format ??= CultureInfo.CurrentCulture.DateTimeFormat.FullDateTimePattern;
							line += $"{date.ToString(format!)}{delimiter}";
						}
						break;
					case TypeCode.Single:
					case TypeCode.Double:
					case TypeCode.Decimal:
						string? n = field.GetValue(row)?.ToString();
						n ??= "null";
						if(n!.Contains(delimiter)) {
							n = $"\"{n!}\"";
						}
						line += $"{n!}{delimiter}";
						break;
					case TypeCode.Char:
						char c = Convert.ToChar(field.GetValue(row) ?? ' ');
						if(c == '"') {
							line += $"\"\"{delimiter}";
						}
						else if(c.ToString() == delimiter) {
							line += $"\"{c}\"{delimiter}";
						}
						else {
							line += $"{c}{delimiter}";
						}
						break;
					case TypeCode.String:
						string? s = field.GetValue(row)?.ToString();
						s ??= "null";
						if(s!.Contains(delimiter)) {
							line += $"\"{s!.Replace("\"", "\"\"")}\"{delimiter}";
						}
						else {
							line += $"{s!.Replace("\"", "\"\"")}{delimiter}";
						}
						break;
					case TypeCode.Empty:
						line += $"null{delimiter}";
						break;
					default:
						if(field.PropertyType == typeof(DateTime?)) {
							object? dob = field.GetValue(row);
							if(dob == null) {
								line += $"null{delimiter}";
							}
							else {
								DateTime date = Convert.ToDateTime(dob!);
								string? format = field.GetCustomAttribute<OutputFormatAttribute>()?.Format;
								format ??= CultureInfo.CurrentCulture.DateTimeFormat.FullDateTimePattern;
								line += $"{date.ToString(format!)}{delimiter}";
							}
						}
						else if(
							field.PropertyType == typeof(int?)
							|| field.PropertyType == typeof(long?)
							|| field.PropertyType == typeof(float?)
							|| field.PropertyType == typeof(double?)
							|| field.PropertyType == typeof(decimal?)
							|| field.PropertyType == typeof(short?)
							|| field.PropertyType == typeof(uint?)
							|| field.PropertyType == typeof(ulong?)
							|| field.PropertyType == typeof(ushort?)
							|| field.PropertyType == typeof(char?)
							|| field.PropertyType == typeof(byte?)
							|| field.PropertyType == typeof(sbyte?)
							|| field.PropertyType == typeof(bool?)
						) {
							line += $"{field.GetValue(row) ?? "null"}{delimiter}";
						}
						else {
							line += $"null{delimiter}";
						}
						break;
				}
			}

			return $"{line[..^delimiter.Length]}{Environment.NewLine}";
		}
	}
}
