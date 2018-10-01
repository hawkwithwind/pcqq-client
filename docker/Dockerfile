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

COPY . /home/myapp
WORKDIR /home/myapp

RUN adduser pcqq
USER pcqq

ENTRYPOINT ["msbuild"]

