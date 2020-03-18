# 1. CPU
Get-Process | where-object {$_.cPU -ge 10} | Select-Object -Property Name, CPU | Out-File -FilePath ".\ProcessesCPU.txt"

# 3. MSDN
$i = 1
foreach($line in Get-Content .\MSDN.txt) {
    if($line -match "PowerShell"){
        Write-Host $i $line
    }
    $i++
}

#4. Salary
Import-Csv .\employees.csv | 
Select-Object *,@{Name='Monthly Salary';Expression={$_.SALARY/12}} -outvariable csv
$csv | sort "Monthly Salary" -desc