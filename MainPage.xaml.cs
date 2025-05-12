namespace HybridWebViewSelect;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();

		webView.Uri = "<html><body style='padding:40px;'><form><label for='sel'>Choose:</label><select id='sel'><option>One</option><option>Two</option></select></form></body></html>";
	}

}

