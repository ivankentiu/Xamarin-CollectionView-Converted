using System;
using UIKit;
using Foundation;
using CoreGraphics;

namespace collectionview
{
    public class CollectionViewCell : UICollectionViewCell
    {
        public UILabel TitleLabel;
        public UIImageView SelectionImage;
        public static NSString CellID = new NSString("collectionViewCell");

        private bool _isEditing;
        public bool IsEditing
        {
            get { return _isEditing; }
            set
            {
                _isEditing = value;
                SelectionImage.Hidden = !_isEditing;
            }
        }

        public override bool Selected
        {
            get { return base.Selected; }
            set
            {
                base.Selected = value;

                if (IsEditing)
                {
                    SelectionImage.Image = Selected ? new UIImage("Checked") : new UIImage("Unchecked");
                }
            }
        }

        [Export("initWithFrame:")]
        public CollectionViewCell(CGRect frame) : base(frame)
        {
            BackgroundColor = new UIColor(red: 0f / 255f, green: 153f / 255f, blue: 76f / 255f, alpha: 1f);

            TitleLabel = new UILabel()
            {
                TranslatesAutoresizingMaskIntoConstraints = false
            };

            SelectionImage = new UIImageView()
            {
                Image = UIImage.FromBundle("Checked"),
                ContentMode = UIViewContentMode.ScaleAspectFit,
                TranslatesAutoresizingMaskIntoConstraints = false,
                BackgroundColor = UIColor.Red,
            };


            AddSubviews(new UIView[] { TitleLabel, SelectionImage });
            SetupLayout();
        }

        private void SetupLayout()
        {
            TitleLabel.CenterXAnchor.ConstraintEqualTo(CenterXAnchor).Active = true;
            TitleLabel.CenterYAnchor.ConstraintEqualTo(CenterYAnchor).Active = true;

            SelectionImage.RightAnchor.ConstraintEqualTo(RightAnchor, 8).Active = true;
            SelectionImage.BottomAnchor.ConstraintEqualTo(BottomAnchor, 8).Active = true;
            SelectionImage.WidthAnchor.ConstraintEqualTo(22);
            SelectionImage.HeightAnchor.ConstraintEqualTo(22);

        }

    }
}
