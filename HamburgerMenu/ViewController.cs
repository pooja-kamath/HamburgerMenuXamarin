using System;

using UIKit;

namespace HamburgerMenu
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        bool _hamburgerMenuIsVisible = false;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //Add Button Action
            MenuButton.Clicked += MenuClickedAction;
        }

        private void MenuClickedAction(object sender, EventArgs e)
        {
            if (!_hamburgerMenuIsVisible)
            {
                //Unhide the menu
                leadingConstraint.Constant = 150;
                trailingConstraint.Constant = -(150);
                _hamburgerMenuIsVisible = true;
            }
            else
            {
                //Hide the menu
                leadingConstraint.Constant = 0;
                trailingConstraint.Constant = 0;
                _hamburgerMenuIsVisible = false;
            }

            //Animate the hiding and unhiding
            UIView.Animate(0.3, 0, UIViewAnimationOptions.CurveEaseIn, AnimationAction, AnimationCompletionHandler);
        }

        private void AnimationAction()
        {
            this.View.LayoutIfNeeded();
        }

        private void AnimationCompletionHandler()
        {
            //Completion of Animation
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
