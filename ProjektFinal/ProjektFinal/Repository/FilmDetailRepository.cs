using ProjektFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektFinal.Repository
{
    public class FilmDetailRepository: RepositoryBase<Film>,IFilmDetailRepository
    {
        public FilmDetailRepository(FilmContext filmContext)
            : base(filmContext)
        { }
    }
}
