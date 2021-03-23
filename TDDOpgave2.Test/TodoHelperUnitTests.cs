using System;
using System.Collections.Generic;
using TDDOpgave2.Test.Fakes;
using Xunit;

namespace TDDOpgave2.Test
{
    public class TodoHelperUnitTests
    {
        [Fact]
        public void Create_Todo()
        {
            //Arrange
            var notificationHelperMock = new NotificationHelperFake();
            var todoHelper = GetTodoHelper(notificationHelperMock);
            var name = "MyTodo";

            //Act
            var result = todoHelper.Create(name);


            //Assert
            Assert.NotNull(result);
            Assert.Equal(name, result.Name);
            Assert.False(result.IsCompleted);
        }
        
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Create_Todo_EmptyName(string name)
        {
            //Arrange
            var notificationHelperMock = new NotificationHelperFake();
            var todoHelper = GetTodoHelper(notificationHelperMock);
            Todo result = null;
            var expectedExceptionMessage = "Name must not be empty.";
            var exceptionMessage = "";

            //Act
            try
            {
                result = todoHelper.Create(name);
            }
            catch(Exception ex)
            {
                exceptionMessage = ex.Message;
            }

            //Assert
            Assert.Null(result);
            Assert.Equal(expectedExceptionMessage, exceptionMessage);
        }

        [Fact]
        public void Edit_Todo()
        {
            //Arrange
            var notificationHelperMock = new NotificationHelperFake();
            var todoHelper = GetTodoHelper(notificationHelperMock);
            var name = "New todo name";
            var todo = new Todo() { Name = "kjkjh" };

            //Act
            var result = todoHelper.Edit(todo,name);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(name, result.Name);
            Assert.False(result.IsCompleted);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Edit_Todo_EmptyName(string name)
        {
            //Arrange
            var notificationHelperMock = new NotificationHelperFake();
            var todoHelper = GetTodoHelper(notificationHelperMock);
            Todo result = null;
            var expectedExceptionMessage = "Name must not be empty.";
            var exceptionMessage = "";
            var todo = new Todo() { Name = "kjkjh" };

            //Act
            try
            {
                result = todoHelper.Edit(todo,name);
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;
            }

            //Assert
            Assert.Null(result);
            Assert.Equal(expectedExceptionMessage, exceptionMessage);
        }

        [Fact]
        public void Edit_Todo_NullTodo()
        {
            //Arrange
            var notificationHelperMock = new NotificationHelperFake();
            var todoHelper = GetTodoHelper(notificationHelperMock);
            Todo result = null;
            var expectedExceptionMessage = "Todo cannot be null.";
            var exceptionMessage = "";

            //Act
            try
            {
                result = todoHelper.Edit(null, "hokuspokus");
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;
            }

            //Assert
            Assert.Null(result);
            Assert.Equal(expectedExceptionMessage, exceptionMessage);
        }

        [Fact]
        public void MarkTodoAsCompleted()
        {
            //Arrange
            var notificationHelperMock = new NotificationHelperFake();
            var todoHelper = GetTodoHelper(notificationHelperMock);
            var todo = new Todo() { Name = "hep" };

            //Act
            var result = todoHelper.MarkAsCompleted(todo);

            //Assert
            Assert.NotNull(result);
            Assert.True(result.IsCompleted);
        }

        [Fact]
        public void MarkTodoAsCompleted_TodoAlreadyCompleted()
        {
            //Arrange
            var notificationHelperMock = new NotificationHelperFake();
            var todoHelper = GetTodoHelper(notificationHelperMock);
            var todo = new Todo() { IsCompleted = true, Name = "Hep" };
            var expectedExceptionMessage = "Todo is already completed.";
            var exceptionMessage = "";
            Todo result = null;

            //Act
            try
            {
                result = todoHelper.MarkAsCompleted(todo);
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;
            }

            //Assert
            Assert.Null(result);
            Assert.Equal(expectedExceptionMessage, exceptionMessage);
        }

        [Fact]
        public void MarkTodoAsCompleted_NullTodo()
        {
            //Arrange
            var notificationHelperMock = new NotificationHelperFake();
            var todoHelper = GetTodoHelper(notificationHelperMock);
            Todo result = null;
            var expectedExceptionMessage = "Todo cannot be null.";
            var exceptionMessage = "";

            //Act
            try
            {
                result = todoHelper.MarkAsCompleted(null);
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;
            }

            //Assert
            Assert.Null(result);
            Assert.Equal(expectedExceptionMessage, exceptionMessage);
        }

        [Fact]
        public void MarkTodoAsCompleted_NotificationSent()
        {
            //Arrange
            var notificationHelperStub = new NotificationHelperFake();
            var todoHelper = GetTodoHelper(notificationHelperStub); //Stub because it is used for validation. Mock is not.
            var todo = new Todo() { Name = "MyTodo" };
            var message = "MyTodo is completed.";

            //Act
            var result = todoHelper.MarkAsCompleted(todo);

            //Assert
            Assert.NotNull(result);
            Assert.True(result.IsCompleted);
            Assert.Equal(message, notificationHelperStub.NotificationMessage);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void MarkTodoAsCompleted_EmptyName(string name)
        {
            //Arrange
            var notificationHelperMock = new NotificationHelperFake();
            var todoHelper = GetTodoHelper(notificationHelperMock);
            var todo = new Todo() { Name = name };
            var expectedExceptionMessage = "Name must not be empty.";
            var exceptionMessage = "";
            Todo result = null;

            //Act
            try
            {
                result = todoHelper.MarkAsCompleted(todo);
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;
            }

            //Assert
            Assert.Null(result);
            Assert.Equal(expectedExceptionMessage, exceptionMessage);
        }

        [Fact]
        public void MarkTodoAsInComplete_NotificationSent()
        {
            //Arrange
            var notificationHelperStub = new NotificationHelperFake();
            var todoHelper = GetTodoHelper(notificationHelperStub); //Stub because it is used for validation. Mock is not.
            var todo = new Todo() { Name = "MyTodo", IsCompleted = true };
            var message = "MyTodo is incomplete.";

            //Act
            var result = todoHelper.MarkAsInComplete(todo);

            //Assert
            Assert.NotNull(result);
            Assert.False(result.IsCompleted);
            Assert.Equal(message, notificationHelperStub.NotificationMessage);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void MarkTodoAsInComplete_EmptyName(string name)
        {
            //Arrange
            var notificationHelperMock = new NotificationHelperFake();
            var todoHelper = GetTodoHelper(notificationHelperMock);
            var todo = new Todo() { Name = name, IsCompleted = true };
            var expectedExceptionMessage = "Name must not be empty.";
            var exceptionMessage = "";
            Todo result = null;

            //Act
            try
            {
                result = todoHelper.MarkAsInComplete(todo);
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;
            }

            //Assert
            Assert.Null(result);
            Assert.Equal(expectedExceptionMessage, exceptionMessage);
        }

        [Fact]
        public void MarkTodoAsInComplete()
        {
            //Arrange
            var notificationHelperMock = new NotificationHelperFake();
            var todoHelper = GetTodoHelper(notificationHelperMock);
            var todo = new Todo() { Name = "Hey", IsCompleted = true };

            //Act
            var result = todoHelper.MarkAsInComplete(todo);

            //Assert
            Assert.NotNull(result);
            Assert.False(result.IsCompleted);
        }

        [Fact]
        public void MarkTodoAsInComplete_TodoAlreadyInComplete()
        {
            //Arrange
            var notificationHelperMock = new NotificationHelperFake();
            var todoHelper = GetTodoHelper(notificationHelperMock);
            var todo = new Todo() { Name = "Hey" };
            var expectedExceptionMessage = "Todo is already incomplete.";
            var exceptionMessage = "";
            Todo result = null;

            //Act
            try
            {
                result = todoHelper.MarkAsInComplete(todo);
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;
            }

            //Assert
            Assert.Null(result);
            Assert.Equal(expectedExceptionMessage, exceptionMessage);
        }

        [Fact]
        public void MarkTodoAsInComplete_NullTodo()
        {
            //Arrange
            var notificationHelperMock = new NotificationHelperFake();
            var todoHelper = GetTodoHelper(notificationHelperMock);
            Todo result = null;
            var expectedExceptionMessage = "Todo cannot be null.";
            var exceptionMessage = "";

            //Act
            try
            {
                result = todoHelper.MarkAsInComplete(null);
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;
            }

            //Assert
            Assert.Null(result);
            Assert.Equal(expectedExceptionMessage, exceptionMessage);
        }

        [Fact]
        public void GetTodos()
        {
            //Arrange
            var notificationHelperMock = new NotificationHelperFake();
            var todoHelper = GetTodoHelper(notificationHelperMock,true);
            var numberOfTodos = 2;

            //Act
            var list = todoHelper.GetTodos();

            //Assert
            Assert.NotNull(list);
            Assert.Equal(numberOfTodos, list.Count);
        }

        [Fact]
        public void GetTodos_EmptyList()
        {
            //Arrange
            var notificationHelperMock = new NotificationHelperFake();
            var todoHelper = GetTodoHelper(notificationHelperMock);
            var numberOfTodos = 0;

            //Act
            var list = todoHelper.GetTodos();

            //Assert
            Assert.NotNull(list);
            Assert.Equal(numberOfTodos, list.Count);
        }

        private TodoHelper GetTodoHelper(INotificationHelper notificationHelper, bool isPopulated = false)
        {
            if(isPopulated)
            {
                List<Todo> todos = new List<Todo>();
                todos.Add(new Todo { Name = "hep" });
                todos.Add(new Todo { Name = "hey" });
                return new TodoHelper(todos, notificationHelper);
            }
            return new TodoHelper(notificationHelper);
        }
    }
}
