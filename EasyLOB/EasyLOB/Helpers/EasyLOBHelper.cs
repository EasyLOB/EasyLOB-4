using AutoMapper;
using System.Collections.Generic;

namespace EasyLOB
{
    /// <summary>
    /// EasyLOB Helper.
    /// </summary>
    public static partial class EasyLOBHelper
    {
        #region Properties

        /// <summary>
        /// DI Manager.
        /// </summary>
        public static IDIManager DIManager { get; private set; }

        /// <summary>
        /// AutoMapper Mapper.
        /// </summary>
        public static IMapper Mapper { get; private set; }

        #endregion Properties

        #region Properties File

        public static Dictionary<ZFileTypes, string> FileAcronyms
        {
            get
            {
                Dictionary<ZFileTypes, string> result = new Dictionary<ZFileTypes, string>();
                foreach (KeyValuePair<ZFileTypes, string> keyValue in FileExtensions)
                {
                    result.Add(keyValue.Key, keyValue.Value.Replace(".", "")); // .pdf => pdf
                }
                return result;
            }
        }

        public static Dictionary<ZFileTypes, string> FileContentTypes
        {
            get
            {
                return new Dictionary<ZFileTypes, string>
                {
                    // Unknown
                    { ZFileTypes.ftUnknown, "" },
                    // Document
                    { ZFileTypes.ftPDF, "application/pdf" },
                    { ZFileTypes.ftDOC, "application/msword" },
                    { ZFileTypes.ftDOCX, "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
                    { ZFileTypes.ftTXT, "text/plain" },
                    { ZFileTypes.ftXLS, "application/vnd.ms-excel" },
                    { ZFileTypes.ftXLSX, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" },
                    // Image
                    { ZFileTypes.ftJPG, "image/jpeg" },
                    { ZFileTypes.ftPNG, "image/x-png" },
                    // Audio
                    { ZFileTypes.ftMP3, "audio/x-mp3" },
                    // Video
                    { ZFileTypes.ftAVI, "video/x-msvideo" },
                    { ZFileTypes.ftMOV, "video/quicktime" },
                    { ZFileTypes.ftMP4, "video/mp4" },
                    { ZFileTypes.ftMPEG, "video/mpeg" },
                    { ZFileTypes.ftWMV, "video/x-ms-wmv" },
                    // Mail
                    { ZFileTypes.ftMSG, "application/vnd.ms-outlook" }
                };
            }
        }

        public static Dictionary<ZFileTypes, string> FileExtensions
        {
            get
            {
                return new Dictionary<ZFileTypes, string>
                {
                    // Unknown
                    { ZFileTypes.ftUnknown, "" },
                    // Document
                    { ZFileTypes.ftPDF, ".pdf" },
                    { ZFileTypes.ftDOC, ".doc" },
                    { ZFileTypes.ftDOCX, ".docx" },
                    { ZFileTypes.ftTXT, ".txt" },
                    { ZFileTypes.ftXLS, ".xls" },
                    { ZFileTypes.ftXLSX, ".xlsx" },
                    // Image
                    { ZFileTypes.ftJPG, ".jpg" }, // .jpeg GetFileType()
                    { ZFileTypes.ftPNG, ".png" },
                    // Audio
                    { ZFileTypes.ftMP3, ".mp3" },
                    // Video
                    { ZFileTypes.ftAVI, ".avi" },
                    { ZFileTypes.ftMOV, ".mov" },
                    { ZFileTypes.ftMP4, ".mp4" },
                    { ZFileTypes.ftMPEG, ".mpeg" },
                    { ZFileTypes.ftWMV, ".wmv" },
                    // Mail
                    { ZFileTypes.ftMSG, ".msg" }
                };
            }
        }

        public static Dictionary<ZFileTypes, string> FileIcons
        {
            get
            {
                return new Dictionary<ZFileTypes, string>
                {
                    // Unknown
                    { ZFileTypes.ftUnknown, "" },
                    // Document
                    { ZFileTypes.ftPDF, "pdf.png" },
                    { ZFileTypes.ftDOC, "doc.png" },
                    { ZFileTypes.ftDOCX, "doc.png" },
                    { ZFileTypes.ftTXT, "txt.png" },
                    { ZFileTypes.ftXLS, "xls.png" },
                    { ZFileTypes.ftXLSX, "xls.png" },
                    // Image
                    { ZFileTypes.ftJPG, "image.png" },
                    { ZFileTypes.ftPNG, "image.png" },
                    // Audio
                    { ZFileTypes.ftMP3, "audio.png" },
                    // Video
                    { ZFileTypes.ftAVI, "movie.png" },
                    { ZFileTypes.ftMOV, "movie.png" },
                    { ZFileTypes.ftMP4, "movie.png" },
                    { ZFileTypes.ftMPEG, "movie.png" },
                    { ZFileTypes.ftWMV, "movie.png" },
                    // Mail
                    { ZFileTypes.ftMSG, "mail.png" }
                };
            }
        }

        #endregion Properties File

        #region Methods

        public static void Setup(IDIManager diManager,
            IMapper mapper)
        {
            DIManager = diManager;
            Mapper = mapper;
        }

        public static T GetService<T>()
        {
            return DIManager.GetService<T>();
        }

        #endregion Methods

        #region Methods File

        /// <summary>
        /// Get acronym.
        /// </summary>
        /// <param name="fileType">File type</param>
        /// <returns>Acronym</returns>
        public static string GetAcronym(ZFileTypes fileType)
        {
            string acronym;

            if (!FileAcronyms.TryGetValue(fileType, out acronym))
            {
                FileContentTypes.TryGetValue(ZFileTypes.ftUnknown, out acronym);
            }

            return acronym;
        }

        /// <summary>
        /// Get content type.
        /// </summary>
        /// <param name="fileType">File type</param>
        /// <returns>Content type</returns>
        public static string GetContentType(ZFileTypes fileType)
        {
            string contentType;

            if (!FileContentTypes.TryGetValue(fileType, out contentType))
            {
                FileContentTypes.TryGetValue(ZFileTypes.ftUnknown, out contentType);
            }

            return contentType;
        }

        /// <summary>
        /// Get file extension.
        /// </summary>
        /// <param name="fileType">File type</param>
        /// <returns>File extension</returns>
        public static string GetFileExtension(ZFileTypes fileType)
        {
            string extension;

            if (!FileExtensions.TryGetValue(fileType, out extension))
            {
                FileExtensions.TryGetValue(ZFileTypes.ftUnknown, out extension);
            }

            return extension;
        }

        /// <summary>
        /// Get file type.
        /// </summary>
        /// <param name="acronymOrExtension">File acronym (pdf) or extension (.pdf)</param>
        /// <returns>File type</returns>
        public static ZFileTypes GetFileType(string acronymOrExtension)
        {
            ZFileTypes fileType = ZFileTypes.ftUnknown;

            acronymOrExtension = acronymOrExtension.ToLower();
            acronymOrExtension = acronymOrExtension.Replace("jpeg", "jpg");

            // Acronyms

            foreach (KeyValuePair<ZFileTypes, string> keyValue in FileAcronyms)
            {
                if (keyValue.Value == acronymOrExtension)
                {
                    fileType = keyValue.Key;
                    break;
                }
            }

            // Extensions

            if (fileType == (int)ZFileTypes.ftUnknown)
            {
                foreach (KeyValuePair<ZFileTypes, string> keyValue in FileExtensions)
                {
                    if (keyValue.Value == acronymOrExtension)
                    {
                        fileType = keyValue.Key;
                        break;
                    }
                }
            }

            return fileType;
        }

        /// <summary>
        /// Get icon.
        /// </summary>
        /// <param name="fileType">File type</param>
        /// <returns>Icon file name</returns>
        public static string GetIcon(ZFileTypes fileType)
        {
            string icon = "";

            if (!FileIcons.TryGetValue(fileType, out icon))
            {
                FileIcons.TryGetValue(ZFileTypes.ftUnknown, out icon);
            }

            return icon;
        }

        /// <summary>
        /// Get icon.
        /// </summary>
        /// <param name="acronymOrExtension">File acronym (pdf) or extension (.pdf)</param>
        /// <returns>Icon file name</returns>
        public static string GetIcon(string acronymOrExtension)
        {
            string icon = "";

            if (!FileIcons.TryGetValue(GetFileType(acronymOrExtension), out icon))
            {
                FileIcons.TryGetValue(ZFileTypes.ftUnknown, out icon);
            }

            return icon;
        }

        #endregion Methods File
    }
}
