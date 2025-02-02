using Newtonsoft.Json;

namespace EasyLOB
{
    public class AppMenuEJ2
    {
        #region Properties

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("parentId")]
        public string ParentId { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        #endregion Properties

        #region Methods

        //public AppMenuEj2(string id, string text, string parentId, string url)
        //{
        //    string webPath = EasyLOBHelper.GetService<IEnvironmentManager>().WebPath;

        //    Id = id;
        //    Text = text;
        //    ParentId = parentId;
        //    Url = (string.IsNullOrEmpty(url) ? "" : webPath + (url[0] == '/' ? "" : "/") + url);
        //}

        #endregion Methods
    }
}