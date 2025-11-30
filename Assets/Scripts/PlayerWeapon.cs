using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance = 100f;
    [SerializeField] AudioSource laserAudio;
    bool isFiring = false;
    void Start()
    {
        Cursor.visible = false;
    }
    private void Update() 
    {
        ProcessFiring();
        MoveCrosshair();
        MoveTargetPoint();
        AimLasers();
    }
    public void OnFire(InputValue value) 
    {
        isFiring = value.isPressed;
    }
    void ProcessFiring()
    {
        foreach (GameObject laser in lasers)
        {
            var emmissionModule = laser.GetComponent<ParticleSystem>().emission;
            emmissionModule.enabled = isFiring;
        }
        if (isFiring && !laserAudio.isPlaying)
        {
            laserAudio.Play();
        }
        else if (!isFiring && laserAudio.isPlaying)
        {
            laserAudio.Stop();
        }
    }
    void MoveCrosshair()
    {
        crosshair.position = Input.mousePosition;
    }
    void MoveTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }
    void AimLasers() 
    {
        foreach (GameObject laser in lasers)
        {
            Vector3 fireDirection = targetPoint.position - this.transform.position;
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);
            laser.transform.rotation = rotationToTarget;
        }
    }
}
