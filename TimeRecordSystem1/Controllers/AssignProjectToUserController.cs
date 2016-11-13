using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeRecordSystem1.Models;
using TimeRecordSystem1.ViewModels;

namespace TimeRecordSystem1.Controllers
{
    public class AssignProjectToUserController : Controller
    {
        ApplicationDbContext _context;
        public AssignProjectToUserController()
        {

            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: AssignProjectToUser
        public ActionResult Index()
        {

            var AssignProjectToUserViewModels = new List<AssignProjectToUserViewModel>();

            var queryUserByProject = from assignProjectToUser in _context.AssignProjectToUsers.ToList()
                                     group assignProjectToUser by assignProjectToUser.Project.Id;


            foreach (var userGroup in queryUserByProject)
            {

                var assignProjectToUserViewModel = new AssignProjectToUserViewModel() {};
                assignProjectToUserViewModel.Users = new List<Models.User>();

                assignProjectToUserViewModel.Project = _context.Projects.SingleOrDefault(c => c.Id == userGroup.Key);
                foreach (AssignProjectToUser assignProjectToUser in userGroup)
                {
                    var user = _context.Users.SingleOrDefault(c => c.Id == assignProjectToUser.User.Id);
                    assignProjectToUserViewModel.Users.Add(user);
                }

                AssignProjectToUserViewModels.Add(assignProjectToUserViewModel);

            }
            
            return View(AssignProjectToUserViewModels);
        }

        public ActionResult Create()
        {
            var assignProjectToUserCreationViewModel = new AssignProjectToUserCreationViewModel
            {

                AllProjects = _context.Projects,
                AllUsers = _context.Users
            };

            return View(assignProjectToUserCreationViewModel);
        }

        [HttpPost]
        public ActionResult Save(AssignProjectToUserCreationViewModel assignProjectToUserCreationViewModel)
        {
            var project = _context.Projects.SingleOrDefault(c => c.Id == assignProjectToUserCreationViewModel.SelectedProjectId);

            foreach (var userId in assignProjectToUserCreationViewModel.SelectedUserIds)
            {

                var assignProjectToUser = new AssignProjectToUser();
                assignProjectToUser.Project = project;
                assignProjectToUser.User = _context.Users.SingleOrDefault(c => c.Id == userId);
                _context.AssignProjectToUsers.Add(assignProjectToUser);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "AssignProjectToUser");
        }
    }
}