## 创建sql库
- 可视化工具下载
https://github.com/pawelsalawa/sqlitestudio/releases/download/3.3.3/sqlitestudio-3.3.3.zip

- sqlite安装
https://www.sqlite.org/download.html
您需要下载 sqlite-tools-win32-*.zip 和 sqlite-dll-win32-*.zip 压缩文件。

在目录C:\sqlite
- cmd
 ```
sqlite3 Alarm.db
.open Alarm.db
 ```

## 创建表
 - 最后一个字段无逗号
 - 语句以英文分号结尾
 ```
PRAGMA foreign_keys = 0;

CREATE TABLE sqlitestudio_temp_table AS SELECT *
                                          FROM Alarm;

DROP TABLE Alarm;

CREATE TABLE Alarm (
   
    Tag TEXT    NOT NULL,
    Message       TEXT    ,
    TimeTicks           TEXT  ,
    AlmQueryValue             TEXT,
    TimestampOccurrence        TEXT,
    TimestampCurrent           TEXT,
    Cost TEXT
);