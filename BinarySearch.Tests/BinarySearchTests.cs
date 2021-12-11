using NUnit.Framework;
using System.Collections.Generic;
using BinarySearchGeneric;
using System;

namespace BinarySearch.Tests
{
    public class ArrayExtensionTests
    {
        [TestFixture]
        [Category("IntTests")]
        public class IntTests
        {
            [TestCase(new[] { 6 }, 6, ExpectedResult = 0)]
            [TestCase(new[] { 1, 3, 4, 6, 8, 9, 11 }, 6, ExpectedResult = 3)]
            [TestCase(new[] { 1, 3, 4, 6, 8, 9, 11 }, 1, ExpectedResult = 0)]
            [TestCase(new[] { 1, 3, 4, 6, 8, 9, 11 }, 11, ExpectedResult = 6)]
            [TestCase(new[] { 1, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 634 }, 144, ExpectedResult = 9)]
            [TestCase(new[] { 1, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377 }, 21, ExpectedResult = 5)]
            public int BinarySearch_ReturnIndexOfValueInArray(int[] source, int value)
            {
                return ArrayExtension.BinarySearch<int>(source, value, Comparer<int>.Default);
            }

            [TestCase(new[] { 6 }, 7, ExpectedResult = -1)]
            [TestCase(new[] { 1, 3, 4, 6, 8, 9, 11 }, 0, ExpectedResult = -1)]
            [TestCase(new[] { 1, 3, 4, 6, 8, 9, 11 }, 14, ExpectedResult = -1)]
            [TestCase(new[] { 1, 3, 4, 6, 8, 9, 11 }, 11, ExpectedResult = 6)]
            [TestCase(new int[] { }, 144, ExpectedResult = -1)]
            [TestCase(new[] { 1, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377 }, 21, ExpectedResult = 5)]
            public int? BinarySearch_ReturnNull(int[] source, int value)
            {
                return ArrayExtension.BinarySearch<int>(source, value, Comparer<int>.Default);
            }

            [Test]
            public void BinarySearch_SourceArrayIsNull_ThrowArgumentNullException()
                => Assert.Throws<ArgumentNullException>(() => ArrayExtension.BinarySearch<int>(null, 1, Comparer<int>.Default), "Source array cannot be null.");
        }

        [TestFixture]
        [Category("StringTests")]
        public class StringTests
        {
            [TestCase(new[] { "A", "B" }, "A", ExpectedResult = 0)]
            [TestCase(new[] { "a", "B", "A" }, "A", ExpectedResult = 2)]
            [TestCase(new[] { "a", "BACDF", "A" }, "BACDF", ExpectedResult = 1)]
            public int BinarySearch_ReturnIndexOfValueInArray(string[] source, string value)
            {
                return ArrayExtension.BinarySearch<string>(source, value, Comparer<string>.Default);
            }

            [TestCase(new[] { "A" }, "ASDF", ExpectedResult = -1)]
            [TestCase(new[] { "A", "B", "C" }, "d", ExpectedResult = -1)]
            public int? BinarySearch_ReturnNull(string[] source, string value)
            {
                return ArrayExtension.BinarySearch<string>(source, value, Comparer<string>.Default);
            }

            [Test]
            public void BinarySearch_SourceArrayIsNull_ThrowArgumentNullException()
                => Assert.Throws<ArgumentNullException>(() => ArrayExtension.BinarySearch<string>(null, "ABC", Comparer<string>.Default), "Source array cannot be null.");
        }
    }
}