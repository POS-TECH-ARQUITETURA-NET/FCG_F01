using API_FCG_F01.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_FCG_F01.Domain.Interfaces
{
    public interface ICompraRepository
    {
        Task<Compra?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<IEnumerable<Compra>> GetAllAsync(CancellationToken ct = default);
        Task AddAsync(Compra entity, CancellationToken ct = default);
        Task UpdateAsync(Compra entity, CancellationToken ct = default);
        Task DeleteAsync(Guid id, CancellationToken ct = default);
    }
}
