# GRPC C#示例程序
本源代码来源于微软官方[教程：在 ASP.NET Core 中创建 gRPC 客户端和服务器](https://learn.microsoft.com/zh-cn/aspnet/core/tutorials/grpc/grpc-start?view=aspnetcore-8.0&tabs=visual-studio)
以及油管博主[IAmTimCorey](https://www.youtube.com/@IAmTimCorey)的视频教程：[Intro to gRPC in C# - How To Get Started](https://www.youtube.com/watch?v=QyxCX2GYHxk)。
有基于ASP.Net core的gRPC服务端和C# .NetCore gRPC客户端的程序，基于Visual Studio 2022开发。

# 关于gRPC和Google protobuf
[gRPC](https://grpc.io/)是一个高性能的开源的通用RPC框架，由Google公司开发，支持常用的C++、Java、Python、C#/.Net、Go、Node、Dart、Kotlin、Object-C、PHP、Ruby等语言，采用[protobuf](https://github.com/protocolbuffers/protobuf)作为数据交换格式，并且采用C++开发，支持Windows 、Linux、macOS跨平台开发。对于跨语言服务调用非常方便，只要使用protobuf定义接口协议，然后按照gRPC语言SDK调用即可。比如我们使用C++对环保数采仪器设备通过串口或者网口传送的数据协议如Modbus协议、HJ212协议、或者厂商自定义的协议进行解析之后，将数据存放到本地数据库，这个时候我们如何将C++的数据传给前端网页呢？
这个时候可以使用多种方式。比如通过数据库、HTTP协议、WebSocket协议、RPC远程过程调用等方式。
我之前做环保的时候，采用C++和环保硬件设备打交道，通过C++后台程序将数采仪数据解析之后存入到本地Sqlite数据库中（分表分页存储），然后由于展示的网页比较简单，只是用网页展示当前站点的数据，前端采用ElementUI和Vue.js，后端采用Node.js。另外，C++后台写了一套RPC服务端接口，Node.js通过RPC客户端调用C++的后台RPC服务，双方之间通过Google Protobuf数据协议交互。


在 gRPC 中，客户端应用程序可以像本地对象一样直接调用不同机器上的服务器应用程序上的方法，从而使您更轻松地创建分布式应用程序和服务。与许多 RPC 系统一样，gRPC 基于定义服务的思想，指定可以远程调用的方法及其参数和返回类型。在服务器端，服务器实现这个接口并运行一个gRPC服务器来处理客户端调用。在客户端，客户端有一个存根（在某些语言中简称为客户端），它提供与服务器相同的方法。
![gRPC服务调用示意图](https://img-blog.csdnimg.cn/direct/2851aab985b24be48e378cf1cbadae24.png)
gRPC 客户端和服务器可以在各种环境中运行和相互通信（从 Google 内部的服务器到您自己的桌面），并且可以用 gRPC 支持的任何语言编写。例如，您可以使用 Java 轻松创建 gRPC 服务器，并使用 Go、Python 或 Ruby 编写客户端。此外，最新的 Google API 将具有其接口的 gRPC 版本，让您可以轻松地将 Google 功能构建到您的应用程序中。

# 在 C#和ASP.NET Core中创建 gRPC 客户端和服务器
在 C#和ASP.NET Core中创建 gRPC 客户端和服务器十分简单，可以参考微软官方的几篇文章：
- [使用 C# 的 gRPC 服务](https://learn.microsoft.com/zh-cn/aspnet/core/grpc/basics?view=aspnetcore-8.0)
- [使用 .NET 客户端调用 gRPC 服务](https://learn.microsoft.com/zh-cn/aspnet/core/grpc/client?view=aspnetcore-8.0)
- [教程：在 ASP.NET Core 中创建 gRPC 客户端和服务器](https://learn.microsoft.com/zh-cn/aspnet/core/tutorials/grpc/grpc-start?view=aspnetcore-8.0&tabs=visual-studio)
![Create a gRPC client and server in ASP.NET Core 7](https://img-blog.csdnimg.cn/direct/c182a4ac94144088badf8edebe6652e6.png)

![Create a gRPC client and server in ASP.NET Core 8](https://img-blog.csdnimg.cn/direct/564bc4cac01a43e7a414df90311f4266.png)

对应在VS2022中分别运行GRPC服务端和客户端的`SayHello`示例接口调用如下图所示：
![在 ASP.NET Core 中创建 gRPC 客户端和服务器 ](https://img-blog.csdnimg.cn/direct/f96374b967314d84b4c9fe4b3bb47c86.png)
- [C# / .NET](https://grpc.io/docs/languages/csharp/)

##  C# 中的 gRPC 简介视频教程
另外，油管上面有来自UP主[IAmTimCorey](https://www.youtube.com/@IAmTimCorey)于2019年9月30日创作的一篇关于C#中使用[GRPC](https://grpc.io/)的视频，地址为：[Intro to gRPC in C# - How To Get Started](https://www.youtube.com/watch?v=QyxCX2GYHxk)
相关示例代码我已经上传到我的Github仓库，地址为：[https://github.com/ccf19881030/GrpcGreeterDemo](https://github.com/ccf19881030/GrpcGreeterDemo)
![GRPC C#示例程序](https://img-blog.csdnimg.cn/direct/7b8cf47637cd45a9b81aca1d3bc81f01.png)
我们`git clone https://github.com/ccf19881030/GrpcGreeterDemo.git`	源代码到本地后，使用`VS2022`打开`GrpcGreeterDemo.sln`解决方案，里面有`GrpcGreeter`和`GrpcGreeterClient`两个项目，分别是基于ASP.Net Core的gRPC服务端程序和基于.NetCore控制台的gRPC客户端程序，我的VS2022使用的是.NetCore 7.0。如下图所示：
![GRPC C#示例程序](https://img-blog.csdnimg.cn/direct/56de5f0d0c9f4e86a50167e2411b238c.png)
我们首选将`GrpcGreeter` gRPC服务端程序作为启动项目，然后运行，如下图所示：
![启动gRPC服务端](https://img-blog.csdnimg.cn/direct/99860f545f8e440eb1c11fb8cf0cccc2.png)
接着我们再将`GrpcGreeterClient` gRPC客户端作为启动项目，然后运行，结果如下图所示：
![启动运行gRPC客户端](https://img-blog.csdnimg.cn/direct/ea7f53a4c7ca416e84a7baf35adc6b40.png)
## 参考资料
- [https://grpc.io/](https://grpc.io/)
- [Introduction to gRPC](https://grpc.io/docs/what-is-grpc/introduction/)
- [gRPC-Quick start](https://grpc.io/docs/languages/csharp/)
- [gRPC in 5 minutes | Eric Anderson & Ivy Zhuang, Google](https://www.youtube.com/watch?v=njC24ts24Pg)
- [Protocol Buffers](https://protobuf.dev/)
- [Protocol Buffers - Google's data interchange format](https://github.com/protocolbuffers/protobuf)
- [使用 ASP.NET Core 的 gRPC 服务](https://learn.microsoft.com/zh-cn/aspnet/core/grpc/aspnetcore?view=aspnetcore-8.0&tabs=visual-studio)
- [Intro to gRPC in C# - How To Get Started](https://www.youtube.com/watch?v=QyxCX2GYHxk)
- [https://github.com/ccf19881030/GrpcGreeterDemo](https://github.com/ccf19881030/GrpcGreeterDemo)
- [将本地托管代码添加到 GitHub](https://docs.github.com/zh/migrations/importing-source-code/using-the-command-line-to-import-source-code/adding-locally-hosted-code-to-github)
