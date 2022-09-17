@echo off
echo RUNNING SCRIPT DETELE DEBUG FILE E_COMMERCE PROJECT
pause

rmdir /q /s  .\E-Commerce\E-Commerce\obj\
echo DETELE  \E-Commerce\E-Commerce\obj\ Successfully!

rmdir /q /s .\E-Commerce-Business-Logic\obj\
echo DETELE  \E-Commerce-UnitTest\obj\ Successfully!

rmdir /q /s .\E-Commerce-Repository\obj\
echo DETELE  \E-Commerce-Repository\obj\ Successfully!

rmdir /q /s .\E-Commerce-UnitTest\obj\
echo DETELE  \E-Commerce-UnitTest\obj\ Successfully!

pause
