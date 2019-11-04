using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesApp.Model.Entities
{
    public class Quarter //квартал
    {
        public int Number { get; set; } //номер квартала
        public List<Section> Sections { get; set; } //список выделов
    }
}
