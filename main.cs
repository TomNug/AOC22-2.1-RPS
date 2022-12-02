using System;
using System.Collections.Generic;

class Program {

  public static int calculateScore(string opponent, string player) {
    IDictionary<string, string> result = new Dictionary<string, string>();
    result.Add("X", "L");
    result.Add("Y", "D");
    result.Add("Z", "W");
    string playerShape = "";
    if (opponent == "R") {
      if (result[player] == "W") {
        playerShape = "P";
      } else if (result[player] == "D") {
        playerShape = opponent;
      } else {
        playerShape = "S";
      }
    } else if (opponent == "P") {
      if (result[player] == "W") {
        playerShape = "S";
      } else if (result[player] == "D") {
        playerShape = opponent;
      } else {
        playerShape = "R";
      }
    } else {
      if (result[player] == "W") {
        playerShape = "R";
      } else if (result[player] == "D") {
        playerShape = opponent;
      } else {
        playerShape = "P";
      }
    }

    
    int score = 0;
    Console.WriteLine("{0} vs {1}", opponent, playerShape);
    IDictionary<string, int> scores = new Dictionary<string, int>();
    scores.Add("R", 1);
    scores.Add("P", 2);
    scores.Add("S", 3);
    score += scores[playerShape];
    Console.WriteLine(score);

    // win
    if ((playerShape == "R" && opponent == "S") || (playerShape == "P" && opponent == "R") || (playerShape == "S" && opponent == "P"))
      score += 6;
    // draw
    else if ((playerShape == opponent)) {
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
      totalScore += calculateScore(rps[game[0]], game[1]);  
      Console.WriteLine("{0} // {1}", rps[game[0]], game[1]);
    Console.WriteLine("Final answer: {0}", totalScore);  
      
      
    }
    // Keep the console window open in debug mode.
    System.Console.ReadKey();
  }
  
}