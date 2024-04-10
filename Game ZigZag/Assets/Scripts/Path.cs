using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public GameObject prefabPath;
    public Vector3 lastPosition;

    public float diference = 0.7071068f;
    private int AmountPath = 0;

    public void StartBuild()
    {
        InvokeRepeating("AddNewPath", 1f, 0.5f);
    }

    public void AddNewPath()
    {
        Vector3 newPosition = Vector3.zero;
        float option = Random.Range(0, 100);

        if (option <= 50)
        {
            newPosition = new Vector3(lastPosition.x + diference, lastPosition.y, lastPosition.z + diference);                                   
        }
        else
        {
            newPosition = new Vector3(lastPosition.x - diference, lastPosition.y, lastPosition.z + diference);
        }

        GameObject g = Instantiate(prefabPath, newPosition, Quaternion.Euler(0, 45, 0));
        lastPosition = g.transform.position;

        AmountPath++;
        float optionCrystal = Random.Range(0, 10);
        print(optionCrystal);
        print(AmountPath);
        if(AmountPath % 5 == 0 && optionCrystal == 5)
        {
            g.transform.GetChild(1).gameObject.SetActive(true); 
        }
        else if(AmountPath % 5 == 0)
        {
            g.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
