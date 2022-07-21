using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTO
{
    public class ToDoDTO
    {
        public int Id { get; set; }
        public string Task { get; set; }
        public bool Status { get; set; }
    }
}
