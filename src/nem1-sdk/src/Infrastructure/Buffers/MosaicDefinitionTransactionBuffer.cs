// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

using System;
using io.nem1.sdk.Infrastructure.Imported.FlatBuffers;

namespace io.nem1.sdk.Infrastructure.Buffers
{
    internal struct MosaicDefinitionTransactionBuffer : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  internal static MosaicDefinitionTransactionBuffer GetRootAsMosaicDefinitionTransactionBuffer(ByteBuffer _bb) { return GetRootAsMosaicDefinitionTransactionBuffer(_bb, new MosaicDefinitionTransactionBuffer()); }
  internal static MosaicDefinitionTransactionBuffer GetRootAsMosaicDefinitionTransactionBuffer(ByteBuffer _bb, MosaicDefinitionTransactionBuffer obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  internal MosaicDefinitionTransactionBuffer __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  internal int TransactionType { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  internal short Version { get { int o = __p.__offset(6); return o != 0 ? __p.bb.GetShort(o + __p.bb_pos) : (short)0; } }
  internal short Network { get { int o = __p.__offset(8); return o != 0 ? __p.bb.GetShort(o + __p.bb_pos) : (short)0; } }
  internal int Timestamp { get { int o = __p.__offset(10); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  internal int PublicKeyLen { get { int o = __p.__offset(12); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  internal sbyte PublicKey(int j) { int o = __p.__offset(14); return o != 0 ? __p.bb.GetSbyte(__p.__vector(o) + j * 1) : (sbyte)0; }
  internal int PublicKeyLength { get { int o = __p.__offset(14); return o != 0 ? __p.__vector_len(o) : 0; } }
  internal ArraySegment<byte>? GetPublicKeyBytes() { return __p.__vector_as_arraysegment(14); }
  internal long Fee { get { int o = __p.__offset(16); return o != 0 ? __p.bb.GetLong(o + __p.bb_pos) : (long)0; } }
  internal int Deadline { get { int o = __p.__offset(18); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  internal int MosaicDefinitionStructureLength { get { int o = __p.__offset(20); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  internal int LengthCreatorPublicKey { get { int o = __p.__offset(22); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  internal sbyte CreatorPublicKey(int j) { int o = __p.__offset(24); return o != 0 ? __p.bb.GetSbyte(__p.__vector(o) + j * 1) : (sbyte)0; }
  internal int CreatorPublicKeyLength { get { int o = __p.__offset(24); return o != 0 ? __p.__vector_len(o) : 0; } }
  internal ArraySegment<byte>? GetCreatorPublicKeyBytes() { return __p.__vector_as_arraysegment(24); }
  internal int LengthOfMosaicIdStructure { get { int o = __p.__offset(26); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  internal int LengthOfNamespaceIdString { get { int o = __p.__offset(28); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  internal sbyte NamespaceIdString(int j) { int o = __p.__offset(30); return o != 0 ? __p.bb.GetSbyte(__p.__vector(o) + j * 1) : (sbyte)0; }
  internal int NamespaceIdStringLength { get { int o = __p.__offset(30); return o != 0 ? __p.__vector_len(o) : 0; } }
  internal ArraySegment<byte>? GetNamespaceIdStringBytes() { return __p.__vector_as_arraysegment(30); }
  internal int LengthOfMosaicNameString { get { int o = __p.__offset(32); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  internal sbyte MosaicNameString(int j) { int o = __p.__offset(34); return o != 0 ? __p.bb.GetSbyte(__p.__vector(o) + j * 1) : (sbyte)0; }
  internal int MosaicNameStringLength { get { int o = __p.__offset(34); return o != 0 ? __p.__vector_len(o) : 0; } }
  internal ArraySegment<byte>? GetMosaicNameStringBytes() { return __p.__vector_as_arraysegment(34); }
  internal int LengthOfDescription { get { int o = __p.__offset(36); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  internal sbyte DescriptionString(int j) { int o = __p.__offset(38); return o != 0 ? __p.bb.GetSbyte(__p.__vector(o) + j * 1) : (sbyte)0; }
  internal int DescriptionStringLength { get { int o = __p.__offset(38); return o != 0 ? __p.__vector_len(o) : 0; } }
  internal ArraySegment<byte>? GetDescriptionStringBytes() { return __p.__vector_as_arraysegment(38); }
  internal int NoOfProperties { get { int o = __p.__offset(40); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  internal MosaicPropertyBuffer? Properties(int j) { int o = __p.__offset(42); return o != 0 ? (MosaicPropertyBuffer?)(new MosaicPropertyBuffer()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  internal int PropertiesLength { get { int o = __p.__offset(42); return o != 0 ? __p.__vector_len(o) : 0; } }
  internal MosaicLevyBuffer? MosaicLevy(int j) { int o = __p.__offset(44); return o != 0 ? (MosaicLevyBuffer?)(new MosaicLevyBuffer()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  internal int MosaicLevyLength { get { int o = __p.__offset(44); return o != 0 ? __p.__vector_len(o) : 0; } }
  internal int LenFeeSinkAddress { get { int o = __p.__offset(46); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  internal sbyte FeeSinkAddress(int j) { int o = __p.__offset(48); return o != 0 ? __p.bb.GetSbyte(__p.__vector(o) + j * 1) : (sbyte)0; }
  internal int FeeSinkAddressLength { get { int o = __p.__offset(48); return o != 0 ? __p.__vector_len(o) : 0; } }
  internal ArraySegment<byte>? GetFeeSinkAddressBytes() { return __p.__vector_as_arraysegment(48); }
  internal long FeeQuantity { get { int o = __p.__offset(50); return o != 0 ? __p.bb.GetLong(o + __p.bb_pos) : (long)0; } }

  internal static Offset<MosaicDefinitionTransactionBuffer> CreateMosaicDefinitionTransactionBuffer(FlatBufferBuilder builder,
      int transactionType = 0,
      short version = 0,
      short network = 0,
      int timestamp = 0,
      int publicKeyLen = 0,
      VectorOffset publicKeyOffset = default(VectorOffset),
      ulong fee = 0,
      int deadline = 0,
      int mosaicDefinitionStructureLength = 0,
      int lengthCreatorPublicKey = 0,
      VectorOffset creatorPublicKeyOffset = default(VectorOffset),
      int lengthOfMosaicIdStructure = 0,
      int lengthOfNamespaceIdString = 0,
      VectorOffset namespaceIdStringOffset = default(VectorOffset),
      int lengthOfMosaicNameString = 0,
      VectorOffset mosaicNameStringOffset = default(VectorOffset),
      int lengthOfDescription = 0,
      VectorOffset descriptionStringOffset = default(VectorOffset),
      int noOfProperties = 0,
      VectorOffset propertiesOffset = default(VectorOffset),
      VectorOffset mosaicLevyOffset = default(VectorOffset),
      int lenFeeSinkAddress = 0,
      VectorOffset feeSinkAddressOffset = default(VectorOffset),
      ulong feeQuantity = 0) {
    builder.StartObject(24);
    MosaicDefinitionTransactionBuffer.AddFeeQuantity(builder, feeQuantity);
    MosaicDefinitionTransactionBuffer.AddFee(builder, fee);
    MosaicDefinitionTransactionBuffer.AddFeeSinkAddress(builder, feeSinkAddressOffset);
    MosaicDefinitionTransactionBuffer.AddLenFeeSinkAddress(builder, lenFeeSinkAddress);
    MosaicDefinitionTransactionBuffer.AddMosaicLevy(builder, mosaicLevyOffset);
    MosaicDefinitionTransactionBuffer.AddProperties(builder, propertiesOffset);
    MosaicDefinitionTransactionBuffer.AddNoOfProperties(builder, noOfProperties);
    MosaicDefinitionTransactionBuffer.AddDescriptionString(builder, descriptionStringOffset);
    MosaicDefinitionTransactionBuffer.AddLengthOfDescription(builder, lengthOfDescription);
    MosaicDefinitionTransactionBuffer.AddMosaicNameString(builder, mosaicNameStringOffset);
    MosaicDefinitionTransactionBuffer.AddLengthOfMosaicNameString(builder, lengthOfMosaicNameString);
    MosaicDefinitionTransactionBuffer.AddNamespaceIdString(builder, namespaceIdStringOffset);
    MosaicDefinitionTransactionBuffer.AddLengthOfNamespaceIdString(builder, lengthOfNamespaceIdString);
    MosaicDefinitionTransactionBuffer.AddLengthOfMosaicIdStructure(builder, lengthOfMosaicIdStructure);
    MosaicDefinitionTransactionBuffer.AddCreatorPublicKey(builder, creatorPublicKeyOffset);
    MosaicDefinitionTransactionBuffer.AddLengthCreatorPublicKey(builder, lengthCreatorPublicKey);
    MosaicDefinitionTransactionBuffer.AddMosaicDefinitionStructureLength(builder, mosaicDefinitionStructureLength);
    MosaicDefinitionTransactionBuffer.AddDeadline(builder, deadline);
    MosaicDefinitionTransactionBuffer.AddPublicKey(builder, publicKeyOffset);
    MosaicDefinitionTransactionBuffer.AddPublicKeyLen(builder, publicKeyLen);
    MosaicDefinitionTransactionBuffer.AddTimestamp(builder, timestamp);
    MosaicDefinitionTransactionBuffer.AddTransactionType(builder, transactionType);
    MosaicDefinitionTransactionBuffer.AddNetwork(builder, network);
    MosaicDefinitionTransactionBuffer.AddVersion(builder, version);
    return MosaicDefinitionTransactionBuffer.EndMosaicDefinitionTransactionBuffer(builder);
  }

  internal static void StartMosaicDefinitionTransactionBuffer(FlatBufferBuilder builder) { builder.StartObject(24); }
  internal static void AddTransactionType(FlatBufferBuilder builder, int transactionType) { builder.AddInt(0, transactionType, 0); }
  internal static void AddVersion(FlatBufferBuilder builder, short version) { builder.AddShort(1, version, 0); }
  internal static void AddNetwork(FlatBufferBuilder builder, short network) { builder.AddShort(2, network, 0); }
  internal static void AddTimestamp(FlatBufferBuilder builder, int timestamp) { builder.AddInt(3, timestamp, 0); }
  internal static void AddPublicKeyLen(FlatBufferBuilder builder, int publicKeyLen) { builder.AddInt(4, publicKeyLen, 0); }
  internal static void AddPublicKey(FlatBufferBuilder builder, VectorOffset publicKeyOffset) { builder.AddOffset(5, publicKeyOffset.Value, 0); }
  internal static VectorOffset CreatePublicKeyVector(FlatBufferBuilder builder, byte[] data) { builder.StartVector(1, data.Length, 1); for (int i = data.Length - 1; i >= 0; i--) builder.AddByte(data[i]); return builder.EndVector(); }
  internal static void StartPublicKeyVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(1, numElems, 1); }
  internal static void AddFee(FlatBufferBuilder builder, ulong fee) { builder.AddUlong(6, fee, 0); }
  internal static void AddDeadline(FlatBufferBuilder builder, int deadline) { builder.AddInt(7, deadline, 0); }
  internal static void AddMosaicDefinitionStructureLength(FlatBufferBuilder builder, int mosaicDefinitionStructureLength) { builder.AddInt(8, mosaicDefinitionStructureLength, 0); }
  internal static void AddLengthCreatorPublicKey(FlatBufferBuilder builder, int lengthCreatorPublicKey) { builder.AddInt(9, lengthCreatorPublicKey, 0); }
  internal static void AddCreatorPublicKey(FlatBufferBuilder builder, VectorOffset creatorPublicKeyOffset) { builder.AddOffset(10, creatorPublicKeyOffset.Value, 0); }
  internal static VectorOffset CreateCreatorPublicKeyVector(FlatBufferBuilder builder, byte[] data) { builder.StartVector(1, data.Length, 1); for (int i = data.Length - 1; i >= 0; i--) builder.AddByte(data[i]); return builder.EndVector(); }
  internal static void StartCreatorPublicKeyVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(1, numElems, 1); }
  internal static void AddLengthOfMosaicIdStructure(FlatBufferBuilder builder, int lengthOfMosaicIdStructure) { builder.AddInt(11, lengthOfMosaicIdStructure, 0); }
  internal static void AddLengthOfNamespaceIdString(FlatBufferBuilder builder, int lengthOfNamespaceIdString) { builder.AddInt(12, lengthOfNamespaceIdString, 0); }
  internal static void AddNamespaceIdString(FlatBufferBuilder builder, VectorOffset namespaceIdStringOffset) { builder.AddOffset(13, namespaceIdStringOffset.Value, 0); }
  internal static VectorOffset CreateNamespaceIdStringVector(FlatBufferBuilder builder, byte[] data) { builder.StartVector(1, data.Length, 1); for (int i = data.Length - 1; i >= 0; i--) builder.AddByte(data[i]); return builder.EndVector(); }
  internal static void StartNamespaceIdStringVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(1, numElems, 1); }
  internal static void AddLengthOfMosaicNameString(FlatBufferBuilder builder, int lengthOfMosaicNameString) { builder.AddInt(14, lengthOfMosaicNameString, 0); }
  internal static void AddMosaicNameString(FlatBufferBuilder builder, VectorOffset mosaicNameStringOffset) { builder.AddOffset(15, mosaicNameStringOffset.Value, 0); }
  internal static VectorOffset CreateMosaicNameStringVector(FlatBufferBuilder builder, byte[] data) { builder.StartVector(1, data.Length, 1); for (int i = data.Length - 1; i >= 0; i--) builder.AddByte(data[i]); return builder.EndVector(); }
  internal static void StartMosaicNameStringVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(1, numElems, 1); }
  internal static void AddLengthOfDescription(FlatBufferBuilder builder, int lengthOfDescription) { builder.AddInt(16, lengthOfDescription, 0); }
  internal static void AddDescriptionString(FlatBufferBuilder builder, VectorOffset descriptionStringOffset) { builder.AddOffset(17, descriptionStringOffset.Value, 0); }
  internal static VectorOffset CreateDescriptionStringVector(FlatBufferBuilder builder, byte[] data) { builder.StartVector(1, data.Length, 1); for (int i = data.Length - 1; i >= 0; i--) builder.AddByte(data[i]); return builder.EndVector(); }
  internal static void StartDescriptionStringVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(1, numElems, 1); }
  internal static void AddNoOfProperties(FlatBufferBuilder builder, int noOfProperties) { builder.AddInt(18, noOfProperties, 0); }
  internal static void AddProperties(FlatBufferBuilder builder, VectorOffset propertiesOffset) { builder.AddOffset(19, propertiesOffset.Value, 0); }
  internal static VectorOffset CreatePropertiesVector(FlatBufferBuilder builder, Offset<MosaicPropertyBuffer>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  internal static void StartPropertiesVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  internal static void AddMosaicLevy(FlatBufferBuilder builder, VectorOffset mosaicLevyOffset) { builder.AddOffset(20, mosaicLevyOffset.Value, 0); }
  internal static VectorOffset CreateMosaicLevyVector(FlatBufferBuilder builder, Offset<MosaicLevyBuffer>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  internal static void StartMosaicLevyVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  internal static void AddLenFeeSinkAddress(FlatBufferBuilder builder, int lenFeeSinkAddress) { builder.AddInt(21, lenFeeSinkAddress, 0); }
  internal static void AddFeeSinkAddress(FlatBufferBuilder builder, VectorOffset feeSinkAddressOffset) { builder.AddOffset(22, feeSinkAddressOffset.Value, 0); }
  internal static VectorOffset CreateFeeSinkAddressVector(FlatBufferBuilder builder, byte[] data) { builder.StartVector(1, data.Length, 1); for (int i = data.Length - 1; i >= 0; i--) builder.AddByte(data[i]); return builder.EndVector(); }
  internal static void StartFeeSinkAddressVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(1, numElems, 1); }
  internal static void AddFeeQuantity(FlatBufferBuilder builder, ulong feeQuantity) { builder.AddUlong(23, feeQuantity, 0); }
  internal static Offset<MosaicDefinitionTransactionBuffer> EndMosaicDefinitionTransactionBuffer(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<MosaicDefinitionTransactionBuffer>(o);
  }
  internal static void FinishMosaicDefinitionTransactionBufferBuffer(FlatBufferBuilder builder, Offset<MosaicDefinitionTransactionBuffer> offset) { builder.Finish(offset.Value); }
};


}
