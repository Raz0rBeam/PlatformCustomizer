using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using SiraUtil.Web;
using UnityEngine;
using PlatformCustomizer.Miscellaneous;
using PlatformCustomizer.CustomFeet;

namespace PlatformCustomizer.CustomFeet
{
    internal class RemoteLocation : ICustomListItem
    {
        public readonly string remoteLocation;
        private readonly DirectoryInfo _customFeetDir;
        private readonly string _fileName;

        private readonly IHttpService _webClient;

        private RemoteLocation(InitData initData, IHttpService webClient, CustomFeetDir feetDirs)
        {
            _webClient = webClient;
            _customFeetDir = feetDirs.CustomFeetDirectory;

            remoteLocation = initData.RemoteLocation;
            ListName = initData.Name;
            _fileName = initData.Filename;
        }

        public string ListName { get; }

        public async Task<Tuple<bool, string>> Download(CancellationToken token)
        {
            try
            {
                var response = await _webClient.GetAsync(remoteLocation, null, token);
                if (!response.Successful)
                {
                    return default;
                }
                Plugin.Log.Critical("KSDJFOIjseoijiosejf");
                var filename = GetFileName();
                File.WriteAllBytes(_customFeetDir.GetFile(filename).FullName, await response.ReadAsByteArrayAsync());
                return new Tuple<bool, string>(true, "CustomFeet\\" + filename);
            }
            catch (Exception)
            {
                return default;
            }
        }
        
        private string GetFileName()
        {
            return _fileName;
        }

        public struct InitData
        {
            public string RemoteLocation;
            public string Name;
            public string Filename;
        }
    }
}
