using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessagePopper : MonoBehaviour
{

    public GameObject startText;
    public float hideAfterTimer = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(HideAfter());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator HideAfter()
    {
        startText.SetActive(true);
        yield return new WaitForSeconds(hideAfterTimer);
        startText.SetActive(false);

        yield return 0;
        
    }
}
