using UnityEngine;

// Tutorial: https://www.youtube.com/watch?v=REPefSyru-I&ab_channel=Terresquall
public class PlayerController : MonoBehaviour
{
    // Controle de movimentos;
    private CharacterController controller;
    private Animator animator;

    private float moveSpeed = 2f;

    [Header("Movement System")]
    private readonly float walkSpeed = 4f;
    private readonly float runSpeed = 8f;

    void Start()
    {
        // Get componentes de movimentação;
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Dance();
    }

    private void Dance()
    {
        if (Input.GetKey(KeyCode.LeftControl)) // Left cntrl
        {
            animator.SetBool("IsDancing", true);
        } else
        {
            animator.SetBool("IsDancing", false);
        }
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
        }

        // Existe uma variável chamada "Speed". Set-a um valor funcional;
        animator.SetFloat("Speed", velocity.magnitude);
    }
}
