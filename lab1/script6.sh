#!/bin/bash
#ví dụ về sử dụng biến trong script
echo "nhap so thu nhat"
read a
#a lưu dữ liệu kiểu chuỗi
echo "nhap so thu hai"
read b
#b lưu dữ liệu kiểu chuỗi
sum=$a+$b
echo "tổng 2 số là : $sum "
exit 0
