using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveFile : MonoBehaviour
{
    public SaveData saveData;
    public JuiceSlider juiceSlider;

    private void Awake()
    {
        LoadData();
        //  juiceSlider.UpdateSliders();
    }
    public void LoadData()
    {
        saveData.landingScreenShake = PlayerPrefs.GetFloat("landingScreenShake");
        saveData.jumpVFX = PlayerPrefs.GetInt("jumpVFX");
        Debug.Log(PlayerPrefs.GetInt("jumpVFX"));
        saveData.jumpSFX = PlayerPrefs.GetInt("jumpSFX");
        saveData.landingVFX = PlayerPrefs.GetInt("landingVFX");
        saveData.landingSFX = PlayerPrefs.GetInt("landingSFX");
        saveData.music = PlayerPrefs.GetInt("music");

        saveData.hurtScreenShake = PlayerPrefs.GetFloat("hurtScreenShake");
        saveData.hurtSlowMotionValue = PlayerPrefs.GetFloat("hurtSlowMotionValue");
        saveData.hurtSlowMotionDuration = PlayerPrefs.GetFloat("hurtSlowMotionDuration");
        saveData.hurtVFX = PlayerPrefs.GetInt("hurtVFX");
        saveData.hurtSFX = PlayerPrefs.GetInt("hurtSFX");

        saveData.cameraZoom = PlayerPrefs.GetFloat("cameraZoom");
        saveData.cameraSmooth = PlayerPrefs.GetFloat("cameraSmooth");
        saveData.deathScreenShake = PlayerPrefs.GetFloat("deathScreenShake");
        saveData.deathSlowMotionValue = PlayerPrefs.GetFloat("deathSlowMotionValue");
        saveData.deathSlowMotionDuration = PlayerPrefs.GetFloat("deathSlowMotionDuration");
        saveData.deathVFX = PlayerPrefs.GetInt("deathVFX");
        saveData.deathSFX = PlayerPrefs.GetInt("deathSFX");

        juiceSlider.landScreenShakeValue = saveData.landingScreenShake;
        juiceSlider.jumpParticle = (JuiceSlider.FXEnum)saveData.jumpVFX;
        juiceSlider.jumpSFX = (JuiceSlider.FXEnum)saveData.jumpSFX;
        juiceSlider.landParticle = (JuiceSlider.FXEnum)saveData.landingVFX;
        juiceSlider.landSFX = (JuiceSlider.FXEnum)saveData.landingSFX;

        juiceSlider.SetJumpParticle(saveData.jumpVFX);
        juiceSlider.SetJumpSFX(saveData.jumpSFX);
        juiceSlider.SetLandParticle(saveData.landingVFX);
        juiceSlider.SetLandSFX(saveData.landingSFX);

        juiceSlider.enemyHurtScreenShakeValue = saveData.hurtScreenShake;
        juiceSlider.slowmotionValue = saveData.hurtSlowMotionValue;
        juiceSlider.slowmotionDuration = saveData.hurtSlowMotionDuration;
        juiceSlider.enemyHurtParticle = (JuiceSlider.FXEnum)saveData.hurtVFX;
        juiceSlider.enemyHurtSFX = (JuiceSlider.FXEnum)saveData.hurtSFX;

        juiceSlider.SetHurtParticle(saveData.hurtVFX);
        juiceSlider.SetHurtSFX(saveData.hurtSFX);

        juiceSlider.enemyCameraZoomValue = saveData.cameraZoom;
        juiceSlider.enemyCameraZoomSmoothing = saveData.cameraSmooth;
        juiceSlider.enemyDeathScreenShakeValue = saveData.deathScreenShake;
        juiceSlider.deathSlowMotionValue = saveData.deathSlowMotionValue;
        juiceSlider.deathSlowMotionDuration = saveData.deathSlowMotionDuration;
        juiceSlider.enemyDeathParticle = (JuiceSlider.FXEnum)saveData.deathVFX;
        juiceSlider.enemyDeathSFX = (JuiceSlider.FXEnum)saveData.deathSFX;

        juiceSlider.SetDeathParticle(saveData.deathVFX);
        juiceSlider.SetDeathSFX(saveData.deathSFX);
        juiceSlider.SetBGM(saveData.music);

        StartCoroutine(DelaySetup());

        //if (File.Exists(Application.persistentDataPath + "/saveData.json"))
        //{
        //    saveData = JsonUtility.FromJson<SaveData>(File.ReadAllText(Application.persistentDataPath + "/saveData.json"));




        //}
        //else {
        //    juiceSlider.SetJumpParticle(0);
        //    juiceSlider.SetJumpSFX(0);
        //    juiceSlider.SetLandParticle(0);
        //    juiceSlider.SetLandSFX(0);

        //    juiceSlider.SetHurtParticle(0);
        //    juiceSlider.SetHurtSFX(0);
        //    juiceSlider.SetDeathParticle(0);
        //    juiceSlider.SetDeathSFX(0);
        //}
    }

    IEnumerator DelaySetup()
    {
        yield return new WaitForFixedUpdate();
        juiceSlider.SetupSliders();
    }

    public void SaveData()
    {
        saveData.landingScreenShake = juiceSlider.landingScreenShakeSlider.value;
        PlayerPrefs.SetFloat("landingScreenShake", saveData.landingScreenShake);
        saveData.jumpVFX = (int)juiceSlider.jumpParticle;
        PlayerPrefs.SetInt("jumpVFX", saveData.jumpVFX);
        Debug.Log(PlayerPrefs.GetInt("jumpVFX"));
        saveData.jumpSFX = (int)juiceSlider.jumpSFX;
        PlayerPrefs.SetInt("jumpSFX", saveData.jumpSFX);
        saveData.landingVFX = (int)juiceSlider.landParticle;
        PlayerPrefs.SetInt("landingVFX", saveData.landingVFX);
        saveData.landingSFX = (int)juiceSlider.landSFX;
        PlayerPrefs.SetInt("landingSFX", saveData.landingSFX);
        saveData.music = juiceSlider.bgmTrack;
        PlayerPrefs.SetInt("music", saveData.music);

        saveData.hurtScreenShake = juiceSlider.enemyHurtScreenShakeValue;
        PlayerPrefs.SetFloat("hurtScreenShake", saveData.hurtScreenShake);
        saveData.hurtSlowMotionValue = juiceSlider.slowmotionValue;
        PlayerPrefs.SetFloat("hurtSlowMotionValue", saveData.hurtSlowMotionValue);
        saveData.hurtSlowMotionDuration = juiceSlider.slowmotionDuration;
        PlayerPrefs.SetFloat("hurtSlowMotionDuration", saveData.hurtSlowMotionDuration);
        saveData.hurtVFX = (int)juiceSlider.enemyHurtParticle;
        PlayerPrefs.SetInt("hurtVFX", saveData.hurtVFX);
        saveData.hurtSFX = (int)juiceSlider.enemyHurtSFX;
        PlayerPrefs.SetInt("hurtSFX", saveData.hurtSFX);

        saveData.cameraZoom = juiceSlider.enemyCameraZoomValue;
        PlayerPrefs.SetFloat("cameraZoom", saveData.cameraZoom);
        saveData.cameraSmooth = juiceSlider.enemyCameraZoomSmoothing;
        PlayerPrefs.SetFloat("cameraSmooth", saveData.cameraSmooth);
        saveData.deathScreenShake = juiceSlider.enemyDeathScreenShakeValue;
        PlayerPrefs.SetFloat("deathScreenShake", saveData.deathScreenShake);
        saveData.deathSlowMotionValue = juiceSlider.deathSlowMotionValue;
        PlayerPrefs.SetFloat("deathSlowMotionValue", saveData.deathSlowMotionValue);
        saveData.deathSlowMotionDuration = juiceSlider.deathSlowMotionDuration;
        PlayerPrefs.SetFloat("deathSlowMotionDuration", saveData.deathSlowMotionDuration);
        saveData.deathVFX = (int)juiceSlider.enemyDeathParticle;
        PlayerPrefs.SetInt("deathVFX", saveData.deathVFX);
        saveData.deathSFX = (int)juiceSlider.enemyDeathSFX;
        PlayerPrefs.SetInt("deathSFX", saveData.deathSFX);

        PlayerPrefs.Save();


        string jsonData = JsonUtility.ToJson(saveData, true);
        File.WriteAllText(Application.persistentDataPath + "/saveData.json", jsonData);
    }
}

[System.Serializable]
public class SaveData
{
    public float landingScreenShake;
    public int jumpVFX;
    public int jumpSFX;
    public int landingVFX;
    public int landingSFX;
    public int music;

    public float hurtScreenShake;
    public float hurtSlowMotionValue;
    public float hurtSlowMotionDuration;
    public int hurtVFX;
    public int hurtSFX;

    public float cameraZoom;
    public float cameraSmooth;
    public float deathScreenShake;
    public float deathSlowMotionValue;
    public float deathSlowMotionDuration;
    public int deathVFX;
    public int deathSFX;
}