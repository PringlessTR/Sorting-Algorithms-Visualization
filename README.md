# Sorting Algorithms Visualization

This project is a Windows Forms application that visualizes various sorting algorithms. The visualization shows how the algorithms work by displaying the array elements as bars and highlighting the steps taken during the sorting process.

![](/gif/1.gif)

## Features

- **Visualization of Sorting Algorithms:** 
  - Quick Sort
  - Merge Sort
  - Heap Sort
  - Selection Sort
  - Insertion Sort
  - Bubble Sort

- **Real-time visualization with delay adjustments**
- **Sound feedback for visualized steps**
- **Log of sorting steps and actions**
- **Ability to randomize the array and stop the sorting process**

## Usage

1. **Run the Application:** Start the application by opening the executable file.
2. **Select a Sorting Algorithm:** Choose one of the available sorting algorithms from the dropdown menu.
3. **Start Sorting:** Click the "Start" button to visualize the selected sorting algorithm.
4. **Randomize Array:** Click the "Randomize" button to generate a new random array.
5. **Stop Sorting:** Click the "Stop" button to halt the sorting process.
6. **Save Log:** Click the "Save Log" button to save the log of sorting steps to a text file.

## Sorting Algorithms

### Quick Sort
Quick sort is an efficient sorting algorithm, serving as a systematic method for placing the elements of an array in order.
- **Advantages:**
  - Average-case time complexity is O(n log n).
  - In-place sort (requires only a small, constant amount of additional storage space).
- **Disadvantages:**
  - Worst-case time complexity is O(n^2), but this can be mitigated with good pivot selection (e.g., using median-of-three).
  - Not stable (does not preserve the relative order of equal elements).
- **Usage:** Suitable for large datasets where average performance is important.

### Merge Sort
Merge sort is an efficient, stable, comparison-based, divide and conquer sorting algorithm.
- **Advantages:**
  - Time complexity is O(n log n) in all cases (best, average, and worst).
  - Stable (preserves the relative order of equal elements).
- **Disadvantages:**
  - Requires additional space proportional to the array size (O(n) space complexity).
- **Usage:** Suitable for sorting linked lists and large datasets where stability is required.

### Heap Sort
Heap sort is a comparison-based sorting algorithm that uses a binary heap data structure.
- **Advantages:**
  - Time complexity is O(n log n) in all cases.
  - In-place sort (requires only a small, constant amount of additional storage space).
- **Disadvantages:**
  - Not stable (does not preserve the relative order of equal elements).
  - Slower in practice compared to Quick Sort due to additional overhead of maintaining the heap structure.
- **Usage:** Suitable for applications where memory usage is critical.

### Selection Sort
Selection sort is an in-place comparison sorting algorithm.
- **Advantages:**
  - Simple to understand and implement.
  - Performs well on small lists.
- **Disadvantages:**
  - Time complexity is O(n^2), making it inefficient on large lists.
  - Not stable (does not preserve the relative order of equal elements).
- **Usage:** Suitable for small datasets or educational purposes.

### Insertion Sort
Insertion sort is a simple sorting algorithm that builds the final sorted array one item at a time.
- **Advantages:**
  - Time complexity is O(n^2) in the average and worst cases, but O(n) in the best case (when the array is already sorted).
  - Stable (preserves the relative order of equal elements).
  - Efficient for small datasets or nearly sorted data.
- **Disadvantages:**
  - Inefficient for large datasets.
- **Usage:** Suitable for small datasets or nearly sorted arrays.

### Bubble Sort
Bubble sort is a simple sorting algorithm that repeatedly steps through the list, compares adjacent elements and swaps them if they are in the wrong order.
- **Advantages:**
  - Simple to understand and implement.
  - Stable (preserves the relative order of equal elements).
- **Disadvantages:**
  - Time complexity is O(n^2), making it inefficient on large lists.
  - Generally considered the least efficient sorting algorithm for large datasets.
- **Usage:** Suitable for educational purposes and small datasets.
