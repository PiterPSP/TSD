# Pieces of cake :white_circle:

Place your solutions in `sufficient.go`. For each of the tasks listed below, there is a set of tests prepared. Run `go run *.go` in this folder to run your solutions agains the test cases.

## Task 1: Palindrome
Write a function `palindrome` that determines if a given string is a palindrome.

```go
palindrome("kayak") // true
palindrome("sample") // false
```
## Task 2: Word count
Create a function `wordcount` that, using a map, finds the word in the provided input string that has the most occurrences. If there is more than one, return the one that is first in the alphabetical order.

```go
wordcount("word test word") // "word"
wordcount("a a b g e ab e e a") // "a"
```

## Task 3: Rotating a slice

Write a function `rotate` that for a given input slice of positive ints returns a slice that is rotated by _k_ elements to the right where _k_ is the initial value of the first element in the input slice.

```go
rotate([]int{1, 2, 3, 4}) // [2 3 4 1]; rotated by 1
rotate([]int{5, 3, 20, 1, 2}) // [5 3 20 1 2]; rotated by 5
```

## Task 4: Fibonacci Sequence sum
Write a function `fib` that takes a slice _k_ of _n_ ints (_k<sub>0</sub>..k<sub>n-1</sub>_) as an argument and returns the sum of all _k<sub>i</sub>-th_ elements of the Fibonacci Sequence. If one number appears more than once in the input slice, it's corresponding Fibonacci Sequence element should be added once for each occurrence.

```go
fib([]int{1, 2, 3}) // 4; explenation: 1 => 1, 2 => 1, 3 => 2, their sum = 4
fib([]int{1, 2, 8}) // 24; explenation: 1 => 1, 2 => 1, 8 => 21, their sum = 24
```