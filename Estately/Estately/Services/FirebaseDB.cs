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

        public async Task<List<Listing>> FilterListing(float startPrice, float endPrice, float startSize, float endSize, string location)
        {
            var toFilter = (await client
                .Child("Listings")
                .OnceAsync<Listing>()).Select(item => new Listing
                {
                    Title = item.Object.Title,
                    Description = item.Object.Description,
                    Price = item.Object.Price,
                    Size = item.Object.Size,
                    Location = item.Object.Location
                }).ToList();
            List<Listing> items = new List<Listing>();
            foreach (var item in toFilter)
            {
                if (location == null)
                {
                    if (item.Price > startPrice && item.Price < endPrice && item.Size > startSize && item.Size < endSize)
                    {
                        items.Add(item);
                    }
                }
                else
                {

                    if (item.Price > startPrice && item.Price < endPrice && item.Size > startSize && item.Size < endSize && item.Location.Equals(location))
                    {
                        items.Add(item);
                    }
                }
            }
            return items;
        }
        
        public async Task<List<Listing>> GetFeaturedProperties(string type)
        {
            var button = (await client
                .Child("Listings")
                .OnceAsync<Listing>()).Select(item => new Listing()
                {
                    Title = item.Object.Title,
                    Price = item.Object.Price,
                    Type = item.Object.Type,
                    Featured = item.Object.Featured,
                    Location = item.Object.Location
                });
            List<Listing> items = new List<Listing>();
            foreach (var item in button)
            {
                if(type == null)
                {
                    if (item.Featured.Equals("Yes"))
                    {
                        items.Add(item);
                    }
                }
                if(item.Type.Equals(type) && item.Featured.Equals("Yes"))
                {
                    items.Add(item);
                }
            }
            return items;
        }

        public async Task<List<Listing>> GetNearbyProperties(string type)
        {
            var button = (await client
                .Child("Listings")
                .OnceAsync<Listing>()).Select(item => new Listing()
                {
                    Title = item.Object.Title,
                    Price = item.Object.Price,
                    Type = item.Object.Type,
                    Featured = item.Object.Featured,
                    Location = item.Object.Location
                });
            List<Listing> items = new List<Listing>();
            foreach (var item in button)
            {
                if (type == null)
                {
                    if (item.Featured.Equals("No"))
                    {
                        items.Add(item);
                    }
                }
                if (item.Type.Equals(type) && item.Featured.Equals("No"))
                {
                    items.Add(item);
                }
            }
            return items;
        }
    }
}
