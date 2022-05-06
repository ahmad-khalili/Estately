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
        Listing emptyListing = new Listing();
        List<Listing> emptyList = new List<Listing> ();

        public FirebaseDB()
        {
            emptyList.Add(emptyListing);
            bucket = new FirebaseStorage("estately-9a428.appspot.com",
                new FirebaseStorageOptions{
                ThrowOnCancel = true
            });
            client = new FirebaseClient("https://estately-9a428-default-rtdb.europe-west1.firebasedatabase.app/");
        }
        
        public async Task AddListing(Listing listing)
        {
            try
            {
                await client.Child("Listings").PostAsync(listing);
            }
            catch (FirebaseException ex)
            {
                await App.Current.MainPage.DisplayAlert("Error In Adding The Listing", ex.Message, "Ok");
            }
        }

        public async Task UpdateListing(Listing listing)
        {
            try
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
            catch (FirebaseException ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", $"Listing Not Found, {ex.Message}", "Ok");
            }
        }

        public async Task DeleteListing(Listing listing)
        {
            try
            {
                var toDeleteListing = (await client
                    .Child("Listings")
                    .OnceAsync<Listing>()).FirstOrDefault
                    (a => a.Object.Title == listing.Title && a.Object.Description == listing.Description);
                await client.Child("Listings").Child(toDeleteListing.Key).DeleteAsync();
            }
            catch (FirebaseException ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", $"Listing Not Found, {ex.Message}", "Ok");
            }
        }

        public async Task<List<Listing>> GetListings()
        {
            try
            {
                var listings = (await client
                    .Child("Listings")
                    .OnceAsync<Listing>()).Select(listing => new Listing
                    {
                        Title = listing.Object.Title,
                        Description = listing.Object.Description,
                        Price = listing.Object.Price,
                        Size = listing.Object.Size,
                        Location = listing.Object.Location,
                        Type = listing.Object.Type,
                        Featured = listing.Object.Featured,
                        Feature1 = listing.Object.Feature1,
                        Feature2 = listing.Object.Feature2,
                        Feature3 = listing.Object.Feature3,
                        Feature4 = listing.Object.Feature4,
                        Image = listing.Object.Image
                    }).ToList();

                return listings;
            }
            catch (FirebaseException ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                return emptyList;
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                return emptyList;
            }
        }
    }
}
