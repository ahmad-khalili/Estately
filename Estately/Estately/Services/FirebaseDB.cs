using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Estately.Models;
using Firebase.Database.Query;
using System.Threading.Tasks;
using System.Linq;
using System.Reflection;
using Firebase.Storage;
using System.Net;

namespace Estately.Services
{
    public class FirebaseDB
    {
        readonly FirebaseClient client;
        readonly FirebaseStorage bucket;
        WebClient webClient;

        public FirebaseDB()
        {
            webClient = new WebClient();
            bucket = new FirebaseStorage("estately-9a428.appspot.com",
                new FirebaseStorageOptions{
                ThrowOnCancel = true
            });
            client = new FirebaseClient("https://estately-9a428-default-rtdb.europe-west1.firebasedatabase.app/");
        }
        
        public async Task AddListing(Listing listing)
        {
            await client.Child("Listings").PostAsync(listing);
        }

        public async Task UpdateListing(Listing listing)
        {
            var toUpdateListing = (await client
                .Child("Listings")
                .OnceAsync<Listing>()).FirstOrDefault
                (a => a.Object.Title == listing.Title && a.Object.Description == listing.Description);

            Listing updatedListing = listing;
            await client
                .Child("Listings")
                .Child(toUpdateListing.Key)
                .PutAsync(updatedListing);
        }

        public async Task DeleteListing(Listing listing)
        {
            var toDeleteListing = (await client
                .Child("Listings")
                .OnceAsync<Listing>()).FirstOrDefault
                (a => a.Object.Title == listing.Title && a.Object.Description == listing.Description);
            await client.Child("Listings").Child(toDeleteListing.Key).DeleteAsync();
        }

        public async Task<List<Listing>> GetListings() { 
            var listings = (await client
                .Child("Listings")
                .OnceAsync<Listing>()).Select(listing => new Listing {
                    Title = listing.Object.Title,
                    Description = listing.Object.Description,
                    Price = listing.Object.Price,
                    Size = listing.Object.Size,
                    Location = listing.Object.Location,
                    Type = listing.Object.Type,
                    Featured = listing.Object.Featured,
                    Image = listing.Object.Image
                }).ToList();

            return listings;
        }

        public async Task<List<Listing>> GetListing(string title)
        {
            var listingToGet = (await client
                .Child("Listings")
                .OnceAsync<Listing>()).Select(item => new Listing()
                {
                    Title = item.Object.Title,
                    Price = item.Object.Price,
                    Type = item.Object.Type,
                    Location = item.Object.Location,
                    Description = item.Object.Description,
                    Size = item.Object.Size,
                    Feature1 = item.Object.Feature1,
                    Feature2 = item.Object.Feature2,
                    Feature3 = item.Object.Feature3,
                    Feature4 = item.Object.Feature4, 
                });
            List<Listing> items = new List<Listing>();

            foreach(var item in listingToGet)
            {
                    if (item.Title.Equals(title))
                    {
                        items.Add(item);
                    }
                }
                return items;
        }
    }
}
