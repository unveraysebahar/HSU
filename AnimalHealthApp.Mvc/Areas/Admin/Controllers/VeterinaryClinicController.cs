using AnimalHealthApp.Entities.Dtos;
using AnimalHealthApp.Mvc.Areas.Admin.Models;
using AnimalHealthApp.Services.Abstract;
using AnimalHealthApp.Shared.Utilities.Extensions;
using AnimalHealthApp.Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AnimalHealthApp.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Vet")]
    public class VeterinaryClinicController : Controller
    {
        private readonly IVeterinaryClinicService _veterinaryClinicService;

        public VeterinaryClinicController(IVeterinaryClinicService veterinaryClinicService)
        {
            _veterinaryClinicService = veterinaryClinicService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _veterinaryClinicService.GetAllByNonDeletedAsync();
            return View(result.Data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("_VeterinaryClinicAddPartial");
        }

        [HttpPost]
        public async Task<IActionResult> Add(VeterinaryClinicAddDto veterinaryClinicAddDto)
        {
            if(ModelState.IsValid)
            {
                var result = await _veterinaryClinicService.AddAsync(veterinaryClinicAddDto, "Ayşe Bahar Ünver");
                if(result.ResultStatus == ResultStatus.Success)
                {
                    var veterinaryClinicAddAjaxModel = JsonSerializer.Serialize(new VeterinaryClinicAddAjaxViewModel
                    {
                        VeterinaryClinicDto = result.Data,
                        VeterinaryClinicAddPartial = await this.RenderViewToStringAsync("_VeterinaryClinicAddPartial", veterinaryClinicAddDto)
                    });
                    return Json(veterinaryClinicAddAjaxModel);
                }
            }
            var veterinaryClinicAddAjaxErrorModel = JsonSerializer.Serialize(new VeterinaryClinicAddAjaxViewModel
            {
                VeterinaryClinicAddPartial = await this.RenderViewToStringAsync("_VeterinaryClinicAddPartial", veterinaryClinicAddDto)
            });
            return Json(veterinaryClinicAddAjaxErrorModel);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int veterinaryClinicId)
        {
            var result = await _veterinaryClinicService.GetVeterinaryClinicUpdateDtoAsync(veterinaryClinicId);
            if(result.ResultStatus == ResultStatus.Success)
            {
                return PartialView("_VeterinaryClinicUpdatePartial", result.Data);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(VeterinaryClinicUpdateDto veterinaryClinicUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _veterinaryClinicService.UpdateAsync(veterinaryClinicUpdateDto, "Ayşe Bahar Ünver");
                if (result.ResultStatus == ResultStatus.Success)
                {
                    var veterinaryClinicUpdateAjaxModel = JsonSerializer.Serialize(new VeterinaryClinicUpdateAjaxViewModel
                    {
                        VeterinaryClinicDto = result.Data,
                        VeterinaryClinicUpdatePartial = await this.RenderViewToStringAsync("_VeterinaryClinicUpdatePartial", veterinaryClinicUpdateDto)
                    });
                    return Json(veterinaryClinicUpdateAjaxModel);
                }
            }
            var veterinaryClinicUpdateAjaxErrorModel = JsonSerializer.Serialize(new VeterinaryClinicUpdateAjaxViewModel
            {
                VeterinaryClinicUpdatePartial = await this.RenderViewToStringAsync("_VeterinaryClinicUpdatePartial", veterinaryClinicUpdateDto)
            });
            return Json(veterinaryClinicUpdateAjaxErrorModel);
        }

        public async Task<JsonResult> GetAllVeterinaryClinic()
        {
            var result = await _veterinaryClinicService.GetAllByNonDeletedAsync();
            var veterinaryClinic = JsonSerializer.Serialize(result.Data, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return Json(veterinaryClinic);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int veterinaryClinicId)
        {
            var result = await _veterinaryClinicService.DeleteAsync(veterinaryClinicId, "Ayşe Bahar");
            var deletedVeterinaryClinic = JsonSerializer.Serialize(result.Data);
            return Json(deletedVeterinaryClinic);
        }
    }
}
