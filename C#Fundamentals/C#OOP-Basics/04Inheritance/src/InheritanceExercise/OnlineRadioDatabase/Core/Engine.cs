using OnlineRadioDatabase.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineRadioDatabase.Core
{
    public class Engine
    {
        private List<Song> songs;

        public Engine()
        {
            this.songs = new List<Song>();
        }

        public void Run()
        {
            var numberOfSongs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfSongs; i++)
            {
                try
                {
                    var inputArgs = Console.ReadLine()
                        .Split(';', StringSplitOptions.RemoveEmptyEntries);

                    if (inputArgs.Length != 3)
                    {
                        throw new InvalidSongException();
                    }

                    var artistName = inputArgs[0];
                    var songName = inputArgs[1];
                    var length = inputArgs[2]
                        .Split(':', StringSplitOptions.RemoveEmptyEntries);

                    var isMinutes = int.TryParse(length[0], out int minutes);
                    var isSeconds = int.TryParse(length[1], out int seconds);

                    if (!isMinutes)
                    {
                        throw new InvalidSongLengthException();
                    }

                    if (!isSeconds)
                    {
                        throw new InvalidSongLengthException();
                    }

                    var song = new Song(artistName, songName, minutes, seconds);
                    songs.Add(song);
                    Console.WriteLine("Song added.");
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }

            Print();
        }

        private void Print()
        {
            Console.WriteLine($"Songs added: {songs.Count}");

            var totalSeconds = songs.Sum(song => song.Minutes * 60 + song.Seconds);
            var time = TimeSpan.FromSeconds(totalSeconds);

            Console.WriteLine($"Playlist length: {time.Hours}h {time.Minutes}m {time.Seconds}s");
        }
    }
}
