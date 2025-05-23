using System.Collections.Generic;
using UnityEngine;
using System;

public class StateController : MonoBehaviour
{
    [HideInInspector] public CustomVariableSets customVariables = new();
    [NaughtyAttributes.ReadOnly][SerializeField] protected StateSO _currentState;
    public StateSO CurrentState { get => _currentState; }
    [HideInInspector] public List<Coroutine> FrameActionSequences = new(36);
    [HideInInspector] public List<Coroutine> TransitionSequences = new(36);
    [HideInInspector] public List<bool> TransitionConditions = new(36);
    private readonly Dictionary<Type, object> _interfaces = new();

    protected virtual void Awake()
    {
        for (int i = 0; i < 36; i++)
        {
            FrameActionSequences.Add(null);
            TransitionSequences.Add(null);
            TransitionConditions.Add(false);
        }
    }

    public void RegisterInterface<T>(T implementation) where T : class
    {
        _interfaces[typeof(T)] = implementation;
    }

    public T GetInterface<T>() where T : class
    {
        if (_interfaces.TryGetValue(typeof(T), out var implementation))
        {
            return implementation as T;
        }
        return null;
    }

    public bool TryGetInterface<T>(out T item) where T : class
    {
        if (_interfaces.TryGetValue(typeof(T), out var implementation))
        {
            item = implementation as T;
            return true;
        }
        else
        {
            item = default;
            return false;
        }
    }

    public virtual void ChangeState(StateSO state)
    {
        _currentState.ExitState(this);
        state.EnterState(this);
        _currentState = state;
    }

    public void UpdateState()
    {
        _currentState.UpdateState(this);
        //Debug.Log("CheckTransition: " + _currentState.name);
        _currentState.CheckTransition(this);
    }

    public void Update()
    {
        UpdateState();
    }

    public void Initialize(StateMachineSO stateMachine)
    {
        if (stateMachine == null)
        {
            Debug.LogError("ERROR: StateMachine missing!!!");
            return;
        }
        _currentState = stateMachine.initialState;
        _currentState.EnterState(this);
        customVariables = stateMachine.customVariables;
        //////
        ///  HAVE TO FIX THIS NOT TO DEEP REFERENCE CUSTOMVARS!!!
        //////
    }

    public void SetBoolParameterTrue(string name)
    {
        if (!customVariables.boolVariables.ContainsKey(name))
        {
            Debug.LogWarning("Warning: Generated missing variable: " + name);
            customVariables.boolVariables[name] = new() { Value = true };
        }
        else
            customVariables.boolVariables[name].Value = true;
    }

    public void SetBoolParameterFalse(string name)
    {
        if (!customVariables.boolVariables.ContainsKey(name))
        {
            Debug.LogWarning("Warning: Generated missing variable: " + name);
            customVariables.boolVariables[name] = new() { Value = false };
        }
        else
            customVariables.boolVariables[name].Value = false;
    }

    public void SetIntParameter(string name, int value)
    {
        customVariables.intVariables[name].Value = value;
    }

    public bool GetBoolParameter(string name)
    {
        if (!customVariables.boolVariables.ContainsKey(name))
        {
            Debug.LogWarning("Warning: Generated missing variable: " + name);
            customVariables.boolVariables[name] = new() { Value = false };
        }

        return customVariables.boolVariables[name].Value;
    }
}