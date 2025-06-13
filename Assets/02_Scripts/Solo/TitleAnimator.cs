using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using JunTweening;

public class TitleAnimator : MonoBehaviour
{
    [SerializeField] string _titleText = "Soldier Tower Defense";
    [SerializeField] GameObject _letterPrefab; // 글자 프리팹 (Text 또는 TMP_Text 포함)
    [SerializeField] Transform _letterParent;
    [SerializeField] float _interval = 0.1f;
    [SerializeField] Vector3 _startOffset = new Vector3(0, 200, 0);

    void Start()
    {
        StartCoroutine(SpawnLetters());
    }

    IEnumerator SpawnLetters()
    {
        for (int i = 0; i < _titleText.Length; i++)
        {
            char c = _titleText[i];

            // 공백이면 그냥 건너뛰고 약간의 위치만 추가
            if (c == ' ')
            {
                yield return new WaitForSeconds(_interval);
                continue;
            }

            GameObject letter = Instantiate(_letterPrefab, _letterParent);
            letter.transform.localPosition += _startOffset;

            // 텍스트 설정
            var text = letter.GetComponent<Text>();
            if (text != null)
                text.text = c.ToString();

            // TMP_Text용
            // var tmp = letter.GetComponent<TMP_Text>();
            // if (tmp != null)
            //     tmp.text = c.ToString();

            // 애니메이션 적용 (예: JunTween으로 떨어지기)
            letter.transform.JunMoveLocal(Vector3.zero, 0.5f).SetEase(JunEase.OutBounce);

            yield return new WaitForSeconds(_interval);
        }
    }
}
