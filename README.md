# PushMessageServicer
这是一个基于.net平台上的对个推服务的一个封装；
本应用可以以服务的形式安装到window平台上；
服务使用Remoting服务，在端口19536上注册代理接口；
注册代理接口为 Push2Clinet.cs;使用时请复制该接口到项目中，作为本地代理；
Remoting通信协议为TCP/IP;

