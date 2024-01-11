using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float lineLength;
    [SerializeField] float offset;
    [SerializeField] bool isJumping;
    [SerializeField] bool isGrounded;

    [SerializeField] ParticleSystem jumpParticles;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //movimiento
        GetComponent<Rigidbody2D>().velocity = new Vector2(playerSpeed * Input.GetAxisRaw("Horizontal"), GetComponent<Rigidbody2D>().velocity.y);
        if (Input.GetAxisRaw("Horizontal") == 1) GetComponent<SpriteRenderer>().flipX = false;
        if (Input.GetAxisRaw("Horizontal") == -1) GetComponent<SpriteRenderer>().flipX = true;
        //salto
        if (Input.GetButtonDown("Fire1") && !isJumping)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpParticles.Play();


           // AudioManager.instance.PlaySFX("Jump");
        }

        //linea debajo de muñeco
        Vector2 origin = new Vector2(transform.position.x, transform.position.y - offset);
        Vector2 target = new Vector2(transform.position.x, transform.position.y - offset - lineLength);
        Debug.DrawLine(origin, target, Color.black);
        //Raycast linea
        RaycastHit2D raycast = Physics2D.Raycast(origin, Vector2.down, lineLength);
        //Detectar colision Raycast
        if (raycast.collider == null) isJumping = true;
        else isJumping = false;

        if (raycast.collider == null)
        {
            if (GetComponent<Rigidbody2D>().velocity.y < 0) SetAnimation("fall");
            if (GetComponent<Rigidbody2D>().velocity.y > 0) SetAnimation("jump");
        }
        else
        {
            // Si está sobre una superficie pero se mueve lateralmente
            if (GetComponent<Rigidbody2D>().velocity.x != 0) SetAnimation("walk");
            else SetAnimation("idle"); // Si está sobre una superficie pero no se mueve

        }

        void SetAnimation(string name)
        {

            // Obtenemos todos los parámetros del Animator
            AnimatorControllerParameter[] parametros = GetComponent<Animator>().parameters;

            // Recorremos todos los parámetros y los ponemos a false
            foreach (var item in parametros) GetComponent<Animator>().SetBool(item.name, false);

            // Activamos el pasado por parámetro
            GetComponent<Animator>().SetBool(name, true);

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            if (collision.collider.CompareTag("Enemy"))
            {
              //  AudioManager.instance.PlayMusic("Lost_A_Life");
              //  AudioManager.instance.PlaySFX("Hit");
              //  SCManager.instance.LoadScene("Lose");
            }
        }
    }

    private void CreateDust() 
    {
    
    }
}
