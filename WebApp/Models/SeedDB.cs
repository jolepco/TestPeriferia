using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class SeedDB
    {
        private readonly DataContext _dataContext;


        public SeedDB(DataContext context)
        {
            _dataContext = context;
        }

        public async Task SeedAsync()
        {
            await CheckciudadesAsync();

        }

        private async Task CheckciudadesAsync()
        {
            if (!_dataContext.Ciudades.Any())
            {
                _dataContext.Ciudades.Add(new Ciudad     {  Nombre = "Moniquira" ,Permitida=true});
                _dataContext.Ciudades.Add(new Ciudad { Nombre = "Duitama" ,Permitida=true});
                _dataContext.Ciudades.Add(new Ciudad { Nombre = "Tunja" ,Permitida=false});
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}
