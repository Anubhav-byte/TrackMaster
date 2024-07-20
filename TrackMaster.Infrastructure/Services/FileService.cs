using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMaster.Infrastructure.Services
{
    public class FileService  : IFileService
    {
        private IConfiguration _configuration;
        public FileService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> SaveFile(IFormFile uploadedFile)
        {
            var FilePath = Path.Combine(_configuration["FilePath"],uploadedFile.FileName);

            try
            {
                using (var fileStream = File.Create(FilePath))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }

                return FilePath;
            }
            catch (Exception ex)
            {

                return null;
            }
            
        }
    }
}
