using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class MapController : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("Header text")]
    private Text Header;

    [SerializeField]
    [Tooltip("body text")]
    private Text body;

    [SerializeField]
    [Tooltip("Image displayer")]
    private Image img;

    [SerializeField]
    [Tooltip("Images to display")]
    private Sprite[] images;

    [SerializeField]
    [Tooltip("Org img to display")]
    private Sprite solarSystem;

    [SerializeField]
    [Tooltip("Exit button text")]
    private Text exit;

    #endregion

    #region Private Variables
    private string[] text;

    #endregion

    private void Awake()
    {
        exit.text = "<<Exit";
        text = new string[10];
        text[0] = "Star Type: Yellow Dwarf \nSize: Roughly 350,000x size of Earth \nOrbits the center of the Milky Way Galaxy \nBy mass, the Sun is about 70.6% hydrogen and 27.4% helium. \nThe surface of the Sun is the photosphere. This is the outer layer of the gassy star. \n Atmosphere: Thin, composed of the chromosphere and corona. Contains features like solar flares and sunspots. \nLIFE ON EARTH WOULD NOT BE POSSIBLE WITHOUT THE SUN.";
        text[1] = "Planet Type: Terrestrial \nNumber of Moons: 0 \nLength of 1 Day: 176 Earth Days \n Size: 0.3x size of Earth \nDistance from Sun: 0.4AU \nSurface: Resembles Earth's Moon surface. Many impact craters, large basins and cliffs \nGravity: 0.38x Earth's Gravity \nAtmosphere: No Atmosphere. Thin Exosphere composed mostly of oxygen, sodium, hydrogen, helium and potassium. \n NOT CONDUCIVE TO LIFE DUE TO EXTREME TEMPERATURES AND SOLAR RADIATION.";
        text[2] = "Planet Type: Terrestrial \nNumber of Moons: 0 \nLength of 1 Day: 243 Earth Days \n Size: Same as Earth \nDistance from Sun: 0.7AU \nSurface: Characterized by mountains, valleys, many large craters and tens of thousands of volcanoes. Dusty landscape and high surfact temperatures \nGravity: 0.91x Earth's Gravity \nAtmosphere: Very thick and dense, composed of carbon dioxide, with clouds of sulfuric acid droplets. \n POTENTIAL FOR LIFE IS WEAK DUE TO EXTREME HEAT.";
        text[3] = "Planet Type: Terrestrial \nNumber of Moons: 1 \nLength of 1 Day: 24 Hours \nDistance from Sun: 1AU \nSurface: Contains volcanos, mountains and valleys. Constantly moving tectonic plates and large waterbodies spanning 70% of the surface \nGravity: 9.8m/s^2 \nAtmosphere: 78 percent nitrogen, 21 percent oxygen, and 1 percent other gases such as argon, carbon dioxide and neon. Thick layer protects the surface \n CURRENTLY HABITATED BY MANKIND.";
        text[4] = "Planet Type: Terrestrial \nNumber of Moons: 2 \nLength of 1 Day: 24 Hours 35 minutes \nSize: 0.5x larger than Earth \nDistance from Sun: 1.5AU \nSurface: Characterized by volcanos, impact craters, large canyons, and tract amounts of water. \nGravity: 0.38x Earth's Gravity \nAtmosphere: Thin atmosphere made up mostly of carbon dioxide, nitrogen and argon gases. Heat easily absorbed and released. \n LIFE MAY HAVE EXISTED HERE IN THE PAST. CURRENTLY NOT CONDUCIVE TO HUMAN LIFE.";
        text[5] = "Planet Type: Gas Giant \nNumber of Moons: 53 \nLength of 1 Day: 9 Hours 55 minutes \nSize: 11x larger than Earth \nDistance from Sun: 5.2AU \nSurface: No true solid surface. Largely composed of swirling gases with liquids deeper down. \nGravity: Roughly 2.40x Earth's Gravity \nAtmosphere: Large amounts of hydrogen, helium, ammonia, and water. High pressure winds and jet streams. \nCONDITIONS ARE NOT CONDUCIVE TO LIFE. SPACESHIP WILL BE DESTROYED BY EXTREME PRESSURES AND TEMPERATURES.";
        text[6] = "Planet Type: Gas Giant \nNumber of Moons: 53 \nLength of 1 Day: 10 Hours 40 minutes \nSize: 9x larger than Earth \nDistance from Sun: 9.5AU \nSurface: No true solid surface. Largely composed of swirling gases with liquids deeper down and a dense core. \nGravity: 1.08x Earth's Gravity \nAtmosphere: Mainly hydrogen and helium. High pressure winds. \nCONDITIONS ARE NOT CONDUCIVE TO LIFE. SPACESHIP WILL BE DESTROYED BY EXTREME PRESSURES AND TEMPERATURES.";
        text[7] = "Planet Type: Ice Giant \nNumber of Moons: 27 \nLength of 1 Day: 17 Hours 14 minutes \nSize: 4x larger than Earth \nDistance from Sun: 19.8AU \nSurface: No solid surface. Largely composed of swirling fluids. \nGravity: 0.86x Earth's Gravity \nAtmosphere: Mainly hydrogen and helium with a small amount of methane and traces of water and ammonia. \nCONDITIONS ARE NOT CONDUCIVE TO LIFE. SPACESHIP WILL BE DESTROYED BY EXTREME PRESSURES AND TEMPERATURES.";
        text[8] = "Planet Type: Ice Giant \nNumber of Moons: 14 \nLength of 1 Day: 16 Hours \nSize: 4x larger than Earth \nDistance from Sun: 30AU \nSurface: No solid surface. Its atmosphere merges into water and other melted ices at depths. \nGravity: 1.10x Earth's Gravity \nAtmosphere: Mainly hydrogen and helium with a little bit of methane. Extremely windy and prone to storms.\nCONDITIONS ARE NOT CONDUCIVE TO LIFE. ";
        text[9] = "Planet Type: Dwarf Planet \nNumber of Moons: 5 \nLength of 1 Day: 153 Hours \nSize: 0.2x size of Earth \nDistance from Sun: 39AU \nSurface: Characterized by tall mountains, valleys, frozen plains, and large craters. \nGravity: 0.6x Earth's Gravity \nAtmosphere: Thin and weak with abundant Methane, Nitrogen, and Carbon Monoxide \nPOTENTIAL FOR LIFE IS WEAK DUE TO EXTREMELY COLD TEMPERATURES. LIFE MAY EXIST IN THE WARMER INTERIORS OF THE PLANET";
    }

    #region Button Methods
    public void PlanetClick(int planet)
    {
        Header.text = EventSystem.current.currentSelectedGameObject.name;
        body.text = text[planet];
        img.sprite = images[planet];
        exit.text = "<<Back";
    }

    public void ExitClick()
    {
        if (exit.GetComponent<Text>().text == "<<Exit")
        {
            SceneManager.LoadScene("4.Spaceship_Interior");
        }
        if (exit.text == "<<Back")
        {
            Header.text = "";
            body.text = "";
            img.sprite = solarSystem;
            exit.text = "<<Exit";
        }

    }
    #endregion
}

