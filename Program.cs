namespace StoneGameIII
{
    internal class Program
    {
        public class StoneGame
        {
            private int DFS(int[] dp, int[] stoneValue, int index)
            {
                if (index >= stoneValue.Length)
                {
                    return 0;
                }
                if (dp[index] != -1)
                {
                    return dp[index];
                }
                int result = int.MinValue;
                int numCount = 0;
                for (int count = index; count < Math.Min(index + 3, stoneValue.Length); ++count)
                {
                    numCount += stoneValue[count];
                    result = Math.Max(result, numCount - DFS(dp, stoneValue, count + 1));
                }
                dp[index] = result;
                return result;
            }

            public string StoneGameIII(int[] stoneValue)
            {
                int n = stoneValue.Length;
                int[] dp = new int[n + 1];
                Array.Fill(dp, -1);
                int dfsResult = DFS(dp, stoneValue, 0);
                return dfsResult == 0 ? "Tie" : dfsResult > 0 ? "Alice" : "Bob";
            }
        }

        static void Main(string[] args)
        {
            StoneGame stoneGame = new();
            Console.WriteLine(stoneGame.StoneGameIII(new int[] { 1, 2, 3, 7 }));
            Console.WriteLine(stoneGame.StoneGameIII(new int[] { 1, 2, 3, -9 }));
            Console.WriteLine(stoneGame.StoneGameIII(new int[] { 1, 2, 3, 6 }));
        }
    }
}