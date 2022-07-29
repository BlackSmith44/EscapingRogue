using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    //Basic
    public Player player;
    public Rigidbody2D rb;
    

    //Player Statistics (public needed for some scripts)
    public float CurrSpeed;
    public float CurrHP;
    public float CurrMP;
    public float CurrDmg;
    public float tempStr;
    public float tempDex;
    public float tempVit;
    public float tempInt;
    public float itemStr;
    public float itemDex;
    public float itemVit;
    public float itemInt;
    public float ManaCost;
    public float Score;
    public float CurrExp;
    public float CurrLvl;
    public float ExpForNextLvl = 5;
    public float SkillPoints;

    public float FullHp;
    public float FullMp;

    Vector2 movement;

    //Shield Section
    public GameObject shield;
    public float Stime = 2;
    private float Stimer;
    public bool ShieldIsActive;

    //Attack Section
    public GameObject AttackZone;
    public Collider2D AttackCollider;
    public float Atime = 0.25f;
    private float Atimer;
    public float Awaittime = 2.0f;
    public float Awaittimer;
    public bool canAttack;
    private bool AttackIsActive;
    

    //item Section
    public GameObject InventoryPanel;
    public GameObject ItemDescPanel;
    public GameObject LootPanel;
    public Inventory inventory;
    [SerializeField] public InventoryUI inventoryUI;

    public Text Points;
    public GameObject RightHandSlot;
    public GameObject LeftHandSlot;
    public GameObject HeadSlot;
    public GameObject TorsoSlot;
    public GameObject BootsSlot;

    //MENU Panel

    public GameObject MenuPanel;
    public Button ExitButton;

    //Game Over Panels

    public GameObject DeadPanel;
    public GameObject ExitPortalPanel;

    void Start()
    {
        player = this.transform.gameObject.GetComponent<Player>();

        inventory = new Inventory();
        inventoryUI.SetInventory(inventory);

        ExitButton.onClick.AddListener(MenuOpen);
        Physics2D.IgnoreLayerCollision(0, 13, true);

        canAttack = true;
        CurrHP = player.MaxHp;
        CurrMP = player.MaxMp;
        CurrSpeed = player.Speed;
    }

    void Update()
    {
        //Check is Player Dead
        if (CurrHP <= 0) Dead();

        //Update Stats and Current Status
        updateStats();
        checkEq();
        checkExp();

        CurrLvl = player.Lvl;
        CurrExp = player.Exp;
        FullHp = player.MaxHp + tempVit + itemVit;
        FullMp = player.MaxMp + tempInt + itemInt;
        CurrSpeed = player.Speed + tempDex + itemDex;
        CurrDmg = player.Dmg + tempStr + itemStr;
        CurrExp = player.Exp;
        if (CurrHP > FullHp) CurrHP = FullHp;
        if (CurrHP > FullMp) CurrMP = FullMp;
        Points.text = "Avaiable Points: " + SkillPoints.ToString();

       

        //Player movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Shield Section
        if (Input.GetButtonDown("Fire2") && (CurrMP - ManaCost) >= 0 && !InventoryPanel.activeSelf && !MenuPanel.activeSelf && !LootPanel.activeSelf && !DeadPanel.activeSelf)
        {
            if (!ShieldIsActive)
            {
                CurrMP -= ManaCost;
                ActivateShield(true);
                Stimer = Stime;
            }
        }
        if (Stimer > 0 && ShieldIsActive)
        {
            Stimer -= Time.deltaTime;
        }
        else
        {
            ActivateShield(false);
        }

        //Attack Section
        if (Input.GetButtonDown("Fire1") && !InventoryPanel.activeSelf && !MenuPanel.activeSelf && !LootPanel.activeSelf && !DeadPanel.activeSelf)
        {
            if (!AttackIsActive && canAttack)
            {
                ActivateAttack(true);
                Atimer = Atime;
                Awaittimer = Awaittime;
            }
        }

        if (Awaittimer > 0)
        {
            Awaittimer -= Time.deltaTime;
            canAttack = false;
        }
        else
        {
            canAttack = true;
        }

        if (Atimer > 0 && AttackIsActive)
        {
            Atimer -= Time.deltaTime;
        }
        else
        {
            ActivateAttack(false);
        }
        
        // Inventory Access
        if (Input.GetKeyDown(KeyCode.I))
        {
            OpenInv();
        }
        // Menu Access (also close anyother active panels)
        if (Input.GetKeyDown(KeyCode.Escape))
        {   if (!InventoryPanel.activeSelf && !LootPanel.activeSelf && !ItemDescPanel.activeSelf)
            {
                if (!MenuPanel.activeSelf)
                {
                    MenuPanel.SetActive(true);
                }
                else
                {
                    MenuPanel.SetActive(false);
                }
            }
            else
            {
                if(ItemDescPanel.activeSelf)
                {
                    ItemDescPanel.SetActive(false);
                }
                else if (InventoryPanel.activeSelf)
                {
                    InventoryPanel.SetActive(false);
                }
                else if (LootPanel.activeSelf)
                {
                    LootPanel.SetActive(false);
                }
            }
        }

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * CurrSpeed * Time.fixedDeltaTime);
    }

    public void GetDmg(float dmg)
    {
        if (!ShieldIsActive)
        {
            CurrHP -= dmg;
        }
    }

    //Shield Section
    public void ActivateShield(bool flag)
    {
        shield.SetActive(flag);
        ShieldIsActive = flag;
    }

    public void ActivateAttack(bool flag)
    {
        AttackZone.SetActive(flag);
        AttackIsActive = flag;
        AttackCollider.enabled = flag;
    }

    public void Hit(Collider2D target)
    {
        TesterStatsScript testerStatsScript = target.GetComponent<TesterStatsScript>();
        testerStatsScript.GetDmg(CurrDmg);
        AttackCollider.enabled = false;
    }

    

    public void updateStats()
    {
        //STR
        if (player != null)
        {
            if (player.Str != 0)
            {
                if (tempStr != player.Str)
                {
                    tempStr = player.Str;
                }
            }
            //DEX
            if (player.Dex != 0)
            {
                if (tempDex != player.Dex)
                {
                    tempDex = player.Dex;
                }
            }
            //VIT
            if (player.Vit != 0)
            {
                if (tempVit != player.Vit)
                {
                    tempVit = player.Vit;
                }
            }
            //INT
            if (player.Int != 0)
            {
                if (tempInt != player.Int)
                {
                    tempInt = player.Int;
                }
            }
        }
        else
        {
            Debug.Log("Lost Player");
        }
    }

    public void checkEq()
    {
        itemStr = 0;
        itemDex = 0;
        itemVit = 0;
        itemInt = 0;

        Item item;

        EqSlotScript eqSlotScript;

        eqSlotScript = RightHandSlot.GetComponent<EqSlotScript>();

        if (eqSlotScript.SlotIsTaken)
        {
            item = eqSlotScript.GetItem();
            if (item != null)
            {
                itemStr += item.STR;
                itemDex += item.DEX;
                itemVit += item.VIT;
                itemInt += item.INT;
            }
        }

        eqSlotScript = LeftHandSlot.GetComponent<EqSlotScript>();

        if (eqSlotScript.SlotIsTaken)
        {
            item = eqSlotScript.GetItem();
            itemStr += item.STR;
            itemDex += item.DEX;
            itemVit += item.VIT;
            itemInt += item.INT;
        }

        eqSlotScript = HeadSlot.GetComponent<EqSlotScript>();

        if (eqSlotScript.SlotIsTaken)
        {
            item = eqSlotScript.GetItem();
            if (item != null)
            {
                itemStr += item.STR;
                itemDex += item.DEX;
                itemVit += item.VIT;
                itemInt += item.INT;
            }
        }

        eqSlotScript = TorsoSlot.GetComponent<EqSlotScript>();

        if (eqSlotScript.SlotIsTaken)
        {
            item = eqSlotScript.GetItem();
            if (item != null)
            {
                itemStr += item.STR;
                itemDex += item.DEX;
                itemVit += item.VIT;
                itemInt += item.INT;
            }
        }

        eqSlotScript = BootsSlot.GetComponent<EqSlotScript>();

        if (eqSlotScript.SlotIsTaken)
        {
            item = eqSlotScript.GetItem();
            if (item != null)
            {
                itemStr += item.STR;
                itemDex += item.DEX;
                itemVit += item.VIT;
                itemInt += item.INT;
            }
        }
    }

    private void checkExp()
    {
        if (CurrExp >= ExpForNextLvl)
        {
            LvlUP();
        }
    }

    private void LvlUP()
    {
        ExpForNextLvl *= 5;
        player.Lvl += 1;
        SkillPoints += 2;
    }

    private void OpenInv()
    {
        if (!InventoryPanel.activeSelf)
        {
            InventoryPanel.SetActive(true);
        }
    }
    
    
    private void MenuOpen()
    {
        MenuPanel.SetActive(true);
    }

    public void PortalExit()
    {
        rb.isKinematic = true;
        ExitPortalPanel.SetActive(true);
    }

    private void Dead()
    {
        rb.isKinematic = true;
        DeadPanel.SetActive(true);
    }
}
