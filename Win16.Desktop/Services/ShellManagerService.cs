using ManagedShell;
using System;
using System.ComponentModel;
using ManagedShell.Common.Enums;

namespace Win16.Desktop.Services
{
    public class ShellManagerService : IDisposable
    {
        public ShellManager ShellManager { get; }

        public ShellManagerService()
        {
            ShellManager = ConfigureShellManager();

            //Settings.Instance.PropertyChanged += Settings_PropertyChanged;
        }

        private void Settings_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e == null || string.IsNullOrWhiteSpace(e.PropertyName))
                return;

            //switch (e.PropertyName)
            //{
            //    case "TaskbarIconSize":
            //        ShellManager.TasksService.TaskIconSize = (IconSize)Settings.Instance.TaskbarIconSize;
            //        break;
            //}
        }

        private ShellManager ConfigureShellManager()
        {
            ShellConfig config = new ShellConfig()
            {
                EnableTasksService = true,
                AutoStartTasksService = false,
                TaskIconSize = 0,

                EnableTrayService = true,
                AutoStartTrayService = false,
                PinnedNotifyIcons = new string[]{ }
            };

            return new ShellManager(config);
        }

        public void Dispose()
        {
            ShellManager.Dispose();
        }
    }
}
