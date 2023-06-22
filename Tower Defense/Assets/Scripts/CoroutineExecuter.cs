using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence
{
    public class CoroutineExecuter : MonoBehaviour
    {
        public void Execute(IEnumerator coroutine)
        {
            StartCoroutine(coroutine);
        }
    }
}
