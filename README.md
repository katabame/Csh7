# Csh7
Cs + Push7 = Csh7

Csh7 is very simple Push7 library for C# users.

**This project is not official!**

### Usage

**Using with Client()**
```csharp
using Csh7;

Push7.Client(string appNumber, string apiKey);

Push7.GetInfo(string datakey); // Get Application Info

Push7.Push(string title, string content, string iconURL, string URL); // Create Push
```

_little more real example_
```csharp
using Csh7;

Push7.Client("12831738", "219182s390138")

Push7.GetInfo("name");
// will return specified key value or any exception.

Push7.Push("Example Push", "This is test push.", "https://example.com/icon.png", "https://example.com");
// will return pushid or any exception.
```

for get more infomation about push7 API, please go [here](https://esa-pages.io/p/sharing/3426/posts/203/80ff5595487df69dfe38.html)!

### NuGet
```shell
PM> Install-Package Csh7
```
[NuGet Gallery](https://www.nuget.org/packages/Csh7)

### Special Thanks
* [Push7](https://push7.jp/): Awesome Service!
* [DynamicJson](https://dynamicjson.codeplex.com/): Using in project.
* [a-r-g-v/push7-python](https://github.com/a-r-g-v/push7-python): Coolest official python library, this project inspired from this!