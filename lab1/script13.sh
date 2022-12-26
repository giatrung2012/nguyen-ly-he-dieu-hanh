#!/bin/bash
# viết lại script 5 , sử dụng 3 tham số vị trí ($1, $2 , $3) để
#truyền vào từ dòng lệnh 2 số a, b, và phép tinh cần thực hiện
declare -i kq
if [ $3 == "+" ] ; then
  kq=$1+$2
else
  kq=$1-$2
fi
echo "ket qua $1 $3 $2 là : $kq"
exit 0
