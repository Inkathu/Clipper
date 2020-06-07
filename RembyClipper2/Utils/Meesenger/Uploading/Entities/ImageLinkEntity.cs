using System;
using Localization;
using RembyClipper.Helpers;

namespace RembyClipper2.Utils.Uploading.Entities
{
    class ImageLinkEntity : LinkEntity
    {
        public ImageLinkEntity()
        {
            Name = LanguageMgr.LM.GetText(Labels.Image);
            _mediaStoreType = RembyServices.MediaStoreTypes.image;
        }

    }
}