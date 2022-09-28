using System;
using System.IO;

namespace E_log
{
    public class GerarLog
    {
        public string nomeArquivo { get; private set; }

        public bool InicaArquivo()
        {
            this.nomeArquivo = "Dia_" + DateTime.Now.ToString().Remove(10).Replace("/", "") + ".log";

            try
            {
                if (!File.Exists(this.nomeArquivo))
                {
                    FileStream file = new FileStream(nomeArquivo, FileMode.Create);
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
                FileStream file = new FileStream(nomeArquivo, FileMode.Append);
                StreamWriter writer = new StreamWriter(file);
                writer.WriteLine(DateTime.Now.ToString() + ". " + mensagem);
                writer.Close();
                file.Close();
            }
        }
    }
}
