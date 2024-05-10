using UnityEngine;

public class BlockVisibility : MonoBehaviour
{
    private Material blockMaterial;
    private bool isVisible = false; // 블록의 가시성 상태를 나타내는 변수

    void Start()
    {
        blockMaterial = GetComponent<Renderer>().material;
        // 시작할 때 블록을 투명하게 설정합니다.
        SetTransparency(0f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌한 객체가 플레이어인지 확인합니다.
        if (collision.gameObject.CompareTag("Player"))
        {
            // 플레이어에 닿으면 블록을 보이게 설정합니다.
            SetTransparency(1f);
        }
    }

    void SetTransparency(float alpha)
    {
        // 블록의 투명도를 조절합니다.
        Color color = blockMaterial.color;
        color.a = alpha;
        blockMaterial.color = color;
    }
}
