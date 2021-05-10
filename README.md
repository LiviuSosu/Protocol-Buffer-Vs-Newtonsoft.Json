# Protocol-Buffer-Vs-Newtonsoft.Json

Comparison bewteen Google Protocol Buffer and Newtonsoft.Json. 

Video may be found here:

<a href="http://www.youtube.com/watch?feature=player_embedded&v=KNi18e0p7zQ
" target="_blank"><img src="http://img.youtube.com/vi/KNi18e0p7zQ/0.jpg" 
alt="[.NET Core] Comparison between Protocol buffer vs Newtonsoft.Json" width="240" height="180" border="10" /></a>

Google Protocol Serializer [documentation](https://developers.google.com/protocol-buffers/docs/csharptutorial) :

You will find the protoc.exe in this repository. However it my be outdated, so you can download from [here](https://github.com/protocolbuffers/protobuf/releases). You may find it on the bottom of the list looking like protoc-version-operating_system.zip. For exemple: protoc-3.14.0-win32.zip

We will continue this article by showing you how to run the Protobuf command.

Go the the location where you have the protoc.exe downloaded. Open any command line utility. There is no need to run it as administrator.

The command has the following pattern:

---
> protoc -I="_your_class_path_" --cdharp_out="_your_path_where_you_want_your_otputed_proto_class_" "_your_proto_executable_"
---

The command should look like:

---

> protoc -I="C:\Users\Liviu\Career\Articles\Protocol-Buffer-Vs-Newtonsoft.Json\ConsoleApp1" --csharp_out="C:\Users\Liviu\Career\Articles\Protocol-Buffer-Vs-Newtonsoft.Json\ConsoleApp1" "C:\Users\Liviu\Career\Articles\Protocol-Buffer-Vs-Newtonsoft.Json\ConsoleApp1\demo-interface.proto"

---

Right now all you have to do is to run the solution and two methods will be called:
> SerializeProtoBuff(dataSize)
  and
>SerializeJson(dataSize)

We will skip showing how to utilize the NewtonSoft.Json library.

Contributions are wellcomed! :-)
