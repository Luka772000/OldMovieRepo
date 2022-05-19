using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektFinal.Repository
{
    public interface IRepositoryWrapper
    {
        IFilmDetailRepository FilmDetail { get; }
        IProdKucaRepository ProdKuca { get; }
        void Save();
    }
}
