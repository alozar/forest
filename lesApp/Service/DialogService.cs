using lesApp.Model;
using Microsoft.Win32;
using System.Windows;

namespace lesApp.Service
{
    public class DialogService : IDialogService
    {
        public string FilePath { get; private set; }

        public bool OpenFileDialog(FileTypes type)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (type == FileTypes.FRJ)
                openFileDialog.Filter = "Forest json files|*.frj";
            if (type == FileTypes.TXT)
                openFileDialog.Filter = "text files|*.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;
                return true;
            }
            return false;
        }

        public bool SaveFileDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Forest json files|*.frj";
            saveFileDialog.DefaultExt = "frj";
            if (saveFileDialog.ShowDialog() == true)
            {
                FilePath = saveFileDialog.FileName;
                return true;
            }
            return false;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
