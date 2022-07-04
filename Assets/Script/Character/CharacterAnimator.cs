using UnityEngine;
using UnityEngine.Serialization;

namespace Script.Character
{
    public class CharacterAnimator : MonoBehaviour
    {

        [FormerlySerializedAs("MovingAnimation")] public RuntimeAnimatorController movingAnimation;
        [FormerlySerializedAs("IdleAnimation")] public RuntimeAnimatorController idleAnimation;
        [FormerlySerializedAs("HitAnimation")] public RuntimeAnimatorController hitAnimation;

        private Animator characterAnimator;

        private CharacterScript characterScript;
        // Start is called before the first frame update
        void Start()
        {
            characterAnimator = GetComponent<Animator>();
            characterScript = GetComponent<CharacterScript>();
            characterAnimator.runtimeAnimatorController = idleAnimation;
        }

        // Update is called once per frame
        void Update()
        {
            switch (characterScript.state)
            {
                case CharacterState.Chatting:
                case CharacterState.Idle:
                    characterAnimator.runtimeAnimatorController = idleAnimation;
                    break;
                case CharacterState.Moving:
                    characterAnimator.runtimeAnimatorController = movingAnimation;
                    break;
                case CharacterState.Hitted:
                    characterAnimator.runtimeAnimatorController = hitAnimation;
                    break;
            }
        }
    }
}
