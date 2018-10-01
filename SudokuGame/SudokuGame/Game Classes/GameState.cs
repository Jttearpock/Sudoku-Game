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
        private string[,] _arrPuzzleSolution;
        public string[,] ArrPuzzleSolution
        {
            get { return _arrPuzzleSolution; }
            set { _arrPuzzleSolution = value; }
        }

        /// <summary>
        /// The Array that holds the Base Puzzle for restarting
        /// </summary>
        private string[,] _arrPuzzleBase;
        public string[,] ArrPuzzleBase
        {
            get { return _arrPuzzleBase; }
            set { _arrPuzzleBase = value; }
        }
        /// <summary>
        /// The Array that holds the Current Puzzle on the game board
        /// </summary>
        private string[,] _arrPuzzleCurrent;
        public string[,] ArrPuzzleCurrent
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

        private string _difficultyLevel;
        public string DifficultyLevel
        {
            get { return _difficultyLevel; }
            set { _difficultyLevel = value;}
        }

        private int _startNumbers;

        public int StartNumbers
        {
            get { return _startNumbers; }
            set { _startNumbers = value; }
        }
    }
}