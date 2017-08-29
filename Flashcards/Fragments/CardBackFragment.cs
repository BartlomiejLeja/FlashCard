using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Flashcards.EventArg;

namespace Flashcards.Fragments
{
    public class CardBackFragment : Fragment
    {
        private TextView russianWord;
        private TextView exampleInRussian;
        private TextView backLevel;
        private MainActivity mMainActivity;
        private string russianWordString;
        private string exampleInRussianString;
    
        public CardBackFragment(MainActivity mA, string russianWordd, string exampleInRussiann)
        {
            mMainActivity = mA;
            russianWordString = russianWordd;
            exampleInRussianString = exampleInRussiann;
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View backCard = inflater.Inflate(Resource.Layout.card_back, container, false);
            backCard.Touch += backCard_Touch;
            russianWord = backCard.FindViewById<TextView>(Resource.Id.russianWordTextView);
            exampleInRussian = backCard.FindViewById<TextView>(Resource.Id.exampleInRussian);
            mMainActivity.CardBackEventHandler += MMainActivity_CardBackEventHandler;
            russianWord.Text = russianWordString;
            exampleInRussian.Text = exampleInRussianString;
            return backCard;
        }

        private void MMainActivity_CardBackEventHandler(object sender, CardBackEventArgs e)
        {
            russianWord.Text = e.CardBackModel.RussianWord;
            exampleInRussian.Text = e.CardBackModel.ExampleInRussian;
        }

        void backCard_Touch(object sender, View.TouchEventArgs e)
        {
            MainActivity parentActivity = Activity as MainActivity;
            parentActivity.mGestureDetector.OnTouchEvent(e.Event);
        }
    }
}