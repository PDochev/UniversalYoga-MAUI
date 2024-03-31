using Firebase.Database;
using Firebase.Database.Query;
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace UniversalYogaMAUI;


public partial class Courses : ContentPage
{
	public ObservableCollection<YogaCourse> listOfCourses { get; set; } = new ObservableCollection<YogaCourse>();
	FirebaseClient firebaseClient = new FirebaseClient("https://universalyoga-e002e-default-rtdb.europe-west1.firebasedatabase.app/");
    

	public Courses()
	{
		InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        initialiseData();
    }

    private void initialiseData()
    {
        listOfCourses = new ObservableCollection<YogaCourse>();
        var collection = firebaseClient.Child("courses").AsObservable<YogaCourse>().Subscribe((item) =>
        {
            if(item.Object != null)
            {
                listOfCourses.Add(new YogaCourse
                {
                    Key = item.Key,
                    dayOfWeek = item.Object.dayOfWeek,
                    timeOfCourse = item.Object.timeOfCourse,
                    capacity = item.Object.capacity,
                    duration = item.Object.duration,
                    price = item.Object.price,
                    type = item.Object.type,
                    description = item.Object.description,
                    level = item.Object.level,
                    id = item.Object.id
                    
                });
            }
        });
        this.collectionCourses.ItemsSource = listOfCourses;
    }

    void collectionCourses_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is YogaCourse selectedCourse)
    {
        // Pass selected course's ID to the Classes constructor
        Navigation.PushAsync(new Classes(selectedCourse.id));

    }
    }
    void Search_TextChanged(object sender, TextChangedEventArgs e)
    {
        string searchText = e.NewTextValue;

        if (string.IsNullOrEmpty(searchText))
        {
            this.collectionCourses.ItemsSource = listOfCourses;
        }
        else
        {
            var filteredCourses = listOfCourses.Where(c => c.dayOfWeek.ToLower().Contains(searchText.ToLower()));
            this.collectionCourses.ItemsSource = new ObservableCollection<YogaCourse>(filteredCourses);
        }
    }


}
