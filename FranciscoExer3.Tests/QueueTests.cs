using FranciscoExer3.DataStructures;
using Xunit;

namespace FranciscoExer3.Tests
{
    public class QueueTests
    {
        private Queue<int> TestQueue;

        public QueueTests()
        {
            TestQueue = new Queue<int>();
        }

        [Fact]
        public void InstantiateQueue_Success()
        {
            Assert.NotNull(TestQueue);
        }

        [Fact]
        public void Enqueue_Success()
        {
            TestQueue.Enqueue(1);
            TestQueue.Enqueue(2);
            TestQueue.Enqueue(3);

            Assert.Equal(3, TestQueue.Count);
        }

        [Fact]
        public void Dequeue_Success()
        {
            TestQueue.Enqueue(1);
            TestQueue.Enqueue(2);
            TestQueue.Enqueue(3);

            int[] expectedDequeues = { 1, 2, 3 };
            
            foreach(int i in expectedDequeues)
            {
                Assert.Equal(i, TestQueue.Dequeue());
            }
        }
    }
}
