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
    public interface IDepositoService
    {
        IEnumerable<Deposito> GetDepositos();
        Deposito GetDeposito(long id);
        void CreateDeposito(Deposito articulo);
        void UpdateDeposito(Deposito articulo);
        void DeleteDeposito(long id);
        void SaveDeposito();
    }

    public class DepositoService : IDepositoService
    {
        private readonly IDepositoRepository articuloRepository;
        private readonly IUnitOfWork unitOfWork;

        public DepositoService(IDepositoRepository articuloRepository, IUnitOfWork unitOfWork)
        {
            this.articuloRepository = articuloRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IDepositoService Members

        public IEnumerable<Deposito> GetDepositos()
        {
            return articuloRepository.GetAll();
        }

        public Deposito GetDeposito(long id)
        {
            return articuloRepository.GetById(id);
        }

        public void CreateDeposito(Deposito articulo)
        {
            articuloRepository.Add(articulo);
        }

        public void UpdateDeposito(Deposito articulo)
        {
            articuloRepository.Update(articulo);
        }

        public void DeleteDeposito(long id)
        {
            articuloRepository.Delete(x => x.DepositoID == id);
        }

        public void SaveDeposito()
        {
            unitOfWork.Commit();
        }

        #endregion

    }
}
