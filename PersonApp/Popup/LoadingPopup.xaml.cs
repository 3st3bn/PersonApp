using Mopups.Pages;
namespace PersonApp.Popup;

public partial class LoadingPopup : PopupPage
{
	public LoadingPopup(string message)
	{
        InitializeComponent();
        lblLoading.Text = message;
    }
}