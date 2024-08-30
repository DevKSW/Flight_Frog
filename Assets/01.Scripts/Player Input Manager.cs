using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InputClass
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public KeyCode PositiveKey { get; set; }
    [field: SerializeField] public KeyCode NegativeKey { get; set; }
    [field: SerializeField] public bool isDualKey { get; set; }
    [field: SerializeField] public float Value { get; private set; }

    public InputClass(string name, KeyCode positiveKey,bool isDualKey = false,KeyCode negativeKey = KeyCode.None)
    {
        Name = name;
        PositiveKey = positiveKey;
        this.isDualKey = isDualKey;
        if (isDualKey)
            NegativeKey = negativeKey;
        Value = 0;
    }
    
    public void GetInput()
    {
        if (Input.GetKey(PositiveKey))
        {
            Value = 1;
        }
        else if (isDualKey && Input.GetKey(NegativeKey))
        {
            Value = -1;
        }
        else
        {
            Value = 0;
        }
    }
    public void SetName(string name)
    {
        this.Name = name;
    }
    
}



public class PlayerInputManager : MonoBehaviour
{
    #region InputClasses
    
    private List<InputClass> inputList;
    
    private InputClass _thrustInput = new InputClass("Thrust",KeyCode.W);
    private InputClass _pitchInput = new InputClass("Pitch",KeyCode.Space,true,KeyCode.S);
    private InputClass _rollInput = new InputClass("Roll",KeyCode.E,true,KeyCode.Q);
    private InputClass _yawInput = new InputClass("Yaw", KeyCode.D, true, KeyCode.A);
    
    #endregion
    
    public float ThrustInput
    {
        get => _thrustInput.Value;
    }
    public float PitchInput
    {
        get => _pitchInput.Value;
    }
    public float RollInput
    {
        get => _rollInput.Value;
    }
    public float YawInput
    {
        get => _yawInput.Value;
    }
    
    #region UnityFuncs

    private void Awake()
    {
        inputList.Add(_thrustInput);
        inputList.Add(_yawInput);
        inputList.Add(_rollInput);
        inputList.Add(_pitchInput);
    }

    private void Update()
    {
        //Get Inputs
        foreach (var input in inputList)
        {
            input.GetInput();   
        }
        
    }

    
    
    #endregion
    
}
