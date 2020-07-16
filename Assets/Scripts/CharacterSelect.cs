using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    public Character[] characterOptions; //0th for max values

    public UI_BarManager maxHealth,maxStamina,speed,range,bulletSpeed;
    public Text characterName, numberOfBullets;
    
    public static bool pauseState = true;


    void Start()
    {
        
        //initialize all this in inspector but it's bugging
        characterOptions = new Character[6];
        characterOptions[0] = new Character{characterName = "maxSheet",
                                            maxHealth = 200, 
                                            maxStamina= 200, 
                                            speed = 10, 
                                            range = 30, 
                                            bulletSpeed = 40, 
                                            numberOfBullets = 10,
                                            color = Color.white };

        characterOptions[1] = new Character{characterName = "Basic",
                                            maxHealth = 100,
                                            maxStamina= 50, 
                                            speed = 5, 
                                            range = 5, 
                                            bulletSpeed = 10, 
                                            numberOfBullets = 3,
                                            color = Color.white };

        characterOptions[2] = new Character{characterName = "Sniper",
                                            maxHealth = 70, 
                                            maxStamina= 50, 
                                            speed = 5, 
                                            range = 30, 
                                            bulletSpeed = 40, 
                                            numberOfBullets = 1,
                                            color = Color.gray };

        characterOptions[3] = new Character{characterName = "Tank",
                                            maxHealth = 200, 
                                            maxStamina= 70, 
                                            speed = 3, 
                                            range = 5, 
                                            bulletSpeed = 5, 
                                            numberOfBullets = 2,
                                            color = Color.red  };

        characterOptions[4] = new Character{characterName = "Speedy",
                                            maxHealth = 100, 
                                            maxStamina= 200, 
                                            speed = 10, 
                                            range = 3, 
                                            bulletSpeed = 5, 
                                            numberOfBullets = 4,
                                            color = Color.green  };

        characterOptions[5] = new Character{characterName = "Machine Gun",
                                            maxHealth = 100, 
                                            maxStamina= 20, 
                                            speed = 3, 
                                            range = 15, 
                                            bulletSpeed = 15, 
                                            numberOfBullets = 10,
                                            color = Color.blue  };
    }

    void Update()
    {
        maxHealth.currentValue=characterOptions[scroll.curretPos+1].maxHealth*100/characterOptions[0].maxHealth;
        maxStamina.currentValue=characterOptions[scroll.curretPos+1].maxStamina*100/characterOptions[0].maxStamina;
        speed.currentValue=characterOptions[scroll.curretPos+1].speed*100/characterOptions[0].speed;
        range.currentValue=characterOptions[scroll.curretPos+1].range*100/characterOptions[0].range;
        bulletSpeed.currentValue=characterOptions[scroll.curretPos+1].bulletSpeed*100/characterOptions[0].bulletSpeed;
        characterName.text = characterOptions[scroll.curretPos+1].characterName;
        numberOfBullets.text = "Bullets: " + characterOptions[scroll.curretPos+1].numberOfBullets.ToString();

        if(pauseState==false)
        {
           Player player =  GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            player.player = gameObject.GetComponent<CharacterSelect>().characterOptions[scroll.curretPos+1];
            player.updateData();

            gameObject.SetActive(false);
        }

    }

    
}
