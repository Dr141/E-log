using System;
using System.Collections.Generic;
using System.IO;

namespace E_log
{
    public class GerarCSV : IDisposable
    {
        public string nomeArquivo { get; private set; }
        private FileStream file;
        private StreamWriter writer;

        public bool InicaArquivo()
        {
            this.nomeArquivo = "Dia_" + DateTime.Now.ToString().Remove(10).Replace("/", "") + ".CSV";

            try
            {
                if (!File.Exists(this.nomeArquivo))
                {
                    file = new FileStream(nomeArquivo, FileMode.Create);
                    file.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void EscreverCSV(List<string> mensagem)
        {
            if (this.InicaArquivo())
            {
                file = new FileStream(nomeArquivo, FileMode.Append);
                writer = new StreamWriter(file);

                foreach (var men in mensagem)
                {
                    writer.WriteLine(men);
                }  
            }
        }

        public void EscreverCSV(string mensagem)
        {
            if (this.InicaArquivo())
            {
                file = new FileStream(nomeArquivo, FileMode.Append);
                writer = new StreamWriter(file);
                writer.WriteLine(mensagem);                
            }
        }

        public void Dispose()
        {
            writer.Close();
            file.Close();
        }
    }
}