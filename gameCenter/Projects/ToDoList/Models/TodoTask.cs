using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameCenter.Projects.ToDoList.Models
{
    internal class TodoTask
    {
        //properties
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate{ get; set; }
        public bool IsComplete{ get; set; }

        //constractor
        public TodoTask(int id, string description)
        { Id = id;
          Description = description; 
          CreateDate = DateTime.Now; 
          IsComplete = false;
        }



    }
}
