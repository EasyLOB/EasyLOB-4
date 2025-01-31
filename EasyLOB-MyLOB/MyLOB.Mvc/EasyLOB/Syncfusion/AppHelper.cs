using EasyLOB.Resources;
using Syncfusion.JavaScript.Models;

namespace EasyLOB
{
    public static partial class AppHelper
    {
        #region Properties

        public static DatePickerProperties DateModel
        {
            get
            {
                DatePickerProperties dateModel = new DatePickerProperties();
                dateModel.DateFormat = PatternResources.ToStringFormat_Date;
                dateModel.Locale = System.Globalization.CultureInfo.CurrentCulture.Name;
                //dateModel.Width = "120";
                dateModel.Width = "180";

                return dateModel;
            }
        }

        public static DateTimePickerProperties DateTimeModel
        {
            get
            {
                DateTimePickerProperties dateTimeModel = new DateTimePickerProperties();
                dateTimeModel.DateTimeFormat = PatternResources.ToStringFormat_DateTime;
                dateTimeModel.Locale = System.Globalization.CultureInfo.CurrentCulture.Name;
                dateTimeModel.Width = "180";

                return dateTimeModel;
            }
        }

        #endregion Properties
    }
}