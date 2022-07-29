using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssest : MonoBehaviour
{

    public static ItemAssest Instance { get; set; }
    public Sprite Sword;
    public Sprite Sword2;
    public Sprite Sword3;
    public Sprite Shield;
    public Sprite Shield2;
    public Sprite Shield3;
    public Sprite Axe;
    public Sprite Axe2;
    public Sprite Axe3;
    public Sprite Armor;
    public Sprite Armor2;
    public Sprite Armor3;
    public Sprite Helmet;
    public Sprite Helmet2;
    public Sprite Helmet3;
    public Sprite Boots;
    public Sprite Boots2;
    public Sprite Boots3;
    public Sprite Wand;
    public Sprite Wand2;
    public Sprite Wand3;
    public Sprite Chicken;
    public Sprite Pottion;
    public Sprite DefaultCross;


    //Item List 
    private List<Item> prefabItemList = new List<Item>();
    private List<int> uniqueNumList = new List<int>();
    private Item item;
    private int num = 0;



    private void Awake()
    {
        Instance = this;

        //Add new items to item list
        NewNumber();
        item = new Item { name= "Tasty Chicken", description = "Maybe not KFC but still nice", itemType = Item.ItemType.Heal,  ID = num, HealPower = 1 };
        prefabItemList.Add(item);
        NewNumber();
        item = new Item { name = "Red Pottion", description = "Inside bottle we can se strange red liquit, which in magic way heal open wounds, broken bones, blood lost, even lost limbs... and also restore energy.", itemType = Item.ItemType.Heal2, ID = num, HealPower = 3 };
        prefabItemList.Add(item);
        NewNumber();
        item = new Item { name = "Sharp Dagger", description = "Dagger used by Assasins and other shady persons. Better watch your back.", itemType = Item.ItemType.Sword, ID = num, STR = 1, DEX = 0.25f, VIT = -1 };
        prefabItemList.Add(item);
        NewNumber();
        item = new Item { name = "Exotic Sabre", description = "Very interesting looking sword. Suddenly I want to eat a bowl of rice.", itemType = Item.ItemType.Sword2, ID = num, STR = 2 };
        prefabItemList.Add(item);
        NewNumber();
        item = new Item { name = "Bastard Sword", description = "Vey very big sword. It's extremly sharp and long... and heavy!", itemType = Item.ItemType.Sword3, ID = num, STR = 4, DEX= -0.75f };
        prefabItemList.Add(item);
        NewNumber();
        item = new Item { name = "Small Shield", description = "Small shield. Perfect for fast parry and counter attack.", itemType = Item.ItemType.Shield, ID = num, VIT = 1, DEX= 0.25f };
        prefabItemList.Add(item);
        NewNumber();
        item = new Item { name = "Hardened Shield", description = "Reinforced shield. It can withstand even stronger blows.", itemType = Item.ItemType.Shield2, ID = num, VIT = 2 };
        prefabItemList.Add(item);
        NewNumber();
        item = new Item { name = "The Door", description = "It simply big peace of old door. \nKnock, Knock. Who's there? THE DOOR", itemType = Item.ItemType.Shield3, ID = num, VIT = 4, DEX= -1.25f };
        prefabItemList.Add(item);
        NewNumber();
        item = new Item { name = "Lumberjack's Axe", description = "Axe used commonly by lumberjacks and other civilians. Suitable for chopping trees.", itemType = Item.ItemType.Axe, ID = num, STR = 3, DEX =- 0.25f};
        prefabItemList.Add(item);
        NewNumber();
        item = new Item { name = "Battle Axe", description = "This great piece of steel was used by berserkers. Extremely dangerous weapon in good hands.", itemType = Item.ItemType.Axe2, ID = num, STR = 4, DEX = -0.5f };
        prefabItemList.Add(item);
        NewNumber();
        item = new Item { name = "Executioner's Axe", description = "Used commonly by Executioners. Very big and heavy but also lethal to everyone.", itemType = Item.ItemType.Axe3, ID = num, STR = 5, DEX = -1 };
        prefabItemList.Add(item);
        NewNumber();
        item = new Item { name = "Warrior chainmail", description = "Armor commonly used by mercenaries and soldiers. Very reliable and cheap to repair.", itemType = Item.ItemType.Armor, ID = num, VIT= 3, DEX = -0.25f };
        prefabItemList.Add(item);
        NewNumber();
        item = new Item { name = "Traveller's Coat", description = "Standard outfit of travellers, mages and bandits. Armor allows the user freedom of movement, but has poorly defend properties.", itemType = Item.ItemType.Armor2, ID = num, VIT = 1, DEX = 0.5f, INT=1, };
        prefabItemList.Add(item);
        NewNumber();
        item = new Item { name = "Palladin's Plate Armor", description = "Very heavy Armor used by Palladins and Chaplains. Can absorb many blows and hit even from spells.", itemType = Item.ItemType.Armor3, ID = num, VIT = 5, DEX = - 1.25f };
        prefabItemList.Add(item);
        NewNumber();
        item = new Item { name = "Mercenary's helmet", description = "Standard mercenary and soldier helmet. It gives a certain chance of surviving a blow to the head.", itemType = Item.ItemType.Helmet, ID = num, VIT = 2 };
        prefabItemList.Add(item);
        NewNumber();
        item = new Item { name = "Hood", description = "Used by everyone in rainy day and those, who are hiding in the shadows.", itemType = Item.ItemType.Helmet2, ID = num, VIT = 1, DEX= 0.25f };
        prefabItemList.Add(item);
        NewNumber();
        item = new Item { name = "Bascinet", description = "Heavy Helmet used by Knights. It's hard to see anything from inside but from outside you are invincible!", itemType = Item.ItemType.Helmet3, ID = num, VIT = 3, DEX =- 0.25f };
        prefabItemList.Add(item);
        NewNumber();
        item = new Item { name = "Flip Flops", description = "Old, worn shoes. They make strange noises when you walk.", itemType = Item.ItemType.Boots, ID = num, DEX = 0.25f };
        prefabItemList.Add(item);
        NewNumber();
        item = new Item { name = "Soldier's boots", description = "Boots used by soldiers. Very good quality and nice durability for long marches.", itemType = Item.ItemType.Boots2, ID = num, DEX = 0.5f };
        prefabItemList.Add(item);
        NewNumber();
        item = new Item { name = "Maze Runner's shoes", description = "Boots used by famous group of adventurers. Shoes are very light, soft and warm.", itemType = Item.ItemType.Boots3, ID = num, DEX = 0.75f };
        prefabItemList.Add(item);
        NewNumber();
        item = new Item { name = "Traveller's Staff", description = "Long piece of wood used by old people, travelers and magicians.", itemType = Item.ItemType.Wand, ID = num, INT =1, DEX = 0.25f };
        prefabItemList.Add(item);
        NewNumber();
        item = new Item { name = "Shaman's Staff", description = "Staff used by clan elders and shamans. An inscription in an ancient language was grooved on the wood.", itemType = Item.ItemType.Wand2, ID = num, INT = 3, DEX = 0.25f };
        prefabItemList.Add(item);
        NewNumber();
        item = new Item { name = "Archmage Staff", description = "Very powerful artifact used by the best of mages. Power accumulated inside staff, help his user in casting advanced magic spells.", itemType = Item.ItemType.Wand3, ID = num, INT = 5, DEX = 0.25f };
        prefabItemList.Add(item);
    }


    //Generate one random unique number
    private void NewNumber()
    {
        bool gotcha = false;
        while (!gotcha)
        {
            num = Random.Range(0, 1000);
            if (!uniqueNumList.Contains(num))
            {
                gotcha = true;
                break;
            }
            else continue;
        }

        uniqueNumList.Add(num);
    }

    //Generate one random Item
    public Item getRandItem()
    {
        bool gotcha = false;
        while (!gotcha)
        {
            num = Random.Range(0, 1000);
            foreach (Item i in prefabItemList)
            {
                if (i.ID == num)
                {
                    item = i;
                    gotcha = true;
                    break;
                }
                else continue;
            }
        }
        return item;
    }

}
