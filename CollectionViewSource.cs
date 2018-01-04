using System;
using System.Collections.Generic;
using UIKit;
using Foundation;
using CoreGraphics;

namespace collectionview
{
    public class CollectionViewSource: UICollectionViewSource
    {
        public List<string> CollectionData { get; set; }

        public CollectionViewSource(List<string> _collectionData)
        {
            CollectionData = _collectionData;
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = collectionView.DequeueReusableCell(CollectionViewCell.CellID, indexPath) as CollectionViewCell;
            cell.TitleLabel.Text = CollectionData[(int)indexPath.Item];
            cell.Editing = true;
            return cell;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return CollectionData.Count;
        }
       
    }
}
