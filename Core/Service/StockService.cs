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
    public interface IStockService
    {
        IEnumerable<Stock> GetStocks();
        IEnumerable<Stock> GetStocksByArticulo(long articuloID);
        IEnumerable<Stock> GetStocksByDeposito(long depositoID);
        Stock GetStock(long articuloID, long depositoID);
        void CreateStock(Stock articulo);
        void UpdateStock(Stock articulo);
        void DeleteStock(long articuloID, long depositoID);
        void SaveStock();
    }

    public class StockService : IStockService
    {
        private readonly IStockRepository articuloRepository;
        private readonly IUnitOfWork unitOfWork;

        public StockService(IStockRepository articuloRepository, IUnitOfWork unitOfWork)
        {
            this.articuloRepository = articuloRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IStockService Members

        public IEnumerable<Stock> GetStocks()
        {
            return articuloRepository.GetAll();
        }

        public IEnumerable<Stock> GetStocksByArticulo( long articuloID )
        {
            return articuloRepository.GetAll().Where(x => x.ArticuloID == articuloID);
        }

        public IEnumerable<Stock> GetStocksByDeposito(long depositoID)
        {
            return articuloRepository.GetAll().Where(x => x.DepositoID == depositoID);
        }

        public Stock GetStock(long articuloID, long depositoID)
        {
            return articuloRepository.Get(x => x.ArticuloID == articuloID && x.DepositoID == depositoID);
        }

        public void CreateStock(Stock articulo)
        {
            articuloRepository.Add(articulo);
        }

        public void UpdateStock(Stock articulo)
        {
            articuloRepository.Update(articulo);
        }

        public void DeleteStock(long articuloID, long depositoID)
        {
            articuloRepository.Delete(x => x.ArticuloID == articuloID && x.DepositoID == depositoID);
        }

        public void SaveStock()
        {
            unitOfWork.Commit();
        }

        #endregion

    }
}
