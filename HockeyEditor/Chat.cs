using System.Collections.Generic;

namespace HockeyEditor
{
    public static class Chat
    {
        const int CHAT_OPEN = 0x07CAAFE0;
        const int CHATMESSAGE = 0x07126C00;

        const int CUR_CHAT_INDEX = 0x0451B5E0;
        const int CHAT_MESSAGES_ADDRESS = 0x07126348;
        const int CHAT_STRUCT_SIZE = 0x94;

        /// <summary>
        /// Send a message to chat from local player
        /// </summary>
        /// <param name="message">the message to send, only the first 63 characters will be shown</param>
        public static void SendChatMessage(string message)
        {
            MemoryEditor.WriteInt(CHAT_OPEN, 0);
            MemoryEditor.WriteString(CHATMESSAGE, message);
        }


        /// <summary>
        /// The last 8 messages sent to chat, in chronological order
        /// </summary>
        public static List<ChatMessage> Messages
        {
            get
            {
                List<ChatMessage> messages = new List<ChatMessage>();
                int index = MemoryEditor.ReadInt(CUR_CHAT_INDEX);
                for (int i = 0; i < 8; i++)
                {
                    messages.Add(new ChatMessage(CHAT_MESSAGES_ADDRESS + index * CHAT_STRUCT_SIZE));
                    index = (++index % 8);
                }
                return messages;
            }
        }

        public class ChatMessage
        {
            const int PLAYERID_OFFSET = 0x8;
            const int MESSAGE_OFFSET = 0xC;
            const int MAX_MESSAGE_LENGTH = 70;

            public int SenderID;
            public string Message;
            public string SenderName;

            internal ChatMessage(int address)
            {
                SenderID = MemoryEditor.ReadInt(address + PLAYERID_OFFSET);
                Message = MemoryEditor.ReadString(address + MESSAGE_OFFSET, MAX_MESSAGE_LENGTH);

                if (Message.Contains(":"))
                {
                    SenderName = Message.Substring(0, Message.IndexOf(":"));
                }
                else
                    SenderName = "Server Message";

                //cut username from message
                Message = Message.Substring(Message.IndexOf(':') + 1).TrimStart(' ');
            }
        }
    }
}
