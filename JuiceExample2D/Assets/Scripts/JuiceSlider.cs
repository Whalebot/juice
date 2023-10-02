using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class JuiceSlider : MonoBehaviour
{
    public static JuiceSlider Instance { get; private set; }
    public SaveFile saveFile;
    public float timeScale;
    public float slowmotionValue;
    public float slowmotionDuration;
    public float slowMotionSmoothing;
    public float landScreenShakeValue;
    public float enemyHurtScreenShakeValue;
    public float enemyDeathScreenShakeValue;
    public float enemyCameraZoomValue;
    public float enemyCameraZoomSmoothing;
    public float deathSlowMotionValue;
    public float deathSlowMotionDuration;

    float startTimeStep;
    public enum FXEnum { None, fx1, fx2, fx3 };
    public FXEnum jumpParticle;
    public FXEnum jumpSFX;
    public FXEnum landParticle;
    public FXEnum landSFX;
    public FXEnum enemyHurtParticle;
    public FXEnum enemyHurtSFX;
    public FXEnum enemyDeathParticle;
    public FXEnum enemyDeathSFX;
    public int bgmTrack;

    public Animator animatorPanel;

    public PlatformerController playerController;

    public CameraController cameraController;

    public Slider landingScreenShakeSlider;
    public TextMeshProUGUI landingSlowmotionText;

    public Slider enemyHurtShakeSlider;
    public TextMeshProUGUI enemyHurtShakeText;

    public Slider enemySlowmotionDurationSlider;
    public TextMeshProUGUI enemyHurtSlowmotionDurationText;

    public Slider enemySlowmotionValueSlider;
    public TextMeshProUGUI enemyHurtSlowmotionValueText;

    public Slider enemySlowmotionSmoothingSlider;
    public TextMeshProUGUI enemyHurtSlowmotionSmoothingText;

    public Slider deathCameraZoomSlider;
    public TextMeshProUGUI deathCameraZoomText;

    public Slider deathCameraSmoothingSlider;
    public TextMeshProUGUI deathCameraSmoothingText;

    public Slider enemyDeathShakeSlider;
    public TextMeshProUGUI enemyDeathShakeText;

    public Slider enemyDeathSlowMotionValueSlider;
    public TextMeshProUGUI enemyDeathSlowMotionValueText;

    public Slider enemyDeathSlowMotionDurationSlider;
    public TextMeshProUGUI enemyDeathSlowMotionDurationText;

    public GameObject particle1;
    public GameObject particle2;
    public GameObject particle3;

    public GameObject sfx1;
    public GameObject sfx2;
    public GameObject sfx3;

    public GameObject enemySfx1;
    public GameObject enemySfx2;
    public GameObject enemySfx3;

    public AudioSource bgmAudioSource;

    public AudioClip music1;
    public AudioClip music2;
    public AudioClip music3;

    public Button jumpParticleButton1;
    public Button jumpParticleButton2;
    public Button jumpParticleButton3;
    public Button jumpParticleButton4;

    public Button jumpSFXButton1;
    public Button jumpSFXButton2;
    public Button jumpSFXButton3;
    public Button jumpSFXButton4;

    public Button landParticleButton1;
    public Button landParticleButton2;
    public Button landParticleButton3;
    public Button landParticleButton4;

    public Button landSFXButton1;
    public Button landSFXButton2;
    public Button landSFXButton3;
    public Button landSFXButton4;

    public Button musicButton1;
    public Button musicButton2;
    public Button musicButton3;
    public Button musicButton4;

    public Button damageVFXButton1;
    public Button damageVFXButton2;
    public Button damageVFXButton3;
    public Button damageVFXButton4;

    public Button damageSFXButton1;
    public Button damageSFXButton2;
    public Button damageSFXButton3;
    public Button damageSFXButton4;

    public Button deathVFXButton1;
    public Button deathVFXButton2;
    public Button deathVFXButton3;
    public Button deathVFXButton4;

    public Button deathSFXButton1;
    public Button deathSFXButton2;
    public Button deathSFXButton3;
    public Button deathSFXButton4;

    Coroutine slowmoCoroutine;

    void Awake()
    {
        Instance = this;
        startTimeStep = Time.fixedDeltaTime;
    }

    private void Start()
    {
        playerController.jumpEvent += PlayerJumping;
        playerController.landEvent += PlayerLanding;

        jumpParticleButton1.onClick.AddListener(() => SetJumpParticle(0));
        jumpParticleButton2.onClick.AddListener(() => SetJumpParticle(1));
        jumpParticleButton3.onClick.AddListener(() => SetJumpParticle(2));
        jumpParticleButton4.onClick.AddListener(() => SetJumpParticle(3));

        jumpSFXButton1.onClick.AddListener(() => SetJumpSFX(0));
        jumpSFXButton2.onClick.AddListener(() => SetJumpSFX(1));
        jumpSFXButton3.onClick.AddListener(() => SetJumpSFX(2));
        jumpSFXButton4.onClick.AddListener(() => SetJumpSFX(3));

        landParticleButton1.onClick.AddListener(() => SetLandParticle(0));
        landParticleButton2.onClick.AddListener(() => SetLandParticle(1));
        landParticleButton3.onClick.AddListener(() => SetLandParticle(2));
        landParticleButton4.onClick.AddListener(() => SetLandParticle(3));

        landSFXButton1.onClick.AddListener(() => SetLandSFX(0));
        landSFXButton2.onClick.AddListener(() => SetLandSFX(1));
        landSFXButton3.onClick.AddListener(() => SetLandSFX(2));
        landSFXButton4.onClick.AddListener(() => SetLandSFX(3));

        musicButton1.onClick.AddListener(() => SetBGM(0));
        musicButton2.onClick.AddListener(() => SetBGM(1));
        musicButton3.onClick.AddListener(() => SetBGM(2));
        musicButton4.onClick.AddListener(() => SetBGM(3));

        damageVFXButton1.onClick.AddListener(() => SetHurtParticle(0));
        damageVFXButton2.onClick.AddListener(() => SetHurtParticle(1));
        damageVFXButton3.onClick.AddListener(() => SetHurtParticle(2));
        damageVFXButton4.onClick.AddListener(() => SetHurtParticle(3));

        damageSFXButton1.onClick.AddListener(() => SetHurtSFX(0));
        damageSFXButton2.onClick.AddListener(() => SetHurtSFX(1));
        damageSFXButton3.onClick.AddListener(() => SetHurtSFX(2));
        damageSFXButton4.onClick.AddListener(() => SetHurtSFX(3));

        deathVFXButton1.onClick.AddListener(() => SetDeathParticle(0));
        deathVFXButton2.onClick.AddListener(() => SetDeathParticle(1));
        deathVFXButton3.onClick.AddListener(() => SetDeathParticle(2));
        deathVFXButton4.onClick.AddListener(() => SetDeathParticle(3));

        deathSFXButton1.onClick.AddListener(() => SetDeathSFX(0));
        deathSFXButton2.onClick.AddListener(() => SetDeathSFX(1));
        deathSFXButton3.onClick.AddListener(() => SetDeathSFX(2));
        deathSFXButton4.onClick.AddListener(() => SetDeathSFX(3));

        //SetJumpParticle(0);
        //SetJumpSFX(0);
        //SetLandParticle(0);
        //SetLandSFX(0);
        //SetBGM(0);
        //SetHurtParticle(0);
        //SetHurtSFX(0);
        //SetDeathParticle(0);
        //SetDeathSFX(0);

        //UpdateSliders();
    }

    private void OnDisable()
    {
        playerController.jumpEvent -= PlayerJumping;
        playerController.landEvent -= PlayerLanding;
    }

    private void Update()
    {
        timeScale = Time.timeScale;

        if (Input.GetKeyDown(KeyCode.Tab))
            animatorPanel.SetBool("Open", !animatorPanel.GetBool("Open"));
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(0);

    }
    public void ToggleAnimation() {
        animatorPanel.SetBool("Open", !animatorPanel.GetBool("Open"));
    }
    void PlayerLanding(Vector2 pos)
    {
        CameraController.ScreenShake(landScreenShakeValue, landScreenShakeValue);
        if (LandParticle() != null)
            Instantiate(LandParticle(), pos, Quaternion.identity);
        if (LandSFX() != null)
            Instantiate(LandSFX(), pos, Quaternion.identity);
    }
    void PlayerJumping(Vector2 pos)
    {
        //CameraController.ScreenShakeLight();
        if (JumpParticle() != null)
            Instantiate(JumpParticle(), pos, Quaternion.identity);
        if (JumpSFX() != null)
            Instantiate(JumpSFX(), pos, Quaternion.identity);
    }
    public void SetJumpParticle(int i)
    {
        jumpParticleButton1.image.color = Color.white;
        jumpParticleButton2.image.color = Color.white;
        jumpParticleButton3.image.color = Color.white;
        jumpParticleButton4.image.color = Color.white;

        jumpParticle = (FXEnum)i;
        switch (jumpParticle)
        {
            case FXEnum.None:
                jumpParticleButton1.image.color = Color.red;
                break;
            case FXEnum.fx1:
                jumpParticleButton2.image.color = Color.red;
                break;
            case FXEnum.fx2:
                jumpParticleButton3.image.color = Color.red;
                break;
            case FXEnum.fx3:
                jumpParticleButton4.image.color = Color.red;
                break;
            default:
                jumpParticleButton1.image.color = Color.red;
                break;
        }
    }
    public void SetJumpSFX(int i)
    {
        jumpSFXButton1.image.color = Color.white;
        jumpSFXButton2.image.color = Color.white;
        jumpSFXButton3.image.color = Color.white;
        jumpSFXButton4.image.color = Color.white;

        jumpSFX = (FXEnum)i;
        switch (jumpSFX)
        {
            case FXEnum.None:
                jumpSFXButton1.image.color = Color.red;
                break;
            case FXEnum.fx1:
                jumpSFXButton2.image.color = Color.red;
                break;
            case FXEnum.fx2:
                jumpSFXButton3.image.color = Color.red;
                break;
            case FXEnum.fx3:
                jumpSFXButton4.image.color = Color.red;
                break;
            default:
                jumpSFXButton1.image.color = Color.red;
                break;
        }
    }
    public GameObject JumpParticle()
    {
        switch (jumpParticle)
        {
            case FXEnum.None:
                return null;
            case FXEnum.fx1:
                return particle1;
            case FXEnum.fx2:
                return particle2;
            case FXEnum.fx3:
                return particle3;
            default:
                return null;
        }
    }
    public GameObject JumpSFX()
    {
        switch (jumpSFX)
        {
            case FXEnum.None:
                return null;
            case FXEnum.fx1:
                return sfx1;
            case FXEnum.fx2:
                return sfx2;
            case FXEnum.fx3:
                return sfx3;
            default:
                return null;
        }
    }
    public void SetLandParticle(int i)
    {
        landParticleButton1.image.color = Color.white;
        landParticleButton2.image.color = Color.white;
        landParticleButton3.image.color = Color.white;
        landParticleButton4.image.color = Color.white;

        landParticle = (FXEnum)i;
        switch (landParticle)
        {
            case FXEnum.None:
                landParticleButton1.image.color = Color.red;
                break;
            case FXEnum.fx1:
                landParticleButton2.image.color = Color.red;
                break;
            case FXEnum.fx2:
                landParticleButton3.image.color = Color.red;
                break;
            case FXEnum.fx3:
                landParticleButton4.image.color = Color.red;
                break;
            default:
                landParticleButton1.image.color = Color.red;
                break;
        }
    }
    public void SetLandSFX(int i)
    {
        landSFXButton1.image.color = Color.white;
        landSFXButton2.image.color = Color.white;
        landSFXButton3.image.color = Color.white;
        landSFXButton4.image.color = Color.white;

        landSFX = (FXEnum)i;
        switch (landSFX)
        {
            case FXEnum.None:
                landSFXButton1.image.color = Color.red;
                break;
            case FXEnum.fx1:
                landSFXButton2.image.color = Color.red;
                break;
            case FXEnum.fx2:
                landSFXButton3.image.color = Color.red;
                break;
            case FXEnum.fx3:
                landSFXButton4.image.color = Color.red;
                break;
            default:
                landSFXButton1.image.color = Color.red;
                break;
        }
    }
    public GameObject LandParticle()
    {
        switch (landParticle)
        {
            case FXEnum.None:
                return null;
            case FXEnum.fx1:
                return particle1;
            case FXEnum.fx2:
                return particle2;
            case FXEnum.fx3:
                return particle3;
            default:
                return null;
        }
    }
    public GameObject LandSFX()
    {
        switch (landSFX)
        {
            case FXEnum.None:
                return null;
            case FXEnum.fx1:
                return sfx1;
            case FXEnum.fx2:
                return sfx2;
            case FXEnum.fx3:
                return sfx3;
            default:
                return null;
        }
    }
    public void SetBGM(int i)
    {

        musicButton1.image.color = Color.white;
        musicButton2.image.color = Color.white;
        musicButton3.image.color = Color.white;
        musicButton4.image.color = Color.white;

        bgmTrack = i;
        switch (bgmTrack)
        {
            case 0:
                musicButton1.image.color = Color.red;
                break;
            case 1:
                musicButton2.image.color = Color.red;
                break;
            case 2:
                musicButton3.image.color = Color.red;
                break;
            case 3:
                musicButton4.image.color = Color.red;
                break;
            default:
                musicButton1.image.color = Color.red;
                break;
        }

        switch (i)
        {
            case 0:
                bgmAudioSource.Pause();
                break;
            case 1:
                bgmAudioSource.clip = music1;
                bgmAudioSource.Play();
                break;
            case 2:
                bgmAudioSource.clip = music2;
                bgmAudioSource.Play();
                break;
            case 3:
                bgmAudioSource.clip = music3;
                bgmAudioSource.Play();
                break;
            default:
                bgmAudioSource.Pause();
                break;
        }
    }
    public void SetHurtParticle(int i)
    {
        damageVFXButton1.image.color = Color.white;
        damageVFXButton2.image.color = Color.white;
        damageVFXButton3.image.color = Color.white;
        damageVFXButton4.image.color = Color.white;

        enemyHurtParticle = (FXEnum)i;
        switch (enemyHurtParticle)
        {
            case FXEnum.None:
                damageVFXButton1.image.color = Color.red;
                break;
            case FXEnum.fx1:
                damageVFXButton2.image.color = Color.red;
                break;
            case FXEnum.fx2:
                damageVFXButton3.image.color = Color.red;
                break;
            case FXEnum.fx3:
                damageVFXButton4.image.color = Color.red;
                break;
            default:
                damageVFXButton1.image.color = Color.red;
                break;
        }
    }
    public void SetHurtSFX(int i)
    {
        damageSFXButton1.image.color = Color.white;
        damageSFXButton2.image.color = Color.white;
        damageSFXButton3.image.color = Color.white;
        damageSFXButton4.image.color = Color.white;

        enemyHurtSFX = (FXEnum)i;
        switch (enemyHurtSFX)
        {
            case FXEnum.None:
                damageSFXButton1.image.color = Color.red;
                break;
            case FXEnum.fx1:
                damageSFXButton2.image.color = Color.red;
                break;
            case FXEnum.fx2:
                damageSFXButton3.image.color = Color.red;
                break;
            case FXEnum.fx3:
                damageSFXButton4.image.color = Color.red;
                break;
            default:
                damageSFXButton1.image.color = Color.red;
                break;
        }
    }
    public GameObject HurtParticle()
    {
        switch (enemyHurtParticle)
        {
            case FXEnum.None:
                return null;
            case FXEnum.fx1:
                return particle1;
            case FXEnum.fx2:
                return particle2;
            case FXEnum.fx3:
                return particle3;
            default:
                return null;
        }
    }
    public GameObject HurtSFX()
    {
        switch (enemyHurtSFX)
        {
            case FXEnum.None:
                return null;
            case FXEnum.fx1:
                return enemySfx1;
            case FXEnum.fx2:
                return enemySfx2;
            case FXEnum.fx3:
                return enemySfx3;
            default:
                return null;
        }
    }
    public void SetDeathParticle(int i)
    {
        deathVFXButton1.image.color = Color.white;
        deathVFXButton2.image.color = Color.white;
        deathVFXButton3.image.color = Color.white;
        deathVFXButton4.image.color = Color.white;

        enemyDeathParticle = (FXEnum)i;
        switch (enemyDeathParticle)
        {
            case FXEnum.None:
                deathVFXButton1.image.color = Color.red;
                break;
            case FXEnum.fx1:
                deathVFXButton2.image.color = Color.red;
                break;
            case FXEnum.fx2:
                deathVFXButton3.image.color = Color.red;
                break;
            case FXEnum.fx3:
                deathVFXButton4.image.color = Color.red;
                break;
            default:
                deathVFXButton1.image.color = Color.red;
                break;
        }
    }
    public void SetDeathSFX(int i)
    {
        deathSFXButton1.image.color = Color.white;
        deathSFXButton2.image.color = Color.white;
        deathSFXButton3.image.color = Color.white;
        deathSFXButton4.image.color = Color.white;

        enemyDeathSFX = (FXEnum)i;
        switch (enemyDeathSFX)
        {
            case FXEnum.None:
                deathSFXButton1.image.color = Color.red;
                break;
            case FXEnum.fx1:
                deathSFXButton2.image.color = Color.red;
                break;
            case FXEnum.fx2:
                deathSFXButton3.image.color = Color.red;
                break;
            case FXEnum.fx3:
                deathSFXButton4.image.color = Color.red;
                break;
            default:
                deathSFXButton1.image.color = Color.red;
                break;
        }
    }
    public GameObject DeathParticle()
    {
        switch (enemyDeathParticle)
        {
            case FXEnum.None:
                return null;
            case FXEnum.fx1:
                return particle1;
            case FXEnum.fx2:
                return particle2;
            case FXEnum.fx3:
                return particle3;
            default:
                return null;
        }
    }
    public GameObject DeathSFX()
    {
        switch (enemyDeathSFX)
        {
            case FXEnum.None:
                return null;
            case FXEnum.fx1:
                return enemySfx1;
            case FXEnum.fx2:
                return enemySfx2;
            case FXEnum.fx3:
                return enemySfx3;
            default:
                return null;
        }
    }
    IEnumerator SetCameraZoom(float zoomValue, float dur)
    {
        while (Camera.main.orthographicSize > zoomValue)
        {
            Camera.main.orthographicSize -= 0.2F;
            yield return new WaitForEndOfFrame();
        }
        Camera.main.orthographicSize = zoomValue;
        yield return new WaitForSecondsRealtime(dur);
        slowmoCoroutine = StartCoroutine(RevertCamera());
    }
    IEnumerator RevertCamera()
    {
        while (Camera.main.orthographicSize < 10)
        {
            Camera.main.orthographicSize += enemyCameraZoomSmoothing;
            yield return new WaitForEndOfFrame();
        }
        Camera.main.orthographicSize = 10;
    }
    public void EnemyDamageShake(Vector3 pos = default)
    {
        if (HurtSFX() != null)
            Instantiate(HurtSFX(), pos, Quaternion.identity);
        if (HurtParticle() != null)
            Instantiate(HurtParticle(), pos, Quaternion.identity);


        if (slowmoCoroutine != null) StopCoroutine(slowmoCoroutine);
        slowmoCoroutine = StartCoroutine(SetSlowmotion(slowmotionValue, slowmotionDuration));
        CameraController.ScreenShake(enemyHurtScreenShakeValue, enemyHurtScreenShakeValue);
    }
    public void EnemyDeathShake(Vector3 pos = default)
    {
        if (DeathSFX() != null)
            Instantiate(DeathSFX(), pos, Quaternion.identity);
        if (DeathParticle() != null)
            Instantiate(DeathParticle(), pos, Quaternion.identity);

        StartCoroutine(SetCameraZoom(enemyCameraZoomValue, 0.5F));
        if (slowmoCoroutine != null) StopCoroutine(slowmoCoroutine);
        slowmoCoroutine = StartCoroutine(SetSlowmotion(deathSlowMotionValue, deathSlowMotionDuration));
        CameraController.ScreenShake(enemyDeathScreenShakeValue, enemyDeathScreenShakeValue);
    }
    IEnumerator SetSlowmotion(float val, float dur)
    {
        Time.timeScale = val;
        Time.fixedDeltaTime = startTimeStep * Time.timeScale;
        yield return new WaitForSecondsRealtime(dur);
        slowmoCoroutine = StartCoroutine(RevertSlowmotion());
    }
    IEnumerator RevertSlowmotion()
    {
        while (Time.timeScale < 1
            //&& !isPaused
            )
        {
            Time.timeScale = Time.timeScale + slowMotionSmoothing;

            Time.fixedDeltaTime = startTimeStep * Time.timeScale;
            yield return new WaitForEndOfFrame();
        }


        Time.timeScale = 1;
        Time.fixedDeltaTime = startTimeStep;

    }
    public void SetupSliders()
    {

        landingScreenShakeSlider.value = landScreenShakeValue;
        landingSlowmotionText.text = landScreenShakeValue.ToString("F2");

        Debug.Log(enemyHurtScreenShakeValue);
        enemyHurtShakeSlider.value = enemyHurtScreenShakeValue;
        Debug.Log(enemyHurtScreenShakeValue);
        enemyHurtShakeText.text = enemyHurtScreenShakeValue.ToString("F2");

        enemySlowmotionValueSlider.value = slowmotionValue;
        enemyHurtSlowmotionValueText.text = slowmotionValue.ToString("F3");

        enemySlowmotionDurationSlider.value = slowmotionDuration;
        enemyHurtSlowmotionDurationText.text = slowmotionDuration.ToString("F2");

        deathCameraZoomSlider.value = enemyCameraZoomValue;
        deathCameraZoomText.text = enemyCameraZoomValue.ToString("F2");

        deathCameraSmoothingSlider.value = enemyCameraZoomSmoothing;
        deathCameraSmoothingText.text = enemyCameraZoomSmoothing.ToString("F3");

        enemyDeathShakeSlider.value = enemyDeathScreenShakeValue;
        enemyDeathShakeText.text = enemyDeathScreenShakeValue.ToString("F2");

        enemyDeathSlowMotionValueSlider.value = deathSlowMotionValue;
        enemyDeathSlowMotionValueText.text = deathSlowMotionValue.ToString("F3");

        enemyDeathSlowMotionDurationSlider.value = deathSlowMotionDuration;
        enemyDeathSlowMotionDurationText.text = deathSlowMotionDuration.ToString("F2");
    }

    public void UpdateSliders()
    {
        if (Time.timeSinceLevelLoad < 1f)
            return;

        landScreenShakeValue = Mathf.Round(landingScreenShakeSlider.value * 100f) / 100f;
        landingSlowmotionText.text = landScreenShakeValue.ToString("F2");

        enemyHurtScreenShakeValue = Mathf.Round(enemyHurtShakeSlider.value * 100f) / 100f;
        enemyHurtShakeText.text = enemyHurtScreenShakeValue.ToString("F2");

        slowmotionValue = Mathf.Round(enemySlowmotionValueSlider.value * 1000f) / 1000f;
        enemyHurtSlowmotionValueText.text = slowmotionValue.ToString("F3");

        slowmotionDuration = Mathf.Round(enemySlowmotionDurationSlider.value * 100f) / 100f;
        enemyHurtSlowmotionDurationText.text = slowmotionDuration.ToString("F2");

        enemyCameraZoomValue = Mathf.Round(deathCameraZoomSlider.value * 100f) / 100f;
        deathCameraZoomText.text = enemyCameraZoomValue.ToString("F2");

        enemyCameraZoomSmoothing = Mathf.Round(deathCameraSmoothingSlider.value * 1000f) / 1000f;
        deathCameraSmoothingText.text = enemyCameraZoomSmoothing.ToString("F3");

        enemyDeathScreenShakeValue = Mathf.Round(enemyDeathShakeSlider.value * 100f) / 100f;
        enemyDeathShakeText.text = enemyDeathScreenShakeValue.ToString("F2");

        deathSlowMotionValue = Mathf.Round(enemyDeathSlowMotionValueSlider.value * 1000f) / 1000f;
        enemyDeathSlowMotionValueText.text = deathSlowMotionValue.ToString("F3");

        deathSlowMotionDuration = Mathf.Round(enemyDeathSlowMotionDurationSlider.value * 100f) / 100f;
        enemyDeathSlowMotionDurationText.text = deathSlowMotionDuration.ToString("F2");

        saveFile.SaveData();
    }
}
