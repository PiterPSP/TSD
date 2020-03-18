$myArray = @()
for ($i=1;$i -le 10000; $i++) {$myArray += Get-Random -Minimum 1 -Maximum 100000}  

$myList = New-Object System.Collections.Generic.List[int]
foreach($s in $myArray){ $myList.Add($s) }

Measure-Command { $myArray | sort }

Measure-Command { $myList.Sort() }
