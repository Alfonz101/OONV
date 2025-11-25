
    // --- Strategy interface ---
    public interface ISortStrategy
    {
        string Name { get; }
        void Sort(List<int> data);
    }

    // --- Concrete Strategy: Bubble Sort ---
    public class BubbleSortStrategy : ISortStrategy
    {
        public string Name => "Bubble Sort";

        public void Sort(List<int> data)
        {
            int n = data.Count;
            bool swapped;

            do
            {
                swapped = false;
                for (int i = 0; i < n - 1; i++)
                {
                    if (data[i] > data[i + 1])
                    {
                        int temp = data[i];
                        data[i] = data[i + 1];
                        data[i + 1] = temp;
                        swapped = true;
                    }
                }
                n--; // Last element is in correct place after each pass
            } while (swapped);
        }
    }

    // --- Concrete Strategy: Quick Sort ---
    public class QuickSortStrategy : ISortStrategy
    {
        public string Name => "Quick Sort";

        public void Sort(List<int> data)
        {
            QuickSort(data, 0, data.Count - 1);
        }

        private void QuickSort(List<int> data, int left, int right)
        {
            if (left >= right)
                return;

            int pivotIndex = Partition(data, left, right);
            QuickSort(data, left, pivotIndex - 1);
            QuickSort(data, pivotIndex + 1, right);
        }

        private int Partition(List<int> data, int left, int right)
        {
            int pivot = data[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (data[j] <= pivot)
                {
                    i++;
                    Swap(data, i, j);
                }
            }

            Swap(data, i + 1, right);
            return i + 1;
        }

        private void Swap(List<int> data, int i, int j)
        {
            int temp = data[i];
            data[i] = data[j];
            data[j] = temp;
        }
    }

    // --- Context: uses a sorting strategy ---
    public class SortContext
    {
        private ISortStrategy _strategy;

        public SortContext(ISortStrategy strategy)
        {
            _strategy = strategy;
        }

        public void SetStrategy(ISortStrategy strategy)
        {
            _strategy = strategy;
            Console.WriteLine($"\nChanged strategy to: {_strategy.Name}");
        }

        public void SortAndPrint(List<int> data)
        {
            // Work on a copy just for demonstration purposes
            var copy = new List<int>(data);

            Console.WriteLine($"\nUsing {_strategy.Name}:");
            Console.WriteLine("Original: " + string.Join(", ", data));

            _strategy.Sort(copy);

            Console.WriteLine("Sorted:   " + string.Join(", ", copy));
        }
    }

    // --- Client / Demo ---
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int> { 5, 1, 9, 3, 7, 2, 8 };

            // Start with Bubble Sort
            var context = new SortContext(new BubbleSortStrategy());
            context.SortAndPrint(numbers);

            // Change strategy at runtime to Quick Sort
            context.SetStrategy(new QuickSortStrategy());
            context.SortAndPrint(numbers);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }

