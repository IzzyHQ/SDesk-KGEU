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

        partial void OrderFilter_PreprocessQuery(string ShowAll, ref IQueryable<OrderItem> query)
        {
            query = query.Where(p => p.UserOwner.Login == "IlnurV");


            if (ShowAll == null)
            {
                query = query.Where(z => z.Status.StatusId != 4);
            }
            else if (ShowAll == "Новая")
            {
                query = query.Where(p => p.Status.StatusId == 1);

            }
            else if (ShowAll == "В работе")
            {
                query = query.Where(p => p.Status.StatusId == 2);
            }
            else if (ShowAll == "Выполнена")
            {
                query = query.Where(p => p.Status.StatusId == 3);
            }
            else if (ShowAll == "Отклонена")
            {
                query = query.Where(p => p.Status.StatusId == 4);
            }
        }

        partial void TaskFilter_PreprocessQuery(string Filter, ref IQueryable<TaskItem> query)
        {
            query = query.Where(p => p.UserItem.Login == "IlnurV");


            if (Filter == null)
            {
                query = query.Where(z => z.StatusItem.StatusId != 4).Where(z => z.StatusItem.StatusId != 3);
            }
            else if (Filter == "Новая")
            {
                query = query.Where(p => p.StatusItem.StatusId == 1);

            }
            else if (Filter == "В работе")
            {
                query = query.Where(p => p.StatusItem.StatusId == 2);
            }
            else if (Filter == "Выполнена")
            {
                query = query.Where(p => p.StatusItem.StatusId == 3);
            }
            else if (Filter == "Отклонена")
            {
                query = query.Where(p => p.StatusItem.StatusId == 4);

            }
        
        }

        partial void HtmlOrderFilter_PreprocessQuery(ref IQueryable<OrderItem> query)
        {
            query = query.Where(p => p.UserOwner.Login == "IlnurV");

            
                query = query.Where(z => z.Status.StatusId != 4).Where(z => z.Status.StatusId != 3);
            
        }


       
    }
}
