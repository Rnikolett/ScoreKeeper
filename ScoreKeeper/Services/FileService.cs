using ScoreKeeper.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ScoreKeeper.Services
{
    public static class FileService
    {
        private static string _playerFileName =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Scorekepper", "Player.json");

        private static string _gamesFileName =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Scorekepper", "Games.json");

        #region Players
        public static async Task SavePlayers(IEnumerable<string> players)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_playerFileName)!);

            using (var fs = File.Create(_playerFileName))
            {
                await JsonSerializer.SerializeAsync(fs, players);
            }
        }

        public static async Task<IEnumerable<string>?> LoadPlayers()
        {
            try
            {
                using (var fs = File.OpenRead(_playerFileName))
                {
                    return await JsonSerializer.DeserializeAsync<List<string>>(fs);
                }
            }
            catch (Exception e) when (e is FileNotFoundException || e is DirectoryNotFoundException)
            {
                return null;
            }
        }
        #endregion

        #region Games
        public static async Task SaveGames(IEnumerable<Game> games)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_gamesFileName)!);

            using (var fs = File.Create(_gamesFileName))
            {
                await JsonSerializer.SerializeAsync(fs, games);
            }
        }

        public static async Task<IEnumerable<Game>?> LoadGames()
        {
            try
            {
                using (var fs = File.OpenRead(_gamesFileName))
                {
                    return await JsonSerializer.DeserializeAsync<List<Game>>(fs);
                }
            }
            catch (Exception e) when (e is FileNotFoundException || e is DirectoryNotFoundException)
            {
                return null;
            }
        }
        #endregion
    }
}
