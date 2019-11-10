using lesApp.Model;
using lesApp.Model.Entities;
using lesApp.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace lesApp.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        Quarter selectedQuarter;
        Section selectedSection;
        double square;

        IDialogService dialogService;
        IFileService fileService;
        ParseService parseService;

        public ObservableCollection<Quarter> Quarters { get; set; }

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
                              fileService.Save(dialogService.FilePath, Quarters.ToList());
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
                              var quarters = fileService.Open(dialogService.FilePath);
                              Quarters.Clear();
                              foreach (var q in quarters)
                                  Quarters.Add(q);
                              SelectedQuarter = Quarters.FirstOrDefault();
                              SelectedSection = SelectedQuarter.Sections.FirstOrDefault();
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
                              var quarters = parseService.Open(dialogService.FilePath);
                              Quarters.Clear();
                              foreach (var p in quarters)
                                  Quarters.Add(p);
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

        // команда вычисления площади
        private RelayCommand calculateCommand;
        public RelayCommand СalculateCommand
        {
            get
            {
                return calculateCommand ??
                  (calculateCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          Result = СalculateService.GetResult(SelectedSection, Square);
                      }
                      catch (Exception ex)
                      {
                          dialogService.ShowMessage(ex.Message);
                      }
                  }));
            }
        }

        public Quarter SelectedQuarter
        {
            get { return selectedQuarter; }
            set
            {
                selectedQuarter = value;
                OnPropertyChanged("SelectedQuarter");
            }

        }
        public Section SelectedSection
        {
            get { return selectedSection; }
            set
            {
                selectedSection = value;
                OnPropertyChanged("SelectedSection");
            }
        }
        public double Square
        {
            get { return square; }
            set
            {
                square = value;
                OnPropertyChanged("Square");
            }
        }

        public Dictionary<string, double> result;
        public Dictionary<string, double> Result
        {
            get { return result; }
            set
            {
                result = value;
                OnPropertyChanged("Result");
            }
        }

        public MainViewModel()
        {
            dialogService = new DialogService();
            fileService = new FileService();
            parseService = new ParseService();
            Quarters = new ObservableCollection<Quarter>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
