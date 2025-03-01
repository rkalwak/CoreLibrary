﻿//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    [TestClass]
    public class Int64Tests
    {
        [TestMethod]
        public void Ctor_Empty()
        {
            var i = new long();
            Assert.Equal(0, i);
        }

        [TestMethod]
        public void Ctor_Value()
        {
            long i = 41;
            Assert.Equal(41, i);
        }

        [TestMethod]
        public void MaxValue()
        {
            Assert.Equal(0x7FFFFFFFFFFFFFFF, long.MaxValue);
        }

        [TestMethod]
        public void MinValue()
        {
            Assert.Equal(unchecked((long)0x8000000000000000), long.MinValue);
        }

        [TestMethod]
        public void Equals()
        {
            Int64TestData[] testData = new Int64TestData[]
            {
                new Int64TestData((long)789, (long)789, true),
                new Int64TestData((long)789, (long)-789, false),
                new Int64TestData((long)789, (long)0, false),
                new Int64TestData((long)0, (long)0, true),
                new Int64TestData((long)-789, (long)-789, true),
                new Int64TestData((long)-789, (long)789, false),
                new Int64TestData((long)789, null, false),
                new Int64TestData((long)789, "789", false),
            };

            foreach (var test in testData)
            {
                if (test.Obj is long)
                {
                    long i2 = (long)test.Obj;
                    Assert.Equal(test.Expected, test.I1.Equals(i2));
                    Assert.Equal(test.Expected, test.I1.GetHashCode().Equals(i2.GetHashCode()));
                }

                Assert.Equal(test.Expected, test.I1.Equals(test.Obj));
            }
        }

        private sealed class Int64TestData
        {
            public object I1 { get; }
            public object Obj { get; }
            public bool Expected { get; }

            public Int64TestData(object i1, object obj, bool expected)
            {
                I1 = i1;
                Obj = obj;
                Expected = expected;
            }
        }
    }
}
