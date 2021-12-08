using UnityEngine;

public class GuardMove : MonoBehaviour
{
    //�ƶ��ٶ�
    public float speed = 0.15f;
    private Vector2 dest = Vector2.zero;

    private void Start()
    {
        dest = transform.position;   
    }

    private void FixedUpdate()  //ÿ֡���е��ã����ⲻͬ�����ٶȲ�һ��
    {
        //��ֵ�õ�Ҫ�ƶ���destλ�õ���һ���ƶ�����
        Vector2 temp = Vector2.MoveTowards(transform.position, dest, speed);
        //ͨ�����������������λ��
        GetComponent<Rigidbody2D>().MovePosition(temp);
        //�����ȴﵽ��һ��dest��λ�òſ��Է����µ�Ŀ�ĵ�����ָ���֤��һ��һ���ƶ�
        if ((Vector2)transform.position == dest)
        {
            if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && Valid(Vector2.up))
            {
                dest = (Vector2)transform.position + Vector2.up;
            }
            if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && Valid(Vector2.down))
            {
                dest = (Vector2)transform.position + Vector2.down;
            }
            if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && Valid(Vector2.left))
            {
                dest = (Vector2)transform.position + Vector2.left;
            }
            if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && Valid(Vector2.right))
            {
                dest = (Vector2)transform.position + Vector2.right;
            }
            //��ȡ�ƶ�����
            Vector2 dir = dest - (Vector2)transform.position;
            //�ѻ�ȡ�����ƶ��������ø�����״̬��
            GetComponent<Animator>().SetFloat("DirX", dir.x);
            GetComponent<Animator>().SetFloat("DirY", dir.y);

        }


    }
    //��⽫Ҫȥ��λ���Ƿ���Ե���
    private bool Valid(Vector2 dir)  //
    {
        //��¼�µ�ǰλ��
        Vector2 pos = transform.position;
        //�ӽ�Ҫ�����λ����ǰλ�÷���һ�����ߣ���������������Ϣ
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        //���ش������Ƿ���˳Զ��������ϵ���ײ��
        return (hit.collider == GetComponent<Collider2D>());
    }
}
