# Protocol-Buffer-Vs-Newtonsoft.Json

Comparison bewteen Google Protocol Buffer and Newtonsoft.Json. 

Video may be found here: https://youtu.be/KNi18e0p7zQ

Google Protocol Serializer documentation: https://developers.google.com/protocol-buffers/docs/csharptutorial 

You will find the protoc.exe in this repository. However it my be outdated, so you can download https://github.com/protocolbuffers/protobuf/releases. You may find it on the bottom of the list looking like protoc-version-operating_system.zip. For exemple: protoc-3.14.0-win32.zip

We will continue this article by showing you how to run the Protobuf command.

Go the the location where you have the protoc.exe downloaded. Oppen any commadn line utitliy. There is no need to run it as administrator.

protoc -I="C:\Users\Liviu\Career\Articles\Protocol-Buffer-Vs-Newtonsoft.Json\ConsoleApp1" --csharp_out="C:\Users\Liviu\Career\Articles\Protocol-Buffer-Vs-Newtonsoft.Json\ConsoleApp1" "C:\Users\Liviu\Career\Articles\Protocol-Buffer-Vs-Newtonsoft.Json\ConsoleApp1\demo-interface.proto"

We will skip showing how to utilize the NewtonSoft.Json library.

Contributions are wellcomed! :-)
