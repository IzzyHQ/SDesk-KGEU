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

        partial void ReplyToTask_Execute()
        {
           Comment.AddNew();
          

            this.OpenModalWindow("ReplyToTaskWnd");
        }

        partial void ReplyToTask_CanExecute(ref bool result)
        {
            result = Task.SelectedItem != null;
        }

        partial void OkReply_Execute()
        {
 

            DataWorkspace.DeskData.SaveChanges();

            this.CloseModalWindow("ReplyToTaskWnd");
        }

        partial void CancelReply_Execute()
        {
            DataWorkspace.DeskData.Details.DiscardChanges();
            this.CloseModalWindow("ReplyToTaskWnd");

        }




    }
}
