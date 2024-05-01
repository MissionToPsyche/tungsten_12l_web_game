using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private const int TOTALSLOTS = 12;
    private Slot[] combinedSlots; 

    public enum Type    
    {
        DocA,
        DocB,
        DocC,
        DocD,
        None
    }
    public class Item
    {
        string itemName;
        Type itemType;
        string description;
        Texture2D displayIcon = new Texture2D(16, 16);

        public Item(string aName, Type aType, string desc, string imagePath)
        {
            this.itemName = aName;
            this.itemType = aType;
            this.description = desc;
            byte[] picArray = File.ReadAllBytes(imagePath);
            ImageConversion.LoadImage(this.displayIcon, picArray);
        }
        
        public Item()
        {
            this.itemName = "";
            this.itemType = Type.None;
            this.description = "";
            this.displayIcon = Texture2D.blackTexture;
        }

        public Type getItemType()
        {
            return this.itemType;
        }
    }
    public class Slot
    {
        Item item;
        int slotNum;

        public Slot(Item itemToInsert, int currentSlotNumber)
        {
            this.item = itemToInsert;
            this.slotNum = currentSlotNumber;
        }
        public Slot(int currentSlotNumber)
        {
            Item emptyItem = new Item();
            this.item = emptyItem;
            this.slotNum = currentSlotNumber;
        }

        public Item getItemInSlot()
        {
            return this.item;
        }
    }

    public Inventory()
    {
        combinedSlots = new Slot[TOTALSLOTS];

        for (int i = 0; i < TOTALSLOTS; i++) 
        {
            Slot slotToInsert = new Slot(i + 1);
            combinedSlots[i] = slotToInsert;
        }
    }

    public bool addItemToNextSlot(Item anItem) 
    {
        bool didAdd = false;

        for (int a = 0; a < TOTALSLOTS; a++)
        {
            if (combinedSlots[a].getItemInSlot().getItemType() == Type.None)
            {
                Slot slotToAdd = new Slot(anItem, a + 1);
                combinedSlots[a] = slotToAdd;
                break;
            }
        }

        return didAdd;
    }

    public void removeSlotItem(int userSlotNumber)
    {
        combinedSlots[userSlotNumber - 1] = new Slot(userSlotNumber);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
