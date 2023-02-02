using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class EndGame : MonoBehaviour,IInteractable
{
    [SerializeField] private GameObject playerCam;
    [SerializeField] private float reactivateTime;
    private bool levelComplete;
    [SerializeField] private GameObject laser;
    [SerializeField] private Transform levelCompletePanel;
    public void Interact(Transform transform)
    {
        if (!levelComplete)
        {
            levelComplete = true;
            PlayerScript.Instance.playerJoystickMovement.enabled = false;
            playerCam.SetActive(false);
            StartCoroutine(WaitBeforeActivate());
        }
    }

    private IEnumerator WaitBeforeActivate()
    {
        yield return new WaitForSeconds(reactivateTime);
        laser.SetActive(false);
        yield return new WaitForSeconds(.5f);
        levelCompletePanel.DOScale(Vector3.one, 1f);

    }
}
