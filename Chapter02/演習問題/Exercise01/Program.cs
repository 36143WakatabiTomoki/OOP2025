using static System.Net.Mime.MediaTypeNames;

namespace Exercise01 {
    public class Program {
        static void Main(string[] args) {
            // 2.1.3
            var songs = new List<string>();
            bool loopEnd = false;
            int songLine = 0;
            Console.WriteLine("***** 曲の登録 *****");

#if true
            while (!loopEnd) {
                Console.WriteLine();

                Console.Write("曲名：");
                string? title = Console.ReadLine();
                if(title == "end") {
                    loopEnd = true;
                    break;
                }
                songs.Add(title);

                Console.Write("アーティスト名：");
                string? artistName = Console.ReadLine();
                songs.Add(artistName);

                Console.Write("演奏時間（秒）：");
                string? length = Console.ReadLine();
                songs.Add(length);

                songLine++;
            }

            int loopCount = 0;
            for(int loop = 0; loop < songLine; loop++) {
                var song = new Song[] {
                    new Song(songs[loopCount], songs[loopCount + 1], int.Parse(songs[loopCount + 2])),
                };
                printSongs(song);
                loopCount += 3;
            }

#else
            while( true ) {
                Console.Write("曲名：");

                string? title = Console.ReadLine();

                // endが入力されたら登録終了 (endの後ろは大文字と小文字の区別を無くすもの)
                if(title.Equals("end",StringComparison.OrdinalIgnoreCase))
                    return;

                Console.Write("アーティスト名：");

                string? artistName = Console.ReadLine();

                Console.Write("演奏時間（秒）：");

                int length = int.Parse(Console.ReadLine());


                Song song = new Song() {
                    Title = title,
                    ArtistName = artistName,
                    Length = length,
                };

                songs.Add(song);

                Console.WriteLine();
            }
#endif
        }


        // 2.1.4
        private static void printSongs(Song[] songs) {
#if false
            foreach (var song in songs) {
                var minutes = song.Length / 60;
                var seconds = song.Length % 60;
                Console.WriteLine($"{song.Title} {song.ArtistName} {minutes}:{seconds:00}");
            }
#else
            // TimeSpan構造体を使った場合
            foreach (var song in songs) {
                var timespan = TimeSpan.FromSeconds(song.Length);
                Console.WriteLine($"{song.Title} {song.ArtistName} {timespan.Minutes}: {timespan.Seconds:00}");
            }

            // または、以下でも可
            /*foreach (var song in songs) {
                Console.WriteLine(@"{0}, {1}, {2:m\:ss}",
                    song.Title, song.ArtistName, TimeSpan.FromSeconds(song.Length));
            }*/
#endif
            Console.WriteLine();
        }
    }
}
