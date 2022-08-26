using Application.DTO;
using Application.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject1.MockData;
using TodoappApi.Controllers;
using Xunit;

namespace TestProject1
{
    public class TodoControllerTest
    {
        [Fact]
        public void TodoController_Should_Return_200status()
        {
            var todoservice = new Mock<ITodoService>();
            todoservice.Setup(_ => _.GetAll()).Returns(TodoMockData.GetTodos());
            var obj = new TodoController(todoservice.Object);
            var res = obj.GetAllItem();
            var s = res.Result as OkObjectResult;
            s.StatusCode.Should().Be(200);
            
        }

        [Fact]
        public void TodoController_Should_matchdata ()
        {
            var todoservice = new Mock<ITodoService>();
            todoservice.Setup(_ => _.GetAll()).Returns(TodoMockData.GetTodos());
            var obj = new TodoController(todoservice.Object);
            var res = obj.GetAllItem();
            Assert.IsType<OkObjectResult>(res.Result);
            var okresult = res.Result.Should().BeOfType<OkObjectResult>().Subject;
            var post = okresult.Value.Should().BeAssignableTo<List<TodoDto>>().Subject;
            Assert.Equal(1,post[0].Id);

        }

        [Fact]
        public void TodoController_Should_matchcount()
        {
            var todoservice = new Mock<ITodoService>();
            todoservice.Setup(_ => _.GetAll()).Returns(TodoMockData.GetTodos());
            var obj = new TodoController(todoservice.Object);
            var res = obj.GetAllItem();
            Assert.IsType<OkObjectResult>(res.Result);
            var okresult = res.Result.Should().BeOfType<OkObjectResult>().Subject;
            var post = okresult.Value.Should().BeAssignableTo<List<TodoDto>>().Subject;
            Assert.Equal(3, post.Count);

        }

        [Fact]
        public void TodoController_Should_returnempty()
        {
            var todoservice = new Mock<ITodoService>();
            todoservice.Setup(_ => _.GetAll()).Returns(TodoMockData.GetEmptyTodos());
            var obj = new TodoController(todoservice.Object);
            var res = obj.GetAllItem();
            Assert.IsType<OkObjectResult>(res.Result);
            var okresult = res.Result.Should().BeOfType<OkObjectResult>().Subject;
            var post = okresult.Value.Should().BeAssignableTo<List<TodoDto>>().Subject;
            Assert.Empty(post);

        }

        [Fact]
        public void TodoController_add_shouldreurn200()
        {
            var todoservice = new Mock<ITodoService>();
            var dto = TodoMockData.AddToDo();
            todoservice.Setup(_ => _.AddTask(dto)).Returns(true);
            var obj = new TodoController(todoservice.Object);
            var res = obj.AddTask(dto);
            var s = res.Result as OkObjectResult;
            s.StatusCode.Should().Be(200);

        }

        [Fact]
        public void TodoController_add_shouldbetrue()
        {
            var todoservice = new Mock<ITodoService>();
            var dto = TodoMockData.AddToDo();
            todoservice.Setup(_ => _.AddTask(dto)).Returns(true);
            var obj = new TodoController(todoservice.Object);
            var res = obj.AddTask(dto);
            var s = res.Result as OkObjectResult;
            Assert.True((bool)s.Value);

        }

        [Fact]
        public void TodoController_add_shouldbefalse()
        {
            var todoservice = new Mock<ITodoService>();
            var dto = TodoMockData.AddToDo();
            todoservice.Setup(_ => _.AddTask(dto)).Returns(false);
            var obj = new TodoController(todoservice.Object);
            var res = obj.AddTask(dto);
            var s = res.Result as OkObjectResult;
            Assert.False((bool)s.Value);

        }

        [Fact]
        public void TodoController_delete_shouldreurn200()
        {
            var todoservice = new Mock<ITodoService>();
        
            todoservice.Setup(_ => _.DeleteTask(1)).Returns(true);
            var obj = new TodoController(todoservice.Object);
            var res = obj.DeleteTask(1);
            var s = res.Result as OkObjectResult;
            s.StatusCode.Should().Be(200);

        }

        [Fact]
        public void TodoController_delete_shouldbetrue()
        {
            var todoservice = new Mock<ITodoService>();

            todoservice.Setup(_ => _.DeleteTask(1)).Returns(true);
            var obj = new TodoController(todoservice.Object);
            var res = obj.DeleteTask(1);
            var s = res.Result as OkObjectResult;
            Assert.True((bool)s.Value);

        }

        [Fact]
        public void TodoController_delete_shouldbefalse()
        {
            var todoservice = new Mock<ITodoService>();

            todoservice.Setup(_ => _.DeleteTask(1)).Returns(false);
            var obj = new TodoController(todoservice.Object);
            var res = obj.DeleteTask(1);
            var s = res.Result as OkObjectResult;
            Assert.False((bool)s.Value);

        }
    }
}
