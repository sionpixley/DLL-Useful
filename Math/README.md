# Sion.Useful.Math

NuGet package that provides static and extension methods to float, double, and decimal.

## Sion.Useful.Math.NumberManipulation

```
public static float Truncate(this float f, int precision)
public static double Truncate(this double d, int precision)
public static decimal Truncate(this decimal d, int precision)
```

## How to use

First, download the Sion.Useful.Math NuGet package, then include this using statement at the top of the file:

```
using Sion.Useful.Math;
```

### NumberManipulation

#### Truncating a decimal point number

```
// Using extension methods
float f = 12.567f;
f = f.Truncate(2); // 12.56f

double d1 = 8.291;
d1 = d1.Truncate(1); // 8.2

decimal d2 = 85.1235m;
d2 = d2.Truncate(3); // 85.123m
```

```
// Using static methods
float f = 12.567f;
f = NumberManipulation.Truncate(f, 2); // 12.56f

double d1 = 8.291;
d1 = NumberManipulation.Truncate(d1, 1); // 8.2

decimal d2 = 85.1235m;
d2 = NumberManipulation.Truncate(d2, 3); // 85.123m
```
