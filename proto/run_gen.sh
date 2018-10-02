#!/bin/bash

docker run --rm -v `pwd`:/home/myapp mono-pcqq:proto ./generate_stub.sh

