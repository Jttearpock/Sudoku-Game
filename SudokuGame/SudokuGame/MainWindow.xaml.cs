//-----------------------------------------------------------------------

// <copyright file="MainWindow.xaml.cs" company="CompanyName">

// Company copyright tag.

// </copyright>

//-----------------------------------------------------------------------

namespace SudokuGame
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Instantiate the ActiveGameState GameState class
        /// </summary>
        public GameState ActiveGameState = new GameState();

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Click event that starts a new puzzle with confirmation check
        /// Doesn't seek confirmation if no game has been started
        /// </summary>
        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            if (ActiveGameState.OnGoingGame == true)
            {
                if (MessageBox.Show("Start new game?", "Confirm", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    CreatePuzzle();
                }
            }
            else
            {
                CreatePuzzle();
            }
        }

        /// <summary>
        /// Method for Creating the Puzzle and filling the arrays with game data
        /// </summary>
        public void CreatePuzzle()
        {
            ActiveGameState.OnGoingGame = true;
            ActiveGameState.ArrPuzzleSolution = new string[9, 9];
            ActiveGameState.ArrPuzzleBase = new string[9, 9];
            ActiveGameState.ArrPuzzleCurrent = new string[9, 9];
            StreamReader puzzleReader = File.OpenText(@"..\..\SudokuPuzzleSolutions.txt");

            // Summary
            // Count lines that aren't empty &
            // Calculate how many puzzles there
            // Summary
            int totalLines = File.ReadLines(@"..\..\SudokuPuzzleSolutions.txt").Count(line => !string.IsNullOrWhiteSpace(line));
            int numOfPuzzles = totalLines / 9;

            // Summary
            // Randomly choose a puzzle based on how many there are in the text file
            // Summary
            Random selectPuzzle = new Random();
            // int puzzleNumber = selectPuzzle.Next(1, numOfPuzzles);
            // Code for testing specific Puzzle selection
            int puzzleNumber = 3;

            // Summary
            // Declare the variables for importing the puzzle
            // Summary
            int x;
            int y;
            int lineCounter = 1;

            // Summary
            // Read the file until the line 
            // Where the selected puzzle begins
            // Puzzle = 10 lines (9 lines + blank line separating puzzles)
            // Puzzle 1 = begins on line 1; Puzzle 2 = line 11; Puzzle 3 = line 21, etc.
            // Summary
            if (puzzleNumber != 1)
            {
                while (lineCounter < ((puzzleNumber - 1) * 10) + 1)
                {
                    puzzleReader.ReadLine();
                    lineCounter++;
                }
            }

            // Summary
            // Randomly choose how to rotate the chosen puzzle
            // Summary
            Random puzzleRotation = new Random();
            int rotateValue = puzzleRotation.Next(1, 8);
            // Code for testing specific Rotation
            //int rotateValue = 1;


            if (rotateValue == 1)
            {
                x = 0;
                y = 0;
                while (x < 9)
                {
                    string currentLine = puzzleReader.ReadLine();
                    y = 0;
                    foreach (char c in currentLine)
                    {
                        if (char.IsNumber(c))
                        {
                            // Place the number into the first value of the array
                            ActiveGameState.ArrPuzzleSolution[x, y] = c.ToString();
                            // After char is read, increment the y variable
                            y++;
                        }
                    }              
                    // After Line is read, increment the x variable
                    x++;
                }
            }
            else if (rotateValue == 2)
            {
                x = 0;
                y = 8;
                while (x < 9)
                {
                    string currentLine = puzzleReader.ReadLine();
                    y = 8;
                    foreach (char c in currentLine)
                    {
                        if (char.IsNumber(c))
                        {
                            // Place the number into the first value of the array
                            ActiveGameState.ArrPuzzleSolution[x, y] = c.ToString();
                            // After char is read, increment the y variable
                            y--;
                        }
                    }
                    // After Line is read, increment the x variable
                    x++;
                }
            }
            else if (rotateValue == 3)
            {
                x = 8;
                y = 0;
                while (x > 0)
                {
                    string currentLine = puzzleReader.ReadLine();
                    y = 0;
                    foreach (char c in currentLine)
                    {
                        if (char.IsNumber(c))
                        {
                            // Place the number into the first value of the array
                            ActiveGameState.ArrPuzzleSolution[x, y] = c.ToString();
                            // After char is read, increment the y variable
                            y++;
                        }
                    }
                    // After Line is read, increment the x variable
                    x--;
                }
            }
            else if (rotateValue == 4)
            {
                x = 8;
                y = 8;
                while (x > 0)
                {
                    string currentLine = puzzleReader.ReadLine();
                    y = 8;
                    foreach (char c in currentLine)
                    {
                        if (char.IsNumber(c))
                        {
                            // Place the number into the first value of the array
                            ActiveGameState.ArrPuzzleSolution[x, y] = c.ToString();
                            // After char is read, increment the y variable
                            y--;
                        }
                    }
                    // After Line is read, increment the x variable
                    x--;
                }
            }
            else if (rotateValue == 5)
            {
                x = 0;
                y = 0;
                while (y < 9)
                {
                    string currentLine = puzzleReader.ReadLine();
                    x = 0;
                    foreach (char c in currentLine)
                    {
                        if (char.IsNumber(c))
                        {
                            // Place the number into the first value of the array
                            ActiveGameState.ArrPuzzleSolution[x, y] = c.ToString();
                            // After char is read, increment the y variable
                            x++;
                        }
                    }
                    // After Line is read, increment the x variable
                    y++;
                }
            }
            else if (rotateValue == 6)
            {
                x = 0;
                y = 8;
                while (y > 0)
                {
                    string currentLine = puzzleReader.ReadLine();
                    x = 0;
                    foreach (char c in currentLine)
                    {
                        if (char.IsNumber(c))
                        {
                            // Place the number into the first value of the array
                            ActiveGameState.ArrPuzzleSolution[x, y] = c.ToString();
                            // After char is read, increment the y variable
                            x++;
                        }
                    }
                    // After Line is read, increment the x variable
                    y--;
                }
            }
            else if (rotateValue == 7)
            {
                x = 8;
                y = 0;
                while (y < 9)
                {
                    string currentLine = puzzleReader.ReadLine();
                    x = 8;
                    foreach (char c in currentLine)
                    {
                        if (char.IsNumber(c))
                        {
                            // Place the number into the first value of the array
                            ActiveGameState.ArrPuzzleSolution[x, y] = c.ToString();
                            // After char is read, increment the y variable
                            x--;
                        }
                    }
                    // After Line is read, increment the x variable
                    y++;
                }
            }
            else if (rotateValue == 8)
            {
                x = 8;
                y = 8;
                while (y > 0)
                {
                    string currentLine = puzzleReader.ReadLine();
                    x = 8;
                    foreach (char c in currentLine)
                    {
                        if (char.IsNumber(c))
                        {
                            // Place the number into the first value of the array
                            ActiveGameState.ArrPuzzleSolution[x, y] = c.ToString();
                            // After char is read, increment the y variable
                            x--;
                        }
                    }
                    // After Line is read, increment the x variable
                    y--;
                }
            }
        }


        /// <summary>
        /// Method for resetting the current puzzle to it's beginning state
        /// </summary>
        public void RestartPuzzle()
        {
            ActiveGameState.ArrPuzzleCurrent = new string[9,9];
            int y;
            for (int x = 0; x < 9; x++)
            {
                y = 0;
                while (y < 9)
                {
                    ActiveGameState.ArrPuzzleCurrent[x, y] = ActiveGameState.ArrPuzzleBase[x, y];
                    y++;
                }
            }
        }
        /// <summary>
        /// Click event that resets puzzle with confirmation check
        /// </summary>
        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            if (ActiveGameState.OnGoingGame == true)
            {
                if (MessageBox.Show("Restart current puzzle?", "Confirm", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    RestartPuzzle();
                }
            }

        }
        /// <summary>
        /// Click event that exits program with confirmation check
        /// </summary>
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit?", "Confirm", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                Close();
            }
        }
    }
}
