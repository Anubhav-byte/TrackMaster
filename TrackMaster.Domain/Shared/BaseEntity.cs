using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMaster.Domain.Shared
{
    public class BaseEntity
    {
        private DateTime _created;
        private DateTime _modified;

        public DateTime Created { get => _created; set => _created = value; }
        public DateTime Modified { get => _modified; set => _modified = value; }
    }
}
