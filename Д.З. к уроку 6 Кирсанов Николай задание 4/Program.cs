 //**Считайте файл различными способами. Смотрите “Пример записи файла различными способами”. 
 //* Создайте методы, которые возвращают массив byte (FileStream, BufferedStream), строку для StreamReader и массив int для BinaryReader.

 

using System;
using System.Diagnostics;
using System.IO;

namespace Д.З.к_уроку_6_Кирсанов_Николай_задание_4
{
    class Program
    {
        static void Main(string[] args)
        {
            long kbyte = 1024;
            long mbyte = 1024 * kbyte;
            long gbyte = 1024 * mbyte;
            long size = mbyte;
           
            Console.WriteLine("Запишем файлы при помощи разных потоков:");
            Console.WriteLine("FileStream. Milliseconds:{0}", FileStreamSampleWrite("E:\\project\\Д.З. к уроку 6 Кирсанов Николай\\fail0.txt", size));
            Console.WriteLine("BinaryStream. Milliseconds:{0}", BinaryStreamSampleWrite("E:\\project\\Д.З. к уроку 6 Кирсанов Николай\\fail1.txt", size));
            Console.WriteLine("StreamWriter. Milliseconds:{0}", StreamWriterSampleWrite("E:\\project\\Д.З. к уроку 6 Кирсанов Николай\\fail2.txt", size));
            Console.WriteLine("BufferedStream. Milliseconds:{0}", BufferedStreamSampleWrite("E:\\project\\Д.З. к уроку 6 Кирсанов Николай\\fail3.txt", size));

            Console.WriteLine("Прочтём файлы при помощи разных потоков:");
            byte[] bytesFromFileStream = FileStreamSampleRead("E:\\project\\Д.З. к уроку 6 Кирсанов Николай\\fail0.txt");
            int[] integersFromBinatyStream = BinaryStreamSampleRead("E:\\project\\Д.З. к уроку 6 Кирсанов Николай\\fail1.txt");
            string stringFromSreamReader = StreamReaderSample("E:\\project\\Д.З. к уроку 6 Кирсанов Николай\\fail2.txt");
            byte[] bytesFromBufferedStream = BufferedStreamSampleRead("E:\\project\\Д.З. к уроку 6 Кирсанов Николай\\fail3.txt");

            Console.ReadKey();
        }

        
        static long FileStreamSampleWrite(string filename, long size)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            
            for (int i = 0; i < size; i++)
                fs.WriteByte(0);
            fs.Close();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        
        static byte[] FileStreamSampleRead(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            byte[] byteArray = new byte[fs.Length];
            for (int i = 0; i < fs.Length; i++)
                byteArray[i] = (byte)fs.ReadByte();
            fs.Close();
            return byteArray;
        }

        
        static long BinaryStreamSampleWrite(string filename, long size)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            for (int i = 0; i < size; i++)
                bw.Write((byte)0);
            fs.Close();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

       
        static int[] BinaryStreamSampleRead(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            int[] intArr = new int[fs.Length / 4];
            BinaryReader br = new BinaryReader(fs);
            for (int i = 0; i < fs.Length / 4; i++)
                intArr[i] = br.ReadInt32();
            fs.Close();
            return intArr;
        }

        
        static long StreamWriterSampleWrite(string filename, long size)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            for (int i = 0; i < size; i++)
                sw.Write(0);
            sw.Write("sdxc");
            fs.Close();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        
        static string StreamReaderSample(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string result = sr.ReadToEnd();          
            fs.Close();
            return result;
        }

        static long BufferedStreamSampleWrite(string filename, long size)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            int countPart = 4;
            int bufsize = (int)(size / countPart);
            byte[] buffer = new byte[size];
            BufferedStream bs = new BufferedStream(fs, bufsize);
            
            for (int i = 0; i < countPart; i++)
                bs.Write(buffer, 0, (int)bufsize);
            fs.Close();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        
        static byte[] BufferedStreamSampleRead(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            int countPart = 4;
            int bufsize = (int)(fs.Length / countPart);
            byte[] buffer = new byte[fs.Length];
            BufferedStream bs = new BufferedStream(fs, bufsize);
            
            for (int i = 0; i < countPart; i++)
                bs.Read(buffer, 0, (int)bufsize);
            fs.Close();
            return buffer;
        }
    }

}
