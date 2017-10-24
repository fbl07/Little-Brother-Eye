using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleBrotherEye.DataAccess.DataAccessObjects
{
    public class APIKey : BaseDataAccess
    {
        public DataAccess.APIKey LoadAPIKey(Guid apiKey)
        {
            return Context.APIKeys.FirstOrDefault(x => x.APIKey1 == apiKey);
        }

        public DataAccess.APIKey LoadAPIKey(string email)
        {
            return Context.APIKeys.FirstOrDefault(x => x.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase));
        }

        public Guid SaveAPIKey(DataAccess.APIKey data)
        {
            if (data.APIKey1 != Guid.Empty)
            {
                Context.APIKeys.Attach(data);
                Context.Entry(data).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                data.APIKey1 = Guid.NewGuid();
                Context.APIKeys.Add(data);
            }

            Context.SaveChanges();

            return data.APIKey1;
        }

    }
}
