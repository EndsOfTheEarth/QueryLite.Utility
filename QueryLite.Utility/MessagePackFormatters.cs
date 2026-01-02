using MessagePack;
using MessagePack.Formatters;

namespace QueryLite.Utility {

    /// <summary>
    /// Serialisation formatter for the Bit type.
    /// </summary>
    /// <typeparam name="TYPE"></typeparam>
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