using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;


public class RobotOnMoon
{
    public string isSafeCommand(string[] board, string S)
    {
        int x=0, y=0;
        bool foundPos = false;
        foreach (var line in board)
        {
            foreach (var field in line)
            {
                if (field == 'S')
                {
                    foundPos = true;
                    break;
                }
                x++;
            }

            if (foundPos) break;
            x=0;
            y++;
        }

        StringBuilder sb;
        foreach (var move in S)
        {
            if (move == 'U')
            {
                if (y - 1 < 0) return "Dead";
                if (board[y - 1][x] == '.')
                {
                    sb = new StringBuilder(board[y]);
                    sb[x] = '.';
                    board[y] = sb.ToString();
                    y--;
                    sb = new StringBuilder(board[y]);
                    sb[x] = 'S';
                    board[y] = sb.ToString();
                }
            }

            if (move == 'D')
            {
                if (y + 1 >= board.Length) return "Dead";
                if (board[y + 1][x] == '.')
                {
                    sb = new StringBuilder(board[y]);
                    sb[x] = '.';
                    board[y] = sb.ToString();
                    y++;
                    sb = new StringBuilder(board[y]);
                    sb[x] = 'S';
                    board[y] = sb.ToString();
                }
            }
            if (move == 'L')
            {
                if (x - 1 < 0) return "Dead";
                if (board[y][x - 1] == '.')
                {
                    sb = new StringBuilder(board[y]);
                    sb[x] = '.';
                    board[y] = sb.ToString();
                    x--;
                    sb = new StringBuilder(board[y]);
                    sb[x] = 'S';
                    board[y] = sb.ToString();
                }
            }
            if (move == 'R')
            {
                if (x + 1 >= board[0].Length) return "Dead";
                if (board[y][x + 1] == '.')
                {
                    sb = new StringBuilder(board[y]);
                    sb[x] = '.';
                    board[y] = sb.ToString();
                    x++;
                    sb = new StringBuilder(board[y]);
                    sb[x] = 'S';
                    board[y] = sb.ToString();
                }
            }
        }
        return "Alive";
    }

    #region Testing code

    [STAThread]
    private static Boolean KawigiEdit_RunTest(int testNum, string[] p0, string p1, Boolean hasAnswer, string p2)
    {
        Console.Write("Test " + testNum + ": [" + "{");
        for (int i = 0; p0.Length > i; ++i)
        {
            if (i > 0)
            {
                Console.Write(",");
            }
            Console.Write("\"" + p0[i] + "\"");
        }
        Console.Write("}" + "," + "\"" + p1 + "\"");
        Console.WriteLine("]");
        RobotOnMoon obj;
        string answer;
        obj = new RobotOnMoon();
        DateTime startTime = DateTime.Now;
        answer = obj.isSafeCommand(p0, p1);
        DateTime endTime = DateTime.Now;
        Boolean res;
        res = true;
        Console.WriteLine("Time: " + (endTime - startTime).TotalSeconds + " seconds");
        if (hasAnswer)
        {
            Console.WriteLine("Desired answer:");
            Console.WriteLine("\t" + "\"" + p2 + "\"");
        }
        Console.WriteLine("Your answer:");
        Console.WriteLine("\t" + "\"" + answer + "\"");
        if (hasAnswer)
        {
            res = answer == p2;
        }
        if (!res)
        {
            Console.WriteLine("DOESN'T MATCH!!!!");
        }
        else if ((endTime - startTime).TotalSeconds >= 2)
        {
            Console.WriteLine("FAIL the timeout");
            res = false;
        }
        else if (hasAnswer)
        {
            Console.WriteLine("Match :-)");
        }
        else
        {
            Console.WriteLine("OK, but is it right?");
        }
        Console.WriteLine("");
        return res;
    }

    public static void Main(string[] args)
    {
        Boolean all_right;
        all_right = true;

        string[] p0;
        string p1;
        string p2;

        // ----- test 0 -----
        p0 = new string[] {".....", ".###.", "..S#.", "...#."};
        p1 = "URURURURUR";
        p2 = "Alive";
        all_right = KawigiEdit_RunTest(0, p0, p1, true, p2) && all_right;
        // ------------------

        // ----- test 1 -----
        p0 = new string[] {".....", ".###.", "..S..", "...#."};
        p1 = "URURURURUR";
        p2 = "Dead";
        all_right = KawigiEdit_RunTest(1, p0, p1, true, p2) && all_right;
        // ------------------

        // ----- test 2 -----
        p0 = new string[] {".....", ".###.", "..S..", "...#."};
        p1 = "URURU";
        p2 = "Alive";
        all_right = KawigiEdit_RunTest(2, p0, p1, true, p2) && all_right;
        // ------------------

        // ----- test 3 -----
        p0 = new string[] {"#####", "#...#", "#.S.#", "#...#", "#####"};
        p1 = "DRULURLDRULRUDLRULDLRULDRLURLUUUURRRRDDLLDD";
        p2 = "Alive";
        all_right = KawigiEdit_RunTest(3, p0, p1, true, p2) && all_right;
        // ------------------

        // ----- test 4 -----
        p0 = new string[] {"#####", "#...#", "#.S.#", "#...#", "#.###"};
        p1 = "DRULURLDRULRUDLRULDLRULDRLURLUUUURRRRDDLLDD";
        p2 = "Dead";
        all_right = KawigiEdit_RunTest(4, p0, p1, true, p2) && all_right;
        // ------------------

        // ----- test 5 -----
        p0 = new string[] {"S"};
        p1 = "R";
        p2 = "Dead";
        all_right = KawigiEdit_RunTest(5, p0, p1, true, p2) && all_right;
        // ------------------

        if (all_right)
        {
            Console.WriteLine("You're a stud (at least on the example cases)!");
        }
        else
        {
            Console.WriteLine("Some of the test cases had errors.");
        }
    }

    #endregion
}