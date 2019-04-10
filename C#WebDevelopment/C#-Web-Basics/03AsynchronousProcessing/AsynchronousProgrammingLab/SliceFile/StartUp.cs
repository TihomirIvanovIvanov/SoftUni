namespace SliceFile
{
    using System;
    using System.IO;
    using System.Threading.Tasks;

    public class StartUp
    {
        public static void Main()
        {
            var videoPath = Console.ReadLine();
            var destination = Console.ReadLine();
            int pieces = int.Parse(Console.ReadLine());

            SliceAsync(videoPath, destination, pieces);

            Console.WriteLine("Anything else?");
            while (true)
            {
                Console.ReadLine();
            }
        }

        private static void Slice(string sourseFile, string destinationPath, int parts)
        {
            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }

            using (var sourse = new FileStream(sourseFile, FileMode.Open))
            {
                var fileInfo = new FileInfo(sourseFile);

                var partLength = (sourse.Length / parts) + 1;
                var currentByte = 0;

                for (int currentPart = 1; currentPart <= parts; currentPart++)
                {
                    var filePath = string.Format($"{destinationPath}/Part-{currentPart}{fileInfo.Extension}");

                    using (var destination = new FileStream(filePath, FileMode.Create))
                    {
                        var buffer = new byte[byte.MaxValue];
                        while (currentByte <= partLength * currentPart)
                        {
                            var readBytesCount = sourse.Read(buffer, 0, buffer.Length);
                            if (readBytesCount == 0)
                            {
                                break;
                            }

                            destination.Write(buffer, 0, readBytesCount);
                            currentByte += readBytesCount;

                            Console.WriteLine("Slice complete.");
                        }
                    }
                }
            }
        }

        private static void SliceAsync(string videoPath, string destination, int pieces)
        {
            Task.Run(() =>
            {
                Slice(videoPath, destination, pieces);
            });
        }
    }
}
