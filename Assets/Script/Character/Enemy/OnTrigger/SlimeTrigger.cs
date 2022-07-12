using System;
using UnityEngine;

namespace Script.Character.Enemy.OnTrigger
{
    public class SlimeTrigger : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Slime Caught :" + other.gameObject.name);
            CharacterScript character = other.GetComponent<CharacterScript>();
            character.Speed /= GamePlayProperties.SlimeSlowDownConst;
        }

        void OnTriggerExit2D(Collider2D other)
        {
            Debug.Log("Slime Release: " + other.gameObject.name);
            CharacterScript character = other.GetComponent<CharacterScript>();
            character.Speed *= GamePlayProperties.SlimeSlowDownConst;
            
            SingletonDontDestroy.Instance.RunAfterSec(() =>
                {
                    try
                    {
                        gameObject.GetComponent<Fader>()?.Die();
                    }
                    catch (Exception e)
                    {
                        Debug.Log(e);
                    }
                },

            GamePlayProperties.SlimeExistTime);
            
        }
    }
}