using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public  interface ITodoService
    {
        public List<TodoDto> GetAll();
        public bool AddTask(TodoDto todoDto);

        public bool DeleteTask(int id);
    }
}
