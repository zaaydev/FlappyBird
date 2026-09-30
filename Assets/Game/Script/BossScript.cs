using UnityEngine;
using UnityEngine.UI;

public class BossScript : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject sprite1;
    [SerializeField] private Player player;
    [SerializeField] private Text Subtitle;
    private GameManager GameManagerScript;
    
    private void Awake() {
        GameManagerScript=  FindAnyObjectByType<GameManager>();
    }


    private float currentTime = 0f;
    private int fireLimit = 15;
    private int fireCount = 0;

    private void Update() {
        if (fireCount == fireLimit) return;

        if (currentTime < 0.9f) {
            currentTime += Time.deltaTime;
        } else {
            FireBullet();
            currentTime = 0;
        }
    }

    public void FireBullet() {
        Vector2 direction = player.transform.position - transform.position;
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
        float bulletSpeed = 15f;
        bulletRB.linearVelocity = direction.normalized * bulletSpeed;

        fireCount += 1;

        if (fireCount == fireLimit) {
            Invoke(nameof(FinalSubtitle), 4f);
        } 
    }

    public void FinalSubtitle() {
        sprite1.SetActive(false);
        Subtitle.gameObject.SetActive(true);
        Invoke(nameof(PlayerWon), 4f);
    }

    public void PlayerWon() {
        Subtitle.gameObject.SetActive(false);
        GameManagerScript.GameWon();        
    }
}
