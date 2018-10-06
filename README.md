# pcqq-client
restful API for pcqq-protocol

## How to build
```
#/ git submodule init
#/ git submodule update
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

## How to sync to newest version PCQQ-Protocol

this project uses git submodule command, for more info see git-submodule(1) for details.

```
#/ git submodule update --recursive --remote
```
note that newest PCQQ-Protocol MAY OR MAY NOT compile with current project.






