using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Infrastructure.Data;

namespace WhiteLagoon.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IVillaRepository villaRepo { get; private set; }
        public IVillaRoomRepository villaRoomRepo { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            villaRepo = new VillaRepository(_context);
            villaRoomRepo = new VillaRoomRepository(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }   
    }
}
