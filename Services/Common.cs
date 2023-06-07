﻿using WebApp.Data;

namespace WebApp.Services
{
    public class Common : ICommon
    {
        private readonly IWebHostEnvironment _iHostingEnvironment;
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public Common(IWebHostEnvironment iHostingEnvironment, ApplicationDbContext context, IConfiguration configuration)
        {
            _iHostingEnvironment = iHostingEnvironment;
            _context = context;
            _configuration = configuration;
        }

        public async Task<string> UploadAvatar(IFormFile avatar)
        {
            string ProfilePictureFileName = string.Empty;

            if (avatar != null)
            {
                string uploadsFolder = Path.Combine(_iHostingEnvironment.ContentRootPath, "wwwroot/upload/avatar");

                if (avatar.FileName == null)
                    ProfilePictureFileName = "blank_avatar.png";
                else
                    ProfilePictureFileName = DateTime.Now.Ticks.ToString() + "_" + avatar.FileName;
                string filePath = Path.Combine(uploadsFolder, ProfilePictureFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await avatar.CopyToAsync(fileStream);
                }
            }
            return ProfilePictureFileName;

        }

        public async Task<string> UploadProductPicture(IFormFile picture)
        {
            string ProfilePictureFileName = string.Empty;

            if (picture != null)
            {
                string uploadsFolder = Path.Combine(_iHostingEnvironment.ContentRootPath, "wwwroot/upload/productPicture");

                if (picture.FileName == null)
                    ProfilePictureFileName = "blank_avatar.png";
                else
                    ProfilePictureFileName = DateTime.Now.Ticks.ToString() + "_" + picture.FileName;
                string filePath = Path.Combine(uploadsFolder, ProfilePictureFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await picture.CopyToAsync(fileStream);
                }
            }
            return ProfilePictureFileName;

        }
    }
}
