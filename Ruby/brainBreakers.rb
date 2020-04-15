class Clock
  def initialize(hrs, min, sec)
    raise "Incorrect time passed!" if hrs < 0 || min < 0 || sec < 0 || hrs > 23 || min > 59 || sec > 59
    @hrs = hrs
    @min = min
    @sec = sec
  end

  def +(x)
    raise "Time must be positive!" if x < 0
    min = @min + x % 60

    hrs = 0
    if (min > 59)
      min = min % 60
      hrs = 1
    end

    hrs += @hrs + x / 60
    hrs = hrs % 24 if hrs > 23

    Clock.new(hrs, min, @sec)
  end

  def -(x)
    raise "Time must be positive!" if x < 0
    min = @min - x % 60

    hrs = 0
    if (min < 0)
      min = 60 - (-min % 60)
      hrs = -1
    end

    hrs += @hrs - x / 60
    hrs = 24 - (-hrs % 24) if hrs < 0

    Clock.new(hrs, min, @sec)
  end

   def ==(clock)
    clock.class == self.class && clock.state == state
  end

  def state
    [@hrs, @min, @sec]
  end

  def print
    puts "The current time is #{format('%02d', @hrs)}:#{format('%02d', @min)}:#{format('%02d', @sec)}"
  end
end

clock = Clock.new(22, 50, 0)
clock.print
clock += 1440
clock.print
clock += 10
clock.print
clock += 70
clock.print
clock -= 121
clock.print
clock -= 1441
clock.print
puts clock == Clock.new(22, 8, 0)
puts clock == Clock.new(21, 8, 0)