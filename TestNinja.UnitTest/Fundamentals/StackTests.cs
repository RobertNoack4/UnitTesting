using System;
using NUnit.Framework;

namespace TestNinja.UnitTest
{
    [TestFixture]
    class StackTests
    {
        private Fundamentals.Stack<string> stack;
        
        [SetUp]
        public void SetUp()
        {
            stack = new Fundamentals.Stack<string>();
        }

        [Test]
        public void Push_NullObjectIsPushed_ThrowsArgumentNullException()
        {
            Assert.That(() => stack.Push(null), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void Push_NormalStringIsPush_StringIsAddedToList()
        {
            var counter = stack.Count;
            
            stack.Push("Test");

            Assert.That(stack.Count, Is.EqualTo(counter + 1));
        }

        [Test]
        public void Pop_PopedWhenListIsEmpty_ThrowsInvalidOperationException()
        {
            Assert.That(() => stack.Pop(), Throws.Exception.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void Pop_PopedWhenObjectsAreInList_RemoveOneObject()
        {
            stack.Push("Test");
            var counter = stack.Count;

            stack.Pop();

            Assert.That(stack.Count, Is.EqualTo(counter - 1));
        }

        [Test]
        public void Peek_PeekedWhenListIsEmpty_ThrowInvalidOperationException()
        {
            Assert.That(() => stack.Peek(), Throws.Exception.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void Peek_PeekWhenObjectsAreInList_ReturnNextExemplarOnList()
        {
            stack.Push("Test");
            stack.Push("Test2");
            var result = stack.Peek();


            Assert.That(result, Is.EqualTo("Test2"));
        }



    }
}
