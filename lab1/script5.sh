#!/bin/bash
#ví dụ về sử dụng biến trong script
declare -i a
declare -i b
declare -i sum
echo "nhap so thu nhat"
read a
echo "nhap so thu hai"
read b
sum=$a+$b
#có thể sử dụng những cách khác
#để tính giá trị của biểu thức này
#như dùng expr , hay $(( )) .
#Không cần khai báo biến bằng declare khi
#dùng expr hay $(( ))
echo "tổng 2 số là : $sum "
exit 0
