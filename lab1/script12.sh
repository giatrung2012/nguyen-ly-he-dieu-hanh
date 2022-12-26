#!/bin/bash
# viết lại script 5 , sử dụng 2 tham số vị trí ($1, $2) để
# truyền vào từ dòng lệnh 2 số a, b
declare -i sum
sum=$1+$2
echo "tổng 2 số là : $sum "
exit 0
