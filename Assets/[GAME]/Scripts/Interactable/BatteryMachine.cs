using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BatteryMachine : MonoBehaviour, IInteractable
{
    [SerializeField] List<Transform> emptyBatteryBeds;
    private int _filledBatteryBeds=0;
    [SerializeField] private Material topPartMat;
    [SerializeField] private Transform batteryDoor;
    [SerializeField] private Renderer topPartRenderer;
    public void Interact(Transform transform)
    {
        if (_filledBatteryBeds < 8 && PlayerScript.Instance.collectedBatterys.Count!=0)
        {
            foreach (var battery in PlayerScript.Instance.collectedBatterys)
            {
                battery.parent = emptyBatteryBeds[_filledBatteryBeds];
                PlayerScript.Instance.filledSeatCount--;
                battery.transform.DOLocalMove(Vector3.zero, 1f);
                battery.transform.DOLocalRotate(Vector3.zero, 1f);
                _filledBatteryBeds++;
                

            }
            PlayerScript.Instance.collectedBatterys.Clear();
            if(_filledBatteryBeds==7) DoorOpen();
        }
    }

    private void DoorOpen()
    {
        topPartRenderer.material = topPartMat;
        batteryDoor.DOLocalMoveY(-1, 1f);
    }
    
}
