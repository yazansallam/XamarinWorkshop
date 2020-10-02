using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Quiz
{
    public class ViewModel : INotifyPropertyChanged
    {


        public ICommand StatisticCommand { get; set; }
        public ICommand FalschCommand { get; set; }
        public ICommand RichtigCommand { get; set; }
        public ICommand ÜberspringenCommand { get; set; }
        private (String, Boolean, int) frage;
        public (String, Boolean, int) Frage
        {
            get => frage;
            set
            {
                if (frage != value)
                {
                    frage = value;
                    OnPropertychanged();
                }
            }
        }

        private string ergebniss;
        public string Ergebniss
        {
            get => ergebniss;
            set
            {
                if (ergebniss != value)
                {
                    ergebniss = value;
                    OnPropertychanged();
                }
            }
        }

        private Int32 richtingAntwort;
        public Int32 RichtingAntwort
        {
            get => richtingAntwort;
            set
            {
                if (richtingAntwort != value)
                {
                    richtingAntwort = value;
                    OnPropertychanged();
                }
            }
        }

        private Int32 falscheAntwort;
        public Int32 FalscheAntwort
        {
            get => falscheAntwort;
            set
            {
                if (falscheAntwort != value)
                {
                    falscheAntwort = value;
                    OnPropertychanged();
                }
            }
        }

        private Int32 übersprungen;
        public Int32 Übersprungen
        {
            get => übersprungen;
            set
            {
                if (übersprungen != value)
                {
                    übersprungen = value;
                    OnPropertychanged();
                }
            }
        }


        public String MeineFrage
        {
            get
            {
                return frage.Item1;               
            }
            
            set
            {
                MeineFrage = frage.Item1;
                OnPropertychanged();
            }
        }

        

         private Color meincolor;
        public Color MeinColor
        {
            get => meincolor;
            set
            {
                if (meincolor != value)
                {
                    meincolor = value;
                    OnPropertychanged();
                }
            }
        }





        public List<(String, Boolean, int)> MeineListe = new List<(String, Boolean, int)>();

        public ViewModel()
        {
            StatisticCommand = new Command(StatisticFunk);
            FalschCommand = new Command(FalschFunk);
            RichtigCommand = new Command(StatisticFunk);
            ÜberspringenCommand = new Command(ÜberspringenFunk);
            MeineListe.Add(f1);
            MeineListe.Add(f2);
            MeineListe.Add(f3);
            MeineListe.Add(f4);
            MeineListe.Add(f5);
            MeineListe.Add(f6);
            Frage = MeineListe[0];
        }
        (String , Boolean,int) f1 = ("Xamarin macht spaß", true,0);
        (String, Boolean, int) f2 = ("mein Name ist Alex", false,1);
        (String, Boolean, int) f3 = ("Magdeburg hat Mehr Einwohner als Essen ", false, 2);
        (String, Boolean, int) f4 = ("5*5=25", true,3);
        (String, Boolean, int) f5 = ("Trump ist Cool", false,4);
        (String, Boolean, int) f6 = ("die Erde ist Flach ", false, 5);
        

        public void StatisticFunk()
        {

        }
        public void FalschFunk()
        {
            if (Frage.Item2 == false)
            {
                Ergebniss = "richtig";
                richtingAntwort = richtingAntwort +1;
                MeinColor = Color.Green;
            }
            else
            {
                Ergebniss = "Falsch";
                falscheAntwort = falscheAntwort + 1;
                MeinColor = Color.Red;
            }
            if (Frage.Item3 == 5)
            {
                Frage = MeineListe[0];
            }
            else
            {
                Frage = MeineListe[Frage.Item3 + 1];
            }
            OnPropertychanged(nameof(Ergebniss));
            OnPropertychanged(nameof(falscheAntwort));
            OnPropertychanged(nameof(richtingAntwort));
            OnPropertychanged(nameof(Frage));
            OnPropertychanged(nameof(MeineFrage));
            OnPropertychanged(nameof(MeinColor));

        }
        public void RichtigFunk()
        {
            if (Frage.Item2 == true)
            {
                Ergebniss = "richtig";
                richtingAntwort = richtingAntwort + 1;
                MeinColor = Color.Green;
            }
            else
            {
                Ergebniss = "Falsch";
                MeinColor = Color.Red;
                falscheAntwort = falscheAntwort + 1;
                if (Frage.Item3 == 5)
                {
                    Frage = MeineListe[0];
                }
                Frage = MeineListe[Frage.Item3 + 1];
            }
            if (Frage.Item3 == 5)
            {
                Frage = MeineListe[0];
            }
            else
            {
                Frage = MeineListe[Frage.Item3 + 1];
            }
            OnPropertychanged(nameof(Ergebniss));
            OnPropertychanged(nameof(falscheAntwort));
            OnPropertychanged(nameof(richtingAntwort));
            OnPropertychanged(nameof(Frage));
            OnPropertychanged(nameof(MeineFrage));
            OnPropertychanged(nameof(MeinColor));
        }
        public void ÜberspringenFunk()
        {
            if (Frage.Item3 == 5)
            {
                Frage = MeineListe[0];
            }
            else
            {
                Frage = MeineListe[Frage.Item3 + 1];
            }
            
            übersprungen = übersprungen + 1;
            OnPropertychanged(nameof(Ergebniss));
            OnPropertychanged(nameof(falscheAntwort));
            OnPropertychanged(nameof(richtingAntwort));
            OnPropertychanged(nameof(Frage));
            OnPropertychanged(nameof(MeineFrage));
            OnPropertychanged(nameof(MeinColor));

        }
   
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertychanged([CallerMemberName] String name = "") => PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(name));
        
    }
}
