package main

import (
	"sort"
	"strings"
)

//feel free to define additional functions as needed

func palindrome(str string) bool {
	for i := 0; i < len(str)/2; i++ {
		if str[i] != str[len(str)-i-1] {
			return false
		}
	}
	return true
}

func wordcount(str string) string {
	words := strings.Split(str, " ")
	wordMap := make(map[string]int)
	for i := range words {
		wordMap[words[i]]++
	}
	maxCount := 0
	for _, v := range wordMap {
		if v > maxCount {
			maxCount = v
		}
	}
	wordsMax := make([]string, 0, len(wordMap))
	for k, v := range wordMap {
		if v == maxCount {
			wordsMax = append(wordsMax, k)
		}
	}
	sort.Strings(wordsMax)
	return wordsMax[0]
}

func rotate(numbers []int) []int {
	rotateBy := numbers[0]
	len := len(numbers) - 1
	for i := 0; i < rotateBy; i++ {
		x := numbers[len]
		numbers = numbers[:len]
		numbers = append([]int{x}, numbers...)
	}
	return numbers
}

func fib(nums []int) int {
	sum := 0
	for _, num := range nums {
		sum += fibonacci(num)
	}
	return sum
}

func fibonacci(n int) int {
	if n <= 1 {
		return n
	}
	return fibonacci(n-1) + fibonacci(n-2)
}

func main() {
	performTests()
}
