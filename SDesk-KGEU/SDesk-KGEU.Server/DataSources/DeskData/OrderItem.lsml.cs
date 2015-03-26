using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.LightSwitch;
namespace LightSwitchApplication
{
    public partial class OrderItem
    {
        partial void Status_Compute(ref decimal result)
        {
            var taskCnt = this.Task.Count();
            if (taskCnt == 0)
            {
                result = 0;
                return;
            }
            var closedCnt = this.Task.Count(t => t.StatusItem.StatusId == 3);
            result = (decimal) closedCnt / taskCnt;
            // Присвоение результату значения нужного поля
        }
    }
}
