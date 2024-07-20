using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortingAlgorithms
{
    public partial class Form1 : Form
    {
        private int[] array;
        private Random rand = new Random();
        private bool sortingInProgress = false;
        private bool sortingStopped = false;
        private int highlightedIndex = -1;
        private int currentDelay = 100;

        public Form1()
        {
            InitializeComponent();
            this.Resize += new EventHandler(Form1_Resize);
            Start.Click += Start_Click_1Async;
            Randomize.Click += Randomize_Click;
            Stop.Click += Stop_Click;
            button1.Click += button1_Click;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            panel3.Paint += Panel3_Paint;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeArray();
            panel3.Invalidate(); // Redraw the panel
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            panel3.Invalidate(); // Redraw the panel on resize
        }

        private void InitializeArray()
        {
            int barCount = Math.Min(panel3.Width / 10, 100); // Increase bar count
            array = new int[barCount];
            List<int> values = Enumerable.Range(1, barCount).ToList();
            for (int i = 0; i < barCount; i++)
            {
                int index = rand.Next(values.Count);
                array[i] = values[index];
                values.RemoveAt(index);
            }
            highlightedIndex = -1; // Clear highlighted index
        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {
            DrawBars(e.Graphics, false);
        }
        private void DrawBars(Graphics g, bool sortingCompleted = false)
        {
            if (array == null) return;

            int barWidth = Math.Max(panel3.Width / array.Length, 1);

            g.Clear(panel3.BackColor);
            for (int i = 0; i < array.Length; i++)
            {
                float barHeight = (float)array[i] / array.Length * panel3.Height;
                float x = i * barWidth;
                float y = panel3.Height - barHeight;

                if (sortingCompleted)
                {
                    g.FillRectangle(Brushes.Green, x, y, barWidth - 2, barHeight);
                }
                else if (i == highlightedIndex)
                {
                    g.FillRectangle(Brushes.Red, x, y, barWidth - 2, barHeight);
                    PlaySoundForBar(array[i]);
                }
                else
                {
                    g.FillRectangle(Brushes.White, x, y, barWidth - 2, barHeight);
                }

                g.DrawRectangle(Pens.Black, x, y, barWidth - 2, barHeight);
                g.FillRectangle(Brushes.Gray, x, 0, barWidth - 2, y); // Extend the gray part to cover the entire bar width
            }
        }
        private void PlaySoundForBar(int value)
        {
            int frequency = 300 + (value * 10); // Adjusted frequency range to make it sound higher
            int duration = currentDelay / 2; // Adjust duration to make it less loud
            Task.Run(() => Console.Beep(frequency, duration)); // Play sound with frequency and delay
        }
        private void DrawSingleBar(int index, Color color)
        {
            if (array == null || index < 0 || index >= array.Length) return;

            int barWidth = Math.Max(panel3.Width / array.Length, 1);
            float barHeight = (float)array[index] / array.Length * panel3.Height;
            float x = index * barWidth;
            float y = panel3.Height - barHeight;

            using (Graphics g = panel3.CreateGraphics())
            {
                g.FillRectangle(new SolidBrush(color), x, y, barWidth - 2, barHeight);
                g.DrawRectangle(Pens.Black, x, y, barWidth - 2, barHeight);
                g.FillRectangle(Brushes.Gray, x, 0, barWidth - 2, y); // Extend the gray part to cover the entire bar width
            }

            if (color == Color.Red) // Play sound only if the bar is highlighted
            {
                PlaySoundForBar(array[index]);
            }
        }
        private void Randomize_Click(object sender, EventArgs e)
        {
            InitializeArray();
            panel3.Invalidate(); // Redraw the panel
        }

        private async void Start_Click_1Async(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a sorting algorithm from the dropdown menu.");
                return;
            }

            richTextBox1.Clear();
            Randomize.Visible = false;
            Start.Visible = false;
            Stop.Visible = true;
            comboBox1.Visible = false;
            label1.Visible = false;
            sortingInProgress = true;
            sortingStopped = false;

            richTextBox1.AppendText("Initial array: " + string.Join(", ", array) + "\n");
            richTextBox1.ScrollToCaret(); // Ensure the last line is visible

            string algorithm = comboBox1.SelectedItem.ToString();
            switch (algorithm)
            {
                case "Quick Sort":
                    richTextBox1.AppendText("Starting Quick Sort\n");
                    richTextBox1.ScrollToCaret(); // Ensure the last line is visible
                    await QuickSort(array, 0, array.Length - 1);
                    break;
                case "Merge Sort":
                    richTextBox1.AppendText("Starting Merge Sort\n");
                    richTextBox1.ScrollToCaret(); // Ensure the last line is visible
                    await MergeSort(array, 0, array.Length - 1);
                    break;
                case "Heap Sort":
                    richTextBox1.AppendText("Starting Heap Sort\n");
                    richTextBox1.ScrollToCaret(); // Ensure the last line is visible
                    await HeapSort(array);
                    break;
                case "Selection Sort":
                    richTextBox1.AppendText("Starting Selection Sort\n");
                    richTextBox1.ScrollToCaret(); // Ensure the last line is visible
                    await SelectionSort(array);
                    break;
                case "Insertion Sort":
                    richTextBox1.AppendText("Starting Insertion Sort\n");
                    richTextBox1.ScrollToCaret(); // Ensure the last line is visible
                    await InsertionSort(array);
                    break;
                case "Bubble Sort":
                    richTextBox1.AppendText("Starting Bubble Sort\n");
                    richTextBox1.ScrollToCaret(); // Ensure the last line is visible
                    await BubbleSort(array);
                    break;
            }

            sortingInProgress = false;
            if (!sortingStopped)
                await CheckTrue(); // Highlight sorted bars in green
            Stop.Visible = false;
            Randomize.Visible = true;
            Start.Visible = true;
            comboBox1.Visible = true;
            label1.Visible = true;
        }

        private async Task QuickSort(int[] array, int low, int high)
        {
            if (sortingStopped) return;

            if (low < high)
            {
                int pi = await Partition(array, low, high);
                await QuickSort(array, low, pi - 1);
                await QuickSort(array, pi + 1, high);
            }

            if (!sortingStopped && !sortingInProgress)
                panel3.Invalidate(); // Redraw final sorted bars
        }

        private async Task<int> Partition(int[] array, int low, int high)
        {
            int pivot = array[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (sortingStopped) return -1;

                highlightedIndex = j;
                DrawSingleBar(j, Color.Red); // Highlight the current index
                await Task.Delay(currentDelay); // Delay for visualization
                DrawSingleBar(j, Color.White); // Revert to white after delay

                if (array[j] < pivot)
                {
                    i++;
                    Swap(array, i, j);
                    DrawSingleBar(i, Color.Red); // Highlight the swapped bar
                    DrawSingleBar(j, Color.Red); // Highlight the swapped bar
                    await Task.Delay(currentDelay); // Delay for visualization
                    DrawSingleBar(i, Color.White); // Revert to white after delay
                    DrawSingleBar(j, Color.White); // Revert to white after delay

                    richTextBox1.AppendText($"Swapping {array[i]} and {array[j]}\n");
                    richTextBox1.ScrollToCaret(); // Ensure the last line is visible
                }
            }

            Swap(array, i + 1, high);
            highlightedIndex = i + 1;
            DrawSingleBar(i + 1, Color.Red); // Highlight the swapped bar
            DrawSingleBar(high, Color.Red); // Highlight the swapped bar
            await Task.Delay(currentDelay); // Delay for visualization
            DrawSingleBar(i + 1, Color.White); // Revert to white after delay
            DrawSingleBar(high, Color.White); // Revert to white after delay

            richTextBox1.AppendText($"Swapping {array[i + 1]} and {array[high]}\n");
            richTextBox1.ScrollToCaret(); // Ensure the last line is visible

            return i + 1;
        }
        private async Task SelectionSort(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (sortingStopped) return;

                    highlightedIndex = j;
                    DrawSingleBar(j, Color.Red); // Highlight the current index
                    PlaySoundForBar(array[j]);
                    await Task.Delay(currentDelay); // Delay for visualization
                    DrawSingleBar(j, Color.White); // Revert to white after delay

                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    Swap(array, i, minIndex);
                    DrawSingleBar(i, Color.Red); // Highlight the swapped bar
                    DrawSingleBar(minIndex, Color.Red); // Highlight the swapped bar
                    PlaySoundForBar(array[minIndex]);
                    await Task.Delay(currentDelay); // Delay for visualization
                    DrawSingleBar(i, Color.White); // Revert to white after delay
                    DrawSingleBar(minIndex, Color.White); // Revert to white after delay

                    richTextBox1.AppendText($"Swapped {array[minIndex]} with {array[i]} at positions {i} and {minIndex}\n");
                    richTextBox1.ScrollToCaret(); // Ensure the last line is visible
                }
                else
                {
                    richTextBox1.AppendText($"No swap needed for position {i}, minimum already at position {minIndex}\n");
                    richTextBox1.ScrollToCaret(); // Ensure the last line is visible
                }

                panel3.Invalidate(); // Redraw the panel after each iteration
            }

            if (!sortingStopped && !sortingInProgress)
                panel3.Invalidate(); // Redraw final sorted bars
        }
        private async Task BubbleSort(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (sortingStopped) return;

                    highlightedIndex = j;
                    DrawSingleBar(j, Color.Red); // Highlight the current index
                    DrawSingleBar(j + 1, Color.Red); // Highlight the next index
                    PlaySoundForBar(array[j]);
                    await Task.Delay(currentDelay); // Delay for visualization
                    DrawSingleBar(j, Color.White); // Revert to white after delay
                    DrawSingleBar(j + 1, Color.White); // Revert to white after delay

                    if (array[j] > array[j + 1])
                    {
                        Swap(array, j, j + 1);
                        DrawSingleBar(j, Color.Red); // Highlight the swapped bar
                        DrawSingleBar(j + 1, Color.Red); // Highlight the swapped bar
                        PlaySoundForBar(array[j + 1]);
                        await Task.Delay(currentDelay); // Delay for visualization
                        DrawSingleBar(j, Color.White); // Revert to white after delay
                        DrawSingleBar(j + 1, Color.White); // Revert to white after delay

                        richTextBox1.AppendText($"Swapped {array[j]} with {array[j + 1]} at positions {j} and {j + 1}\n");
                        richTextBox1.ScrollToCaret(); // Ensure the last line is visible
                    }
                }
                panel3.Invalidate(); // Redraw the panel after each iteration
            }

            if (!sortingStopped && !sortingInProgress)
                panel3.Invalidate(); // Redraw final sorted bars
        }
        private async Task InsertionSort(int[] array)
        {
            int n = array.Length;
            for (int i = 1; i < n; ++i)
            {
                int key = array[i];
                int j = i - 1;

                while (j >= 0 && array[j] > key)
                {
                    if (sortingStopped) return;

                    array[j + 1] = array[j];
                    highlightedIndex = j + 1;
                    DrawSingleBar(j + 1, Color.Red); // Highlight the current index
                    PlaySoundForBar(array[j + 1]);
                    await Task.Delay(currentDelay); // Delay for visualization
                    DrawSingleBar(j + 1, Color.White); // Revert to white after delay

                    j = j - 1;
                }
                array[j + 1] = key;
                highlightedIndex = j + 1;
                DrawSingleBar(j + 1, Color.Red); // Highlight the current index
                PlaySoundForBar(array[j + 1]);
                await Task.Delay(currentDelay); // Delay for visualization
                DrawSingleBar(j + 1, Color.White); // Revert to white after delay

                richTextBox1.AppendText($"Inserting {key} at position {j + 1}\n");
                richTextBox1.ScrollToCaret(); // Ensure the last line is visible
            }

            if (!sortingStopped && !sortingInProgress)
                panel3.Invalidate(); // Redraw final sorted bars
        }

        private async Task MergeSort(int[] array, int left, int right)
        {
            if (sortingStopped) return;

            if (left < right)
            {
                int middle = (left + right) / 2;
                await MergeSort(array, left, middle);
                await MergeSort(array, middle + 1, right);
                await Merge(array, left, middle, right);
            }
        }

        private async Task Merge(int[] array, int left, int middle, int right)
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;
            int[] L = new int[n1];
            int[] R = new int[n2];
            Array.Copy(array, left, L, 0, n1);
            Array.Copy(array, middle + 1, R, 0, n2);

            int i = 0, j = 0, k = left;
            while (i < n1 && j < n2)
            {
                if (sortingStopped) return;

                highlightedIndex = k;
                DrawSingleBar(k, Color.Red); // Highlight the current index
                PlaySoundForBar(array[k]);
                richTextBox1.AppendText($"Comparing {L[i]} and {R[j]}\n");
                richTextBox1.ScrollToCaret(); // Ensure the last line is visible
                await Task.Delay(currentDelay); // Delay for visualization

                if (L[i] <= R[j])
                {
                    array[k] = L[i];
                    i++;
                }
                else
                {
                    array[k] = R[j];
                    j++;
                }
                k++;
                DrawSingleBar(k - 1, Color.White); // Revert to white after delay
            }

            while (i < n1)
            {
                if (sortingStopped) return;

                array[k] = L[i];
                highlightedIndex = k;
                DrawSingleBar(k, Color.Red); // Highlight the current index
                PlaySoundForBar(array[k]);
                richTextBox1.AppendText($"Moving {L[i]} to position {k}\n");
                richTextBox1.ScrollToCaret(); // Ensure the last line is visible
                await Task.Delay(currentDelay); // Delay for visualization
                i++;
                k++;
                DrawSingleBar(k - 1, Color.White); // Revert to white after delay
            }

            while (j < n2)
            {
                if (sortingStopped) return;

                array[k] = R[j];
                highlightedIndex = k;
                DrawSingleBar(k, Color.Red); // Highlight the current index
                PlaySoundForBar(array[k]);
                richTextBox1.AppendText($"Moving {R[j]} to position {k}\n");
                richTextBox1.ScrollToCaret(); // Ensure the last line is visible
                await Task.Delay(currentDelay); // Delay for visualization
                j++;
                k++;
                DrawSingleBar(k - 1, Color.White); // Revert to white after delay
            }

            // Clear highlighting after the merge step is done
            highlightedIndex = -1;
            panel3.Invalidate();
        }

        private async Task HeapSort(int[] array)
        {
            if (sortingStopped) return;

            int n = array.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
            {
                await Heapify(array, n, i);
            }

            for (int i = n - 1; i > 0; i--)
            {
                if (sortingStopped) return;

                Swap(array, 0, i);
                highlightedIndex = i;
                DrawSingleBar(0, Color.Red); // Highlight the swapped bar
                DrawSingleBar(i, Color.Red); // Highlight the swapped bar
                PlaySoundForBar(array[i]);
                await Task.Delay(currentDelay); // Delay for visualization
                DrawSingleBar(0, Color.White); // Revert to white after delay
                DrawSingleBar(i, Color.White); // Revert to white after delay

                richTextBox1.AppendText($"Swapping {array[0]} and {array[i]}\n");
                richTextBox1.ScrollToCaret(); // Ensure the last line is visible

                await Heapify(array, i, 0);
            }

            if (!sortingStopped && !sortingInProgress)
                panel3.Invalidate(); // Redraw final sorted bars
        }
        private async Task Heapify(int[] array, int n, int i)
        {
            if (sortingStopped) return; // Stop kontrolü ekledik

            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && array[left] > array[largest])
                largest = left;

            if (right < n && array[right] > array[largest])
                largest = right;

            if (largest != i)
            {
                Swap(array, i, largest);
                highlightedIndex = largest;
                DrawSingleBar(i, Color.Red); // Highlight the swapped bar
                DrawSingleBar(largest, Color.Red); // Highlight the swapped bar
                PlaySoundForBar(array[largest]);
                await Task.Delay(currentDelay); // Delay for visualization
                DrawSingleBar(i, Color.White); // Revert to white after delay
                DrawSingleBar(largest, Color.White); // Revert to white after delay

                richTextBox1.AppendText($"Swapping {array[i]} and {array[largest]}\n");
                richTextBox1.ScrollToCaret(); // Ensure the last line is visible

                await Heapify(array, n, largest);
            }
        }

        private void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        private async Task CheckTrue()
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (sortingStopped) return;

                highlightedIndex = i;
                Color barColor = (i > 0 && array[i] < array[i - 1]) ? Color.Black : Color.Green;
                DrawSingleBar(i, barColor);
                await Task.Delay(currentDelay); // Delay for visualization

                richTextBox1.AppendText($"Checking position {i}: {array[i]} is {(barColor == Color.Green ? "correct" : "incorrect")}\n");
                richTextBox1.ScrollToCaret(); // Ensure the last line is visible

                PlaySoundForBar(array[i]); // Play sound during CheckTrue step
            }

            Randomize.Visible = true;
            Start.Visible = true;
            comboBox1.Visible = true;
            label1.Visible = true;
        }
        private void Stop_Click(object sender, EventArgs e)
        {
            sortingStopped = true;
            sortingInProgress = false;
            Stop.Visible = false;
            Randomize.Visible = true;
            Start.Visible = true;
            comboBox1.Visible = true;
            label1.Visible = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string algorithm = comboBox1.SelectedItem.ToString();
            label2.Text = algorithm;
            switch (algorithm)
            {
                case "Quick Sort":
                    label3.Text = "Quick sort is an efficient sorting algorithm, serving as a systematic method for placing the elements of an array in order.\n" +
                                  "Advantages:\n" +
                                  "1. Average-case time complexity is O(n log n).\n" +
                                  "2. In-place sort (requires only a small, constant amount of additional storage space).\n" +
                                  "Disadvantages:\n" +
                                  "1. Worst-case time complexity is O(n^2), but this can be mitigated with good pivot selection (e.g., using median-of-three).\n" +
                                  "2. Not stable (does not preserve the relative order of equal elements).\n" +
                                  "Usage: Suitable for large datasets where average performance is important.";
                    break;
                case "Merge Sort":
                    label3.Text = "Merge sort is an efficient, stable, comparison-based, divide and conquer sorting algorithm.\n" +
                                  "Advantages:\n" +
                                  "1. Time complexity is O(n log n) in all cases (best, average, and worst).\n" +
                                  "2. Stable (preserves the relative order of equal elements).\n" +
                                  "Disadvantages:\n" +
                                  "1. Requires additional space proportional to the array size (O(n) space complexity).\n" +
                                  "Usage: Suitable for sorting linked lists and large datasets where stability is required.";
                    break;
                case "Heap Sort":
                    label3.Text = "Heap sort is a comparison-based sorting algorithm that uses a binary heap data structure.\n" +
                                  "Advantages:\n" +
                                  "1. Time complexity is O(n log n) in all cases.\n" +
                                  "2. In-place sort (requires only a small, constant amount of additional storage space).\n" +
                                  "Disadvantages:\n" +
                                  "1. Not stable (does not preserve the relative order of equal elements).\n" +
                                  "2. Slower in practice compared to Quick Sort due to additional overhead of maintaining the heap structure.\n" +
                                  "Usage: Suitable for applications where memory usage is critical.";
                    break;
                case "Selection Sort":
                    label3.Text = "Selection sort is an in-place comparison sorting algorithm.\n" +
                                  "Advantages:\n" +
                                  "1. Simple to understand and implement.\n" +
                                  "2. Performs well on small lists.\n" +
                                  "Disadvantages:\n" +
                                  "1. Time complexity is O(n^2), making it inefficient on large lists.\n" +
                                  "2. Not stable (does not preserve the relative order of equal elements).\n" +
                                  "Usage: Suitable for small datasets or educational purposes.";
                    break;
                case "Insertion Sort":
                    label3.Text = "Insertion sort is a simple sorting algorithm that builds the final sorted array one item at a time.\n" +
                                  "Advantages:\n" +
                                  "1. Time complexity is O(n^2) in the average and worst cases, but O(n) in the best case (when the array is already sorted).\n" +
                                  "2. Stable (preserves the relative order of equal elements).\n" +
                                  "3. Efficient for small datasets or nearly sorted data.\n" +
                                  "Disadvantages:\n" +
                                  "1. Inefficient for large datasets.\n" +
                                  "Usage: Suitable for small datasets or nearly sorted arrays.";
                    break;
                case "Bubble Sort":
                    label3.Text = "Bubble sort is a simple sorting algorithm that repeatedly steps through the list, compares adjacent elements and swaps them if they are in the wrong order.\n" +
                                  "Advantages:\n" +
                                  "1. Simple to understand and implement.\n" +
                                  "2. Stable (preserves the relative order of equal elements).\n" +
                                  "Disadvantages:\n" +
                                  "1. Time complexity is O(n^2), making it inefficient on large lists.\n" +
                                  "2. Generally considered the least efficient sorting algorithm for large datasets.\n" +
                                  "Usage: Suitable for educational purposes and small datasets.";
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Title = "Save RichTextBox Content";
            saveFileDialog1.FileName = "sorting_log.txt";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
                MessageBox.Show("File saved successfully.");
            }
        }
    }
}
