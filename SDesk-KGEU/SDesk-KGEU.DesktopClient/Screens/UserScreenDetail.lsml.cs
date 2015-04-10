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
    public partial class UserScreenDetail
    {

       
        partial void AddNewOrder_Execute()
        {
          
            
            Order.AddNew();
          
            this.OpenModalWindow("AddNewOrderModalWnd");
            Order.SelectedItem.UserOwner = DataWorkspace.DeskData.User.Where(p => p.Login == "IlnurV").First();
            Order.SelectedItem.Status = DataWorkspace.DeskData.Status.Where(p => p.StatusId == 1).First();
        }

        partial void SaveNewOrder_Execute()
        {
            // Добавьте сюда свой код.

           DataWorkspace.DeskData.SaveChanges();
            this.CloseModalWindow("AddNewOrderModalWnd");
            

        }

        partial void DeleteOrderAction_Execute()
        {
            // Добавьте сюда свой код.
            Order.SelectedItem.Delete();
            DataWorkspace.DeskData.SaveChanges();

        }

        partial void AddCommentAction_Execute()
        {
            // Добавьте сюда свой код.
            //  Order.SelectedItem.IdOrder;


            Comment.AddNew();
            this.OpenModalWindow("AddCommentWnd");

        }

        partial void SaveCommentAction_Execute()
        {
            // Добавьте сюда свой код.
            DataWorkspace.DeskData.SaveChanges();
            this.CloseModalWindow("AddCommentWnd");

        }

        partial void DeleteCommentAction_Execute()
        {
            // Добавьте сюда свой код.
            Comment.SelectedItem.Delete();
            DataWorkspace.DeskData.SaveChanges();

        }

        partial void CancelComment_Execute()
        {
            DataWorkspace.DeskData.Details.DiscardChanges();
            this.CloseModalWindow("AddCommentWnd");

        }

        partial void CancelNewOrder_Execute()
        {
            DataWorkspace.DeskData.Details.DiscardChanges();
            this.CloseModalWindow("AddNewOrderModalWnd");

        }

        partial void OpenFileDialog_Execute()
        {
            
                Microsoft.LightSwitch.Threading.Dispatchers.Main.BeginInvoke(() =>
                {
                    var ofd = new System.Windows.Controls.OpenFileDialog();
                    ofd.ShowDialog();
                });
            

        }

       
 
    }
}
