using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicksCode.Entities;
using System.IO;

namespace TicksCode
{
    class Program
    {
        static void Main(string[] args)
        {
            TickCode code = new TickCode();
            Console.WriteLine(code);

            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string path = Path.Combine(docPath, "TickCodes");
            string separator = " | ";
            // Se não existir o arquivo, ele cria na pasta de documentos
            File.AppendAllText(Path.Combine(path, "codes.txt"), (code.ToString() + separator));






        }
    }
}
