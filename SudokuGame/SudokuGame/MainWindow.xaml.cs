//-----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Part 2 C#">
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
    using System.Collections;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Instantiate the activeGameState GameState class
        /// </summary>
        private GameState activeGameState = new GameState();

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Total set of methods for puzzle creation
        /// </summary>
        public void CreateNewGame()
        {
            CreatePuzzle();
            SetDifficulty();
            SetPuzzleStart();
            SetGameBoard();
        }

        public void SetGameBoard()
        {
            int y;
            for (int x = 0; x < 9; x++)
            {
                y = 0;
                while (y < 9)
                {
                    if (activeGameState.ArrPuzzleCurrent[x, y] == null)
                    {
                        activeGameState.ArrPuzzleCurrent[x, y] = "";
                    }
                    y++;
                }
            }
            Cell00.Text = activeGameState.ArrPuzzleCurrent[0, 0];
            // Test code
            // if (Cell00.Text != "")
            // {
            //    Cell00.FontWeight = FontWeights.Bold;
            //    Cell00.IsHitTestVisible = false;
            //    Cell00.Focusable = false;              
            // }
            Cell01.Text = activeGameState.ArrPuzzleCurrent[0, 1];
            Cell02.Text = activeGameState.ArrPuzzleCurrent[0, 2];
            Cell03.Text = activeGameState.ArrPuzzleCurrent[0, 3];
            Cell04.Text = activeGameState.ArrPuzzleCurrent[0, 4];
            Cell05.Text = activeGameState.ArrPuzzleCurrent[0, 5];
            Cell06.Text = activeGameState.ArrPuzzleCurrent[0, 6];
            Cell07.Text = activeGameState.ArrPuzzleCurrent[0, 7];
            Cell08.Text = activeGameState.ArrPuzzleCurrent[0, 8];
            Cell10.Text = activeGameState.ArrPuzzleCurrent[1, 0];
            Cell11.Text = activeGameState.ArrPuzzleCurrent[1, 1];
            Cell12.Text = activeGameState.ArrPuzzleCurrent[1, 2];
            Cell13.Text = activeGameState.ArrPuzzleCurrent[1, 3];
            Cell14.Text = activeGameState.ArrPuzzleCurrent[1, 4];
            Cell15.Text = activeGameState.ArrPuzzleCurrent[1, 5];
            Cell16.Text = activeGameState.ArrPuzzleCurrent[1, 6];
            Cell17.Text = activeGameState.ArrPuzzleCurrent[1, 7];
            Cell18.Text = activeGameState.ArrPuzzleCurrent[1, 8];
            Cell20.Text = activeGameState.ArrPuzzleCurrent[2, 0];
            Cell21.Text = activeGameState.ArrPuzzleCurrent[2, 1];
            Cell22.Text = activeGameState.ArrPuzzleCurrent[2, 2];
            Cell23.Text = activeGameState.ArrPuzzleCurrent[2, 3];
            Cell24.Text = activeGameState.ArrPuzzleCurrent[2, 4];
            Cell25.Text = activeGameState.ArrPuzzleCurrent[2, 5];
            Cell26.Text = activeGameState.ArrPuzzleCurrent[2, 6];
            Cell27.Text = activeGameState.ArrPuzzleCurrent[2, 7];
            Cell28.Text = activeGameState.ArrPuzzleCurrent[2, 8];
            Cell30.Text = activeGameState.ArrPuzzleCurrent[3, 0];
            Cell31.Text = activeGameState.ArrPuzzleCurrent[3, 1];
            Cell32.Text = activeGameState.ArrPuzzleCurrent[3, 2];
            Cell33.Text = activeGameState.ArrPuzzleCurrent[3, 3];
            Cell34.Text = activeGameState.ArrPuzzleCurrent[3, 4];
            Cell35.Text = activeGameState.ArrPuzzleCurrent[3, 5];
            Cell36.Text = activeGameState.ArrPuzzleCurrent[3, 6];
            Cell37.Text = activeGameState.ArrPuzzleCurrent[3, 7];
            Cell38.Text = activeGameState.ArrPuzzleCurrent[3, 8];
            Cell40.Text = activeGameState.ArrPuzzleCurrent[4, 0];
            Cell41.Text = activeGameState.ArrPuzzleCurrent[4, 1];
            Cell42.Text = activeGameState.ArrPuzzleCurrent[4, 2];
            Cell43.Text = activeGameState.ArrPuzzleCurrent[4, 3];
            Cell44.Text = activeGameState.ArrPuzzleCurrent[4, 4];
            Cell45.Text = activeGameState.ArrPuzzleCurrent[4, 5];
            Cell46.Text = activeGameState.ArrPuzzleCurrent[4, 6];
            Cell47.Text = activeGameState.ArrPuzzleCurrent[4, 7];
            Cell48.Text = activeGameState.ArrPuzzleCurrent[4, 8];
            Cell50.Text = activeGameState.ArrPuzzleCurrent[5, 0];
            Cell51.Text = activeGameState.ArrPuzzleCurrent[5, 1];
            Cell52.Text = activeGameState.ArrPuzzleCurrent[5, 2];
            Cell53.Text = activeGameState.ArrPuzzleCurrent[5, 3];
            Cell54.Text = activeGameState.ArrPuzzleCurrent[5, 4];
            Cell55.Text = activeGameState.ArrPuzzleCurrent[5, 5];
            Cell56.Text = activeGameState.ArrPuzzleCurrent[5, 6];
            Cell57.Text = activeGameState.ArrPuzzleCurrent[5, 7];
            Cell58.Text = activeGameState.ArrPuzzleCurrent[5, 8];
            Cell60.Text = activeGameState.ArrPuzzleCurrent[6, 0];
            Cell61.Text = activeGameState.ArrPuzzleCurrent[6, 1];
            Cell62.Text = activeGameState.ArrPuzzleCurrent[6, 2];
            Cell63.Text = activeGameState.ArrPuzzleCurrent[6, 3];
            Cell64.Text = activeGameState.ArrPuzzleCurrent[6, 4];
            Cell65.Text = activeGameState.ArrPuzzleCurrent[6, 5];
            Cell66.Text = activeGameState.ArrPuzzleCurrent[6, 6];
            Cell67.Text = activeGameState.ArrPuzzleCurrent[6, 7];
            Cell68.Text = activeGameState.ArrPuzzleCurrent[6, 8];
            Cell70.Text = activeGameState.ArrPuzzleCurrent[7, 0];
            Cell71.Text = activeGameState.ArrPuzzleCurrent[7, 1];
            Cell72.Text = activeGameState.ArrPuzzleCurrent[7, 2];
            Cell73.Text = activeGameState.ArrPuzzleCurrent[7, 3];
            Cell74.Text = activeGameState.ArrPuzzleCurrent[7, 4];
            Cell75.Text = activeGameState.ArrPuzzleCurrent[7, 5];
            Cell76.Text = activeGameState.ArrPuzzleCurrent[7, 6];
            Cell77.Text = activeGameState.ArrPuzzleCurrent[7, 7];
            Cell78.Text = activeGameState.ArrPuzzleCurrent[7, 8];
            Cell80.Text = activeGameState.ArrPuzzleCurrent[8, 0];
            Cell81.Text = activeGameState.ArrPuzzleCurrent[8, 1];
            Cell82.Text = activeGameState.ArrPuzzleCurrent[8, 2];
            Cell83.Text = activeGameState.ArrPuzzleCurrent[8, 3];
            Cell84.Text = activeGameState.ArrPuzzleCurrent[8, 4];
            Cell85.Text = activeGameState.ArrPuzzleCurrent[8, 5];
            Cell86.Text = activeGameState.ArrPuzzleCurrent[8, 6];
            Cell87.Text = activeGameState.ArrPuzzleCurrent[8, 7];
            Cell88.Text = activeGameState.ArrPuzzleCurrent[8, 8];




        }

        /// <summary>
        /// Method for Creating the Puzzle and filling the arrays with game data
        /// </summary>
        public void CreatePuzzle()
        {
            activeGameState = new GameState();
            activeGameState.OnGoingGame = true;
            activeGameState.ArrPuzzleSolution = new string[9, 9];
            activeGameState.ArrPuzzleBase = new string[9, 9];
            activeGameState.ArrPuzzleCurrent = new string[9, 9];
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
            int puzzleNumber = selectPuzzle.Next(1, numOfPuzzles);
            // Code for testing specific Puzzle selection
            //int puzzleNumber = 3;

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
                            activeGameState.ArrPuzzleSolution[x, y] = c.ToString();
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
                            activeGameState.ArrPuzzleSolution[x, y] = c.ToString();
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
                            activeGameState.ArrPuzzleSolution[x, y] = c.ToString();
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
                            activeGameState.ArrPuzzleSolution[x, y] = c.ToString();
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
                            activeGameState.ArrPuzzleSolution[x, y] = c.ToString();
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
                            activeGameState.ArrPuzzleSolution[x, y] = c.ToString();
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
                            activeGameState.ArrPuzzleSolution[x, y] = c.ToString();
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
                            activeGameState.ArrPuzzleSolution[x, y] = c.ToString();
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
        /// Find and set difficulty level based on selected radio button
        /// </summary>
        public void SetDifficulty()
        {
            if (easyDiffRadio.IsChecked == true)
            {
                activeGameState.DifficultyLevel = "Easy";
                activeGameState.StartNumbers = 32;
            }
            else if (mediumDiffRadio.IsChecked == true)
            {
                activeGameState.DifficultyLevel = "Medium";
                activeGameState.StartNumbers = 30;
            }
            else if (hardDiffRadio.IsChecked == true)
            {
                activeGameState.DifficultyLevel = "Hard";
                activeGameState.StartNumbers = 27;
            }
            else if (expertDiffRadio.IsChecked == true)
            {
                activeGameState.DifficultyLevel = "Expert";
                activeGameState.StartNumbers = 24;
            }
            puzzleLabel.Content = activeGameState.DifficultyLevel + " Puzzle";
        }

        public void SetPuzzleStart()
        {
            int startNum = activeGameState.StartNumbers;
            int i = 0;
            Random randomNum = new Random();

            while (i < startNum)
            {
                int x = randomNum.Next(0, 8);
                int y = randomNum.Next(0, 8);
                if (activeGameState.ArrPuzzleBase[x, y] == null)
                {
                    activeGameState.ArrPuzzleBase[x, y] = activeGameState.ArrPuzzleSolution[x, y];
                    activeGameState.ArrPuzzleCurrent[x, y] = activeGameState.ArrPuzzleSolution[x, y];
                    i++;
                }
            }
        }

        /// <summary>
        /// Method for resetting the current puzzle to it's beginning state
        /// </summary>
        public void RestartPuzzle()
        {
            activeGameState.ArrPuzzleCurrent = new string[9, 9];
            int y;
            for (int x = 0; x < 9; x++)
            {
                y = 0;
                while (y < 9)
                {
                    activeGameState.ArrPuzzleCurrent[x, y] = activeGameState.ArrPuzzleBase[x, y];
                    y++;
                }
            }
        }

        /// <summary>
        /// Click event that resets puzzle with confirmation check
        /// </summary>
        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            if (activeGameState.OnGoingGame == true)
            {
                if (MessageBox.Show("Restart current puzzle?", "Confirm", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    RestartPuzzle();
                    SetGameBoard();
                }
            }
        }

        /// <summary>
        /// Click event that starts a new puzzle with confirmation check
        /// Doesn't seek confirmation if no game has been started
        /// </summary>
        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            if (activeGameState.OnGoingGame == true)
            {
                if (MessageBox.Show("Start new game?", "Confirm", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    CreateNewGame();
                }
            }
            else
            {
                CreateNewGame();
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
