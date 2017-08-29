namespace Flashcards.Models
{
    class CardFrontModel
    {
        private string polishWord;
        private string exampleInPolish;
        public string PolishWord
        {
            get { return polishWord; }
            set { polishWord = value; }
        }
        public string ExampleInPolish
        {
            get { return exampleInPolish; }
            set { exampleInPolish = value; }
        }
    }
}