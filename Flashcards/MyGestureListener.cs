using System;
using Android.Views;


namespace Flashcards
{
    public class MyGestureListener : GestureDetector.SimpleOnGestureListener
    {
        private MainActivity mmMainActivity;

        public MyGestureListener(MainActivity activity)
        {
            mmMainActivity = activity;
        }

        public override bool OnDoubleTap(MotionEvent e)
        {
            mmMainActivity.FlipCard();
            return true;
        }

        //public override void OnLongPress(MotionEvent e)
        //{
        //    Console.WriteLine("Long Press");
        //}

        //public override bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
        //{
        //    Console.WriteLine("Fling");
        //    return base.OnFling(e1, e2, velocityX, velocityY);
        //}

        //public override bool OnScroll(MotionEvent e1, MotionEvent e2, float distanceX, float distanceY)
        //{
        //    Console.WriteLine("Scroll");
        //    return base.OnScroll(e1, e2, distanceX, distanceY);
        //}
    }
}