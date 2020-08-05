# 学生选课系统  
## Bilibili教程:  
B站教学链接：https://www.bilibili.com/video/BV1zJ411k7cQ/?p=1  
## 说明
1、数据库使用的是Access，与视频中SQLserver大同小异，只是类名不同  
2、sql语句使用了string.Format(“”); 或$"{};这两种格式书写的，结构上更清晰一些  
示例:  
string sql1 = string.Format("select * from 选课记录表 where SID='{0}' and CID='{1}'", SID, CID);  
string sql = $"select * from 选课记录表 where SID='{SID}'";  
3、使用的图标、图片均位于Resources文件夹内  
##  更新记录
2020.8.3，更新到第7讲选课部分  
2020.8.4，更新到第9讲，完成选课与删除已选课程功能  
2020.8.4，更新到第10讲，完成管理员修改教师信息功能  
2020.8.5，更新到第11讲，完成密码修改功能  
2020.8.5，更新图标与部分交互逻辑 
