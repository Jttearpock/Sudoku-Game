//-----------------------------------------------------------------------

// <copyright file="ActiveGame.cs" company="CompanyName">

// Company copyright tag.

// </copyright>

//-----------------------------------------------------------------------

namespace SudokuGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The Class that holds all of the Puzzle Arrays
    /// </summary>
    public class ActiveGame
    {
        /// <summary>
        /// The Array that holds the Puzzle Solution
        /// </summary>
        public int[,] ArrPuzzleSolution;

        /// <summary>
        /// The Array that holds the Base Puzzle for restarting
        /// </summary>
        public int[,] ArrPuzzleBase;

        /// <summary>
        /// The Array that holds the Current Puzzle on the game board
        /// </summary>
        public int[,] ArrPuzzleCurrent;
    }
}