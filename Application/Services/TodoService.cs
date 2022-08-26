using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TodoService : ITodoService
    {
        private readonly IUnitofWork _unitofWork;
        public TodoService(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public bool AddTask(TodoDto todoDto)
        {
            //can use automapper
            var todo = new TodoTask
            {
                Id = todoDto.Id,
                Name = todoDto.Name,
                LastModifiedAt = DateTime.Now,
                Status = true,
                Description = todoDto.Description
            };
            _unitofWork.TodoRepo.Add<TodoTask>(todo);
            return _unitofWork.Save() > 0;
        }

        public bool DeleteTask(int id)
        {
            _unitofWork.TodoRepo.Delete<TodoTask>(x => x.Id == id);
            return _unitofWork.Save() > 0;
        }

        public List<TodoDto> GetAll()
        {
            List<TodoDto> todoDtos = new List<TodoDto>();
            var data = _unitofWork.TodoRepo.GetAll().OrderByDescending(x=>x.LastModifiedAt);
            if(data.Count() > 0)
            {
              
                foreach(var item in data)
                {
                    TodoDto obj = new TodoDto
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Description = item.Description,
                        Status = item.Status,
                        LastModifiedAt = item.LastModifiedAt,
                    };

                    todoDtos.Add(obj);
                }
            }
            return todoDtos;
                
        }
    }
}
