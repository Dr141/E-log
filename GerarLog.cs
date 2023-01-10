using System;
using System.IO;

namespace E_log
{
    public class GerarLog : IDisposable
    {
        public string nomeArquivo { get; private set; }
        private FileStream file;
        private StreamWriter writer;

        public bool InicaArquivo()
        {
            this.nomeArquivo = "Dia_" + DateTime.Now.ToString().Remove(10).Replace("/", "") + ".log";

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

        public void EscreverLog(string mensagem)
        {
            if (this.InicaArquivo())
            {
                file = new FileStream(nomeArquivo, FileMode.Append);
                writer = new StreamWriter(file);
                writer.WriteLine(DateTime.Now.ToString() + ". " + mensagem);                
            }
        }

        public void Dispose()
        {
            writer.Close();
            file.Close();
        }
    }
}