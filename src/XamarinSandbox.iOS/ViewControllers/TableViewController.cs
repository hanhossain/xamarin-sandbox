using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;
using XamarinSandbox.iOS.Extensions;
using XamarinSandbox.iOS.Models;
using XamarinSandbox.iOS.Views;

namespace XamarinSandbox.iOS.ViewControllers
{
    public class TableViewController : UITableViewController
    {
        private const string CellId = "CellId";
        private readonly List<Entry> _entries = new List<Entry>();

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            TableView.RegisterClassForCellReuse<SubtitleTableViewCell>(CellId);
            NavigationItem.RightBarButtonItem = new UIBarButtonItem(
                UIBarButtonSystemItem.Add,
                AddEntry);
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell<SubtitleTableViewCell>(CellId, indexPath);
            var entry = _entries[indexPath.Row];
            
            cell.TextLabel.Text = entry.Content;
            cell.DetailTextLabel.Text = entry.Timestamp.ToString("g");
            return cell;
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return _entries.Count;
        }
        
        private void AddEntry(object sender, EventArgs e)
        {
            var alertController = UIAlertController.Create("Add Entry", "Add an entry", UIAlertControllerStyle.Alert);
            alertController.AddTextField(x => x.Placeholder = "Entry");
            
            var submitAction = UIAlertAction.Create("Submit", UIAlertActionStyle.Default, _ =>
            {
                var text = alertController.TextFields.First().Text;
                if (!string.IsNullOrWhiteSpace(text))
                {
                    _entries.Add(new Entry()
                    {
                        Content = text,
                        Timestamp = DateTime.Now
                    });
                }
                
                TableView.InsertRows(
                    new[] { NSIndexPath.FromRowSection(_entries.Count - 1, 0) },
                    UITableViewRowAnimation.Automatic);
            });
            alertController.AddAction(submitAction);

            PresentViewController(alertController, true, null);
        }
    }
}
