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
    public partial class DispatcherScreenDetail
    {

        partial void TaskAdd_Execute()
        {
            Task.AddNew();
            Task.SelectedItem.StatusItem = DataWorkspace.DeskData.Status.Where(p => p.StatusId == 2).First();
            
           Task.SelectedItem.Description = Order.SelectedItem.Description;         
           this.OpenModalWindow("AddNewTaskModalWnd");
            
        }

      
        partial void SaveNewTask_Execute()
        {
            DataWorkspace.DeskData.SaveChanges();
            this.CloseModalWindow("AddNewTaskModalWnd");
        }

        partial void CancelNewTask_Execute()
        {
            
            DataWorkspace.DeskData.Details.DiscardChanges();
            this.CloseModalWindow("AddNewTaskModalWnd");
        }      

       
    }
}
