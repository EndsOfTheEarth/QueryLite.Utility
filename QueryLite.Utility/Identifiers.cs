/*
 * MIT License
 *
 * Copyright (c) 2026 EndsOfTheEarth
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

    [MessagePackFormatter(formatterType: typeof(BitFormatter))]
    public readonly struct Bit(bool value) {

        public readonly static Bit TRUE = new(true);
        public readonly static Bit FALSE = new(false);

        public bool Value { get; } = value;

        public static Bit ValueOf(bool value) => value ? TRUE : FALSE;

        public override string ToString() => Value ? "1" : "0";
    }
}