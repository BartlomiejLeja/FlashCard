namespace Flashcards.Models
{
    class CardBackModel
    {
        private string russianWord;
        private string exampleInRussian;
    
        public string RussianWord
        {
            get { return russianWord; }
            set { russianWord = value; }
        }
        public string ExampleInRussian
        {
            get { return exampleInRussian; }
            set { exampleInRussian = value; }
        }
    }
}