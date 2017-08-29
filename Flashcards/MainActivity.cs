using Android.App;
using Android.Widget;
using Android.OS;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using System.Collections.Generic;
using Android.Views;
using System;
using Flashcards.Azure;
using GestureCardFlip;
using Flashcards.EventArg;
using Flashcards.Fragments;
using System.Linq;
using Android.Content.PM;

namespace Flashcards
{
    [Activity(Label = "FlashCards", MainLauncher = true, Theme = "@style/MyTheme", Icon = "@drawable/icon", ScreenOrientation = ScreenOrientation.Locked)]
    public class MainActivity : ActionBarActivity
    {
        private SupportToolbar mToolbar;
        private MyActionBarDrawerToggle mDrawerToggle;
        private DrawerLayout mDrawerLayout;
        private ListView mLeftDrawer;
        private Button nextFlashCardButton;
        private AzureApi azureApi;
        private static readonly string[] Sections = new[] { "Poziom A1","Poziom A2","Poziom B1","Poziom B2","Przekleństwa"};
        private List<B1FlashCards> allQuestions;
        private List<B1FlashCards> questions;
        private bool mShowingBack;
        private int countQuestions = 0;
        internal event EventHandler<CardFrontEventArgs> CardFrontEventHandler;
        internal event EventHandler<CardBackEventArgs> CardBackEventHandler;
        public GestureDetector mGestureDetector;
        private Random random;
        protected async override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.waitingLayout);
            mGestureDetector = new GestureDetector(this, new MyGestureListener(this));
            azureApi = new AzureApi(this);
            allQuestions = await azureApi.GetQuestions();
            questions = allQuestions;
            SetContentView(Resource.Layout.Main);

            mToolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            nextFlashCardButton = FindViewById<Button>(Resource.Id.NextFlashCardButton);
            nextFlashCardButton.Click += NextFlashCardButton_Click;
            mLeftDrawer = FindViewById<ListView>(Resource.Id.left_drawer);

            mLeftDrawer.Adapter = new ArrayAdapter<string>(this, Resource.Layout.nav_menu, Sections);
            mLeftDrawer.ItemClick += (sender, args) => ListItemClicked(args.Position);
            SetSupportActionBar(mToolbar);

            random = new Random();

            if (bundle == null)
            {
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                countQuestions = random.Next(0, questions.Count);
                transaction.Add(Resource.Id.container, new CardFrontFragment(this, questions[countQuestions].PolishWord, questions[countQuestions].ExampleInPolish));
                transaction.Commit();
            }

            mDrawerToggle = new MyActionBarDrawerToggle(
                this,                           //Host Activity
                mDrawerLayout,                  //DrawerLayout
                Resource.String.openDrawer,     //Opened Message
                Resource.String.closeDrawer     //Closed Message
            );
            mDrawerLayout.SetDrawerListener(mDrawerToggle);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            mDrawerToggle.SyncState();
        }

        private void NextFlashCardButton_Click(object sender, EventArgs e)
        {
            this.NextFlashCard();
        }

        private void NextFlashCard()
        {
            countQuestions = random.Next(0, questions.Count);

            CardFrontEventHandler.Invoke(this, new CardFrontEventArgs(questions[countQuestions].PolishWord, questions[countQuestions].ExampleInPolish));
            if (CardBackEventHandler != null)
                CardBackEventHandler.Invoke(this, new CardBackEventArgs(questions[countQuestions].RussianWord, questions[countQuestions].ExampleInRussian));
        }

        private void ListItemClicked(int position)
        {
            switch(position)
            {
                case 0:
                    questions = allQuestions.Where(x=>x.Level==1).ToList();
                    this.NextFlashCard();
                    break;
                case 1:
                    questions =allQuestions.Where(x => x.Level == 2).ToList();
                    this.NextFlashCard();
                    break;
                case 2:
                    questions =allQuestions.Where(x => x.Level == 3).ToList();
                    this.NextFlashCard();
                    break;
                case 3:
                    questions =allQuestions.Where(x => x.Level == 4).ToList();
                    this.NextFlashCard();
                    break;
                case 4:
                    questions =allQuestions.Where(x => x.Level == 5).ToList();
                    this.NextFlashCard();
                    break;
            }
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            mDrawerToggle.OnOptionsItemSelected(item);
            return base.OnOptionsItemSelected(item);
        }
    public void FlipCard()
        {
            if (mShowingBack)
            {
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                transaction.SetCustomAnimations(Resource.Animation.card_flip_left_in, Resource.Animation.card_flip_left_out,
                                              Resource.Animation.card_flip_right_in, Resource.Animation.card_flip_right_out);

                transaction.Replace(Resource.Id.container, new CardFrontFragment(this, questions[countQuestions].PolishWord, questions[countQuestions].ExampleInPolish));

                transaction.AddToBackStack(null);

                transaction.Commit();
                mShowingBack = false;
            }
            else
            {
                //Otherwise the front is showing therefore flip to back
                FragmentTransaction transaction = FragmentManager.BeginTransaction();

                //Set the custom animations we made to animate with this transaction
                transaction.SetCustomAnimations(Resource.Animation.card_flip_right_in, Resource.Animation.card_flip_right_out,
                                                Resource.Animation.card_flip_left_in, Resource.Animation.card_flip_left_out);

                transaction.Replace(Resource.Id.container, new CardBackFragment(this, questions[countQuestions].RussianWord, questions[countQuestions].ExampleInRussian));

                transaction.AddToBackStack(null);

                transaction.Commit();

                mShowingBack = true;
            }
        }
    }
}

 


