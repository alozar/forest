﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesApp.Model
{
    public class Forest
    {
        public int Number { get; set; } //номер выдела
        public double Area { get; set; } //площадь
        public string Structure{ get; set; } //состав выдела
        public double Fullness { get; set; } //полнота
        public int StockHectare { get; set; } //запас леса на га
        public int StockTotal { get; set; } //запас леса общий
    }
}