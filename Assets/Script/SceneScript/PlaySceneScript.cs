using System.Collections.Generic;
using Cinemachine;
using Script;
using Script.Character;
using Script.Model;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlaySceneScript : SingletonMonoBehavior<PlaySceneScript>
{
    [SerializeField] private List<GameObject> userStatistic;
    private Dictionary<string,GameObject> idToGameObject = new Dictionary<string, GameObject>();

    private Dictionary<string, (int, GameObject)> playerIdToPlayerScore = new Dictionary<string, (int, GameObject)>();

    private Tilemap tilemap;

    private CinemachineVirtualCamera camera;
    // Start is called before the first frame update
    void Awake()
    {
        tilemap = GameObject.Find("Tilemap").GetComponent<Tilemap>();
        camera = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        Debug.Log(tilemap);
        Debug.Log(camera);
        foreach (var fGameObject in userStatistic)
        {
            fGameObject.SetActive(false);
        }
    }

    private void Start()
    {
        for (int i = 0 ; i < UserProperties.UserRoom.Players?.Count;i++)
        {
            playerIdToPlayerScore.Add(UserProperties.UserRoom.Players[i].userID, (0,userStatistic[i]));
            userStatistic[i].transform.Find("UserName").GetComponent<TMP_Text>().text = UserProperties.UserRoom.Players[i].userName + " :";
            userStatistic[i].transform.Find("UserScore").GetComponent<TMP_Text>().text = 0 + "";
            userStatistic[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(string userID, int score)
    {
        if (playerIdToPlayerScore.ContainsKey(userID))
        {
            score += playerIdToPlayerScore[userID].Item1;
            GameObject scoreText = playerIdToPlayerScore[userID].Item2;
            scoreText.transform.Find("UserScore").GetComponent<TMP_Text>().text = score + "";
            playerIdToPlayerScore[userID] = (score, scoreText);
        }
    }

    public void InitPlayer(List<PlayerInitState> playerInitStateList)
    {
        foreach (var playerInitState in playerInitStateList)
        {
            foreach (var player in UserProperties.UserRoom.Players)
            {
                if (player.userID == playerInitState.id)
                {
                    GameObject gameObject = Instantiate(AvatarSetManager.Instance.GetAsset(player.avatar).AvatarPrefab,
                        tilemap.CellToWorld(new Vector3Int(playerInitState.locationX, playerInitState.locationY, 0)), Quaternion.identity);

                    if (gameObject.GetComponent<ObjectScript>() == null)
                    {
                        gameObject.AddComponent < ObjectScript>();
                    }

                    gameObject.GetComponent<ObjectScript>().id = player.userID;
                    
                    idToGameObject.Add(player.userID, gameObject);
                    break;
                }
            }
        }
    }
}
