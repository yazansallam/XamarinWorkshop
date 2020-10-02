using System;
using System.Diagnostics;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Quiz
{
    public partial class App : Application
    {
        static StatistikDatenbank _datenbank;

        ViewModel viewModel = new ViewModel();

        public static StatistikDatenbank Datenbank
        {
            get
            {
                if (_datenbank != null) return _datenbank;
                var dbPath = Path.Combine(FileSystem.AppDataDirectory, "statistik.db3");
                Debug.WriteLine(dbPath);
                _datenbank = new StatistikDatenbank(dbPath);
                return _datenbank;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage(viewModel));
        }

        protected override void OnStart()
        {
            var dbStatistik = Datenbank.LoadStatistik();
            if (dbStatistik != null)
            {
                viewModel.FalscheAntwort = dbStatistik.FalscheAntworte;
                viewModel.RichtingAntwort = dbStatistik.DbRichtigeAntworte;
                viewModel.Übersprungen = dbStatistik.Übersprungen;
            }
        }

        protected override void OnSleep()
        {
            Datenbank.SaveStatistik(new Statistik {
                Übersprungen = viewModel.Übersprungen,
                DbRichtigeAntworte = viewModel.RichtingAntwort,
                FalscheAntworte = viewModel.FalscheAntwort               
            });
        }

        protected override void OnResume()
        {
        }
    }
}
