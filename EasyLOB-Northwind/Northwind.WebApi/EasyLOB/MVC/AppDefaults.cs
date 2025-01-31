namespace EasyLOB
{
    public static partial class AppDefaults
    {
        #region Properties

        public static string TitleSeparator { get { return " : "; } }

        #endregion Properties

        #region Properties CSS

        // Group
        //     Label
        //     Editor
        //         Lookup
        //     Validator

        public static string CSSClassGroup { get { return "form-group z-group"; } }

        public static string CSSClassGroupImage { get { return "form-group z-groupImage"; } }

        public static string CSSClassGroupTextArea { get { return "form-group z-groupTextArea"; } }

        public static string CSSClassEditor { get { return "form-control input-sm z-editor"; } }

        public static string CSSClassEditorRequired { get { return "form-control input-sm z-editorRequired"; } }

        public static string CSSClassEditorDate { get { return "z-editorDate"; } }

        public static string CSSClassEditorDateRequired { get { return "z-editorDateRequired"; } }

        public static string CSSClassEditorDateTime { get { return "z-editorDateTime"; } }

        public static string CSSClassEditorDateTimeRequired { get { return "z-editorDateTimeRequired"; } }
        
        public static string CSSClassForm { get { return "z-form"; } }
        //public static string CSSClassForm { get { return "form-inline z-form"; } }

        public static string CSSClassFormButtons { get { return "z-formButtons"; } }

        public static string CSSClassLabel { get { return "control-label z-label"; } }

        public static string CSSClassLabelRequired { get { return "control-label z-labelRequired"; } }

        public static string CSSClassLookup { get { return "input-group z-lookup"; } }

        public static string CSSClassLookupEditor { get { return "form-control input-sm z-lookupEditor"; } }

        public static string CSSClassLookupEditorRequired { get { return "form-control input-sm z-lookupEditorRequired"; } }

        public static string CSSClassPanel { get { return "panel-body z-panel"; } }

        public static string CSSClassValidator { get { return "z-validator"; } }

        #endregion Properties CSS Class

        #region Properties Syncfusion

        public static int SyncfusionRecordsByPage { get { return 10; } }

        public static int SyncfusionRecordsByLookup { get { return 5; } }

        public static int SyncfusionRecordsBySearch { get { return 100; } }

        public static int SyncfusionRecordsForFiltering { get { return 100; } }

        public static string SyncfusionTheme { get { return "bootstrap-theme"; } }

        #endregion Properties Syncfusion
    }
}