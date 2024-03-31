using Firebase.Database;
using Firebase.Database.Query;
namespace UniversalYogaMAUI;

public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();
	}

	private void viewCourses(object sender, EventArgs e)
	{

		Navigation.PushAsync(new Courses(), true);
	}

  
}


