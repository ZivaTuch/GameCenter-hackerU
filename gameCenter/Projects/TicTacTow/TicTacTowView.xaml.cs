﻿using gameCenter.Projects.TicTacTow.Models;
using System.Windows;
using System.Windows.Controls;

namespace gameCenter.Projects.TicTacTow
{
    public partial class TicTacTowView : Window
    {
        GameTicTacTow GameModel;

        public TicTacTowView()
        {
            InitializeComponent();
            GameModel = new GameTicTacTow();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (button != null && string.IsNullOrEmpty(button.Content as string))
            {
                button.Content = GameModel.CurrentPlayer.ToString();
                int row = Grid.GetRow(button);
                int column = Grid.GetColumn(button);
                GameModel.GameBoard[row, column] = GameModel.CurrentPlayer;

                if (GameModel.CheckForWin())
                {
                    MessageBox.Show($"{GameModel.CurrentPlayer} wins!", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
                    ResetGame();
                }
                else
                {
                    if (GameModel.IsBoardFull())
                    {
                        MessageBox.Show("It's a draw!", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
                        ResetGame();
                    }
                    else
                    {
                        GameModel.ToggleCurrentPlayer();
                    }
                }
            }
        }
        private void ResetGame()
        {
            GameModel = new GameTicTacTow();

            // Clear the game board
            foreach (Button button in MainGrid.Children)
            {
                button.Content = "";
            }
        }
    }
}