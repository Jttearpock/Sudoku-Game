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

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            CreatePuzzle();
        }

        public void CreatePuzzle()
        {
            ActiveGameState.ArrPuzzleSolution = new int[9, 9];
            ActiveGameState.ArrPuzzleBase = new int[9, 9];
            ActiveGameState.ArrPuzzleCurrent = new int[9, 9];
            StreamReader puzzleReader = File.OpenText(@"..\..\SudokuPuzzleSolutions.txt");

            Random puzzleRotation = new Random();
            int rotateValue = puzzleRotation.Next(1, 8);
            // Code for testing specific Rotation
            // int rotateValue = 6;

            
            Random selectPuzzle = new Random();
            int puzzleNumber = selectPuzzle.Next(1, 4);
            // Code for testing specific Puzzle selection
            // int puzzleNumber = 2;
            int x;
            int y;
            int linecount;

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
                            ActiveGameState.ArrPuzzleSolution[x, y] = (int) char.GetNumericValue(c);
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
                            ActiveGameState.ArrPuzzleSolution[x, y] = (int) char.GetNumericValue(c);
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
                            ActiveGameState.ArrPuzzleSolution[x, y] = (int) char.GetNumericValue(c);
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
                            ActiveGameState.ArrPuzzleSolution[x, y] = (int) char.GetNumericValue(c);
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
                            ActiveGameState.ArrPuzzleSolution[x, y] = (int)char.GetNumericValue(c);
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
                            ActiveGameState.ArrPuzzleSolution[x, y] = (int)char.GetNumericValue(c);
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
                            ActiveGameState.ArrPuzzleSolution[x, y] = (int)char.GetNumericValue(c);
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
                            ActiveGameState.ArrPuzzleSolution[x, y] = (int)char.GetNumericValue(c);
                            // After char is read, increment the y variable
                            x--;
                        }
                    }

                    // After Line is read, increment the x variable
                    y--;
                }
            }
        }
    }
}
