#!/bin/bash
# tên file có thể truyền vào từ dòng lệnh khi gọi chạy script
# và được gọi là tham số vị trí , có tên là $1, $2, $3, ...
if [ -f $1 ] ; then
  echo "file $1 có tồn tại "
else
  echo "không tồn tại file $1 "
fi
exit 0
