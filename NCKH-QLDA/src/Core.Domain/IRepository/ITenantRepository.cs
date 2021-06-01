using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.IRepository
{
    public interface ITenantRepository
    {
        //Task<List<TenantSearchViewModel>> SearchAsync(string keyword, bool? isActive);
        //Task<list<tenantsearchviewmodel>> selectallasync();
        //task<int> insertasync(tenant tenant);
        //task<int> updateasync(tenant tenant);
        //task<int> forcedeleteasync(string id);
        //task<tenant> getinfoasync(string id);
        //task<bool> checkexistsasync(string id);
        //task<bool> checkexistbyemailorphoneasync(string id, string phonenumber, string email);
        //task<bool> checkexistbydomainasync(string id, string domain);
        Task<string> GetidKhoaByDomainAsync(string domain);
        Task<int> UpdateIsActiveAsync(string id, bool isActive);
    }
}
