using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameMap 
{
    private List<bool> map;
    public int count;

    public gameMap()
    {
        initMap();
    }

    public void initMap()
    {
        count = 0;
        
        map = new List<bool>();
        for(int i = 0; i < 25; i++)
        {
            int rand = Random.Range(1,8);
            if (rand==1)
            {
                map.Add(true);
                count++;
            }
            else
            {
                map.Add(false);
            }
        }
        if (count == 0)
        {
            map = new List<bool>();
            int rand = Random.Range(0, 24);
            for (int i = 0; i < 25; i++)
            {
                if (i == rand)
                {
                    map.Add(true);
                    count++;
                    
                }
                else
                {
                    map.Add(false);
                }
            }
        }
    }

    public List<bool> getMap()
    {
        return map;
    }

    
}
