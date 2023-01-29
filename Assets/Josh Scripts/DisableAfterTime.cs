using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterTime : MonoBehaviour
{
    [SerializeField] float timeToDisable = 0.4f;
    float timer;

    // Start is called before the first frame update
    private void OnEnable()
    {
        timer = timeToDisable;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            gameObject.SetActive(false);
        }
    }
}
