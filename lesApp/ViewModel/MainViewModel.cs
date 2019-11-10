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
                          double sq = Square;
                          dialogService.ShowMessage("Площадь посчитана");
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

        public MainViewModel()
        {
            dialogService = new DialogService();
            fileService = new FileService();
            parseService = new ParseService();
            Quarters = new ObservableCollection<Quarter>();
            //var quarter1 = new Quarter
            //{
            //    Number = 1,
            //    Sections = new List<Section>
            //    {
            //        new Section {
            //            Number = 1,
            //            Area = 27.6,
            //            Structure = "6С3Л1Б",
            //            Fullness = 0.6,
            //            StockHectare = 260,
            //            StockTotal = 7176,
            //            IsForest = true
            //        },
            //        new Section {
            //            Number = 2,
            //            Area = 5.3,
            //            Structure = "7Б2С1Л",
            //            Fullness = 0.7,
            //            StockHectare = 110,
            //            StockTotal = 583,
            //            IsForest = true
            //        },
            //        new Section
            //        {
            //            Number = 40,
            //            Area = 0.4,
            //            Structure = "ручьи",
            //            IsForest = false
            //        }
            //    }
            //};
            //var quarter3 = new Quarter
            //{
            //    Number = 3,
            //    Sections = new List<Section>
            //    {
            //        new Section {
            //            Number = 1,
            //            Area = 12.2,
            //            Structure = "9С3Л",
            //            Fullness = 0.7,
            //            StockHectare = 224,
            //            StockTotal = 8105,
            //            IsForest = true
            //        },
            //        new Section {
            //            Number = 2,
            //            Area = 3.9,
            //            Structure = "1Б1Л7С",
            //            Fullness = 0.5,
            //            StockHectare = 190,
            //            StockTotal = 622,
            //            IsForest = true
            //        },
            //        new Section
            //        {
            //            Number = 15,
            //            Area = 0.7,
            //            Structure = "профиль",
            //            IsForest = false
            //        }
            //    }
            //};
            //Quarters.Add(quarter1);
            //Quarters.Add(quarter3);
            //SelectedQuarter = Quarters.FirstOrDefault();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
