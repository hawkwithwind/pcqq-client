# pcqq-client
restful API for pcqq-protocol

## How to build
```
#/ git submodule init
#/ make
```

## How to run
```
#/ docker run -it --rm qqlogintest
```

note that "qqlogintest" is what project you want to build, you can change this in Makefile

```
PROJECT=QQLoginTest
PROJECT_IMAGE=qqlogintest
```

## How to add QQ num and pass into QQLoginTest

modify QQLoginTest/Program.cs

```
var user = new QQUser(0, "");
```


