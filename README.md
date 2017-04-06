# Csh7
Cs + Push7 = Csh7

Csh7 is very simple Push7 library for C# users.

**This project is not official!**

### Usage
```Cs
using Csh7;

push7.GetInfo(string apikey, string datakey); // Get Application Info

push7.Push(string appNumber, string title, string content, string iconURL, string URL, string apikey); // Create Push
```

_little more real example_
```Cs
using Csh7;

push7.GetInfo("1145141919810", "name");
// will return specified key value or any exception.

push7.Push("1145141919810", "test", "This is test.", "http://example.com/icon.png", "http://example.com", "1145141919810INMUC");
// will return pushid or any exception.
```

for get more infomation about push7 API, please go [here](https://esa-pages.io/p/sharing/3426/posts/203/80ff5595487df69dfe38.html)!

### NuGet
```
PM> Install-Package Csh7
```
[NuGet Gallery](https://www.nuget.org/packages/Csh7)

### Special Thanks
* [Push7](https://push7.jp/): Awesome Service!
* [DynamicJson](https://dynamicjson.codeplex.com/): Using in project.
* [a-r-g-v/push7-python](https://github.com/a-r-g-v/push7-python): Coolest official python library, this project inspired from this!