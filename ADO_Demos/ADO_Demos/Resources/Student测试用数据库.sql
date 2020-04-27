-- 新建 student 学生数据库
CREATE DATABASE student;
-- 定位到该数据库
USE student;

SELECT * FROM system_users WHERE ucode='admin' AND upwd='123456' 

-- 新建 system_users 登录账户信息表
CREATE TABLE system_users(
	uid INT IDENTITY PRIMARY KEY,					-- 账户ID
	ucode VARCHAR(10) NOT NULL,					-- 账号
	upwd VARCHAR(10) NOT NULL						-- 账户密码
)
-- 添加测试数据到 system_users 登录账户信息表
INSERT INTO system_users VALUES('101010','123456');
-- 查询 system_users 登录账户信息表数据
SELECT * FROM system_users
-- 清除 system_users 班级信息表数据
TRUNCATE TABLE system_users;


-- 新建 classInfo 班级信息表
CREATE TABLE classInfo(
	cid INT IDENTITY(1,1) PRIMARY KEY,				-- 班级ID
	cname NVARCHAR(20) NOT NULL 				-- 班级编号
)
-- 添加测试数据到 classInfo 班级信息表
INSERT INTO classInfo VALUES('S201'),('S202'),('S203'),('S204'),('S205'),('S206'),('S207'),('S208');
-- 查询 classInfo 班级表数据
SELECT * FROM classInfo
-- 清除 classInfo 班级信息表数据
TRUNCATE TABLE classInfo;

SELECT * FROM classInfo WHERE cname ='S201'

-- 新建 student 学生信息表
CREATE TABLE student(
	sid INT IDENTITY(1000,1) PRIMARY KEY,				-- 学生ID
	sname VARCHAR(20) NOT NULL,							-- 学生姓名
	ssex INT NOT NULL,												-- 学生性别
	sage INT NOT NULL,												-- 学生年龄
	sbirthday DATE NOT NULL,									-- 学生生日
	sphone VARCHAR(20) NOT NULL,							-- 学生电话
	saddress VARCHAR(50) NOT NULL,						-- 学生地址
	scid INT NOT NULL,												-- 学生班级编号
	spassword VARCHAR(6) NOT NULL,						-- 学生登录密码
	foreign key (scid) references classInfo(cid),			-- 关联班级外键
)
-- 添加测试数据到 Student 学生信息表
INSERT INTO student VALUES('Admin',1,DATEDIFF(YY, '1990-01-01', GETDATE()),'1990-01-01','13888888888','湖南长沙',1,'123456');
INSERT INTO student VALUES('张明全',1,DATEDIFF(YY, '1990-01-01', GETDATE()),'1990-01-01','13812345678','湖南长沙',1,'456789');
INSERT INTO student VALUES('李菲',1,DATEDIFF(YY, '1991-02-02', GETDATE()),'1991-02-02','15041576258','湖北宜昌',2,'789123');
INSERT INTO student VALUES('于寄谦',1,DATEDIFF(YY, '1992-03-03', GETDATE()),'1992-03-03','13945624865','甘肃天水',4,'147258');
INSERT INTO student VALUES('刘国正',1,DATEDIFF(YY, '1993-04-04', GETDATE()),'1993-04-04','15842548964','山东荷泽',1,'258369');
INSERT INTO student VALUES('周接轮',1,DATEDIFF(YY, '1995-06-07', GETDATE()),'1995-06-07','17654254892','台湾新竹',4,'369147');
INSERT INTO student VALUES('巩小妹',0,DATEDIFF(YY, '1996-03-22', GETDATE()),'1996-03-22','13545568785','香港龙湾',3,'111222');
INSERT INTO student VALUES('巩大妹',0,DATEDIFF(YY, '1994-02-01', GETDATE()),'1994-02-01','13042148961','香港龙湾',3,'333444');
INSERT INTO student VALUES('张明敏',0,DATEDIFF(YY, '1997-05-12', GETDATE()),'1997-05-12','13848754865','北京顺义',2,'555666');
INSERT INTO student VALUES('矛十八',1,DATEDIFF(YY, '1998-06-07', GETDATE()),'1998-06-07','16514567869','四川棉阳',4,'777888');
INSERT INTO student VALUES('罗林光',1,DATEDIFF(YY, '1999-02-04', GETDATE()),'1999-02-04','17532448546','陕西临潼',2,'999000');
INSERT INTO student VALUES('司马坡',1,DATEDIFF(YY, '1997-04-06', GETDATE()),'1997-04-06','13545678924','新疆喀什',1,'112233');
INSERT INTO student VALUES('罗宇飞',1,DATEDIFF(YY, '1999-04-06', GETDATE()),'1999-04-06','13545645924','浙江杭州',6,'445566');
INSERT INTO student VALUES('吴强',1,DATEDIFF(YY, '1993-08-21', GETDATE()),'1993-08-21','13645646215','云南大理',5,'778899');
INSERT INTO student VALUES('王小明',1,DATEDIFF(YY, '1996-02-23', GETDATE()),'1996-02-23','13701257945','黑龙江鸡西',7,'123123');
INSERT INTO student VALUES('李科',1,DATEDIFF(YY, '1998-09-16', GETDATE()),'1998-09-16','15846532452','浙江杭州',3,'456456');
-- 查询 student 学生信息表数据
SELECT * FROM student AS S
LEFT JOIN classInfo AS C ON C.cid = S.scid
-- 清除 student 学生信息表数据
TRUNCATE TABLE student;


-- 新建 student_backup 学生备份信息表
CREATE TABLE student_backup(
	sid INT IDENTITY(1000,1) PRIMARY KEY,				-- 学生ID
	sname VARCHAR(20) NOT NULL,							-- 学生姓名
	ssex INT NOT NULL,												-- 学生性别
	sage INT NOT NULL,												-- 学生年龄
	sbirthday DATE NOT NULL,									-- 学生生日
	sphone VARCHAR(20) NOT NULL,							-- 学生电话
	saddress VARCHAR(50) NOT NULL,						-- 学生地址
	scid INT NOT NULL,												-- 学生班级编号
	spassword VARCHAR(6) NOT NULL,						-- 学生登录密码
	foreign key (scid) references classInfo(cid),			-- 关联班级外键
)
-- 查询 student_backup 备份表数据
SELECT * FROM student_backup AS S
LEFT JOIN classInfo AS C ON C.cid = S.cid
-- 清除 student_backup 学生信息备份表数据
TRUNCATE TABLE student_backup;


-- 新建 teacher 教师信息表
CREATE TABLE teacher(
	tid INT IDENTITY PRIMARY KEY,								-- 教师ID
	tcid INT NOT NULL,												-- 教室编号
	tname VARCHAR(20) NOT NULL,							-- 教师名字
	tProfession CHAR(1) NOT NULL,							-- 课程专业 (专业：1:体育,2:计算机,3:数学,4:化学)
	tpassword CHAR(6) NOT NULL								-- 登录密码
	foreign key (tcid) references classInfo(cid),			-- 关联班级外键
)
-- 添加测试数据到 teacher 教师信息表
INSERT INTO teacher VALUES(1,'陈政',3,'123456'),(2,'徐柯',1,'456789'),(3,'刘莉',2,'789123');
-- 查询 teacher 学生信息表数据
SELECT * FROM teacher
-- 清除 teacher 学生信息表数据
TRUNCATE TABLE teacher;

SELECT C.cname,T.tname,T.tProfession,T.tpassword FROM teacher AS T
LEFT JOIN classInfo AS C ON T.tcid = C.cid
WHERE tid=1;

-- 新建 Course 课程信息表
CREATE TABLE course(
	cid INT IDENTITY PRIMARY KEY,					-- 课程序号
	ctid INT NOT NULL,										-- 教师编号
	cname NVARCHAR(20) NOT NULL,				-- 课程名称
	climit INT NOT NULL										-- 选课人数
)
-- 添加测试数据到 Course 课程信息表
INSERT INTO Course VALUES(1,'多维运算与应用',0),(2,'户外体育',0),(3,'Android软件开发',0);
-- 查询 Course 课程信息表数据
SELECT * FROM Course
-- 清除 Course 课程信息表数据
TRUNCATE TABLE Course;


-- 新建 SC_Mapping 成绩表
CREATE TABLE SC_Mapping(
	scid INT IDENTITY PRIMARY KEY,								-- 序号
	sid INT NOT NULL,													-- 学生编号
	cid INT NOT NULL,													-- 课程编号
	score INT NOT NULL													-- 分数
	foreign key (scid) references course(cid),					-- 关联课程表外键
	foreign key (cid) references course(cid)						-- 关联课程表外键
)
-- 添加测试数据到 SC_Mapping 成绩表
INSERT INTO SC_Mapping VALUES(1000,1,80),(1000,2,90),(1000,3,100);
-- 查询 SC_Mapping 成绩表数据
SELECT * FROM SC_Mapping
-- 清除 SC_Mapping 成绩表数据
TRUNCATE TABLE SC_Mapping;

SELECT SC.scid,S.sname,C.cname,SC.score FROM SC_Mapping AS SC
LEFT JOIN student AS S ON SC.sid = S.sid
LEFT JOIN course AS C ON SC.cid = C.cid
WHERE SC.sid = 1000

-----------------------------------------------------------------------------------------------------

-- 删除行(测试触发器效果)
DELETE FROM student WHERE sid=1015

-- 更新Student主表管理员账号生日年份数据
UPDATE student SET sbirthday=DATEADD(YY,1,sbirthday) WHERE sid=1000;

-- 清除Student主表内数据
TRUNCATE TABLE student;

-- 清除Student备份表内数据
TRUNCATE TABLE student_backup;

-- 约束条件：三天内的Student表信息
-- WHERE DATEDIFF(DD,sbirthday,GETDATE())=3

-- 排序方式：生日倒序排列
-- ORDER BY sbirthday DESC;

-- 高级查询：查询Student主表全部信息(性别数值转换成汉字，日期字符串分割间隔为年月日，生日降序排列，判断所属年龄段)
SELECT
	S.sid AS '学生ID',
	S.sname AS '学生姓名',
	(
		CASE S.ssex
		WHEN'1' THEN'男'
		WHEN'0' THEN'女'
		ELSE '变性人'
		END
	) AS '学生性别',
	S.sage AS '学生年龄',
	(
		CAST(YEAR(S.sbirthday) AS CHAR(4)) +'年'+
		CAST(MONTH(S.sbirthday) AS VARCHAR(2)) +'月'+
		CAST(DAY(S.sbirthday) AS VARCHAR(2)) +'日'
	) AS '学生生日',
	S.sphone AS '学生电话',
	S.saddress AS '学生地址',
	C.cname AS '学生班级',
	S.spassword AS '学生登录密码',
	(
		CASE
		WHEN S.sage<=18 THEN'未成年'
		WHEN S.sage BETWEEN 18 AND 30 THEN'青年'
		WHEN S.sage BETWEEN 30 AND 60 THEN'中年'
		WHEN S.sage>60 THEN'老年'
		END
	) AS '所属年龄段'
FROM student AS S
LEFT JOIN classInfo AS C ON C.cid = S.scid



SELECT * FROM student WHERE sid=1015
UPDATE student set sname='',sage=20 WHERE sid=1000;

SELECT S.sid,S.sname,S.ssex,S.sage,S.sbirthday,S.sphone,S.saddress,C.cname FROM student AS S LEFT JOIN classInfo AS C ON C.cid = S.cid

SELECT S.sid,S.sname,S.ssex,S.sage,S.sbirthday,S.sphone,S.saddress,C.cname,S.spassword FROM student AS S LEFT JOIN classInfo AS C ON C.cid = S.scid WHERE sid=1000