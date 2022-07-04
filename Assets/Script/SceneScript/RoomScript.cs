using System;
using System.Collections.Generic;
using Script;
using Script.Messages.CsMessages;
using Script.Model;
using UnityEngine;
using UnityEngine.UI;

public class RoomScript : SingletonMonoBehavior<RoomScript>
{
    public List<Room> rooms = new List<Room>();

    [SerializeField] private List<Button> roomButtons;

    [SerializeField] private InputField createRoomName;
    [SerializeField] private InputField createRoomPass;
    
    [SerializeField] private InputField joinRoomId;
    [SerializeField] private InputField joinRoomPass;
    // Start is called before the first frame update
    void Start()
    {
        Refresh();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i =0 ; i< roomButtons.Count; i++)
        {
            if (i >= rooms.Count)
            {
                roomButtons[i].gameObject.SetActive(false);
            }
            else
            {
                roomButtons[i].gameObject.SetActive(true);
                roomButtons[i].transform.Find("RoomSize").GetComponent<Text>().text = rooms[i].numberOfMembers + "/" + GamePlayProperties.MaxMemberNumber;
                roomButtons[i].transform.Find("RoomName").GetComponent<Text>().text = rooms[i].roomName;
                Room room = rooms[i];
                roomButtons[i].onClick.AddListener(()=>
                {
                    if (!room.hasPass)
                    {
                        JoinRoom(room.roomID,null);
                    }
                    else
                    {
                        
                    }
                });
            }
        }
    }

    public void Refresh()
    {
        AppProperties.ServerSession.SendMessage(new CsGetRoomList(5));
    }

    public void CreateRoom()
    {
        UserProperties.UserRoom = new Room(null, createRoomName.text,String.IsNullOrEmpty(createRoomPass.text),1);

        AppProperties.ServerSession.SendMessage(new CsCreateRoom(createRoomName.text,createRoomPass.text));
    }
    
    public void JoinRoom()
    {
        UserProperties.UserRoom = new Room(joinRoomId.text,null,String.IsNullOrEmpty(joinRoomPass.text),1);
        AppProperties.ServerSession.SendMessage(new CsCreateRoom(joinRoomId.text,joinRoomPass.text));
    }

    void JoinRoom(string roomId, string pass)
    {
        UserProperties.UserRoom = new Room(joinRoomId.text,null,String.IsNullOrEmpty(pass),1);
        AppProperties.ServerSession.SendMessage(new CsCreateRoom(joinRoomId.text,joinRoomPass.text));
    }
}
