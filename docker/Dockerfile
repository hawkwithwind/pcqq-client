FROM mono:5.14-slim
RUN sed -i 's/deb.debian.org/mirrors.ustc.edu.cn/g' /etc/apt/sources.list
RUN apt-get update

ENV TZ=Asia/Shanghai
RUN apt-get install -y tzdata
RUN rm /etc/localtime && \
    ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && \
    echo $TZ > /etc/timezone

RUN apt-get install -y libssl-dev build-essential libz-dev
RUN apt-get install -y openssl

RUN apt-get install -y locales && \
    locale-gen && \
    sed -i 's/# zh_CN.UTF-8 UTF-8/zh_CN.UTF-8 UTF-8/g' /etc/locale.gen && \
    locale-gen && update-locale
ENV LANG="zh_CN.UTF-8"
RUN locale -a

RUN apt-get install -y mono-complete
RUN apt-get install -y newtonsoft.json
RUN apt-get install -y wget

RUN wget https://dist.nuget.org/win-x86-commandline/latest/nuget.exe && \
    mkdir -p /usr/lib/nuget/ && \
    mv nuget.exe /usr/lib/nuget

RUN cd /usr/lib/cli && \
    mono /usr/lib/nuget/nuget.exe install Google.Protobuf && \
    mono /usr/lib/nuget/nuget.exe install Google.Protobuf.Tools && \
    mono /usr/lib/nuget/nuget.exe install Grpc && \
    mono /usr/lib/nuget/nuget.exe install Grpc.Tools && \
    mono /usr/lib/nuget/nuget.exe install System.ValueTuple
    
COPY . /home/myapp
WORKDIR /home/myapp

RUN adduser pcqq
RUN chown -R pcqq:pcqq /home/myapp

RUN cp -R /root/.nuget /home/pcqq/.nuget && \
    chown -R pcqq:pcqq /home/pcqq/.nuget

USER pcqq

ENTRYPOINT ["msbuild"]

