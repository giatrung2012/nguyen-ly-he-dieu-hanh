#!/bin/bash
#ví dụ về sử dụng cấu trúc if
declare -i a
declare -i b
echo "nhap so thu nhat"
read a
echo "nhap so thu hai"
read b
if [ $a -gt $b ] ; then
  echo "$a > $b"
else
  echo "$a < $b"
fi
exit 0
