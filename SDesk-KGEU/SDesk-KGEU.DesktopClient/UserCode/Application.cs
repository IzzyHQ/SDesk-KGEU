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
    public partial class Application
    {
        partial void DispatcherScreenDetail_Run(ref bool handled)
        {
            // Set handled to 'true' to stop further processing.

        }

        partial void DispatcherScreenDetail_CanRun(ref bool result)
        {
            result = User.HasPermission(Permissions.CanRunDispatcherScr);
        }

        partial void SpecialistScreenDetail_CanRun(ref bool result)
        {
            result = User.HasPermission(Permissions.CanRunSpecialistScr);

        }

        partial void UserListDetail_CanRun(ref bool result)
        {
            result = User.HasPermission(Permissions.CanRunUserScr);

        }

        partial void UserScreenDetail_CanRun(ref bool result)
        {
            // Set result to the desired field value

        }
    }
}
