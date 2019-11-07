using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesApp.Model.Entities
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
