using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Estately.Models;
using Firebase.Database.Query;
using System.Threading.Tasks;
using System.Linq;

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
        
        public async Task AddListing(string title, string description)
        {
            Listing listing = new Listing() { Title = title, Description = description };
            await client.Child("Listings").PostAsync(listing);
        }

        public async Task UpdateListing(string title, string description)
        {
            var toUpdateListing = (await client
                .Child("Listings")
                .OnceAsync<Listing>()).FirstOrDefault
                (a => a.Object.Title == title && a.Object.Description == description);

            Listing listing = new Listing() { Title = title, Description = description };
            await client
                .Child("Listings")
                .Child(toUpdateListing.Key)
                .PutAsync(listing);
        }

        public async Task DeleteListing(string title, string description)
        {
            var toDeleteListing = (await client
                .Child("Listings")
                .OnceAsync<Listing>()).FirstOrDefault
                (a => a.Object.Title == title && a.Object.Description == description);
            await client.Child("Listings").Child(toDeleteListing.Key).DeleteAsync();
        }
    }
}
