using MessagePack;
using MessagePack.Formatters;
using System.Buffers;

namespace QueryLite.Utility {

    public class GuidKeyFormatter<TYPE> : IMessagePackFormatter<GuidKey<TYPE>> {

        public void Serialize(ref MessagePackWriter writer, GuidKey<TYPE> value, MessagePackSerializerOptions options) {

            if(value == null) {
                writer.WriteNil();
                return;
            }
            writer.WriteRaw(value.Value.ToByteArray());
        }

        public GuidKey<TYPE> Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options) {

            if(reader.TryReadNil()) {
                return GuidKey<TYPE>.NotSet;
            }

            options.Security.DepthStep(ref reader);

            ReadOnlySequence<byte> bytes = reader.ReadRaw(length: 16);

            reader.Depth--;
            return new GuidKey<TYPE>(new Guid(bytes.ToArray()));
        }
    }

    public class StringKeyFormatter<TYPE> : IMessagePackFormatter<StringKey<TYPE>> {

        public void Serialize(ref MessagePackWriter writer, StringKey<TYPE> value, MessagePackSerializerOptions options) {
            if(value == null) {
                writer.WriteNil();
                return;
            }
            writer.Write(value.Value);
        }

        public StringKey<TYPE> Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options) {

            if(reader.TryReadNil()) {
                return StringKey<TYPE>.NotSet;
            }

            options.Security.DepthStep(ref reader);

            string? text = reader.ReadString() ?? string.Empty;

            reader.Depth--;
            return new StringKey<TYPE>(text);
        }
    }

    public class ShortKeyFormatter<TYPE> : IMessagePackFormatter<ShortKey<TYPE>> {

        public void Serialize(ref MessagePackWriter writer, ShortKey<TYPE> value, MessagePackSerializerOptions options) {
            if(value == null) {
                writer.WriteNil();
                return;
            }
            writer.WriteInt16(value.Value);
        }

        public ShortKey<TYPE> Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options) {

            if(reader.TryReadNil()) {
                return ShortKey<TYPE>.NotSet;
            }

            options.Security.DepthStep(ref reader);

            short value = reader.ReadInt16();

            reader.Depth--;
            return new ShortKey<TYPE>(value);
        }
    }

    public class IntKeyFormatter<TYPE> : IMessagePackFormatter<IntKey<TYPE>> {

        public void Serialize(ref MessagePackWriter writer, IntKey<TYPE> value, MessagePackSerializerOptions options) {

            if(value == null) {
                writer.WriteNil();
                return;
            }
            writer.WriteInt32(value.Value);
        }

        public IntKey<TYPE> Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options) {

            if(reader.TryReadNil()) {
                return IntKey<TYPE>.NotSet;
            }

            options.Security.DepthStep(ref reader);

            int value = reader.ReadInt32();

            reader.Depth--;
            return new IntKey<TYPE>(value);
        }
    }

    public class LongKeyFormatter<TYPE> : IMessagePackFormatter<LongKey<TYPE>> {

        public void Serialize(ref MessagePackWriter writer, LongKey<TYPE> value, MessagePackSerializerOptions options) {

            if(value == null) {
                writer.WriteNil();
                return;
            }
            writer.WriteInt64(value.Value);
        }

        public LongKey<TYPE> Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options) {

            if(reader.TryReadNil()) {
                return LongKey<TYPE>.NotSet;
            }

            options.Security.DepthStep(ref reader);

            long value = reader.ReadInt64();

            reader.Depth--;
            return new LongKey<TYPE>(value);
        }
    }

    public class BoolValueFormatter<TYPE> : IMessagePackFormatter<BoolValue<TYPE>> {

        public void Serialize(ref MessagePackWriter writer, BoolValue<TYPE> value, MessagePackSerializerOptions options) {

            if(value == null) {
                writer.WriteNil();
                return;
            }
            writer.Write(value.Value);
        }

        public BoolValue<TYPE> Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options) {

            if(reader.TryReadNil()) {
                return new BoolValue<TYPE>();
            }

            options.Security.DepthStep(ref reader);
            
            bool value = reader.ReadBoolean();
            reader.Depth--;
            return new BoolValue<TYPE>(value);
        }
    }

    public class BitFormatter : IMessagePackFormatter<Bit> {

        public void Serialize(ref MessagePackWriter writer, Bit value, MessagePackSerializerOptions options) {
            writer.Write(value.Value);
        }

        public Bit Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options) {

            if(reader.TryReadNil()) {
                return new Bit();
            }

            options.Security.DepthStep(ref reader);

            bool value = reader.ReadBoolean();
            reader.Depth--;
            return new Bit(value);
        }
    }
}