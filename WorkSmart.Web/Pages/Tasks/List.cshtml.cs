using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using WorkSmart.Data;

namespace WorkSmart.Web.Pages.Tasks
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly ITaskData _taskData;

        public IEnumerable<Core.Task> Tasks { get; set; }
        public string Message { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config, ITaskData taskData)
        {
            _config = config;
            _taskData = taskData;
        }

        public void OnGet()
        {
            //Message = _config["Message"];
            Tasks = _taskData.GetTaskBySubject(SearchTerm);
        }
    }
}