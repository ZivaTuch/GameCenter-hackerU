using gameCenter.Projects.CurrencyConverter;
using gameCenter.Projects.CurrencyConverter.Services;
using gameCenter.Projects.NewFolder;
using gameCenter.Projects.UsersManager;
using gameCenter.Projects.TicTacTow;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using gameCenter.Projects;
using gameCenter.Projects.Calculator;
using System.Numerics;
using System.Security.AccessControl;
using System.Security.Policy;
using System.Windows.Documents;
using gameCenter.Projects.Snake;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Windows.Controls.Image;
using Application = System.Windows.Application;

namespace gameCenter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
             
            DispatcherTimer clock = new()
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            clock.Tick += ShowCurrentDate!;
            clock.Start();
           

        }

        public void ShowCurrentDate(object sender, EventArgs e)
        {
            DateLabel.Content = DateTime.UtcNow.ToString("dd/MM/yy hh:mm");
          

        }
        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            Image image = (sender as Image)!;
            image.Opacity = 0.7;
            GameText.Content = (image.Name) switch
            {
                "Image1" => "a User Management System",
                "Image2" => "Todo List",
                "Image3" => "Currency convertor",
                "Image4" => "Tic Tac Toe",
                "Image5" => "Calculator",
                "Image6" => "Snake Game",
                _ => "please pick a game"
            };
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as Image)!.Opacity = 1;
            GameText.Content = "please pick a game";
        }
   
        private void Image1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            UsersManager UsersManager = new();
            projectPresentationPage presentetion = new();
            Hide();
            presentetion.OnStart("User Manegment ", "" +
                "A user management system streamlines the process of overseeing user accounts,\n" +
                " ensuring that the right people have the right level of access to the application or system.\n" +
                " It contributes to efficient user administration, enhances data security," +
                " and helps maintain compliance with privacy regulations.", Image1.Source, UsersManager);
           
            presentetion.ShowDialog();
            Show();


        }

   
          private void Image2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
         
            ToDoList todoListProject = new();
            projectPresentationPage presentetion = new();
            Hide();
            presentetion.OnStart("To-Do List", "" +
                "A to-do list is a simple and effective organizational tool used to keep track of tasks," +
                " activities, or goals that need to be accomplished within a certain timeframe." +
                " It serves as a visual reminder of what needs to be done, helping individuals prioritize and manage" +
                " their responsibilities more efficiently. By listing tasks in a structured manner, " +
                "users can track progress, set priorities, and achieve their objectives with greater clarity and focus." +
                " To-do lists are commonly used in both personal and professional settings to enhance productivity and ensure" +
                " that important tasks are not overlooked.", Image2.Source, todoListProject);

            presentetion.ShowDialog();
            Show();




        }
        private void Image3_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CurrenctConvertorView CurrencyServiceProj = new();
            projectPresentationPage presentetion = new();
            Hide();
            presentetion.OnStart("Currency Convertor", "" +
              " currency converter program is a practical tool designed to convert monetary values from one currency to another." +
              " It helps users quickly and accurately determine the equivalent amount in a different currency," +
              " making international transactions, budgeting," +
              " and financial planning more accessible and manageable." +
              " By inputting the value in a source currency and selecting a target currency, " +
              "users can obtain real-time exchange rates and obtain the corresponding converted amount." +
              "Currency converter programs are widely used for personal and business purposes, " +
              "enabling individuals and organizations to navigate global financial transactions with ease" +
              " and make informed decisions about currency exchange.", Image3.Source, CurrencyServiceProj);

            presentetion.ShowDialog();
            Show();

        }
        private void Image4_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
      
            TicTacTowView TicTacTowProj = new();
            projectPresentationPage presentetion = new();
            Hide();
            presentetion.OnStart("Tic Tac Toe", "" +
                "Tic-Tac-Toe is a strategic game that requires players to anticipate their opponent's" +
                " moves and plan their own to prevent their opponent from forming a winning line.\n" +
                " Due to its simplicity, the game serves as an entertaining and quick pastime that is often used to" +
                " introduce basic game theory concepts to children and newcomers to gaming." +
                " It is also frequently used as a teaching tool for programming and artificial intelligence due" +
                " to its straightforward rules and manageable complexity.", Image4.Source, TicTacTowProj);
            presentetion.ShowDialog();
            Show();


        }
        private void Image5_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CalculatorView CalculatorProj = new();
            projectPresentationPage presentetion = new();
            Hide();
            presentetion.OnStart("Calculator", "" +
                "A simple calculator is a mathematical tool used for performing basic arithmetic operations such as addition, subtraction," +
                " multiplication, and division between numbers.\n" +
                " The calculator was created to aid in quick and accurate calculations, " +
                "and it consists of several buttons representing numbers and basic operations." +
                " A simple calculator can be used for various purposes, including business calculations," +
                " academic tasks, or everyday calculations."
                , Image5.Source, CalculatorProj);
            presentetion.ShowDialog();
            Show();
        }
        private void Image6_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            SnakeView SnakeProj = new();
            projectPresentationPage presentetion = new();
            Hide();
            presentetion.OnStart("Snake Game", "" +
            "A snake game is a classic and simple video game where the player controls a snake that moves around a rectangular grid or playing field." +
            "The objective of the game is to eat food items that appear on the grid," +
            " which causes the snake to grow longer.As the snake grows, it becomes more challenging to navigate without running into the walls " +
            "of the playing field or colliding with itself.", Image6.Source,SnakeProj);
            presentetion.ShowDialog();
            Show();
        }
        private async void Window_IsLeftMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            await Dispatcher.BeginInvoke(() =>
            {
                DragMove();
            });
        }
        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void minimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void image_ReturnYoMain(object sender, MouseButtonEventArgs e)
        {
            Show();
        }
    }
}
