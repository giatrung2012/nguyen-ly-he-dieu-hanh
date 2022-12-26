#!/bin/bash
#vi du về cách xuất thông tin hệ thống
echo "ngay hom nay la : `date` "
echo "tên máy : $HOSTNAME "
echo "tài khoản login : $USER"
echo "shell mặc định : $SHELL"
echo "số người đang đăng nhập hệ thống : `who |wc -l`"
echo "have a lot of fun!!!!"
exit 0
