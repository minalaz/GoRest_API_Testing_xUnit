using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoRest.GoRestApi.Models;
using Newtonsoft.Json;
using Xunit;


namespace GoRest.GoRestApi.Tests
{
    public class SavingFile
    {
        [Fact]
        public async void SaveFile()
        {
            //practicing to make and export json file
            var CurrentDir = System.IO.Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()).ToString() + Path.DirectorySeparatorChar + "JsonFile" + Path.DirectorySeparatorChar + "Credentials.json";
            JsonFile jsonFile = new JsonFile();
            jsonFile.username = "MinaMinic";
            jsonFile.password = "zaboravljenaDeca";
            string serializedJsonFile = JsonConvert.SerializeObject(jsonFile);
            await File.WriteAllTextAsync(CurrentDir, serializedJsonFile);
            var readFile = await File.ReadAllTextAsync(CurrentDir);
            JsonFile deserialized = JsonConvert.DeserializeObject<JsonFile>(readFile);
            Assert.Equal(jsonFile.username, deserialized.username);
            Assert.Equal(jsonFile.password, deserialized.password);
        }

    }
}
