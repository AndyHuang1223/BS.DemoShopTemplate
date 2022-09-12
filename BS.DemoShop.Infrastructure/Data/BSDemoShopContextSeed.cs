using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BS.DemoShop.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BS.DemoShop.Infrastructure.Data
{
    public class BSDemoShopContextSeed
    {
        public static void SeedDevelopment(BSDemoShopContext context, ILogger logger, int retry = 0)
        {
            var retryForAvailability = retry;
            try
            {
                if (!context.Database.IsSqlServer())
                {
                    return;
                }
                //先刪除再建立，確保測試資料是乾淨的
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                
            }
            catch (Exception ex)
            {
                if (retryForAvailability >= 5) throw;

                retryForAvailability++;

                logger.LogError(ex.Message);
                SeedDevelopment(context, logger, retryForAvailability);
                throw;
            }
        }

        public static void SeedForProduction(BSDemoShopContext context, ILogger logger, int retry = 0)
        {
            var retryForAvailability = retry;
            try
            {
                if (!context.Database.IsSqlServer())
                {
                    return;
                }
                //套用Migrations相關紀錄
                context.Database.Migrate();
               
            }
            catch (Exception ex)
            {
                if (retryForAvailability >= 5) throw;

                retryForAvailability++;

                logger.LogError(ex.Message);
                SeedForProduction(context, logger, retryForAvailability);
                throw;
            }

        }

    }
}