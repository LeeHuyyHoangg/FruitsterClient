using System;
using System.Linq;
using Newtonsoft.Json;
using Script.Messages;
using UnityEngine;

namespace Script.Utils
{
    public static class JsonUtils
    {
        public static string MessageToJson(Message message)
        {
            var json = JsonConvert.SerializeObject(message);
            return message.GetMessageType() + json;
        }

        public static Message JsonToMessage(string json)
        {
            var messageTypeLength = json.IndexOf('{');
            var messageType = AppDomain.CurrentDomain.GetAssemblies().Reverse().SelectMany(t => t.GetTypes()).First(t =>
                string.Equals(t.Name, json.Substring(0, messageTypeLength), StringComparison.Ordinal));
            Debug.Log("Message type: " + json.Substring(0, messageTypeLength));
            Debug.Log("Message data: " + json.Substring(messageTypeLength, json.Length - messageTypeLength));
            if (!messageType.IsSubclassOf(typeof(Message)))
                return null;
            return (Message) JsonConvert.DeserializeObject(
                json.Substring(messageTypeLength, json.Length - messageTypeLength), messageType);
        }
    }
}