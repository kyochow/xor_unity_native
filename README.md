# xor_unity_native

#### 介绍
一个超简单的native plugin demo，c实现，用于文件加密(例如lua和配置文件等)

使用cmake

支持iOS，Android，Mac，Windows平台编译native库

使用最基础的异或加密，可以防一防小白
加密不重要，重点是各个平台编译和基本写法

使用说明及特性如下

1. 菜单栏 Encrypt/Encode 将Origin下的一个lua脚本加密到Encode下
2. 菜单栏 Encrypt/Decode 将Encode下的一个lua脚本解密到Decode下
3. 加密解密过程 0内存拷贝，0 GC
4. 附带各个平台的构建shell/bat
5. 具体的源码，都是有附带的，可以直接应用到项目中
6. 附带Build/Load AssetBundle的范例

介绍博客在这里： https://kyochow.github.io/articles/2020/10/12/1602495480321.html
