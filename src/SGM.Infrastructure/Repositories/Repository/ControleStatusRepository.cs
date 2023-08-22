using SGM.Domain.Entities;
using SGM.Infrastructure.Context;
using SGM.Infrastructure.Repositories.Interfaces;
using System.Collections.Generic;

namespace SGM.Infrastructure.Repositories.Repository
{
    public class ControleStatusRepository : IControleStatusRepository
    {
        private readonly SGMContext _sGMContext;

        public ControleStatusRepository(SGMContext sGMContext)
        {
            _sGMContext = sGMContext;
        }

        public IEnumerable<ControleStatus> GetControleStatusByAll()
        {
            var controleStatus = new List<ControleStatus>();

            return controleStatus;
        }
    }
}