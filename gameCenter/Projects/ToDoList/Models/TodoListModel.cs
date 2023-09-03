using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace gameCenter.Projects.ToDoList.Models
{
    internal class TodoListModel
    {
        //properties
        //List of tasks - ObservableCollection
        public ObservableCollection<TodoTask> Tasks { get; set; }

        //methods
        //Constructor
        public TodoListModel() 
        { 
            Tasks = new ObservableCollection<TodoTask>();
        }
         public void UpdateTask(int taskid,string newDescription)
        {
            TodoTask? TaskUpdate = Tasks.FirstOrDefault(Tasks => Tasks.Id == taskid);

            // אם האיבר נמצא, עדכון התיאור שלו
            if (TaskUpdate != null)
            {
                TaskUpdate.Description = newDescription;
            }
            else
            {
                Console.WriteLine("Item with ID not found.");
            }
        }
       
        public void ToggleTaskIsComplete(int taskid)
        {
            TodoTask? TaskUpdate = Tasks.FirstOrDefault(Tasks => Tasks.Id == taskid);

            // אם האיבר נמצא, עדכון התיאור שלו
            if (TaskUpdate != null)
            {
                TaskUpdate.IsComplete = !TaskUpdate.IsComplete; 
            }
            else
            {
                Console.WriteLine("Item with ID not found.");
            }

        }

        public void AddNewTask(TodoTask task) 
        {
           Tasks.Add(task);

        }

    }
}
