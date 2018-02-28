using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    private int maxHeartAmount = 3;
    public int startHearts = 3;
    public int curHealth;
    private int maxHealth;
    private int healthPerHeart =2;

    public Image[] healthImages; //How many  hearths
    public Sprite[] healthSprites; //how many states each hearth can have
	// Use this for initialization
	void Start () {
        curHealth = startHearts * healthPerHeart;
        maxHealth = maxHeartAmount * healthPerHeart;

	}
    void checkHealthAmount()
    {
        for(int i=0; i < maxHeartAmount; i++)
        {
            if (startHearts <= i)
            {
                healthImages[i].enabled = false;
            }
            else
            {
                healthImages[i].enabled = false;
            }
        }
        updateHearts();
    }
    void updateHearts()
    {
        bool empty = false;
        int i = 0;

        foreach (Image image in healthImages)
        {
            if (empty)
            {
                image.sprite = healthSprites[0]; // Need help with images like empty health/

            }
            else
            {
                i++;
                if (curHealth >= i * healthPerHeart)
                {
                    image.sprite = healthSprites[healthSprites.Length - 1];
                }
                else
                {
                    int currentHeartHealth = (int)(healthPerHeart - (healthPerHeart * i - curHealth));
                    int healthPerImage = healthPerHeart / (healthSprites.Length - 1);
                    int imageIndex = currentHeartHealth / healthPerImage;
                    image.sprite = healthSprites[imageIndex];
                    empty = true;
                }
            }
        }
    }

    public void TakeDamage(int amount)
    {
        curHealth += amount;
        curHealth = Mathf.Clamp(curHealth, 0, startHearts * healthPerHeart);
        updateHearts();
    }

    public void AddHeartContainer()
    {
         startHearts++;
         startHearts = Mathf.Clamp(startHearts, 0, maxHeartAmount);
         curHealth = startHearts * healthPerHeart;
         maxHealth = maxHeartAmount * healthPerHeart;
         checkHealthAmount();
        
    }
}
