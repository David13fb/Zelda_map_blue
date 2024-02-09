using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DropitemScrips : MonoBehaviour
{
    [SerializeField] GameObject rupee;
    [SerializeField] GameObject heart;
    [SerializeField] int drop;
    private Transform _transform;
   
    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;
      
    }

    // Update is called once per frame
   public void DropItem()
    {
     
            Debug.Log("jajaj");
            if (drop ==1)
            {
                Instantiate(rupee, transform.position, _transform.rotation);
            }
            if (drop == 2)
            {
                Instantiate(heart, transform.position, _transform.rotation);
            }
        
    }
}
