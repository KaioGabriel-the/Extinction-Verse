using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FollowHeadset : MonoBehaviour
{
    public Transform headset;
    public float speed = 2.0f; // Velocidade do movimento pelo analógico

    private CharacterController controller;
    private Vector3 lastHeadPosition;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        lastHeadPosition = headset.position;
    }

    void Update()
    {
        // 1. AJUSTE DO COLLIDER (Igual ao original)
        controller.height = headset.localPosition.y;
        Vector3 center = new Vector3(headset.localPosition.x, controller.height / 2, headset.localPosition.z);
        controller.center = center;

        // 2. MOVIMENTO FÍSICO (Acompanhando sua caminhada no quarto)
        Vector3 headMovement = headset.position - lastHeadPosition;
        headMovement.y = 0;
        controller.Move(headMovement);
        lastHeadPosition = headset.position;

        // 3. MOVIMENTO PELO ANALÓGICO (Locomoção Artificial)
        float moveX = Input.GetAxis("Horizontal"); // Analógico Esquerdo (Esq/Dir)
        float moveZ = Input.GetAxis("Vertical");   // Analógico Esquerdo (Frente/Trás)

        // Calcula a direção baseada para onde a cabeça está olhando
        Vector3 forward = headset.forward;
        Vector3 right = headset.right;
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        Vector3 desiredMove = (forward * moveZ + right * moveX) * speed * Time.deltaTime;
        
        // Aplica o movimento do controle
        controller.Move(desiredMove);
    }
}