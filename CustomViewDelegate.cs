using System;
using UIKit;
using CoreGraphics;

namespace collectionview
{
    public class CustomViewDelegate : UICollectionViewDelegateFlowLayout
    {
        public override CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, Foundation.NSIndexPath indexPath)
        {
            var width = (collectionView.Frame.Size.Width - 20) / 3;
            return new CGSize(width, width);
        }

    }
}
