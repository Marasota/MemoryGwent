using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartWinterScene()
    {
        Application.LoadLevel("WinterScene");
    }

    public void StartSpringScene()
    {
        Application.LoadLevel("SpringScene");
    }

    public void StartAutumnScene()
    {
        Application.LoadLevel("AutumnScene");
    }

    public void StartSummerScene()
    {
        Application.LoadLevel("SummerScene");
    }
}
