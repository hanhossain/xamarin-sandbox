using Foundation;
using UIKit;

namespace XamarinSandbox.iOS.Extensions
{
    // ReSharper disable once InconsistentNaming
    public static class UITableViewExtensions
    {
        public static void RegisterClassForCellReuse<T>(this UITableView tableView, string reuseIdentifier)
            where T: UITableViewCell
        {
            tableView.RegisterClassForCellReuse(typeof(T), reuseIdentifier);
        }

        public static T DequeueReusableCell<T>(
            this UITableView tableView, string reuseIdentifier, NSIndexPath indexPath)
            where T : UITableViewCell
        {
            return (T)tableView.DequeueReusableCell(reuseIdentifier, indexPath);
        }
    }
}
