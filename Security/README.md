# Sion.Useful.Security

NuGet package that provides useful cryptographically-strong static methods. Specifically, random value generation.

## Sion.Useful.Security.Random

```
public static bool Bool()
public static byte[] Bytes(int numOfBytes = 16)
public static double Double()
public static double Double(double min, double max)
public static float Float()
public static float Float(float min, float max)
public static int Int()
public static int Int(int min, int max)
public static short Int16()
public static short Int16(short min, short max)
public static int Int32()
public static int Int32(int min, int max)
public static long Int64()
public static long Int64(long min, long max)
public static long Long()
public static long Long(long min, long max)
public static short Short()
public static short Short(short min, short max)
```

## How to use:

First, download the Sion.Useful.Security NuGet package, then include this using statement at the top of the file:

```
using Sion.Useful.Security;
```

Alternatively, if you're having ambiguous references between Sion.Useful.Security.Random and System.Random, and you only want to use Sion.Useful.Security.Random:

```
using Random = Sion.Useful.Security.Random;
```

### Random

```
bool randomBoolean = Random.Bool();
byte[] randomBytes = Random.Bytes(20); // Array will be of length 20
double randomDouble = Random.Double();
float randomFloat = Random.Float();
int randomInt = Random.Int(); // Note: You can also use Random.Int32
long randomLong = Random.Long(); // Note: You can also use Random.Int64
short randomShort = Random.Short(); // Note: You can also use Random.Int16
```

#### Getting random values within a range:

```
double randomDouble = Random.Double(0, 1); // Value will be between 0 and 1 (exclusive)
float randomFloat = Random.Float(67.2, 73.08); // Value will be between 67.2 and 73.08 (exclusive)
int randomInt = Random.Int(-63, 300); // Value will be between -63 and 300 (exclusive)
long randomLong = Random.Long(445, 732); // Value will be between 445 and 732 (exclusive)
short randomShort = Random.Short(2, 100); // Value will be between 2 and 100 (exclusive)
```
