using System;

namespace Basic13
{
    class Program
    {
        static void Main(string[] args)
        {
            //PrintNumbers();
            //PrintOdds();
            //PrintSum();
            int[] arrayOfInt = {1, 2, 3, 4, 5,-1,-7};
            //LoopArray(arrayOfInt);
            //FindMax(arrayOfInt);
            //GetAverage(arrayOfInt);
            //LoopArray(OddArray());
            //Console.WriteLine(GreaterThanY(arrayOfInt,3));
            //SquareArrayValues(arrayOfInt);
            //EliminateNegatives(arrayOfInt);
            //MinMaxAverage(arrayOfInt);
            //ShiftValues(arrayOfInt);
            object[] newArrayOfInt = NumToString(arrayOfInt);
            Console.WriteLine(newArrayOfInt[5]);
        }
        public static void PrintNumbers(){
            for(int i=1;i<=255;i++){
                Console.WriteLine(i);
            }
        }
        public static void PrintOdds(){
            for(int i=1;i<=255;i++){
                if(i%2!=0){
                    Console.WriteLine(i);
                }
            }
        }
        public static void PrintSum(){
            int sum=0;
            for(int i=0;i<=255;i++){
                sum+=i;
                Console.WriteLine($"New number: {i} Sum: {sum}");
            }
        }
        public static void LoopArray(int[] numbers){
            for(int i=0;i<numbers.Length;i++){
                Console.WriteLine(numbers[i]);
            }
        }
        public static int FindMax(int[] numbers){
            int max = numbers[0];
            for(int i=1;i<numbers.Length;i++){
                if(max < numbers[i]){
                    max = numbers[i];
                }
            }
            Console.WriteLine($"Max: {max}");
            return max;
        }
        public static void GetAverage(int[] numbers){
            int sum=0;
            for(int i=0;i<numbers.Length;i++){
                sum+=numbers[i];
            }
            Console.WriteLine($"Avg: {(double)sum/numbers.Length}");
        }
        public static int[] OddArray(){
            int arr_length = 0;
            for(int i=1;i<=255;i++){
                if(i%2!=0){
                    arr_length++;
                }
            }
            int[] numArray = new int[arr_length];
            for(int i=255;i>=1;i--){
                if(i%2!=0){
                    numArray[arr_length-1]=i;
                    arr_length--;
                }
            }
            return numArray;
        }
        public static int GreaterThanY(int[] numbers, int y){
            int num_of_values = 0;
            for(int i=0;i<numbers.Length;i++){
                if(numbers[i] > y){
                    num_of_values++;
                }
            }
            return num_of_values;
        }
        public static void SquareArrayValues(int[] numbers){
            for(int i=0;i<numbers.Length;i++){
                numbers[i] *= numbers[i];
            }
            LoopArray(numbers);
        }
        public static void EliminateNegatives(int[] numbers){
            for(int i=0;i<numbers.Length;i++){
                if(numbers[i] < 0){
                    numbers[i] = 0;
                }
            }
            LoopArray(numbers);
        }
        public static void MinMaxAverage(int[] numbers){
            FindMax(numbers);
            int min = numbers[0];
            for(int i=1;i<numbers.Length;i++){
                if(min > numbers[i]){
                    min = numbers[i];
                }
            }
            Console.WriteLine($"Min: {min}");
            GetAverage(numbers);
        }
        public static void ShiftValues(int[] numbers){
            for(int i=0;i<numbers.Length-1;i++){
                numbers[i] = numbers[i+1];
            }
            numbers[numbers.Length-1] = 0;
            LoopArray(numbers);
        }
        public static object[] NumToString(int[] numbers){
            object[] numArray = new object[numbers.Length];

            for(int i=0;i<numbers.Length;i++){
                if(0 > numbers[i]){
                    numArray[i] = "Dojo";
                }else{
                    numArray[i] = numbers[i];
                }
            }
            return numArray;
        }
    }
}
