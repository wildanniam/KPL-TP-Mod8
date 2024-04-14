namespace tpmodul8_1302220005
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            AppKonfig cfg = new AppKonfig();

            cfg.UbahSatuan();

            Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {cfg.konfig.satuan_suhu} : ");
            double suhu = Convert.ToDouble(Console.ReadLine());

            Console.Write($"Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? : ");
            int lama_demam = int.Parse(Console.ReadLine());


            if (
                ((cfg.konfig.satuan_suhu == "celcius" && suhu >= 36.5 && suhu <= 37.5) ||
                (cfg.konfig.satuan_suhu == "fahrenheit" && suhu >= 97.7 && suhu <= 99.5)) &&
                lama_demam < cfg.konfig.batas_hari_demam
            )
            {
                Console.WriteLine(cfg.konfig.pesan_diterima);
            }
            else
            {
                Console.WriteLine(cfg.konfig.pesan_ditolak);
            }
        }
    }
}
