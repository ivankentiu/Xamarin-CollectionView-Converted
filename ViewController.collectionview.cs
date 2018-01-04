using System;
using Foundation;
using CoreGraphics;
using UIKit;

namespace collectionview
{
    partial class ViewController
    {
        [Export("collectionView:layout:sizeForItemAtIndexPath:")]
        public virtual CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, Foundation.NSIndexPath indexPath)
        {
            var width = (collectionView.Frame.Size.Width - 20) / 3;
            return new CGSize(width, width);
        }

        public override bool ShouldHighlightItem(UICollectionView collectionView, NSIndexPath indexPath)
        {
            return true;
        }

        public override void ItemHighlighted(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = collectionView.CellForItem(indexPath) as CollectionViewCell;
            cell.BackgroundColor = UIColor.Red;
        }

        public override void ItemUnhighlighted(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = collectionView.CellForItem(indexPath) as CollectionViewCell;
            cell.BackgroundColor = new UIColor(red: 0f / 255f, green: 153f / 255f, blue: 76f / 255f, alpha: 1f);
        }

        public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var detailsViewController = new DetailsViewController();
            detailsViewController.Selection = collectionData[(int)indexPath.Item];
            NavigationController.PushViewController(detailsViewController, true);
        }

    }
}
