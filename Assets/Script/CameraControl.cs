using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel3;
    public GameObject Panel4;
    public GameObject Panel5;
    public Transform[] Views;
    public float TransitionSpeed;
    Transform CurrentViews;

    // Start is called before the first frame update
    void Start()
    {
        Panel1.SetActive(true);
        CurrentViews = Views[0];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Panel2.SetActive(false);
            Panel3.SetActive(false);
            Panel4.SetActive(false);
            CurrentViews = Views[0];
            Panel1.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Panel1.SetActive(false);
            Panel3.SetActive(false);
            Panel4.SetActive(false);
            CurrentViews = Views[1];
            Panel2.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Panel1.SetActive(false);
            Panel2.SetActive(false);
            Panel4.SetActive(false);
            CurrentViews = Views[2];
            Panel3.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Panel1.SetActive(false);
            Panel2.SetActive(false);
            Panel3.SetActive(false);
            CurrentViews = Views[3];
            Panel4.SetActive(true);
        }
    }

    public void StartClicked()
    {
        Panel1.SetActive(false);
        Panel3.SetActive(false);
        Panel4.SetActive(false);
        Panel5.SetActive(false);
        CurrentViews = Views[1];
        Panel2.SetActive(true);
    }

    public void ScoreClicked()
    {
        Panel1.SetActive(false);
        Panel2.SetActive(false);
        Panel4.SetActive(false);
        Panel5.SetActive(false);
        CurrentViews = Views[2];
        Panel3.SetActive(true);
    }

    public void AboutClicked()
    {
        Panel1.SetActive(false);
        Panel2.SetActive(false);
        Panel3.SetActive(false);
        Panel5.SetActive(false);
        CurrentViews = Views[3];
        Panel4.SetActive(true);
    }

    public void ExitClicked()
    {
        Application.Quit();
    }

    public void LoginClicked(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void RegisterClicked()
    {
        Panel1.SetActive(false);
        Panel2.SetActive(false);
        Panel3.SetActive(false);
        Panel4.SetActive(false);
        CurrentViews = Views[1];
        Panel5.SetActive(true);
    }

    public void Back_LoginClicked()
    {
        Panel2.SetActive(false);
        Panel3.SetActive(false);
        Panel4.SetActive(false);
        Panel5.SetActive(false);
        CurrentViews = Views[0];
        Panel1.SetActive(true);
    }

    public void Back_ScoreClicked()
    {
        Panel2.SetActive(false);
        Panel3.SetActive(false);
        Panel4.SetActive(false);
        Panel5.SetActive(false);
        CurrentViews = Views[0];
        Panel1.SetActive(true);
    }

    public void Back_AboutClicked()
    {
        Panel2.SetActive(false);
        Panel3.SetActive(false);
        Panel4.SetActive(false);
        Panel5.SetActive(false);
        CurrentViews = Views[0];
        Panel1.SetActive(true);
    }

    public void Back_RegisterClicked()
    {
        Panel1.SetActive(false);
        Panel3.SetActive(false);
        Panel4.SetActive(false);
        Panel5.SetActive(false);
        CurrentViews = Views[1];
        Panel2.SetActive(true);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, CurrentViews.position, Time.deltaTime * TransitionSpeed);

        Vector3 CurrentAngle = new Vector3(
            Mathf.LerpAngle(transform.rotation.eulerAngles.x, CurrentViews.transform.rotation.eulerAngles.x, Time.deltaTime * TransitionSpeed),
            Mathf.LerpAngle(transform.rotation.eulerAngles.y, CurrentViews.transform.rotation.eulerAngles.y, Time.deltaTime * TransitionSpeed),
            Mathf.LerpAngle(transform.rotation.eulerAngles.z, CurrentViews.transform.rotation.eulerAngles.z, Time.deltaTime * TransitionSpeed)
            );

        transform.eulerAngles = CurrentAngle;
    }
}
