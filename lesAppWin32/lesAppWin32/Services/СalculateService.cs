using lesAppWin32.Model.Entities;
using System.Collections.Generic;

namespace lesAppWin32.Services
{
    public static class СalculateService
    {
        public static Dictionary<string, double> GetResult(Section section, double square)
        {
            var result = new Dictionary<string, double>();
            foreach (var d in ParseStructure(section.Structure))
            {
                result[d.Key] = square * section.StockHectare * 0.01 * d.Value;
            }
            return result;
        }

        private static string GetKind(string shortKind)
        {
            switch (shortKind)
            {
                case "Л":
                    return "лиственица";
                case "К":
                    return "кедр";
                case "С":
                    return "сосна";
                case "Б":
                    return "береза";
                case "Е":
                    return "ель";
                case "П":
                    return "пихта";
                case "ОС":
                    return "осина";
                default:
                    return shortKind;
            }
        }

        private static Dictionary<string, int> ParseStructure(string structure)
        {
            var parseStructure = new Dictionary<string, int>();
            int value = -1;
            string num ="";
            string kind="";
            foreach (var s in structure)
            {
                if (s == '+')
                {
                    break;
                }
                if (char.IsDigit(s))
                {
                    if (num != "" && kind != "")
                    {
                        value = int.Parse(num);
                        num = "";
                    }
                    num += s;
                }
                else
                {
                    kind += s;
                }
                if (value != -1)
                {
                    parseStructure[GetKind(kind)] = value;
                    kind = "";
                    value = -1;
                }
            }
            parseStructure[GetKind(kind)] = int.Parse(num);
            return parseStructure;
        }
    }
}
