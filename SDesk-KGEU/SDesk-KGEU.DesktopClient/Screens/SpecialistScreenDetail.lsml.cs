using System;
using System.Linq;
using System.IO;
using System.IO.IsolatedStorage;
using System.Collections.Generic;
using Microsoft.LightSwitch;
using Microsoft.LightSwitch.Framework.Client;
using Microsoft.LightSwitch.Presentation;
using Microsoft.LightSwitch.Presentation.Extensions;
namespace LightSwitchApplication
{
    public partial class SpecialistScreenDetail
    {



        partial void CloseTask_Execute()
        {
            Task.SelectedItem.StatusItem = DataWorkspace.DeskData.Status.Where(p => p.StatusId == 3).FirstOrDefault();
            Task.SelectedItem.DateClose = DateTime.Now;
            DataWorkspace.DeskData.SaveChanges();
        }
    }
}
