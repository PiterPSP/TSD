function Multiply {
    param ($num1, $num2)
    return $num1 * $num2
}

Multiply 2 5
Multiply 4 -3

function Increment {
    param ($num1, $num2 = 1)
    return $num1 + $num2
}

Increment 2
Increment 4 2

#Date
Get-Date -UFormat "%A, %B %d, %Y"

#Hidden files
gci C:\Users\helminiakp -recurse -Filter Desktop.ini -ErrorAction "silentlycontinue" -Force

#Bigger than 1MB
gci C:\Users\helminiakp -recurse | where-object {$_.length -gt 1048576}

#Sort by name
gci | sort Name | select Name, Length

