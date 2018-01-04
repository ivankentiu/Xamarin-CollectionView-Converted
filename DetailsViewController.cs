using System;

using UIKit;

namespace collectionview
{
    public class DetailsViewController : UIViewController
    {
        public String Selection { get; set; }

        private readonly UILabel detailsLabel;

        public DetailsViewController()
        {
            detailsLabel = new UILabel()
            {
                Text = "woot",
                TextColor = UIColor.Black,
                TranslatesAutoresizingMaskIntoConstraints = false                    
            };

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;
            View.AddSubview(detailsLabel);
            SetupLayout();
            detailsLabel.Text = Selection;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        private void SetupLayout()
        {
            detailsLabel.CenterXAnchor.ConstraintEqualTo(View.CenterXAnchor).Active = true;
            detailsLabel.CenterYAnchor.ConstraintEqualTo(View.CenterYAnchor).Active = true;
        }


    }
}

