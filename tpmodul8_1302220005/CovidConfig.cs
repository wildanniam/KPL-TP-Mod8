using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace tpmodul8_1302220005
{
    public class CovidConfig
    {
        public String satuan_suhu { get; set; }
        public int batas_hari_demam { get; set; }
        public String pesan_ditolak { get; set; }
        public String pesan_diterima { get; set; }

        public CovidConfig()
        {
        }
    }

    public class AppKonfig
    {

        public CovidConfig konfig;

        //private const string filePath = "D://JSON/konfigkpl.json";
        private const string filePath = "../../../covid_config.json";

        public AppKonfig()
        {
            try
            {
                ReadKonfigFile();
            }
            catch
            {
                SetDefault();
                WriteKonfigFile();
            }
        }

        public void ReadKonfigFile()
        {
            String configJsonData = File.ReadAllText(filePath);
            konfig = JsonSerializer.Deserialize<CovidConfig>(configJsonData);
        }

        public void WriteKonfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            String tulisan = JsonSerializer.Serialize(konfig);
            File.WriteAllText(filePath, tulisan);
        }

        public void SetDefault()
        {
            konfig = new CovidConfig();

            konfig.satuan_suhu = "celcius";
            konfig.batas_hari_demam = 14;
            konfig.pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
            konfig.pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";
        }

        public void UbahSatuan()
        {
            if (this.konfig.satuan_suhu == "celcius")
            {
                this.konfig.satuan_suhu = "fahrenheit";
            }
            else
            {
                this.konfig.satuan_suhu = "celcius";
            }

            String tulisan = JsonSerializer.Serialize(konfig);
            File.WriteAllText(filePath, tulisan);
        }
    }
}
