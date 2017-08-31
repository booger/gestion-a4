using Core.Data.Infrastructure;
using Core.Data.Repositories;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IArticuloService
    {
        IEnumerable<Articulo> GetArticulos();
        Articulo GetArticulo(long id);
        void CreateArticulo(Articulo articulo);
        void UpdateArticulo(Articulo articulo);
        void DeleteArticulo(long id);
        void SaveArticulo();
    }

    public class ArticuloService : IArticuloService
    {
        private readonly IArticuloRepository articuloRepository;
        private readonly IUnitOfWork unitOfWork;

        public ArticuloService(IArticuloRepository articuloRepository, IUnitOfWork unitOfWork)
        {
            this.articuloRepository = articuloRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IArticuloService Members

        public IEnumerable<Articulo> GetArticulos()
        {
            return articuloRepository.GetAll();
        }

        public Articulo GetArticulo(long id)
        {
            return articuloRepository.GetById(id);
        }

        public void CreateArticulo(Articulo articulo)
        {
            articuloRepository.Add(articulo);
        }

        public void UpdateArticulo(Articulo articulo)
        {
            articuloRepository.Update(articulo);
        }

        public void DeleteArticulo(long id)
        {
            articuloRepository.Delete(x => x.ArticuloID == id);
        }

        public void SaveArticulo()
        {
            unitOfWork.Commit();
        }

        #endregion

    }
}
