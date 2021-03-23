using System;
using System.Collections.Generic;
using System.Text;

namespace TDDOpgave2
{
    public class TodoHelper
    {
        private List<Todo> _todos;
        private INotificationHelper _notificationHelper;

        public TodoHelper(INotificationHelper notificationHelper)
        {
            _todos = new List<Todo>();
            _notificationHelper = notificationHelper;
        }
        public TodoHelper(List<Todo> todos, INotificationHelper notificationHelper) //TODO make this internal for testing purposes.
        {
            _todos = todos;
            _notificationHelper = notificationHelper;
        }
        public Todo Create(string name)
        {
            ValidateName(name);
            var todo = new Todo();
            return Edit(todo, name);
        }
        public Todo Edit(Todo todo, string name)
        {
            ValidateTodo(todo);
            ValidateName(name);
            todo.Name = name;
            return todo;
        }
        private void ValidateName(string name)
        {
            if(String.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Name must not be empty.");
            }
        }
        private void ValidateTodo(Todo todo)
        {
            if (todo == null)
            {
                throw new Exception("Todo cannot be null.");
            }
        }
        public Todo MarkAsCompleted(Todo todo)
        {
            ValidateTodo(todo);
            ValidateName(todo.Name);

            if (todo.IsCompleted)
            {
                throw new Exception("Todo is already completed.");
            }
            
            todo.IsCompleted = true;
            _notificationHelper.Notify($"{todo.Name} is completed.");

            return todo;
        }
        public Todo MarkAsInComplete(Todo todo)
        {
            ValidateTodo(todo);
            ValidateName(todo.Name);
            if (!todo.IsCompleted)
            {
                throw new Exception("Todo is already incomplete.");
            }
            
            todo.IsCompleted = false;
            _notificationHelper.Notify($"{todo.Name} is incomplete.");
            return todo;
        }
        public List<Todo> GetTodos()
        {
            return _todos;
        }
    }
}
