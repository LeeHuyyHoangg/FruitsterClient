using System.Collections;
using System.Collections.Generic;
using System.IO;
using Script;
using UnityEngine;
using UnityEngine.UI;

public class CharacterAvatarScript : MonoBehaviour
{
    private static int _userSelection = 0;
    private static List<AvatarSet> _avatarSets = new List<AvatarSet>();

    [SerializeField] private Text userName;
    
    [SerializeField] private Animator avatarImage;
    [SerializeField] private Text avatarLabel;
    [SerializeField] private Text avatarDescription;
    // Start is called before the first frame update
    void Start()
    {
        userName.text = UserProperties.UserName;
        
        string[] lines = File.ReadAllLines(Path.Combine(Application.streamingAssetsPath, "AvatarConfig.txt"));
        foreach (var line in lines)
        {
            _avatarSets.Add(new AvatarSet(line));
        }

        UserProperties.UserAvatarSet = _avatarSets[0];
    }

    // Update is called once per frame
    void Update()
    {
        avatarImage.runtimeAnimatorController = UserProperties.UserAvatarSet.IdleAnimation;
        avatarLabel.text = UserProperties.UserAvatarSet.AvatarName;
        avatarDescription.text = UserProperties.UserAvatarSet.AvatarDescription;
        
    }

    public void ChooseIncrease()
    {
        _userSelection++;
        if (_userSelection >= _avatarSets.Count)
        {
            _userSelection -= _avatarSets.Count;
        }

        UserProperties.UserAvatarSet = _avatarSets[_userSelection];
        UpdateAvatar();
    }
    
    public void ChooseDecrease()
    {
        _userSelection--;
        if (_userSelection < 0)
        {
            _userSelection = _avatarSets.Count - 1;
        }

        UserProperties.UserAvatarSet = _avatarSets[_userSelection];
        UpdateAvatar();
    }

    private void UpdateAvatar()
    {
        avatarImage.runtimeAnimatorController = UserProperties.UserAvatarSet.IdleAnimation;
        avatarLabel.text = UserProperties.UserAvatarSet.AvatarName;
        avatarDescription.text = UserProperties.UserAvatarSet.AvatarDescription;
    }
}
