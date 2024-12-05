using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpeed : MonoBehaviour
{
    public float missilespeed = 50f;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * missilespeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject gm = Instantiate(GameManager.instance.explosion, transform.position,transform.rotation);
            Destroy(gm, 2f);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
