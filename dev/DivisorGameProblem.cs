/**
 * Alice and Bob take turns playing a game, with Alice starting first.

Initially, there is a number N on the chalkboard.  On each player's turn, that player makes a move consisting of:

Choosing any x with 0 < x < N and N % x == 0.
Replacing the number N on the chalkboard with N - x.
Also, if a player cannot make a move, they lose the game.

Return True if and only if Alice wins the game, assuming both players play optimally.

// https://leetcode.com/problems/divisor-game/
// Status = AC
 * /
namespace dev
{
    using System.Collections.Generic;
    using System;
    using System.Linq;

    public class DivisorGameProblem
    {
        private Dictionary<int, bool> soln = new Dictionary<int, bool>();

        public bool DivisorGame(int N)
        {
            soln[0] = false;
            soln[1] = false;
            soln[2] = true;

            bool turn = true; // alice

            var result = DivisorGameHelper(N, turn);
            return result;
        }

        private bool DivisorGameHelper(int n, bool turn)
        {
            if(soln.ContainsKey(n))
            {
                return turn && soln[n];
            }

            for (var x = 1; x < n; x++)
            {
                if(n % x == 0)
                {
                    soln[n] = DivisorGameHelper(n - x, !turn);
                    return soln[n];
                }
            }

            return soln[n] = !turn;
        }
    }
}