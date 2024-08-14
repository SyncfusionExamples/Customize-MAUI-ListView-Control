using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewSample
{
    public class LoadMoreViewModel
    {
        private readonly int totalItems = 15;
        public ObservableCollection<BookInfo> BookDetails { get; set; }
        public Command<object> LoadMoreItemsCommand { get; set; }

        public LoadMoreViewModel()
        {
            BookDetails = new ObservableCollection<BookInfo>();
            GenerateSource(5);
            LoadMoreItemsCommand = new Command<object>(LoadMoreItems,CanLoadMoreItems);
        }

        private bool CanLoadMoreItems(object obj)
        {
            if(BookDetails.Count >= totalItems)
            {
                return false;
            }
            return true;
        }

        private async void LoadMoreItems(object obj)
        {
            var listView = obj as Syncfusion.Maui.ListView.SfListView;
            if(listView != null )
            {
                listView.IsLazyLoading = true;
                await Task.Delay(2500);
                var index = BookDetails.Count;
                var count = index + 2 >= totalItems ? totalItems - index : 2;
                for (int i = index; i < index + count; i++)
                {
                    var books = new BookInfo()
                    {
                        Name = BookNames[i],
                        Description = BookDescriptions[i]
                    };
                    BookDetails.Add(books);
                }
                listView.IsLazyLoading = false;
            }
        }

        private void GenerateSource(int value)
        {
            for (int i = 0; i < value; i++)
            {
                var book = new BookInfo()
                {
                    Name = BookNames[i],
                    Description = BookDescriptions[i]
                };

                BookDetails.Add(book);
            }
        }

        private readonly string[] BookNames = new string[]
        {
            "Object-Oriented Programming in C#",
            "C# Code Contracts",
            "Machine Learning Using C#",
            "Neural Networks Using C#",
            "Visual Studio Code",
            "Android Programming",
            "iOS Succinctly",
            "Visual Studio 2015",
            "Xamarin.Forms",
            "Windows Store Apps",
            "Agile Software Development",
            "Assembly Language",
            "Cryptography in .NET",
            "Entity Framework Code First",
            "Localization for .NET"
        };

        private readonly string[] BookDescriptions = new string[]
        {
            "Object-oriented programming is the de facto programming paradigm.",
            "Code Contracts provide a way to convey code assumptions.",
            "You’ll learn several different approaches to applying machine learning.",
            "Neural networks are an exciting field of software development.",
            "It is a powerful tool for editing code and serves for end-to-end programming.",
            "It is provides a useful overview of the Android application lifecycle.",
            "It is for developers looking to step into frightening world of iPhone.",
            "The new version of the widely-used integrated development environment.",
            "Its creates mappings from its C# classes and controls directly.",
            "Windows Store apps present a radical shift in Windows development.",
            "Learning new development processes can be difficult.",
            "Assembly language is as close to writing machine code.",
            "Cryptography is used throughout software to protect all kinds of information.",
            "Follow author Ricardo Peres as he introduces the newest development mode.",
            "Learn to write applications that support different languages and cultures."
        };
    }
}
