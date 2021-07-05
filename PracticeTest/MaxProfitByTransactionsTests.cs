using InterviewPrep.Array;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InterviewPrepTest
{
    [TestClass]
    public class MaxProfitByTransactionsTests
    {
        [TestMethod]
        public void ProfitByTransaction()
        {
            int[] input = { 5, 11, 3, 50, 60, 90 };
            var maxProfitByTransactions = new MaxProfitByTransactions();
            var result = maxProfitByTransactions.MaxProfitWithKTransactions(input, 4);
            Assert.AreEqual(93, result);
        }        
    }
}
