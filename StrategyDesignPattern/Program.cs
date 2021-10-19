using System;

namespace StrategyDesignPattern
{
    public interface ICompressStrategy
    {
        string Compress(string data);
    }

    public class ZipCompressionStrategy : ICompressStrategy
    {
        public string Compress(string data)
        {
            return "<zip>" + data + "</zip";
        }
    }

    public class RarCompressionStrategy : ICompressStrategy
    {
        public string Compress(string data)
        {
            return "<rar>" + data + "</rar>";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //string compr = "zip";
            string compr = "rar";

            ICompressStrategy strategy = null;

            if (compr == "zip")
            {
                strategy = new ZipCompressionStrategy();
            }
            else if (compr == "rar")
            {
                strategy = new RarCompressionStrategy();
            }
            else //default
            {
                strategy = new RarCompressionStrategy();
            }
            var compressData = strategy.Compress("Compress Me");
            Console.WriteLine(compressData);
        }
    }
}
