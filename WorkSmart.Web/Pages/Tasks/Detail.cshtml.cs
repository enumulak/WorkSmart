using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkSmart.Data;
using Task = WorkSmart.Core.Task;

namespace WorkSmart.Web.Pages.Tasks
{
    public class DetailModel : PageModel
    {
        private readonly ITaskData _taskData;
        public Task Task { get; set; }

        public DetailModel(ITaskData taskData)
        {
            _taskData = taskData;
        }

        public IActionResult OnGet(int taskId)
        {
            Task = _taskData.GetTaskById(taskId);

            if (Task == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }
    }
}