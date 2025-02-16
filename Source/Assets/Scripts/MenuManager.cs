﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public Animator anim;
    public GameObject optionsPanel;
    public GameObject mainPanel;
    public GameObject fadePanel;

    public RectTransform celestusTitle;
    public RectTransform titlePos;
    private Vector2 iniPos;
    public float difScale;

    public LevelLoader loader;

    void Awake(){
        loader = GetComponent<LevelLoader>();
        fadePanel.SetActive(true);
    }

    void Start(){
        //optionsPanel.SetActive(false);
        mainPanel.SetActive(true);
        //iniPos = celestusTitle.position;
    }
    public void ExitButtons()
    {
        Application.Quit();
    }
    
    public void OptionsButton() {
		optionsPanel.SetActive(true);
        mainPanel.SetActive(false);
        //celestusTitle.localScale *= difScale;
        //celestusTitle.position = titlePos.position;
    }

    public void CreditsButton()
    {

    }

    public void OptionsBackButton()
    {
        //celestusTitle.position = iniPos;
        //celestusTitle.localScale *= (1 / difScale);
        optionsPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    public void PlayButton(string sceneName)
    {
        StartCoroutine(Fading(sceneName));
    }

    IEnumerator Fading(string sceneName)
    {
        anim.SetBool("Fade", true);
        yield return new WaitForSeconds(1.0f);
        loader.LoadLevel(sceneName);
    }

    
}
