using MessageAppDemo2.Backend.Message.MessageDatas;
using MessageAppDemo2.Backend.Message.MessageDatas.Interfaces;
using MessageAppDemo2.Backend.SystemData.UploadedFile;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAppDemo2.FrontEnd.FrontEnd_BackendActions.ViewModels.App.HelperClasses
{
    public class DedectSendindMessageType
    {
        public static MessageType DedectType(ObservableCollection<UploadedFile> uploadedFiles, string MessageWaiting)
        {
            if (uploadedFiles.Count != 1)
            {
                return MessageType.TextMessage;
            }
            else if (uploadedFiles.Count == 1)
            {
                switch (uploadedFiles[0].FileType)
                {
                    case FileTypes.File:
                        return MessageType.TextMessage;
                    case FileTypes.Video:
                        return MessageType.VideoMessage;
                    case FileTypes.Image:
                        return MessageType.PictureMessage;
                    case FileTypes.Voice:
                        return MessageType.VoiceMessage;
                    case FileTypes.GIF:
                        return MessageType.VideoMessage;
                    default:
                        throw new ArgumentException("File Type Not Found");

                }
            }
            throw new ArgumentException("Error");
        }
        public static Type DedectTypeReturnType(ObservableCollection<UploadedFile> uploadedFiles, string MessageWaiting)
        {
            if (uploadedFiles.Count != 1)
            {
                return typeof(TextMessage);
            }
            else if (uploadedFiles.Count == 1)
            {
                switch (uploadedFiles[0].FileType)
                {
                    case FileTypes.File:
                        return typeof(TextMessage);
                    case FileTypes.Video:
                        return typeof(VideoMessage);
                    case FileTypes.Image:
                        return typeof(PictureMessage);
                    case FileTypes.Voice:
                        return typeof(VoiceMessage);
                    case FileTypes.GIF:
                        return typeof(VideoMessage);
                    default:
                        throw new ArgumentException("File Type Not Found");

                }
            }
            throw new ArgumentException("Error");
        }
        public static Type DedectTypeReturnType(MessageType type)
        {
            switch (type)
            {
                case MessageType.TextMessage:
                    return typeof(TextMessage);
                case MessageType.VideoMessage:
                    return typeof(VideoMessage);
                case MessageType.PictureMessage:
                    return typeof(PictureMessage);
                case MessageType.VoiceMessage:
                    return typeof(VoiceMessage);
                default:
                    throw new ArgumentException("File Type Not Found");
            }

            throw new ArgumentException("Error");
        }

    }
}
