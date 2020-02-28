using System;
using System.Linq;
using NUnit.Framework;
using Wordwrap;

namespace WordwrapTests
{
    public class WrapperTests: With_an_automocked<Wrapper>
    {
        private Wrapper wrapper;

        [SetUp]
        public void SetupWrapper()
        {
            wrapper = ClassUnderTest;
        }

        [Test]
        public void When_wrap_and_empty_string()
        {
            Assert.That(wrapper.Wrap("", 1), Is.EqualTo(""));
        }

        [Test]
        public void When_wrap_and_string_shorter_than_col()
        {
            Assert.That(wrapper.Wrap("this", 10), Is.EqualTo("this"));
        }

        [Test]
        public void When_wrap_split_one_word()
        {
            Assert.That(wrapper.Wrap("word", 2), Is.EqualTo("wo\nrd"));
        }

        [Test]
        public void When_wrap_split_one_word_many_times()
        {
            Assert.That(wrapper.Wrap("abcdefghij", 3), Is.EqualTo("abc\ndef\nghi\nj"));
        }

        [Test]
        public void When_wrap_on_word_boundary()
        {
            Assert.That(wrapper.Wrap("word word", 5), Is.EqualTo("word\nword"));
        }

        [Test]
        public void When_wrap_after_word_boundary()
        {
            Assert.That(wrapper.Wrap("word word", 6), Is.EqualTo("word\nword"));
        }

        [Test]
        public void When_wrap_well_before_word_boundary()
        {
            Assert.That(wrapper.Wrap("word word", 3), Is.EqualTo("wor\nd\nwor\nd"));
        }

        [Test]
        public void When_wrap_just_before_word_boundary()
        {
            Assert.That(wrapper.Wrap("word word", 4), Is.EqualTo("word\nword"));
        }

    }
}
