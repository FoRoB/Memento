using Memento.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Memento.Infrastructure
{
    internal static class SerializeHelper
    {
        public static void Serialize(string path, object obj)
        {
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(fs, obj);
            }
        }
        public static T Deserialize<T>(string path)
        {
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                return JsonSerializer.Deserialize<T>(fs);
            }
        }
        public static async Task SerializeAsync(string path, object obj)
        {
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync(fs, obj);
            }
        }
        public static async Task<T> DeserializeAsync<T>(string path)
        {
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                return await JsonSerializer.DeserializeAsync<T>(fs);
            }
        }
    }
}
