using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ParallaxScript : MonoBehaviour
{

    public GameObject cam;
    public float parallaxSpeed = -0.5f;
    private float bgWidth, bgTotalWidth;
    private GameObject bgCloneObj;
    private bool isObjCloned = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bgWidth = GetComponent<SpriteRenderer>().bounds.extents.x * 2;
        //bgWidth = GetComponent<SpriteRenderer>().bounds.size.x; This is the previous script with the gap
        bgTotalWidth = bgWidth * 2;

        if (isObjCloned == false)
        {
            float bgClonePositionX = transform.position.x + bgWidth;

            Vector3 bgClonePosition = new Vector3(transform.position.x + bgTotalWidth / 2, transform.position.y, transform.position.z);
            //Vector3 bgClonePosition = transform.position + new Vector3(bgClonePositionX, 0, 0) Previous Script

            bgCloneObj = Instantiate(gameObject, bgClonePosition, transform.rotation);

            bgCloneObj.transform.SetParent(transform.parent);

            bgCloneObj.transform.localScale = transform.localScale;

            //Preventing cloning loop
            isObjCloned = true;
            Destroy(bgCloneObj.GetComponent<ParallaxScript>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        float newPositionX = Time.deltaTime * parallaxSpeed;
        transform.position = transform.position + new Vector3(newPositionX, 0, 0);

        bgCloneObj.transform.position = bgCloneObj.transform.position + new Vector3(newPositionX, 0, 0);

        if (gameObject.transform.position.x < -bgTotalWidth / 2)
        {
            ResetPosition(gameObject);
        }

        if (bgCloneObj.transform.position.x < -bgTotalWidth / 2)
        {
            ResetPosition(bgCloneObj);
        }
    }

    void ResetPosition(GameObject obj)
    {
        float resetPositionX = obj.transform.position.x + bgTotalWidth;
        obj.transform.position = new Vector3(resetPositionX, transform.position.y, transform.position.z);
    }

}

