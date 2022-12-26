#!/bin/bash
# dùng lệnh test để kiểm tra sự tồn tại của file
#sử dụng các option kiểm tra với file, chẳng hạn: -f
if [ -f ~/myscript/vd1 ] ; then
echo "file ~/myscript/vd1 có tồn tại "
else
echo "không tồn tại file ~/myscript/vd1 "
fi
exit 0
