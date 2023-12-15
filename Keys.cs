/*
 * MIT License
 *
 * Copyright (c) 2023 EndsOfTheEarth
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
using System.Diagnostics.CodeAnalysis;

namespace QueryLite.Utility {

    /// <summary>
    /// Composite dictionary key
    /// </summary>
    internal readonly struct Key<K1, K2> : IEquatable<Key<K1, K2>> where K1 : notnull, IEquatable<K1> where K2 : notnull, IEquatable<K2> {

        public Key(K1 key1, K2 key2) {
            Key1 = key1;
            Key2 = key2;
        }
        public K1 Key1 { get; }
        public K2 Key2 { get; }

        public override bool Equals([NotNullWhen(true)] object? obj) {

            if(obj is Key<K1, K2> other) {
                return Key1.Equals(other.Key1) && Key2.Equals(other.Key2);
            }
            return false;
        }
        public bool Equals(Key<K1, K2> other) {
            return Key1.Equals(other.Key1) && Key2.Equals(other.Key2);
        }
        public override int GetHashCode() {
            return HashCode.Combine(Key1, Key2);
        }
    }

    /// <summary>
    /// Composite dictionary key
    /// </summary>
    internal readonly struct Key<K1, K2, K3> : IEquatable<Key<K1, K2, K3>> where K1 : notnull, IEquatable<K1> where K2 : notnull, IEquatable<K2> where K3 : notnull, IEquatable<K3> {

        public Key(K1 key1, K2 key2, K3 key3) {
            Key1 = key1;
            Key2 = key2;
            Key3 = key3;
        }
        public K1 Key1 { get; }
        public K2 Key2 { get; }
        public K3 Key3 { get; }

        public override bool Equals([NotNullWhen(true)] object? obj) {

            if(obj is Key<K1, K2, K3> other) {
                return Key1.Equals(other.Key1) && Key2.Equals(other.Key2) && Key3.Equals(other.Key3);
            }
            return false;
        }
        public bool Equals(Key<K1, K2, K3> other) {
            return Key1.Equals(other.Key1) && Key2.Equals(other.Key2) && Key3.Equals(other.Key3);
        }
        public override int GetHashCode() {
            return HashCode.Combine(Key1, Key2, Key3);
        }
    }

    /// <summary>
    /// Composite dictionary key
    /// </summary>
    internal readonly struct Key<K1, K2, K3, K4> : IEquatable<Key<K1, K2, K3, K4>> where K1 : notnull, IEquatable<K1> where K2 : notnull, IEquatable<K2> where K3 : notnull, IEquatable<K3> where K4 : notnull, IEquatable<K4> {

        public Key(K1 key1, K2 key2, K3 key3, K4 key4) {
            Key1 = key1;
            Key2 = key2;
            Key3 = key3;
            Key4 = key4;
        }
        public K1 Key1 { get; }
        public K2 Key2 { get; }
        public K3 Key3 { get; }
        public K4 Key4 { get; }

        public override bool Equals([NotNullWhen(true)] object? obj) {

            if(obj is Key<K1, K2, K3, K4> other) {
                return Key1.Equals(other.Key1) && Key2.Equals(other.Key2) && Key3.Equals(other.Key3) && Key4.Equals(other.Key4);
            }
            return false;
        }
        public bool Equals(Key<K1, K2, K3, K4> other) {
            return Key1.Equals(other.Key1) && Key2.Equals(other.Key2) && Key3.Equals(other.Key3) && Key4.Equals(other.Key4);
        }
        public override int GetHashCode() {
            return HashCode.Combine(Key1, Key2, Key3, Key4);
        }
    }

    /// <summary>
    /// Composite dictionary key
    /// </summary>
    internal readonly struct Key<K1, K2, K3, K4, K5> : IEquatable<Key<K1, K2, K3, K4, K5>> where K1 : notnull, IEquatable<K1> where K2 : notnull, IEquatable<K2> where K3 : notnull, IEquatable<K3> where K4 : notnull, IEquatable<K4> where K5 : notnull, IEquatable<K5> {

        public Key(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5) {
            Key1 = key1;
            Key2 = key2;
            Key3 = key3;
            Key4 = key4;
            Key5 = key5;
        }
        public K1 Key1 { get; }
        public K2 Key2 { get; }
        public K3 Key3 { get; }
        public K4 Key4 { get; }
        public K5 Key5 { get; }

        public override bool Equals([NotNullWhen(true)] object? obj) {

            if(obj is Key<K1, K2, K3, K4, K5> other) {
                return Key1.Equals(other.Key1) && Key2.Equals(other.Key2) && Key3.Equals(other.Key3) && Key4.Equals(other.Key4) && Key5.Equals(other.Key5);
            }
            return false;
        }
        public bool Equals(Key<K1, K2, K3, K4, K5> other) {
            return Key1.Equals(other.Key1) && Key2.Equals(other.Key2) && Key3.Equals(other.Key3) && Key4.Equals(other.Key4) && Key5.Equals(other.Key5);
        }
        public override int GetHashCode() {
            return HashCode.Combine(Key1, Key2, Key3, Key4, Key5);
        }
    }
}