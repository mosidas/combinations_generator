using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CombinationsGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ChooseCsvFile_Click(object sender, EventArgs e)
        {
            var filePath = SelectFile();
            var sets = LoadSets(filePath);
            Results.Text = GenerateCombination(sets);
        }

        private string SelectFile()
        {
            var ofd = new OpenFileDialog();
            ofd.Title = "ファイルを開く";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ofd.Filter = "CSVファイル(*.csv)|*.csv";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                return ofd.FileName;
            }
            else
            {
                return "";
            }
        }

        private List<Set> LoadSets(string filePath)
        {
            if(string.IsNullOrEmpty(filePath))
            {
                return new List<Set>();
            }

            var sets = new Dictionary<string, List<string>>();

            using (var parser = new TextFieldParser(filePath, Encoding.UTF8))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                parser.HasFieldsEnclosedInQuotes = true;
                parser.TrimWhiteSpace = false;

                while (!parser.EndOfData)
                {
                    var line = parser.ReadFields();

                    if(sets.ContainsKey(line[0]))
                    {
                        sets[line[0]].Add(line[1]);
                    }
                    else
                    {
                        sets[line[0]] = new List<string>
                        {
                            line[1]
                        };
                    }
                }
            }

            var r = sets.Select(s => new Set() { SetName = s.Key, ElementNames = s.Value }).ToList();
            return r;
        }
        private string GenerateCombination(List<Set> sets)
        {
            var r = "";
            r = string.Join(",", sets.Select(s => s.SetName)) + Environment.NewLine;
            r += GetCombination("", sets);
            return r;
        }

        private string GetCombination(string baseStr, List<Set> baseSet)
        {
            if(baseSet.Count == 0)
            {
                return baseStr + Environment.NewLine;
            }
            else
            {
                var str = "";
                var set =  baseSet[0];
                var sets = baseSet.Skip(1).ToList();
                foreach (var element in set.ElementNames)
                {
                    var bstr = string.IsNullOrEmpty(baseStr) ? element : baseStr + "," + element;
                    str += GetCombination(bstr, sets);
                }
                return str;
            }
        }
    }
}
