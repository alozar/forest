using lesApp.Model;
using lesApp.Service;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace lesApp.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        Forest selectedForest;

        IDialogService dialogService;
        IFileService fileService;
        ParseService parseService;

        public ObservableCollection<Forest> Forests { get; set; }

        // команда сохранения файла
        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return saveCommand ??
                  (saveCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (dialogService.SaveFileDialog() == true)
                          {
                              fileService.Save(dialogService.FilePath, Forests.ToList());
                              dialogService.ShowMessage("Файл сохранен");
                          }
                      }
                      catch (Exception ex)
                      {
                          dialogService.ShowMessage(ex.Message);
                      }
                  }));
            }
        }

        // команда открытия файла
        private RelayCommand openCommand;
        public RelayCommand OpenCommand
        {
            get
            {
                return openCommand ??
                  (openCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (dialogService.OpenFileDialog(FileTypes.FRJ) == true)
                          {
                              var forests = fileService.Open(dialogService.FilePath);
                              Forests.Clear();
                              foreach (var p in forests)
                                  Forests.Add(p);
                              dialogService.ShowMessage("Файл открыт");
                          }
                      }
                      catch (Exception ex)
                      {
                          dialogService.ShowMessage(ex.Message);
                      }
                  }));
            }
        }

        // команда парсинга txt-файла
        private RelayCommand parseCommand;
        public RelayCommand ParseCommand
        {
            get
            {
                return parseCommand ??
                  (parseCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (dialogService.OpenFileDialog(FileTypes.TXT) == true)
                          {
                              var forests = parseService.Open(dialogService.FilePath);
                              Forests.Clear();
                              foreach (var p in forests)
                                  Forests.Add(p);
                              dialogService.ShowMessage("Файл распарсен");
                          }
                      }
                      catch (Exception ex)
                      {
                          dialogService.ShowMessage(ex.Message);
                      }
                  }));
            }
        }

        public Forest SelectedForest
        {
            get { return selectedForest; }
            set
            {
                selectedForest = value;
                OnPropertyChanged("SelectedForest");
            }
        }

        public MainViewModel()
        {
            dialogService = new DialogService();
            fileService = new FileService();
            parseService = new ParseService();

            Forests = new ObservableCollection<Forest>
            {
                new Forest {
                    Number = 1,
                    Area = 27.6,
                    Structure = "6С3Л1Б",
                    Fullness = 0.6,
                    StockHectare = 260,
                    StockTotal = 7176
                },
                new Forest {
                    Number = 2,
                    Area = 5.3,
                    Structure = "7Б2С1Л",
                    Fullness = 0.7,
                    StockHectare = 110,
                    StockTotal = 583
                },
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
