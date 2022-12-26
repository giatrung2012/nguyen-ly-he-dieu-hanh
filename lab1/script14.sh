#!/bin/bash
# dùng vòng lặp while in ra 5 dòng ký tự
declare -i k
k=0
while [ $k -lt 5 ] ; do
  echo "hello"
  k=$k+1
done
exit 0
