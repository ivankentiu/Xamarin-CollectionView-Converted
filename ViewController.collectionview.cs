using System;
using Foundation;
using CoreGraphics;
using UIKit;

namespace collectionview
{
    partial class ViewController
    {
        // Layout Section

        [Export("collectionView:layout:sizeForItemAtIndexPath:")]
        public virtual CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, Foundation.NSIndexPath indexPath)
        {
            var width = (collectionView.Frame.Size.Width - 20) / 3;
            return new CGSize(width, width);
        }

        // Delegate Section

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
            if (!Editing)
            {
                var detailsViewController = new DetailsViewController();
                detailsViewController.Selection = collectionData[(int)indexPath.Item];
                NavigationController.PushViewController(detailsViewController, true);
            }
            else
            {
                NavigationController.ToolbarHidden = false;
            }
        }

        public override void ItemDeselected(UICollectionView collectionView, NSIndexPath indexPath)
        {
            if (Editing)
            {
                var selected = CollectionView.GetIndexPathsForSelectedItems();
                if (selected != null && selected.Length == 0)
                {
                    NavigationController.ToolbarHidden = true;
                }
            }
        }

        // DataSource Section

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = collectionView.DequeueReusableCell(CollectionViewCell.CellID, indexPath) as CollectionViewCell;
            cell.TitleLabel.Text = collectionData[(int)indexPath.Item];
            cell.Editing = Editing;
            return cell;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return collectionData.Count;
        }

    }
}
