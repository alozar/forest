using lesApp.Model;
namespace lesApp.Service
{
    public interface IDialogService
    {
        string FilePath { get; }   // путь к выбранному файлу
        bool OpenFileDialog(FileTypes type);  // открытие файла
        bool SaveFileDialog();  // сохранение файла
        void ShowMessage(string message);   // показ сообщения
    }
}
