using System;
using Foundation;
using UIKit;
using XamarinSandbox.iOS.Extensions;

namespace XamarinSandbox.iOS.ViewControllers
{
    public class TableViewController : UITableViewController
    {
        private const string CellId = "CellId";

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            TableView.RegisterClassForCellReuse<UITableViewCell>(CellId);
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(CellId, indexPath);
            cell.TextLabel.Text = "Hello world";
            return cell;
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return 1;
        }
    }
}
