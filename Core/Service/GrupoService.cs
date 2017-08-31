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
    public interface IGrupoService
    {
        IEnumerable<Grupo> GetGrupos();
        Grupo GetGrupo(long id);
        void CreateGrupo(Grupo articulo);
        void UpdateGrupo(Grupo articulo);
        void DeleteGrupo(long id);
        void SaveGrupo();
    }

    public class GrupoService : IGrupoService
    {
        private readonly IGrupoRepository articuloRepository;
        private readonly IUnitOfWork unitOfWork;

        public GrupoService(IGrupoRepository articuloRepository, IUnitOfWork unitOfWork)
        {
            this.articuloRepository = articuloRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IGrupoService Members

        public IEnumerable<Grupo> GetGrupos()
        {
            return articuloRepository.GetAll();
        }

        public Grupo GetGrupo(long id)
        {
            return articuloRepository.GetById(id);
        }

        public void CreateGrupo(Grupo articulo)
        {
            articuloRepository.Add(articulo);
        }

        public void UpdateGrupo(Grupo articulo)
        {
            articuloRepository.Update(articulo);
        }

        public void DeleteGrupo(long id)
        {
            articuloRepository.Delete(x => x.GrupoID == id);
        }

        public void SaveGrupo()
        {
            unitOfWork.Commit();
        }

        #endregion

    }
}
