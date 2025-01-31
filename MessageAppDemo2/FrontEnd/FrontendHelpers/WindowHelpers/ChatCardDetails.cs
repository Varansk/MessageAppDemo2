using MessageAppDemo2.Backend.Message.MessageDatas.Interfaces;
using MessageAppDemo2.Backend.Message.MessageDatas;
using MessageAppDemo2.FrontEnd.Resources.Icons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using MessageAppDemo2.Backend.SystemData.ExtensionClasses;
using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo2.Backend.DataBase.Repositorys;
using MessageAppDemo2.Backend.Users.UserData.Interfaces;
using MessageAppDemo2.Backend.DataBase.DatabaseObjectPools.RepositoryPools;

namespace MessageAppDemo2.FrontEnd.FrontendHelpers.WindowHelpers
{
    public record class ChatCardDetails
        (MessageBase Message, MessageType MessageType, string LastMessageFormatted, BitmapImage LastMessageSideLogo, string UserNameFormatted)
    {
        public static ChatCardDetails GetChatDetails(MessageBase LastMessage)
        {
            MessageType messagetype = (MessageType)LastMessage;
            string LastMessageFormat = string.Empty;
            BitmapImage LastMessageLogoFormat = null;
            string UserNameFormat = string.Empty;



            

            DatabaseRepository<User, Guid> repo = DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();

            User user = repo.GetSingle((I) => { return I.UserGUİD == LastMessage.MessageSenderID; });

            DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Return(repo);

            string FirstName = user.Name;
            string LastName = user.LastName;

            string nsn = FirstName + " " + LastName;


            if (nsn.Length >= 10)
            {
                UserNameFormat = nsn.Substring(0, 10);
            }
            else
            {
                UserNameFormat = nsn;
            }


            switch (LastMessage)
            {
                case TextMessage tm:

                    if (tm.Text.Length >= 40)
                    {
                        LastMessageFormat = tm.Text.Substring(0, 40);
                    }
                    else
                    {
                        LastMessageFormat += tm.Text;
                    }

                    LastMessageLogoFormat = tm.Files.Any() == true ? IconResources.archive.ToBitmapImage() : IconResources.comment.ToBitmapImage();

                    break;

                case VideoMessage vm:
                    LastMessageFormat = "Video: ";

                    if (vm.Text.Length >= 33)
                    {
                        LastMessageFormat = LastMessageFormat + vm.Text.Substring(0, 33);
                    }
                    else
                    {
                        LastMessageFormat = LastMessageFormat + vm.Text;
                    }

                    LastMessageLogoFormat = IconResources.play_button.ToBitmapImage();

                    break;

                case PictureMessage pm:

                    LastMessageFormat = "Image: ";

                    if (pm.Text.Length >= 33)
                    {
                        LastMessageFormat = LastMessageFormat + pm.Text.Substring(0, 33);
                    }
                    else
                    {
                        LastMessageFormat = LastMessageFormat + pm.Text;
                    }

                    LastMessageLogoFormat = IconResources.image.ToBitmapImage();


                    break;
                case VoiceMessage vem:

                    LastMessageFormat = "Voice: ";
                    LastMessageLogoFormat = IconResources.wave_sound.ToBitmapImage();

                    break;

                default:
                    throw new ArgumentException("Type Not Found.");
            }

            return new ChatCardDetails(LastMessage, messagetype, LastMessageFormat, LastMessageLogoFormat, UserNameFormat);
        }

    }
}
