using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace searchaufgabe
{ 
    class TableViewModel: INotifyPropertyChanged
{
        public TableViewModel()
        {
            items = new ObservableCollection<ItemViewModel>();
            items.Add(new ItemViewModel { Text = "text", Detail = "detail", Source = "source" });
            items.Add(new ItemViewModel { Text = "text2", Detail = "detail2", Source = "source" });
        }
        public ObservableCollection<ItemViewModel> items { get; set; }

        private String eingabe;
        public String Eingabe 
        {
          get => eingabe;
            set
            {
                if (eingabe != value)
                {
                    eingabe = value;
                    OnPropertychanged();
                }
            }
        }
        public struct ItemViewModel
        {
            public string Text { get; set; }
            public string Detail { get; set; }
            public string Source { get; set; }            
        }

        public void SetInformationInList(List<ItemViewModel> Inlist )
        {
            foreach (var item in Inlist)
            {
                items.Add(new ItemViewModel { Text = item.Text, Detail = item.Detail, Source = item.Source });
            }
        }

      public event PropertyChangedEventHandler PropertyChanged;

      public void OnPropertychanged([CallerMemberName] String name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }
}
