using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.LightSwitch;
using Microsoft.LightSwitch.Security.Server;
namespace LightSwitchApplication
{
    public partial class DeskDataService
    {



        partial void Query1_PreprocessQuery(string ShowAll, bool? Showall2, ref IQueryable<OrderItem> query)
        {
            if (ShowAll == "Новая")
            {
                query = query.Where(p => p.Task.All(z => z.StatusItem == null));

            }
            else if (ShowAll=="В работе")
            {
                query = query.Where(p => p.Task.Any(z => z.StatusItem.StatusId == 2));
            }
            else if (ShowAll == "Выполнена")
            {
                query = query.Where(p => p.Task.Any(z => z.StatusItem.StatusId == 3));
            }
            else if (ShowAll == "Отклонена")
            {
                query = query.Where(p => p.Task.Any(z => z.StatusItem.StatusId == 4));
            }



            if (!Showall2.Value)
            {
                query = query.Where(p => p.Task.All(z => z.StatusItem.StatusId == 1));
            }
          
        }
    }
}
