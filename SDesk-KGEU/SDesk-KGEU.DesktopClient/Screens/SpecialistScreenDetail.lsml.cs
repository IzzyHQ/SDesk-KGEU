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
    public partial class SpecialistScreenDetail
    {

        partial void SaveFile2_Execute()
        {
            {
                Microsoft.LightSwitch.Threading.Dispatchers.Main.BeginInvoke(() =>
                {
                    SaveFileDialog sfd = new SaveFileDialog();

                    sfd.Filter = "All files (*.*)|*.*";
                    sfd.DefaultFileName = FileItem1.SelectedItem.FileName;
                    sfd.FilterIndex = 2;
                    if (sfd.ShowDialog() == true)
                    {
                        using (FileStream fs = new FileStream(sfd.SafeFileName, FileMode.Create))
                        {
                            byte[] buf = new byte[fs.Length];
                            buf = FileItem1.SelectedItem.Image;
                            fs.Write(buf, 0, buf.Length);
                        }
                    }
                });

            }
        }

        partial void AddNewComment_Execute()
        {
                Comment.AddNew();
                this.OpenModalWindow("AddNewCommentModalWnd");
        }

        partial void SaveNewComment1_Execute()
        {
            DataWorkspace.DeskData.SaveChanges();
            this.CloseModalWindow("AddNewCommentModalWnd");
        }

        partial void CancelComment_Execute()
        {
            DataWorkspace.DeskData.Details.DiscardChanges();
            this.CloseModalWindow("AddNewCommentModalWnd");
        }
    }
}
