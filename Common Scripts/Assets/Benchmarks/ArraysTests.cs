using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Common.Benchmarks
{
    public class ArraysTests : MonoBehaviour
    {
        [SerializeField]
        private int arrayLength = 50000, repeats = 25;

        [SerializeField]
        private Text text1, text2;

        private List<int> list;
        private int[] array;
        private int x;

        private void Start()
        {
            array = new int[arrayLength];
            list = new List<int>(arrayLength);
            for (int i = 0; i < arrayLength; i++)
            {
                array[i] = Random.Range(-10, 10);
                list.Add(Random.Range(-10, 10));
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                PerformanceMeasure.Display(ArrayFor, repeats, "Array For average", text1);
                PerformanceMeasure.Display(IListArrayFor, repeats, "IList (array) For average", text2);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                PerformanceMeasure.Display(ListFor, repeats, "List For average", text1);
                PerformanceMeasure.Display(IListFor, repeats, "IList (list) For average", text2);
            }
        }

        private void OnDestroy()
        {
            Debug.Log(x);
        }

        private void ArrayFor()
        {
            int sum = 0;

            for (int i = 0; i < array.Length; i++)
                sum += array[i];

            x = sum;
        }

        private void IListArrayFor()
        {
            IList<int> list = array;
            int sum = 0;

            for (int i = 0; i < list.Count; i++)
                sum += list[i];

            x = sum;
        }

        private void ListFor()
        {
            int sum = 0;

            for (int i = 0; i < list.Count; i++)
                sum += list[i];

            x = sum;
        }

        private void IListFor()
        {
            IList<int> list = this.list;
            int sum = 0;

            for (int i = 0; i < list.Count; i++)
                sum += list[i];

            x = sum;
        }
    }
}