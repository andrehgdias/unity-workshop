using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    [SerializeField] private float slowMotionValue = .2f;
    private float fixedDeltaTime;

    void Awake()
    {
        // Make a copy of the fixedDeltaTime, it defaults to 0.02f, but it can be changed in the editor
        fixedDeltaTime = Time.fixedDeltaTime;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.CapsLock))
        {
            Time.timeScale = slowMotionValue;
            Time.fixedDeltaTime = fixedDeltaTime * Time.timeScale;
        }
        else Time.timeScale = 1.0f;

    }
}
