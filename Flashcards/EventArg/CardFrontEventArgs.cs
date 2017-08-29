using System;
using Flashcards.Models;

namespace Flashcards.EventArg
{
     class CardFrontEventArgs : EventArgs
    {
       public CardFrontModel CardFrontModel { get; set; }

        public CardFrontEventArgs(string polishWord,string exampleInPolish) : base()
        {
            CardFrontModel = new CardFrontModel();
            CardFrontModel.PolishWord= polishWord;
            CardFrontModel.ExampleInPolish = exampleInPolish;
        }
    }
}