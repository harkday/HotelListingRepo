using HotelListingDataAccess.Data;
using HotelListingDataAccess.Repository.Interface;
using HotelListingModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListingDataAccess.Repository.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DataBaseContext _context;
        private HotelRepository<Country> _countries;
        private HotelRepository<Hotel> _hotels;

        public UnitOfWork(DataBaseContext context)
        {
            _context = context;
            
        }
        public IGenericRepository<Country> Countries => _countries ??  new HotelRepository<Country>(_context);

        public IGenericRepository<Hotel> Hotels => _hotels??  new HotelRepository<Hotel>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
