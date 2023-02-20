using One.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.Services
{
    public interface IOneEmailServices
    {
        Task<List<OneEmailModel>> GetOneEmailList();
        Task<int> AddOneEmail(OneEmailModel oneEmailModel);
        Task<int> DeleteOneEmail(OneEmailModel oneEmailModel);
        Task<int> UpdatOneEmail(OneEmailModel oneEmailModel);
    }
}
