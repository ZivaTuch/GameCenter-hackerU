using gameCenter.Projects.ToDoList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace gameCenter.Projects.NewFolder
{
    /// <summary>
    /// Interaction logic for ToDoList.xaml
    /// </summary>
    public partial class ToDoList : Window
    {
        private TodoListModel _todoList;
        public ToDoList()
        {
            InitializeComponent();
            initializeTasks();
        }
        // initializeTasks
        //1.create new todolistmodel
        //2. add 2 static tasks
        //3. listTasks.ItemSource = _todoList.Tasks;
        //OnTextBlockMouseLeftButtonDown

        private void initializeTasks()
        {
            _todoList = new TodoListModel(); // constractor

            _todoList.AddNewTask(new TodoTask(1, "do my Homework"));
            _todoList.AddNewTask(new TodoTask(2, "complete the project"));
            listTasks.ItemsSource = _todoList.Tasks;
        }
      
        //OnTaskToggled
        private void OnTaskToggled(object sender,RoutedEventArgs e)
        { if (sender is CheckBox  cb && cb.DataContext is TodoTask task)
                {
                _todoList.ToggleTaskIsComplete(task.Id);
                }                 
        }
        //OnSaveEdit
        private void OnSaveEdit(object sender, RoutedEventArgs e)
        {
            Button btnSave = sender as Button;
            StackPanel parent = btnSave.Parent as StackPanel;
            TextBox editTextBox = parent.FindName("editTaskDescription") as TextBox;
            TextBlock textBlock = parent.FindName("txtTaskDescription") as TextBlock;
            TodoTask task = textBlock.DataContext as TodoTask;

             textBlock.Visibility = Visibility.Visible;
             editTextBox.Visibility = Visibility.Collapsed;
             btnSave.Visibility = Visibility.Collapsed;

              textBlock.Text =editTextBox.Text ;
            _todoList.UpdateTask(task.Id, textBlock.Text);


        }

        //OnAddTask
        private void OnAddTask(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNewTask.Text) )
            {
               TodoTask newTask = new TodoTask(_todoList.Tasks.Count+1, txtNewTask.Text); // create new task

                _todoList.AddNewTask(newTask);
                txtNewTask.Clear();
            }
        }

        private void OnTextBlockMouseLeftButtonDown(object sender,MouseButtonEventArgs e)
        {
             if (e.ClickCount == 2)
            {
                TextBlock textBlock = sender as TextBlock;
                StackPanel parent = textBlock.Parent as StackPanel;
                TextBox editTextBox = parent.FindName("editTaskDescription") as TextBox;
                Button btnSave = parent.FindName("btnSave") as Button;

                //hide the textBlock
                textBlock.Visibility = Visibility.Collapsed;
                //show the text Box & save button
                editTextBox.Visibility = Visibility.Visible;
                btnSave.Visibility = Visibility.Visible;

                //show int the TextBox.Text the task description
                editTextBox.Text = textBlock.Text;
            }
        }

    }
}
