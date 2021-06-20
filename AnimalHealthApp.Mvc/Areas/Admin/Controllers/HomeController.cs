using AnimalHealthApp.Entities.Concrete;
using AnimalHealthApp.Mvc.Areas.Admin.Models;
using AnimalHealthApp.Services.Abstract;
using AnimalHealthApp.Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalHealthApp.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Vet")]
    public class HomeController : Controller
    {
        private readonly IVeterinaryClinicService _animalSpeciesService;
        private readonly IAnimalService _animalService;
        private readonly IHealthInformationService _commentService;
        private readonly UserManager<User> _userManager;

        public HomeController(IVeterinaryClinicService animalSpeciesService, IAnimalService animalService, IHealthInformationService commentService, UserManager<User> userManager)
        {
            _animalSpeciesService = animalSpeciesService;
            _animalService = animalService;
            _commentService = commentService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var animalSpeciesCountResult = await _animalSpeciesService.CountByIsDeletedAsync();
            var animalsCountResult = await _animalSpeciesService.CountByIsDeletedAsync();
            var commentsCountResult = await _commentService.CountByIsDeletedAsync();
            var usersCount = await _userManager.Users.CountAsync();
            var animalsResult = await _animalService.GetAllAsync();
            if(animalSpeciesCountResult.ResultStatus == ResultStatus.Success && animalsCountResult.ResultStatus == ResultStatus.Success && commentsCountResult.ResultStatus == ResultStatus.Success && usersCount > -1 && animalsResult.ResultStatus == ResultStatus.Success)
            {
                return View(new DashboardViewModel
                {
                    VeterinaryClinicsCount = animalSpeciesCountResult.Data,
                    AnimalsCount = animalsCountResult.Data,
                    HealthInformationsCount = commentsCountResult.Data,
                    UsersCount = usersCount,
                    Animals = animalsResult.Data
                });
            }
            return NotFound();
        }
    }
}
