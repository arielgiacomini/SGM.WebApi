using SGM.Domain.Entities;
using System.Collections.Generic;

namespace SGM.Infrastructure.Repositories.Interfaces
{
    public interface IControleStatusRepository
    {
        IEnumerable<ControleStatus> GetControleStatusByAll();
    }
}