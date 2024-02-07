# Sion.Useful

NuGet package that provides static and extension methods to DateTime and string.

## Sion.Useful.DateTimeMethods

```
public static long ConvertToUnixMilliseconds(DateTime date)
public static long ConvertToUnixSeconds(DateTime date)
public static long GetUnixMillisecondsNow()
public static long GetUnixSecondsNow()
public static long ToUnixMilliseconds(this DateTime date)
public static long ToUnixSeconds(this DateTime date)
```

## Sion.Useful.StringMethods

```
public static string Base64ToUtf8(this string base64)
public static string Utf8ToBase64(this string utf8)
```

## How to use

First, download the Sion.Useful NuGet package, then include this using statement at the top of the file:

```
using Sion.Useful;
```

### DateTimeMethods

#### Getting Unix seconds and milliseconds

```
// Using extension methods
DateTime date = Convert.ToDateTime("2000-01-01T12:00:00.000");
long unixMilliseconds = date.ToUnixMilliseconds();
long unixSeconds = date.ToUnixSeconds();

long unixMillisecondsNow = DateTime.Now.ToUnixMilliseconds();
long unixSeconds = DateTime.Now.ToUnixSeconds();
```

```
// Using static methods
DateTime date = Convert.ToDateTime("2000-01-01T12:00:00.000");
long unixMilliseconds = DateTimeMethods.ConvertToUnixMilliseconds(date);
long unixSeconds = DateTimeMethods.ConvertToUnixSeconds(date);

long unixMillisecondsNow = DateTimeMethods.GetUnixMillisecondsNow();
long unixSecondsNow = DateTimeMethods.GetUnixSecondsNow();
```

### StringMethods

#### Converting between UTF-8 and Base64 strings

```
// Using extension methods
string utf8 = "hello";
string base64 = utf8.Utf8ToBase64(); // aGVsbG8=

base64 = "Ym9uam91cg==";
utf8 = base64.Base64ToUtf8(); // bonjour
```

```
// Using static methods
string utf8 = "hello";
string base64 = StringMethods.Utf8ToBase64(utf8); // aGVsbG8=

base64 = "Ym9uam91cg==";
utf8 = StringMethods.Base64ToUtf8(base64); // bonjour
```

## Supported versions

| Version | Supported          |
| ------- | ------------------ |
| 3.x     | :white_check_mark: |
| 2.x     | :x:                |
| 1.x     | :x:                |
