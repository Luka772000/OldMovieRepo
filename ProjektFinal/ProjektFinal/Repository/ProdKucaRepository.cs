using ProjektFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektFinal.Repository
{
    public class ProdKucaRepository : RepositoryBase<ProductionHouse>, IProdKucaRepository
    {
        public ProdKucaRepository(FilmContext filmContext)
            : base(filmContext)
        { }
    }
}