// class Program
// {
//     static void Main(string[] args)
//     {
//         int[] numbers = ReadFile("input.txt");
//         int[] leftArray = new int[numbers.Length / 2];
//         int[] rightArray = new int[numbers.Length - numbers.Length / 2];

//         Array.Copy(numbers, 0, leftArray, 0, numbers.Length / 2);
//         Array.Copy(numbers, numbers.Length / 2, rightArray, 0, numbers.Length - numbers.Length / 2);

//         Thread thread1 = new Thread(() => MergeSort(leftArray, 0, leftArray.Length - 1));
//         Thread thread2 = new Thread(() => MergeSort(rightArray, 0, rightArray.Length - 1));

//         thread1.Start();
//         thread2.Start();

//         thread1.Join();
//         thread2.Join();

//         int[] sortedNumbers = Merge(leftArray, rightArray);
//         Console.WriteLine("Sorted numbers: " + string.Join(", ", sortedNumbers));
//     }

//     private static int[] ReadFile(string path)
//     {
//         int[] numbers = File.ReadAllLines(path)
//                             .Select(x => int.Parse(x))
//                             .ToArray();
//         return numbers;
//     }

//     private static void MergeSort(int[] arr, int left, int right)
//     {
//         if (left < right)
//         {
//             int middle = (left + right) / 2;

//             MergeSort(arr, left, middle);
//             MergeSort(arr, middle + 1, right);

//             Merge(arr, left, middle, right);
//         }
//     }

//     private static void Merge(int[] arr, int left, int middle, int right)
//     {
//         int[] leftArray = new int[middle - left + 1];
//         int[] rightArray = new int[right - middle];

//         Array.Copy(arr, left, leftArray, 0, middle - left + 1);
//         Array.Copy(arr, middle + 1, rightArray, 0, right - middle);

//         int i = 0;
//         int j = 0;
//         int k = left;

//         while (i < leftArray.Length && j < rightArray.Length)
//         {
//             if (leftArray[i] <= rightArray[j])
//             {
//                 arr[k] = leftArray[i];
//                 i++;
//             }
//             else
//             {
//                 arr[k] = rightArray[j];
//                 j++;
//             }
//             k++;
//         }

//         while (i < leftArray.Length)
//         {
//             arr[k] = leftArray[i];
//             i++;
//             k++;
//         }

//         while (j < rightArray.Length)
//         {
//             arr[k] = rightArray[j];
//             j++;
//             k++;
//         }
//     }

//     private static int[] Merge(int[] leftArray, int[] rightArray)
//     {
//         int[] result = new int[leftArray.Length + rightArray.Length];
//         int i = 0;
//         int j = 0;
//         int k = 0;
//         while (i < leftArray.Length && j < rightArray.Length)
//         {
//             if (leftArray[i] <= rightArray[j])
//             {
//                 result[k] = leftArray[i];
//                 i++;
//             }
//             else
//             {
//                 result[k] = rightArray[j];
//                 j++;
//             }
//             k++;
//         }

//         while (i < leftArray.Length)
//         {
//             result[k] = leftArray[i];
//             i++;
//             k++;
//         }

//         while (j < rightArray.Length)
//         {
//             result[k] = rightArray[j];
//             j++;
//             k++;
//         }

//         return result;
//     }
// }