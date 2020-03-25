using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sorted
{
    class Program
    {
         static   int[] R = { 0,3,6,5,9,7,1,8,2,4};
        
        static void Main(string[] args)
        {
            Console.WriteLine("原始数据为：");
            for (int i = 1; i < R.Length; i++)
            {
                Console.Write(R[i].ToString());
            }
            Console.WriteLine("排序之后为：");

            int[] s = R;
            MergeSort(s, 0, s.Length - 1);

            for (int i = 1; i < R.Length; i++)
            {
                Console.Write(R[i].ToString());
            }
            Console.ReadLine();
        }



        //直接插入排序
        public static void insertSort()
        {
            int j;
            for (int i = 2; i < R.Length; i++)
            {
                R[0] = R[i];//将待插入的元素放置到R[0]中 
                j = i - 1;
                while (R[0]<R[j])
                {
                    R[j + 1] = R[j];//移动记录
                    j--;
                }
                R[j + 1] = R[0];//将插入的元素插入到合适位置
            }
        }

        
        //shell排序
        public static void shellSort()
        {
            int j,temp;
            for (int d = R.Length/2; d>=1;d=d/2)
            {
                for (int i = d; i < R.Length; i++)
                {
                    temp = R[i];
                    j = i - d;
                    while (j>=0&&temp<R[j])
                    {
                        R[j + d] = R[j];
                        j  = j - d;
                    }
                    R[j + d] = temp;
                } 
            }
        }

        //冒泡排序
        public static void BubbleSort()
        {
            for (int j = 1; j < R.Length; j++)
            {
                for (int i = 0; i < R.Length - j; i++)
                {
                    if (R[i]>R[i+1])
                    {//交换数据（前者大于后者）
                        int temp = R[i];
                        R[i] = R[i + 1];
                        R[i + 1] = temp;
                    }
                }
            }
        }


        //选择排序
        public static void selectionSrot()
        {
            int k, temp;
            for (int i = 0; i < R.Length-1; i++)
            {
                k = i;//k用于记录一趟排序中最小元素的索引号
                for (int j =i+1; j < R.Length; j++)
                {
                    if (R[j]<R[k])//只要发现比R【j】小的元素
                    {
                        k = j;
                    }
                }
                if (i!=k)
                {//交换R[i] 和 R[k]的值，把最小的元素放在最左边

                    temp = R[i];
                    R[i] = R[k];
                    R[k] = temp;
                }
            }
        }





        //建堆过程
        public static void shift(int[] s, int low, int high)
        {//i为欲调整子树的根节点的索引号，j为这个节点的左孩子
            int i = low, j = 2 * i + 1;
            int temp = s[i];//记录双亲节点
            while (j <= high)
            {//如果左孩子小于右孩子，则将欲交换的孩子结点指向右孩子
                if (j < high && s[j] < s[j + 1])
                {
                    j++;//j指向右孩子
                }
                if (temp < s[j])//如果双亲节点小于他的孩子结点
                {
                    s[i] = s[j];//交换双亲节点和他的孩子
                    i = j;//以交换后的孩子结点为根，继续调整它的子树
                    j = 2 * i + 1;//j此时代表交换后的孩子结点的左孩子
                }
                else
                {
                    break;//调整完毕
                }
            }
            s[i] = temp;//使最初被调整的结点放入正确位置
        }

        //堆排序
        public static void HeapSort(int[] s)
        {
            int n = R.Length;//序列的长度
            for (int i = n / 2 - 1; i >= 0; i--)//创建初始堆
            {
                shift(s, i, n - 1);
            }
            for (int i = n - 1; i >= 1; i--)
            {
                int temp = R[0];//去堆顶元素
                R[0] = R[i];//让堆中最后一个元素上移到堆顶位置
                R[i] = temp;//此时R[i]已不在堆中，用于存放排序好的元素
                shift(s, 0, i - 1);//重新调整堆
            }
        }



        public static void Merge(int[] s, int low, int mid, int high)
        {//r为临时空间用于存放合并后的数据
            int[] r = new int[high - low + 1];
            int i = low, j = mid + 1, k = 0;//k代表r的下标
            while (i <= mid && j <= high)//合并两个子集合
            {
                r[k++] = (s[i] < s[j]) ? s[i++] : s[j++];
            }
            while (i <= mid)//将左边子集合的剩余部分复制到r
            {
                r[k++] = s[i++];
            }
            while (j <= high)//将右边子集合的剩余部分复制到r
            {
                r[k++] = s[j++];
            }
            for (k = 0, i = low; i <= high; i++, k++)
            {//将r复制到s中
                s[i] = r[k];
            }
        }
        //二路归并排序
        public static void MergeSort(int[] s, int low, int high)
        {
            if (low < high)
            {
                int mid = (low + high) / 2;

                MergeSort(s, low, mid);//归并左边子集合（递归调用）
                MergeSort(s, mid + 1, high);//归并右边子集合（递归调用）
                Merge(s, low, mid, high);//归并当前集合
            }

        }

      
    }
}
