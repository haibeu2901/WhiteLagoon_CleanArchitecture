using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;

namespace WhiteLagoon.Infrastructure.Repository
{
    public class VillaRoomRepository : Repository<VillaRoom>, IVillaRoomRepository
    {
        private readonly ApplicationDbContext _context;

        public VillaRoomRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(VillaRoom entity)
        {
            _context.VillaRooms.Update(entity);
        }
    }
}
