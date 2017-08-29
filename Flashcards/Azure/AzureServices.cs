using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using System.IO;
using Android.Widget;
using Flashcards;

namespace GestureCardFlip
{
   public class AzureServices
    {
        MobileServiceClient client { get; set; }

        IMobileServiceSyncTable<B1FlashCards> table;

        private MainActivity _bundle;

        public AzureServices(MainActivity bundle)
        {
            _bundle = bundle;
        }

        public async Task Initialize()
        {
            if (client?.SyncContext?.IsInitialized ?? false)
                return;

            var azureUrl = "http://flashcardsdemo.azurewebsites.net";

            try
            {
                client = new MobileServiceClient(azureUrl);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Problem with Client" + ex);
                Android.Widget.Toast.MakeText(_bundle, "Problem with Client" + ex, ToastLength.Long).Show();
            }
           
          
            //Initialization LocalDatabase for path
            var path = "questions.db";
            path = Path.Combine(MobileServiceClient.DefaultDatabasePath, path);

            //setup our local sqlite store and intialize our table
            var store = new MobileServiceSQLiteStore(path);

            //Define table 
            store.DefineTable<B1FlashCards>();

            //Intalize SyncContext
            await client.SyncContext.InitializeAsync(store, new MobileServiceSyncHandler());

            table = client.GetSyncTable<B1FlashCards>();

        }

        public async Task<List<B1FlashCards>> GetQuestions()
        {
            await Initialize();
            await SyncQuestion();
            return await table.ToListAsync();
        }

        private async Task SyncQuestion()
        {
            try
            {
                await client.SyncContext.PushAsync();
                await table.PullAsync("allQuestions", table.CreateQuery());

            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Unable to sync, using offline capabilites: " + ex);
            }
        }
        public async Task InsertQuestion(List<B1FlashCards> questions)
        {
            await Initialize();

            await Task.WhenAll(questions.Select(q => table.InsertAsync(q)));

            await SyncQuestion();
    }
    }

    
}