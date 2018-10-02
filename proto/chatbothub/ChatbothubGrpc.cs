// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: chatbothub.proto
// </auto-generated>
// Original file comments:
// Copyright 2015 gRPC authors.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Chatbothub {
  /// <summary>
  /// The greeting service definition.
  /// </summary>
  public static partial class ChatBotHub
  {
    static readonly string __ServiceName = "chatbothub.ChatBotHub";

    static readonly grpc::Marshaller<global::Chatbothub.EventRequest> __Marshaller_chatbothub_EventRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Chatbothub.EventRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Chatbothub.EventReply> __Marshaller_chatbothub_EventReply = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Chatbothub.EventReply.Parser.ParseFrom);

    static readonly grpc::Method<global::Chatbothub.EventRequest, global::Chatbothub.EventReply> __Method_EventTunnel = new grpc::Method<global::Chatbothub.EventRequest, global::Chatbothub.EventReply>(
        grpc::MethodType.DuplexStreaming,
        __ServiceName,
        "EventTunnel",
        __Marshaller_chatbothub_EventRequest,
        __Marshaller_chatbothub_EventReply);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Chatbothub.ChatbothubReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of ChatBotHub</summary>
    public abstract partial class ChatBotHubBase
    {
      /// <summary>
      /// Sends a greeting
      /// </summary>
      /// <param name="requestStream">Used for reading requests from the client.</param>
      /// <param name="responseStream">Used for sending responses back to the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>A task indicating completion of the handler.</returns>
      public virtual global::System.Threading.Tasks.Task EventTunnel(grpc::IAsyncStreamReader<global::Chatbothub.EventRequest> requestStream, grpc::IServerStreamWriter<global::Chatbothub.EventReply> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for ChatBotHub</summary>
    public partial class ChatBotHubClient : grpc::ClientBase<ChatBotHubClient>
    {
      /// <summary>Creates a new client for ChatBotHub</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public ChatBotHubClient(grpc::Channel channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for ChatBotHub that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public ChatBotHubClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected ChatBotHubClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected ChatBotHubClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      /// <summary>
      /// Sends a greeting
      /// </summary>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncDuplexStreamingCall<global::Chatbothub.EventRequest, global::Chatbothub.EventReply> EventTunnel(grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return EventTunnel(new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Sends a greeting
      /// </summary>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncDuplexStreamingCall<global::Chatbothub.EventRequest, global::Chatbothub.EventReply> EventTunnel(grpc::CallOptions options)
      {
        return CallInvoker.AsyncDuplexStreamingCall(__Method_EventTunnel, null, options);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override ChatBotHubClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new ChatBotHubClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(ChatBotHubBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_EventTunnel, serviceImpl.EventTunnel).Build();
    }

  }
}
#endregion
