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
    public interface ILineaService
    {
        IEnumerable<Linea> GetLineas();
        Linea GetLinea(long id);
        void CreateLinea(Linea articulo);
        void UpdateLinea(Linea articulo);
        void DeleteLinea(long id);
        void SaveLinea();
    }

    public class LineaService : ILineaService
    {
        private readonly ILineaRepository articuloRepository;
        private readonly IUnitOfWork unitOfWork;

        public LineaService(ILineaRepository articuloRepository, IUnitOfWork unitOfWork)
        {
            this.articuloRepository = articuloRepository;
            this.unitOfWork = unitOfWork;
        }

        #region ILineaService Members

        public IEnumerable<Linea> GetLineas()
        {
            return articuloRepository.GetAll();
        }

        public Linea GetLinea(long id)
        {
            return articuloRepository.GetById(id);
        }

        public void CreateLinea(Linea articulo)
        {
            articuloRepository.Add(articulo);
        }

        public void UpdateLinea(Linea articulo)
        {
            articuloRepository.Update(articulo);
        }

        public void DeleteLinea(long id)
        {
            articuloRepository.Delete(x => x.LineaID == id);
        }

        public void SaveLinea()
        {
            unitOfWork.Commit();
        }

        #endregion

    }
}
