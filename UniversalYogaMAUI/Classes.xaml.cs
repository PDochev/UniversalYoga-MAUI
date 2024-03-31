using Firebase.Database;
using Firebase.Database.Query;
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace UniversalYogaMAUI;

public partial class Classes : ContentPage
{
    public ObservableCollection<YogaClass> listOfClasses { get; set; } = new ObservableCollection<YogaClass>();
    FirebaseClient firebaseClient = new FirebaseClient("https://universalyoga-e002e-default-rtdb.europe-west1.firebasedatabase.app/");
    string selectedCourseId;

    public Classes(string courseId)
	{
		InitializeComponent();
        selectedCourseId = courseId;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        initialiseData();
    }

    private void initialiseData()
    {
        listOfClasses = new ObservableCollection<YogaClass>();
        var collection = firebaseClient.Child("classes").AsObservable<YogaClass>().Subscribe((item) =>
        {
            if (item.Object != null && item.Object.id_course == selectedCourseId)
            {

                listOfClasses.Add(new YogaClass
                {
                    Key = item.Key,
                    id_course = item.Object.id_course,
                    teacher = item.Object.teacher,
                    date = item.Object.date,
                    comments = item.Object.comments,
                    
                });
            }
        });

        this.collectionClasses.ItemsSource = listOfClasses;
    }

    void collectionClasses_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

   

    void Search_TextChanged(object sender, TextChangedEventArgs e)
    {
        string searchText = e.NewTextValue;

        if (string.IsNullOrEmpty(searchText))
        {   
            this.collectionClasses.ItemsSource = listOfClasses;
        }
        else
        {
            var filteredClasses = listOfClasses.Where(c => c.date.ToLower().Contains(searchText.ToLower()));
            this.collectionClasses.ItemsSource = new ObservableCollection<YogaClass>(filteredClasses);
        }
    }

}
