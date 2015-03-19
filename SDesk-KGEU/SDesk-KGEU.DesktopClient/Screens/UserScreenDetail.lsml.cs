﻿using System;
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
            // Добавьте сюда свой код.
            Order.AddNew();
            this.OpenModalWindow("AddNewOrderModalWnd");

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
    }
}