//-----------------------------------------------------------------------

// <copyright file="GameState.cs" company="CompanyName">

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
    public class GameState
    {
        /// <summary>
        /// The Array that holds the Puzzle Solution
        /// </summary>
        private int[,] _arrPuzzleSolution;
        public int[,] ArrPuzzleSolution
        {
            get { return _arrPuzzleSolution; }
            set { _arrPuzzleSolution = value; }
        }

        /// <summary>
        /// The Array that holds the Base Puzzle for restarting
        /// </summary>
        private int[,] _arrPuzzleBase;
        public int[,] ArrPuzzleBase
        {
            get { return _arrPuzzleBase; }
            set { _arrPuzzleBase = value; }
        }
        /// <summary>
        /// The Array that holds the Current Puzzle on the game board
        /// </summary>
        private int[,] _arrPuzzleCurrent;
        public int[,] ArrPuzzleCurrent
        {
            get { return _arrPuzzleCurrent; }
            set { _arrPuzzleCurrent = value; }
        }

        /// <summary>
        /// Bool stating if there is an active game or not
        /// </summary>
        private bool _onGoingGame = false;
        public bool OnGoingGame
        {
            get { return _onGoingGame; }
            set { _onGoingGame = value; }
        }
    }
}