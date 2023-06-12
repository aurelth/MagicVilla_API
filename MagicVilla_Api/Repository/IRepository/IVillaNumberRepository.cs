using MagicVilla_Api.Models;
using System.Linq.Expressions;

namespace MagicVilla_Api.Repository.IRepository
{
    public interface IVillaNumberRepository : IRepository<VillaNumber>
    {
        Task<VillaNumber> Update(VillaNumber entity);
    }
}
