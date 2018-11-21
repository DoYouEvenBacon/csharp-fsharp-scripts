set PATH="C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\MSBuild\15.0\Bin\Roslyn\";%PATH%


cd C:\pathOfSourceCode
if exist frequency.exe del atan574.exe
csc atan574.cs
pause


.\atan574.exe test1.txt 2
.\atan574.exe test1.txt 10
.\atan574.exe test1.txt
.\atan574.exe test12.txt
.\atan574.exe

.\atan574.exe test123.txt 3
.\atan574.exe test123.txt xyz
.\atan574.exe test1.txt -1
pause
