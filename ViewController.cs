using System;
using System.Collections.Generic;
using Foundation;
using System.Linq;
using CoreGraphics;
using UIKit;

namespace collectionview
{
    public partial class ViewController : UICollectionViewController
    {

        private UIBarButtonItem addButton;
        private UIBarButtonItem deleteButton;

        List<string> collectionData = new List<string>() { "1  \U0001F600", "2 \U0001F602", "3 \U0001F606", "4 \U0001F60B", "5 \U0001F929" };

        public ViewController(UICollectionViewFlowLayout layout) : base(layout)
        {
            addButton = new UIBarButtonItem(UIBarButtonSystemItem.Add, (s, e) =>
            {
                AddItem();
            });

            deleteButton = new UIBarButtonItem(UIBarButtonSystemItem.Trash, (s, e) =>
            {
                DeleteSelected();
            });

            NavigationItem.SetRightBarButtonItem(addButton, true);
            NavigationItem.SetLeftBarButtonItem(EditButtonItem, true);

        }

        public override void ViewDidLoad()
        {
            CollectionView.BackgroundColor = UIColor.White;

            CollectionView.RegisterClassForCell(typeof(CollectionViewCell), CollectionViewCell.CellID);

            CollectionView.Delegate = this;
            CollectionView.DataSource = this;

            var refresh = new UIRefreshControl();
            refresh.AddTarget(Refresh, UIControlEvent.ValueChanged);
            CollectionView.RefreshControl = refresh;

            SetToolbarItems(new UIBarButtonItem[] { deleteButton }, false);
            NavigationController.ToolbarHidden = true;

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
                    var text = $"{collectionData.Count + 1} \U0001F60E";
                    collectionData.Add(text);
                    var index = NSIndexPath.FromRowSection(collectionData.Count - 1, 0);
                    CollectionView.InsertItems(new NSIndexPath[] { index });
                }
            }, null);
        }

        public void DeleteSelected()
        {
            var selected = CollectionView.GetIndexPathsForSelectedItems();
            var items = selected.Select(i => i.Item).OrderBy(i => i).Reverse();
            foreach (var item in items)
            {
                collectionData.Remove(collectionData[(int)item]);
            }
            CollectionView.DeleteItems(selected);
            NavigationController.ToolbarHidden = true;
        }

        public void Refresh(Object sender, EventArgs eventArgs)
        {
            AddItem();
            CollectionView.RefreshControl.EndRefreshing();
        }

        public override void SetEditing(bool editing, bool animated)
        {
            base.SetEditing(editing, animated);
            addButton.Enabled = !editing;
            deleteButton.Enabled = editing;
            CollectionView.AllowsMultipleSelection = editing;

            // Make Sure For VisibleItems Not SelectedItems!
            var indexes = CollectionView.IndexPathsForVisibleItems;

            foreach (var index in indexes)
            {
                var cell = CollectionView.CellForItem(index) as CollectionViewCell;
                cell.Editing = editing;
            }

            if (!editing)
            {
                NavigationController.ToolbarHidden = true;
            }
            else
            {
                NavigationController.ToolbarHidden = false;
            }

        }

    }
}
