using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMaster.Domain.Models;
using TrackMaster.Domain.Persistence;
using TrackMaster.Domain.Repository._shared;
using TrackMaster.Domain.Tasks;
using TaskAttachment = TrackMaster.Domain.Models.TaskAttachment;

namespace TrackMaster.Infrastructure.Repository
{
    public class FileAttachmentRepository : BaseRepository,ITaskAttachmentRepository
    {
        public FileAttachmentRepository(TrackMasterContext trackMasterContext) : base(trackMasterContext)
        {
        }

        public async Task<TaskAttachment> AddAttachment(string fullFilePath, string fileType)
        {

            try
            {
                var attachedFile = await _dbContext.TaskAttachments.AddAsync(new Domain.Models.TaskAttachment()
                {
                    AttachmentType = fileType,
                    AttchmentLocation = fullFilePath
                });

                if(attachedFile.State.ToString() == "Added")
                {
                    await _dbContext.SaveChangesAsync();
                    return attachedFile.Entity;
                }
                

                

                return null;

            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        } 

        public async Task<TaskAttachment> GetTaskAttachment(int attachmentId)
        {
            try
            {
                var dbResponse = _dbContext.TaskAttachments.Where(x => x.AttachmentId == attachmentId).FirstOrDefault();

                return dbResponse;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
