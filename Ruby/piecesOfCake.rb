def factorial(num)
    raise "cannot count factorial for negative number" if num.negative?
    return 1 if num==0
    (1..num).inject() {|res, n| res*n }
  end
  
  module InstanceModule
    def square
      self*self
    end
  end
  
  module ClassModule
    def sample(size)
      raise ArgumentError.new "the number must be positive" if size < 0
      Array.new(size) { rand(1...size) }
    end
  end
  
  class Integer
    extend ClassModule
    include InstanceModule
  
    def factorial
      raise "cannot count factorial for negative number" if self.negative?
      return 1 if self==0
      (1..self).inject() {|res, n| res*n }
    end
  end
  
  puts "#{factorial(3)}"
  puts "#{0.factorial}"
  puts "#{4.factorial}"
  puts "#{5.square}"
  puts "#{Integer.sample(4)}"
  
  #errors
  puts "#{Integer.sample(-1)}"
  puts "#{-4.factorial}"
  puts "#{factorial(-4)}"
  