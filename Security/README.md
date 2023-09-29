# Sion.Useful.Security

NuGet package that provides useful cryptographically-strong static methods. Specifically, random value generation.

## Sion.Useful.Security.Random

```
public static bool Bool()
public static byte[] Bytes(int numOfBytes = 16)
public static double Double()
public static float Float()
public static int Int()
public static short Int16()
public static int Int32()
public static long Int64()
public static long Long()
public static short Short()
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
