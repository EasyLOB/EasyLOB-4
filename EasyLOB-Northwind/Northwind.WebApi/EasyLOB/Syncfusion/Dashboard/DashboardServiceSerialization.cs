using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace EasyLOB
{
    public class DashboardServiceSerialization
    {
        private static readonly XmlSerializer previewSerializer = new XmlSerializer(typeof(DashboardServicePreviewSettings));

        public void Serialize(DashboardServicePreviewSettings settings, string path)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    previewSerializer.Serialize(writer, settings);
                }
            }
            catch (Exception)
            {
            }
        }

        public DashboardServicePreviewSettings Deserialize(string path)
        {
            DashboardServicePreviewSettings settings = new DashboardServicePreviewSettings();
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    settings = (DashboardServicePreviewSettings)previewSerializer.Deserialize(reader);
                }
            }
            catch (Exception)
            {
            }
            return settings;
        }
    }

    public class DashboardServicePreviewSettings
    {
        public string ServiceURL { get; set; }
        public List<Guid> DashboardServiceInstances { get; set; }

        public DashboardServicePreviewSettings()
        {
            DashboardServiceInstances = new List<Guid>();
        }
    }
}