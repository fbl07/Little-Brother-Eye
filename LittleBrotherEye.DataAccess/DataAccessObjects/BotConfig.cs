using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleBrotherEye.DataAccess.DataAccessObjects
{
    public class BotConfig : BaseDataAccess
    {
        public DataAccess.BotConfig GetBotConfig()
        {
            return Context.BotConfigs.FirstOrDefault();
        }

        public void SaveBotConfig(DataAccess.BotConfig config)
        {
            Context.Database.ExecuteSqlCommand("TRUNCATE TABLE BotConfig");

            var newConfig = new DataAccess.BotConfig()
            {
                AccessToken = config.AccessToken,
                Expire = config.Expire
            };

            Context.BotConfigs.Add(newConfig);
            Context.SaveChanges();
        }
    }
}
