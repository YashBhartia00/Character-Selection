using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float fallMultiplier = 4,lowJumpMultiplier = 6f, jspeed = 5f;
    Rigidbody2D rb;
    public GameObject bulletPrefab, characterSelect;
    public UI_BarManager health, stamina;

    public Character player;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") <0)
        {transform.right = new Vector2(-1,0);} else if(Input.GetAxisRaw("Horizontal") >0){transform.right = new Vector2(1,0); }

        rb.velocity= new Vector3(Input.GetAxisRaw("Horizontal") *player.speed*(Input.GetKey(KeyCode.LeftShift) && stamina.currentValue>0?2 :1) , rb.velocity.y ,0);
        jump();
        if(Input.GetKey(KeyCode.LeftShift)){stamina.currentValue-=2;} else{stamina.currentValue+=1;}

        if(Input.GetKeyDown(KeyCode.Space)){StartCoroutine( Attack(player.bulletSpeed,player.range,player.numberOfBullets));}

        if(Input.GetKeyDown(KeyCode.Escape)){CharacterSelect.pauseState=true;characterSelect.SetActive(true);transform.parent.gameObject.SetActive(false);}
    }

    void jump(){

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity= Vector2.up*jspeed;
        }
        if(rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
         else if(rb.velocity.y>0 && !(Input.GetKey(KeyCode.UpArrow) ))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    IEnumerator Attack(float speed, float range, int numberOfBullets)
    {
        for(int i =0; i<numberOfBullets;i++){
            GameObject bullet = Instantiate(bulletPrefab,transform.GetChild(0).position,Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = transform.right*player.bulletSpeed;
            StartCoroutine(delayedDestroy(bullet,player.range/player.bulletSpeed));
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator delayedDestroy(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(obj);
    }


    public void updateData()
    {
        health.MaxValue = player.maxHealth;
        stamina.MaxValue = player.maxStamina;
        health.currentValue = player.maxHealth;
        stamina.currentValue = player.maxStamina;
        gameObject.GetComponent<SpriteRenderer>().color = player.color;
    }
}
