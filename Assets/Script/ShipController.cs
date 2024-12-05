using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float speed = 10f;

    [Header("Missile")]
    public GameObject missile;
    public Transform missilespawnposition;
    public float destoryTime;
    public Transform muzzleSpawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerShoot();
    }

    void PlayerMovement()
    {

        float xpos = Input.GetAxis("Horizontal");
        float ypos = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(xpos, ypos, 0) * speed * Time.deltaTime;

        transform.Translate(movement);
    }

    void PlayerShoot()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SpawnMissle();
            SpawnMuzzleFlash();
        }
    }

    void SpawnMissle()
    {
        GameObject gm = Instantiate(missile, missilespawnposition);
        
        gm.transform.SetParent(null);
        Destroy(gm, destoryTime);
    }

    void SpawnMuzzleFlash()
    {
        GameObject muzzle = Instantiate(GameManager.instance.MuzzleFlash, muzzleSpawnPosition);
        muzzle.transform.SetParent(null);
        Destroy(muzzle, destoryTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject gm = Instantiate(GameManager.instance.explosion, transform.position, transform.rotation);
            Destroy(gm, 2f);
            Destroy(this.gameObject);
            Debug.Log("Game Over");
        }
    }
}
