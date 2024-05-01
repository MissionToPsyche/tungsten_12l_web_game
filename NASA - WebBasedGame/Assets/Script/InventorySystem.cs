using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JetBrains.Annotations;
using System.IO;
using Unity.VisualScripting;
using System.Drawing;

public class InventorySystem : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();
    public List<string> collectedItems = new List<string>();
    public Dictionary<string, string> descriptions = new Dictionary<string, string>();
    public Dictionary<string, string> combinableItems = new Dictionary<string, string>();

    private void Start()
    {
        // --- First area combinable items ---
        combinableItems.Add("Arizona State University", " ");
        combinableItems.Add("Electromagnetic Fields", "Solar Panels");
        combinableItems.Add("Solar Panels", "Electromagnetic Fields");
        combinableItems.Add("Falcon Heavy Rocket", " ");
        combinableItems.Add("Solar Electric Propulsion", " ");

        // --- Second area combinable items ---
        combinableItems.Add("Neutron Spectrometer", "Cosmic Rays");
        combinableItems.Add("Cosmic Rays", "Neutron Spectrometer");
        combinableItems.Add("Magnetometer", " ");
        combinableItems.Add("X-Band Radio Frequency", " ");
        combinableItems.Add("Gamma Ray Spectrometer", " ");

        // --- Third area combinable items ---
        combinableItems.Add("Density", "Rotation Period");
        combinableItems.Add("Rotation Period", "Orbital Period");
        combinableItems.Add("Orbital Period", "Density");
        combinableItems.Add("Psyche Asteroid", " ");
        combinableItems.Add("The Mission to Psyche", " ");


        // First area item descriptions
        descriptions.Add("Arizona State University", "A university in Arizona that is the lead for the NASA Psyche mission and is " +
            "well known for other scientific initiatives.");

        descriptions.Add("Solar Panels", "Solar panels capture sunlight and turn it into electricity. They are used on " +
            "many spacecraft for its reliability and renewability.");

        descriptions.Add("Electromagnetic Fields", "A field of moving electrons that has many applications, one being the " +
            "generation of charged atoms. If there was a way to power an electromagnetic field it would be an extremely " +
            "efficient form of movement in a vacuum.");

        descriptions.Add("Falcon Heavy Rocket", "The Falcon Heavy is a two-stage rocket with side boosters developed by SpaceX.");

        descriptions.Add("Solar Electric Propulsion", "Powered by Hall-effect thrusters, Psyche’s solar electric propulsion system" +
            " harnesses energy from large solar arrays to create electric and magnetic fields. These, in turn, accelerate and expel" +
            " charged atoms, or ions, of a propellant called xenon (a neutral gas used in car headlights and plasma TVs) at such high" +
            " speed, it creates thrust.");

        // Second area item descriptions
        descriptions.Add("Magnetometer", "A device that can precisely detect very small magnetic fields.");

        descriptions.Add("Cosmic Rays", "High-energy particles that flow into our solar system from far away in the galaxy. " +
            "When the particles hit a surface, the elements there absorb the energy and emit neutrons and gamma rays of " +
            "varying energy levels.");

        descriptions.Add("X-Band Radio Frequency", "The X-band frequency range is on the radio portion of the electromagnetic spectrum.");

        descriptions.Add("Neutron Spectrometer", "A device that measures the amount of neutrons being released from a material or area" +
            " that can be used to identify what a specific material might be made of");

        descriptions.Add("Gamma Ray Spectrometer", "This device measures the amount and type of gamma rays a material emits when hit by" +
            " cosmic rays, the amount and type are unique for each element and is extremely useful for determining what an asteroid or" +
            " planet is made of.");

        // Third area item descriptions
        descriptions.Add("Density", "All matter has mass and volume. Mass is a measure of the amount of matter an object has and volume is" +
            " the amount of space an object occupies. Density is the ratio of the mass of an object to the volume it occupies. Space objects" +
            " like asteroids can have extremely high density if it they have a lot of heavy metals or elements");

        descriptions.Add("Rotation Period", "Rotation period measures how long it takes something to fully spin around, this is used to determine the day" +
            " and night cycle of an asteroid or planet based on how fast or slow it spins.");

        descriptions.Add("Orbital Period", "Orbital period measures how long it takes something to fully orbit around a star. Earth’s orbital period is one year.");

        descriptions.Add("Psyche Asteroid", "The Psyche asteroid is a relatively large asteroid that orbits between Mars and Jupiter. It may consist largely of" +
            " metal from the core of a planetesimal. A recent mission was launched that will determine what the asteroid is composed of and its internal structure." +
            " The spacecraft is supposed to reach the asteroid in 2029.");

        descriptions.Add("The Mission to Psyche", "The Psyche mission is a currently ongoing mission to map and determine the structure of the Psyche asteroid in order to" +
            " investigate hypotheses about the asteroid and gain more information about how planets such as Earth came to be using a specialized satellite.");

    }

    public bool findItem(string searchedName)
    {
        foreach (GameObject item in items)
        {
            if (item.name == searchedName)
            {
                return true;
            }
                
        }
        return false;
    }

    public bool findItemC(string searchedName)
    {
        foreach (string itemName in collectedItems)
        {
            if (itemName == searchedName)
            {
                return true;
            }

        }
        return false;
    }

    public void AddItem(GameObject item)
    {
        items.Add(item);
        collectedItems.Add(item.name);
    }
}
