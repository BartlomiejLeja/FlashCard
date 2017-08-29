using GestureCardFlip;
using Microsoft.WindowsAzure.MobileServices;
using SQLitePCL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flashcards.Azure
{
    class AzureApi
    {
        private AzureServices azureService;
        MainActivity _bundle;
        public AzureApi(MainActivity bundle)
        {
            _bundle = bundle;
            CurrentPlatform.Init();
            Batteries.Init();
            azureService = new AzureServices(_bundle);
        }

        public async Task <List<B1FlashCards>> GetQuestions()
        {
          return await azureService.GetQuestions();
        }
    }
}