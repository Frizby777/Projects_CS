using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA_Text_Editor
{
    class Editor
    {
        public string Path { get; set; }
        public string Results { get; set; }
        public DateTime DateEdit { get; set; }
        public DateTime DateCreate { get; set; }
        public int Lengh { get; set; }
        public Editor(string path)
        {
            Path = path;
        }

        public void Open(string file)
        {
            using (StreamReader sr = new StreamReader(file))
            {
                Results = sr.ReadToEnd();
                DateEdit = File.GetLastWriteTime(file);
                DateCreate = File.GetCreationTime(file);
                Lengh = file.Length;
            }
        
        }

        public void Save(string file)
        {
            using (StreamWriter sw = new StreamWriter(file, false))
            {
                sw.WriteLine(Results);
            }

            

        }



    }
}
