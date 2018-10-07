//-----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace SudokuGame
{
    using Microsoft.Win32;
    using System;
    using System.IO;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;


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
            this.CreatePuzzle();
            this.SetDifficulty();
            this.SetPuzzleStart();
            this.SetGameBoard();
        }

        /// <summary>
        /// Method for Creating the Puzzle and filling the arrays with game data
        /// </summary>
        public void CreatePuzzle()
        {
            this.activeGameState = new GameState();
            this.activeGameState.OnGoingGame = true;
            this.activeGameState.ArrPuzzleSolution = new string[9, 9];
            this.activeGameState.ArrPuzzleBase = new string[9, 9];
            this.activeGameState.ArrPuzzleCurrent = new string[9, 9];
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
            //int rotateValue = puzzleRotation.Next(1, 8);
            int rotateValue = 3;

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
                            this.activeGameState.ArrPuzzleSolution[x, y] = c.ToString();
                            y++;
                        }
                    }

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
                            this.activeGameState.ArrPuzzleSolution[x, y] = c.ToString();
                            y--;
                        }
                    }

                    x++;
                }
            }
            else if (rotateValue == 3)
            {
                x = 8;
                y = 0;
                while (x > -1)
                {
                    string currentLine = puzzleReader.ReadLine();
                    y = 0;
                    foreach (char c in currentLine)
                    {
                        if (char.IsNumber(c))
                        {
                            this.activeGameState.ArrPuzzleSolution[x, y] = c.ToString();
                            y++;
                        }
                    }

                    x--;
                }
            }
            else if (rotateValue == 4)
            {
                x = 8;
                y = 8;
                while (x > -1)
                {
                    string currentLine = puzzleReader.ReadLine();
                    y = 8;
                    foreach (char c in currentLine)
                    {
                        if (char.IsNumber(c))
                        {
                            this.activeGameState.ArrPuzzleSolution[x, y] = c.ToString();
                            y--;
                        }
                    }

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
                            this.activeGameState.ArrPuzzleSolution[x, y] = c.ToString();
                            x++;
                        }
                    }

                    y++;
                }
            }
            else if (rotateValue == 6)
            {
                x = 0;
                y = 8;
                while (y > -1)
                {
                    string currentLine = puzzleReader.ReadLine();
                    x = 0;
                    foreach (char c in currentLine)
                    {
                        if (char.IsNumber(c))
                        {
                            this.activeGameState.ArrPuzzleSolution[x, y] = c.ToString();
                            x++;
                        }
                    }

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
                            this.activeGameState.ArrPuzzleSolution[x, y] = c.ToString();
                            x--;
                        }
                    }

                    y++;
                }
            }
            else if (rotateValue == 8)
            {
                x = 8;
                y = 8;
                while (y > -1)
                {
                    string currentLine = puzzleReader.ReadLine();
                    x = 8;
                    foreach (char c in currentLine)
                    {
                        if (char.IsNumber(c))
                        {
                            this.activeGameState.ArrPuzzleSolution[x, y] = c.ToString();
                            x--;
                        }
                    }

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
                this.activeGameState.DifficultyLevel = "Easy";
                this.activeGameState.StartNumbers = 32;
            }
            else if (mediumDiffRadio.IsChecked == true)
            {
                this.activeGameState.DifficultyLevel = "Medium";
                this.activeGameState.StartNumbers = 30;
            }
            else if (hardDiffRadio.IsChecked == true)
            {
                this.activeGameState.DifficultyLevel = "Hard";
                this.activeGameState.StartNumbers = 27;
            }
            else if (expertDiffRadio.IsChecked == true)
            {
                this.activeGameState.DifficultyLevel = "Expert";
                this.activeGameState.StartNumbers = 24;
            }

            puzzleLabel.Content = this.activeGameState.DifficultyLevel + " Puzzle";
        }

        /// <summary>
        /// Set base and current arrays to starting values
        /// </summary>
        public void SetPuzzleStart()
        {
            int startNum = this.activeGameState.StartNumbers;
            int i = 0;
            Random randomNum = new Random();

            while (i < startNum)
            {
                int x = randomNum.Next(0, 8);
                int y = randomNum.Next(0, 8);
                if (string.IsNullOrWhiteSpace(this.activeGameState.ArrPuzzleBase[x, y]))
                {
                    this.activeGameState.ArrPuzzleBase[x, y] = this.activeGameState.ArrPuzzleSolution[x, y];
                    this.activeGameState.ArrPuzzleCurrent[x, y] = this.activeGameState.ArrPuzzleSolution[x, y];
                    i++;
                }
            }
        }

        /// <summary>
        /// Method for setting the game board Cells equal to the current game array
        /// Also assigns correct settings & event handlers to each Cell
        /// </summary>
        public void SetGameBoard()
        {
            int y;
            string cellName;
            for (int x = 0; x < 9; x++)
            {
                y = 0;
                while (y < 9)
                {
                    cellName = "Cell" + x + y;
                    TextBox currentCell = FindName(cellName) as TextBox;

                    // If there is a starting value
                    // Set value and lock cell
                    if (!string.IsNullOrWhiteSpace(this.activeGameState.ArrPuzzleCurrent[x, y]))
                    {
                        if (!string.IsNullOrWhiteSpace(this.activeGameState.ArrPuzzleBase[x, y]))
                        {
                            currentCell.Text = this.activeGameState.ArrPuzzleCurrent[x, y];
                            currentCell.FontWeight = FontWeights.Bold;
                            currentCell.IsReadOnly = true;
                            currentCell.Focusable = true;
                            currentCell.TextChanged += GameCellTextChange;
                        }
                        else
                        {
                            currentCell.Text = this.activeGameState.ArrPuzzleCurrent[x, y];
                            currentCell.IsReadOnly = false;
                            currentCell.Focusable = true;
                            currentCell.FontWeight = FontWeights.Normal;
                            currentCell.TextChanged += GameCellTextChange;
                        }
                    }
                    else
                    {
                        currentCell.Text = string.Empty;
                        currentCell.IsReadOnly = false;
                        currentCell.Focusable = true;
                        currentCell.FontWeight = FontWeights.Normal;
                        currentCell.TextChanged += GameCellTextChange;
                    }

                    y++;
                }
            }
        }

        /// <summary>
        /// Method for resetting the current puzzle to it's beginning state
        /// </summary>
        public void RestartPuzzle()
        {
            this.activeGameState.ArrPuzzleCurrent = new string[9, 9];
            int y;
            for (int x = 0; x < 9; x++)
            {
                y = 0;
                while (y < 9)
                {
                    this.activeGameState.ArrPuzzleCurrent[x, y] = this.activeGameState.ArrPuzzleBase[x, y];
                    y++;
                }
            }
        }

        /// <summary>
        /// Method for loading saved game from text file
        /// </summary>
        public void OpenGameFile()
        {
            OpenFileDialog loadGameDialog = new OpenFileDialog();
            loadGameDialog.InitialDirectory = "C:\\";
            loadGameDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            loadGameDialog.Multiselect = false;

            if (loadGameDialog.ShowDialog() == true)
            {
                int totalLines = File.ReadLines(loadGameDialog.FileName).Count(line => !string.IsNullOrWhiteSpace(line));
                if (totalLines != 28)
                {
                    if (MessageBox.Show("This file appears to be an incorrect format.  Errors may occur. Load anyways?",
                            "Confirm", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                    {
                        LoadGameFile(loadGameDialog.FileName);
                    }
                }
                else
                {
                    LoadGameFile(loadGameDialog.FileName);
                }
            }
        }

        public void LoadGameFile(string fileLocation)
        {
            StreamReader savedGame = File.OpenText(fileLocation);
            this.activeGameState = new GameState();
            this.activeGameState.OnGoingGame = true;
            this.activeGameState.ArrPuzzleSolution = new string[9, 9];
            this.activeGameState.ArrPuzzleBase = new string[9, 9];
            this.activeGameState.ArrPuzzleCurrent = new string[9, 9];
            this.activeGameState.DifficultyLevel = savedGame.ReadLine();
            puzzleLabel.Content = this.activeGameState.DifficultyLevel + " Puzzle";

            while (savedGame.EndOfStream == false)
            {
                //Read Solution Puzzle from file
                int y;
                for (int x = 0; x < 9; x++)
                {
                    string currentLine = savedGame.ReadLine();
                    y = 0;
                    foreach (char c in currentLine)
                    {
                        if (char.IsNumber(c))
                        {
                            this.activeGameState.ArrPuzzleSolution[x, y] = c.ToString();
                            y++;
                        }
                    }
                }
                //Read Base Puzzle from file
                for (int x = 0; x < 9; x++)
                {
                    string currentLine = savedGame.ReadLine();
                    y = 0;
                    foreach (char c in currentLine)
                    {
                        if (char.IsNumber(c))
                        {
                            this.activeGameState.ArrPuzzleBase[x, y] = c.ToString();
                            y++;
                        }
                        else
                        {
                            this.activeGameState.ArrPuzzleBase[x, y] = String.Empty;
                            y++;
                        }
                    }
                }
                //Read Current Puzzle from file
                for (int x = 0; x < 9; x++)
                {
                    string currentLine = savedGame.ReadLine();
                    y = 0;
                    foreach (char c in currentLine)
                    {
                        if (char.IsNumber(c))
                        {
                            this.activeGameState.ArrPuzzleCurrent[x, y] = c.ToString();
                            y++;
                        }
                        else
                        {
                            this.activeGameState.ArrPuzzleCurrent[x, y] = String.Empty;
                            y++;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Method for saving a game to a text file 
        /// </summary>
        public void SaveGame()
        {
            SaveFileDialog saveGameDialog = new SaveFileDialog();
            saveGameDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveGameDialog.DefaultExt = ".txt";
            saveGameDialog.OverwritePrompt = true;
            saveGameDialog.AddExtension = true;
            if (saveGameDialog.ShowDialog() == true)
            {
                string gameData = String.Empty;
                gameData += this.activeGameState.DifficultyLevel + "\r\n";
                for (int x = 0; x < 9; x++)
                {
                    for (int y = 0; y < 9; y++)
                    {
                        gameData += this.activeGameState.ArrPuzzleSolution[x, y];
                    }

                    gameData += "\r\n";
                }
                for (int x = 0; x < 9; x++)
                {
                    for (int y = 0; y < 9; y++)
                    {
                        if (this.activeGameState.ArrPuzzleBase[x, y] != null)
                        {
                            gameData += this.activeGameState.ArrPuzzleBase[x, y];
                        }
                        else
                        {
                            gameData += "P"; // Placeholder character so lines remain set length
                        }
                    }

                    gameData += "\r\n";
                }
                for (int x = 0; x < 9; x++)
                {
                    for (int y = 0; y < 9; y++)
                    {
                        if (string.IsNullOrWhiteSpace(this.activeGameState.ArrPuzzleCurrent[x, y]))
                        {
                            gameData += "P"; // Placeholder character so lines remain set length                            
                        }
                        else
                        {
                            gameData += this.activeGameState.ArrPuzzleCurrent[x, y];
                        }
                    }

                    gameData += "\r\n";
                }
                File.WriteAllText(saveGameDialog.FileName, gameData);
            }
        }

        /// <summary>
        /// Click event that starts a new puzzle with confirmation check
        /// Doesn't seek confirmation if no game has been started
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.activeGameState.OnGoingGame == true)
            {
                if (MessageBox.Show("Start new game?", "Confirm", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    this.CreateNewGame();
                }
            }
            else
            {
                this.CreateNewGame();
            }
        }

        /// <summary>
        /// Click event that resets puzzle with confirmation check
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.activeGameState.OnGoingGame == true)
            {
                if (MessageBox.Show("Restart current puzzle?", "Confirm", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    this.RestartPuzzle();
                    this.SetGameBoard();
                }
            }
        }

        /// <summary>
        /// Click event that exits program with confirmation check
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param> 
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit?", "Confirm", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Method to validate text input & add it to Current Array
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param> 
        private void GameCellTextChange(object sender, TextChangedEventArgs e)
        {
            TextBox currentCell = sender as TextBox;
            var validInput = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "" };
            if (validInput.Contains(currentCell.Text))
            {
                string cellname = currentCell.Name;
                int x = int.Parse(cellname.Substring(4, 1));
                int y = int.Parse(cellname.Substring(5, 1));
                this.activeGameState.ArrPuzzleCurrent[x, y] = currentCell.Text;
            }
            else
            {
                currentCell.Text = String.Empty;
            }
        }

        /// <summary>
        /// Loads game from text file of players choosing
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param> 
        private void LoadGameButton_Click(object sender, RoutedEventArgs e)
        {
            OpenGameFile();
            SetGameBoard();
        }

        /// <summary>
        /// Saves game to text file of players choosing
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param> 
        private void SaveGameButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.activeGameState.OnGoingGame == true)
            {
                SaveGame();
            }
        }

        private void CheckBoxEnableNumber_Checked(object sender, RoutedEventArgs e)
        {
            MenuItemNumberTitle.IsEnabled = true;
            Number1.IsEnabled = true;
            Number2.IsEnabled = true;
            Number3.IsEnabled = true;
            Number4.IsEnabled = true;
            Number5.IsEnabled = true;
            Number6.IsEnabled = true;
            Number7.IsEnabled = true;
            Number8.IsEnabled = true;
            Number9.IsEnabled = true;
        }

        private void CheckBoxEnableNumber_Unchecked(object sender, RoutedEventArgs e)
        {
            MenuItemNumberTitle.IsEnabled = false;
            Number1.IsEnabled = false;
            Number2.IsEnabled = false;
            Number3.IsEnabled = false;
            Number4.IsEnabled = false;
            Number5.IsEnabled = false;
            Number6.IsEnabled = false;
            Number7.IsEnabled = false;
            Number8.IsEnabled = false;
            Number9.IsEnabled = false;
        }
    }
}
