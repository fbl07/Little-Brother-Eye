using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleBrotherEye.DataAccess.DataAccessObjects
{
    public class BotPosts : BaseDataAccess
    {
        public DataAccess.BotPost GetLatestPost()
        {
            return Context.BotPosts.OrderByDescending(x => x.CreateTime).FirstOrDefault();
        }

        public int SavePost(BotPost data)
        {
            if (data.PostId > 0)
            {
                Context.BotPosts.Attach(data);
                Context.Entry(data).State = System.Data.Entity.EntityState.Modified;
            }
            else
                Context.BotPosts.Add(data);

            Context.SaveChanges();

            return data.PostId;
        }
    }
}
