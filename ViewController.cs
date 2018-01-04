using System;
using System.Collections.Generic;
using Foundation;
using CoreGraphics;
using UIKit;

namespace collectionview
{
    public partial class ViewController : UICollectionViewController
    {

        private UIBarButtonItem addButton;

        List<string> collectionData = new List<string>() { "1  ", "2 ", "3 ", "4 ", "5 " };


        public ViewController(UICollectionViewFlowLayout layout) : base(layout)
        {
            CollectionView.Delegate = this;

            addButton = new UIBarButtonItem(UIBarButtonSystemItem.Add, (s, e) =>
            {
                AddItem();
            });

            NavigationItem.SetRightBarButtonItem(addButton, true);
        }

        public override void ViewDidLoad()
        {
            CollectionView.BackgroundColor = UIColor.White;
            CollectionView.RegisterClassForCell(typeof(CollectionViewCell), CollectionViewCell.CellID);
            CollectionView.Source = new CollectionViewSource(collectionData);

            var refresh = new UIRefreshControl();
            refresh.AddTarget(Refresh, UIControlEvent.ValueChanged);
            CollectionView.RefreshControl = refresh;

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public void AddItem()
        {
            CollectionView.PerformBatchUpdates(() =>
            {
                for (var i = 0; i < 2; i++)
                {
                    var text = $"{collectionData.Count + 1}  woot";
                    collectionData.Add(text);
                    var index = NSIndexPath.FromRowSection(collectionData.Count - 1, 0);
                    CollectionView.InsertItems(new NSIndexPath[] { index });
                }
            }, null);
        }

        public void Refresh(Object sender, EventArgs eventArgs)
        {
            AddItem();
            CollectionView.RefreshControl.EndRefreshing();
        }

    }
}
