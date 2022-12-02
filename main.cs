using System;
using System.Collections.Generic;

class Program {
  public static int calculateScore(string opponent, string player) {
    int score = 0;
    Console.WriteLine("{0} vs {1}", opponent, player);
    IDictionary<string, int> scores = new Dictionary<string, int>();
    scores.Add("R", 1);
    scores.Add("P", 2);
    scores.Add("S", 3);
    score += scores[player];
    Console.WriteLine(score);

    // win
    if ((player == "R" && opponent == "S") || (player == "P" && opponent == "R") || (player == "S" && opponent == "P"))
      score += 6;
    // draw
    else if ((player == opponent)) {
      score += 3;
    }
    Console.WriteLine(score);
    Console.WriteLine();
    return score;
  }
  public static void Main (string[] args) {
    string[] lines = System.IO.File.ReadAllLines(@"rps.txt");

    IDictionary<string, string> rps = new Dictionary<string, string>();
    rps.Add("A", "R");
    rps.Add("B", "P");
    rps.Add("C", "S");
    rps.Add("X", "R");
    rps.Add("Y", "P");
    rps.Add("Z", "S");
    //int[] top3 = {0,0,0};
    //int runningTotal = 0;

    // Line 1: B X
    // Line 1: P R
    
    int totalScore = 0;
    
    foreach (string gameLine in lines){
      string[] game = gameLine.Split(" ");
      totalScore += calculateScore(rps[game[0]], rps[game[1]]);  
      Console.WriteLine("{0} // {1}", rps[game[0]], rps[game[1]]);
    Console.WriteLine("Final answer: {0}", totalScore);  
      
      
    }
    // Keep the console window open in debug mode.
    System.Console.ReadKey();
  }
  
}