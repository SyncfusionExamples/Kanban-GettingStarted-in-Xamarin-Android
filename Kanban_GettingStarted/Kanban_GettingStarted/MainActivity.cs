using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Syncfusion.SfKanban.Android;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Kanban_GettingStarted
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

			/// Intialized the SfKanban Control
            SfKanban kanban = new SfKanban(this);

			///Holds a collection of KanbanModel instances
			ObservableCollection<KanbanModel> ItemsSourceCards()
			{
				ObservableCollection<KanbanModel> cards = new ObservableCollection<KanbanModel>();
				cards.Add(new KanbanModel()
				{
					ID = 1,
					Title = "iOS - 1002",
					ImageURL = "Image1.png",
					Category = "Open",
					Description = "Analyze customer requirements",
					ColorKey = "Red",
					Tags = new string[] { "Incident", "Customer" }
				});

				cards.Add(new KanbanModel()
				{
					ID = 6,
					Title = "Xamarin - 4576",
					ImageURL = "Image2.png",
					Category = "Open",
					Description = "Show the retrieved data from the server in grid control",
					ColorKey = "Green",
					Tags = new string[] { "SfDataGrid", "Customer" }
				});

				cards.Add(new KanbanModel()
				{
					ID = 13,
					Title = "UWP - 13",
					ImageURL = "Image3.png",
					Category = "In Progress",
					Description = "Add responsive support to application",
					ColorKey = "Brown",
					Tags = new string[] { "Story", "Kanban" }
				});

				cards.Add(new KanbanModel()
				{
					ID = 2543,
					Title = "Xamarin_iOS - 2543",
					Category = "Code Review",
					ImageURL = "Image4.png",
					Description = "Provide swimlane support kanban",
					ColorKey = "Brown",
					Tags = new string[] { "Feature", "SfKanban" }
				});

				cards.Add(new KanbanModel()
				{
					ID = 1975,
					Title = "iOS - 1975",
					Category = "Done",
					ImageURL = "Image5.png",
					Description = "Fix the issues reported by the customer",
					ColorKey = "Purple",
					Tags = new string[] { "Bug" }
				});

				return cards;
			}

			///Binded the above data to SfKanban using ItemsSource property.
			kanban.ItemsSource = ItemsSourceCards();

			kanban.ColumnMappingPath = "Category";

			KanbanColumn openColumn = new KanbanColumn(this);
			openColumn.Title = "To Do";
			openColumn.Categories = new List<object>() { "Open" };
			kanban.Columns.Add(openColumn);

			KanbanColumn progressColumn = new KanbanColumn(this);
			progressColumn.Title = "In Progress";
			progressColumn.Categories = new List<object>() { "In Progress" };
			kanban.Columns.Add(progressColumn);

			KanbanColumn codeColumn = new KanbanColumn(this);
			codeColumn.Title = "Code Review";
			codeColumn.Categories = new List<object>() { "Code Review" };
			kanban.Columns.Add(codeColumn);

			KanbanColumn doneColumn = new KanbanColumn(this);
			doneColumn.Title = "Done";
			doneColumn.Categories = new List<object>() { "Done" };
			kanban.Columns.Add(doneColumn);

			SetContentView(kanban);
            
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}