using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : CharacterBase
{
    //#TODO Remove later, just for testing purpose
    public float movSpeed = 5f;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * movSpeed, 0, Input.GetAxis("Vertical") * Time.deltaTime * movSpeed));
    }
}
