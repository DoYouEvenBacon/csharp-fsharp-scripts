set PATH="C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\MSBuild\15.0\Bin\Roslyn\";%PATH%


cd C:\pathOfSourceCode
if exist wordFrequency.exe del wordFrequency.exe
csc wordFrequency.cs
pause


.\wordFrequency.exe test1.txt 2
.\wordFrequency.exe test1.txt 10
.\wordFrequency.exe test1.txt
.\wordFrequency.exe test12.txt
.\wordFrequency.exe
.\wordFrequency.exe test123.txt 3
.\wordFrequency.exe test123.txt xyz
.\wordFrequency.exe test1.txt -1
pause
