using System;
using Foundation;
using UIKit;
using XamarinSandbox.iOS.Extensions;
using XamarinSandbox.iOS.Views;

namespace XamarinSandbox.iOS.ViewControllers
{
    public class TableViewController : UITableViewController
    {
        private const string CellId = "CellId";

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            TableView.RegisterClassForCellReuse<SubtitleTableViewCell>(CellId);
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell<SubtitleTableViewCell>(CellId, indexPath);
            cell.TextLabel.Text = "Hello world";
            cell.DetailTextLabel.Text = "This is some detail";
            return cell;
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return 1;
        }
    }
}
