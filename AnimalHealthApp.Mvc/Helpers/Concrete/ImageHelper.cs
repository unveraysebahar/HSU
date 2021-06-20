using AnimalHealthApp.Entities.Dtos;
using AnimalHealthApp.Mvc.Helpers.Abstract;
using AnimalHealthApp.Shared.Utilities.Extensions;
using AnimalHealthApp.Shared.Utilities.Results.Abstract;
using AnimalHealthApp.Shared.Utilities.Results.ComplexTypes;
using AnimalHealthApp.Shared.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalHealthApp.Mvc.Helpers.Concrete
{
    public class ImageHelper : IImageHelper
    {
        private readonly IWebHostEnvironment _env;
        private readonly string _wwwroot;
        private readonly string imgFolder = "img";

        public ImageHelper(IWebHostEnvironment env)
        {
            _env = env;
            _wwwroot = _env.WebRootPath;
        }

        public IDataResult<ImageDeletedDto> Delete(string pictureName)
        {
            var fileToDelete = Path.Combine($"{_wwwroot}/{imgFolder}/", pictureName);
            if (System.IO.File.Exists(fileToDelete))
            {
                var fileInfo = new FileInfo(fileToDelete);
                var imageDeletedDto = new ImageDeletedDto
                {
                    FullName = pictureName,
                    Extension = fileInfo.Extension,
                    Path = fileInfo.FullName,
                    Size = fileInfo.Length
                };
                System.IO.File.Delete(fileToDelete);
                return new DataResult<ImageDeletedDto>(ResultStatus.Success, imageDeletedDto);
            }
            else
            {
                return new DataResult<ImageDeletedDto>(ResultStatus.Error, $"Böyle bir resim bulunamadı", null);
            }
        }

        public async Task<IDataResult<ImageUploadedDto>> UploadUserImage(string userName, IFormFile pictureFile, string folderName = "userImages")
        {
            if(!Directory.Exists($"{_wwwroot}/{imgFolder}/{folderName}")) // Böyle bir klasör var mı? Yoksa bu işlenmleri yap
            {
                Directory.CreateDirectory($"{_wwwroot}/{imgFolder}/{folderName}");
            }
            // ~/img/user.Picture
            // aysebahar
            string oldFileName = Path.GetFileNameWithoutExtension(pictureFile.FileName); // Resmin adını alıyoruz
            // .png
            string fileExtension = Path.GetExtension(pictureFile.FileName); // Uzantısını alıyoruz
            DateTime dateTime = DateTime.Now;
            // aysebahar_587_5_38_12_3_10_2020.png
            string newFileName = $"{userName}_{dateTime.FullDateAndTimeStringWithUnderScore()}{fileExtension}"; // Yeni isim oluşturuyoruz
            //string fileName = $"{userAddDto.UserName} {dateTime.FullDateAndTimeStringWithUnderScore()} {fileName2}";
            var path = Path.Combine($"{_wwwroot}/{imgFolder}/{folderName}", newFileName);
            await using (var stream = new FileStream(path, FileMode.Create))
            {
                await pictureFile.CopyToAsync(stream);
            }
            return new DataResult<ImageUploadedDto>(ResultStatus.Success, $"{userName} adlı kullanıcının resimi başarıyla yüklenmiştir.", new ImageUploadedDto 
            { 
                FullName = $"{folderName}/{newFileName}", // String Formatlama
                OldName = oldFileName,
                Extension = fileExtension,
                FolderName = folderName,
                Path = path,
                Size = pictureFile.Length // byte
            }); // aysebahar_587_5_38_12_3_10_2020.png "~/img/user.Picture"
        }
    }
}
