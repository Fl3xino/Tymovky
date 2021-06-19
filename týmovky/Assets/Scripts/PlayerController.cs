 using UnityEngine;
 using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{



    public float bulletspeed;
    public GameObject  bulletPrefab;
    private float lastfire;
    public float firedelay;
    public Text collectedText;
    public static int collectedAmount = 0;

    void Update()
    {
        firedelay = GameController.FireRate;
        collectedText.text = "Items collected: " + collectedAmount;
        float shootHor = Input.GetAxisRaw("ShootHorizontal");
        float shootVert = Input.GetAxisRaw("ShootVertical");
        if((shootHor != 0 || shootVert != 0) && Time.time > lastfire + firedelay)
        {
            Shoot(shootHor, shootVert);
            lastfire = Time.time;
        }

    }

    void Shoot(float x, float y)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
        bullet.AddComponent<Rigidbody2D>().gravityScale = 0;
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(
            (x < 0) ? Mathf.Floor(x) * bulletspeed : Mathf.Ceil(x) * bulletspeed,
            (y < 0) ? Mathf.Floor(y) * bulletspeed : Mathf.Ceil(y) * bulletspeed,
            0
        );
    }

}
