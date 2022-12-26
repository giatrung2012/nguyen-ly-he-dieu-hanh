#!/bin/bash
# dùng lệnh test để tính biểu thức sau if (tương tự [ ])
if test $USER == "root"
  # dùng phép so sánh với chuỗi ;
then
  echo "ban dang dung tai khoản root"
else
  echo "ban dang dung tai khoản " $USER
fi
exit 0
