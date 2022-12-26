#!/bin/bash
# dùng vòng lặp while tính tổng dãy số nhập vào từ bàn phím
declare -i sum
declare -i num
k="y"
while [ $k == "y" ] ; do
echo "ban nhap so "
read num
sum=$sum+$num
echo "bạn có muốn tiếp tục nhập số không (y/n) "
read k
done
echo "tổng các số đã nhập là : " $sum
exit 0
