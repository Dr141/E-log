using System;
using System.Collections.Generic;
using System.IO;

namespace E_log
{
    class GerarCSV
    {
        public string nomeArquivo { get; private set; }

        public bool InicaArquivo()
        {
            this.nomeArquivo = "Dia_" + DateTime.Now.ToString().Remove(10).Replace("/", "") + ".CSV";

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

        public void EscreverCSV(List<string> mensagem)
        {
            if (this.InicaArquivo())
            {
                FileStream file = new FileStream(nomeArquivo, FileMode.Append);
                StreamWriter writer = new StreamWriter(file);

                foreach (var men in mensagem)
                {
                    writer.WriteLine(men);
                }                
                
                writer.Close();
                file.Close();
            }
        }
    }
}
