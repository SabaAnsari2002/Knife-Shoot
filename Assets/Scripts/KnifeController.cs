using UnityEngine;
using UnityEngine.SceneManagement; // Add this line
public class KnifeController : MonoBehaviour
{
    private Rigidbody2D knifeRigidbody2D;
    
    private KnifeManager KnifeManager;
    [SerializeField] private float moveSpeed;
    private bool canShoot;

    private void Start(){
        GetComponentValues();
    }

    private void Update(){
        HandleShootInput();
    }

    private void FixedUpdate(){
        Shoot();
    }

    private void HandleShootInput(){
        if (Input.GetMouseButtonDown(0)){
            canShoot = true;
        }
    }

    private void Shoot(){
        if (canShoot){
            knifeRigidbody2D.AddForce(Vector2.up * moveSpeed * Time.fixedDeltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("Circle")){
            KnifeManager.SetActiveKnife();
            KnifeManager.SetDisableKnifeIconColor();
            canShoot = false;
            knifeRigidbody2D.isKinematic = true;
            // چاقو که خورد به اون دایره فیزیکش خاموش شه

            transform.SetParent(other.gameObject.transform);
            //چاقو خورد به دایره بره زیر مچموعه اش

        }

        if(other.gameObject.CompareTag("Knife"))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void GetComponentValues(){
        knifeRigidbody2D = GetComponent<Rigidbody2D>();
        KnifeManager = GameObject.FindObjectOfType<KnifeManager>();
    }

}
