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
            Routing.RegisterRoute(nameof(AgentFinderPage), typeof(AgentFinderPage));
            Routing.RegisterRoute(nameof(ContractPage), typeof(ContractPage));
            Routing.RegisterRoute(nameof(Listingage), typeof(ListingPage));
            Routing.RegisterRoute(nameof(MarketPlacePage), typeof(MarketPlacePage));
            Routing.RegisterRoute(nameof(MessagesPage), typeof(MessagesPage));
            Routing.RegisterRoute(nameof(MoreTabsPage), typeof(MoreTabsPage));
            Routing.RegisterRoute(nameof(MortgagePage), typeof(MortgagePage));
            Routing.RegisterRoute(nameof(NewListingPage), typeof(NewListingPage));
            Routing.RegisterRoute(nameof(NotificationsPage), typeof(NotificationsPage));
            Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
            Routing.RegisterRoute(nameof(RennovationPage), typeof(RennovationPage));

        }

    }
}
