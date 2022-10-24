# DLL-Useful

NuGet package of useful methods. 

## Sion.Useful.Classes

```
DirectedGraph<T> : IGraph<T>
Graph<T> : IGraph<T>
Node<T>
WeightedDirectedGraph<TValue, TWeight> : IWeightedGraph<TValue, TWeight>
WeightedGraph<TValue, TWeight> : IWeightedGraph<TValue, TWeight>
WeightedNode<TValue, TWeight>
```

## Sion.Useful.DateTimeMethods

```
public static long ConvertToUnixMilliseconds(DateTime date)
public static long ConvertToUnixSeconds(DateTime date)
public static long GetUnixMillisecondsNow()
public static long GetUnixSecondsNow()
```

## Sion.Useful.DecimalMethods

```
public static decimal Truncate(decimal d, int precision)
```

## Sion.Useful.Interfaces

```
IGraph<T>
IWeightedGraph<TValue, TWeight>
```

## Sion.Useful.StringMethods

```
public static string Base64ToUtf8(string base64)
public static string Utf8ToBase64(string utf8)
```
