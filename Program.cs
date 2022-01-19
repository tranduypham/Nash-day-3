
using System.Diagnostics;

namespace Day_3
{
    public class Program
    {
        static void Main(String[] arg){
            var sw = new Stopwatch();
            sw.Start();
            var primes = GetPrimesNumber(0,1000000).Result;
            foreach(int num in primes){
                Console.WriteLine(num);
            }
            sw.Stop();
            Console.WriteLine("Total time: {0}", sw.Elapsed.TotalMilliseconds);
            Clock clock = new Clock();
            while(true){
                clock.Change();
                Thread.Sleep(1000);
            }
        }

        class Clock{
            public delegate void ClockHandler(String str);
            public event ClockHandler onChange;

            public Clock(){
                ClockHandler clockHandler1 = new ClockHandler(this.notification);
                onChange += clockHandler1;
            }
            public void notification(String str){
                Console.WriteLine(str);
            }
            public void Change(){
                if(onChange != null){
                    String date = DateTime.Now.ToLocalTime().ToString();
                    onChange(date);
                }
            }
        }

        static async Task<List<int>> GetPrimesNumber(int min, int max){
            return await Task.Run(() => {
                var result = new List<int>();
                for(int i = min; i <= max; i++){
                    if(isPrimes(i)){
                        result.Add(i);
                    }
                }
                return result;
            });
        }
        
        // public static List<int> Primes = new List<int>();
        // public static List<int> notPrimes = new List<int>();
        static bool isPrimes(int number){
            // if(notPrimes.Contains(number)){
            //     return false;
            // }
            // if(Primes.Contains(number)){
            //     return true;
            // }
            if(number == 2){
                // Primes.Add(number);
                return true;
            }
            if(number % 2 == 0) {
                // notPrimes.Add(number);
                return false;
            }
            else {
                var topLimmit =  (int)Math.Floor(Math.Sqrt(number));
                for(int i = 2; i <= topLimmit; i ++){
                    if(number % i == 0){
                        // notPrimes.Add(number);
                        return false;
                    }
                }
                // Primes.Add(number);
                return true;
            }
        }
    }
}