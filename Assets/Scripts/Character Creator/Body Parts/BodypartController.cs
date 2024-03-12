
using System;
using System.Collections.Generic;
using UnityEngine;

public class BodypartController : MonoBehaviour
{
    [SerializeField] private List<PartPlayerType> bodypartType;
    [SerializeField] private List<string> state;
    [SerializeField] private List<string> direction;
    [SerializeField] public ModelPlayer _Model;
    [SerializeField] private Animator _animatorPlayer;
    
    private AnimationClip _animationClip;
    private AnimatorOverrideController _animatorOverrideController;
    private AnimationClipOverrides _animationClipOverrides;

    public Animator AnimatorPlayer => _animatorPlayer;
    private void Awake()
    {
       // _animatorPlayer = GetComponent<Animator>();
        _animatorOverrideController = new AnimatorOverrideController(_animatorPlayer.runtimeAnimatorController);
        _animatorPlayer.runtimeAnimatorController = _animatorOverrideController;
        _animationClipOverrides = new AnimationClipOverrides(_animatorOverrideController.overridesCount);
        _animatorOverrideController.GetOverrides(_animationClipOverrides);
        UpdateBodyPart();
    }
    
    public void UpdateBodyPart()
    {
        print("Run");
        /*for (int typeIndex = 0; typeIndex < bodypartType.Count; typeIndex++)
        {
            string type = bodypartType[typeIndex].ToString();
            foreach (var partPlayer in _Model._listpartPlayer)
            {
                if(partPlayer.SoBodyPart ==null) continue;
                string partID = _Model._listpartPlayer[typeIndex].SoBodyPart.bodypartAnimationID;
                for (int stateIndex = 0; stateIndex < state.Count; stateIndex++)
                {
                    string stateName = state[stateIndex];
                    for (int direcIndex = 0; direcIndex < direction.Count; direcIndex++)
                    {
                        string directionName = direction[direcIndex];
                        _animationClip = Resources.Load<AnimationClip>("Player Animations/" + type + "/" + type + "_" +   partID + "_" + stateName + "_" + directionName);
                        _animationClipOverrides[type + "_" + 0 + "_" + stateName + "_" + directionName] = _animationClip;
                    }
                }
            }
           
        }*/

        foreach (var typebodypart in bodypartType)
        {
            string type = typebodypart.ToString();
            foreach (var partPlayer in _Model._listpartPlayer)
            {
                if(partPlayer.SoBodyPart ==null || typebodypart != partPlayer.typePartPlayer) continue;
                string partID =partPlayer.SoBodyPart.bodypartAnimationID;
                for (int stateIndex = 0; stateIndex < state.Count; stateIndex++)
                {
                    string stateName = state[stateIndex];
                    for (int direcIndex = 0; direcIndex < direction.Count; direcIndex++)
                    {
                        string directionName = direction[direcIndex];
                        _animationClip = Resources.Load<AnimationClip>("Player Animations/" + type + "/" + type + "_" +   partID + "_" + stateName + "_" + directionName);
                        _animationClipOverrides[type + "_" + 0 + "_" + stateName + "_" + directionName] = _animationClip;
                    }
                }
            }
           
        }
        
        
        _animatorOverrideController.ApplyOverrides(_animationClipOverrides);
    }
}

public class AnimationClipOverrides : List<KeyValuePair<AnimationClip, AnimationClip>>
{
    public AnimationClipOverrides(int capacity) : base(capacity) { }

    public AnimationClip this[string name]
    {
        get { return this.Find(x => x.Key.name.Equals(name)).Value; }
        set
        {
            int index = this.FindIndex(x => x.Key.name.Equals(name));
            if (index != -1)
                this[index] = new KeyValuePair<AnimationClip, AnimationClip>(this[index].Key, value);
        }
    }
}
