    using MvvmHelpers;
using EasyStall.Models;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EasyStall.ViewModels
{
    public class StandViewModel : ViewModelBase
    {
        public StandViewModel(string email)
        {
            Email = email;

        }
        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public ObservableRangeCollection<Stand> Stand { get; set; }

        public ObservableRangeCollection<Grouping<string,Stand>> StandGroups { get; set; }

        public AsyncCommand RefreshCommand { get; }
        public StandViewModel()
        {
            Title = " Les Stands ";

            Stand = new ObservableRangeCollection<Stand>();
            StandGroups = new ObservableRangeCollection<Grouping<string, Stand>>();

            Stand.Add(new Stand { Number = 1, Size = "Petit" });
            Stand.Add(new Stand { Number = 2, Size = "Grand" });
            Stand.Add(new Stand { Number = 3, Size = "Grand" });
            Stand.Add(new Stand { Number = 4, Size = "Moyen" });
            Stand.Add(new Stand { Number = 5, Size = "Petit" });
            /*
            StandGroups.Add(new Grouping<string, Stand>("Grand", Stand.Where(s => s.Size == "Grand")));
            StandGroups.Add(new Grouping<string, Stand>("Moyen", Stand.Where(s => s.Size == "Moyen")));
            StandGroups.Add(new Grouping<string, Stand>("Petit", Stand.Where(s => s.Size == "Petit")));
             */    
            RefreshCommand = new AsyncCommand(Refresh);
        }

        Stand selectedStand;

        public Stand SelectedStand
        {
            get => selectedStand;
            set
            {
                if (value != null)
                {
                    Application.Current.MainPage.DisplayAlert( "Taille du stand selectionné", value.Size, "OK");
                    value = null;
                }
                selectedStand = value;
                OnPropertyChanged();
            }
        }

        async Task Refresh()
        {
            IsBusy = true;

            await Task.Delay(2000);
            IsBusy = false;

        }

}
}
