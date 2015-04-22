using System;
using System.Linq;
using System.IO;
using System.IO.IsolatedStorage;
using System.Collections.Generic;
using Microsoft.LightSwitch;
using Microsoft.LightSwitch.Framework.Client;
using Microsoft.LightSwitch.Presentation;
using Microsoft.LightSwitch.Presentation.Extensions;
using System.Windows.Controls;
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
            DataWorkspace.DeskData.SaveChanges();
            this.CloseModalWindow("AddNewOrderModalWnd");
        }

        partial void DeleteOrderAction_Execute()
        {
            Order.SelectedItem.Delete();
            DataWorkspace.DeskData.SaveChanges();
        }

        partial void AddCommentAction_Execute()
        {
            Comment.AddNew();
            this.OpenModalWindow("AddCommentWnd");
        }

        partial void SaveCommentAction_Execute()
        {
            DataWorkspace.DeskData.SaveChanges();
            this.CloseModalWindow("AddCommentWnd");

        }

        partial void DeleteCommentAction_Execute()
        {
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
                if (ofd.ShowDialog() == true)
                {
                    using (FileStream fs = ofd.File.OpenRead())
                    {
                        byte[] buf = new byte[fs.Length];
                        fs.Read(buf, 0, buf.Length);

                        var v = Order.SelectedItem.FileItem.AddNew();
                        v.FileName = ofd.File.Name;
                        v.Image = buf;
                    }
                }
            });
        }

        partial void SaveFile_Execute()
        {
            Microsoft.LightSwitch.Threading.Dispatchers.Main.BeginInvoke(() =>
            {
                SaveFileDialog sfd = new SaveFileDialog();

                sfd.Filter = "All files (*.*)|*.*";
                sfd.DefaultFileName = FileItem.SelectedItem.FileName;
                sfd.FilterIndex = 2;
                if (sfd.ShowDialog() == true)
                {
                    string path = FileItem.SelectedItem.FileName;
                    using (FileStream fs = new FileStream(sfd.SafeFileName + path, FileMode.Create))
                    {
                        byte[] buf = new byte[fs.Length];
                        buf = FileItem.SelectedItem.Image;
                        fs.Write(buf, 0, buf.Length);
                    }
                }
            });
        }

        partial void EditProfile_Execute()
        {

            

        }
    }
}
