using AutoMoqCore;
using NUnit.Framework;

namespace WordwrapTests
{
    public abstract class With_an_automocked<T>
    {
        private AutoMoqer mocker;

        [SetUp]
        public void WithAnAutoMockedSetup()
        {
            mocker = new AutoMoqer();
            ClassUnderTest = mocker.Create<T>();
        }

        public T ClassUnderTest { get; set; }
    }
}
