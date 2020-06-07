using System;
using System.Collections.Generic;
using System.Text;

namespace Localization
{
    /// <summary>
    /// label names enum
    /// 
    /// </summary>
    public enum Labels 
    {
        // ReSharper disable InconsistentNaming
        //Common constants
        About,
        Error,
        AllRightsReserved,
        ChangeTags,
        Version,
        Name,
        LabelDelimiter,
        Text,
        Remby,
        RembyClipper,
        RembyLink,
        ToolTip_Copy,
        OCR,
        Tags,
        Source,
        Windows_Open,
        Upload,
        Capture_MarkArea,
        RembyScrennshot_WindowTitle,
        RembyText_WindowTitle,
        RembyScreenshot_CopiedToClipboard,
        Remby_Login_Title,
        Show,
        Clear,
        NotificationDontShowAgain,
        ContextMessageRandom,
        ContextMessageUploadVideoFile,
        ContextMessageFileDragging,
        ContextMessageYouTubeRecording,
        GettingStarted_Button_Close,

        Place_BottomRight,
        Place_TopRight,
        Place_NearIcon,

        #region Drawing tool
        Arrow,
        Rectangle,
        Circle,
        TextFigureText,
        ChangeBorderColor,
        ChangeBorderWidth,
        NoBorder,
        BorderSizyType,
        ChangeFillColor,
        ChangeTextColor,
        ChangeTextFont,
        Opacity,
        ChangeFigureOpacity,
        Reorder,
        ChangeFiguresOrder,
        SendToBack,
        BringToFront,
        SendBackward,
        BringForward,
        Clone,
        CloneSelectedFigure,
        Remove,
        RemoveFigure,
        AddArrow,
        AddCircle,
        AddRectangle,
        AddText,
        #endregion

        #region Типы файлов
        Image,
        File,
        Video,
        TextType,
        #endregion

        #region Button captions
        Button_Browse,
        Button_Cancel,
        Button_Continue,
        Button_Close,
        Button_CloseThisWindow,
        Button_Login,
        Button_AddRemby,
        Button_Save,
        Button_SaveChanges,
        Button_Next,
        #endregion
        
        #region Languages Titles
        EnglishLanguage,
        RussianLanguage,
        SwedishLanguage,
        #endregion

        #region Options window strings
        Options_Title,
        Options_General,
        Options_Video,
        Options_Login,
        Options_LogOut,
        Options_Video_Title,
        Options_Video_FrameRate,
        Options_Video_YouTubePrivate,
        Options_Audio_Title,
        Options_Audio_Channels,
        Options_Audio_Sample,
        Options_Audio_Bitrate,
        Options_Audio_Bitspersample,
        Options_Webcam_Title,
        Options_Webcam_Device,
        Options_RembyAccount,
        Options_LoggedIn,
        Options_StartWithWindows,
        Options_Language_Title,
        Options_Language_UseIn,
        Options_Advanced,
        Options_NotLoggedIn,
        Options_SaveDataError,
        Options_Reset,
        Options_SignedOutNote,
        Options_SettingsRestored,
        Options_MsgBoxPlacement,
        Options_placeAt,

        Options_Account_SubcriptionLabel,
        Options_Account_UserIdLabel,
        Options_Account_FileSizeLimitLabel,
        Options_Account_StorageSizeLimitLabel,
        Options_Account_TabTitle,
        Options_Account_UpgradeBtn,

        Options_Update_Never,
        Options_Update_EveryHour,
        Options_Update_EveryDay,
        Options_Update_EveryWeek,
        Options_Account_UpdatePolicyLabel,
        Options_Account_UpdatePeriodLabel,
        #endregion

        #region Main window and tray
        Tray_About,
        Tray_Options,
        Tray_Exit,
        Tray_GettingStarted,
        TopNav_Capture,
        TopNav_Video,
        TopNav_History,
        TopNav_AddNewBook,
        TopNav_HistoryRefreshing,
        TopNav_HistoryRefreshed,
        TopNav_Close,
        TopNav_Uploading,
        TopNav_Uploaded,
        TopNav_Error,
        TopNav_Hi,
        TopNav_Exit,
        ShareThis,
        TopNav_Text,
        TopNav_EditBook,
        TopNav_CancelUploading,
        TopNav_SendLogViaSkype,
        TopNav_ShowDebugLog,
        TopNav_OpenLogFolder,
        TopNav_CheckForUpdates,
        Windows_Screenvideo,
        Windows_Screenshot,
        TopNav_SendSkypeMessageWithParam,
        TopNav_DragAndDropDoesntSupported,
        TopNav_FewFilesWerentImages,
        TopNav_WereUploaded,
        TopNav_YouTubeTitle,
        TopNav_YouTubeDescription,
        TopNav_ClickToAddTagWithParam,
        TopNav_ChangeTagsWithParam,
        TopNav_Canceled,
        TopNav_ShortenUrlCopiedToClipBoardWithParam,
        TopNav_GoToMyBooks,
        TopNav_GoToMyStuff,
        TopNav_Upload,
        TopNav_ClearHistory,
        TopNav_CurrentUploadingQueue,
        TopNav_CancellAllUploading,
        TopNav_RecentUploadingItems,
        TopNav_UpdateErrorMessage,
        TopNav_CancelCurrent,
        TopNav_ClearList,
        TopNav_UnsupportedExtension,
        #endregion

        #region OCR window strings
        OCR_FormTitle,
        OCR_Title1,
        OCR_Title2,
        OCR_Quality,
        OCR_HowToImprove,
        OCR_TextCopied,
        OCR_Tips,
        ToolTip_OCR,
        ToolTip_Save,
        #endregion

        #region History window strings
        History_Title,
        History_ListTitle,
        History_Screenshot,
        History_Screenvideo,
        History_Text,
        History_SelectElementToShare,
        History_FilterOnTags,
        History_ChangeTagsError,
        History_All,
        History_ShowAll,
        History_Images,
        History_ShowImages,
        History_Videos,
        History_ShowVideos,
        History_Texts,
        History_ShowTexts,
        History_Files,
        History_ShowFiles,
        History_Screenshots,
        History_ShowScreenShots,
        History_Refresh,
        History_Items_Count,
        History_Select_To_Change_Tags,
        History_Expand_List_Button,
        #endregion

        #region Remby Video Frame
        RembyVideo_Title,
        RembyVideo_Tags,
        RembyVideo_Description,
        RembyVideo_Category,
        RembyVideo_TitleText,
        RembyVideo_TagsText,
        RembyVideo_YouTubeLegal,
        RembyVideo_CompleteDescription,
        RembyVideo_CompeteTags,
        RembyVideo_CompleteTitle,
        RembyVideo_WindowTitle,
        #endregion

        #region Remby Login Frame
        RembyLogin_Title,
        RembyLogin_Username,
        RembyLogin_Password,
        RembyLogin_RememberMe,
        RembyLogin_DontHaveAccount,
        RembyLogin_CreateAccount,
        #endregion

        #region Remby Recorder Frame
        VideoRecorder_MuteMic,
        VideoRecorder_UnmutMic,
        VideoRecorder_CloseCam,
        VideoRecorder_OpenCam,
        VideoRecorder_StartRecording,
        VideoRecorder_StopRecording,
        #endregion

        #region YouTube Login Frame
        RembyYouTubeLogin_Title,
        RembyYouTubeLogin_KeepLoggedIn,
        RembyYouTubeLogin_DontHaveAccount,
        RembyYouTubeLogin_CreateAccount,
        RembyYouTubeLogin_FreeUserTitle,
        #endregion

        #region Getting started form
        GettingStarted_Note1,
        GettingStarted_Note2,
        GettingStarted_Note3,
        GettingStarted_Note4,
        GettingStarted_Note5,
        GettingStarted_DontShowAgain,
        GettingStarted_DidYouKnow,
        #endregion

        #region First user experience window
        FirstUserExperience_FormTitle,
        FirstUserExperience_title,
        FirstUserExperience_body1,
        FirstUserExperience_body2,
        FirstUserExperence_dontshow,
        #endregion

        #region Drawing tool properties window

        Properties,
        FigureName,
        BorderColor,
        FillColor,
        BorderOpacity,
        BorderWidth,
        FillOpacity,
        Font,
        FontColor,
        None,

        #endregion

        #region WebCam surface frame
        VideoRecorder_ZoomIn,
        VideoRecorder_ZoomOut,
        #endregion

        #region Color Dialog
        ColorDialog_title,
        ColorDialog_ApplyBtn,
        ColorDialog_HTMLColor,
        ColorDialog_Red,
        ColorDialog_Green,
        ColorDialog_Blue,
        ColorDialog_Opacity,
        ColorDialog_RecentColors,
        #endregion

        #region InfoBox
        InfoBox_Link,
        InfoBox_File,
        InfoBox_Files,
        InfoBox_Video,
        InfoBox_ScreenShoot,
        InfoBox_Text,
        InfoBox_UploadingWithParam,

        #endregion


        #region Files upload dialog
        FileUpload_Title,
        FileUpload_HelpLabel,
        #endregion


        //Capture Form constants
        key1,
        key2,
        key3,


        #region Errors
        Error_VideoUpload,
        Error_LoadingVideo,
        Error_InvalidCredentials,
        #endregion
        // ReSharper restore InconsistentNaming


        AccountType_Basic,
        AccountType_Plus,
        AccountType_Unknown,

        Update_NewVersionCouldNotBeRetreivedWithParam,
        Update_Cancelled,
        Update_AvailableMessageWithQuestion,
        Update_AvailableText,
        Update_MandatoryUpdateWithParam,
        Update_LatestVersionRunning,
        Update_UpdateToLatestVerWasCanc,
        Update_CouldNotInstallLatestVersionWithParam,
        RestartApplicationText,
        Update_WouldYouLikeToRestartMessage,
        RembyFileUpload_WindowTitle,
        Button_Reselect,
        OneClickScreenShot_Text,
        OneClickScreenShot_Title,
        Attention,
        YouTube_InvalidCredentials,
        YouTube_ValidationError,
        TypeYourTextHere,
        ShareTo,
        Copy,
        SuccessShare_AvailableAt,
        AnnotateBubble,
        AddAnnotateBubble,
        InfoBox_Uploading,
        NotificationsAreaWrongPlace,
        ScreenshotTextParam,
        DescriptionText,
        LinkTooIsToLong,
        TagIsAlreadyUsed,
        unsupported_media_type,
        not_authorized,
        IE_Not_Supported
    }
}
