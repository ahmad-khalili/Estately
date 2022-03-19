using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Estately.Models;
using Firebase.Database.Query;
using System.Threading.Tasks;

namespace Estately.Services
{
    public class FirebaseDB
    {
        FirebaseClient client;

        public FirebaseDB()
        {
            client = new FirebaseClient("https://estately-9a428-default-rtdb.europe-west1.firebasedatabase.app/");
        }
        
        public ObservableCollection<Listing> getListing()
        {
            var listingData = client
                .Child("Listings")
                .AsObservable<Listing>()
                .AsObservableCollection();
            return listingData;
        }
    }
}
