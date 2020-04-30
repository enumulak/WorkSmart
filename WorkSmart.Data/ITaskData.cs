using System;
using System.Collections.Generic;
using System.Text;
using WorkSmart.Core;
using System.Linq;

namespace WorkSmart.Data
{
    public interface ITaskData
    {
        //IEnumerable<Task> GetAll();

        IEnumerable<Task> GetTaskBySubject(string subject);

        Task GetTaskById(int id);

        Task Update(Task updatedTask);

        int Commit();
    }

    public class InMemoryTaskData : ITaskData
    {
        List<Task> tasks;

        public InMemoryTaskData()
        {
            tasks = new List<Task>()
            {
                new Task { Id = 1, Subject = "First Subject", Description = "Task 1", Priority = TaskPriority.Low },
                new Task { Id = 2, Subject = "Second Subject", Description = "Task 2", Priority = TaskPriority.Low },
                new Task { Id = 3, Subject = "Third Subject", Description = "Task 3", Priority = TaskPriority.Low }
            };
        }

        //public IEnumerable<Task> GetAll()
        //{
           // return from t in tasks
             //      orderby t.Subject
               //    select t;

            //throw new NotImplementedException();
        //}

        public IEnumerable<Task> GetTaskBySubject(string subject = null)
        {
            return from t in tasks
                   where string.IsNullOrEmpty(subject) || t.Subject.StartsWith(subject)
                   orderby t.Subject
                   select t;

            throw new NotImplementedException();
        }

        public Task GetTaskById(int id)
        {
            return tasks.SingleOrDefault(t => t.Id == id);
        }

        public Task Update(Task updatedTask)
        {
            var task = tasks.SingleOrDefault(t => t.Id == updatedTask.Id);

            if (task != null)
            {
                task.Subject = updatedTask.Subject;
                task.Description = updatedTask.Description;
                task.Priority = updatedTask.Priority;
            }

            return task;
        }

        public int Commit()
        {
            return 0;
        }
    }
}
