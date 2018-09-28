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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void newGameButton_Click(object sender, RoutedEventArgs e)
        {
            CreatePuzzle();                                   
        }

        public void CreatePuzzle()
        {
            ActiveGame currentGame = new ActiveGame();
            currentGame.ArrPuzzleSolution = new int[9, 9];
            currentGame.ArrPuzzleBase = new int[9, 9];
            currentGame.ArrPuzzleCurrent = new int[9, 9];
            StreamReader puzzleReader = File.OpenText(@"..\..\SudokuPuzzleSolutions.txt");

            Random puzzleRotation = new Random();
            int rotateValue = puzzleRotation.Next(1, 4);

            int x = 0;
            int y = 0;
            while (x < 9)
            {
                string currentLine = puzzleReader.ReadLine();
                y = 0;
                foreach (char c in currentLine)
                {
                    if (char.IsNumber(c))
                    {
                        // Place the number into the first value of the array
                        currentGame.ArrPuzzleSolution[x, y] = (int)char.GetNumericValue(c);
                        // After char is read, increment the y variable
                        y++;
                    }
                }
                // After Line is read, increment the x variable
                x++;
            }
        }
    }
}
