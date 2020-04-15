def min_max(arr)
  max = 0
  min = 0
  arr2 = arr.clone

  4.times do
    max += arr.max 
    arr.delete(arr.max)
  end
  4.times do
    min += arr2.min
    arr2.delete(arr2.min)
  end

  puts "#{min} #{max}"
end

min_max([1, 2, 3, 4, 5])
min_max([2, 8, 3, 5, 1])

def decimal(bin)
  raise "provide binary number as string" if bin.class != "".class
  dec = 0
  i = 0
  bin.split("").each do |x|
    raise ArgumentError.new "this is not a binary number" if x != "0" and x != "1"
    dec += x.to_i * 2**i
    i += 1
  end
  puts dec
end

decimal("101")
decimal("1011")
decimal("231")