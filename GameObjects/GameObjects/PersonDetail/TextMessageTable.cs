namespace GameObjects.PersonDetail
{
    using GameObjects;
    using System;
    using System.Collections.Generic;

    public class TextMessageTable
    {
        public Dictionary<int, TextMessage> TextMessages = new Dictionary<int, TextMessage>();

        public bool AddTextMessage(TextMessage textMessage)
        {
            if (this.TextMessages.ContainsKey(textMessage.ID))
            {
                return false;
            }
            this.TextMessages.Add(textMessage.ID, textMessage);
            return true;
        }

        public void Clear()
        {
            this.TextMessages.Clear();
        }

        public TextMessage GetTextMessage(int textMessageID)
        {
            TextMessage message = null;
            this.TextMessages.TryGetValue(textMessageID, out message);
            return message;
        }

        public GameObjectList GetTextMessageList()
        {
            GameObjectList list = new GameObjectList();
            foreach (TextMessage message in this.TextMessages.Values)
            {
                list.Add(message);
            }
            return list;
        }

        public void LoadFromString(TextMessageTable allTextMessages, string textMessageIDs)
        {
            char[] separator = new char[] { ' ', '\n', '\r' };
            string[] strArray = textMessageIDs.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            TextMessage message = null;
            for (int i = 0; i < strArray.Length; i++)
            {
                if (allTextMessages.TextMessages.TryGetValue(int.Parse(strArray[i]), out message))
                {
                    this.AddTextMessage(message);
                }
            }
        }

        public string SaveToString()
        {
            string str = "";
            foreach (TextMessage message in this.TextMessages.Values)
            {
                str = str + message.ID.ToString() + " ";
            }
            return str;
        }

        public int Count
        {
            get
            {
                return this.TextMessages.Count;
            }
        }
    }
}

