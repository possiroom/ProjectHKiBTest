using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graffiti : MonoBehaviour
{
    private List<Vector2> graffitiVectorSet = new List<Vector2>();
    private List<PlayerSkillDataSO> skillList = new List<SkillDataS0>();
    
    int completedSkillNum = -1;

    //��ų �߰��ڵ�
    PlayerSkillDataSO Windmill = new PlayerSkillDataSO();
    Windmill.graffitiCodes={(0,0), (0,1),(1,0),(0,-1),(-1,0)};
    skillList.Add(Windmill);

    // public bool ContainsVector(Vector2 target)
    // {

    //     return false;
    // }

    //�̰� ���� ������ ��ũ��Ʈ ������ �ҵ�. 

    //���� ��ǥ currentVector


    void CheckGraffitiProgress(Vector2)//�̰� �� �ǵ�� ��¼�� �̰� �� ����
    {  
        bool check = true;
        bool end = false;
        // ������ ������ ȣ��

        // ValidateVectorSet�� 
        //false�� �������� �ǵ��� �Բ�
        //vectorset �ʱ�ȭ�ϰ� ����Ʈ �׸� �͵� ����.
        //���ÿ�completedSkillNum >= 0�̸� CheckGraffitiComplete ȣ�� ,

        //true�� �̵��� �ڸ��� ��¦��
        // CheckCompleted >= 0 �� ���� �ǵ��, completedSkillNum�� ��
        //get player's vector
        Vector2 currentVector

        int completedSkillNum = CheckCompleted();
        while(!check || completedSkillNum >= 0){
            graffitiVectorSet.Add(currentVector);
            check = ValidateVectorSet(graffitiVectorSet);
            //print Vectorset();
        }

        if(completedSkillNum >= 0){
            //success feedback-> green effect
            CheckGraffitiComplete(completedSkillNum);
            end=true;
        }

        //fail
        if(!check){
            //fail feedback-> red effect
            end=true;
        }

        if (end) {
            graffitiVectorSet.Clear();
        }
    }

    void CheckGraffitiComplete(int num)
    {   
        switch(num){
            case 0: //windmill skill on
        }
        return num=-1;
    }
    // �׶���Ƽ ���� ���� ��ǲ�� ������ ȣ��
    // �÷��̾ ��ų �ߵ��ϵ��� ��

    List<Vector2> VectorSet()
    {
        List<Vector2> patterns=null;

        foreach (var graffitiCode in Windmill.graffitiAllCases){
            if (graffitiVectorSet.All(vector => graffitiCode.code.Contains(vector)))
                {
                    patterns = graffitiCode.code;  
                    break;
                }
        }
        return patterns;

    }

    bool ValidateVectorSet(Vector2 vector)
    {
        List<Vector2> patterns;
        graffitiVectorSet.Add(vector);

        foreach (var graffitiCode in Windmill.graffitiAllCases){
            if (graffitiVectorSet.All(Vector2 => Windmill.graffitiAllCases.Contains(Vector2)))
                return true;
        }
        return false;

    }

    // �̵��� ������ vectorset�� ��ų �߿� ���ԵǴ��� Ȯ��
    int CheckCompleted()
    {
        foreach (var graffitiCode in Windmill.graffitiAllCases)
            if (graffitiCode.code.SequenceEqual(graffitiVectorSet))
                return 0;


        return -1;
    }
    // ���� vectorset�� ��ų �� �ϳ��� ��ġ�ϴ��� Ȯ��

}
