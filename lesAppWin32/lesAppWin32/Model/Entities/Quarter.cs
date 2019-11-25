using System.Collections.Generic;
namespace lesAppWin32.Model.Entities
{
    public class Quarter //квартал
    {
        public Quarter() { }
        public Quarter(int number)
        {
            Number = number;
            Sections = new List<Section>();
        }
        public int Number { get; set; } //номер квартала
        public List<Section> Sections { get; set; } //список выделов
    }
}
