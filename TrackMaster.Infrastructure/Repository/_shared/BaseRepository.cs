using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMaster.Domain.Persistence;

namespace TrackMaster.Domain.Repository._shared
{
    public class BaseRepository
    {
        protected TrackMasterContext _dbContext;
        public BaseRepository(TrackMasterContext trackMasterContext) {
            _dbContext = trackMasterContext;
        }
    }
}
