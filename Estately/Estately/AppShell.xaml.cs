using Estately.ViewModels;
using Estately.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Estately
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MarketplacePage), typeof(MarketplacePage));
            Routing.RegisterRoute(nameof(AgentFinderPage), typeof(AgentFinderPage));
            Routing.RegisterRoute(nameof(MessagesPage), typeof(MessagesPage));
            Routing.RegisterRoute(nameof(NotificationsPage), typeof(NotificationsPage));
            Routing.RegisterRoute(nameof(MoreTabsPage), typeof(MoreTabsPage));
        }

    }
}
