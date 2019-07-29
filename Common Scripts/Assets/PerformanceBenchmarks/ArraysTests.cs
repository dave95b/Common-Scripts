using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Benchmarks
{
    public class ArraysTests : MonoBehaviour
    {
        [SerializeField]
        private int arrayLength = 50000, repeats = 25;

        [SerializeField]
        private Text text1, text2;

        private int[] array;
        private int x;

        private void Start()
        {
            array = new int[arrayLength];
            for (int i = 0; i < arrayLength; i++)
                array[i] = Random.Range(-10, 10);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                PerformanceMeasure.Display(Foreach, repeats, "Foreach average", text1);
                PerformanceMeasure.Display(IListForeach, repeats, "IList Foreach average", text2);
            }
        }

        private void OnDestroy()
        {
            Debug.Log(x);
        }

        private void Foreach()
        {
            int sum = 0;

            for (int i = 0; i < array.Length; i++)
                sum += array[i];

            x = sum;
        }

        private void IListForeach()
        {
            IList<int> list = array;
            int sum = 0;

            for (int i = 0; i < list.Count; i++)
                sum += list[i];

            x = sum;
        }
    }
}