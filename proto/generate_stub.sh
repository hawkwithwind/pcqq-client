#!/bin/bash
protoc -I chatbothub/ --csharp_out chatbothub --grpc_out chatbothub chatbothub/chatbothub.proto --plugin=protoc-gen-grpc=$GRPC_HOME/grpc_csharp_plugin
