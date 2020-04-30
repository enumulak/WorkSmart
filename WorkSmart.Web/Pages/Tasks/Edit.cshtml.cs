using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WorkSmart.Core;
using WorkSmart.Data;
using Task = WorkSmart.Core.Task;

namespace WorkSmart.Web.Pages.Tasks
{
    public class EditModel : PageModel
    {
        private readonly ITaskData _taskData;
        private readonly IHtmlHelper _htmlHelper;

        [BindProperty]
        public Task Task { get; set; }
        public IEnumerable<SelectListItem> Priority { get; set; }
        
        public EditModel(ITaskData taskData, IHtmlHelper htmlHelper)
        {
            _taskData = taskData;
            _htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int taskId)
        {
            Priority = _htmlHelper.GetEnumSelectList<TaskPriority>();

            Task = _taskData.GetTaskById(taskId);

            if (Task == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            Task = _taskData.Update(Task);
            _taskData.Commit();

            return Page();
        }
    }
}