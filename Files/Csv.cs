using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sion.Useful.Files {
	public static class Csv {
		public static IEnumerable<string[]> Read(string path, string delimiter = ",", bool hasHeader = false, Encoding? encoding = null) {
			encoding ??= Encoding.UTF8;
			List<string[]> lines = new();

			using TextFieldParser parser = new(path, encoding!) {
				TextFieldType = FieldType.Delimited,
				Delimiters = new string[] { delimiter }
			};

			while(!parser.EndOfData) {
				if(hasHeader) {
					parser.ReadFields();
					hasHeader = false;
				}
				else {
					string[]? row = parser.ReadFields();
					if(row != null) {
						row = row!.Select(r => r.Replace("\"\"", "\"")).ToArray();
						lines.Add(row!);
					}
				}
			}

			return lines;
		}

		public static IEnumerable<RowType> Read<RowType>(string path, string delimiter = ",", bool hasHeader = false, Encoding? encoding = null) where RowType : class {
			encoding ??= Encoding.UTF8;
			List<RowType> lines = new();
			string[]? fields = null;

			using TextFieldParser parser = new(path, encoding!) {
				TextFieldType = FieldType.Delimited,
				Delimiters = new string[] { delimiter }
			};

			while(!parser.EndOfData) {
				if(fields == null && hasHeader) {
					fields = parser.ReadFields();
				}
				else {
					RowType? obj = Activator.CreateInstance(typeof(RowType)) as RowType;
					Type? objType = obj?.GetType();
					fields ??= objType?.GetProperties().Select(p => p.Name).ToArray();
					string[]? row = parser.ReadFields();

					if(obj != null && objType != null && fields != null && row != null) {
						for(int i = 0; i < row!.Length; i += 1) {
							PropertyInfo? property = objType!.GetProperty(fields![i]);
							TypeCode typeCode = Type.GetTypeCode(property?.PropertyType);

							if(row![i] == "null" || String.IsNullOrWhiteSpace(row![i])) {
								property?.SetValue(obj!, null, null);
							}
							else {
								switch(typeCode) {
									case TypeCode.SByte:
										property?.SetValue(obj!, Convert.ToSByte(row![i]), null);
										break;
									case TypeCode.Byte:
										property?.SetValue(obj!, Convert.ToByte(row![i]), null);
										break;
									case TypeCode.Int16:
										property?.SetValue(obj!, Convert.ToInt16(row![i]), null);
										break;
									case TypeCode.UInt16:
										property?.SetValue(obj!, Convert.ToUInt16(row![i]), null);
										break;
									case TypeCode.Int32:
										property?.SetValue(obj!, Convert.ToInt32(row![i]), null);
										break;
									case TypeCode.UInt32:
										property?.SetValue(obj!, Convert.ToUInt32(row![i]), null);
										break;
									case TypeCode.Int64:
										property?.SetValue(obj!, Convert.ToInt64(row![i]), null);
										break;
									case TypeCode.UInt64:
										property?.SetValue(obj!, Convert.ToUInt64(row![i]), null);
										break;
									case TypeCode.Single:
										property?.SetValue(obj!, Convert.ToSingle(row![i]), null);
										break;
									case TypeCode.Double:
										property?.SetValue(obj!, Convert.ToDouble(row![i]), null);
										break;
									case TypeCode.Decimal:
										property?.SetValue(obj!, Convert.ToDecimal(row![i]), null);
										break;
									case TypeCode.Boolean:
										property?.SetValue(obj!, Convert.ToBoolean(row![i]), null);
										break;
									case TypeCode.Char:
										property?.SetValue(obj!, Convert.ToChar(row![i]), null);
										break;
									case TypeCode.String:
										row[i] = row![i].Replace("\"\"", "\"");
										property?.SetValue(obj!, row![i], null);
										break;
									case TypeCode.DateTime:
										property?.SetValue(obj!, Convert.ToDateTime(row![i]), null);
										break;
									case TypeCode.Empty:
										property?.SetValue(obj!, null, null);
										break;
									default:
										property?.SetValue(obj!, null, null);
										break;
								}
							}
						}
						lines.Add(obj!);
					}
				}
			}

			return lines;
		}

		public static IEnumerable<RowType> Read<RowType>(string path, Func<string[], RowType> customMappingFunc, string delimiter = ",", bool hasHeader = false, Encoding? encoding = null) {
			encoding ??= Encoding.UTF8;
			List<RowType> lines = new();

			using TextFieldParser parser = new(path, encoding!) {
				TextFieldType = FieldType.Delimited,
				Delimiters = new string[] { delimiter }
			};

			while(!parser.EndOfData) {
				if(hasHeader) {
					parser.ReadFields();
					hasHeader = false;
				}
				else {
					string[]? row = parser.ReadFields();
					if(row != null) {
						row = row!.Select(r => r.Replace("\"\"", "\"")).ToArray();
						lines.Add(customMappingFunc(row!));
					}
				}
			}

			return lines;
		}

		public static void Write(IEnumerable<IEnumerable<string>> rows, string path, string delimiter = ",", Encoding? encoding = null) {
			encoding ??= Encoding.UTF8;

			if(File.Exists(path)) {
				File.Delete(path);
			}

			using FileStream fin = File.Create(path);
			foreach(var row in rows) {
				string line = "";
				foreach(var column in row) {
					if(column.Contains(delimiter)) {
						line += $"\"{column.Replace("\"", "\"\"")}\"{delimiter}";
					}
					else {
						line += $"{column.Replace("\"", "\"\"")}{delimiter}";
					}
				}
				line = $"{line[..^delimiter.Length]}{Environment.NewLine}";
				byte[] data = encoding!.GetBytes(line);
				fin.Write(data, 0, data.Length);
			}
		}

		public static void Write<RowType>(IEnumerable<RowType> rows, string path, string delimiter = ",", bool writeHeader = false, Encoding? encoding = null) where RowType : class {
			encoding ??= Encoding.UTF8;

			if(Activator.CreateInstance(typeof(RowType)) as RowType is RowType obj) {
				Type objType = obj.GetType();
				PropertyInfo[] fields = objType.GetProperties();

				if(File.Exists(path)) {
					File.Delete(path);
				}

				using FileStream fin = File.Create(path);
				foreach(var row in rows) {
					string line = "";

					if(writeHeader) {
						line += $"{String.Join(delimiter, fields?.Select(f => f.Name) ?? Array.Empty<string>())}{Environment.NewLine}";
						writeHeader = false;
					}

					foreach(var field in fields!) {
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
							case TypeCode.DateTime:
								line += $"{field.GetValue(row) ?? "null"}{delimiter}";
								break;
							case TypeCode.Single:
								line += $"{field.GetValue(row) ?? "null"}{delimiter}";
								break;
							case TypeCode.Double:
								line += $"{field.GetValue(row) ?? "null"}{delimiter}";
								break;
							case TypeCode.Decimal:
								line += $"{field.GetValue(row) ?? "null"}{delimiter}";
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
								if(s?.Contains(delimiter) ?? false) {
									line += $"\"{s!.Replace("\"", "\"\"")}\"{delimiter}";
								}
								else {
									line += $"{s?.Replace("\"", "\"\"") ?? "null"}{delimiter}";
								}
								break;
							case TypeCode.Empty:
								line += $"null{delimiter}";
								break;
							default:
								line += $"null{delimiter}";
								break;
						}
					}

					line = $"{line[..^delimiter.Length]}{Environment.NewLine}";
					byte[] data = encoding!.GetBytes(line);
					fin.Write(data, 0, data.Length);
				}
			}
		}

		public static async Task WriteAsync(IEnumerable<IEnumerable<string>> rows, string path, string delimiter = ",", Encoding? encoding = null) {
			string csv = "";
			foreach(var row in rows) {
				foreach(var column in row) {
					if(column.Contains(delimiter)) {
						csv += $"\"{column.Replace("\"", "\"\"")}\"{delimiter}";
					}
					else {
						csv += $"{column.Replace("\"", "\"\"")}{delimiter}";
					}
				}
				csv = $"{csv[..^delimiter.Length]}{Environment.NewLine}";
			}
			encoding ??= Encoding.UTF8;
			await File.WriteAllTextAsync(path, csv, encoding!);
		}

		public static async Task WriteAsync<RowType>(IEnumerable<RowType> rows, string path, string delimiter = ",", bool writeHeader = false, Encoding? encoding = null) where RowType : class {
			string csv = "";

			if(Activator.CreateInstance(typeof(RowType)) as RowType is RowType obj) {
				Type objType = obj.GetType();
				PropertyInfo[] fields = objType.GetProperties();
				foreach(var row in rows) {
					if(writeHeader) {
						csv += $"{String.Join(delimiter, fields?.Select(f => f.Name) ?? Array.Empty<string>())}{Environment.NewLine}";
						writeHeader = false;
					}

					foreach(var field in fields!) {
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
							case TypeCode.DateTime:
								csv += $"{field.GetValue(row) ?? "null"}{delimiter}";
								break;
							case TypeCode.Single:
								csv += $"{field.GetValue(row) ?? "null"}{delimiter}";
								break;
							case TypeCode.Double:
								csv += $"{field.GetValue(row) ?? "null"}{delimiter}";
								break;
							case TypeCode.Decimal:
								csv += $"{field.GetValue(row) ?? "null"}{delimiter}";
								break;
							case TypeCode.Char:
								char c = Convert.ToChar(field.GetValue(row) ?? ' ');
								char delimit = Convert.ToChar(delimiter);
								if(c == '"') {
									csv += $"\"\"{delimiter}";
								}
								else if(delimit.ToString() == delimiter && c == delimit) {
									csv += $"\"{c}\"{delimiter}";
								}
								else {
									csv += $"{c}{delimiter}";
								}
								break;
							case TypeCode.String:
								string? s = field.GetValue(row)?.ToString();
								if(s?.Contains(delimiter) ?? false) {
									csv += $"\"{s!.Replace("\"", "\"\"")}\"{delimiter}";
								}
								else {
									csv += $"{s?.Replace("\"", "\"\"") ?? "null"}{delimiter}";
								}
								break;
							case TypeCode.Empty:
								csv += $"null{delimiter}";
								break;
							default:
								csv += $"null{delimiter}";
								break;
						}
					}

					csv = $"{csv[..^delimiter.Length]}{Environment.NewLine}";
				}
			}

			encoding ??= Encoding.UTF8;
			await File.WriteAllTextAsync(path, csv, encoding!);
		}
	}
}
