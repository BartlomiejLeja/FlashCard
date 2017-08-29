using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Flashcards.EventArg;

namespace Flashcards.Fragments
{
    public class CardFrontFragment : Fragment
    {
        private TextView polishWord;
        private TextView exampleInPolish;
        private MainActivity mMainActivity;
        string polishWordString;
        string exampleInPolishString;
        public CardFrontFragment(MainActivity mA, string polishWordd, string exampleInPolishh)
        {
            mMainActivity = mA;
            polishWordString = polishWordd;
            exampleInPolishString = exampleInPolishh;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            mMainActivity.CardFrontEventHandler += MMainActivity_CardFrontEventHandler;
            View frontCard = inflater.Inflate(Resource.Layout.card_front, container, false);
            frontCard.Touch += frontCard_Touch;
            polishWord = frontCard.FindViewById<TextView>(Resource.Id.polishWord);
            exampleInPolish = frontCard.FindViewById<TextView>(Resource.Id.exampleInPolish);
            polishWord.Text = polishWordString;
            exampleInPolish.Text = exampleInPolishString;
            return frontCard;
        }

        private void MMainActivity_CardFrontEventHandler(object sender, CardFrontEventArgs e)
        {
            polishWord.Text = e.CardFrontModel.PolishWord;
            exampleInPolish.Text = e.CardFrontModel.ExampleInPolish;

        }
        void frontCard_Touch(object sender, View.TouchEventArgs e)
        {
            MainActivity parentActivity = Activity as MainActivity;
            parentActivity.mGestureDetector.OnTouchEvent(e.Event);
        }
    }
}