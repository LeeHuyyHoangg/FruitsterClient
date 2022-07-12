using System;
using System.Collections.Generic;
using Script.Character;
using Script.Messages.CsMessages;
using Script.Model;
using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class RoomSceneScript : SingletonMonoBehavior<RoomSceneScript>
    {
        private const int ChatBubbleExistTime = 3000;
        [SerializeField] private List<Text> userNames;
        [SerializeField] private List<GameObject> avatarLocations;

        [SerializeField] private List<GameObject> userChatBubbles;

        //name -> chat bubble -> gameObject
        private readonly Dictionary<string, (Text, GameObject, GameObject)> userIdObjects = new Dictionary<string, (Text, GameObject, GameObject)>();
        private void Start()
        {
            AppProperties.ServerSession.SendMessage(new CsGetRoom(UserProperties.UserRoom.RoomID));
            foreach (var chatBubble in userChatBubbles)
            {
                chatBubble.SetActive(false);
            }
        }

        public void RefreshRoom()
        {
            foreach (var tuples in userIdObjects.Values)
            {
                try
                {
                    Destroy(tuples.Item3);
                }
                catch (Exception e)
                {
                    Debug.Log(e);
                }
            }
            userIdObjects.Clear();
            int i;
            for (i = 0; i < UserProperties.UserRoom.Players.Count; i++)
            {
                User player = UserProperties.UserRoom.Players[i];
                GameObject playerGameObject = Instantiate(AvatarSetManager.Instance.GetAsset(player.avatar).AvatarPrefab, avatarLocations[i].transform);
                userNames[i].text = player.userName;
                userIdObjects.Add(player.userID, (userNames[i], userChatBubbles[i], playerGameObject));
            }
        }

        public void LeaveRoom()
        {
            AppProperties.ServerSession.SendMessage(new CsLeaveRoom());
        }

        public void StartGame()
        {
            // throw new NotImplementedException();
        }

        public void Chat(Text text)
        {
            AppProperties.ServerSession.SendMessage(new CsChat(text.text));
            text.text = "";
        }

        public void RemoteChat(String userId, String message)
        {
            SingletonDontDestroy.Instance.DoAction(() =>
            {
                var chatBubbleObject = userIdObjects[userId].Item2;
                chatBubbleObject.GetComponentInChildren<Text>().text = message;
                chatBubbleObject.SetActive(true);

                RunAfterMillisSec(() =>
                {
                    try
                    {
                        chatBubbleObject.SetActive(false);
                    }
                    catch (Exception)
                    {
                        //ignored
                    }
                }, ChatBubbleExistTime);
            });
        }
    }
}