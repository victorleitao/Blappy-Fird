using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Jump Settings")]
    [Tooltip("How high is the jump.")]
    public float jumpPower = 0;
    public float jumpInterval = 0.5f;
    private float jumpCooldown = 0;

    [Header("Scripted Animation")]
    public GameObject leftWing;
    public GameObject rightWing;
    public GameObject openedLeftEye;
    public GameObject closedLeftEye;
    public GameObject openedRightEye;
    public GameObject closedRightEye;
    private float wingAngle = 0;
    private float blinkCooldown = 0f;
    [Tooltip("Duration of the closed eyes.")]
    public float blinkDuration = 0.15f;
    [Tooltip("Maximum and minimum intervals between blinkings.")]
    public Vector2 blinkInterval = new Vector2(2, 4);

    private Rigidbody thisRigidbody;

    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Check game active
        bool isGameActive = GameManager.Instance.IsGameActive();

        // Update blink cooldown
        blinkCooldown -= Time.fixedDeltaTime;
        bool canBlink = blinkCooldown <= 0 && isGameActive;

        // Blink
        if (canBlink)
        {
            StartCoroutine(Blink(blinkDuration));
            blinkCooldown = Random.Range(blinkInterval.x, blinkInterval.y);
        }

        // Update jump cooldown
        jumpCooldown -= Time.fixedDeltaTime;
        bool canJump = jumpCooldown <= 0 && isGameActive;

        // Jump
        if (canJump)
        {
            bool jumpInput = Input.GetKey(KeyCode.Space);
            if (jumpInput)
            {
                Jump();
            }
        }

        // Flap wings
        if (isGameActive)
        {
            wingAngle = thisRigidbody.velocity.y * -5;
            if (wingAngle >= 45)
            {
                wingAngle = 45;
            }
            rightWing.transform.localEulerAngles = new(wingAngle, 0, 0);
            leftWing.transform.localEulerAngles = new(wingAngle * -1, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ScreenLimit" || other.gameObject.tag == "Pipe")
        {
            GameManager.Instance.EndGame();
            thisRigidbody.constraints = RigidbodyConstraints.FreezePositionY;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ScoreCounter")
        {
            GameManager.Instance.playerScore++;
        }
    }

    private void Jump()
    {
        // Reset cooldown
        jumpCooldown = jumpInterval;

        // Apply force
        thisRigidbody.velocity = Vector3.zero;
        thisRigidbody.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
    }

    private IEnumerator Blink(float duration)
    {
        openedLeftEye.SetActive(false);
        closedLeftEye.SetActive(true);
        openedRightEye.SetActive(false);
        closedRightEye.SetActive(true);

        yield return new WaitForSeconds(duration);

        openedLeftEye.SetActive(true);
        closedLeftEye.SetActive(false);
        openedRightEye.SetActive(true);
        closedRightEye.SetActive(false);
    }
}
