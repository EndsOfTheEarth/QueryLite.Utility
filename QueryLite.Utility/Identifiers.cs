/*
 * MIT License
 *
 * Copyright (c) 2024 EndsOfTheEarth
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 **/
using MessagePack;
using System.Text.Json.Serialization;

namespace QueryLite {

    /// <summary>
    /// IValue<> interface. Used to support custom identifiers.
    /// </summary>
    /// <typeparam name="TYPE"></typeparam>
    public interface IValue<TYPE> {
        TYPE Value { get; }
    }

    /// <summary>
    /// IValue<> interface. Used to support custom identifiers.
    /// </summary>
    public interface IValueOf<TYPE, RETURN> {
        abstract static RETURN ValueOf(TYPE value);
    }

    /// <summary>
    /// Custom type interface.
    /// </summary>
    public interface ICustomType<TYPE, RETURN> : IValue<TYPE>, IValueOf<TYPE, RETURN> {

    }
}

namespace QueryLite.Utility {

    public interface IKeyValue {

        object GetValueAsObject();

        bool IsValid { get; }
    }

    public interface IGuidType {

        Guid Value { get; }
    }
    public interface IStringType {

        string Value { get; }
    }
    public interface IInt16Type {

        short Value { get; }
    }
    public interface IInt32Type {

        int Value { get; }
    }
    public interface IInt64Type {

        long Value { get; }
    }
    public interface IBoolType {

        bool Value { get; }
    }

    [MessagePackFormatter(formatterType: typeof(GuidKeyFormatter<>))]
    public readonly struct GuidKey<TYPE> : IKeyValue, IGuidType, IEquatable<GuidKey<TYPE>> {

        [JsonPropertyName("Value")]
        [JsonInclude]
        public Guid Value { get; init; }

        object IKeyValue.GetValueAsObject() => Value;

        public GuidKey() { }
        public GuidKey(Guid value) {
            Value = value;
        }

        public static GuidKey<TYPE> ValueOf(Guid value) => new(value);

        public static Guid? ToGuid(GuidKey<TYPE>? key) => key?.Value;

        public static GuidKey<TYPE> Parse(string text) => new(Guid.Parse(text));

        [JsonIgnore]
        public Type DataType => typeof(TYPE);

        public static GuidKey<TYPE> NotSet { get; } = new(Guid.Empty);

        [JsonIgnore]
        public bool IsValid => Value != Guid.Empty;

        public static bool operator ==(GuidKey<TYPE>? pA, GuidKey<TYPE>? pB) {

            if(pA is null && pB is null) {
                return true;
            }
            if(pA is not null) {
                return pA.Equals(pB);
            }
            return false;
        }
        public static bool operator !=(GuidKey<TYPE>? pA, GuidKey<TYPE>? pB) {

            if(pA is null && pB is null) {
                return false;
            }
            if(pA is not null) {
                return !pA.Equals(pB);
            }
            return true;
        }

        public override bool Equals(object? obj) {

            if(obj is GuidKey<TYPE> identifier) {
                return Value.CompareTo(identifier.Value) == 0;
            }
            return false;
        }
        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => Value.ToString() ?? "";

        public bool Equals(GuidKey<TYPE> other) => Value == other.Value;
    }

    [MessagePackFormatter(formatterType: typeof(StringKeyFormatter<>))]
    public readonly struct StringKey<TYPE>(string value) : IKeyValue, IStringType, IEquatable<StringKey<TYPE>> {

        [JsonPropertyName("Value")]
        [JsonInclude]
        public string Value { get; init; } = value;

        object IKeyValue.GetValueAsObject() => Value;

        public static StringKey<TYPE> ValueOf(string value) => new(value);

        [JsonIgnore]
        public Type DataType => typeof(TYPE);

        public static StringKey<TYPE> NotSet { get; } = new("");

        [JsonIgnore]
        public bool IsValid => !string.IsNullOrEmpty(Value);

        public static bool operator ==(StringKey<TYPE>? pA, StringKey<TYPE>? pB) {

            if(pA is null && pB is null) {
                return true;
            }
            if(pA is not null) {
                return pA.Equals(pB);
            }
            return false;
        }
        public static bool operator !=(StringKey<TYPE>? pA, StringKey<TYPE>? pB) {

            if(pA is null && pB is null) {
                return false;
            }
            if(pA is not null) {
                return !pA.Equals(pB);
            }
            return true;
        }

        public override bool Equals(object? obj) {

            if(obj is StringKey<TYPE> identifier) {
                return Value.CompareTo(identifier.Value) == 0;
            }
            return false;
        }
        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => Value ?? "";

        public bool Equals(StringKey<TYPE> other) => Value.CompareTo(other.Value) == 0;
    }

    [MessagePackFormatter(formatterType: typeof(ShortKeyFormatter<>))]
    public readonly struct ShortKey<TYPE>(short value) : IKeyValue, IInt16Type, IEquatable<ShortKey<TYPE>> {

        [JsonPropertyName("Value")]
        [JsonInclude]
        public short Value { get; init; } = value;

        object IKeyValue.GetValueAsObject() => Value;

        public static ShortKey<TYPE> ValueOf(short value) => new(value);

        public static short? ToShort(ShortKey<TYPE>? key) => key?.Value;

        public static ShortKey<TYPE> Parse(string text) => new(short.Parse(text));

        [JsonIgnore]
        public Type DataType => typeof(TYPE);

        public static ShortKey<TYPE> NotSet { get; } = new(0);

        [JsonIgnore]
        public bool IsValid => Value > 0;

        public static bool operator ==(ShortKey<TYPE>? pA, ShortKey<TYPE>? pB) {

            if(pA is null && pB is null) {
                return true;
            }
            if(pA is not null) {
                return pA.Equals(pB);
            }
            return false;
        }
        public static bool operator !=(ShortKey<TYPE>? pA, ShortKey<TYPE>? pB) {

            if(pA is null && pB is null) {
                return false;
            }
            if(pA is not null) {
                return !pA.Equals(pB);
            }
            return true;
        }

        public override bool Equals(object? obj) {

            if(obj is ShortKey<TYPE> identifier) {
                return Value.CompareTo(identifier.Value) == 0;
            }
            return false;
        }
        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => Value.ToString() ?? "";

        public bool Equals(ShortKey<TYPE> other) => Value == other.Value;
    }

    [MessagePackFormatter(formatterType: typeof(IntKeyFormatter<>))]
    public readonly struct IntKey<TYPE>(int value) : IKeyValue, IInt32Type, IEquatable<IntKey<TYPE>> {

        [JsonPropertyName("Value")]
        [JsonInclude]
        public int Value { get; init; } = value;

        object IKeyValue.GetValueAsObject() => Value;

        public static IntKey<TYPE> ValueOf(int value) => new(value);

        public static int? ToInt(IntKey<TYPE>? key) => key?.Value;

        public static IntKey<TYPE> Parse(string text) => new(int.Parse(text));

        [JsonIgnore]
        public Type DataType => typeof(TYPE);

        public static IntKey<TYPE> NotSet { get; } = new(0);

        [JsonIgnore]
        public bool IsValid => Value > 0;

        public static bool operator ==(IntKey<TYPE>? pA, IntKey<TYPE>? pB) {

            if(pA is null && pB is null) {
                return true;
            }
            if(pA is not null) {
                return pA.Equals(pB);
            }
            return false;
        }
        public static bool operator !=(IntKey<TYPE>? pA, IntKey<TYPE>? pB) {

            if(pA is null && pB is null) {
                return false;
            }
            if(pA is not null) {
                return !pA.Equals(pB);
            }
            return true;
        }

        public override bool Equals(object? obj) {

            if(obj is IntKey<TYPE> identifier) {
                return Value.CompareTo(identifier.Value) == 0;
            }
            return false;
        }
        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => Value.ToString() ?? "";

        public bool Equals(IntKey<TYPE> other) => Value == other.Value;
    }

    [MessagePackFormatter(formatterType: typeof(LongKeyFormatter<>))]
    public readonly struct LongKey<TYPE>(long value) : IKeyValue, IInt64Type, IEquatable<LongKey<TYPE>> {

        [JsonPropertyName("Value")]
        [JsonInclude]
        public long Value { get; init; } = value;

        object IKeyValue.GetValueAsObject() => Value;

        public static LongKey<TYPE> ValueOf(long value) => new(value);
        
        public static long? ToLong(LongKey<TYPE>? key) => key?.Value;

        public static LongKey<TYPE> Parse(string text) => new(long.Parse(text));

        [JsonIgnore]
        public Type DataType => typeof(TYPE);

        public static LongKey<TYPE> NotSet { get; } = new(0);

        [JsonIgnore]
        public bool IsValid => Value > 0;

        public static bool operator ==(LongKey<TYPE>? pA, LongKey<TYPE>? pB) {

            if(pA is null && pB is null) {
                return true;
            }
            if(pA is not null) {
                return pA.Equals(pB);
            }
            return false;
        }
        public static bool operator !=(LongKey<TYPE>? pA, LongKey<TYPE>? pB) {

            if(pA is null && pB is null) {
                return false;
            }
            if(pA is not null) {
                return !pA.Equals(pB);
            }
            return true;
        }

        public override bool Equals(object? obj) {

            if(obj is LongKey<TYPE> identifier) {
                return Value.CompareTo(identifier.Value) == 0;
            }
            return false;
        }
        public override int GetHashCode() => Value.GetHashCode();
        
        public override string ToString() => Value.ToString() ?? "";

        public bool Equals(LongKey<TYPE> other) => Value == other.Value;
    }

    [MessagePackFormatter(formatterType: typeof(BoolValueFormatter<>))]
    public readonly struct BoolValue<TYPE>(bool value) : IKeyValue, IBoolType, IEquatable<BoolValue<TYPE>> {

        [JsonPropertyName("Value")]
        [JsonInclude]
        public bool Value { get; init; } = value;

        object IKeyValue.GetValueAsObject() => Value;

        public static BoolValue<TYPE> ValueOf(bool value) => new(value);

        public static bool? ToBool(BoolValue<TYPE>? key) => key?.Value;

        [JsonIgnore]
        public bool IsValid => true;

        [JsonIgnore]
        public Type DataType => typeof(TYPE);

        public static bool operator ==(BoolValue<TYPE>? pA, BoolValue<TYPE>? pB) {

            if(pA is null && pB is null) {
                return true;
            }
            if(pA is not null) {
                return pA.Equals(pB);
            }
            return false;
        }
        public static bool operator !=(BoolValue<TYPE>? pA, BoolValue<TYPE>? pB) {

            if(pA is null && pB is null) {
                return false;
            }
            if(pA is not null) {
                return !pA.Equals(pB);
            }
            return true;
        }

        public override bool Equals(object? obj) {

            if(obj is BoolValue<TYPE> value) {
                return Value.CompareTo(value.Value) == 0;
            }
            return false;
        }
        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => Value.ToString() ?? "";

        public bool Equals(BoolValue<TYPE> other) => Value == other.Value;
    }

    [MessagePackFormatter(formatterType: typeof(BitFormatter))]
    public readonly struct Bit(bool value) {

        public readonly static Bit TRUE = new(true);
        public readonly static Bit FALSE = new(false);

        public bool Value { get; } = value;

        public static Bit ValueOf(bool value) => value ? TRUE : FALSE;

        public override string ToString() => Value ? "1" : "0";
    }
}