// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: chatbothub.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Chatbothub {

  /// <summary>Holder for reflection information generated from chatbothub.proto</summary>
  public static partial class ChatbothubReflection {

    #region Descriptor
    /// <summary>File descriptor for chatbothub.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static ChatbothubReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChBjaGF0Ym90aHViLnByb3RvEgpjaGF0Ym90aHViIj0KDEV2ZW50UmVxdWVz",
            "dBIRCglldmVudFR5cGUYASABKAkSDAoEYm9keRgCIAEoCRIMCgR0eGlkGAMg",
            "ASgJIjsKCkV2ZW50UmVwbHkSEQoJZXZlbnRUeXBlGAEgASgJEgwKBGJvZHkY",
            "AiABKAkSDAoEdHhpZBgDIAEoCTJTCgpDaGF0Qm90SHViEkUKC0V2ZW50VHVu",
            "bmVsEhguY2hhdGJvdGh1Yi5FdmVudFJlcXVlc3QaFi5jaGF0Ym90aHViLkV2",
            "ZW50UmVwbHkiACgBMAFCMAobbmV0Lmhhd2t3aXRod2luZC5jaGF0Ym90aHVi",
            "Qg9DaGF0Qm90SHViUHJvdG9QAWIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Chatbothub.EventRequest), global::Chatbothub.EventRequest.Parser, new[]{ "EventType", "Body", "Txid" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Chatbothub.EventReply), global::Chatbothub.EventReply.Parser, new[]{ "EventType", "Body", "Txid" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  /// The request message containing the user's name.
  /// </summary>
  public sealed partial class EventRequest : pb::IMessage<EventRequest> {
    private static readonly pb::MessageParser<EventRequest> _parser = new pb::MessageParser<EventRequest>(() => new EventRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<EventRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Chatbothub.ChatbothubReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public EventRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public EventRequest(EventRequest other) : this() {
      eventType_ = other.eventType_;
      body_ = other.body_;
      txid_ = other.txid_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public EventRequest Clone() {
      return new EventRequest(this);
    }

    /// <summary>Field number for the "eventType" field.</summary>
    public const int EventTypeFieldNumber = 1;
    private string eventType_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string EventType {
      get { return eventType_; }
      set {
        eventType_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "body" field.</summary>
    public const int BodyFieldNumber = 2;
    private string body_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Body {
      get { return body_; }
      set {
        body_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "txid" field.</summary>
    public const int TxidFieldNumber = 3;
    private string txid_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Txid {
      get { return txid_; }
      set {
        txid_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as EventRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(EventRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (EventType != other.EventType) return false;
      if (Body != other.Body) return false;
      if (Txid != other.Txid) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (EventType.Length != 0) hash ^= EventType.GetHashCode();
      if (Body.Length != 0) hash ^= Body.GetHashCode();
      if (Txid.Length != 0) hash ^= Txid.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (EventType.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(EventType);
      }
      if (Body.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Body);
      }
      if (Txid.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Txid);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (EventType.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(EventType);
      }
      if (Body.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Body);
      }
      if (Txid.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Txid);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(EventRequest other) {
      if (other == null) {
        return;
      }
      if (other.EventType.Length != 0) {
        EventType = other.EventType;
      }
      if (other.Body.Length != 0) {
        Body = other.Body;
      }
      if (other.Txid.Length != 0) {
        Txid = other.Txid;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            EventType = input.ReadString();
            break;
          }
          case 18: {
            Body = input.ReadString();
            break;
          }
          case 26: {
            Txid = input.ReadString();
            break;
          }
        }
      }
    }

  }

  /// <summary>
  /// The response message containing the greetings
  /// </summary>
  public sealed partial class EventReply : pb::IMessage<EventReply> {
    private static readonly pb::MessageParser<EventReply> _parser = new pb::MessageParser<EventReply>(() => new EventReply());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<EventReply> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Chatbothub.ChatbothubReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public EventReply() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public EventReply(EventReply other) : this() {
      eventType_ = other.eventType_;
      body_ = other.body_;
      txid_ = other.txid_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public EventReply Clone() {
      return new EventReply(this);
    }

    /// <summary>Field number for the "eventType" field.</summary>
    public const int EventTypeFieldNumber = 1;
    private string eventType_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string EventType {
      get { return eventType_; }
      set {
        eventType_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "body" field.</summary>
    public const int BodyFieldNumber = 2;
    private string body_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Body {
      get { return body_; }
      set {
        body_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "txid" field.</summary>
    public const int TxidFieldNumber = 3;
    private string txid_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Txid {
      get { return txid_; }
      set {
        txid_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as EventReply);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(EventReply other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (EventType != other.EventType) return false;
      if (Body != other.Body) return false;
      if (Txid != other.Txid) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (EventType.Length != 0) hash ^= EventType.GetHashCode();
      if (Body.Length != 0) hash ^= Body.GetHashCode();
      if (Txid.Length != 0) hash ^= Txid.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (EventType.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(EventType);
      }
      if (Body.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Body);
      }
      if (Txid.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Txid);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (EventType.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(EventType);
      }
      if (Body.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Body);
      }
      if (Txid.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Txid);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(EventReply other) {
      if (other == null) {
        return;
      }
      if (other.EventType.Length != 0) {
        EventType = other.EventType;
      }
      if (other.Body.Length != 0) {
        Body = other.Body;
      }
      if (other.Txid.Length != 0) {
        Txid = other.Txid;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            EventType = input.ReadString();
            break;
          }
          case 18: {
            Body = input.ReadString();
            break;
          }
          case 26: {
            Txid = input.ReadString();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code