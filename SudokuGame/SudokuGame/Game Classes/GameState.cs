//-----------------------------------------------------------------------
// <copyright file="GameState.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace SudokuGame
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Controls;

    /// <summary>
    /// The Class that holds all of the Puzzle Arrays
    /// </summary>
    public class GameState
    {
        /// <summary>
        /// Holds the Puzzle Solution
        /// </summary>
        private string[,] arrPuzzleSolution;

        /// <summary>
        /// The Array that holds the Base Puzzle for restarting
        /// </summary>
        private string[,] arrPuzzleBase;

        /// <summary>
        /// The Array that holds the Current Puzzle for validation
        /// </summary>
        private string[,] arrPuzzleCurrent;

        /// <summary>
        /// Bool stating if there is an active game or not
        /// </summary>
        private bool onGoingGame = false;

        /// <summary>
        /// String that holds the difficulty level of the current game
        /// </summary>
        private string difficultyLevel;

        /// <summary>
        /// Int that holds the amount of starting numbers
        /// </summary>
        private int startNumbers;

        /// <summary>
        /// Gets or sets the Puzzle Solution array
        /// </summary>
        public string[,] ArrPuzzleSolution
        {
            get { return this.arrPuzzleSolution; }
            set { this.arrPuzzleSolution = value; }
        }

        /// <summary>
        /// Gets or sets the Puzzle Base array
        /// </summary>
        public string[,] ArrPuzzleBase
        {
            get { return this.arrPuzzleBase; }
            set { this.arrPuzzleBase = value; }
        }

        /// <summary>
        /// Gets or sets the Puzzle Current array
        /// </summary>
        public string[,] ArrPuzzleCurrent
        {
            get { return this.arrPuzzleCurrent; }
            set { this.arrPuzzleCurrent = value; }
        }

        /// <summary>
        /// Gets or sets the onGoingGame bool
        /// </summary>
        public bool OnGoingGame
        {
            get { return this.onGoingGame; }
            set { this.onGoingGame = value; }
        }

        /// <summary>
        /// Gets or sets the Difficulty Level
        /// </summary>
        public string DifficultyLevel
        {
            get { return this.difficultyLevel; }
            set { this.difficultyLevel = value; }
        }

        /// <summary>
        /// Gets or sets the StartNumbers amount
        /// </summary>
        public int StartNumbers
        {
            get { return this.startNumbers; }
            set { this.startNumbers = value; }
        }
    }
}