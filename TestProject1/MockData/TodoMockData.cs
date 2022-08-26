using Application.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.MockData
{
    public class TodoMockData
    {
        public static List<TodoDto> GetTodos()
        {
            return new List<TodoDto>
            {
                new TodoDto
                {
                    Id = 1,
                    Name = "tst",
                    Description = "this is a test task",
                    Status = true,
                    LastModifiedAt = DateTime.Now.AddDays(20),
                },
                 new TodoDto
                {
                    Id = 2,
                    Name = "demo",
                    Description = "this is a demo task for unit test",
                    Status = true,
                    LastModifiedAt = DateTime.Now.AddDays(10),
                },
                  new TodoDto
                {
                    Id = 3,
                    Name = "sample",
                    Description = "this is a sample task and only for testging purpose",
                    Status = true,
                    LastModifiedAt = DateTime.Now.AddDays(43),
                }
            };
        }

        public static List<TodoDto> GetEmptyTodos()
        {
            return new List<TodoDto>
            {
                
            };
        }

        public static TodoDto AddToDo()
        {
            return new TodoDto
            {
                Id = 4,
                Name = "Add Task",
                Description = "Descrption for add test",
                Status = true,
                LastModifiedAt = DateTime.Now
            };
        }
    }
}
