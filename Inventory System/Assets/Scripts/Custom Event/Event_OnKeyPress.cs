using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Event_OnKeyPress : MonoBehaviour
{
    [SerializeField] private KeyCode _key;
    [SerializeField] private UnityEvent _onKeyPress;

    private void Update()
    {
        if (Input.GetKeyDown(_key))
        {
            _onKeyPress.Invoke();
        }
    }
}
