using ProjektFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektFinal.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private FilmContext _filmContext;
        private IFilmDetailRepository _filmdetail;
        private IProdKucaRepository _prodkuca;

        public IFilmDetailRepository FilmDetail
        {
            get
            {
                if (_filmdetail == null)
                {
                    _filmdetail= new FilmDetailRepository(_filmContext);
                }
                return _filmdetail;
            }
        }
        public IProdKucaRepository ProdKuca
        {
            get
            {
                if (_prodkuca == null)
                {
                    _prodkuca = new ProdKucaRepository(_filmContext);
                }
                return _prodkuca;
            }
        }
        public RepositoryWrapper(FilmContext filmContext)
        {
            _filmContext = filmContext;
        }
        public void Save()
        {
            _filmContext.SaveChanges();
        }
    }
}
