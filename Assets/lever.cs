using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private Transform leverStick; // 레버의 막대 부분만 참조
    [SerializeField] private float maxRotationAngle = 90f; // 최대 회전 각도
    [SerializeField] private float rotationSpeed = 5f; // 회전 속도
    [SerializeField] private Vector3 rotationAxis = Vector3.forward; // 회전축 (Z축 기준)
    
    private float currentRotation = 0f;
    private float targetRotation = 0f;
    
    // 회전 방향 설정 (-1: 왼쪽, 1: 오른쪽)
    public void SetLeverDirection(float direction)
    {
        targetRotation = direction * maxRotationAngle;
    }
    
    void Update()
    {
        // 키보드 입력 확인 (테스트용)
        CheckInput();
        
        // 부드러운 회전 적용
        currentRotation = Mathf.Lerp(currentRotation, targetRotation, Time.deltaTime * rotationSpeed);
        
        // 막대 부분만 회전
        leverStick.localRotation = Quaternion.Euler(rotationAxis * currentRotation);
    }
    
    void CheckInput()
    {
        float direction = 0f;
        
        if (Input.GetKey(KeyCode.Z))
        {
            direction = -1f;
        }
        SetLeverDirection(direction);
    }
}