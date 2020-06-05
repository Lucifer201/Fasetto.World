using System.Windows;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Fasetto.World
{
    public static class FrameworkElementAnimations
    {
        #region Slide In/Out

        /// <summary>
        /// Slides an element in
        /// </summary>
        /// <param name="element">The element to animate</param>
        /// <param name="direction">The direction of the slide</param>
        /// <param name="seconds">The time the animate will take</param>
        /// <param name="keepMargin">Whether to keep the element at the same width during animation</param>
        /// <param name="size">The animation width/height to animate to. If not specified the elements width is used</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInAsync(this FrameworkElement element, AnimationSlideInDirection direction,bool firstLoad, float seconds = 0.3f, bool keepMargin = true, int size = 0)
        {
            //Create the storyboard
            var sb = new Storyboard();

            //Slide in the correct direction
            switch (direction)
            {
                case AnimationSlideInDirection.Left:
                    //Add slide from left animation
                    sb.AddSlideFromLeft(seconds, size == 0 ? element.ActualWidth : size, keepMargin: keepMargin);
                    break;
                case AnimationSlideInDirection.Right:
                    //Add slide from right animation
                    sb.AddSlideFromRight(seconds, size == 0 ? element.ActualWidth : size, keepMargin: keepMargin);
                    break;
                case AnimationSlideInDirection.Top:
                    //Add slide from top animation
                    sb.AddSlideFromTop(seconds, size == 0 ? element.ActualHeight : size, keepMargin: keepMargin);
                    break;
                case AnimationSlideInDirection.Bottom:
                    //Add slide from bottom animation
                    sb.AddSlideFromBottom(seconds, size == 0 ? element.ActualWidth : size, keepMargin: keepMargin);
                    break;
            }

            //Add fade in animation
            sb.AddFadeIn(seconds);

            //Start animating
            sb.Begin(element);

            //Make page visible only if we are animating or its the first load
            if (seconds != 0||firstLoad)
                element.Visibility = Visibility.Visible;

            //Wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Slides an element out
        /// </summary>
        /// <param name="element">The element to animate</param>
        /// <param name="direction">The direction of the slide (this is for the reverse slide out action, so left would slide out to left)</param>
        /// <param name="seconds">The time the animate will take</param>
        /// <param name="keepMargin">Whether to keep the element at the same width during animation</param>
        /// <param name="size">The animation width/height to animate to. If not specified the elements height is used</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutAsync(this FrameworkElement element,AnimationSlideInDirection direction, float seconds = 0.3f, bool keepMargin = true, int size = 0)
        {
            //Create the storyboard
            var sb = new Storyboard();

            //Slide in the correct direction
            switch (direction)
            {
                case AnimationSlideInDirection.Left:
                    //Add slide from left animation
                    sb.AddSlideToLeft(seconds, size == 0 ? element.ActualWidth : size, keepMargin: keepMargin);
                    break;
                case AnimationSlideInDirection.Right:
                    //Add slide from right animation
                    sb.AddSlideToRight(seconds, size == 0 ? element.ActualWidth : size, keepMargin: keepMargin);
                    break;
                case AnimationSlideInDirection.Top:
                    //Add slide from top animation
                    sb.AddSlideToTop(seconds, size == 0 ? element.ActualHeight : size, keepMargin: keepMargin);
                    break;
                case AnimationSlideInDirection.Bottom:
                    //Add slide from bottom animation
                    sb.AddSlideToBottom(seconds, size == 0 ? element.ActualWidth : size, keepMargin: keepMargin);
                    break;
            }

            //Add fade in from right animation
            sb.AddFadeOut(seconds);

            //Start animating
            sb.Begin(element);

            //Make element visible
            if (seconds != 0)
                element.Visibility = Visibility.Visible;

            //Wait for it to finish
            await Task.Delay((int)(seconds * 1000));

            //Make element hidden when finishing animation
            if (element.Opacity == 0)
                element.Visibility = Visibility.Hidden;
        }

        #endregion

        #region Fade In/Out

        /// <summary>
        /// Fades in an element
        /// </summary>
        /// <param name="element">The page to animate</param>
        /// <param name="seconds">The time the animate will take</param>
        /// <returns></returns>
        public static async Task FadeInAsync(this FrameworkElement element,bool firstLoad, float seconds = 0.3f)
        {
            //Create the storyboard
            var sb = new Storyboard();

            //Add fade in from bottom animation
            sb.AddFadeIn(seconds);

            //Start animating
            sb.Begin(element);

            //Make element visible only if we are animating or it's the first load
            if (seconds != 0||firstLoad)
                element.Visibility = Visibility.Visible;

            //Wait for it to finish
            await Task.Delay((int)(seconds * 1000));

        }


        /// <summary>
        /// Fades out an element
        /// </summary>
        /// <param name="element">The page to animate</param>
        /// <param name="seconds">The time the animate will take</param>
        /// <returns></returns>
        public static async Task FadeOutAsync(this FrameworkElement element, float seconds = 0.3f)
        {
            //Create the storyboard
            var sb = new Storyboard();

            //Add fade in from right animation
            sb.AddFadeOut(seconds);

            //Start animating
            sb.Begin(element);

            //Make element visible
            if (seconds != 0)
                element.Visibility = Visibility.Visible;

            //Wait for it to finish
            await Task.Delay((int)(seconds * 1000));

            //Fully hide when the animaion is finished
            element.Visibility = Visibility.Collapsed;
        }


        #endregion

        #region Marquee

        /// <summary>
        /// Animate a marquee style element 
        /// The struct should be 
        /// </summary>
        /// <param name="element">The element to animate</param>
        /// <param name="seconds">The time to animate</param>
        public static void MarqueeAsync(this FrameworkElement element, float seconds = 3f)
        {
            //Create the storyboard
            var sb = new Storyboard();

            //Run until element is unloaded
            var unloaded = false;

            //Monitor for the element unloading
            element.Unloaded += (s, e) => unloaded = true;

            //Run a loop of the caller thread
            Task.Run(async () =>
            {
                //While the element is still available, recheck the size
                //after every loop in case the container was resized
                while (element != null && unloaded)
                {
                    //Create width variables
                    var width = 0d;
                    var innerWidth = 0d;

                    try
                    {
                        //Check if element is still loaded
                        if (element == null || unloaded)
                            break;

                        //Try and get current width
                        width = element.ActualWidth;
                        innerWidth = ((element as Border).Child as FrameworkElement).ActualWidth;
                    }
                    catch
                    {
                        //Any issues the stop animating (persume element destroyed)
                        break;
                    }

                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        //Add marquee animation
                        sb.AddMarquee(seconds, width, innerWidth);

                        //Start animating
                        sb.Begin(element);

                        //Make element visible
                        element.Visibility = Visibility.Visible;
                    });

                    //Wait for it to finish animating
                    await Task.Delay((int)seconds * 1000);

                    //If this is from first load or zero seconds of animation, do not repeat
                    if (seconds == 0)
                        break;

                }
            });

        }

        #endregion

    }
}
