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

	private CinemachineVirtualCamera camera;
	private readonly Dictionary<string, GameObject> idToGameObject = new Dictionary<string, GameObject>();

	private readonly Dictionary<string, (int, GameObject)> playerIdToPlayerScore = new Dictionary<string, (int, GameObject)>();

	private Tilemap tilemap;
	// Start is called before the first frame update
	private void Awake()
	{
		tilemap = GameObject.Find( "Tilemap" ).GetComponent<Tilemap>();
		camera = GameObject.Find( "CM vcam1" ).GetComponent<CinemachineVirtualCamera>();
		Debug.Log( tilemap );
		Debug.Log( camera );
		foreach (GameObject fGameObject in userStatistic)
		{
			fGameObject.SetActive( false );
		}
	}

	private void Start()
	{
		for( int i = 0; i < UserProperties.UserRoom.Players?.Count; i++ )
		{
			playerIdToPlayerScore.Add( UserProperties.UserRoom.Players[i].userID, ( 0, userStatistic[i] ) );
			userStatistic[i].transform.Find( "UserName" ).GetComponent<TMP_Text>().text = UserProperties.UserRoom.Players[i].userName + " :";
			userStatistic[i].transform.Find( "UserScore" ).GetComponent<TMP_Text>().text = 0 + "";
			userStatistic[i].SetActive( true );
		}
	}

	// Update is called once per frame
	private void Update()
	{

	}

	public void AddScore( string userID, int score )
	{
		if( playerIdToPlayerScore.ContainsKey( userID ) )
		{
			score += playerIdToPlayerScore[userID].Item1;
			GameObject scoreText = playerIdToPlayerScore[userID].Item2;
			scoreText.transform.Find( "UserScore" ).GetComponent<TMP_Text>().text = score + "";
			playerIdToPlayerScore[userID] = ( score, scoreText );
		}
	}

	public void InitPlayer( List<PlayerInitState> playerInitStateList )
	{
		foreach (PlayerInitState playerInitState in playerInitStateList)
		{
			foreach (User player in UserProperties.UserRoom.Players)
			{
				if( player.userID == playerInitState.id )
				{
					GameObject gameObject = Instantiate( AvatarSetManager.Instance.GetAsset( player.avatar ).AvatarPrefab,
						tilemap.CellToWorld( new Vector3Int( playerInitState.locationX, playerInitState.locationY, 0 ) ), Quaternion.identity );

					if( gameObject.GetComponent<ObjectScript>() == null )
					{
						gameObject.AddComponent<ObjectScript>();
					}

					gameObject.GetComponent<ObjectScript>().id = player.userID;

					idToGameObject.Add( player.userID, gameObject );
					break;
				}
			}
		}
	}

	public void SpawnEnemy( string id, string type, Vector3Int position)
	{
		if(EnemyManager.Instance.HasEnemy(type))
		{
			Vector3 realLocation = tilemap.CellToWorld( position );
			GameObject instantiate = Instantiate( EnemyManager.Instance.GetEnemy( type ), realLocation, Quaternion.identity );
			if( instantiate.GetComponent<ObjectScript>() == null )
			{
				instantiate.AddComponent<ObjectScript>();
			}
			instantiate.GetComponent<ObjectScript>().id = id;
			idToGameObject.Add( id, instantiate );
		}
	}

	public void SpawnItem( string id, string type, Vector3Int position )
	{
		if(ItemManager.Instance.HasItem(type))
		{
			Vector3 realLocation = tilemap.CellToWorld( position );
			GameObject instantiate = Instantiate( ItemManager.Instance.GetItem( type ), realLocation, Quaternion.identity );
			if( instantiate.GetComponent<ObjectScript>() == null )
			{
				instantiate.AddComponent<ObjectScript>();
			}
			instantiate.GetComponent<ObjectScript>().id = id;
			idToGameObject.Add( id, instantiate );
		}
	}
}