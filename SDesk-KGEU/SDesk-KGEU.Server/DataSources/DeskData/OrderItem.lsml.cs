using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.LightSwitch;
namespace LightSwitchApplication
{
    public partial class OrderItem
    {
       

        partial void Status_Compute(ref string result)
        {
            var taskCnt = this.Task.Count();
            if (taskCnt == 0)
            {
                result = "Новая";
                return;
            }
            if (this.Task.Any(p => p.StatusItem == null))
            {
                result = "Новая";
            }
            else if (this.Task.Any(p => p.StatusItem.StatusId == 2 ))
            {
                result = "В работе" ;
                return;
            }
            
            else if (this.Task.All(p=>p.StatusItem.StatusId==3))
            {
                result = "Выполнена";

                return;   
            }
          
            
            // Присвоение результату значения нужного поля
        }

        partial void FullName_Compute(ref string result)
        {
            result = string.Format("{0} {1}", UserOwner.LName , UserOwner.FName);
        }

        partial void FullName1_Compute(ref string result)
        {
            result = string.Format("{0} {1}", DUser.LName, DUser.FName);

        }

    }
}
