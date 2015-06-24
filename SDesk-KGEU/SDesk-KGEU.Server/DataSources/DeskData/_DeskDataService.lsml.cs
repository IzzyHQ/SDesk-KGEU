using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.LightSwitch;
using Microsoft.LightSwitch.Security.Server;
using System.Linq.Expressions;

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

  

        partial void Order_Inserting(OrderItem entity)
        {
            string currentUser = Application.User.Identity.Name;
            entity.UserOwner = DataWorkspace.DeskData.User.Where(p => p.Login == currentUser).FirstOrDefault();
        }

        partial void Order_Filter(ref Expression<Func<OrderItem, bool>> filter)
        {
            filter = (x => x.UserOwner.Login == Application.User.Identity.Name);

        }

        partial void Order_Updating(OrderItem entity)
        {
            entity.UserOwner = DataWorkspace.DeskData.User.Where(p => p.Login == this.Application.User.Name).FirstOrDefault();
        }

        partial void OrdersForUser_PreprocessQuery(string paramSort, ref IQueryable<OrderItem> query)
        {
            
        }

        partial void Comment_Inserting(CommentItem entity)
        {
            string currentUser = Application.User.Identity.Name;
            entity.UserItem = DataWorkspace.DeskData.User.Where(p => p.Login == currentUser).FirstOrDefault();
        }

        partial void Comment_Updated(CommentItem entity)
        {
            string currentUser = Application.User.Identity.Name;
            entity.UserItem = DataWorkspace.DeskData.User.Where(p => p.Login == currentUser).FirstOrDefault();
        }

        partial void SortOrdersHtml_PreprocessQuery(string chooseList, ref IQueryable<OrderItem> query)
        {
            query = query.Where(x => x.UserOwner.Login == this.Application.User.Name);
            if (chooseList==null)
            {
                query = query.Where(x => x.Status.StatusId != 3).Where(x => x.Status.StatusId != 4);
            }
            if (chooseList == "Новая")
            {
                query = query.Where(x => x.Status.StatusId == 1);
            }
            if (chooseList == "В работе")
            {
                query = query.Where(x => x.Status.StatusId == 2);
            }

            if (chooseList == "Все")
            {
                query = query.Where(x => x.Status.StatusId != 0);
            }
            if (chooseList == "Выполнена")
            {
                query = query.Where(x => x.Status.StatusId == 3);
            }
        }



       
    }
}
