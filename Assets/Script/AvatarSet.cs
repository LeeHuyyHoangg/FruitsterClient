using UnityEngine;

public class AvatarSet
{
    public string AvatarName { get; private set;}
    public string AvatarDescription{ get; private set;}
    
    public RuntimeAnimatorController IdleAnimation{ get; private set;}
    public RuntimeAnimatorController RunAnimation{ get; private set;}
    public RuntimeAnimatorController HitAnimation{ get; private set;}
    public AvatarSet(string avatarName)
    {
        AvatarName = avatarName;
        AvatarDescription = (Resources.Load("AvatarSet/" + avatarName + "/" + avatarName + "Description") as TextAsset)?.text;
        
        IdleAnimation = Resources.Load("AvatarSet/" + avatarName + "/" + avatarName + "_Idle") as RuntimeAnimatorController;
        RunAnimation = Resources.Load("AvatarSet/" + avatarName + "/" + avatarName + "_Run") as RuntimeAnimatorController;
        HitAnimation = Resources.Load("AvatarSet/" + avatarName + "/" + avatarName + "_Hit") as RuntimeAnimatorController;
    }
}