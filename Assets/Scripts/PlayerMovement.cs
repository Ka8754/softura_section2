using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public GameObject _otherObj;
    public bool _insideProximityZone = false;

    void Update()
    {

   
        this.transform.LookAt(_otherObj.transform);

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontal, 0, vertical);
        movementDirection.Normalize();

        transform.position += movementDirection * speed * Time.deltaTime;

        this.transform.LookAt(_otherObj.transform);
        //Debug.LogError(Vector3.Distance(_otherObj.transform.position, this.transform.position));


        //Bool Set
        if ((Vector3.Distance(_otherObj.transform.position, this.transform.position) < 5) && !_insideProximityZone)
        {
            this.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            _insideProximityZone = true;
        }
        
        //Bool Reset
        if((Vector3.Distance(_otherObj.transform.position, this.transform.position) >= 5))
        {
            _insideProximityZone = false;
        }

    }
}
