using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Global Variables
    [SerializeField] private Canvas canvas;
    private Text scoreText;
    static public GameObject menuInicial;
    static public GameObject menuGameOver;
    static public GameObject menuCreditos;
    static public GameObject menuGame;
    private GameObject player;

    public Text gameOverScore;
    public Text gameOverRecord;

    [SerializeField]
    private Transform maxX, minX;
    private Vector2 screenBounds;
    private Camera mainCamera;
    public static int score;
    public static int recorde;

    int gameVolumeValue;
    int musicVolumeValue;

    // Buttons
    [SerializeField] private GameObject playButtonObj;
    [SerializeField] private GameObject alfinete;
    [SerializeField] private GameObject dropButton;

    [SerializeField] private GameObject playAgainButtonObj;
    [SerializeField] private GameObject playAgainAlfinete;
    [SerializeField] private GameObject playAgainDropButton;

    // Start is called before the first frame update
    void Start()
    {
        // Get data
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        player = GameObject.Find("Player");
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        menuInicial = GameObject.Find("menuInicial");
        menuGameOver = GameObject.Find("menuGameOver");
        menuCreditos = GameObject.Find("menuCreditos");
        menuGame = GameObject.Find("menuGame");
        getData();
        atualizarAudio();

        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        minX.position = new Vector2(-screenBounds.x, minX.position.y);
        maxX.position = new Vector2(screenBounds.x, maxX.position.y);
    }

    // Update is called once per frame
    void Update()
    {

        if (player.transform.position.y * 100 > score)
            score = (int)(player.transform.position.y * 100);

        if (score > 7500) {

            SpriteRenderer background = GameObject.Find("sky").GetComponent<SpriteRenderer>();
            Color newColor = background.color;

            if (score > 20000)
                newColor = new Color(153/255f, 217/255f, 234/255f); 
            else if (score > 15000) 
                newColor = new Color(98/255f, 90/255f, 174/255f); 
            else
                newColor = new Color(255/255f, 190/255f, 133/255f); 

            background.color = Color.Lerp(background.color, newColor, Mathf.PingPong(Time.deltaTime, 1)); 
            
        }

        if (GameManager.menuGameOver.GetComponent<CanvasGroup>().alpha > 0.1f) {
            if (score > recorde)
                recorde = score;

            gameOverScore.text = "Pontos: " + score.ToString();
            gameOverRecord.text = "Recorde: " + recorde.ToString();
        }

        scoreText.text = "Pontos: " + score;
    }

    static public void saveRecord() 
    {
        PlayerPrefs.SetInt("recorde", recorde);
    }

    void getData() 
    {
        gameVolumeValue = (PlayerPrefs.HasKey("volumeGame")) ? PlayerPrefs.GetInt("volumeGame") : 10;
        musicVolumeValue = (PlayerPrefs.HasKey("volumeMusic")) ? PlayerPrefs.GetInt("volumeMusic") : 10;
        recorde = (PlayerPrefs.HasKey("recorde")) ? PlayerPrefs.GetInt("recorde") : 0;
    }

    public void atualizarAudio() 
    {
        // musica
        mainCamera.GetComponent<AudioSource>().volume = (musicVolumeValue / 100f);

        // cut paper
        GetComponent<AudioSource>().volume = (gameVolumeValue / 100f);

        // jump
        player.GetComponent<AudioSource>().volume = (gameVolumeValue / 1000f);
    }

    public void playButton() 
    {
        player.GetComponent<Player>().enabled = true;
        playButtonObj.SetActive(false);
        dropButton.SetActive(true);
        alfinete.SetActive(true);

        StartCoroutine(DoFadeOut(menuInicial.GetComponent<CanvasGroup>()));
        StartCoroutine(DoFadeIn(menuGame.GetComponent<CanvasGroup>()));
    }

    public void cutPaper() {
        GetComponent<AudioSource>().Play();
    }

    public void playAgainButton() 
    {
        player.GetComponent<Player>().enabled = true;

        // resetar camera
        mainCamera.transform.position = new Vector3(0, -0.51f, -10);

        // resetar plataforms
        PlatformGenerator platformGenerator = GameObject.Find("WorldGenerator").GetComponent<PlatformGenerator>();
        
        // Reset Variables
        platformGenerator.minY = 0.3f;
        platformGenerator.maxY = 1.5f;
        platformGenerator.platformCount = 0;
        platformGenerator.spawnPosition = new Vector3(0, -5, 0);
        score = 0;        

        // destroy all power ups
        PowerUp[] powerUps = GameObject.FindObjectsOfType<PowerUp>();
        foreach (var powerUp in powerUps)
            Destroy(powerUp.gameObject);

        // destroy all monsters
        Monster[] monsters = GameObject.FindObjectsOfType<Monster>();
        foreach (var monster in monsters)
            Destroy(monster.gameObject);

        // destroy all platforms
        Platform[] platforms = GameObject.FindObjectsOfType<Platform>();
        foreach (var platform in platforms)
            Destroy(platform.gameObject);

        // create first platform
        GameObject newPlatform = Instantiate(platformGenerator.platform, new Vector2(0, -4.7f), Quaternion.identity);
        newPlatform.transform.parent = GameObject.Find("Platforms").transform;
        platformGenerator.platformCount++;

        // Create the rest platforms
        platformGenerator.Start(); 

        // resetar pos do player
        player.transform.position = new Vector2(0f, -3.94f);

        // resetar estrelas
        player.GetComponent<Player>().defeatStars.enabled = false;

        // resetar colliders
        player.GetComponent<BoxCollider2D>().isTrigger = false;

        // resetar player state
        player.GetComponent<Player>().playerState = Player.state.normal;

        // resetar cor do background
        GameObject.Find("sky").GetComponent<SpriteRenderer>().color = new Color(153/255f, 217/255f, 234/255f); 

        // resetar quantidade max de nuvens
        CloudGenerator cloudGenerator = GameObject.Find("WorldGenerator").GetComponent<CloudGenerator>();
        cloudGenerator.cloudMax = 15;
        cloudGenerator.cloudCount = 0;

        playAgainButtonObj.SetActive(false);
        playAgainAlfinete.SetActive(true);
        playAgainDropButton.SetActive(true);
        StartCoroutine(afterPlayAgainAnimation());

        StartCoroutine(DoFadeOut(menuGameOver.GetComponent<CanvasGroup>()));
        StartCoroutine(DoFadeIn(menuGame.GetComponent<CanvasGroup>()));
    }

    public void menuButton() 
    {
        SceneManager.LoadScene("SampleScene");
        score = 0;
    }

    public void optionsButton() 
    {
        SceneManager.LoadScene("OptionsMenu");
        score = 0;
    }

    public void creditsButton() 
    {
        StartCoroutine(DoFadeOut(menuInicial.GetComponent<CanvasGroup>()));
        StartCoroutine(DoFadeIn(menuCreditos.GetComponent<CanvasGroup>()));
    }

    public void creditsBackButton() 
    {
        StartCoroutine(DoFadeIn(menuInicial.GetComponent<CanvasGroup>()));
        StartCoroutine(DoFadeOut(menuCreditos.GetComponent<CanvasGroup>()));
    }

    static public IEnumerator DoFadeOut(CanvasGroup canvasG)
    {
        while (canvasG.alpha > 0) {
            canvasG.alpha -= Time.deltaTime;
            yield return null;
        }

        canvasG.interactable = false;
    }

    static public IEnumerator DoFadeIn(CanvasGroup canvasG)
    {
        while (canvasG.alpha < 1) {
            canvasG.alpha += Time.deltaTime;
            yield return null;
        }

        canvasG.interactable = true;
    }

    IEnumerator afterPlayAgainAnimation() 
    {
        yield return new WaitForSeconds(1);
        playAgainButtonObj.SetActive(true);
        playAgainAlfinete.SetActive(false);
        playAgainDropButton.SetActive(false);
        playAgainDropButton.transform.localPosition = new Vector3(0, -11.69999f, 0);
    }

}
