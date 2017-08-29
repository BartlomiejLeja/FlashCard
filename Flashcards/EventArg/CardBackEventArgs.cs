using System;
using Flashcards.Models;

namespace Flashcards.EventArg
{
    class CardBackEventArgs : EventArgs
    {
        public CardBackModel CardBackModel { get; set; }
        public CardBackEventArgs( string rusianWord, string exampleInRussian) : base()
        {
            CardBackModel = new CardBackModel();
            CardBackModel.RussianWord = rusianWord;
            CardBackModel.ExampleInRussian = exampleInRussian;
        }
    }
}

