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
    }
}
