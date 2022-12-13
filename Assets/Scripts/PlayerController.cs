using System.Collections;
using UnityEngine;

// Tutorial: https://www.youtube.com/watch?v=REPefSyru-I&ab_channel=Terresquall
public class PlayerController : MonoBehaviour
{
    // Controles de movimentos e som;
    private CharacterController controller;
    private Animator animator;
    public AudioSource audioSourceDance;
    public AudioSource audioSourceInsult;

    [Header("Movement")]
    private float moveSpeed = 2f;
    private readonly float walkSpeed = 4f;
    private readonly float runSpeed = 8f;

    PlayerInteractionController playerInteraction;

    void Start()
    {
        // Get componentes de movimentação;
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        playerInteraction = GetComponentInChildren<PlayerInteractionController>();
    }

    void Update()
    {
        Move();
        Dance();
        Insult();
        Jump();
        Interact();
    }

    private void Move()
    {
        // Iniciar processo de movimentação;
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(horizontal, 0f, vertical).normalized;

        // Gerar velocidade de movimentação do personagem com base em algumas regras específicas/necessárias;
        Vector3 velocity = moveSpeed * Time.deltaTime * dir;

        // Checar se a "sprint key" (shift) está sendo pressionada;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = runSpeed;
            animator.SetBool("IsRunning", true);
        }
        else
        {
            moveSpeed = walkSpeed;
            animator.SetBool("IsRunning", false);
        }

        // Checar se houve alguma movimentação;
        if (dir.magnitude >= 0.1f)
        {
            // Virar o personagem pra direção clicada;
            transform.rotation = Quaternion.LookRotation(dir);

            // Movimentar-se;
            controller.Move(velocity);
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }

        // Existe uma variável chamada "Speed". Set-a um valor funcional;
        animator.SetFloat("Speed", velocity.magnitude);     
    }

    private void Dance()
    {
        bool isMoving = animator.GetBool("IsMoving");
        bool isInsulting = animator.GetBool("IsInsulting");
        if (Input.GetKey(KeyCode.LeftControl) && !isMoving && !isInsulting)
        {
            animator.SetBool("IsDancing", true);
        }
        else
        {
            animator.SetBool("IsDancing", false);
        }

        bool isDancing = animator.GetBool("IsDancing");
        if (isDancing && !audioSourceDance.isPlaying)
        {
            audioSourceDance.Play();
        }
        else if (!isDancing)
        {
            audioSourceDance.Stop();
        }
    }

    private void Insult()
    {
        bool isMoving = animator.GetBool("IsMoving");
        bool isDancing = animator.GetBool("IsDancing");
        if (Input.GetKey(KeyCode.CapsLock) && !isMoving && !isDancing)
        {
            animator.SetBool("IsInsulting", true);
        }
        else
        {
            animator.SetBool("IsInsulting", false);
        }

        bool isInsulting = animator.GetBool("IsInsulting");
        if (isInsulting && !audioSourceInsult.isPlaying)
        {
            audioSourceInsult.Play();
        }
        else if (!isInsulting)
        {
            audioSourceInsult.Stop();
        }
    }

    private bool isPodePular = true;
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isPodePular)
            {
                isPodePular = false;
                animator.SetBool("IsJumping", true);
                StartCoroutine(SetIsPodePularTrue());
            }
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }
    }

    private IEnumerator SetIsPodePularTrue()
    {
        yield return new WaitForSeconds(0.8f);
        isPodePular = true;
    }

    private void Interact()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            playerInteraction.Interact();
        }
    }
}
