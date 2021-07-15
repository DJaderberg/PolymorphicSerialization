Example project that avoids the top-level polymorphic serialization in ASP.NET Core controllers

Done by implementing a local version of SystemTextJsonOutputFormatter and registering it in Startup.cs
Only one line of code has been changed, now it is 
```csharp
var objectType = context.ObjectType ?? context.Object?.GetType() ?? typeof(object);
```
instead of
```csharp
var objectType = context.Object?.GetType() ?? context.ObjectType ?? typeof(object);
```