namespace Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] data = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 };

            int[] result10danbuyuk = data.Where(x => x > 10 ).ToArray();
            int[] resultTekSayilar = data.Where(x => x % 2 != 0).ToArray();
            int[] result10danBuyuk30dankucuk = data.Where(x => x > 10 && x < 30).ToArray();
            int[] result15denbuyukciftsayilar = data.Where(x => x > 15 && x % 2 == 0).ToArray();

            Console.WriteLine(String.Join(",", result10danbuyuk));
            Console.WriteLine(String.Join(",", resultTekSayilar));
            Console.WriteLine(String.Join(",", result10danBuyuk30dankucuk));
            Console.WriteLine(String.Join(",", result15denbuyukciftsayilar));
        }
    }
}
