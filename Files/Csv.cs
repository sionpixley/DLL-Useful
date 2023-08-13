using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Sion.Useful.Files {
	public static class Csv {
		public static IEnumerable<string[]> Read(string path, string delimiter = ",", bool hasHeader = false) {
			List<string[]> lines = new();

			using TextFieldParser parser = new(path) {
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
						lines.Add(row!);
					}
				}
			}

			return lines;
		}

		public static IEnumerable<RowType> Read<RowType>(string path, string delimiter = ",", bool hasHeader = false) where RowType : class {
			List<RowType> lines = new();
			string[]? fields = null;

			using TextFieldParser parser = new(path) {
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

							if(row![i] == "null") {
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
										property?.SetValue(obj!, row![i], null);
										break;
									case TypeCode.DateTime:
										property?.SetValue(obj!, Convert.ToDateTime(row![i]), null);
										break;
									case TypeCode.Empty:
										property?.SetValue(obj!, null, null);
										break;
									default:
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
	}
}
