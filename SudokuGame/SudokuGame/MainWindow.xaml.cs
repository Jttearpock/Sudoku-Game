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

namespace SudokuGame
{
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
            ActiveGame CurrentGame = new ActiveGame();
            CurrentGame.ArrPuzzleSolution = new int[9, 9];
            CurrentGame.ArrPuzzleBase = new int[9, 9];
            CurrentGame.ArrPuzzleCurrent = new int[9, 9];
            StreamReader PuzzleReader = File.OpenText(@"..\..\SudokuPuzzleSolutions.txt");
            // Random RandomPuzzle = new Random(1-4);
            int x = 0;
            int y = 0;
            while (x < 9)
            {
                string currentLine = PuzzleReader.ReadLine();
                y = 0;
                foreach (char c in currentLine)
                {
                    if (char.IsNumber(c))
                    {                                       
                        // Place the number into the first value of the array
                        CurrentGame.ArrPuzzleSolution[x, y] = (int)char.GetNumericValue(c);
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
