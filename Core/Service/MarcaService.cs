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
    public interface IMarcaService
    {
        IEnumerable<Marca> GetMarcas();
        Marca GetMarca(long id);
        void CreateMarca(Marca articulo);
        void UpdateMarca(Marca articulo);
        void DeleteMarca(long id);
        void SaveMarca();
    }

    public class MarcaService : IMarcaService
    {
        private readonly IMarcaRepository articuloRepository;
        private readonly IUnitOfWork unitOfWork;

        public MarcaService(IMarcaRepository articuloRepository, IUnitOfWork unitOfWork)
        {
            this.articuloRepository = articuloRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IMarcaService Members

        public IEnumerable<Marca> GetMarcas()
        {
            return articuloRepository.GetAll();
        }

        public Marca GetMarca(long id)
        {
            return articuloRepository.GetById(id);
        }

        public void CreateMarca(Marca articulo)
        {
            articuloRepository.Add(articulo);
        }

        public void UpdateMarca(Marca articulo)
        {
            articuloRepository.Update(articulo);
        }

        public void DeleteMarca(long id)
        {
            articuloRepository.Delete(x => x.MarcaID == id);
        }

        public void SaveMarca()
        {
            unitOfWork.Commit();
        }

        #endregion

    }
}
