using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TimetrackerWebApp.ViewModels;
using Domain.Interfaces.TaskContext;
using Domain.TaskItems;

namespace TimetrackerWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITaskItemRepository _taskItemRepository;

        public HomeController(ILogger<HomeController> logger,
            ITaskItemRepository taskItemRepository)
        {
            _logger = logger;
            _taskItemRepository = taskItemRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string sortOrder)
        {
            List<TaskItemViewModel> model = new List<TaskItemViewModel>();
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["CategorySortParm"] = sortOrder == "Category" ? "category_desc" : "Category";
            ViewData["StartDateSortParm"] = sortOrder == "StartDate" ? "start_date_desc" : "StartDate";
            ViewData["EndDateSortParm"] = sortOrder == "StartDate" ? "end_date_desc" : "EndDate";
            var tasks = await _taskItemRepository.ListAllAsync();
            switch (sortOrder)
            {
                case "name_desc":
                    tasks = tasks.OrderBy(s => s.Name).ToList();
                    break;
                case "start_date_desc":
                    tasks = tasks.OrderByDescending(s => s.StartDateTime).ToList();
                    break;
                case "StartDate":
                    tasks = tasks.OrderBy(s => s.StartDateTime).ToList();
                    break;
                case "end_date_desc":
                    tasks = tasks.OrderByDescending(s => s.EndDateTime).ToList();
                    break;
                case "EndDate":
                    tasks = tasks.OrderBy(s => s.EndDateTime).ToList();
                    break;
                case "Category":
                    tasks = tasks.OrderBy(s => s.Category).ToList();
                    break;
                case "category_desc":
                    tasks = tasks.OrderByDescending(s => s.Category).ToList();
                    break;
                default:
                    tasks = tasks.OrderByDescending(s => s.Name).ToList();
                    break;
            }
            foreach (var t in tasks)
            {
                TaskItemViewModel taskItem = new TaskItemViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    Category = t.Category,
                    StartDateTime = t.StartDateTime,
                    EndDateTime = t.EndDateTime
                };
                model.Add(taskItem);
            }
            return View(model);
        }


        [HttpGet]
        public ActionResult AddTaskItem()
        {
            TaskItemViewModel model = new TaskItemViewModel();

            return PartialView("_AddTaskItem", model);
        }


        [HttpPost]
        public async Task<IActionResult> AddTaskItem(TaskItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                TaskItem taskItem = new TaskItem
                {
                    Name = model.Name,
                    Category = model.Category,
                    StartDateTime = model.StartDateTime,
                    EndDateTime = model.EndDateTime
                };
                await _taskItemRepository.AddAsync(taskItem);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTaskItem(TaskItemViewModel taskItemVM)
        {
            TaskItem taskItem = new TaskItem(taskItemVM.Name, taskItemVM.Category, taskItemVM.StartDateTime, taskItemVM.EndDateTime);
            var createdTask = await _taskItemRepository.TaskCreateNewAsync(taskItem);
            return View(createdTask);

        }




        public IActionResult TaskItem()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
