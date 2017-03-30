using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using PugCreator.Commands;
using PugCreator.Models;

namespace PugCreator.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        #region Commands

        private readonly DelegateCommand _createPugCommand;
        public ICommand CreatePugCommand => _createPugCommand;

        private ObservableCollection<Pug> _pugCollection { get; set; }
        public ObservableCollection<Pug> PugCollection
        {
            get => _pugCollection;
            set
            {
                _pugCollection = value;
                RaisePropertyChangedEvent("PugCollection");
            }
        }

        private Pug _selectedPug;
        public Pug SelectedPug
        {
            get => _selectedPug;
            set
            {
                _selectedPug = value;
                RaisePropertyChangedEvent("SelectedPug");
            }
        }

        private string _createPugName;
        public string CreatePugName
        {
            get => _createPugName;
            set
            {
                _createPugName = value;
                RaisePropertyChangedEvent("CreatePugName");
            }
        }

        private string _createPugColour;
        public string CreatePugColour
        {
            get => _createPugColour;
            set
            {
                _createPugColour = value;
                RaisePropertyChangedEvent("CreatePugColour");
            }
        }

        #endregion

        private PugClient.PugClient Client { get; }

        public MainWindowViewModel()
        {
            Client = new PugClient.PugClient();

            _createPugCommand = new DelegateCommand(CreatePug);

            RefreshPugs();

            SelectedPug = PugCollection.FirstOrDefault();
        }

        public void RefreshPugs()
        {
            PugCollection = new ObservableCollection<Pug>(Client.GetPugs());

            CreatePugColour = "";
            CreatePugName = "";
        }

        public void CreatePug()
        {
            var pugCreator = Client.CreatePug(new Pug
            {
                Id = Guid.NewGuid(),
                Name = CreatePugName,
                Coat = new Coat
                {
                    Id = Guid.NewGuid(),
                    ColourCode = CreatePugColour
                }
            });

            MessageBox.Show(pugCreator ?
                "Your Pug has been created!" :
                "Unable to create your Pug :(...");

            RefreshPugs();
        }
    }
}
